using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMinds_WebApp.Models
{
    [Table("tblCity")]
    public class CityModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "City Name is required")]
        public string CityName { get; set; }
        [Required(ErrorMessage = "State is required")]
        public int StateId { get; set; }
    }
}
