using Business.Services;
using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.RegistroTipoEntidades
{
    public partial class RegistroTipoEntidades : Form
    {
        private TiposEntidades Data { get; set; }
        private TiposEntidades entidad = new TiposEntidades();

        public static RegistroTipoEntidades Form { get; } = new RegistroTipoEntidades();

        public string connectionString = ConfigurationManager.ConnectionStrings["SellPointEntities"].ConnectionString;

        private SqlConnection connection;
        private TiposEntidadesService TE_Service;

        public RegistroTipoEntidades()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            TE_Service = new TiposEntidadesService(connection);
            dgTipoEntidades.ClearSelection();
            //dgTipoEntidades.Columns[1].Visible = false;
            FillComboBox();
        }

        private void RegistroTipoEntidades_Load(object sender, EventArgs e)
        {
            dgTipoEntidades.DataSource = TE_Service.ShowTiposEntidades();
        }

        private void Refresh()
        {
            dgTipoEntidades.DataSource = TE_Service.ShowTiposEntidades();
            txtDescripcion.Text = "";
            txtComentario.Text = "";
            cbStatus.SelectedIndex = 0;
            cbGrupoEntidad.SelectedIndex = 0;
            checkEliminable.Checked = false;
        }

        private void FillComboBox()
        {
            cbGrupoEntidad.ValueMember = "IdGrupoEntidad";
            cbGrupoEntidad.DisplayMember = "Descripcion";
            cbGrupoEntidad.DataSource = TE_Service.FillTipoEntidadCB();

            cbStatus.ValueMember = "IdStatus";
            cbStatus.DisplayMember = "Status";
            cbStatus.DataSource = TE_Service.FillStatusCB();
        }

        private bool ValidateAllFields()
        {
            if (txtDescripcion.Text == "" || txtComentario.Text == "" ||
                cbStatus.SelectedIndex == 0 || cbGrupoEntidad.SelectedIndex == 0
            ) return false;

            else return true;
        }

        private void Insert()
        {
            Data = new TiposEntidades();
            {
                Data.Descripcion = txtDescripcion.Text;
                Data.Comentario = txtComentario.Text;
                Data.IdGrupoEntidad = cbGrupoEntidad.SelectedIndex;
                Data.Status = cbStatus.SelectedIndex;

                Data.NoEliminable = checkEliminable.Checked;
                if (checkEliminable.Checked) Data.NoEliminable = true;
            }
        }

        private int GetRowId()
        {
            int id;
            if (dgTipoEntidades.SelectedRows.Count > 0)
            {
                id = Convert.ToInt32(dgTipoEntidades.CurrentRow.Cells[0].Value.ToString());
                return id;
            }
            else
            {
                MessageBox.Show("Porfavor, seleccione una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void FillFields(int id)
        {
            if (id != 0)
            {
                entidad = TE_Service.GetTipoEntidadById(id);

                txtDescripcion.Text = entidad.Descripcion;
                txtComentario.Text = entidad.Comentario;
                cbGrupoEntidad.SelectedIndex = (int)entidad.IdGrupoEntidad;
                cbStatus.SelectedIndex = (int)entidad.Status;
                checkEliminable.Checked = (bool)entidad.NoEliminable;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void txtAgregar_Click(object sender, EventArgs e)
        {
            if (ValidateAllFields())
            {
                Insert();
                bool wasInserted = TE_Service.InsertToTipoEntidad(Data);

                if (wasInserted) MessageBox.Show("Registro insertado exitosamente!", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else MessageBox.Show("Algo fue mal :'(", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Llene todos los campos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FillFields(GetRowId());
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = GetRowId();
            if (ValidateAllFields())
            {
                Insert();
                bool wasUpdated = TE_Service.UpdateTipoEntidad(Data, id);
                if (wasUpdated) MessageBox.Show("Registro actualizado exitosamente!", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else MessageBox.Show("Lo sentimos :'(", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("Llene todos los campos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (GetRowId() >= 0)
            {
                DialogResult isSureDialog = MessageBox.Show("¿Estás seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (isSureDialog == DialogResult.Yes)
                {
                    bool wasDeleted = TE_Service.DeleteTipoEntidad(GetRowId());

                    if (wasDeleted)
                    {
                        MessageBox.Show("Registro eliminado exitosamente!", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Refresh();
                    }
                    else MessageBox.Show("Lo sentimos :'(", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
