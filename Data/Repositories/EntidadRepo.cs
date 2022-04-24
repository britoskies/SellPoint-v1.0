using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EntidadRepo
    {
        private SqlConnection connection;

        public EntidadRepo(SqlConnection con)
        {
            connection = con;
        }

        public bool InsertToEntidades(Entidades data)
        {
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("spInsertEntidades", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parametros
                cmd.Parameters.AddWithValue("@Descripcion", data.Descripcion);
                cmd.Parameters.AddWithValue("@Direccion", data.Direccion);
                cmd.Parameters.AddWithValue("@Localidad", data.Localidad);
                cmd.Parameters.AddWithValue("@TipoEntidad", data.TipoEntidad);
                cmd.Parameters.AddWithValue("@TipoDocumento", data.TipoDocumento);
                cmd.Parameters.AddWithValue("@NumeroDocumento", data.NumeroDocumento);
                cmd.Parameters.AddWithValue("@Telefonos", data.Telefonos);
                cmd.Parameters.AddWithValue("@URLPaginaWeb", data.URLPaginaWeb);
                cmd.Parameters.AddWithValue("@URLFacebook", data.URLFacebook);
                cmd.Parameters.AddWithValue("@URLInstagram", data.URLInstagram);
                cmd.Parameters.AddWithValue("@URLTwitter", data.URLTwitter);
                cmd.Parameters.AddWithValue("@URLTikTok", data.URLTikTok);
                cmd.Parameters.AddWithValue("@IdGrupoEntidad", data.IdGrupoEntidad);
                cmd.Parameters.AddWithValue("@IdTipoEntidad", data.IdTipoEntidad);
                cmd.Parameters.AddWithValue("@LimiteCredito", data.LimiteCredito);
                cmd.Parameters.AddWithValue("@UserNameEntidad", data.UserNameEntidad);
                cmd.Parameters.AddWithValue("@PasswordEntidad", data.PasswordEntidad);
                cmd.Parameters.AddWithValue("@RolUserEntidad", data.RolUserEntidad);
                cmd.Parameters.AddWithValue("@Comentario", data.Comentario);
                cmd.Parameters.AddWithValue("@Status", data.Status);
                cmd.Parameters.AddWithValue("@NoEliminable", data.NoEliminable);

                cmd.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        public bool UpdateEntidades(Entidades data, int id)
        {
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("spUpdateEntidades", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parametros
                cmd.Parameters.AddWithValue("@IdEntidad", id);
                cmd.Parameters.AddWithValue("@Descripcion", data.Descripcion);
                cmd.Parameters.AddWithValue("@Direccion", data.Direccion);
                cmd.Parameters.AddWithValue("@Localidad", data.Localidad);
                cmd.Parameters.AddWithValue("@TipoEntidad", data.TipoEntidad);
                cmd.Parameters.AddWithValue("@TipoDocumento", data.TipoDocumento);
                cmd.Parameters.AddWithValue("@NumeroDocumento", data.NumeroDocumento);
                cmd.Parameters.AddWithValue("@Telefonos", data.Telefonos);
                cmd.Parameters.AddWithValue("@URLPaginaWeb", data.URLPaginaWeb);
                cmd.Parameters.AddWithValue("@URLFacebook", data.URLFacebook);
                cmd.Parameters.AddWithValue("@URLInstagram", data.URLInstagram);
                cmd.Parameters.AddWithValue("@URLTwitter", data.URLTwitter);
                cmd.Parameters.AddWithValue("@URLTikTok", data.URLTikTok);
                cmd.Parameters.AddWithValue("@IdGrupoEntidad", data.IdGrupoEntidad);
                cmd.Parameters.AddWithValue("@IdTipoEntidad", data.IdTipoEntidad);
                cmd.Parameters.AddWithValue("@LimiteCredito", data.LimiteCredito);
                cmd.Parameters.AddWithValue("@UserNameEntidad", data.UserNameEntidad);
                cmd.Parameters.AddWithValue("@PasswordEntidad", data.PasswordEntidad);
                cmd.Parameters.AddWithValue("@RolUserEntidad", data.RolUserEntidad);
                cmd.Parameters.AddWithValue("@Comentario", data.Comentario);
                cmd.Parameters.AddWithValue("@Status", data.Status);
                cmd.Parameters.AddWithValue("@NoEliminable", data.NoEliminable);

                cmd.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        public bool DeleteEntidad(int id)
        {
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("spDeleteEntidades", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEntidad", id);

                cmd.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        public DataTable LoadTiposCB()
        {
            SqlCommand cmd = new SqlCommand("select * from tblTipoEntidad", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();

            DataRow fila = table.NewRow();
            fila["TipoEntidad"] = "Tipo de Entidad";
            table.Rows.InsertAt(fila, 0);
            return table;
        }

        public DataTable LoadTiposEntidadesCB()
        {
            SqlCommand cmd = new SqlCommand("select IdTipoEntidad, Descripcion from TiposEntidades", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();

            DataRow fila = table.NewRow();
            fila["Descripcion"] = "Tipos de Entidades";
            table.Rows.InsertAt(fila, 0);
            return table;
        }

        public DataTable LoadGruposCB()
        {
            SqlCommand cmd = new SqlCommand("select IdGrupoEntidad,Descripcion from GruposEntidades", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();

            DataRow fila = table.NewRow();
            fila["Descripcion"] = "Grupo de Entidad";
            table.Rows.InsertAt(fila, 0);
            return table;
        }

        public DataTable LoadTipoDocumentoCB()
        {
            SqlCommand cmd = new SqlCommand("select * from tblTipoDocumento", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();

            DataRow fila = table.NewRow();
            fila["TipoDocumento"] = "Tipo de Documento";
            table.Rows.InsertAt(fila, 0);
            return table;
        }

        public DataTable LoadRolCB()
        {
            SqlCommand cmd = new SqlCommand("select * from tblRolUserEntidad", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();

            DataRow fila = table.NewRow();
            fila["RolUserEntidad"] = "Rol de Usuario";
            table.Rows.InsertAt(fila, 0);
            return table;
        }

        public DataTable LoadStatusCB()
        {
            SqlCommand cmd = new SqlCommand("select * from tblStatus", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();

            DataRow fila = table.NewRow();
            fila["Status"] = "Estado";
            table.Rows.InsertAt(fila, 0);
            return table;
        }

        public DataTable GetEntidades()
        {
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("spEntidades", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(reader);

                connection.Close();
                return table; 
            }
            catch (Exception)
            {
                connection.Close();
                return null;
            }
        }

        public Entidades GetEntidadesById(int id)
        {
            try
            {
                Entidades data = new Entidades();
                connection.Open();

                SqlCommand cmd = new SqlCommand("spGetEntidadesById", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEntidad", id);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read()) 
                {
                    data.IdEntidad = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                    data.Descripcion = dr.IsDBNull(1) ? "" : dr.GetString(1);
                    data.Direccion = dr.IsDBNull(2) ? "" : dr.GetString(2);
                    data.Localidad = dr.IsDBNull(3) ? "" : dr.GetString(3);
                    data.TipoEntidad = dr.IsDBNull(4) ? 0 : dr.GetInt32(4);
                    data.TipoDocumento = dr.IsDBNull(5) ? 0 : dr.GetInt32(5);
                    data.NumeroDocumento = dr.IsDBNull(6) ? 0 : dr.GetDecimal(6);
                    data.Telefonos = dr.IsDBNull(7) ? "" : dr.GetString(7);
                    data.URLPaginaWeb = dr.IsDBNull(8) ? "" : dr.GetString(8);
                    data.URLFacebook = dr.IsDBNull(9) ? "" : dr.GetString(9);
                    data.URLInstagram = dr.IsDBNull(10) ? "" : dr.GetString(10);
                    data.URLTwitter = dr.IsDBNull(11) ? "" : dr.GetString(11);
                    data.URLTikTok = dr.IsDBNull(12) ? "" : dr.GetString(12);
                    data.IdGrupoEntidad = dr.IsDBNull(13) ? 0 : dr.GetDecimal(13);
                    data.IdTipoEntidad = dr.IsDBNull(14) ? 0 : dr.GetDecimal(14);
                    data.LimiteCredito = dr.IsDBNull(15) ? 0 : dr.GetDecimal(15);
                    data.UserNameEntidad = dr.IsDBNull(16) ? "" : dr.GetString(16);
                    data.PasswordEntidad = dr.IsDBNull(17) ? "" : dr.GetString(17);
                    data.RolUserEntidad = dr.IsDBNull(18) ? 0 : dr.GetInt32(18);
                    data.Comentario = dr.IsDBNull(19) ? "" : dr.GetString(19);
                    data.Status = dr.IsDBNull(20) ? 0 : dr.GetInt32(20);
                    data.NoEliminable = dr.IsDBNull(21) ? false : dr.GetBoolean(21);
                }

                dr.Dispose();
                dr.Close();
                connection.Close();

                return data;
            }
            catch (Exception)
            {
                connection.Close();
                return null;
            }
        }

        public Entidades GetEntidadesByUser(string username)
        {
            try
            {
                Entidades data = new Entidades();
                connection.Open();
                
                // Consulta para filtrar el campo relacionado al UserNameEntidad
                SqlCommand cmd = new SqlCommand("select * from Entidades where UserNameEntidad=@username", connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@username", username);

                // Método de lectura directa a la DB (DataReader)
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // Check de cada campo en la tabla Entidades
                    data.IdEntidad = dr.IsDBNull(0) ? 0 : dr.GetInt32(0); 
                    data.Descripcion = dr.IsDBNull(1) ? "" : dr.GetString(1);
                    data.Direccion = dr.IsDBNull(2) ? "" : dr.GetString(2);
                    data.Localidad = dr.IsDBNull(3) ? "" : dr.GetString(3);
                    data.TipoEntidad = dr.IsDBNull(4) ? 0 : dr.GetInt32(4);
                    data.TipoDocumento = dr.IsDBNull(5) ? 0 : dr.GetInt32(5);
                    data.NumeroDocumento = dr.IsDBNull(6) ? 0 : dr.GetDecimal(6);
                    data.Telefonos = dr.IsDBNull(7) ? "" : dr.GetString(7);
                    data.URLPaginaWeb = dr.IsDBNull(8) ? "" : dr.GetString(8);
                    data.URLFacebook = dr.IsDBNull(9) ? "" : dr.GetString(9);
                    data.URLInstagram = dr.IsDBNull(10) ? "" : dr.GetString(10);
                    data.URLTwitter = dr.IsDBNull(11) ? "" : dr.GetString(11);
                    data.URLTikTok = dr.IsDBNull(12) ? "" : dr.GetString(12);
                    data.IdGrupoEntidad = dr.IsDBNull(13) ? 0 : dr.GetDecimal(13);
                    data.IdTipoEntidad = dr.IsDBNull(14) ? 0 : dr.GetDecimal(14);
                    data.LimiteCredito = dr.IsDBNull(15) ? 0 : dr.GetDecimal(15);
                    data.UserNameEntidad = dr.IsDBNull(16) ? "" : dr.GetString(16);
                    data.PasswordEntidad = dr.IsDBNull(17) ? "" : dr.GetString(17);
                    data.RolUserEntidad = dr.IsDBNull(18) ? 0 : dr.GetInt32(18);
                    data.Comentario = dr.IsDBNull(19) ? "" : dr.GetString(19);
                    data.Status = dr.IsDBNull(20) ? 0 : dr.GetInt32(20);
                    data.NoEliminable = dr.IsDBNull(21) ? false : dr.GetBoolean(21);
                }

                dr.Dispose();
                dr.Close();
                connection.Close();

                return data;
            }
            catch (Exception)
            {
                connection.Close();
                return null;
            }
        }
    }
}
