using ImportantEventApi.Services;
using ImportantEventBusiness.Abstract;
using ImportantEventBusiness.Concrete.Specifications;
using ImportantEventEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportantEventApi.Managers
{
    public class MyFavoriteMemoryManager : IMyFavoriteMemoryService
    {
        private readonly IEventService _eventService;

        public MyFavoriteMemoryManager(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<List<Event>> GetMyFavoriteMemories(string userId, string jsonLanguage, string type, string time,string searchContent)
        {
            var spec = new EventListFilterSpecification(userId, jsonLanguage,type,time, searchContent);
            var events = _eventService.ListAsync(spec);

            return await events;
        }

        
    }
}
