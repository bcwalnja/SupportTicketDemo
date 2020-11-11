using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace SupportTicketDemo.DAL.Database
{

    public partial class Form
    {
        public Form(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
