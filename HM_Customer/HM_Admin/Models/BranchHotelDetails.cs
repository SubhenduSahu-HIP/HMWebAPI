using System.ComponentModel.DataAnnotations;

namespace HM_Admin.Models
{
    public class BranchHotelDetails
    {
        [Key]
        public int BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public string BranchType { get; set; } = string.Empty;
        public string BranchManagerID { get; set; }= string.Empty;
        public int HotelId { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }

        public HotelDetails HotelDetail { get; internal set; }

        
    }
}
