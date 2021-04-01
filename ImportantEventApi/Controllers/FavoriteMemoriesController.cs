using ImportantEventApi.Dtos;
using ImportantEventApi.Services;
using ImportantEventBusiness.Abstract;
using ImportantEventEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FavoriteMemoriesController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FavoriteMemoriesController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMyFavoriteMemoryService _myFavoriteMemoryService;

        public FavoriteMemoriesController(IEventService eventService, IMyFavoriteMemoryService myFavoriteMemoryService)
        {
            _eventService = eventService;
            _myFavoriteMemoryService = myFavoriteMemoryService;
        }
        public string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

        [HttpGet("MyFavoriteMemories")]

        public async Task<ActionResult> MyFavoriteMemories(string jsonLanguage, string type ,string time,string searchContent)
        {
            var userId = UserId;
            
            return Ok(await _myFavoriteMemoryService.GetMyFavoriteMemories(userId,jsonLanguage,type,time, searchContent));
        }


        [HttpPost("AddFavoriteMemory")]
        public async Task<IActionResult> AddFavoriteMemory([FromForm] EventDto eventDto,[FromForm] string jsonLanguage)
        {
            if (jsonLanguage == null)
            {
                jsonLanguage = "#it";
            }
            var newEvent = new Event()
            {
                Time = eventDto.Time,
                Category = eventDto.Category,
                Description = eventDto.Description,
                OwnerId = UserId,
                Language = jsonLanguage
            };

            if (newEvent != null)
            {
                await _eventService.AddEventAsync(newEvent);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("EditFavoriteMemory")]
        public async Task<IActionResult> EditFavoriteMemory([FromForm]EventDto eventDto,[FromForm]int eventId,[FromForm]string jsonLanguage)
        {
            Event editedEvent = await _eventService.GetByIdAsync(eventId);
            editedEvent.Category = eventDto.Category;
            editedEvent.Description = eventDto.Description;
            editedEvent.Time = eventDto.Time;
            editedEvent.Language = jsonLanguage;
            await _eventService.UpdateAsync(editedEvent);
            if (editedEvent == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost("DeleteFavoriteMemory")]
        public async Task<IActionResult> DeleteFavoriteMemory([FromForm] int eventId)
        {

            Event editedEvent = await _eventService.GetByIdAsync(eventId);
            await _eventService.DeleteAsync(editedEvent);
            if (editedEvent == null)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
