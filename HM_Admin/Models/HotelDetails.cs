using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HM_Admin.Models
{
    public class HotelDetails
    {
        [Key]        
        public int HotelId { get; set; }
        [Required (ErrorMessage = "Registration number is required"),MaxLength(255),NotNull]
        public string HotelRegistrationNumber {  get; set; } = string.Empty;
        public string HotelGSTNumber {  get; set; }=string.Empty;
        [Required(ErrorMessage = "Hotel name is required"), MaxLength(255), NotNull]
        public string HotelName { get; set; }= string.Empty;
        [NotNull]
        public string HotelType { get; set; }= string.Empty;
        public bool HotelStatus { get; set; }
        public int HotelRating {  get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }   

        public ICollection<BranchHotelDetails> BranchHotelDetail { get; set; }

    }
}
