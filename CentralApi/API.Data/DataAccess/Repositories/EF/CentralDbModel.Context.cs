﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Data.DataAccess.Repositories.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CentralDbEntities : DbContext
    {
        public CentralDbEntities()
            : base("name=CentralDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderStates> OrderStates { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductTypes> ProductTypes { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UnitMeasure> UnitMeasure { get; set; }
    }
}
