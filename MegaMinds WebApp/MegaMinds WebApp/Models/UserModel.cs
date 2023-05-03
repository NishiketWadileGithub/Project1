using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MegaMinds_WebApp.Models
{
    [Table("tblUserRegistration")]
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "State is required")]
        public int StateId { get; set; }
        [Required(ErrorMessage = "City is required")]
        public int CityId { get; set; }
        // Navigation property for State
        public StateModel? State { get; set; }

        // Navigation property for City
        public CityModel? City { get; set; }
        // List of all States
        public List<StateModel>? StatesList { get; set; }

        // List of Cities based on the selected State
        public List<CityModel>? CitiesList { get; set; }
    }
}
