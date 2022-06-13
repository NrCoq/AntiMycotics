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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.addStage = new System.Windows.Forms.Button();
            this.EditStage = new System.Windows.Forms.Button();
            this.DeleteStage = new System.Windows.Forms.Button();
            this.StageUp = new System.Windows.Forms.Button();
            this.StageDown = new System.Windows.Forms.Button();
            this.listBoxStages = new System.Windows.Forms.ListBox();
            this.listBoxOperations = new System.Windows.Forms.ListBox();
            this.listBoxActions = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelSchemeName = new System.Windows.Forms.Label();
            this.textBoxSchemeName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.listBoxStages, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.listBoxOperations, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.listBoxActions, 2, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 59);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(800, 391);
            this.tableLayoutPanel.TabIndex = 0;
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 247);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 141);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // addStage
            // 
            this.addStage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addStage.Location = new System.Drawing.Point(3, 3);
            this.addStage.Name = "addStage";
            this.addStage.Size = new System.Drawing.Size(80, 64);
            this.addStage.TabIndex = 0;
            this.addStage.Text = "Добавить стадию";
            this.addStage.UseVisualStyleBackColor = true;
            this.addStage.Click += new System.EventHandler(this.addStage_Click);
            // 
            // EditStage
            // 
            this.EditStage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditStage.Location = new System.Drawing.Point(89, 3);
            this.EditStage.Name = "EditStage";
            this.EditStage.Size = new System.Drawing.Size(80, 64);
            this.EditStage.TabIndex = 1;
            this.EditStage.Text = "Редактировать";
            this.EditStage.UseVisualStyleBackColor = true;
            this.EditStage.Click += new System.EventHandler(this.EditStage_Click);
            // 
            // DeleteStage
            // 
            this.DeleteStage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteStage.Location = new System.Drawing.Point(175, 3);
            this.DeleteStage.Name = "DeleteStage";
            this.DeleteStage.Size = new System.Drawing.Size(82, 64);
            this.DeleteStage.TabIndex = 2;
            this.DeleteStage.Text = "Удалить";
            this.DeleteStage.UseVisualStyleBackColor = true;
            this.DeleteStage.Click += new System.EventHandler(this.DeleteStage_Click);
            // 
            // StageUp
            // 
            this.StageUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StageUp.Location = new System.Drawing.Point(3, 73);
            this.StageUp.Name = "StageUp";
            this.StageUp.Size = new System.Drawing.Size(80, 65);
            this.StageUp.TabIndex = 3;
            this.StageUp.Text = "Вверх";
            this.StageUp.UseVisualStyleBackColor = true;
            this.StageUp.Click += new System.EventHandler(this.StageUp_Click);
            // 
            // StageDown
            // 
            this.StageDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StageDown.Location = new System.Drawing.Point(175, 73);
            this.StageDown.Name = "StageDown";
            this.StageDown.Size = new System.Drawing.Size(82, 65);
            this.StageDown.TabIndex = 4;
            this.StageDown.Text = "Вниз";
            this.StageDown.UseVisualStyleBackColor = true;
            this.StageDown.Click += new System.EventHandler(this.StageDown_Click);
            // 
            // listBoxStages
            // 
            this.listBoxStages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxStages.FormattingEnabled = true;
            this.listBoxStages.ItemHeight = 15;
            this.listBoxStages.Location = new System.Drawing.Point(3, 3);
            this.listBoxStages.Name = "listBoxStages";
            this.listBoxStages.Size = new System.Drawing.Size(260, 238);
            this.listBoxStages.TabIndex = 4;
            // 
            // listBoxOperations
            // 
            this.listBoxOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxOperations.FormattingEnabled = true;
            this.listBoxOperations.ItemHeight = 15;
            this.listBoxOperations.Location = new System.Drawing.Point(269, 3);
            this.listBoxOperations.Name = "listBoxOperations";
            this.listBoxOperations.Size = new System.Drawing.Size(260, 238);
            this.listBoxOperations.TabIndex = 5;
            // 
            // listBoxActions
            // 
            this.listBoxActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxActions.FormattingEnabled = true;
            this.listBoxActions.ItemHeight = 15;
            this.listBoxActions.Location = new System.Drawing.Point(535, 3);
            this.listBoxActions.Name = "listBoxActions";
            this.listBoxActions.Size = new System.Drawing.Size(262, 238);
            this.listBoxActions.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
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
            // labelSchemeName
            // 
            this.labelSchemeName.AutoSize = true;
            this.labelSchemeName.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelSchemeName.Location = new System.Drawing.Point(33, 0);
            this.labelSchemeName.Name = "labelSchemeName";
            this.labelSchemeName.Size = new System.Drawing.Size(151, 29);
            this.labelSchemeName.TabIndex = 2;
            this.labelSchemeName.Text = "Название схемы синтеза -";
            // 
            // textBoxSchemeName
            // 
            this.textBoxSchemeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSchemeName.Location = new System.Drawing.Point(190, 3);
            this.textBoxSchemeName.Name = "textBoxSchemeName";
            this.textBoxSchemeName.Size = new System.Drawing.Size(607, 23);
            this.textBoxSchemeName.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.44498F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.55502F));
            this.tableLayoutPanel2.Controls.Add(this.textBoxSchemeName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelSchemeName, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(800, 29);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // SchemeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SchemeEditor";
            this.Text = "SchemeEditor";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
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
        private TableLayoutPanel tableLayoutPanel2;
        private ListBox listBoxStages;
        private ListBox listBoxOperations;
        private ListBox listBoxActions;
        private Button EditStage;
        private Button DeleteStage;
        private Button StageUp;
        private Button StageDown;
    }
}