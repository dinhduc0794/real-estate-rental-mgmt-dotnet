namespace RealEstateRentalMgmt.Models.DTOs
{
    public class BuildingResponseDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } // Có thể là Street + Ward
        public string ManagerName { get; set; }
        public string ManagerPhone { get; set; }
    }
}