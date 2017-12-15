using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fantasyapicsharp.model;

namespace fantasyapicsharp.Controllers
{
    [Route("api/[controller]")]
    public class FighterController : Controller
    {
        private readonly FighterContext context;

        public FighterController(FighterContext context){
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Fighter> GetAll()
        {
            return context.Fighters.ToList();
        }

        [HttpGet("{id}", Name = "GetFighter")]
        public IActionResult Get(int id)
        {
            var item = context.Fighters.FirstOrDefault(t => t.id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Fighter fighter)
        {
            if (fighter == null)
            {
                return BadRequest();
            }

            context.Fighters.Add(fighter);
            context.SaveChanges();

            return CreatedAtRoute("GetFighter", new { id = fighter.id }, fighter);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Fighter fighter)
        {
            if (fighter == null)
            {
                return BadRequest();
            }
            
            var oldFighter = context.Fighters.FirstOrDefault(t => t.id == fighter.id);
            if (oldFighter == null)
            {
                return NotFound();
            }

            oldFighter.name = fighter.name;
            oldFighter.photo = fighter.photo;

            context.Fighters.Update(oldFighter);
            context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var fighter = context.Fighters.FirstOrDefault(t => t.id == id);
            if (fighter == null)
            {
                return NotFound();
            }

            context.Fighters.Remove(fighter);
            context.SaveChanges();
            return new NoContentResult();
        }
    }
}