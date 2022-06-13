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
    public partial class SchemeEditor : Form
    {        
        bool isExists;
        
        TechnologicalSchemeDBContext db;
        ProductionScheme scheme;

        List<Operation> operations;
        List<DataModels.TechnologicalSchemeDataModel.Action> actions;

        public SchemeEditor(ProductionScheme scheme, bool isExists)
        {
            InitializeComponent();
            db = new TechnologicalSchemeDBContext();
            this.scheme = scheme;
            this.isExists = isExists;

            operations = new List<Operation>();
            actions = new List<DataModels.TechnologicalSchemeDataModel.Action>();

            if (isExists)
                GetAllData();
        }

        private void GetAllData()
        {
            
        }

        private void addStage_Click(object sender, EventArgs e)
        {
            Stage stage = new Stage();
            stage.IdSchemeNavigation = scheme;
            StageEditor editor = new StageEditor(stage, db, false);
            editor.ShowDialog();
            if (!String.IsNullOrEmpty(stage.Name))
            {
                stage.OrderInScheme = listBoxStages.Items.Count;
                scheme.Stages.Add(stage);
                DisplayStages();
            }
        }

        private void DisplayStages()
        {
            listBoxStages.Items.Clear();
            foreach(Stage s in scheme.Stages.OrderBy(b => b.OrderInScheme))
            {
                listBoxStages.Items.Add(s.Name);
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isExists)
            {
                if (String.IsNullOrEmpty(textBoxSchemeName.Text))
                {
                    MessageBox.Show("Введено некорректное название схемы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ifSchemeExists())
                {
                    MessageBox.Show("Схема с таким наименованием уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                scheme.Name = textBoxSchemeName.Text;
                db.SaveChanges();
                Close();
            }
            else
            {
                if (String.IsNullOrEmpty(textBoxSchemeName.Text))
                {
                    MessageBox.Show("Введено некорректное название схемы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ifSchemeExists())
                {
                    MessageBox.Show("Схема с таким наименованием уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                scheme.Name = textBoxSchemeName.Text;
                db.ProductionSchemes.Add(scheme);
                db.SaveChanges();
                Close();
            }
        }

        private bool ifSchemeExists()
        {
            foreach(ProductionScheme s in db.ProductionSchemes)
            {
                if (s.Name == textBoxSchemeName.Text)
                    return true;
            }
            return false;
        }

        private void EditStage_Click(object sender, EventArgs e)
        {
            if (listBoxStages.SelectedItems.Count == 0)
                return;
            Stage stage = (from s in scheme.Stages where s.OrderInScheme == listBoxStages.SelectedIndex select s).Single();
            StageEditor editor = new StageEditor(stage, db, true);
            editor.ShowDialog();

            DisplayStages();
        }

        private void DeleteStage_Click(object sender, EventArgs e)
        {
            if (listBoxStages.SelectedItems.Count == 0)
                return;
            Stage stage = (from s in scheme.Stages where s.OrderInScheme == listBoxStages.SelectedIndex select s).Single();
            scheme.Stages.Remove(stage);
            DisplayStages();
        }

        private void StageUp_Click(object sender, EventArgs e)
        {
            if (listBoxStages.SelectedItems.Count == 0)
                return;
            Stage stage = (from s in scheme.Stages where s.OrderInScheme == listBoxStages.SelectedIndex select s).Single();
            if (stage.OrderInScheme == 0)
                return;

            Stage swapStage = (from s in scheme.Stages where s.OrderInScheme == listBoxStages.SelectedIndex - 1 select s).Single();
            stage.OrderInScheme = stage.OrderInScheme - 1;
            swapStage.OrderInScheme = swapStage.OrderInScheme + 1;

            DisplayStages();
        }

        private void StageDown_Click(object sender, EventArgs e)
        {
            if (listBoxStages.SelectedItems.Count == 0)
                return;
            Stage stage = (from s in scheme.Stages where s.OrderInScheme == listBoxStages.SelectedIndex select s).Single();
            if (stage.OrderInScheme == scheme.Stages.Count - 1)
                return;

            Stage swapStage = (from s in scheme.Stages where s.OrderInScheme == listBoxStages.SelectedIndex + 1 select s).Single();
            stage.OrderInScheme = stage.OrderInScheme + 1;
            swapStage.OrderInScheme = swapStage.OrderInScheme - 1;

            DisplayStages();
        }
    }

}
