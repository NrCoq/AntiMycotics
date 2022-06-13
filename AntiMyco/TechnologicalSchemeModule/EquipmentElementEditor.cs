using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntiMyco.DataModels.TechnologicalSchemeDataModel;

namespace AntiMyco.TechnologicalSchemeModule
{
    public partial class EquipmentElementEditor : Form
    {
        EquipmentInvolvedInOperation involv;
        TechnologicalSchemeDBContext db;

        public EquipmentElementEditor(TechnologicalSchemeDBContext db, EquipmentInvolvedInOperation involv, List<Equipment> allEquipment)
        {
            InitializeComponent();

            this.db = db;
            this.involv = involv;

            foreach (Equipment eq in allEquipment)
            {
                string characteristics = "";

                foreach (var par in eq.EquipmentParameters)
                {
                    characteristics += par.IdParameterNavigation.Name + " - " + par.Value + " " + par.IdParameterNavigation.Unit + Environment.NewLine;
                }

                if (eq.Macro != null)
                {
                    using (MemoryStream memstr = new MemoryStream(eq.Macro))
                    {
                        Image img = Image.FromStream(memstr);
                        dataGridView1.Rows.Add(eq.Id, eq.Name, characteristics, img);
                    }
                }
                else
                {
                    dataGridView1.Rows.Add(eq.Id, eq.Name, characteristics);
                }
            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number;
            if(!int.TryParse(textBox1.Text, out number) || dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            Equipment eq = (from i in db.Equipment where i.Id == int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()) select i).Single();
            involv.IdEquipmentNavigation = eq;
            involv.NumberOfUnits = number;
            Close();
        }
    }
}
