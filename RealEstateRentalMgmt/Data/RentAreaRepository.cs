using RealEstateRentalMgmt.Models;

namespace RealEstateRentalMgmt.Data
{
    public class RentAreaRepository
    {
        private readonly AppDbContext _context;

        public RentAreaRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(RentArea rentArea)
        {
            _context.RentAreas.Add(rentArea);
            _context.SaveChanges();
        }
    }
}