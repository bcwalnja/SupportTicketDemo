﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace SupportTicketDemo.DAL.Database
{

    [Persistent(@"tblSubscription")]
    public partial class Subscription : XPObject
    {
        Publication fPublication;
        [Persistent(@"lnk_publication")]
        [Association(@"SubscriptionReferencesPublication")]
        public Publication Publication
        {
            get { return fPublication; }
            set { SetPropertyValue<Publication>(nameof(Publication), ref fPublication, value); }
        }
        string fPaymentMethod;
        [Size(SizeAttribute.Unlimited)]
        [Persistent(@"tx_paymentMethod")]
        public string PaymentMethod
        {
            get { return fPaymentMethod; }
            set { SetPropertyValue<string>(nameof(PaymentMethod), ref fPaymentMethod, value); }
        }
        bool fPaid;
        [Persistent(@"yn_paid")]
        public bool Paid
        {
            get { return fPaid; }
            set { SetPropertyValue<bool>(nameof(Paid), ref fPaid, value); }
        }
        DateTime fCreated;
        [Persistent(@"dt_created")]
        public DateTime Created
        {
            get { return fCreated; }
            set { SetPropertyValue<DateTime>(nameof(Created), ref fCreated, value); }
        }
        DateTime fExpires;
        [Persistent(@"dt_expires")]
        public DateTime Expires
        {
            get { return fExpires; }
            set { SetPropertyValue<DateTime>(nameof(Expires), ref fExpires, value); }
        }
        Address fAddress;
        [Persistent(@"lnk_address")]
        [Association(@"SubscriptionReferencesAddress")]
        public Address Address
        {
            get { return fAddress; }
            set { SetPropertyValue<Address>(nameof(Address), ref fAddress, value); }
        }
        [Association(@"SubscriptionChangeReferencesSubscription")]
        public XPCollection<SubscriptionChange> Changes { get { return GetCollection<SubscriptionChange>(nameof(Changes)); } }
    }

}
