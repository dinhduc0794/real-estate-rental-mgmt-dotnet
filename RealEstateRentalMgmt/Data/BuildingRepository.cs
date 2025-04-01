using RealEstateRentalMgmt.Models;

namespace RealEstateRentalMgmt.Data
{
    public class BuildingRepository
    {
        private readonly AppDbContext _context;

        public BuildingRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Building building)
        {
            _context.Buildings.Add(building);
            _context.SaveChanges();
        }
    }
}