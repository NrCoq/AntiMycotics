namespace AntiMyco.TechnologicalSchemeModule
{
    partial class SchemeEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxStages = new System.Windows.Forms.ListBox();
            this.listBoxOperations = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.AddOperation = new System.Windows.Forms.Button();
            this.EditOperation = new System.Windows.Forms.Button();
            this.DeleteOperation = new System.Windows.Forms.Button();
            this.OperationUp = new System.Windows.Forms.Button();
            this.OperationDown = new System.Windows.Forms.Button();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.AddAction = new System.Windows.Forms.Button();
            this.EditAction = new System.Windows.Forms.Button();
            this.DeleteAction = new System.Windows.Forms.Button();
            this.ActionUp = new System.Windows.Forms.Button();
            this.ActionDown = new System.Windows.Forms.Button();
            this.listBoxActions = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.addStage = new System.Windows.Forms.Button();
            this.EditStage = new System.Windows.Forms.Button();
            this.DeleteStage = new System.Windows.Forms.Button();
            this.StageUp = new System.Windows.Forms.Button();
            this.StageDown = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.визульноеАпредставлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelSchemeName = new System.Windows.Forms.Label();
            this.textBoxSchemeName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel.Controls.Add(this.listBoxStages, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.listBoxOperations, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel9, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.listBoxActions, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 35);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1271, 384);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // listBoxStages
            // 
            this.listBoxStages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxStages.FormattingEnabled = true;
            this.listBoxStages.ItemHeight = 15;
            this.listBoxStages.Location = new System.Drawing.Point(3, 3);
            this.listBoxStages.Name = "listBoxStages";
            this.listBoxStages.Size = new System.Drawing.Size(417, 234);
            this.listBoxStages.TabIndex = 4;
            this.listBoxStages.SelectedIndexChanged += new System.EventHandler(this.listBoxStages_SelectedIndexChanged);
            // 
            // listBoxOperations
            // 
            this.listBoxOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxOperations.FormattingEnabled = true;
            this.listBoxOperations.HorizontalScrollbar = true;
            this.listBoxOperations.ItemHeight = 15;
            this.listBoxOperations.Location = new System.Drawing.Point(426, 3);
            this.listBoxOperations.Name = "listBoxOperations";
            this.listBoxOperations.Size = new System.Drawing.Size(417, 234);
            this.listBoxOperations.TabIndex = 5;
            this.listBoxOperations.SelectedIndexChanged += new System.EventHandler(this.listBoxOperations_SelectedIndexChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.AddOperation, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.EditOperation, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.DeleteOperation, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.OperationUp, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.OperationDown, 2, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(426, 243);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(417, 138);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // AddOperation
            // 
            this.AddOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddOperation.Location = new System.Drawing.Point(3, 3);
            this.AddOperation.Name = "AddOperation";
            this.AddOperation.Size = new System.Drawing.Size(133, 63);
            this.AddOperation.TabIndex = 0;
            this.AddOperation.Text = "Добавить операцию";
            this.AddOperation.UseVisualStyleBackColor = true;
            this.AddOperation.Click += new System.EventHandler(this.AddOperation_Click);
            // 
            // EditOperation
            // 
            this.EditOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditOperation.Location = new System.Drawing.Point(142, 3);
            this.EditOperation.Name = "EditOperation";
            this.EditOperation.Size = new System.Drawing.Size(133, 63);
            this.EditOperation.TabIndex = 1;
            this.EditOperation.Text = "Редактировать";
            this.EditOperation.UseVisualStyleBackColor = true;
            this.EditOperation.Click += new System.EventHandler(this.EditOperation_Click);
            // 
            // DeleteOperation
            // 
            this.DeleteOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteOperation.Location = new System.Drawing.Point(281, 3);
            this.DeleteOperation.Name = "DeleteOperation";
            this.DeleteOperation.Size = new System.Drawing.Size(133, 63);
            this.DeleteOperation.TabIndex = 2;
            this.DeleteOperation.Text = "Удалить";
            this.DeleteOperation.UseVisualStyleBackColor = true;
            this.DeleteOperation.Click += new System.EventHandler(this.DeleteOperation_Click);
            // 
            // OperationUp
            // 
            this.OperationUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OperationUp.Location = new System.Drawing.Point(3, 72);
            this.OperationUp.Name = "OperationUp";
            this.OperationUp.Size = new System.Drawing.Size(133, 63);
            this.OperationUp.TabIndex = 3;
            this.OperationUp.Text = "Вверх";
            this.OperationUp.UseVisualStyleBackColor = true;
            this.OperationUp.Click += new System.EventHandler(this.OperationUp_Click);
            // 
            // OperationDown
            // 
            this.OperationDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OperationDown.Location = new System.Drawing.Point(281, 72);
            this.OperationDown.Name = "OperationDown";
            this.OperationDown.Size = new System.Drawing.Size(133, 63);
            this.OperationDown.TabIndex = 4;
            this.OperationDown.Text = "Вниз";
            this.OperationDown.UseVisualStyleBackColor = true;
            this.OperationDown.Click += new System.EventHandler(this.OperationDown_Click);
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel9.Controls.Add(this.AddAction, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.EditAction, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.DeleteAction, 2, 0);
            this.tableLayoutPanel9.Controls.Add(this.ActionUp, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.ActionDown, 2, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(849, 243);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(419, 138);
            this.tableLayoutPanel9.TabIndex = 8;
            // 
            // AddAction
            // 
            this.AddAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddAction.Location = new System.Drawing.Point(3, 3);
            this.AddAction.Name = "AddAction";
            this.AddAction.Size = new System.Drawing.Size(133, 63);
            this.AddAction.TabIndex = 0;
            this.AddAction.Text = "Добавить работу";
            this.AddAction.UseVisualStyleBackColor = true;
            this.AddAction.Click += new System.EventHandler(this.AddAction_Click);
            // 
            // EditAction
            // 
            this.EditAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditAction.Location = new System.Drawing.Point(142, 3);
            this.EditAction.Name = "EditAction";
            this.EditAction.Size = new System.Drawing.Size(133, 63);
            this.EditAction.TabIndex = 1;
            this.EditAction.Text = "Редактировать";
            this.EditAction.UseVisualStyleBackColor = true;
            this.EditAction.Click += new System.EventHandler(this.EditAction_Click);
            // 
            // DeleteAction
            // 
            this.DeleteAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteAction.Location = new System.Drawing.Point(281, 3);
            this.DeleteAction.Name = "DeleteAction";
            this.DeleteAction.Size = new System.Drawing.Size(135, 63);
            this.DeleteAction.TabIndex = 2;
            this.DeleteAction.Text = "Удалить";
            this.DeleteAction.UseVisualStyleBackColor = true;
            this.DeleteAction.Click += new System.EventHandler(this.DeleteAction_Click);
            // 
            // ActionUp
            // 
            this.ActionUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActionUp.Location = new System.Drawing.Point(3, 72);
            this.ActionUp.Name = "ActionUp";
            this.ActionUp.Size = new System.Drawing.Size(133, 63);
            this.ActionUp.TabIndex = 3;
            this.ActionUp.Text = "Вверх";
            this.ActionUp.UseVisualStyleBackColor = true;
            this.ActionUp.Click += new System.EventHandler(this.ActionUp_Click);
            // 
            // ActionDown
            // 
            this.ActionDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActionDown.Location = new System.Drawing.Point(281, 72);
            this.ActionDown.Name = "ActionDown";
            this.ActionDown.Size = new System.Drawing.Size(135, 63);
            this.ActionDown.TabIndex = 4;
            this.ActionDown.Text = "Вниз";
            this.ActionDown.UseVisualStyleBackColor = true;
            this.ActionDown.Click += new System.EventHandler(this.ActionDown_Click);
            // 
            // listBoxActions
            // 
            this.listBoxActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxActions.FormattingEnabled = true;
            this.listBoxActions.ItemHeight = 15;
            this.listBoxActions.Location = new System.Drawing.Point(849, 3);
            this.listBoxActions.Name = "listBoxActions";
            this.listBoxActions.Size = new System.Drawing.Size(419, 234);
            this.listBoxActions.TabIndex = 6;
            this.listBoxActions.SelectedIndexChanged += new System.EventHandler(this.listBoxActions_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.addStage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.EditStage, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.DeleteStage, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.StageUp, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.StageDown, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 243);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(417, 138);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // addStage
            // 
            this.addStage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addStage.Location = new System.Drawing.Point(3, 3);
            this.addStage.Name = "addStage";
            this.addStage.Size = new System.Drawing.Size(133, 63);
            this.addStage.TabIndex = 0;
            this.addStage.Text = "Добавить стадию";
            this.addStage.UseVisualStyleBackColor = true;
            this.addStage.Click += new System.EventHandler(this.addStage_Click);
            // 
            // EditStage
            // 
            this.EditStage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditStage.Location = new System.Drawing.Point(142, 3);
            this.EditStage.Name = "EditStage";
            this.EditStage.Size = new System.Drawing.Size(133, 63);
            this.EditStage.TabIndex = 1;
            this.EditStage.Text = "Редактировать";
            this.EditStage.UseVisualStyleBackColor = true;
            this.EditStage.Click += new System.EventHandler(this.EditStage_Click);
            // 
            // DeleteStage
            // 
            this.DeleteStage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteStage.Location = new System.Drawing.Point(281, 3);
            this.DeleteStage.Name = "DeleteStage";
            this.DeleteStage.Size = new System.Drawing.Size(133, 63);
            this.DeleteStage.TabIndex = 2;
            this.DeleteStage.Text = "Удалить";
            this.DeleteStage.UseVisualStyleBackColor = true;
            this.DeleteStage.Click += new System.EventHandler(this.DeleteStage_Click);
            // 
            // StageUp
            // 
            this.StageUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StageUp.Location = new System.Drawing.Point(3, 72);
            this.StageUp.Name = "StageUp";
            this.StageUp.Size = new System.Drawing.Size(133, 63);
            this.StageUp.TabIndex = 3;
            this.StageUp.Text = "Вверх";
            this.StageUp.UseVisualStyleBackColor = true;
            this.StageUp.Click += new System.EventHandler(this.StageUp_Click);
            // 
            // StageDown
            // 
            this.StageDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StageDown.Location = new System.Drawing.Point(281, 72);
            this.StageDown.Name = "StageDown";
            this.StageDown.Size = new System.Drawing.Size(133, 63);
            this.StageDown.TabIndex = 4;
            this.StageDown.Text = "Вниз";
            this.StageDown.UseVisualStyleBackColor = true;
            this.StageDown.Click += new System.EventHandler(this.StageDown_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.визульноеАпредставлениеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1277, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.сохранитьToolStripMenuItem.Text = "Сохранить и выйти";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // визульноеАпредставлениеToolStripMenuItem
            // 
            this.визульноеАпредставлениеToolStripMenuItem.Name = "визульноеАпредставлениеToolStripMenuItem";
            this.визульноеАпредставлениеToolStripMenuItem.Size = new System.Drawing.Size(162, 20);
            this.визульноеАпредставлениеToolStripMenuItem.Text = "Визульное представление";
            this.визульноеАпредставлениеToolStripMenuItem.Click += new System.EventHandler(this.визульноеАпредставлениеToolStripMenuItem_Click);
            // 
            // labelSchemeName
            // 
            this.labelSchemeName.AutoSize = true;
            this.labelSchemeName.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelSchemeName.Location = new System.Drawing.Point(5, 0);
            this.labelSchemeName.Name = "labelSchemeName";
            this.labelSchemeName.Size = new System.Drawing.Size(151, 26);
            this.labelSchemeName.TabIndex = 2;
            this.labelSchemeName.Text = "Название схемы синтеза -";
            // 
            // textBoxSchemeName
            // 
            this.textBoxSchemeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSchemeName.Location = new System.Drawing.Point(162, 3);
            this.textBoxSchemeName.Name = "textBoxSchemeName";
            this.textBoxSchemeName.Size = new System.Drawing.Size(1106, 23);
            this.textBoxSchemeName.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 94);
            this.button1.TabIndex = 0;
            this.button1.Text = "Добавить стадию";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(69, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 94);
            this.button2.TabIndex = 1;
            this.button2.Text = "Редактировать";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.582938F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.41706F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1277, 422);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.50984F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.49017F));
            this.tableLayoutPanel5.Controls.Add(this.labelSchemeName, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.textBoxSchemeName, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1271, 26);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.Controls.Add(this.button3, 0, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 94);
            this.button3.TabIndex = 0;
            this.button3.Text = "Добавить операцию";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(69, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 94);
            this.button4.TabIndex = 1;
            this.button4.Text = "Редактировать";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.Controls.Add(this.button5, 0, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Location = new System.Drawing.Point(3, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(60, 94);
            this.button5.TabIndex = 0;
            this.button5.Text = "Добавить операцию";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Location = new System.Drawing.Point(69, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(60, 94);
            this.button6.TabIndex = 1;
            this.button6.Text = "Редактировать";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.Controls.Add(this.button7, 0, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button7.Location = new System.Drawing.Point(3, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(60, 94);
            this.button7.TabIndex = 0;
            this.button7.Text = "Добавить операцию";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.Location = new System.Drawing.Point(69, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(60, 94);
            this.button8.TabIndex = 1;
            this.button8.Text = "Редактировать";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // SchemeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 446);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SchemeEditor";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private TableLayoutPanel tableLayoutPanel1;
        private Button addStage;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private Label labelSchemeName;
        private TextBox textBoxSchemeName;
        private ListBox listBoxStages;
        private ListBox listBoxOperations;
        private ListBox listBoxActions;
        private Button EditStage;
        private Button DeleteStage;
        private Button StageUp;
        private Button StageDown;
        private TableLayoutPanel tableLayoutPanel4;
        private Button AddOperation;
        private Button EditOperation;
        private Button DeleteOperation;
        private Button OperationUp;
        private Button OperationDown;
        private TableLayoutPanel tableLayoutPanel3;
        private Button button1;
        private Button button2;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel9;
        private Button AddAction;
        private Button EditAction;
        private Button DeleteAction;
        private Button ActionUp;
        private Button ActionDown;
        private TableLayoutPanel tableLayoutPanel6;
        private Button button3;
        private Button button4;
        private TableLayoutPanel tableLayoutPanel7;
        private Button button5;
        private Button button6;
        private TableLayoutPanel tableLayoutPanel8;
        private Button button7;
        private Button button8;
        private ToolStripMenuItem визульноеАпредставлениеToolStripMenuItem;
    }
}