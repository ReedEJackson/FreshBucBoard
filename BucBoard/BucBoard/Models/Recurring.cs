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
    
    public partial class Recurring
    {
        public Nullable<int> isAvalible { get; set; }
        public int eventID { get; set; }
    
        public virtual Event Event { get; set; }
    }
}
