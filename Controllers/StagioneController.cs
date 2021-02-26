using Microsoft.AspNetCore.Mvc;
using SsdWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace SsdWebApi.Controllers
{
    [ApiController]
    [Route("api/Stagione")]
    public class StagioneController : ControllerBase
    {
        private readonly StagioneContext _context;
        public StagioneController(StagioneContext context)
        {
            _context = context;
        }
    

        [HttpGet]
        public ActionResult<List<Stagione>> GetAll() => _context.cronistoria.ToList();
        // GET by id action
        // POST action
        // PUT action
        // DELETE by id actoion
    }
}