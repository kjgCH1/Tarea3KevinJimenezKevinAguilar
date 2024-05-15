using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    public class PersonaRepositorio: IPersonaRepositorio
    {
        private readonly DbContexto _context;

        public PersonaRepositorio(DbContexto context)
        {
            _context = context;
        }
        public bool Insertar(Persona persona) {
            bool insertado = false;
            using (var connection = _context.crearConexion())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_insertar_persona", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Agrega los parámetros necesarios para el procedimiento almacenado
                    command.Parameters.AddWithValue("@cedula", persona.Cedula);
                    command.Parameters.AddWithValue("@nombre", persona.Nombre);
                    command.Parameters.AddWithValue("@apellido", persona.Apellido);

                    // Ejecuta el comando
                    int rowsAffected = command.ExecuteNonQuery();

                    // Verifica si se insertaron filas en la tabla
                    if (rowsAffected > 0)
                        insertado = true;
                }
                catch (Exception ex)
                {
                    // Maneja cualquier excepción que pueda ocurrir al ejecutar el comando
                    Console.WriteLine("Error al insertar persona: " + ex.Message);
                }
            }

            return insertado;
        }

        public Persona Buscar(int cedula) {
            Persona persona = new Persona();
            using (var connection = _context.crearConexion())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_buscar_persona", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Agrega el parámetro necesario para el procedimiento almacenado
                    command.Parameters.AddWithValue("@cedula", cedula);

                    // Ejecuta el comando y obtiene el resultado
                    SqlDataReader reader = command.ExecuteReader();

                    // Verifica si se encontró una persona y asigna sus datos
                    if (reader.Read())
                    {
                        persona = new Persona
                        {
                            Cedula = Convert.ToInt32(reader["cedula"]),
                            Nombre = reader["nombre"].ToString(),
                            Apellido = reader["apellido"].ToString()
                        };
                    }
                }
                catch (Exception ex)
                {
                    // Maneja cualquier excepción que pueda ocurrir al ejecutar el comando
                    Console.WriteLine("Error al buscar persona: " + ex.Message);
                }
            }

            return persona;
        }

        public List<Persona> Obtener() { 
            List<Persona> personas = new List<Persona>();
            using (SqlConnection connection = _context.crearConexion())
            {
                

                using (SqlCommand command = new SqlCommand("ListarPersonas", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    
                        while (reader.Read())
                        {
                            personas.Add(new Persona
                            {
                                Cedula = Convert.ToInt32(reader["cedula"]),
                                Nombre = reader["nombre"].ToString(),
                                Apellido = reader["apellido"].ToString()
                            });
                        }
                    
                }
            }
            return personas;
        }
        public bool Actualizar(Persona persona) {
            bool actualizado = false;
            using (var connection = _context.crearConexion())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_actualizar_persona", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Agrega los parámetros necesarios para el procedimiento almacenado
                    command.Parameters.AddWithValue("@cedula", persona.Cedula);
                    command.Parameters.AddWithValue("@nombre", persona.Nombre);
                    command.Parameters.AddWithValue("@apellido", persona.Apellido);

                    // Ejecuta el comando
                    int rowsAffected = command.ExecuteNonQuery();

                    // Verifica si se actualizaron filas en la tabla
                    if (rowsAffected > 0)
                        actualizado = true;
                }
                catch (Exception ex)
                {
                    // Maneja cualquier excepción que pueda ocurrir al ejecutar el comando
                    Console.WriteLine("Error al actualizar persona: " + ex.Message);
                }
            }

            return actualizado;
        }

        public bool Borrar(int cedula) {
            bool borrado = false;
            using (var connection = _context.crearConexion())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_borrar_persona", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Agrega el parámetro necesario para el procedimiento almacenado
                    command.Parameters.AddWithValue("@cedula", cedula);

                    // Ejecuta el comando y obtiene el resultado
                    int rowsAffected = command.ExecuteNonQuery();

                    // Verifica si se eliminó la persona correctamente
                    if (rowsAffected > 0)
                    {
                        borrado = true;
                    }
                }
                catch (Exception ex)
                {
                    // Maneja cualquier excepción que pueda ocurrir al ejecutar el comando
                    Console.WriteLine("Error al borrar persona: " + ex.Message);
                }
            }

            return borrado;
        }
    }
}
