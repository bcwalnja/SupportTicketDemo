using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportTicketDemo.Classes
{
    public class DataMap
    {
        public string PropertyName { get; set; }
        public string ImportColumn { get; set; }
        public object DefaultValue { get; set; }
        /// <summary>If the property is the 'many' side of a one-to-many association.</summary>
        public bool IsAssociation { get; set; } = false;

        public DataMap() { }

        public DataMap(string propertyName)
        {
            this.PropertyName = propertyName;
        }

        public DataMap(string propertyName, bool isAssociation)
        {
            this.PropertyName = propertyName;
            this.IsAssociation = isAssociation;
            this.ImportColumn = "(N/A for linking fields)";
        }
    }
}
