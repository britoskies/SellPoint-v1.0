using Data;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class GruposEntidadesService
    {
        private SqlConnection connection;
        GruposEntidadesRepo repo;

        public GruposEntidadesService(SqlConnection con)
        {
            connection = con;
            repo = new GruposEntidadesRepo(connection);
        }

        public DataTable ShowGruposEntidades()
        {
            DataTable table = new DataTable();
            table = repo.GetGruposEntidades();
            return table;
        }

        public bool InsertToGrupoEntidad(GruposEntidades data)
        {
            return repo.InsertToGrupoEntidad(data);
        }

        public bool UpdateGrupoEntidad(GruposEntidades data, int id)
        {
            return repo.UpdateGrupoEntidad(data, id);
        }

        public bool DeleteGrupoEntidad(int id)
        {
            return repo.DeleteGrupoEntidad(id);
        }

        public DataTable FillStatusCB()
        {
            return repo.LoadStatusCB();
        }
        public GruposEntidades GetGrupoEntidadById(int id)
        {
            return repo.GetGrupoEntidadById(id);
        }
    }
}
