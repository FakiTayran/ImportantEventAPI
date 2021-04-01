using Ardalis.Specification;
using ImportantEventEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportantEventBusiness.Concrete.Specifications
{
    public class EventListFilterSpecification : Specification<Event>
    {
        public EventListFilterSpecification(string userId, string jsonLanguage, string type, string time, string searchContent)
        {
            if (time != null && (time.Contains("Giorno") || time.Contains("Mese") || time.Contains("Gün") || time.Contains("Ay")))
            {
                time = null;
            }


            if (type != null && (type == "Hepsi" || type == "Tutte"))
            {
                type = null;
            }
            if (jsonLanguage == null)
            {
                jsonLanguage = "#it";
            }
            Query.Where(x => (x.OwnerId == userId && x.Language == jsonLanguage) && (string.IsNullOrEmpty(type) || x.Category == type) && (string.IsNullOrEmpty(time) || x.Time == time) && (!(searchContent != null) || x.Id.ToString().Contains(searchContent) || x.Category.ToLower().Contains(searchContent) || x.Time.ToLower().Contains(searchContent) || x.Description.ToLower().Contains(searchContent)));
        }
    }
}
