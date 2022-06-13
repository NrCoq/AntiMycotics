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
using Microsoft.EntityFrameworkCore;

namespace AntiMyco.TechnologicalSchemeModule
{
    public partial class SchemeEditor : Form
    {        
        TechnologicalSchemeDBContext db;
        ProductionScheme scheme;
        List<Equipment> allEquipment;

        Stage? curStage;
        Operation? curOperation;
        DataModels.TechnologicalSchemeDataModel.Action? curAction;

        public SchemeEditor(TechnologicalSchemeDBContext db, ProductionScheme scheme, bool isExists)
        {
            InitializeComponent();
            this.db = db;
            this.scheme = scheme;

            allEquipment = db.Equipment.Include(e => e.EquipmentParameters).ThenInclude(p => p.IdParameterNavigation).ToList();

            if (isExists)
            {
                textBoxSchemeName.Text = scheme.Name;
                //GetAllData();
                DisplayStages();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBoxSchemeName.Text.Trim()))
            {
                MessageBox.Show("Введено некорректное название схемы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ifSchemeExists())
            {
                MessageBox.Show("Схема с таким наименованием уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (scheme.Stages.Count == 0)
            {
                MessageBox.Show("Схема должна содержать хотябы 1 стадию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            scheme.Name = textBoxSchemeName.Text;
            Close();

        }

        private bool ifSchemeExists()
        {
            foreach (ProductionScheme s in db.ProductionSchemes)
            {
                if (s.Name == textBoxSchemeName.Text && textBoxSchemeName.Text != scheme.Name)
                    return true;
            }
            return false;
        }


        //ОБРАБОТКА СТАДИЙ
        
        private void SetCurStage()
        {
            if (listBoxStages.SelectedItems.Count == 0)
            {
                curStage = null;
                return;
            }
            curStage = (from s in scheme.Stages where s.OrderInScheme == listBoxStages.SelectedIndex select s).Single();
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
                OnStageAdd(stage);
            }
        }

        private void EditStage_Click(object sender, EventArgs e)
        {
            if (curStage == null)
                return;            
            StageEditor editor = new StageEditor(curStage, db, true);
            editor.ShowDialog();

            OnStageEdit();
        }

        private void DeleteStage_Click(object sender, EventArgs e)
        {
            if (curStage == null)
                return;            
            scheme.Stages.Remove(curStage);
            if(db.Stages.Contains(curStage))
                db.Stages.Remove(curStage);

            List<Stage> tmp = scheme.Stages.OrderBy(s => s.OrderInScheme).ToList();
            for (int i = curStage.OrderInScheme; i < tmp.Count; i++)
                tmp[i].OrderInScheme -= 1;

            OnStageDelete();
        }

        private void StageUp_Click(object sender, EventArgs e)
        {
            if (curStage == null)
                return;
            
            if (curStage.OrderInScheme == 0)
                return;

            Stage swapStage = (from s in scheme.Stages where s.OrderInScheme == listBoxStages.SelectedIndex - 1 select s).Single();
            curStage.OrderInScheme -= 1;
            swapStage.OrderInScheme += 1;

            OnStageUp();
        }

        private void StageDown_Click(object sender, EventArgs e)
        {
            if (curStage == null)
                return;
            
            if (curStage.OrderInScheme == scheme.Stages.Count - 1)
                return;

            Stage swapStage = (from s in scheme.Stages where s.OrderInScheme == listBoxStages.SelectedIndex + 1 select s).Single();
            curStage.OrderInScheme += 1;
            swapStage.OrderInScheme -= 1;

            OnStageDown();
        }



        //ОБРАБОТКА ОПЕРАЦИЙ

        private void SetCurOperation()
        {
            if(listBoxOperations.SelectedItems.Count == 0)
            {
                curOperation = null;
                return;
            }
            curOperation = (from o in curStage.Operations where o.OrderInStage == listBoxOperations.SelectedIndex select o).Single();
        }

        private void AddOperation_Click(object sender, EventArgs e)
        {
            if (curStage == null)
                return;

            Operation operation = new Operation();
            operation.IdStageNavigation = curStage;

            OperationEditor editor = new OperationEditor(operation, db, false, allEquipment);
            editor.ShowDialog();

            if (!string.IsNullOrEmpty(operation.Name))
            {
                operation.OrderInStage = curStage.Operations.Count;
                curStage.Operations.Add(operation);
                OnOperationAdd(operation);
            }
        }

        private void EditOperation_Click(object sender, EventArgs e)
        {
            if (curOperation == null)
                return;

            OperationEditor editor = new OperationEditor(curOperation, db, true, allEquipment);
            editor.ShowDialog();

            OnOperationEdit();
        }

        private void DeleteOperation_Click(object sender, EventArgs e)
        {
            if (curOperation == null)
                return;

            curStage.Operations.Remove(curOperation);
            if (db.Operations.Contains(curOperation))
                db.Operations.Remove(curOperation);

            List<Operation> tmp = curStage.Operations.OrderBy(s => s.OrderInStage).ToList();
            for (int i = curOperation.OrderInStage; i < tmp.Count; i++)
                tmp[i].OrderInStage -= 1;

            OnOperationDelete();
        }

        private void OperationUp_Click(object sender, EventArgs e)
        {
            if (listBoxOperations.SelectedItems.Count == 0)
                return;
            Operation op = (from s in curStage.Operations where s.OrderInStage == listBoxOperations.SelectedIndex select s).Single();
            if (op.OrderInStage == 0)
                return;

            Operation swapOp = (from s in curStage.Operations where s.OrderInStage == listBoxOperations.SelectedIndex - 1 select s).Single();
            op.OrderInStage -= 1;
            swapOp.OrderInStage += 1;

            OnOperationUp();
        }

        private void OperationDown_Click(object sender, EventArgs e)
        {
            if (listBoxOperations.SelectedItems.Count == 0)
                return;

            Operation op = (from s in curStage.Operations where s.OrderInStage == listBoxOperations.SelectedIndex select s).Single();
            if (op.OrderInStage == curStage.Operations.Count - 1)
                return;

            Operation swapOp = (from s in curStage.Operations where s.OrderInStage == listBoxOperations.SelectedIndex + 1 select s).Single();
            op.OrderInStage += 1;
            swapOp.OrderInStage -= 1;

            OnOperationDown();
        }


        //ОБРАБОТКА РАБОТ

        private void SetCurAction()
        {
            if (listBoxActions.SelectedItems.Count == 0)
            {
                curAction = null;
                return;
            }
            curAction = (from a in curOperation.Actions where a.OrderInOperation == listBoxActions.SelectedIndex select a).Single();
        }

        private void AddAction_Click(object sender, EventArgs e)
        {
            if (curOperation == null)
                return;

            DataModels.TechnologicalSchemeDataModel.Action action = new();
            action.OrderNumNavigation = curOperation;

            ActionEdit editor = new(db, action, false);
            editor.ShowDialog();

            if (!string.IsNullOrEmpty(action.Name))
            {
                action.OrderInOperation = curOperation.Actions.Count;
                curOperation.Actions.Add(action);
                OnActionAdd(action);
            }
        }

        private void EditAction_Click(object sender, EventArgs e)
        {
            if (curAction == null)
                return;

            ActionEdit editor = new ActionEdit(db, curAction, true);
            editor.ShowDialog();

            OnActionEdit();
        }

        private void DeleteAction_Click(object sender, EventArgs e)
        {
            if (curAction == null)
                return;

            curOperation.Actions.Remove(curAction);
            if (db.Actions.Contains(curAction))
                db.Actions.Remove(curAction);

            List<DataModels.TechnologicalSchemeDataModel.Action> tmp = curOperation.Actions.OrderBy(s => s.OrderInOperation).ToList();
            for (int i = curAction.OrderInOperation; i < tmp.Count; i++)
                tmp[i].OrderInOperation -= 1;

            OnActionDelete();
        }

        private void ActionUp_Click(object sender, EventArgs e)
        {
            if (listBoxActions.SelectedItems.Count == 0)
                return;
            DataModels.TechnologicalSchemeDataModel.Action act = (from a in curOperation.Actions where a.OrderInOperation == listBoxActions.SelectedIndex select a).Single();
            if (act.OrderInOperation == 0)
                return;

            DataModels.TechnologicalSchemeDataModel.Action swapAct = (from a in curOperation.Actions where a.OrderInOperation == listBoxActions.SelectedIndex - 1 select a).Single();
            act.OrderInOperation -=  1;
            swapAct.OrderInOperation += 1;

            OnActionUp();
        }

        private void ActionDown_Click(object sender, EventArgs e)
        {
            if (listBoxActions.SelectedItems.Count == 0)
                return;

            DataModels.TechnologicalSchemeDataModel.Action act = (from a in curOperation.Actions where a.OrderInOperation == listBoxActions.SelectedIndex select a).Single();
            if (act.OrderInOperation == curOperation.Actions.Count - 1)
                return;

            DataModels.TechnologicalSchemeDataModel.Action swapAct = (from a in curOperation.Actions where a.OrderInOperation == listBoxActions.SelectedIndex + 1 select a).Single();
            act.OrderInOperation += 1;
            swapAct.OrderInOperation -= 1;

            OnActionDown();
        }

        //ОТОБРАЖЕНИЕ СПИСКОВ
        private void DisplayStages()
        {
            listBoxActions.Items.Clear();
            listBoxOperations.Items.Clear();
            listBoxStages.Items.Clear();

            curAction = null;
            curOperation = null;
            curStage = null;

            foreach (Stage s in scheme.Stages.OrderBy(b => b.OrderInScheme))
            {
                listBoxStages.Items.Add(s.Name);
            }
        }

        private void DisplayOperations()
        {
            listBoxActions.Items.Clear();
            listBoxOperations.Items.Clear();

            curAction = null;
            curOperation = null;

            foreach (var op in curStage.Operations.OrderBy(o => o.OrderInStage))
            {
                listBoxOperations.Items.Add(op.Name);
            }
        }

        private void DisplayActions()
        {
            listBoxActions.Items.Clear();

            curAction = null;

            foreach(var act in curOperation.Actions.OrderBy(a => a.OrderInOperation))
            {
                listBoxActions.Items.Add(act.Name);
            }
        }


        private void OnStageAdd(Stage newStage)
        {
            listBoxStages.Items.Add(newStage.Name);
        }

        private void OnStageEdit()
        {
            listBoxStages.Items[curStage.OrderInScheme] = curStage.Name;
        }

        private void OnStageDelete()
        {
            DisplayStages();
        }

        private void OnStageUp()
        {
            foreach(Stage s in scheme.Stages.OrderBy(o => o.OrderInScheme))
                listBoxStages.Items[s.OrderInScheme] = s.Name;
            listBoxStages.SelectedIndex -= 1;
        }

        private void OnStageDown()
        {
            foreach (Stage s in scheme.Stages.OrderBy(o => o.OrderInScheme))
                listBoxStages.Items[s.OrderInScheme] = s.Name;
            listBoxStages.SelectedIndex += 1;
        }

        private void listBoxStages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxStages.SelectedIndex == -1)
                return;

            SetCurStage();
            DisplayOperations();
        }


        private void OnOperationAdd(Operation newOperation)
        {
            listBoxOperations.Items.Add(newOperation.Name);
        }

        private void OnOperationEdit()
        {
            listBoxOperations.Items[curOperation.OrderInStage] = curOperation.Name;
        }

        private void OnOperationDelete()
        {
            DisplayOperations();
        }

        private void OnOperationUp()
        {
            foreach (Operation op in curStage.Operations.OrderBy(o => o.OrderInStage))
                listBoxOperations.Items[op.OrderInStage] = op.Name;
            listBoxOperations.SelectedIndex -= 1;
        }

        private void OnOperationDown()
        {
            foreach (Operation op in curStage.Operations.OrderBy(o => o.OrderInStage))
                listBoxOperations.Items[op.OrderInStage] = op.Name;
            listBoxOperations.SelectedIndex += 1;
        }

        private void listBoxOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxOperations.SelectedIndex == -1)
                return;

            SetCurOperation();
            DisplayActions();
        }



        private void OnActionAdd(DataModels.TechnologicalSchemeDataModel.Action newAction)
        {
            listBoxActions.Items.Add(newAction.Name);
        }

        private void OnActionEdit()
        {
            listBoxActions.Items[curAction.OrderInOperation] = curAction.Name;
        }

        private void OnActionDelete()
        {
            DisplayActions();
        }

        private void OnActionUp()
        {
            foreach (DataModels.TechnologicalSchemeDataModel.Action act in curOperation.Actions.OrderBy(o => o.OrderInOperation))
                listBoxActions.Items[act.OrderInOperation] = act.Name;
            listBoxActions.SelectedIndex -= 1;
        }

        private void OnActionDown()
        {
            foreach (DataModels.TechnologicalSchemeDataModel.Action act in curOperation.Actions.OrderBy(o => o.OrderInOperation))
                listBoxActions.Items[act.OrderInOperation] = act.Name;
            listBoxActions.SelectedIndex += 1;
        }

        private void listBoxActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxActions.SelectedIndex == -1)
                return;

            SetCurAction();
        }
    }

}
