using RealEstateRentalMgmt.Models.Builders;
using RealEstateRentalMgmt.Models.DTOs;

namespace RealEstateRentalMgmt.Services.Converters
{
    public class BuildingSearchBuilderConverter
    {
        public BuildingSearchBuilder ToBuildingSearchBuilder(BuildingSearchDTO searchDTO)
        {
            var builder = new BuildingSearchBuilder
            {
                Name = searchDTO.Name,
                Ward = searchDTO.Ward,
                Street = searchDTO.Street,
                RentPriceFrom = searchDTO.RentPriceFrom,
                RentPriceTo = searchDTO.RentPriceTo,
                RentAreaFrom = searchDTO.RentAreaFrom,
                RentAreaTo = searchDTO.RentAreaTo,
                StaffId = searchDTO.StaffId,
                TypeCode = searchDTO.TypeCode ?? new List<string>()
            };

            return builder;
        }
    }
}