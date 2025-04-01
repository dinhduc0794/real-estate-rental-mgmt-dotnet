using Microsoft.EntityFrameworkCore;
using RealEstateRentalMgmt.Data;
using RealEstateRentalMgmt.Models;
using RealEstateRentalMgmt.Models.Builders;
using RealEstateRentalMgmt.Models.DTOs;
using RealEstateRentalMgmt.Services.Converters;

namespace RealEstateRentalMgmt.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly AppDbContext _context;
        private readonly BuildingConverter _buildingConverter;
        private readonly BuildingSearchBuilderConverter _builderConverter;

        public BuildingService(AppDbContext context, BuildingConverter buildingConverter, BuildingSearchBuilderConverter builderConverter)
        {
            _context = context;
            _buildingConverter = buildingConverter;
            _builderConverter = builderConverter;
        }

        public List<BuildingResponseDTO> FindAll(Dictionary<string, object> parameters, List<string> typeCodes)
        {
            var builder = _builderConverter.ToBuildingSearchBuilder(parameters, typeCodes);

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
            // StaffId và TypeCode sẽ được xử lý sau khi bạn thêm các entity liên quan (AssignmentBuilding, BuildingRentType)

            var buildings = query.ToList();
            return buildings.Select(b => _buildingConverter.ToBuildingResponseDTO(b)).ToList();
        }

        public void SaveBuilding(BuildingDTO buildingDTO)
        {
            Building building;

            if (buildingDTO.Id.HasValue)
            {
                building = _context.Buildings
                    .Include(b => b.RentAreas)
                    .FirstOrDefault(b => b.Id == buildingDTO.Id);

                if (building != null)
                {
                    // Xóa các RentArea hiện có
                    _context.RentAreas.RemoveRange(building.RentAreas);
                }
                else
                {
                    building = new Building();
                }
            }
            else
            {
                building = new Building();
            }

            building = _buildingConverter.ToBuildingEntity(buildingDTO, building);

            // Lưu Building
            if (buildingDTO.Id.HasValue)
            {
                _context.Buildings.Update(building);
            }
            else
            {
                _context.Buildings.Add(building);
            }
            _context.SaveChanges();

            // Lưu RentAreas
            foreach (var value in buildingDTO.RentAreas)
            {
                var rentArea = new RentArea
                {
                    BuildingId = building.Id,
                    Value = value
                };
                _context.RentAreas.Add(rentArea);
            }
            _context.SaveChanges();
        }

        public void DeleteBuilding(long[] ids)
        {
            var buildings = _context.Buildings
                .Include(b => b.RentAreas)
                .Where(b => ids.Contains(b.Id))
                .ToList();

            foreach (var building in buildings)
            {
                _context.RentAreas.RemoveRange(building.RentAreas);
            }

            _context.Buildings.RemoveRange(buildings);
            _context.SaveChanges();
        }
    }
}