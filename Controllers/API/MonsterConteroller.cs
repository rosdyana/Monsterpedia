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
        private readonly ApplicationDbContext _context;

        public MonsterController(ApplicationDbContext context)
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
        public IActionResult CreateMonster(Monster monster)
        {
            _context.Monsters.Add(monster);
            _context.SaveChanges();

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMonster(int id, Monster monster)
        {
            var mMonster = _context.Monsters.Find(id);
            if (mMonster == null)
            {
                return NotFound();
            }

            _context.Update(monster);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMonster(int id)
        {
            var mMonster = _context.Monsters.Find(id);
            if (mMonster == null)
            {
                return NotFound();
            }

            _context.Monsters.Remove(mMonster);
            _context.SaveChanges();
            return Ok();
        }
    }
}