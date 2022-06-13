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
    public partial class StageEditor : Form
    {
        Stage stage;
        TechnologicalSchemeDBContext db;

        public StageEditor(Stage stage,TechnologicalSchemeDBContext db, bool isExists)
        {
            InitializeComponent();
            this.stage = stage;
            this.db = db;

            if (isExists)
            {
                DisplayBalance();
                textBoxStageName.Text = stage.Name;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxStageName.Text))
            {
                MessageBox.Show("Введено некорректное название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CheckIfExists())
            {
                MessageBox.Show("В этой схеме стадия с таким наименованием уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            stage.Name = textBoxStageName.Text;

            Close();
        }

        private bool CheckIfExists()
        {
            #warning не забыть спросить
            //foreach(var s in stage.IdSchemeNavigation.Stages)
            //{
            //    if (s.Name == textBoxStageName.Text && textBoxStageName.Text != stage.Name)
            //        return true;
            //}
            return false;
        }

        private void DisplayBalance()
        {
            Substance substance;
            SubstanceClass substanceClass;
            dataGridViewBalance.Rows.Clear();
            foreach(var s in stage.MaterialBalances)
            {
                substance = s.IdSubstanceNavigation;
                substanceClass = s.IdClassNavigation;
                dataGridViewBalance.Rows.Add(substance.Name, substanceClass.Name, s.ChanfeG, s.ChangeMl);
            }
        }

        private void buttonAddSub_Click(object sender, EventArgs e)
        {
            MaterialBalance balance = new MaterialBalance();
            BalanceElementEdit edit = new BalanceElementEdit(balance, false, db);
            edit.ShowDialog();
            if (balance.IdSubstanceNavigation != null && balance.IdClassNavigation != null)
                stage.MaterialBalances.Add(balance);
            DisplayBalance();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            MaterialBalance balance = stage.MaterialBalances.ElementAt(dataGridViewBalance.SelectedRows[0].Index);
            BalanceElementEdit edit = new BalanceElementEdit(balance, true, db);
            edit.ShowDialog();
            DisplayBalance();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            MaterialBalance balance = stage.MaterialBalances.ElementAt(dataGridViewBalance.SelectedRows[0].Index);
            stage.MaterialBalances.Remove(balance);
            DisplayBalance();
        }
    }
}
