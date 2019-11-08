using System.Collections.Generic;
using System.Threading.Tasks;
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

    }
}