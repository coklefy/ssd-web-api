using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SsdWebApi.Models;

namespace SsdWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IndiciController : ControllerBase 
    {
        private readonly IndiciContext _context;
        Persistence persistence;

        public IndiciController(IndiciContext context)
        {

        }

        [HttpGet]
        public ActionResult<List<Indice>> GetAll() => 

        [HttpGet("{id}", Name = "GetSerie")]
        public string GetSerie(int id)
        {
            string res = "{";
            if (id>8) id = 8;
            string[] index = new string[]{"id", "Data", "SP_500", "FTSE_MIB", "GOLD_SPOT", "MSCI_EM", "MSCI_EURO", "All:Bonds", "US_Treasury"};
            string attribute = indices[id];

            WeatherForecastController F = new Foreceast();
            res += F.forecastSARIMAindex(attribute);
            res += "}";
            
            var index = F.readIndex(attribute);
            return res;
        }

    }
}