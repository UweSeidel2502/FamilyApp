//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Tools
    {
        public int ID { get; set; }
        public Nullable<int> FamilyToolsTreeID { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Waranty { get; set; }
        public byte[] Picture { get; set; }
    
        public virtual FamilyToolsTree FamilyToolsTree { get; set; }
    }
}
