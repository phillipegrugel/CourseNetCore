using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Api.Data;
using SmartSchool.Api.Dtos;
using SmartSchool.Api.Models;

namespace SmartSchool.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AlunoController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repository.GetAllAlunos(true);

            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(result));
        }

        [HttpGet("getregister")]
        public IActionResult GetRegisterDto()
        {
            return Ok(new AlunoRegisterDto());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repository.GetAlynoById(id);

            if (aluno == null)
                return BadRequest("Aluno não encontrado");

            return Ok(_mapper.Map<AlunoDto>(aluno));
        }

        [HttpPost]
        public IActionResult Post(AlunoRegisterDto alunoDto)
        {
            var aluno = _mapper.Map<Aluno>(alunoDto);
            _repository.Add(aluno);
            if(_repository.SaveChanges())
                return Created($"/api/aluno/{aluno.Id}", _mapper.Map<AlunoDto>(aluno));
            else
                return BadRequest("Erro ao salvar aluno");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoRegisterDto alunoDto)
        {
            var aluno = _repository.GetAlynoById(id);

            if (aluno == null)
                return BadRequest("Aluno não encontrado");

            _mapper.Map(alunoDto, aluno);

            _repository.Update(aluno);
            if (_repository.SaveChanges())
                return Created($"/api/aluno/{aluno.Id}", _mapper.Map<AlunoDto>(aluno));
            else
                return BadRequest("Erro ao atualizar o aluno.");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoRegisterDto alunoDto)
        {
            var aluno = _repository.GetAlynoById(id);

            if (aluno == null)
                return BadRequest("Aluno não encontrado");

            _mapper.Map(alunoDto, aluno);

            _repository.Update(aluno);
            if (_repository.SaveChanges())
                return Created($"/api/aluno/{aluno.Id}", _mapper.Map<AlunoDto>(aluno));
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