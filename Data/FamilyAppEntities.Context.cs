﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FamilyApp.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FamilyAppEntities : DbContext
    {
        public FamilyAppEntities()
            : base("name=FamilyAppEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ArbeitsStunden> ArbeitsStunden { get; set; }
        public virtual DbSet<Bearbeiter> Bearbeiter { get; set; }
        public virtual DbSet<DM_DisplayIcons> DM_DisplayIcons { get; set; }
        public virtual DbSet<DM_DocumenState> DM_DocumenState { get; set; }
        public virtual DbSet<DM_Documents> DM_Documents { get; set; }
        public virtual DbSet<DM_Folders> DM_Folders { get; set; }
        public virtual DbSet<FamilyToolsTree> FamilyToolsTree { get; set; }
        public virtual DbSet<Password> Password { get; set; }
        public virtual DbSet<PasswordTree> PasswordTree { get; set; }
        public virtual DbSet<sys_Reg> sys_Reg { get; set; }
        public virtual DbSet<Tools> Tools { get; set; }
    }
}
