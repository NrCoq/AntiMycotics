namespace AntiMyco.TechnologicalSchemeModule
{
    partial class Overview
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDeleteScheme = new System.Windows.Forms.Button();
            this.buttonEditScheme = new System.Windows.Forms.Button();
            this.buttonAddScheme = new System.Windows.Forms.Button();
            this.listBoxSchemes = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listBoxSchemes, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.66666F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.buttonDeleteScheme, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonEditScheme, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonAddScheme, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 402);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 45);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // buttonDeleteScheme
            // 
            this.buttonDeleteScheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeleteScheme.Location = new System.Drawing.Point(531, 3);
            this.buttonDeleteScheme.Name = "buttonDeleteScheme";
            this.buttonDeleteScheme.Size = new System.Drawing.Size(260, 39);
            this.buttonDeleteScheme.TabIndex = 2;
            this.buttonDeleteScheme.Text = "Удалить";
            this.buttonDeleteScheme.UseVisualStyleBackColor = true;
            this.buttonDeleteScheme.Click += new System.EventHandler(this.buttonDeleteScheme_Click);
            // 
            // buttonEditScheme
            // 
            this.buttonEditScheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEditScheme.Location = new System.Drawing.Point(267, 3);
            this.buttonEditScheme.Name = "buttonEditScheme";
            this.buttonEditScheme.Size = new System.Drawing.Size(258, 39);
            this.buttonEditScheme.TabIndex = 1;
            this.buttonEditScheme.Text = "Редактировать";
            this.buttonEditScheme.UseVisualStyleBackColor = true;
            this.buttonEditScheme.Click += new System.EventHandler(this.buttonEditScheme_Click);
            // 
            // buttonAddScheme
            // 
            this.buttonAddScheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddScheme.Location = new System.Drawing.Point(3, 3);
            this.buttonAddScheme.Name = "buttonAddScheme";
            this.buttonAddScheme.Size = new System.Drawing.Size(258, 39);
            this.buttonAddScheme.TabIndex = 0;
            this.buttonAddScheme.Text = "Добавить схему";
            this.buttonAddScheme.UseVisualStyleBackColor = true;
            this.buttonAddScheme.Click += new System.EventHandler(this.buttonAddScheme_Click);
            // 
            // listBoxSchemes
            // 
            this.listBoxSchemes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxSchemes.FormattingEnabled = true;
            this.listBoxSchemes.ItemHeight = 15;
            this.listBoxSchemes.Location = new System.Drawing.Point(3, 3);
            this.listBoxSchemes.Name = "listBoxSchemes";
            this.listBoxSchemes.Size = new System.Drawing.Size(794, 393);
            this.listBoxSchemes.TabIndex = 1;
            // 
            // Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Overview";
            this.Text = "Overview";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button buttonDeleteScheme;
        private Button buttonEditScheme;
        private Button buttonAddScheme;
        private ListBox listBoxSchemes;
    }
}