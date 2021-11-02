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
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ProfessorController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult Get()
        {
            var result = _repository.GetAllProfessores(true);
            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(result));
        }

        [HttpGet("getregister")]
        public IActionResult GetRegisterDto()
        {
            return Ok(new ProfessorRegisterDto());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repository.GetProfessorById(id);

            if (professor == null)
                return BadRequest("Professor não encontrado.");

            return Ok(_mapper.Map<ProfessorDto>(professor));
        }

        [HttpPost]
        public IActionResult Post(ProfessorRegisterDto professorDto)
        {
            var professor = _mapper.Map<Professor>(professorDto);
            _repository.Add(professor);
            if (_repository.SaveChanges())
                return Created($"/api/professor/{professor.Id}", _mapper.Map<ProfessorDto>(professor));
            else
                return BadRequest("Professor não foi criado.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegisterDto professorDto)
        {
            var professor = _repository.GetProfessorById(id);

            if (professor == null)
                return BadRequest("Professor não encontrado.");

            _mapper.Map(professorDto, professor);

            _repository.Update(professor);

            if (_repository.SaveChanges())
                return Created($"/api/professor/{professor.Id}", _mapper.Map<ProfessorDto>(professor));
            else
                return BadRequest("Professor não atualizado.");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorRegisterDto professorDto)
        {
            var professor = _repository.GetProfessorById(id);

            if (professor == null)
                return BadRequest("Professor não encontrado.");

            _mapper.Map(professorDto, professor);

            _repository.Update(professor);
            if (_repository.SaveChanges())
                return Created($"/api/professor/{professor.Id}", _mapper.Map<ProfessorDto>(professor));
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