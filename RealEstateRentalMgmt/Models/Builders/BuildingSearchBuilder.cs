namespace RealEstateRentalMgmt.Models.Builders
{
    public class BuildingSearchBuilder
    {
        public string Name { get; set; }
        public string Ward { get; set; }
        public string Street { get; set; }
        public long? RentPriceFrom { get; set; }
        public long? RentPriceTo { get; set; }
        public long? RentAreaFrom { get; set; }
        public long? RentAreaTo { get; set; }
        public long? StaffId { get; set; }
        public List<string> TypeCode { get; set; } = new List<string>();
    }
}