using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateRentalMgmt.Models
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        [Column("createddate")]
        public DateTime? CreatedDate { get; set; }
        [Column("modifieddate")]
        public DateTime? ModifiedDate { get; set; }
        [Column("createdby")]
        public string? CreatedBy { get; set; }
        [Column("modifiedby")]
        public string? ModifiedBy { get; set; }
    }
}