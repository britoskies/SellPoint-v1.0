using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class TiposEntidadesRepo
    {
        SqlConnection connection;
        public TiposEntidadesRepo(SqlConnection con)
        {
            connection = con;
        }

        public bool InsertToTipoEntidad(TiposEntidades data)
        {
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("spInsertTipoEntidades", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parametros
                cmd.Parameters.AddWithValue("@Descripcion", data.Descripcion);
                cmd.Parameters.AddWithValue("@IdGrupoEntidad", data.IdGrupoEntidad);
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

        public bool UpdateTipoEntidad(TiposEntidades data, int id)
        {
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("spUpdateTipoEntidades", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parametros
                cmd.Parameters.AddWithValue("IdTipoEntidad", id);
                cmd.Parameters.AddWithValue("@Descripcion", data.Descripcion);
                cmd.Parameters.AddWithValue("@IdGrupoEntidad", data.IdGrupoEntidad);
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

        public bool DeleteTipoEntidad(int id)
        {
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("spDeleteTipoEntidad", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdTipoEntidad", id);

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

        // Manejo de datos relacionados a la tabla "TiposEntidades"
        public DataTable GetTiposEntidades()
        {
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("spTiposEntidades", connection);
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

        public TiposEntidades GetTipoEntidadById(int id)
        {
            try
            {
                TiposEntidades data = new TiposEntidades();
                connection.Open();

                SqlCommand cmd = new SqlCommand("spGetTipoEntidadById", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTipoEntidad", id);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    data.IdTipoEntidad = dr.IsDBNull(0) ? 0 : dr.GetDecimal(0);
                    data.Descripcion = dr.IsDBNull(1) ? "" : dr.GetString(1);
                    data.IdGrupoEntidad = dr.IsDBNull(2) ? 0 : dr.GetDecimal(2);
                    data.Comentario = dr.IsDBNull(3) ? "" : dr.GetString(3);
                    data.Status = dr.IsDBNull(4) ? 0 : dr.GetInt32(4);
                    data.NoEliminable = !dr.IsDBNull(5) && dr.GetBoolean(5);
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
