using System;
using DevExpress.DataAccess.Excel;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.SpreadsheetSource;
using DevExpress.Xpo;
using SupportTicketDemo.Classes;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data.Filtering;
using System.Reflection;
using SupportTicketDemo.DAL.Database;
using SupportTicketDemo.BLL.Helpers;
using DevExpress.XtraEditors.Repository;
using System.Collections;
using DevExpress.XtraEditors;
using SupportTicketDemo.BLL.Events;
using DevExpress.Xpo.Metadata;

namespace SupportTicketDemo.Forms
{
    public partial class ExcelImportForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string Filename { get; private set; }
        public bool IsBusy { get; private set; }
        public List<DataMap> MappingInfo { get; set; }
        public Type Persistent { get; private set; }

        private readonly UnitOfWork unitOfWork;
        private GridColumn colDefault;
        private GridColumn colIsAssociation;
        private GridColumn colImport;
        private GridColumn colProperty;
        private ExcelDataSource excelDataSource;

        private delegate void ProgressDelegate(object sender, ImportEventArgs e);

        public ExcelImportForm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            MappingInfo = new List<DataMap>();
        }

        #region Methods
        private static RepositoryItemDateEdit CreateDateEdit()
        {
            return new RepositoryItemDateEdit()
            {
                VistaCalendarInitialViewStyle = VistaCalendarInitialViewStyle.YearView,
                VistaCalendarViewStyle = VistaCalendarViewStyle.YearView,
                EditMask = "y"
            };
        }

        private static RepositoryItemLookUpEdit CreateLookupEdit(IList datasource)
        {
            return new RepositoryItemLookUpEdit
            {
                DataSource = datasource,
                TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor,
                AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.False,
                BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup,
                NullText = string.Empty,
            };
        }

        private static RepositoryItemTextEdit CreateNumericEdit(string mask)
        {
            var edit = new RepositoryItemTextEdit();
            edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            edit.Mask.EditMask = mask;
            return edit;
        }

        private void CreateMappingEntryForEachLinkingTable()
        {
            XPClassInfo classInfo = unitOfWork.GetClassInfo(this.Persistent);

            foreach (var info in classInfo.AssociationListProperties)
            {
                if (info is ReflectionPropertyInfo propertyInfo &&
                    propertyInfo.CollectionElementType != null)
                {
                    if (propertyInfo.IsManyToMany)
                    {
                        AddToMap(info, true);
                        continue;
                    }

                    foreach (var field in propertyInfo.CollectionElementType.PersistentProperties)
                    {
                        if (FieldIsOtherEndOfLinkingTable(field))
                        {
                            AddToMap(info, true);
                        }
                    }
                }
            }
        }

        private void AddToMap(object info)
        {
            var map = new DataMap(info.ToString());
            MappingInfo.Add(map);
        }

        private void AddToMap(object info, bool isAssociation)
        {
            var map = new DataMap(info.ToString(), isAssociation);
            MappingInfo.Add(map);
        }

        private void CreateMappingInfoEntryForPersistentProperties()
        {
            XPClassInfo classInfo = unitOfWork.GetClassInfo(this.Persistent);

            foreach (var info in classInfo.PersistentProperties)
            {
                if (IsBaseXPObjectProperty(info))
                {
                    continue;
                }
                if (HasCustomAttribute(info))
                {
                    continue;
                }

                AddToMap(info);
            }
        }

        private bool HasCustomAttribute(object info)
        {
            if (info is ReflectionPropertyInfo t)
            {
                var attributes = t.Attributes;
                return attributes.Any(x => x is DAL.Classes.ExcludeFromImport);
            }

            return false;
        }

        private bool FieldIsOtherEndOfLinkingTable(object item)
        {
            return item is ReflectionPropertyInfo i &&
                i.IsAssociation && !(i.MemberType == this.Persistent);
        }

        private async void ImportExcelDataIntoDatabase()
        {
            try
            {
                var message = "The program will read into memory all rows from the spreadsheet, " +
                            "and then process saving them to the database.\n" +
                            "Ready to begin the import process?";
                var dr = XtraMessageBox.Show(message, "Begin Import?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                {
                    return;
                }

                var importer = new ExcelImporter(gridViewExcelSource, MappingInfo, Persistent);
                EventMediator.GetInstance().OnImportStarted();
                EventMediator.GetInstance().ImportProgressUpdated += OnProgressUpdated;

                marquee.Properties.Stopped = false;
                await importer.Import();

                message = "Data has been imported successfully!";
                XtraMessageBox.Show(message, "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                marquee.Properties.Stopped = true;
                EventMediator.GetInstance().OnImportComplete();
            }
            catch (Exception ex)
            {
                ex.Report();
            }
        }

        private static bool IsBaseXPObjectProperty(object info)
        {
            return info.ToString() == nameof(XPObject.Oid) ||
                info.ToString() == nameof(XPObject.Fields.GCRecord) ||
                info.ToString() == nameof(XPObject.Fields.OptimisticLockField);
        }

        private void CheckTypeAndCreateColumnEditorForDefaultColumn()
        {
            if (gridViewMapping.GetFocusedRow() is DataMap map)
            {
                Type member = GetFieldType(map);

                if (member is null)
                {
                    return;
                }
                else if (member.IsSubclassOf(typeof(XPObject)))
                {
                    CriteriaOperator criteria = null;
                    foreach (PropertyInfo property in member.GetProperties())
                    {
                        if (property.Name == nameof(Address.Active))
                        {
                            criteria = CriteriaOperator.And(criteria, CriteriaController.GetActive());
                        }
                        if (property.Name == nameof(Address.Deleted))
                        {
                            criteria = CriteriaOperator.And(criteria, CriteriaController.GetDeletedCriteria());
                        }
                    }

                    var datasource = new XPCollection(unitOfWork, unitOfWork.GetClassInfo(member), criteria);

                    var lookup = CreateLookupEdit(datasource);
                    colDefault.ColumnEdit = lookup;

                    colDefault.OptionsColumn.AllowEdit = true;
                }
                else if (member == typeof(bool))
                {
                    var list = new List<bool>() { true, false };
                    colDefault.ColumnEdit = CreateLookupEdit(list);
                    colDefault.OptionsColumn.AllowEdit = true;
                }
                else if (member == typeof(DateTime))
                {
                    colDefault.ColumnEdit = CreateDateEdit();
                    colDefault.OptionsColumn.AllowEdit = true;
                }
                else if (member == typeof(int))
                {
                    colDefault.ColumnEdit = CreateNumericEdit("d");
                    colDefault.OptionsColumn.AllowEdit = true;
                }
                else
                {
                    colDefault.ColumnEdit = null;
                    colDefault.OptionsColumn.AllowEdit = true;
                }
            }
        }

        private Type GetFieldType(DataMap map)
        {
            if (map.IsAssociation)
            {
                XPClassInfo classInfo = unitOfWork.GetClassInfo(this.Persistent);
                foreach (var item in classInfo.AssociationListProperties)
                {
                    if (item is ReflectionPropertyInfo propertyInfo &&
                        propertyInfo.Name == map.PropertyName)
                    {
                        if (propertyInfo.IsManyToMany)
                        {
                            return propertyInfo.CollectionElementType.ClassType;
                        }
                        foreach (var field in propertyInfo.CollectionElementType.PersistentProperties)
                        {
                            if (FieldIsOtherEndOfLinkingTable(field))
                            {
                                return (field as ReflectionPropertyInfo).MemberType;
                            }
                        }
                    }
                }
            }
            else
            {
                var info = unitOfWork.GetClassInfo(this.Persistent);
                return info.FindMember(map.PropertyName).MemberType;
            }

            return null;
        }

        private void IfIsAssociationPreventEditingColImport()
        {
            if (gridViewMapping.GetFocusedRow() is DataMap map && map.IsAssociation)
            {
                colImport.OptionsColumn.AllowEdit = false;
            }
            else
            {
                colImport.OptionsColumn.AllowEdit = true;
            }
        }

        private string GetWorksheetNameByIndex(int p, string fileName)
        {
            string worksheetName = "";
            using (ISpreadsheetSource spreadsheetSource = SpreadsheetSourceFactory.CreateSource(fileName))
            {
                IWorksheetCollection worksheetCollection = spreadsheetSource.Worksheets;
                worksheetName = worksheetCollection[p].Name;
            }
            return worksheetName;
        }

        private async void LoadExcelFileSetGridviewLookupDatasources()
        {
            marquee.Properties.Stopped = false;

            await Task.Run(() =>
            {
                try
                {
                    this.excelDataSource = new ExcelDataSource();
                    excelDataSource.FileName = this.Filename;

                    ExcelWorksheetSettings exlWS = new ExcelWorksheetSettings(GetWorksheetNameByIndex(0, this.Filename));
                    ExcelSourceOptions exlSO = new ExcelSourceOptions(exlWS);
                    excelDataSource.SourceOptions = exlSO;

                    excelDataSource.Fill();
                }
                catch (Exception ex)
                {
                    ex.Report();
                }
            });

            gridControlExcelSource.DataSource = excelDataSource;
            gridControlExcelSource.Refresh();
            SetColumnHeadersAsLookupDatasource();
            marquee.Properties.Stopped = true;
        }

        private void LoadAllPropertiesForMappingGridview()
        {
            List<Type> persistent = ConnectionHelper.GetPersistentTypes().ToList();
            cboPersistent.Properties.Items.AddRange(persistent);
            gridControlMapping.DataSource = MappingInfo;

            if (gridViewMapping.Columns.Count > 1)
            {
                colProperty = gridViewMapping.Columns[nameof(DataMap.PropertyName)];
                colImport = gridViewMapping.Columns[nameof(DataMap.ImportColumn)];
                colDefault = gridViewMapping.Columns[nameof(DataMap.DefaultValue)];
                colIsAssociation = gridViewMapping.Columns[nameof(DataMap.IsAssociation)];

                colProperty.OptionsColumn.AllowFocus = false;
                colImport.OptionsColumn.AllowEdit = false;
                colDefault.OptionsColumn.AllowEdit = false;
                colIsAssociation.Visible = false;
            }
        }

        private void SetColumnHeadersAsLookupDatasource()
        {
            var headers = gridViewExcelSource.Columns.Select(x => x.FieldName).ToList();
            lkpField.Items.Clear();
            foreach (var item in headers)
            {
                lkpField.Items.Add(item);
            }
            foreach (var map in MappingInfo)
            {
                map.ImportColumn = null;
            }
            colImport.ColumnEdit = lkpField;
        }
        #endregion

        #region Event Handlers
        private void OnCboPersistentSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Persistent = cboPersistent.EditValue as Type;

                this.MappingInfo.Clear();

                CreateMappingInfoEntryForPersistentProperties();
                CreateMappingEntryForEachLinkingTable();

                colImport.ColumnEdit = lkpField;
                gridControlMapping.DataSource = MappingInfo;
                gridControlMapping.Refresh();
                gridViewMapping.RefreshData();
            }
            catch (Exception ex)
            {
                ex.Report();
            }
        }

        private void OnChooseFileEditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender is ButtonEdit editor)
                {
                    this.Filename = editor.EditValue.ToString();
                    LoadExcelFileSetGridviewLookupDatasources();
                }
            }
            catch (Exception ex)
            {
                ex.Report();
            }
        }

        private void OnCustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            try
            {
                if (e.Column == colDefault)
                {
                    e.DisplayText = e.Value?.ToString();
                }
            }
            catch (Exception ex)
            {
                ex.Report();
            }
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            try
            {
                LoadAllPropertiesForMappingGridview();
            }
            catch (Exception ex)
            {
                ex.Report();
            }
        }

        private void OnGridviewBeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            try
            {
                colDefault.ColumnEdit = null;
                colDefault.OptionsColumn.AllowEdit = false;
                colImport.OptionsColumn.AllowEdit = false;
            }
            catch (Exception ex)
            {
                ex.Report();
            }
        }

        private void OnImportClick(object sender, EventArgs e)
        {
            try
            {
                if (excelDataSource is null)
                {
                    return;
                }

                ImportExcelDataIntoDatabase();
            }
            catch (Exception ex)
            {
                ex.Report();
            }
        }

        private void OnMappingRowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left)
                    return;
                if (e.Column == colDefault)
                {
                    CheckTypeAndCreateColumnEditorForDefaultColumn();
                }
                if (e.Column == colImport)
                {
                    IfIsAssociationPreventEditingColImport();
                }
            }
            catch (Exception ex)
            {
                ex.Report();
            }
        }

        private void OnProgressUpdated(object sender, BLL.Events.ImportEventArgs e)
        {
            if (this.IsBusy)
            {
                return;
            }
            else if (this.InvokeRequired)
            {
                var del = new ProgressDelegate(OnProgressUpdated);
                this.BeginInvoke(del, sender, e);
                return;
            }

            IsBusy = true;
            progress.Properties.Maximum = e.Total;
            progress.Position = e.Current;
            progress.Update();
            IsBusy = false;
        }
        #endregion
    }
}