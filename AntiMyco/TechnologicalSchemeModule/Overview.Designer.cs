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
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.listBoxSchemes, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.55556F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.22222F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1370, 714);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 614);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1364, 97);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // buttonDeleteScheme
            // 
            this.buttonDeleteScheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeleteScheme.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDeleteScheme.Location = new System.Drawing.Point(911, 3);
            this.buttonDeleteScheme.Name = "buttonDeleteScheme";
            this.buttonDeleteScheme.Size = new System.Drawing.Size(450, 91);
            this.buttonDeleteScheme.TabIndex = 2;
            this.buttonDeleteScheme.Text = "Удалить";
            this.buttonDeleteScheme.UseVisualStyleBackColor = true;
            this.buttonDeleteScheme.Click += new System.EventHandler(this.buttonDeleteScheme_Click);
            // 
            // buttonEditScheme
            // 
            this.buttonEditScheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEditScheme.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonEditScheme.Location = new System.Drawing.Point(457, 3);
            this.buttonEditScheme.Name = "buttonEditScheme";
            this.buttonEditScheme.Size = new System.Drawing.Size(448, 91);
            this.buttonEditScheme.TabIndex = 1;
            this.buttonEditScheme.Text = "Редактировать";
            this.buttonEditScheme.UseVisualStyleBackColor = true;
            this.buttonEditScheme.Click += new System.EventHandler(this.buttonEditScheme_Click);
            // 
            // buttonAddScheme
            // 
            this.buttonAddScheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddScheme.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAddScheme.Location = new System.Drawing.Point(3, 3);
            this.buttonAddScheme.Name = "buttonAddScheme";
            this.buttonAddScheme.Size = new System.Drawing.Size(448, 91);
            this.buttonAddScheme.TabIndex = 0;
            this.buttonAddScheme.Text = "Добавить схему";
            this.buttonAddScheme.UseVisualStyleBackColor = true;
            this.buttonAddScheme.Click += new System.EventHandler(this.buttonAddScheme_Click);
            // 
            // listBoxSchemes
            // 
            this.listBoxSchemes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxSchemes.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxSchemes.FormattingEnabled = true;
            this.listBoxSchemes.ItemHeight = 25;
            this.listBoxSchemes.Location = new System.Drawing.Point(3, 214);
            this.listBoxSchemes.Name = "listBoxSchemes";
            this.listBoxSchemes.Size = new System.Drawing.Size(1364, 394);
            this.listBoxSchemes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Cambria", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1364, 211);
            this.label1.TabIndex = 2;
            this.label1.Text = "Программный комплекс для формирования технологических схем лабораторного синтеза " +
    "антимикотиков";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 714);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Overview";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private Label label1;
    }
}