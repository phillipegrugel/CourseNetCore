using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Api.Data;
using SmartSchool.Api.Models;

namespace SmartSchool.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;
        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(_ => _.Id == id);

            if (professor == null)
                return BadRequest("Professor não encontrado.");

            return Ok(professor);
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName(string nome)
        {
            var professor = _context.Professores.FirstOrDefault(_ => _.Nome == nome);

            if (professor == null)
                return BadRequest("Professor não encontrado.");

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var professorDb = _context.Professores.AsNoTracking().FirstOrDefault(_ => _.Id == id);

            if (professorDb == null)
                return BadRequest("Professor não encontrado.");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var professorDb = _context.Professores.AsNoTracking().FirstOrDefault(_ => _.Id == id);

            if (professorDb == null)
                return BadRequest("Professor não encontrado.");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professorDb = _context.Professores.FirstOrDefault(_ => _.Id == id);

            if (professorDb == null)
                return BadRequest("Professor não encontrado.");

            _context.Remove(professorDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}