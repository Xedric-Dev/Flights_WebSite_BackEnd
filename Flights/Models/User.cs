using Flights_Create_Book.Models;
using System.ComponentModel.DataAnnotations;

namespace Flights_Create_Book.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }
        public  IEnumerable<int>? FavoriteFlights { get; set; }
    }
}
