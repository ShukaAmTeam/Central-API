namespace API.Entities
{
    public class ProductEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CostPrice { get; set; }
        public int? Price { get; set; }
        public int? TotalCount { get; set; }
        public int? AvailableCount { get; set; }
        public bool? IsAvailable { get; set; }

        public MeasUnitEntity MeasUnits { get; set; }
        public ProductTypeEntity ProductTypes { get; set; }
    }

    public class MeasUnitEntity
    {
        public System.Guid MeasUnit_Guid { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
    }

    public partial class ProductTypeEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}