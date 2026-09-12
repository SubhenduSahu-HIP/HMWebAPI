using System.ComponentModel.DataAnnotations;

namespace HM_Admin.Models
{
    public class AdminUser
    {
        [Key]
        public int UserId { get; set; }
        
        public string UserFirstName { get; set; } = string.Empty;
       
        public string UserLastName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        
        public string UserMobile { get; set; } = string.Empty;
        
        public string UserPassword { get; set; } = string.Empty;
        public string UserAddress { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }

    }
}
