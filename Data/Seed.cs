using System.Collections.Generic;
using DoraTourist.API.Models;
using Newtonsoft.Json;

namespace DoraTourist.API.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedHotels()
        {
            var hotelData = System.IO.File.ReadAllText("Data/HotelSeedData.json");
            var hotels = JsonConvert.DeserializeObject<List<Hotel>>(hotelData);
            foreach(var hotel in hotels)
            {
                _context.Hotels.Add(hotel);
            }

            _context.SaveChanges();
        }
    }
}