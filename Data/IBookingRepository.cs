using System.Collections.Generic;
using System.Threading.Tasks;
using DoraTourist.API.Helpers;
using DoraTourist.API.Models;

namespace DoraTourist.API.Data
{
    public interface IBookingRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<PagedList<Hotel>> GetHotels(HotelParams hotelParams);
        Task<Hotel> GetHotel(int id);

        Task<Review> GetReview(int id);
        Task<PagedList<Review>> GetReviewsForHotel(ReviewParams reviewParams);
        // Task<IEnumerable<Review>> GetMessageThread(int userId, int recipientId)();

    }
}