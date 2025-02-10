using System.ComponentModel.DataAnnotations;

namespace Flights_Create_Book.Models
{
    public class Flight
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Airline Name is required")]
        public string airlineName { get; set; }

        [Required(ErrorMessage = "Departure Location is required")]
        public string fromLocation { get; set; }

        [Required(ErrorMessage = "Arrival Location is required")]
        public string toLocation { get; set; }

        [Required(ErrorMessage = "Departure Date is required")]
        public string fromDate { get; set; }

        [Required(ErrorMessage = "Arrival Date is required")]
        public string toDate { get; set; }

        [Required(ErrorMessage = "Departure Time is required")]
        public string fromTime { get; set; }

        [Required(ErrorMessage = "Arrival Time is required")]
        public string toTime { get; set; }

        [Required(ErrorMessage = "Passengers Number is required")]
        [Range(0,1000 , ErrorMessage ="Number of passengers must be below 1000")]
        public int passengerNumber { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public int price { get; set; }
    }
}
