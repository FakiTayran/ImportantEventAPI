using Ardalis.Specification;
using ImportantEventEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportantEventBusiness.Abstract
{
    public interface IEventService
    {
        Task<Event> AddEventAsync(Event eventEntity);

        Task<List<Event>> ListAsync(ISpecification<Event> spec);

        Task UpdateAsync(Event entity);

        Task DeleteAsync(Event entity);

        Task<Event> GetByIdAsync(int id);


    }
}
