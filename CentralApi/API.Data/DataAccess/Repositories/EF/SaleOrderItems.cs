//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class SaleOrderItems
    {
        public int Id { get; set; }
        public double Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public int ProductId { get; set; }
        public int SaleOrderId { get; set; }
        public string AdditionalInformation { get; set; }
    
        public virtual Products Products { get; set; }
        public virtual SaleOrders SaleOrders { get; set; }
    }
}
