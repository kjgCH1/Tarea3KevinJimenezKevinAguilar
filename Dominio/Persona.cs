using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        int cedula;
        string nombre;
        string apellido;

        public Persona() { 
            this.cedula = 0;
            this.nombre = "";
            this.apellido = "";
        }

        public int Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
    }
}
