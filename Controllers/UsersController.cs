using System.Threading.Tasks;
using AutoMapper;
using DoraTourist.API.Data;
using DoraTourist.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DoraTourist.API.Helpers;
using System.Collections.Generic;
using System.Security.Claims;
using DoraTourist.API.Models;

namespace DoraTourist.API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IBookingRepository _repo;
        private readonly IMapper _mapper;
        public UsersController(IMapper mapper, IBookingRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();

            var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);
            
            return Ok(usersToReturn);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);

            var userToReturn = _mapper.Map<UserForDetailedDto>(user);
            
            return Ok(userToReturn);
        }

        // [HttpPost("{id}/reviewHotel/{recipientId}")]
        // public async Task<IActionResult> ReviewHotel(int id, int recipientId)
        // {
        //     if(id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
        //         return Unauthorized();

        //     if(await _repo.GetHotel(recipientId) == null)
        //         return NotFound();
           
        //     var review = new Review
        //     {
        //         SenderId = id,
        //         RecipientId = recipientId
        //     };

        //     _repo.Add<Review>(review);
        // }
    }
}