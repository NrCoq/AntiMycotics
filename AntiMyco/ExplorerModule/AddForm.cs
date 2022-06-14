using AntiMyco.DataModels.Antimycotics;
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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
            using (AntimycoticsContext db = new())
            {
                var precursors = db.Precursors.ToList();
                foreach (var precursor in precursors)
                    comboBox1.Items.Add(precursor.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                AntimycoticsContext context = new();
                Antimycotic antimycotic = new()
                {
                    Name = textBox1.Text,
                    Smiles = @"CC2(C)CCCC(\C)=C2\C=C\C(\C)=C\C=C\C(\C)=C\C=C\C=C(/C)\C=C\C=C(/C)\C=C\C1=C(/C)",
                    Toxicity = 7.81m,
                    Properties = "{nr_ahr:false nr_ar:false, nr_ar_lbd:false, nr_aromatase:false, nr_er:false, nr_er_lbd:false, nr_ppar_gamma:false, sr_are:true, sr_atad5:false, sr_hse:true, sr_mmp:false, sr_p53:false}",
                    PrecursorId = comboBox1.SelectedIndex + 1
                };
                context.Antimycotics.Add(antimycotic);
                context.SaveChanges();
                MessageBox.Show("Вещество успешно добавлено!");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка при добавление вещества!");
            }
        }
    }
}
