using Aplicacion;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Tarea3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly PersonaServicio _personaService;

        public PersonaController(PersonaServicio personaService)
        {
            _personaService = personaService;
        }

        [HttpGet]
        public IActionResult ObtenerPersonas()
        {
            return Ok(_personaService.ObtenerPersonas());
        }

        [HttpPost("Insertar")]
        public IActionResult InsertarPersona(Persona persona) {
            return Ok(_personaService.InsertarPersona(persona));
        }
        
        [HttpPost("Actualizar")] 
        public IActionResult ActualizarPersona(Persona persona)
        {
            return Ok(_personaService.ActualizarPersona(persona));
        }

        [HttpGet("Buscar")]
        public IActionResult BuscarPersona(int cedula) {
            return Ok(_personaService.BuscarPersona(cedula));
        }

        [HttpDelete("Borrar")]
        public IActionResult BorrarPerso(int cedula)
        {
            return Ok(_personaService.BorrarPersona(cedula));
        }
    }
}
