using Business;
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

namespace Presentation
{
    public sealed partial class Login : Form
    {
        public string UserName;

        // Login instance to run application
        public static Login Form { get; } = new Login();

        public string connectionString = ConfigurationManager.ConnectionStrings["SellPointEntities"].ConnectionString;

        SqlConnection connection;
        LoginService loginService;

        public Login()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            loginService = new LoginService(connection);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Almacenamiento del método encargado de verificar las credenciales
            bool isAuthenticated = loginService.ValidateAuth(txtUsername.Text, txtPassword.Text);
            UserName = txtUsername.Text;

            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
               MessageBox.Show("Porfavor, complete ambos campos!");
            }
            else
            {
                if (isAuthenticated) 
                { 
                    MenuPrincipal.MenuPrincipal menu = new MenuPrincipal.MenuPrincipal(UserName);

                    menu.Show();
                    this.Hide();
                }
                else MessageBox.Show("Sus credenciales no coinciden!\n" + "Intente nuevamente");
            }

        }
    }
}
