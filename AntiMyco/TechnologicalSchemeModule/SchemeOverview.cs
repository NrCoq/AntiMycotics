using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntiMyco.DataModels;

namespace AntiMyco.TechnologicalSchemeModule
{
    public partial class SchemeOverview : Form
    {
        TechnologicalSchemeDBContext db;

        public SchemeOverview()
        {
            InitializeComponent();
            db = new TechnologicalSchemeDBContext();
        }
    }
}
