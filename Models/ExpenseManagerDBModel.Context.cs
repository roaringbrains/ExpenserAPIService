﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExpenserAPIService.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ExpenseManagerEntities : DbContext
    {
        public ExpenseManagerEntities()
            : base("name=ExpenseManagerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Expense_Category> Expense_Category { get; set; }
        public virtual DbSet<Income_Category> Income_Category { get; set; }
        public virtual DbSet<Income_Source> Income_Source { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<User_Credential> User_Credential { get; set; }
        public virtual DbSet<User_Expense_Details> User_Expense_Details { get; set; }
        public virtual DbSet<User_Mobile> User_Mobile { get; set; }
    }
}
