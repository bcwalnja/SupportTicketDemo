using SupportTicketDemo.DAL.Database;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;

namespace SupportTicketDemo.BLL.Helpers
{
    public static class CriteriaController
    {
        public static CriteriaOperator GetActiveDeletedCriteria()
        {
            return CriteriaOperator.And(GetActive(), GetDeletedCriteria());
        }

        public static CriteriaOperator GetActive()
        {
            return new BinaryOperator(nameof(Address.Active), true);
        }

        public static CriteriaOperator GetDeletedCriteria()
        {
            return new BinaryOperator(nameof(Address.Deleted), false);
        }

        public static SortProperty GetSortProperty(string property, bool ascending = true)
        {
            if (ascending)
            {
                return new SortProperty(property, DevExpress.Xpo.DB.SortingDirection.Ascending);
            }
            else
            {
                return new SortProperty(property, DevExpress.Xpo.DB.SortingDirection.Descending);
            }
        }

        public static SortProperty[] GetAddressSortingCollection()
        {
            var byState = GetSortProperty(nameof(Address.State));
            var byCity = GetSortProperty(nameof(Address.City));
            var byAddress1 = GetSortProperty(nameof(Address.Address1));
            var byAddress2 = GetSortProperty(nameof(Address.Address2));
            var byLastName = GetSortProperty(nameof(Address.LastName));
            var byFirstName = GetSortProperty(nameof(Address.FirstName));
            var byBusiness = GetSortProperty(nameof(Address.Business));
            return new SortProperty[] 
            { 
                byState, 
                byCity, 
                byAddress1, 
                byAddress2, 
                byLastName, 
                byFirstName, 
                byBusiness 
            };
        }
    }
}
