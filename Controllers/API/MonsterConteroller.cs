using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Monsterpedia.Models;

namespace Monsterpedia.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonsterController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MonsterController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Monster>> GetAll()
        {
            return _context.Monsters.ToList();
        }

        [HttpGet("{id}", Name = "GetMonster")]
        public ActionResult<Monster> GetById(int id)
        {
            var item = _context.Monsters.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(Monster monster)
        {
            _context.Monsters.Add(monster);
            _context.SaveChanges();

            return CreatedAtRoute("GetMonster", new { id = monster.Id }, monster);
        }
    }
}