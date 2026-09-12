using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace HM_Admin.Models
{
//    -- Create Countries Table
//CREATE TABLE countries(
//    id INT PRIMARY KEY AUTO_INCREMENT,
//    name VARCHAR(100) NOT NULL,
//    country_code VARCHAR(10) NOT NULL UNIQUE
//);
    public class Countries
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<States> State { get; set; }
    }
}
