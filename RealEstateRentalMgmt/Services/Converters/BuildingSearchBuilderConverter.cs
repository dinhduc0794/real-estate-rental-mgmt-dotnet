using RealEstateRentalMgmt.Models.Builders;

namespace RealEstateRentalMgmt.Services.Converters
{
    public class BuildingSearchBuilderConverter
    {
        public BuildingSearchBuilder ToBuildingSearchBuilder(Dictionary<string, object> paramsDict, List<string> typeCodes)
        {
            var builder = new BuildingSearchBuilder();

            if (paramsDict.TryGetValue("name", out var name))
                builder.Name = name?.ToString();
            if (paramsDict.TryGetValue("ward", out var ward))
                builder.Ward = ward?.ToString();
            if (paramsDict.TryGetValue("street", out var street))
                builder.Street = street?.ToString();
            if (paramsDict.TryGetValue("rentPriceFrom", out var rentPriceFrom) && long.TryParse(rentPriceFrom?.ToString(), out var rpf))
                builder.RentPriceFrom = rpf;
            if (paramsDict.TryGetValue("rentPriceTo", out var rentPriceTo) && long.TryParse(rentPriceTo?.ToString(), out var rpt))
                builder.RentPriceTo = rpt;
            if (paramsDict.TryGetValue("rentAreaFrom", out var rentAreaFrom) && long.TryParse(rentAreaFrom?.ToString(), out var raf))
                builder.RentAreaFrom = raf;
            if (paramsDict.TryGetValue("rentAreaTo", out var rentAreaTo) && long.TryParse(rentAreaTo?.ToString(), out var rat))
                builder.RentAreaTo = rat;
            if (paramsDict.TryGetValue("staffId", out var staffId) && long.TryParse(staffId?.ToString(), out var sid))
                builder.StaffId = sid;

            if (typeCodes != null && typeCodes.Any())
                builder.TypeCode = typeCodes;

            return builder;
        }
    }
}