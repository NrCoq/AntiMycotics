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
        TechnologicalSchemeDBContext db;
        ProductionScheme scheme;

        public SchemeEditor(ProductionScheme scheme)
        {
            InitializeComponent();
            db = new TechnologicalSchemeDBContext();
            this.scheme = scheme;
            GetAllData();
        }

        private void GetAllData()
        {
            db.Entry(scheme).Collection(s => s.StageLists).Load();

            foreach (var stageNav in db.StageLists)
            {
                db.Entry(stageNav).Reference(s => s.IdStageNavigation).Load();
                db.Entry(stageNav.IdStageNavigation).Collection(s => s.MaterialBalances).Load();
                foreach(var materialNav in stageNav.IdStageNavigation.MaterialBalances)
                {
                    db.Entry(materialNav).Reference(s => s.IdSubstanceNavigation).Load();
                }

                db.Entry(stageNav.IdStageNavigation).Collection(s => s.OperationLists).Load();
                foreach (var opNav in stageNav.IdStageNavigation.OperationLists)
                {
                    db.Entry(opNav).Reference(s => s.IdOperationNavigation).Load();

                    db.Entry(opNav.IdOperationNavigation).Collection(s => s.EquipmentInvolvedInOperations).Load();
                    foreach(var eqNav in opNav.IdOperationNavigation.EquipmentInvolvedInOperations)
                    {
                        db.Entry(eqNav).Reference(s => s.IdEquipmentNavigation).Load();
                        db.Entry(eqNav.IdEquipmentNavigation).Collection(s => s.EquipmentParameters).Load();
                        foreach(var parNav in eqNav.IdEquipmentNavigation.EquipmentParameters)
                        {
                            db.Entry(parNav).Reference(s => s.IdParameterNavigation).Load();
                        }
                    }

                    db.Entry(opNav.IdOperationNavigation).Collection(s => s.ActionLists).Load();
                    foreach(var actNav in opNav.IdOperationNavigation.ActionLists)
                    {
                        db.Entry(actNav).Reference(s => s.IdActionNavigation).Load();
                        db.Entry(actNav.IdActionNavigation).Collection(s => s.ParameterValues).Load();
                        foreach(var valNav in actNav.IdActionNavigation.ParameterValues)
                        {
                            db.Entry(valNav).Reference(s => s.IdParameterNavigation).Load();
                        }
                    }
                }
            }
        }
    }
}
