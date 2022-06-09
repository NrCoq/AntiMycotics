using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiMyco.ExplorerModule
{
    public partial class StructureWindow : Form
    {
        public StructureWindow(string url)
        {
            InitializeComponent();
            webBrowser1.Navigate(url);
            Size resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            this.Size = resolution;
        }
    }
}
