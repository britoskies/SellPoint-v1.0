using Business.Services;
using Data;
using Data.Repositories;
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

namespace Presentation.RegistroEntidades
{
    public partial class RegistroEntidades : Form
    {
        private Entidades Data { get; set; }
        private Entidades entidad = new Entidades();

        public static RegistroEntidades Form { get; } = new RegistroEntidades();

        public string connectionString = ConfigurationManager.ConnectionStrings["SellPointEntities"].ConnectionString;

        SqlConnection connection;
        EntidadService entidadService;

        public RegistroEntidades()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            entidadService = new EntidadService(connection);
        }

        private void RegistroEntidades_Load(object sender, EventArgs e)
        {
            dgEntidades.DataSource = entidadService.ShowEntidades();
            dgEntidades.ClearSelection();
            dgEntidades.Columns[0].Visible = false;
            FillComboBoxes();
        }

        private void Refresh()
        {
            dgEntidades.DataSource = entidadService.ShowEntidades();
            txtDescripcion.Text = "";
            txtDireccion.Text = "";
            txtLocalidad.Text = "";
            cbTipoEntidad.SelectedIndex = 0;
            cbTipoDocumento.SelectedIndex = 0;
            txtNumeroDocumento.Text = "";
            txtTelefonos.Text = "";
            txtPaginaWeb.Text = "";
            txtFacebook.Text = "";
            txtTwitter.Text = "";
            txtTikTok.Text = "";
            txtInstagram.Text = "";
            txtUsuario.Text = "";
            txtPassword.Text = "";
            cbGrupoEntidad.SelectedIndex = 0;
            cbTiposEntidades.SelectedIndex = 0;
            cbRol.SelectedIndex = 0;
            txtComentario.Text = "";
            cbStatus.SelectedIndex = 0;
            checkEliminable.Checked = false;
        }

        private void FillComboBoxes()
        {
            cbTipoEntidad.ValueMember = "IdTipoEntidad";
            cbTipoEntidad.DisplayMember = "TipoEntidad";
            cbTipoEntidad.DataSource = entidadService.FillTipoEntidadCB();

            cbTiposEntidades.ValueMember = "IdTipoEntidad";
            cbTiposEntidades.DisplayMember = "Descripcion";
            cbTiposEntidades.DataSource = entidadService.FillTiposEntidadesCB();

            cbGrupoEntidad.ValueMember = "IdGrupoEntidad";
            cbGrupoEntidad.DisplayMember = "Descripcion";
            cbGrupoEntidad.DataSource = entidadService.FillGrupoEntidadCB();

            cbTipoDocumento.ValueMember = "IdTipoDocumento";
            cbTipoDocumento.DisplayMember = "TipoDocumento";
            cbTipoDocumento.DataSource = entidadService.FillTipoDocumentoCB();

            cbRol.ValueMember = "IdRolUserEntidad";
            cbRol.DisplayMember = "RolUserEntidad";
            cbRol.DataSource = entidadService.FillRolCB();

            cbStatus.ValueMember = "IdStatus";
            cbStatus.DisplayMember = "Status";
            cbStatus.DataSource = entidadService.FillStatusCB();
        }

        private bool ValidateAllFields()
        {
            if (txtDescripcion.Text == "" ||
                txtDireccion.Text == "" ||
                txtLocalidad.Text == "" ||
                cbTipoEntidad.SelectedIndex == 0 ||
                cbTipoDocumento.SelectedIndex == 0 ||
                txtNumeroDocumento.Text == "" ||
                txtTelefonos.Text == "" ||
                txtPaginaWeb.Text == "" ||
                txtFacebook.Text == "" ||
                txtTwitter.Text == "" ||
                txtTikTok.Text == "" ||
                txtInstagram.Text == "" ||
                txtUsuario.Text == "" ||
                txtPassword.Text == "" ||
                cbGrupoEntidad.SelectedIndex == 0 ||
                cbTiposEntidades.SelectedIndex == 0 ||
                cbRol.SelectedIndex == 0 ||
                txtComentario.Text == "" ||
                cbStatus.SelectedIndex == 0
            ) return false;

            else return true;    
        } 

        private void Insert()
        {
            Data = new Entidades();
            {
                Data.Descripcion = txtDescripcion.Text;
                Data.Direccion = txtDireccion.Text;
                Data.Localidad = txtLocalidad.Text;
                Data.NumeroDocumento = Convert.ToDecimal(txtNumeroDocumento.Text);
                Data.Telefonos = txtTelefonos.Text;
                Data.URLPaginaWeb = txtPaginaWeb.Text;
                Data.URLFacebook = txtFacebook.Text;
                Data.URLInstagram = txtInstagram.Text;
                Data.URLTwitter = txtTwitter.Text;
                Data.URLTikTok = txtTikTok.Text;
                Data.LimiteCredito = (decimal?)199.99;
                Data.UserNameEntidad = txtUsuario.Text;
                Data.PasswordEntidad = txtPassword.Text;
                Data.Comentario = txtComentario.Text;
                Data.IdGrupoEntidad = cbGrupoEntidad.SelectedIndex;
                Data.IdTipoEntidad = cbTipoEntidad.SelectedIndex;
                Data.TipoEntidad = cbTipoEntidad.SelectedIndex;
                Data.TipoDocumento = cbTipoDocumento.SelectedIndex;
                Data.RolUserEntidad = cbRol.SelectedIndex;
                Data.Status = cbStatus.SelectedIndex;

                Data.NoEliminable = checkEliminable.Checked;
                if (checkEliminable.Checked) Data.NoEliminable = true;
            }

        }

        private int GetRowId()
        {
            int id;
            if (dgEntidades.SelectedRows.Count > 0)
            {
                id = Convert.ToInt32(dgEntidades.CurrentRow.Cells[0].Value.ToString());
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
                entidad = entidadService.GetEntidadesById(id);

                txtDescripcion.Text = entidad.Descripcion;
                txtDireccion.Text = entidad.Direccion;
                txtLocalidad.Text = entidad.Localidad;
                cbTipoEntidad.SelectedIndex = entidad.TipoEntidad;
                cbTipoDocumento.SelectedIndex = entidad.TipoDocumento;
                txtNumeroDocumento.Text = entidad.NumeroDocumento.ToString();
                txtTelefonos.Text = entidad.Telefonos;
                txtPaginaWeb.Text = entidad.URLPaginaWeb;
                txtFacebook.Text = entidad.URLFacebook;
                txtTwitter.Text = entidad.URLTwitter;
                txtTikTok.Text = entidad.URLTikTok;
                txtInstagram.Text = entidad.URLInstagram;
                txtUsuario.Text = entidad.UserNameEntidad;
                txtPassword.Text = entidad.PasswordEntidad;
                cbGrupoEntidad.SelectedIndex = (int)entidad.IdGrupoEntidad;
                cbTiposEntidades.SelectedIndex = (int)entidad.IdTipoEntidad;
                cbRol.SelectedIndex = (int)entidad.RolUserEntidad;
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
                bool wasInserted = entidadService.InsertToEntidades(Data);

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
                bool wasUpdated = entidadService.UpdateEntidades(Data, id);
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
                DialogResult isSureDialog = MessageBox.Show("¿Estás seguro?", "Advertencia", MessageBoxButtons.YesNo);

                if (isSureDialog == DialogResult.Yes)
                {
                    bool wasDeleted = entidadService.DeleteEntidad(GetRowId());

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
