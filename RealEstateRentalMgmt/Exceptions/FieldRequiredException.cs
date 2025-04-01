namespace RealEstateRentalMgmt.Exceptions
{
    public class FieldRequiredException : Exception
    {
        public FieldRequiredException(string message) : base(message) { }
    }
}