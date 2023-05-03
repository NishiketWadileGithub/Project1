using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMinds_WebApp.Models
{
    [Table("tblState")]
    public class StateModel
    {
        [Key]
        [Column("Id")]
        public int StateId { get; set; }
        [Required(ErrorMessage = "State Name is required")]
        [Column("StateName")]
        public string StateName { get; set; }
        [ForeignKey("StateId")]
        public ICollection<CityModel> Cities { get; set; }
    }
}
