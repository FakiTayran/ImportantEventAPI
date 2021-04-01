using ImportantEventApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportantEventApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll(string jsonLanguage, string type, string time,string searchContent)
        {

            if (time != null && (time.Contains("Giorno") || time.Contains("Mese") || time.Contains("Gün") || time.Contains("Ay")))
            {
                time = null;
            }


            if (type != null && (type == "Hepsi" || type == "Tutte"))
            {
                type = null;
            }
            if (jsonLanguage == "#tr")
            {
                string jsonTurkish = System.IO.File.ReadAllText(@"C:\Users\fakit\Downloads\stajyer proje\TariheGöreOlaylar(Türkçe).json");
                var turkceJson = JsonConvert.DeserializeObject<List<TurkceJson>>(jsonTurkish);
                var filteredTurkceJson = turkceJson.Where(x => (string.IsNullOrEmpty(type) || x.dc_Kategori == type) && (string.IsNullOrEmpty(time) || x.dc_Zaman == time) && (!(searchContent != null) || x.ID.ToString().Contains(searchContent) || x.dc_Kategori.ToLower().Contains(searchContent) || x.dc_Zaman.ToLower().Contains(searchContent) || x.dc_Olay.ToLower().Contains(searchContent)));
               
                var turkceJsonSerialize = JsonConvert.SerializeObject(filteredTurkceJson);


                return Content(turkceJsonSerialize, "application/json");
            }
            else
            {
                string jsonItalian = System.IO.File.ReadAllText(@"C:\Users\fakit\Downloads\stajyer proje\TariheGöreOlaylar(italyanca).json");
                var italianJson = JsonConvert.DeserializeObject<List<ItalianJson>>(jsonItalian);
                var filteredItalianJson = italianJson.Where(x => (string.IsNullOrEmpty(type) || x.dc_Categoria == type) && (string.IsNullOrEmpty(time) || x.dc_Orario == time) && (!(searchContent != null) || x.ID.ToString().Contains(searchContent) || x.dc_Categoria.ToLower().Contains(searchContent) || x.dc_Orario.ToLower().Contains(searchContent) || x.dc_Evento.ToLower().Contains(searchContent)));
                var italianJsonSerialize = JsonConvert.SerializeObject(filteredItalianJson);

                return Content(italianJsonSerialize, "application/json");
            }
        }
    }
}
