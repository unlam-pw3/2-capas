﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaNegocioDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ZooEntities : DbContext
    {
        public ZooEntities()
            : base("name=ZooEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Cuidador> Cuidadors { get; set; }
        public virtual DbSet<PlanCuidado> PlanCuidadoes { get; set; }
    }
}
