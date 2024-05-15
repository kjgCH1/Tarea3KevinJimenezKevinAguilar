using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    public class DbContexto
    {
        private readonly string _connectionString;

        public DbContexto(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public SqlConnection crearConexion()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
