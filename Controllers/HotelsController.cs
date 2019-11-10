using System.Threading.Tasks;
using AutoMapper;
using DoraTourist.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DoraTourist.API.Dtos;
using System.Collections.Generic;
using DoraTourist.API.Helpers;

namespace DoraTourist.API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IBookingRepository _repo;
        private readonly IMapper _mapper;

        public HotelsController(IBookingRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetHotels([FromQuery]HotelParams hotelParams)
        {

            var hotels= await _repo.GetHotels(hotelParams);
            var hotelsToReturn = _mapper.Map<IEnumerable<HotelForListDto>>(hotels);
            Response.AddPagination(hotels.CurrentPage, hotels.PageSize, hotels.TotalCount, hotels.TotalPages);
            
            return Ok(hotelsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotel(int id)
        {
            var hotel = await _repo.GetHotel(id);
            var hotelToReturn = _mapper.Map<HotelForDetailedDto>(hotel);
            return Ok(hotelToReturn);
        }

        
    
    } 
}