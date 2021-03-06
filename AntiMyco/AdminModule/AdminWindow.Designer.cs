namespace AntiMyco.AdminModule
{
    partial class AdminWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обучениеОделейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tOX21ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lD50ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.addRecordBtn = new System.Windows.Forms.Button();
            this.deleteRecordBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выйтиToolStripMenuItem,
            this.обучениеОделейToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.выйтиToolStripMenuItem.Text = "Выйти";
            this.выйтиToolStripMenuItem.Click += new System.EventHandler(this.выйтиToolStripMenuItem_Click);
            // 
            // обучениеОделейToolStripMenuItem
            // 
            this.обучениеОделейToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tOX21ToolStripMenuItem,
            this.lD50ToolStripMenuItem});
            this.обучениеОделейToolStripMenuItem.Name = "обучениеОделейToolStripMenuItem";
            this.обучениеОделейToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.обучениеОделейToolStripMenuItem.Text = "Обучение моделей";
            // 
            // tOX21ToolStripMenuItem
            // 
            this.tOX21ToolStripMenuItem.Name = "tOX21ToolStripMenuItem";
            this.tOX21ToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.tOX21ToolStripMenuItem.Text = "TOX21";
            this.tOX21ToolStripMenuItem.Click += new System.EventHandler(this.tOX21ToolStripMenuItem_Click);
            // 
            // lD50ToolStripMenuItem
            // 
            this.lD50ToolStripMenuItem.Name = "lD50ToolStripMenuItem";
            this.lD50ToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.lD50ToolStripMenuItem.Text = "LD50";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.comboBox1);
            this.flowLayoutPanel1.Controls.Add(this.addRecordBtn);
            this.flowLayoutPanel1.Controls.Add(this.deleteRecordBtn);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(776, 27);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "БД пользователей",
            "Заболевания",
            "Побочные эффекты",
            "Прекурсоры",
            "Антимикотики",
            "Оборудование"});
            this.comboBox1.Location = new System.Drawing.Point(3, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(294, 23);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // addRecordBtn
            // 
            this.addRecordBtn.Location = new System.Drawing.Point(303, 3);
            this.addRecordBtn.Name = "addRecordBtn";
            this.addRecordBtn.Size = new System.Drawing.Size(112, 23);
            this.addRecordBtn.TabIndex = 1;
            this.addRecordBtn.Text = "Добавить запись";
            this.addRecordBtn.UseVisualStyleBackColor = true;
            this.addRecordBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // deleteRecordBtn
            // 
            this.deleteRecordBtn.Location = new System.Drawing.Point(421, 3);
            this.deleteRecordBtn.Name = "deleteRecordBtn";
            this.deleteRecordBtn.Size = new System.Drawing.Size(104, 23);
            this.deleteRecordBtn.TabIndex = 2;
            this.deleteRecordBtn.Text = "Удалить запись";
            this.deleteRecordBtn.UseVisualStyleBackColor = true;
            this.deleteRecordBtn.Click += new System.EventHandler(this.deleteRecordBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(776, 378);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellDoubleClick);
            // 
            // AdminWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "AdminWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование баз данных";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem выйтиToolStripMenuItem;
        private ToolStripMenuItem обучениеОделейToolStripMenuItem;
        private FlowLayoutPanel flowLayoutPanel1;
        private ComboBox comboBox1;
        private Button addRecordBtn;
        private Button deleteRecordBtn;
        private DataGridView dataGridView1;
        private ToolStripMenuItem tOX21ToolStripMenuItem;
        private ToolStripMenuItem lD50ToolStripMenuItem;
    }
}