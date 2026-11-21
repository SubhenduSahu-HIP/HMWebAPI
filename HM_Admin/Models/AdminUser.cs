using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HM_Admin.Models
{
    public class AdminUser
    {
        [Key]
        [JsonIgnore]
        public int UserId { get; set; }        
        public string FirstName { get; set; } = string.Empty;       
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;        
        public string Mobile { get; set; } = string.Empty;        
        public string Password { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsAdmin { get;  set; } = false;
        [Required]
        public string CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; } = string.Empty;
        [JsonIgnore]
        public DateTime ModifiedDate { get; set; } 
        [JsonIgnore]
        public bool IsDeleted { get; set; }

    }
}
