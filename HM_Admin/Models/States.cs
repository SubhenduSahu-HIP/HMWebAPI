using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HM_Admin.Models
{
//    -- Create States Table
//CREATE TABLE states(
//    id INT PRIMARY KEY AUTO_INCREMENT,
//    country_id INT NOT NULL,
//    name VARCHAR(100) NOT NULL,
//    state_code VARCHAR(10) NOT NULL UNIQUE,
//    FOREIGN KEY(country_id) REFERENCES countries(id) ON DELETE CASCADE
//);
    public class States
    {   
        [Key]        
        public int Id { get; set; }
        [JsonIgnore]
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string StateCode { get; set; }

        [JsonIgnore]
        public virtual Countries? Country { get; set; }
        public ICollection<Cities> City { get; set; }

    }
}
