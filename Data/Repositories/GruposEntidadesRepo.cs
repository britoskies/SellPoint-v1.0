using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class GruposEntidadesRepo
    {
        private SqlConnection connection;
        public GruposEntidadesRepo(SqlConnection con)
        {
            connection = con;
        }

        public bool InsertToGrupoEntidad(GruposEntidades data)
        {
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("spInsertGrupoEntidades", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parametros
                cmd.Parameters.AddWithValue("@Descripcion", data.Descripcion);
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

        public bool UpdateGrupoEntidad(GruposEntidades data, int id)
        {
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("spUpdateGrupoEntidades", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parametros
                cmd.Parameters.AddWithValue("@IdGrupoEntidad", id);
                cmd.Parameters.AddWithValue("@Descripcion", data.Descripcion);
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

        public bool DeleteGrupoEntidad(int id)
        {
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("spDeleteGrupoEntidades", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdGrupoEntidad", id);

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

        // Manejo de datos relacionados a la tabla "GruposEntidades"
        public DataTable GetGruposEntidades()
        {
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("spGruposEntidades", connection);
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

        public GruposEntidades GetGrupoEntidadById(int id)
        {
            try
            {
                GruposEntidades data = new GruposEntidades();
                connection.Open();

                SqlCommand cmd = new SqlCommand("spGetGrupoEntidadById", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdGrupoEntidad", id);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    data.IdGrupoEntidad = dr.IsDBNull(0) ? 0 : dr.GetDecimal(0);
                    data.Descripcion = dr.IsDBNull(1) ? "" : dr.GetString(1);
                    data.Comentario = dr.IsDBNull(2) ? "" : dr.GetString(2);
                    data.Status = dr.IsDBNull(3) ? 0 : dr.GetInt32(3);
                    data.NoEliminable = !dr.IsDBNull(3) && dr.GetBoolean(4);
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
