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
    public class EntidadService
    {
        private SqlConnection connection;
        private EntidadRepo repo;

        public EntidadService(SqlConnection con)
        {
            connection = con;
            repo = new EntidadRepo(connection);
        }

        public bool InsertToEntidades(Entidades data)
        {
            return repo.InsertToEntidades(data);
        }

        public bool UpdateEntidades(Entidades data, int id)
        {
            return repo.UpdateEntidades(data, id);
        }

        public bool DeleteEntidad(int id)
        {
            return repo.DeleteEntidad(id);
        }

        public DataTable FillTipoEntidadCB()
        {
            return repo.LoadTiposCB();
        }

        public DataTable FillTiposEntidadesCB()
        {
            return repo.LoadTiposEntidadesCB();
        }

        public DataTable FillGrupoEntidadCB()
        {
           return repo.LoadGruposCB();
        }

        public DataTable FillTipoDocumentoCB()
        {
            return repo.LoadTipoDocumentoCB();
        }

        public DataTable FillRolCB()
        {
            return repo.LoadRolCB();
        }

        public DataTable FillStatusCB()
        {
            return repo.LoadStatusCB();
        }

        public DataTable ShowEntidades()
        {
            DataTable table = new DataTable();
            table = repo.GetEntidades();
            return table;
        }

        public Entidades GetEntidadesByUser(string username)
        {
            return repo.GetEntidadesByUser(username);
        }

        public Entidades GetEntidadesById(int id)
        {
            return repo.GetEntidadesById(id);
        }
    }
}
