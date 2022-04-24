using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class LoginService
    {
        private SqlConnection connection;

        EntidadRepo repo;

        public LoginService(SqlConnection con)
        {
            connection = con;
            repo = new EntidadRepo(connection);
        }

        public bool ValidateAuth(string user, string password)
        {
            var entidad = repo.GetEntidadesByUser(user);

            // Validaciones de credenciales directas con los campos de la DB
            if (string.IsNullOrEmpty(user)) return false;
            if (string.IsNullOrEmpty(password)) return false;
            if (entidad == null) return false;
            if (entidad.PasswordEntidad != password) return false;

            return true;
        }
    }
}
