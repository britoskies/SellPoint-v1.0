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
    public class TiposEntidadesService
    {
        SqlConnection connection;
        TiposEntidadesRepo repo;
        public TiposEntidadesService(SqlConnection con)
        {
            connection = con;
            repo = new TiposEntidadesRepo(connection);
        }

        public DataTable ShowTiposEntidades()
        {
            DataTable table = new DataTable();
            table = repo.GetTiposEntidades();
            return table;
        }

        public bool InsertToTipoEntidad(TiposEntidades data)
        {
            return repo.InsertToTipoEntidad(data);
        }

        public bool UpdateTipoEntidad(TiposEntidades data, int id)
        {
            return repo.UpdateTipoEntidad(data, id);
        }

        public bool DeleteTipoEntidad(int id)
        {
            return repo.DeleteTipoEntidad(id);
        }

        public DataTable FillTipoEntidadCB()
        {
            return repo.LoadGruposCB();
        }

        public DataTable FillStatusCB()
        {
            return repo.LoadStatusCB();
        }
        public TiposEntidades GetTipoEntidadById(int id)
        {
            return repo.GetTipoEntidadById(id);
        }
    }
}
