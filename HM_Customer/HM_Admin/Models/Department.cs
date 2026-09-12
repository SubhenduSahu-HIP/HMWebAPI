namespace HM_Admin.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }= string.Empty;
        public bool IsDeleted{ get; set; }
        public bool DepartmentStatus { get; set; }  
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string UpdatedBY { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
    }
}
