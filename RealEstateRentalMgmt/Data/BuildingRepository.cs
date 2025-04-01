using Microsoft.EntityFrameworkCore;
using RealEstateRentalMgmt.Data;
using RealEstateRentalMgmt.Models;
using RealEstateRentalMgmt.Models.Builders;

namespace RealEstateRentalMgmt.Data
{
    public class BuildingRepository
    {
        private readonly AppDbContext _context;

        public BuildingRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Building> FindAll(BuildingSearchBuilder builder)
        {
            var query = _context.Buildings
                .Include(b => b.District)
                .Include(b => b.RentAreas)
                .AsQueryable();

            // Điều kiện WHERE
            if (!string.IsNullOrEmpty(builder.Name))
                query = query.Where(b => b.Name.Contains(builder.Name));
            if (!string.IsNullOrEmpty(builder.Ward))
                query = query.Where(b => b.Ward.Contains(builder.Ward));
            if (!string.IsNullOrEmpty(builder.Street))
                query = query.Where(b => b.Street.Contains(builder.Street));
            if (builder.RentPriceFrom.HasValue)
                query = query.Where(b => b.RentPrice >= builder.RentPriceFrom.Value);
            if (builder.RentPriceTo.HasValue)
                query = query.Where(b => b.RentPrice <= builder.RentPriceTo.Value);
            if (builder.RentAreaFrom.HasValue)
                query = query.Where(b => b.RentAreas.Any(ra => ra.Value >= builder.RentAreaFrom.Value));
            if (builder.RentAreaTo.HasValue)
                query = query.Where(b => b.RentAreas.Any(ra => ra.Value <= builder.RentAreaTo.Value));
            // StaffId và TypeCode sẽ được xử lý sau khi bạn thêm các entity liên quan

            return query;
        }

        public Building FindById(long id)
        {
            return _context.Buildings
                .Include(b => b.RentAreas)
                .FirstOrDefault(b => b.Id == id);
        }

        public void Add(Building building)
        {
            _context.Buildings.Add(building);
        }

        public void Update(Building building)
        {
            _context.Buildings.Update(building);
        }

        public void AddRentArea(RentArea rentArea)
        {
            _context.RentAreas.Add(rentArea);
        }

        public void DeleteRange(IEnumerable<Building> buildings)
        {
            _context.Buildings.RemoveRange(buildings);
        }

        public void DeleteRentAreas(IEnumerable<RentArea> rentAreas)
        {
            _context.RentAreas.RemoveRange(rentAreas);
        }

        public List<Building> FindByIds(long[] ids)
        {
            return _context.Buildings
                .Include(b => b.RentAreas)
                .Where(b => ids.Contains(b.Id))
                .ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}