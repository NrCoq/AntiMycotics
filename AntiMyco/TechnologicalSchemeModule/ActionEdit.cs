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
    public partial class ActionEdit : Form
    {
        TechnologicalSchemeDBContext db;
        DataModels.TechnologicalSchemeDataModel.Action action;

        public ActionEdit(TechnologicalSchemeDBContext db, DataModels.TechnologicalSchemeDataModel.Action action, bool isExists)
        {
            InitializeComponent();
            this.db = db;
            this.action = action;

            if (isExists)
            {
                FillDataGrid();
                textBoxName.Text = action.Name;
            }
        }

        private void FillDataGrid()
        {
            dataGridView1.Rows.Clear();
            foreach(var val in action.ParameterValues)
            {
                dataGridView1.Rows.Add(val.IdParameterNavigation.Id, val.IdParameterNavigation.Name, val.MaxValue, val.MinValue);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            tableLayoutPanel5.Visible = true;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            tableLayoutPanel5.Visible = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxParamName.Clear();
            textBoxMin.Clear();
            textBoxMax.Clear();
            tableLayoutPanel5.Visible = false;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            float min, max;
            if (string.IsNullOrEmpty(textBoxParamName.Text))
                return;
            if (!float.TryParse(textBoxMin.Text, out min))
                return;
            if (!float.TryParse(textBoxMax.Text, out max))
                return;

            ParameterValue value = new ParameterValue();

            if (!string.IsNullOrEmpty(textBoxMin.Text))
            {
                if (!float.TryParse(textBoxMin.Text, out min))
                {
                    MessageBox.Show("Введены некорректные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    value.MinValue = min;
                }

                if (!float.TryParse(textBoxMax.Text, out max))
                {
                    MessageBox.Show("Введены некорректные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    value.MaxValue = max;
                }
            }

            ProcessParameter parameter = (from p in db.ProcessParameters.ToList() where p.Name == textBoxParamName.Text select p).SingleOrDefault();
            if (parameter == null)
            {
                parameter = new ProcessParameter();
                parameter.Name = textBoxParamName.Text;
                db.ProcessParameters.Add(parameter);
            }

            value.IdParameterNavigation = parameter;
            value.IdActionNavigation = action;
            action.ParameterValues.Add(value);

            tableLayoutPanel5.Visible = false;
            FillDataGrid();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Введено некорректное название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CheckIfExists())
            {
                MessageBox.Show("В этой операции работа с таким наименованием уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            action.Name = textBoxName.Text;

            Close();
        }

        private bool CheckIfExists()
        {
            foreach (var a in action.OrderNumNavigation.Actions)
            {
                if (a.Name == textBoxName.Text && textBoxName.Text != action.Name)
                    return true;
            }
            return false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            ParameterValue value = action.ParameterValues.ElementAt(dataGridView1.SelectedRows[0].Index);
            action.ParameterValues.Remove(value);
            FillDataGrid();
        }
    }
}
