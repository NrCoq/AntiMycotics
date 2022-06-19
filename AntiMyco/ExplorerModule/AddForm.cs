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
        string Smiles { get; set; }
        decimal Toxicity { get; set; }
        public AddForm(string smiles, decimal toxicity)
        {
            InitializeComponent();
            Smiles = smiles;
            Toxicity = toxicity;
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
                if (prop_tb.Text == "")
                {
                    MessageBox.Show("Введите свойства!");
                    return;
                }
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Выберите прекурсор!");
                    return;
                }


                AntimycoticsContext context = new();
                Antimycotic antimycotic = new()
                {
                    Name = textBox1.Text,
                    Smiles = @"CC2(C)CCCC(\C)=C2\C=C\C(\C)=C\C=C\C(\C)=C\C=C\C=C(/C)\C=C\C=C(/C)\C=C\C1=C(/C)",
                    Toxicity = 7.81m,
                    Properties = prop_tb.Text,
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
