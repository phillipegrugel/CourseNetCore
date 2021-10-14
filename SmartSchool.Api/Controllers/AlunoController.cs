using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.Api.Models;

namespace SmartSchool.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private List<Aluno> alunos = new List<Aluno> {
            new Aluno {
                Nome = "Phillipe",
                Sobrenome = "Grugel",
                Id = 1,
                Telefone = "8546542561"
            },
            new Aluno {
                Nome = "Fernando",
                Sobrenome = "Rodrigues",
                Id = 2,
                Telefone = "5645656554"
            },
            new Aluno {
                Nome = "Mauricio",
                Sobrenome = "Murgel",
                Id = 3,
                Telefone = "875465148"
            },
            new Aluno {
                Nome = "Marta",
                Sobrenome = "Rocha",
                Id = 4,
                Telefone = "54564251321"
            },
            new Aluno {
                Nome = "Maria",
                Sobrenome = "Mole",
                Id = 5,
                Telefone = "21231478"
            }
        };
        public AlunoController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = alunos.Find(_ => _.Id == id);

            if (aluno == null)
                return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }

        [HttpGet("GetByName")]
        public IActionResult GetByNome(string nome, string sobrenome)
        {
            var aluno = alunos.Find(_ => _.Nome.Contains(nome) && _.Sobrenome.Contains(sobrenome));

            if (aluno == null)
                return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}