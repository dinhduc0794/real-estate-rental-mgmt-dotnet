namespace RealEstateRentalMgmt.Models
{
    public class District
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public List<Building> Buildings { get; set; } = new List<Building>();
    }
}