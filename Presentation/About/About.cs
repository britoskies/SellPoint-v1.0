using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.About
{
    public sealed partial class About : Form
    {

        public static About Form { get; } = new About();

        public About()
        {
            InitializeComponent();
        }
    }
}
