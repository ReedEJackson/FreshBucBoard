﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bucboardEntities : DbContext
    {
        public bucboardEntities()
            : base("name=bucboardEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Calendar> Calendars { get; set; }
        public virtual DbSet<CustomEvent> CustomEvents { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Premade> Premades { get; set; }
        public virtual DbSet<Recurring> Recurrings { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
