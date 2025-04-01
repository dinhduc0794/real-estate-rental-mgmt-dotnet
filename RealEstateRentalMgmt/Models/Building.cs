using RealEstateRentalMgmt.Models;

public class Building : BaseEntity
{
    public string Name { get; set; }
    public string Street { get; set; }
    public string Ward { get; set; }
    public string? Structure { get; set; }
    public long? NumberOfBasement { get; set; }
    public long? FloorArea { get; set; }
    public string? Direction { get; set; }
    public string? Level { get; set; }
    public long RentPrice { get; set; }
    public string? RentPriceDescription { get; set; }
    public string? ServiceFee { get; set; }
    public string? CarFee { get; set; }
    public string? MotorbikeFee { get; set; }
    public string? OvertimeFee { get; set; }
    public string? WaterFee { get; set; }
    public string? ElectricityFee { get; set; }
    public string? Deposit { get; set; }
    public string? Payment { get; set; }
    public string? RentTime { get; set; }
    public string? DecorationTime { get; set; }
    public double? BrokerageFee { get; set; }
    public string? Note { get; set; }
    public string? LinkOfBuilding { get; set; }
    public string? Map { get; set; }
    public string? Image { get; set; }
    public string? ManagerName { get; set; }
    public string? ManagerPhone { get; set; }

    public long DistrictId { get; set; }
    public District District { get; set; }

    public List<RentArea> RentAreas { get; set; } = new List<RentArea>();
}
