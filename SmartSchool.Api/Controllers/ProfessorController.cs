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
        private readonly IRepository _repository;

        public ProfessorController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Get()
        {
            var result = _repository.GetAllProfessores(true);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repository.GetProfessorById(id);

            if (professor == null)
                return BadRequest("Professor não encontrado.");

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repository.Add(professor);
            if (_repository.SaveChanges())
                return Ok(professor);
            else
                return BadRequest("Professor não foi criado.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var professorDb = _repository.GetProfessorById(id);

            if (professorDb == null)
                return BadRequest("Professor não encontrado.");

            _repository.Update(professor);

            if (_repository.SaveChanges())
                return Ok(professor);
            else
                return BadRequest("Professor não atualizado.");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var professorDb = _repository.GetProfessorById(id);

            if (professorDb == null)
                return BadRequest("Professor não encontrado.");

            _repository.Update(professor);
            if (_repository.SaveChanges())
                return Ok(professor);
            else
                return BadRequest("Professor não atualizado.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professorDb = _repository.GetProfessorById(id);

            if (professorDb == null)
                return BadRequest("Professor não encontrado.");

            _repository.Delete(professorDb);
            if (_repository.SaveChanges())
                return Ok();
            else
                return BadRequest("Professor não deletado.");
        }
    }
}