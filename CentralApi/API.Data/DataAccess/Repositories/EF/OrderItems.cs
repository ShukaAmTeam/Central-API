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
    
    public partial class OrderItems
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public int Order_Id { get; set; }
        public double Count { get; set; }
        public int Price { get; set; }
    
        public virtual Orders Orders { get; set; }
        public virtual Products Products { get; set; }
    }
}
