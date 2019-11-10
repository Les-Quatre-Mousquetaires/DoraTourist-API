using System;

namespace DoraTourist.API.Models
{
    public class Review
    {
        public int Id { get; set; }
        public User Sender { get; set; }
        public int SenderId {get; set; }
        public Hotel Recipient { get; set; }
        public int RecipientId { get; set; }
        public DateTime DateAdded { get; set; }
        public int Point { get; set; }
        public string Comment { get; set; }
        public bool SenderDeleted { get; set; }
    }
}