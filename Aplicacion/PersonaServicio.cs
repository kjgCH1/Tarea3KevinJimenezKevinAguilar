using Dominio;
using Infraestructura;

namespace Aplicacion
{
    public class PersonaServicio
    {
        private readonly PersonaRepositorio _personaRepositorio;

        public PersonaServicio(PersonaRepositorio personaRepositorio)
        {
            _personaRepositorio = personaRepositorio;
        }

        public bool InsertarPersona(Persona persona)
        {
            return _personaRepositorio.Insertar(persona);
        }

        public Persona BuscarPersona(int cedula)
        {
            return _personaRepositorio.Buscar(cedula);
        }

        public List<Persona> ObtenerPersonas()
        {
            return _personaRepositorio.Obtener();
        }

        public bool ActualizarPersona(Persona persona)
        {
            return _personaRepositorio.Actualizar(persona);
        }

        public bool BorrarPersona(int cedula)
        {
            return _personaRepositorio.Borrar(cedula);
        }
    }
}
