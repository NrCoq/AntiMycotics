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
    public partial class BalanceElementEdit : Form
    {
        MaterialBalance balance;
        bool isExists;
        TechnologicalSchemeDBContext db;

        public BalanceElementEdit(MaterialBalance balance, bool isExists, TechnologicalSchemeDBContext db)
        {
            InitializeComponent();
            this.balance = balance;
            this.isExists = isExists;
            this.db = db;

            FillComboBox();
            if (isExists)
                DisplayInfo();
        }

        private void FillComboBox()
        {
            foreach (var s in db.Substances)
                comboBoxSub.Items.Add(s.Name);

            foreach (var s in db.SubstanceClasses)
                comboBoxClasses.Items.Add(s.Name);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            float G, Ml;
            if(comboBoxClasses.SelectedIndex == -1 || comboBoxSub.SelectedIndex == -1)
            {
                MessageBox.Show("Введены некорректные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!string.IsNullOrEmpty(textBoxG.Text))
            {
                if (!float.TryParse(textBoxG.Text, out G))
                {
                    MessageBox.Show("Введены некорректные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    balance.ChanfeG = G;
                }
            }
            if (!string.IsNullOrEmpty(textBoxMl.Text))
            {
                if (!float.TryParse(textBoxMl.Text, out Ml))
                {
                    MessageBox.Show("Введены некорректные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    balance.ChangeMl = Ml;
                }
            }

            Substance sub = (from s in db.Substances.ToList() where s.Name == comboBoxSub.Text select s).Single();
            SubstanceClass subClass = db.SubstanceClasses.Find(comboBoxClasses.SelectedIndex + 1);

            balance.IdSubstanceNavigation = sub;
            balance.IdClassNavigation = subClass;
            Close();
        }

        private void DisplayInfo()
        {
            comboBoxSub.SelectedIndex = comboBoxSub.FindStringExact(balance.IdSubstanceNavigation.Name);
            comboBoxClasses.SelectedIndex = comboBoxClasses.FindStringExact(balance.IdClassNavigation.Name);
            textBoxG.Text = balance.ChanfeG.ToString();
            textBoxMl.Text = balance.ChangeMl.ToString();
        }
    }
}

