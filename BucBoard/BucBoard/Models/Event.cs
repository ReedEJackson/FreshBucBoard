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
    
    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            this.Messages = new HashSet<Message>();
        }
    
        public int eventID { get; set; }
        public string eventName { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public Nullable<int> calendarID { get; set; }
    
        public virtual Calendar Calendar { get; set; }
        public virtual CustomEvent CustomEvent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }
        public virtual Premade Premade { get; set; }
        public virtual Recurring Recurring { get; set; }
    }
}
