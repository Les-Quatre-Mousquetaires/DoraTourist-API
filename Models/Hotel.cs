using System.Collections.Generic;

namespace DoraTourist.API.Models
{

    public class Hotel 
    {
        public int Id { get; set; }
        public string HotelName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Address { get; set; }
        public int Rooms { get; set; }
        public int Beds { get; set; }
        public int Bathrooms { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool Status { get; set; }
        public ICollection<Review> ReviewsReceived { get; set; }

    }
}