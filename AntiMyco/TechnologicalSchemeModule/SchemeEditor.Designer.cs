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
            this.listViewStages = new System.Windows.Forms.ListView();
            this.listViewOperations = new System.Windows.Forms.ListView();
            this.listViewActions = new System.Windows.Forms.ListView();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel.Controls.Add(this.listViewStages, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.listViewOperations, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.listViewActions, 2, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // listViewStages
            // 
            this.listViewStages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewStages.Location = new System.Drawing.Point(3, 3);
            this.listViewStages.Name = "listViewStages";
            this.listViewStages.Size = new System.Drawing.Size(260, 275);
            this.listViewStages.TabIndex = 0;
            this.listViewStages.UseCompatibleStateImageBehavior = false;
            // 
            // listViewOperations
            // 
            this.listViewOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewOperations.Location = new System.Drawing.Point(269, 3);
            this.listViewOperations.Name = "listViewOperations";
            this.listViewOperations.Size = new System.Drawing.Size(260, 275);
            this.listViewOperations.TabIndex = 1;
            this.listViewOperations.UseCompatibleStateImageBehavior = false;
            // 
            // listViewActions
            // 
            this.listViewActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewActions.Location = new System.Drawing.Point(535, 3);
            this.listViewActions.Name = "listViewActions";
            this.listViewActions.Size = new System.Drawing.Size(262, 275);
            this.listViewActions.TabIndex = 2;
            this.listViewActions.UseCompatibleStateImageBehavior = false;
            // 
            // SchemeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "SchemeEditor";
            this.Text = "SchemeEditor";
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private ListView listViewStages;
        private ListView listViewOperations;
        private ListView listViewActions;
    }
}