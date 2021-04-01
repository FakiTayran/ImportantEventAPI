using ImportantEventEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportantEventApi.Services
{
    public interface IMyFavoriteMemoryService
    {
        Task<List<Event>> GetMyFavoriteMemories(string userId,string jsonLanguage,string type,string time, string searchContent);
    }
}
