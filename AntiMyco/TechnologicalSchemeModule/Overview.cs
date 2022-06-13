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
    public partial class Overview : Form
    {
        TechnologicalSchemeDBContext db;

        public Overview()
        {
            InitializeComponent();
            db = new TechnologicalSchemeDBContext();
            DisplaySchemes();
        }

        private void DisplaySchemes()
        {
            listBoxSchemes.Items.Clear();
            foreach (ProductionScheme sc in db.ProductionSchemes)
            {
                listBoxSchemes.Items.Add(sc.Name);
            }
        }

        private void buttonAddScheme_Click(object sender, EventArgs e)
        {
            ProductionScheme scheme = new ProductionScheme();
            SchemeEditor editor = new SchemeEditor(db, scheme, false);
            editor.ShowDialog();

            if (!string.IsNullOrEmpty(scheme.Name))
            {
                db.ProductionSchemes.Add(scheme);
                db.SaveChanges();
            }

            DisplaySchemes();
        }

        private void buttonEditScheme_Click(object sender, EventArgs e)
        {
            if (listBoxSchemes.SelectedItems.Count == 0)
                return;

            ProductionScheme scheme = (from s in db.ProductionSchemes.ToList() where s.Name == listBoxSchemes.SelectedItem.ToString() select s).Single();
            GetAllData(scheme);

            SchemeEditor editor = new SchemeEditor(db, scheme, true);
            editor.ShowDialog();
            db.SaveChanges();

            DisplaySchemes();
            
        }

        private void buttonDeleteScheme_Click(object sender, EventArgs e)
        {
            if (listBoxSchemes.SelectedItems.Count == 0)
                return;

            ProductionScheme scheme = (from s in db.ProductionSchemes.ToList() where s.Name == listBoxSchemes.SelectedItem.ToString() select s).Single();
            db.ProductionSchemes.Remove(scheme);
            db.SaveChanges();
            DisplaySchemes();
        }

        private void GetAllData(ProductionScheme scheme)
        {
            db.Entry(scheme).Collection(s => s.Stages).Load();
            foreach (var stage in scheme.Stages)
            {
                db.Entry(stage).Collection(s => s.MaterialBalances).Load();
                foreach (var balance in stage.MaterialBalances)
                {
                    db.Entry(balance).Reference(b => b.IdSubstanceNavigation).Load();
                    db.Entry(balance).Reference(b => b.IdClassNavigation).Load();
                }

                db.Entry(stage).Collection(s => s.Operations).Load();
                foreach (var op in stage.Operations)
                {
                    db.Entry(op).Collection(o => o.EquipmentInvolvedInOperations).Load();
                    foreach (var eq in op.EquipmentInvolvedInOperations)
                    {
                        db.Entry(eq).Reference(e => e.IdEquipmentNavigation).Load();
                        db.Entry(eq.IdEquipmentNavigation).Collection(e => e.EquipmentParameters).Load();
                        foreach (var par in eq.IdEquipmentNavigation.EquipmentParameters)
                        {
                            db.Entry(par).Reference(p => p.IdParameterNavigation).Load();
                        }
                    }

                    db.Entry(op).Collection(o => o.Actions).Load();
                    foreach (var act in op.Actions)
                    {
                        db.Entry(act).Collection(a => a.ParameterValues).Load();
                        foreach (var par in act.ParameterValues)
                        {
                            db.Entry(par).Reference(p => p.IdParameterNavigation).Load();
                        }
                    }
                }
            }
        }
    }
}
