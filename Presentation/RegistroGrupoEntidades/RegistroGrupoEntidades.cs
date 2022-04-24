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

namespace Presentation.RegistroGrupoEntidades
{
    public partial class RegistroGrupoEntidades : Form
    {
        private GruposEntidades Data { get; set; }
        private GruposEntidades entidad = new GruposEntidades();
        public static RegistroGrupoEntidades Form { get; } = new RegistroGrupoEntidades();

        public string connectionString = ConfigurationManager.ConnectionStrings["SellPointEntities"].ConnectionString;

        private SqlConnection connection;
        private GruposEntidadesService GE_Service;

        public RegistroGrupoEntidades()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            GE_Service = new GruposEntidadesService(connection);
        }

        private void RegistroGrupoEntidades_Load(object sender, EventArgs e)
        {
            dgGrupoEntidades.DataSource = GE_Service.ShowGruposEntidades();
            dgGrupoEntidades.ClearSelection();
            dgGrupoEntidades.Columns[0].Visible = false;
            FillComboBox();
        }

        private void Refresh()
        {
            dgGrupoEntidades.DataSource = GE_Service.ShowGruposEntidades();
            txtDescripcion.Text = "";
            txtComentario.Text = "";
            cbStatus.SelectedIndex = 0;
            checkEliminable.Checked = false;
        }

        private void FillComboBox()
        {
            cbStatus.ValueMember = "IdStatus";
            cbStatus.DisplayMember = "Status";
            cbStatus.DataSource = GE_Service.FillStatusCB();
        }

        private bool ValidateAllFields()
        {
            if (txtDescripcion.Text == "" || txtComentario.Text == "" ||
                cbStatus.SelectedIndex == 0
            ) return false;

            else return true;
        }

        private void Insert()
        {
            Data = new GruposEntidades();
            {
                Data.Descripcion = txtDescripcion.Text;
                Data.Comentario = txtComentario.Text;

                // Status validacion
                if (cbStatus.Text == "Activa") Data.Status = 1;
                else Data.Status = 2;

                Data.NoEliminable = checkEliminable.Checked;
                if (checkEliminable.Checked) Data.NoEliminable = true;
            }
        }

        private int GetRowId()
        {
            int id;
            if (dgGrupoEntidades.SelectedRows.Count > 0)
            {
                id = Convert.ToInt32(dgGrupoEntidades.CurrentRow.Cells[0].Value.ToString());
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
                entidad = GE_Service.GetGrupoEntidadById(id);

                txtDescripcion.Text = entidad.Descripcion;
                txtComentario.Text = entidad.Comentario;
                cbStatus.SelectedIndex = (int)entidad.Status;
                checkEliminable.Checked = (bool)entidad.NoEliminable;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidateAllFields())
            {
                Insert();
                bool wasInserted = GE_Service.InsertToGrupoEntidad(Data);

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
                bool wasUpdated = GE_Service.UpdateGrupoEntidad(Data, id);
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
                    bool wasDeleted = GE_Service.DeleteGrupoEntidad(GetRowId());

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
