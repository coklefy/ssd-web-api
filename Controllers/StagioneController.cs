using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SsdWebApi.Models;
using Microsoft.Data.SqlClient;

using System.Text.Json;

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
        [HttpGet("{id}")]
        public async Task<ActionResult<Stagione>> GetStagione(int id)
        {
            var stagioneItem = await _context.cronistoria.FindAsync(id);
            if (stagioneItem == null){ return NotFound();}

            return stagioneItem;
        }

        // POST: api/Stagione/PostStagione Item (insert)
        [HttpPost]
        [Route("[action]")]
        public string PostStagioneItem([FromBody] Stagione item)
        {
            string res = "anno " + item.anno;
            try {
                _context.cronistoria.Add(item);
                _context.SaveChangesAsync();
            } catch (Exception ex) {
                Console.WriteLine("[ERROR] " + ex.Message);
                res = "Error";
            }

            Console.WriteLine(res);
            return res;
        }


        // PUT: api/Stagione/10 (update)
        [HttpPut("{id}")]
        public async Task<ActionResult<Stagione>> PutStagione(int id, [FromBody] Stagione item) 
        {
            if (id != item.id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;

            try{
                await _context.SaveChangesAsync();
            } catch (Exception ex) {
                if(! _context.cronistoria.Any(s => s.id == id)) { return NotFound();}
                else { Console.WriteLine("[ERROR] " + ex.Message);}
            }
            
            return Ok();
        }



        // DELETE: api/Stagione/10
        [HttpDelete("{id}")]
        public async Task<ActionResult<Stagione>> DeleteStagione(int id) 
        {
            var item = await _context.cronistoria.FindAsync(id);
            if (item == null) { return NotFound();}
            
            _context.cronistoria.Remove(item);

            try{
                await _context.SaveChangesAsync();
            } catch (Exception ex) {
                Console.WriteLine("[ERROR] " + ex.Message);
            }

            return item;
        }
    }
}