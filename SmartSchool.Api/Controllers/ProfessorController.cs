using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public ProfessorController() { }

        public IActionResult Get()
        {
            return Ok("Professores: Marta, Paula, Lucas, Rafa");
        }
    }
}