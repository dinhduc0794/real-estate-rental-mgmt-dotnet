using RealEstateRentalMgmt.Data;
using RealEstateRentalMgmt.Models;
using RealEstateRentalMgmt.Models.Builders;
using RealEstateRentalMgmt.Models.DTOs;
using RealEstateRentalMgmt.Services.Converters;

namespace RealEstateRentalMgmt.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly BuildingRepository _buildingRepository;
        private readonly BuildingConverter _buildingConverter;
        private readonly BuildingSearchBuilderConverter _builderConverter;

        public BuildingService(BuildingRepository buildingRepository, BuildingConverter buildingConverter, BuildingSearchBuilderConverter builderConverter)
        {
            _buildingRepository = buildingRepository;
            _buildingConverter = buildingConverter;
            _builderConverter = builderConverter;
        }

        public List<BuildingResponseDTO> FindAll(BuildingSearchDTO searchDTO)
        {
            var builder = _builderConverter.ToBuildingSearchBuilder(searchDTO);
            var buildings = _buildingRepository.FindAll(builder).ToList();
            return buildings.Select(b => _buildingConverter.ToBuildingResponseDTO(b)).ToList();
        }

        public void SaveBuilding(BuildingDTO buildingDTO)
        {
            Building building;

            if (buildingDTO.Id.HasValue)
            {
                building = _buildingRepository.FindById(buildingDTO.Id.Value);

                if (building != null)
                {
                    // Xóa các RentArea hiện có
                    _buildingRepository.DeleteRentAreas(building.RentAreas);
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
                _buildingRepository.Update(building);
            }
            else
            {
                _buildingRepository.Add(building);
            }

            // Lưu RentAreas
            foreach (var value in buildingDTO.RentAreas)
            {
                var rentArea = new RentArea
                {
                    BuildingId = building.Id,
                    Value = value
                };
                _buildingRepository.AddRentArea(rentArea);
            }

            _buildingRepository.SaveChanges();
        }

        public void DeleteBuilding(long[] ids)
        {
            var buildings = _buildingRepository.FindByIds(ids);

            foreach (var building in buildings)
            {
                _buildingRepository.DeleteRentAreas(building.RentAreas);
            }

            _buildingRepository.DeleteRange(buildings);
            _buildingRepository.SaveChanges();
        }
    }
}