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
    public partial class OperationEditor : Form
    {
        Operation operation;
        TechnologicalSchemeDBContext db;
        List<Equipment> allEquipment;

        public OperationEditor(Operation operation, TechnologicalSchemeDBContext db, bool isExists, List<Equipment> allEquipment)
        {
            InitializeComponent();
            this.operation = operation;
            this.db = db;
            this.allEquipment = allEquipment;

            if (isExists)
            {
                FillDataGrid();
                textBoxName.Text = operation.Name;
            }
        }

        public void FillDataGrid()
        {
            dataGridView1.Rows.Clear();

            foreach(EquipmentInvolvedInOperation eq in operation.EquipmentInvolvedInOperations)
            {
                string characteristics = "";

                foreach (var par in eq.IdEquipmentNavigation.EquipmentParameters)
                {
                    characteristics += par.IdParameterNavigation.Name + " - " + par.Value + " " + par.IdParameterNavigation.Unit + Environment.NewLine;
                }

                if (eq.IdEquipmentNavigation.Macro != null)
                {
                    using (MemoryStream memstr = new MemoryStream(eq.IdEquipmentNavigation.Macro))
                    {
                        Image img = Image.FromStream(memstr);
                        dataGridView1.Rows.Add(eq.IdEquipmentNavigation.Id, eq.IdEquipmentNavigation.Name, characteristics, eq.NumberOfUnits, eq.IdEquipmentNavigation.Macro);
                    }
                }
                else
                {
                    dataGridView1.Rows.Add(eq.IdEquipmentNavigation.Id, eq.IdEquipmentNavigation.Name, characteristics, eq.NumberOfUnits);
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            EquipmentInvolvedInOperation eq = new EquipmentInvolvedInOperation();

            EquipmentElementEditor editor = new EquipmentElementEditor(db, eq, allEquipment);
            editor.ShowDialog();
            if(eq.IdEquipmentNavigation != null)
            {
                operation.EquipmentInvolvedInOperations.Add(eq);
            }

            FillDataGrid();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            EquipmentInvolvedInOperation eq = (from o in operation.EquipmentInvolvedInOperations where o.IdEquipmentNavigation.Id == (int)dataGridView1.SelectedRows[0].Cells[0].Value && o.NumberOfUnits == (int)dataGridView1.SelectedRows[0].Cells[3].Value select o).Single();
            operation.EquipmentInvolvedInOperations.Remove(eq);
            FillDataGrid();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text.Trim()))
                return;
            if (IfExsists())
            {
                MessageBox.Show("В этой стадии операция с таким наименованием уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            operation.Name = textBoxName.Text;
            Close();
        }

        private bool IfExsists()
        {
            foreach(Operation op in operation.IdStageNavigation.Operations)
            {
                if (op.Name == textBoxName.Text && textBoxName.Text != operation.Name)
                    return true;
            }
            return false;
        }
    }
}
