using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Api.Data;
using SmartSchool.Api.Models;

namespace SmartSchool.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repository;

        public AlunoController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repository.GetAllAlunos(true);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repository.GetAlynoById(id);

            if (aluno == null)
                return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repository.Add(aluno);
            if(_repository.SaveChanges())
                return Ok(aluno);
            else
                return BadRequest("Erro ao salvar aluno");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alunoDb = _repository.GetAlynoById(id);

            if (alunoDb == null)
                return BadRequest("Aluno não encontrado");

            _repository.Update(aluno);
            if (_repository.SaveChanges())
                return Ok(aluno);
            else
                return BadRequest("Erro ao atualizar o aluno.");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alunoDb = _repository.GetAlynoById(id);

            if (alunoDb == null)
                return BadRequest("Aluno não encontrado");

            _repository.Update(aluno);
            if (_repository.SaveChanges())
                return Ok(aluno);
            else
                return BadRequest("Erro ao atualizar aluno");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repository.GetAlynoById(id);

            if (aluno == null)
                return BadRequest("Aluno não encontrado");

            _repository.Delete(aluno);
            if (_repository.SaveChanges())
                return Ok();
            else
                return BadRequest("Erro ao deletar aluno.");
        }
    }
}