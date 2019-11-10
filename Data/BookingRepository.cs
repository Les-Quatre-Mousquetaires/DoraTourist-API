using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoraTourist.API.Helpers;
using DoraTourist.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DoraTourist.API.Data
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DataContext _context;
        public BookingRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            
            return users;
        }
 
        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }
        
        public async Task<PagedList<Hotel>> GetHotels(HotelParams hotelParams)
        {
            var hotels = _context.Hotels;
            return await PagedList<Hotel>.CreateAsync(hotels, hotelParams.PageNumber, hotelParams.PageSize);
        }

        public async Task<Hotel> GetHotel(int id)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);
            return hotel;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Review> GetReview(int id)
        {
            return await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
        }

        public Task<PagedList<Review>> GetReviewsForHotel(ReviewParams reviewParams)
        {
            var reviews = _context.Reviews
            .Include(u => u.Sender)
            .Include(h => h.Recipient)
            .AsQueryable();

            reviews = reviews.Where(h => h.RecipientId == reviewParams.hotelId);

            return PagedList<Review>.CreateAsync(reviews, reviewParams.PageNumber, reviewParams.pageSize);
        }
    }
}