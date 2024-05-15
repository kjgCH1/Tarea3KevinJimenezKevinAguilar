using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public interface IPersonaRepositorio
    {
        bool Insertar(Persona persona);
        Persona Buscar(int cedula);
        List<Persona> Obtener();
        bool Actualizar(Persona persona);
        bool Borrar(int cedula);
    }
}
