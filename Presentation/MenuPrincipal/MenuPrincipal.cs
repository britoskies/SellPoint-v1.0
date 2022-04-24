using Business.Services;
using Data;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Presentation.MenuPrincipal
{
    public partial class MenuPrincipal : Form
    {
        //public static MenuPrincipal Form { get; } = new MenuPrincipal();
        public string connectionString = ConfigurationManager.ConnectionStrings["SellPointEntities"].ConnectionString;

        private Login login = new Login();
        private Entidades entidad = new Entidades();
        private EntidadService entidadService;
        private SqlConnection connection;
        private RegistroEntidades.RegistroEntidades registroEntidades;
        private RegistroTipoEntidades.RegistroTipoEntidades registroTipoEntidades;
        private RegistroGrupoEntidades.RegistroGrupoEntidades registroGrupoEntidades;
        private About.About about;

        public MenuPrincipal(string username)
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            entidadService = new EntidadService(connection);

            // Set of username
            entidad = entidadService.GetEntidadesByUser(username);
            lblNombre.Text = username.ToUpper();
        }
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

            lblDocumento.Text = entidad.NumeroDocumento.ToString();
            lblDescripcion.Text = entidad.Descripcion;
            lblTelefonos.Text = entidad.Telefonos;
            lblLocalidad.Text = entidad.Localidad;
            lblDireccion.Text = entidad.Direccion;

            if (entidad.RolUserEntidad == 1) lblRol.Text = "Admin";
            else if (entidad.RolUserEntidad == 2) lblRol.Text = "Supervisor";
            else lblRol.Text = "User";

            if (entidad.Status == 1)
            {
                lblStatus.Text = "Activa";
            }
            else 
            {
                lblStatus.Text = "Inactiva";
                lblStatus.ForeColor = System.Drawing.Color.Brown;
            } 

            if (entidad.TipoEntidad == 1) lblTipoEntidad.Text = "Física";
            else lblTipoEntidad.Text = "Jurídica";

            if (entidad.TipoDocumento == 1) lblTipoDocumento.Text = "RNC";
            else if (entidad.TipoDocumento == 2) lblTipoDocumento.Text = "Cédula";
            else lblTipoDocumento.Text = "Pasaporte";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToString("hh:mm tt | dddd dd/MM/yy");
        }

        private void gruposEntidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registroGrupoEntidades = new RegistroGrupoEntidades.RegistroGrupoEntidades();
            registroGrupoEntidades.Show();
        }

        private void tiposEntidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registroTipoEntidades = new RegistroTipoEntidades.RegistroTipoEntidades();
            registroTipoEntidades.Show();
        }

        private void entidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registroEntidades = new RegistroEntidades.RegistroEntidades();
            registroEntidades.Show();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about = new About.About();
            about.Show();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.Form.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkPagina.Links.Add(24, 9, entidad.URLPaginaWeb);
        }

        private void linkFacebook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkFacebook.Links.Add(24, 9, entidad.URLFacebook);
        }

        private void linkInstagram_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkInstagram.Links.Add(24, 9, entidad.URLInstagram);
        }

        private void linkTikTok_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkTikTok.Links.Add(24, 9, entidad.URLInstagram);
        }

        private void linkTwitter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkTwitter.Links.Add(24, 9, entidad.URLTwitter);
        }
    }
}
