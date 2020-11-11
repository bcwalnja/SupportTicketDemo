using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace SupportTicketDemo.DAL.Database
{

    public partial class Address
    {
        public Address(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
