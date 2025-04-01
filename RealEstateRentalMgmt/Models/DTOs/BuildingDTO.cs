using System.ComponentModel.DataAnnotations;

namespace RealEstateRentalMgmt.Models.DTOs
{
    public class BuildingDTO
    {
        public long? Id { get; set; }

        [Required(ErrorMessage = "Building name must not be blank")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ward must not be blank")]
        public string Ward { get; set; }

        [Required(ErrorMessage = "Street must not be blank")]
        public string Street { get; set; }
        public long? NumberOfBasement { get; set; }

        [Required(ErrorMessage = "District must not be blank")]
        public long DistrictId { get; set; }

        [Required(ErrorMessage = "Manager name must not be blank")]
        public string ManagerName { get; set; }

        [Required(ErrorMessage = "Manager phone number must not be blank")]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Manager phone number must be 10-11 digits")] 
        public string ManagerPhone { get; set; }
        public List<long> RentAreas { get; set; } = new List<long>();
    }
}