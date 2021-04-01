using Ardalis.Specification;
using ImportantEventBusiness.Abstract;
using ImportantEventDataAccess.Abstract;
using ImportantEventEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportantEventBusiness.Concrete
{
    public class EventManager : IEventService
    {
        private readonly IAsyncRepository<Event> _asyncRepository;

        public EventManager(IAsyncRepository<Event> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }
        public async Task<Event> AddEventAsync(Event eventEntity)
        {
            return await _asyncRepository.AddAsync(eventEntity); 
        }

        public async Task DeleteAsync(Event entity)
        {
             await _asyncRepository.DeleteAsync(entity);
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            return await _asyncRepository.GetByIdAsync(id);
        }

        public async Task<List<Event>> ListAsync(ISpecification<Event> spec)
        {
            return await _asyncRepository.ListAsync(spec);
        }

        public async Task UpdateAsync(Event entity)
        {
            await _asyncRepository.UpdateAsync(entity);
        }
    }
}
