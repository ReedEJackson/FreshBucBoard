//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BucBoard.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        public int messageID { get; set; }
        public string sender { get; set; }
        public string reciever { get; set; }
        public string body { get; set; }
        public string subject { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> eventID { get; set; }
    
        public virtual Event Event { get; set; }
    }
}