using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class SplashScreen : Form
    {
        public static SplashScreen Form { get; } = new SplashScreen();
        public SplashScreen()
        {
            InitializeComponent();
        }
        private void SplashScreen_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            progressBarPanel.Width += 55;

            if (progressBarPanel.Width >= 650)
            {
                timer.Stop();
                this.Hide();
                Login.Form.Show();
            }
        }
    }
}
