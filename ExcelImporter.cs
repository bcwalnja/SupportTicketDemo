using SupportTicketDemo.BLL.Events;
using SupportTicketDemo.DAL.Database;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SupportTicketDemo.Classes
{
    public class ExcelImporter : INotifyPropertyChanged
    {
        public GridView gridViewExcelSource { get; set; }
        public List<DataMap> MappingData { get; set; }
        public Type Destination { get; set; }
        private int totalRows;
        public int TotalRows
        {
            get
            {
                return totalRows;
            }
            set
            {
                SetProperty(ref totalRows, value);
            }
        }
        private int rowsComplete;
        public int RowsComplete
        {
            get
            {
                return rowsComplete;
            }
            set
            {
                SetProperty(ref rowsComplete, value);
            }
        }

        public ExcelImporter(GridView gridView, List<DataMap> mappingData, Type destination)
        {
            gridViewExcelSource = gridView ?? throw new ArgumentNullException(nameof(gridView));
            MappingData = mappingData ?? throw new ArgumentNullException(nameof(mappingData));
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));
        }

        public Task Import()
        {
            return Task.Run(() =>
            {
                this.RowsComplete = 0;
                TotalRows = gridViewExcelSource.DataRowCount;
                UpdateProgress();

                if (MappingDataIsEmpty())
                {
                    return;
                }

                RemoveUnusedMappingFields();

                var unitOfWork = new UnitOfWork();

                for (int i = 0; i < gridViewExcelSource.DataRowCount; i++)
                {
                    RowsComplete = i;
                    UpdateProgress();
                    var newObject = Activator.CreateInstance(Destination, unitOfWork) as XPObject;
                    SetAllFieldValues(i, newObject);
                }

                unitOfWork.CommitTransaction();
            });
        }

        private bool MappingDataIsEmpty()
        {
            return MappingData.All(x => string.IsNullOrWhiteSpace(x.ImportColumn))
                && MappingData.All(x => x.DefaultValue == null);
        }

        private void RemoveUnusedMappingFields()
        {
            for (int i = MappingData.Count - 1; i >= 0; i--)
            {
                var map = MappingData[i];
                if ((string.IsNullOrWhiteSpace(map.ImportColumn) ||
                map.IsAssociation) &&
                map.DefaultValue is null)
                {
                    MappingData.Remove(map);
                }
            }
        }

        private void UpdateProgress()
        {
            EventMediator.GetInstance().OnImportProgressUpdated(RowsComplete, TotalRows);
        }

        private void SetAllFieldValues(int i, XPObject newObject)
        {
            foreach (var map in MappingData)
            {
                try
                {
                    if (map.IsAssociation)
                    {
                        //TODO: figure out how to handle creating Many-to-Many entries
                        //continue;

                        if (map.DefaultValue is XPObject targetType)
                        {
                            XPObject linking = FindLinkingTable(newObject, targetType);

                            if (linking is null)
                            {
                                continue;
                            }

                            SetLinkingEntryValues(newObject, targetType, linking);
                            continue; 
                        }
                    }

                    object value = GetValue(i, map);

                    if (value is null)
                    {
                        continue;
                    }

                    SetFieldValue(newObject, map, value);
                }
                catch
                {
                    continue;
                }
            }
        }

        private object GetValue(int i, DataMap map)
        {
            object value = null;

            if (!string.IsNullOrWhiteSpace(map.ImportColumn))
            {
                GridColumn colImport = gridViewExcelSource.Columns[map.ImportColumn];
                value = gridViewExcelSource.GetRowCellValue(i, colImport);
            }

            value = value ?? map.DefaultValue;
            return value;
        }

        private static XPObject FindLinkingTable(XPObject newObject, XPObject targetType)
        {
            var types = ConnectionHelper.GetPersistentTypes();
            var session = newObject.Session;
            XPObject linking = null;

            foreach (Type xpType in types)
            {
                var meta = session.GetClassInfo(xpType);
                bool hasRootType = false;
                bool hasTargetType = false;
                foreach (var item in meta.PersistentProperties)
                {
                    if (item is ReflectionPropertyInfo info)
                    {
                        if (info.MemberType == newObject.ClassInfo.ClassType)
                        {
                            hasRootType = true;
                        }
                        if (info.MemberType == targetType.ClassInfo.ClassType)
                        {
                            hasTargetType = true;
                        }
                        if (hasRootType && hasTargetType)
                        {
                            // Create new object of that XP Table
                            linking = Activator.CreateInstance(xpType, session) as XPObject;
                            break;
                        }
                    }
                }
                if (hasRootType && hasTargetType)
                {
                    break;
                }
            }

            return linking;
        }

        private static void SetLinkingEntryValues(XPObject newObject, XPObject targetType, XPObject linking)
        {
            var session = newObject.Session;
            linking.SetMemberValue(newObject.ClassInfo.ClassType.Name, newObject);
            var defaultValue = session.GetObjectByKey(targetType.GetType(), targetType.Oid);
            linking.SetMemberValue(targetType.ClassInfo.ClassType.Name, defaultValue);
        }

        private static void SetFieldValue(XPObject newObject, DataMap map, object value)
        {
            var fieldType = newObject.ClassInfo.GetPersistentMember(map.PropertyName).MemberType;

            if (value.GetType() != fieldType)
            {
                var result = Convert.ChangeType(value, fieldType);
                newObject.SetMemberValue(map.PropertyName, result);
            }
            else
            {
                newObject.SetMemberValue(map.PropertyName, value);
            }
        }

        #region INotifyPropertyChanged
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
