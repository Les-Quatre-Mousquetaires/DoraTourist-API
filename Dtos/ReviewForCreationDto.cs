using System;

namespace DoraTourist.API.Dtos
{
    public class ReviewForCreationDto
    {
        public int SenderId { get; set; } // user
        public int RecipientId { get; set; } // hotel
        public DateTime DateAdded { get; set; }
        public int Point { get; set; }
        public string Comment { get; set; }

        public ReviewForCreationDto()
        {
            DateAdded = DateTime.Now;
        }
    }
}