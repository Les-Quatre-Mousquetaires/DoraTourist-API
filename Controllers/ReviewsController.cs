using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DoraTourist.API.Data;
using DoraTourist.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DoraTourist.API.Dtos;
using DoraTourist.API.Models;
using System;

namespace DoraTourist.API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Authorize]
    [Route("api/users/{userId}/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IBookingRepository _repo;
        private readonly IMapper _mapper;
        public ReviewsController(IBookingRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{id}", Name="GetReview")]
        public async Task<IActionResult> GetReview(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            
            var reviewFromRepo = await _repo.GetReview(id);

            if(reviewFromRepo == null)
                return NotFound();
            
            return Ok(reviewFromRepo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(int userId, ReviewForCreationDto ReviewForCreationDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            
            ReviewForCreationDto.SenderId  = userId;

            var hotelRecipient = await _repo.GetHotel(ReviewForCreationDto.RecipientId);

            if (hotelRecipient == null)
                return BadRequest("Could not find this hotel");
            
            var review = _mapper.Map<Review>(ReviewForCreationDto);
            
            _repo.Add(review);

            var reviewToReturn = _mapper.Map<ReviewForCreationDto>(review);

            if(await _repo.SaveAll())
            {
                return CreatedAtRoute("GetReview", new {id = review.Id}, reviewToReturn);
            }

            throw new Exception("Creating the review failed on save");
        }
    }
}