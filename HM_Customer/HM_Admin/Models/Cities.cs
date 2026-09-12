using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HM_Admin.Models
{
//    -- Create Cities Table
//CREATE TABLE cities(
//    id INT PRIMARY KEY AUTO_INCREMENT,
//    state_id INT NOT NULL,
//    name VARCHAR(100) NOT NULL,
//    FOREIGN KEY(state_id) REFERENCES states(id) ON DELETE CASCADE
//);
    public class Cities
    {
        [Key]
        public int Id { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public States State { get; internal set; }
        
    }
}
