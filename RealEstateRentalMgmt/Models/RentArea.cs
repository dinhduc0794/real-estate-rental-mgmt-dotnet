namespace RealEstateRentalMgmt.Models
{
    public class RentArea : BaseEntity
    {
        public long? Value { get; set; }

        public long BuildingId { get; set; }
        public Building Building { get; set; }
    }
}