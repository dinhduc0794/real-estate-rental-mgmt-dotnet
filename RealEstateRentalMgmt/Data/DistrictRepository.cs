using RealEstateRentalMgmt.Models;

namespace RealEstateRentalMgmt.Data
{
    public class DistrictRepository
    {
        private readonly AppDbContext _context;

        public DistrictRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(District district)
        {
            _context.Districts.Add(district);
            _context.SaveChanges();
        }
    }
}