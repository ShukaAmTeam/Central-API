namespace API.Entities
{
    public class WarehouseEntity
    {
        public int Id { get; set; }
        public double? Quantity { get; set; }
        public double? QuantityAvalable { get; set; }
        public bool? IsAvalable { get; set; }
        public string AdditionalInformation { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public int ProductId { get; set; }

        public virtual ProductEntity Products { get; set; }
    }
}