
namespace AntiMyco.ExplorerModule
{
    partial class ExplorerWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplorerWindow));
            this.WindowPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SMILES_textbox = new System.Windows.Forms.RichTextBox();
            this.PropertiesPanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ActivityPanel = new System.Windows.Forms.TableLayoutPanel();
            this.sr_p53 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.sr_mmp = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.sr_hse = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.sr_atad5 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.sr_are = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.nr_ppar_gamma = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.nr_er_lbd = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nr_er = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nr_aromatase = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nr_ar_lbd = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nr_ar = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nr_ahr = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RightPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.sim = new System.Windows.Forms.Label();
            this.ld50 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.log_p = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.Resize = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowPanel.SuspendLayout();
            this.PropertiesPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ActivityPanel.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Resize)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WindowPanel
            // 
            this.WindowPanel.ColumnCount = 1;
            this.WindowPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.WindowPanel.Controls.Add(this.SMILES_textbox, 0, 0);
            this.WindowPanel.Controls.Add(this.PropertiesPanel, 0, 3);
            this.WindowPanel.Location = new System.Drawing.Point(10, 37);
            this.WindowPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.WindowPanel.Name = "WindowPanel";
            this.WindowPanel.RowCount = 4;
            this.WindowPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.WindowPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.WindowPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.WindowPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.WindowPanel.Size = new System.Drawing.Size(926, 515);
            this.WindowPanel.TabIndex = 0;
            // 
            // SMILES_textbox
            // 
            this.SMILES_textbox.DetectUrls = false;
            this.SMILES_textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SMILES_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SMILES_textbox.Location = new System.Drawing.Point(4, 3);
            this.SMILES_textbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SMILES_textbox.Name = "SMILES_textbox";
            this.SMILES_textbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.SMILES_textbox.Size = new System.Drawing.Size(919, 109);
            this.SMILES_textbox.TabIndex = 1;
            this.SMILES_textbox.Text = "SMILES";
            this.SMILES_textbox.Enter += new System.EventHandler(this.focus);
            this.SMILES_textbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            // 
            // PropertiesPanel
            // 
            this.PropertiesPanel.ColumnCount = 2;
            this.PropertiesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.75634F));
            this.PropertiesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.24366F));
            this.PropertiesPanel.Controls.Add(this.groupBox1, 0, 0);
            this.PropertiesPanel.Controls.Add(this.RightPanel, 1, 0);
            this.PropertiesPanel.Location = new System.Drawing.Point(4, 118);
            this.PropertiesPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PropertiesPanel.Name = "PropertiesPanel";
            this.PropertiesPanel.RowCount = 1;
            this.PropertiesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PropertiesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 417F));
            this.PropertiesPanel.Size = new System.Drawing.Size(919, 391);
            this.PropertiesPanel.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ActivityPanel);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(533, 382);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Связь с белками";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // ActivityPanel
            // 
            this.ActivityPanel.ColumnCount = 2;
            this.ActivityPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ActivityPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.ActivityPanel.Controls.Add(this.sr_p53, 1, 11);
            this.ActivityPanel.Controls.Add(this.label23, 0, 11);
            this.ActivityPanel.Controls.Add(this.sr_mmp, 1, 10);
            this.ActivityPanel.Controls.Add(this.label21, 0, 10);
            this.ActivityPanel.Controls.Add(this.sr_hse, 1, 9);
            this.ActivityPanel.Controls.Add(this.label19, 0, 9);
            this.ActivityPanel.Controls.Add(this.sr_atad5, 1, 8);
            this.ActivityPanel.Controls.Add(this.label17, 0, 8);
            this.ActivityPanel.Controls.Add(this.sr_are, 1, 7);
            this.ActivityPanel.Controls.Add(this.label15, 0, 7);
            this.ActivityPanel.Controls.Add(this.nr_ppar_gamma, 1, 6);
            this.ActivityPanel.Controls.Add(this.label13, 0, 6);
            this.ActivityPanel.Controls.Add(this.nr_er_lbd, 1, 5);
            this.ActivityPanel.Controls.Add(this.label11, 0, 5);
            this.ActivityPanel.Controls.Add(this.nr_er, 1, 4);
            this.ActivityPanel.Controls.Add(this.label9, 0, 4);
            this.ActivityPanel.Controls.Add(this.nr_aromatase, 1, 3);
            this.ActivityPanel.Controls.Add(this.label7, 0, 3);
            this.ActivityPanel.Controls.Add(this.nr_ar_lbd, 1, 2);
            this.ActivityPanel.Controls.Add(this.label5, 0, 2);
            this.ActivityPanel.Controls.Add(this.nr_ar, 1, 1);
            this.ActivityPanel.Controls.Add(this.label3, 0, 1);
            this.ActivityPanel.Controls.Add(this.nr_ahr, 1, 0);
            this.ActivityPanel.Controls.Add(this.label1, 0, 0);
            this.ActivityPanel.Location = new System.Drawing.Point(7, 26);
            this.ActivityPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ActivityPanel.Name = "ActivityPanel";
            this.ActivityPanel.RowCount = 12;
            this.ActivityPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.ActivityPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.ActivityPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.ActivityPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.ActivityPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.ActivityPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.ActivityPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.ActivityPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.ActivityPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.ActivityPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.ActivityPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.ActivityPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.ActivityPanel.Size = new System.Drawing.Size(519, 348);
            this.ActivityPanel.TabIndex = 0;
            // 
            // sr_p53
            // 
            this.sr_p53.AutoSize = true;
            this.sr_p53.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sr_p53.Location = new System.Drawing.Point(384, 319);
            this.sr_p53.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sr_p53.Name = "sr_p53";
            this.sr_p53.Size = new System.Drawing.Size(48, 19);
            this.sr_p53.TabIndex = 23;
            this.sr_p53.Text = "Value";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label23.Location = new System.Drawing.Point(4, 319);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(61, 19);
            this.label23.TabIndex = 22;
            this.label23.Text = "SR-p53";
            // 
            // sr_mmp
            // 
            this.sr_mmp.AutoSize = true;
            this.sr_mmp.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sr_mmp.Location = new System.Drawing.Point(384, 290);
            this.sr_mmp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sr_mmp.Name = "sr_mmp";
            this.sr_mmp.Size = new System.Drawing.Size(48, 19);
            this.sr_mmp.TabIndex = 21;
            this.sr_mmp.Text = "Value";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label21.Location = new System.Drawing.Point(4, 290);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 19);
            this.label21.TabIndex = 20;
            this.label21.Text = "SR-MMP";
            // 
            // sr_hse
            // 
            this.sr_hse.AutoSize = true;
            this.sr_hse.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sr_hse.Location = new System.Drawing.Point(384, 261);
            this.sr_hse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sr_hse.Name = "sr_hse";
            this.sr_hse.Size = new System.Drawing.Size(48, 19);
            this.sr_hse.TabIndex = 19;
            this.sr_hse.Text = "Value";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label19.Location = new System.Drawing.Point(4, 261);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 19);
            this.label19.TabIndex = 18;
            this.label19.Text = "SR-HSE";
            // 
            // sr_atad5
            // 
            this.sr_atad5.AutoSize = true;
            this.sr_atad5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sr_atad5.Location = new System.Drawing.Point(384, 232);
            this.sr_atad5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sr_atad5.Name = "sr_atad5";
            this.sr_atad5.Size = new System.Drawing.Size(48, 19);
            this.sr_atad5.TabIndex = 17;
            this.sr_atad5.Text = "Value";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(4, 232);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 19);
            this.label17.TabIndex = 16;
            this.label17.Text = "SR-ATAD5";
            // 
            // sr_are
            // 
            this.sr_are.AutoSize = true;
            this.sr_are.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sr_are.Location = new System.Drawing.Point(384, 203);
            this.sr_are.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sr_are.Name = "sr_are";
            this.sr_are.Size = new System.Drawing.Size(48, 19);
            this.sr_are.TabIndex = 15;
            this.sr_are.Text = "Value";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(4, 203);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 19);
            this.label15.TabIndex = 14;
            this.label15.Text = "SR-ARE";
            // 
            // nr_ppar_gamma
            // 
            this.nr_ppar_gamma.AutoSize = true;
            this.nr_ppar_gamma.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nr_ppar_gamma.Location = new System.Drawing.Point(384, 174);
            this.nr_ppar_gamma.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nr_ppar_gamma.Name = "nr_ppar_gamma";
            this.nr_ppar_gamma.Size = new System.Drawing.Size(48, 19);
            this.nr_ppar_gamma.TabIndex = 13;
            this.nr_ppar_gamma.Text = "Value";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(4, 174);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(134, 19);
            this.label13.TabIndex = 12;
            this.label13.Text = "NR-PPAR-gamma";
            // 
            // nr_er_lbd
            // 
            this.nr_er_lbd.AutoSize = true;
            this.nr_er_lbd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nr_er_lbd.Location = new System.Drawing.Point(384, 145);
            this.nr_er_lbd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nr_er_lbd.Name = "nr_er_lbd";
            this.nr_er_lbd.Size = new System.Drawing.Size(48, 19);
            this.nr_er_lbd.TabIndex = 11;
            this.nr_er_lbd.Text = "Value";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(4, 145);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 19);
            this.label11.TabIndex = 10;
            this.label11.Text = "NR-ER-LBD";
            // 
            // nr_er
            // 
            this.nr_er.AutoSize = true;
            this.nr_er.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nr_er.Location = new System.Drawing.Point(384, 116);
            this.nr_er.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nr_er.Name = "nr_er";
            this.nr_er.Size = new System.Drawing.Size(48, 19);
            this.nr_er.TabIndex = 9;
            this.nr_er.Text = "Value";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(4, 116);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 19);
            this.label9.TabIndex = 8;
            this.label9.Text = "NR-ER";
            // 
            // nr_aromatase
            // 
            this.nr_aromatase.AutoSize = true;
            this.nr_aromatase.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nr_aromatase.Location = new System.Drawing.Point(384, 87);
            this.nr_aromatase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nr_aromatase.Name = "nr_aromatase";
            this.nr_aromatase.Size = new System.Drawing.Size(48, 19);
            this.nr_aromatase.TabIndex = 7;
            this.nr_aromatase.Text = "Value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(4, 87);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "NR-Aromatase";
            // 
            // nr_ar_lbd
            // 
            this.nr_ar_lbd.AutoSize = true;
            this.nr_ar_lbd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nr_ar_lbd.Location = new System.Drawing.Point(384, 58);
            this.nr_ar_lbd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nr_ar_lbd.Name = "nr_ar_lbd";
            this.nr_ar_lbd.Size = new System.Drawing.Size(48, 19);
            this.nr_ar_lbd.TabIndex = 5;
            this.nr_ar_lbd.Text = "Value";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(4, 58);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "NR-AR-LBD";
            // 
            // nr_ar
            // 
            this.nr_ar.AutoSize = true;
            this.nr_ar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nr_ar.Location = new System.Drawing.Point(384, 29);
            this.nr_ar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nr_ar.Name = "nr_ar";
            this.nr_ar.Size = new System.Drawing.Size(48, 19);
            this.nr_ar.TabIndex = 3;
            this.nr_ar.Text = "Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(4, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "NR-AR";
            // 
            // nr_ahr
            // 
            this.nr_ahr.AutoSize = true;
            this.nr_ahr.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nr_ahr.Location = new System.Drawing.Point(384, 0);
            this.nr_ahr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nr_ahr.Name = "nr_ahr";
            this.nr_ahr.Size = new System.Drawing.Size(48, 19);
            this.nr_ahr.TabIndex = 1;
            this.nr_ahr.Text = "Value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "NR-AhR";
            // 
            // RightPanel
            // 
            this.RightPanel.ColumnCount = 1;
            this.RightPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RightPanel.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.RightPanel.Controls.Add(this.webBrowser1, 0, 1);
            this.RightPanel.Controls.Add(this.Resize, 0, 2);
            this.RightPanel.Location = new System.Drawing.Point(543, 3);
            this.RightPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.RowCount = 3;
            this.RightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 238F));
            this.RightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.RightPanel.Size = new System.Drawing.Size(372, 385);
            this.RightPanel.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.35331F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.64669F));
            this.tableLayoutPanel5.Controls.Add(this.sim, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.ld50, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label32, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label31, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.log_p, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.label29, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(4, 3);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(368, 103);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // sim
            // 
            this.sim.AutoSize = true;
            this.sim.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sim.Location = new System.Drawing.Point(240, 36);
            this.sim.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sim.Name = "sim";
            this.sim.Size = new System.Drawing.Size(48, 19);
            this.sim.TabIndex = 22;
            this.sim.Text = "Value";
            // 
            // ld50
            // 
            this.ld50.AutoSize = true;
            this.ld50.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ld50.Location = new System.Drawing.Point(240, 0);
            this.ld50.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ld50.Name = "ld50";
            this.ld50.Size = new System.Drawing.Size(48, 19);
            this.ld50.TabIndex = 22;
            this.ld50.Text = "Value";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label32.Location = new System.Drawing.Point(4, 36);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(192, 19);
            this.label32.TabIndex = 22;
            this.label32.Text = "Сходство с полиеном, %";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label31.Location = new System.Drawing.Point(4, 71);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(49, 19);
            this.label31.TabIndex = 24;
            this.label31.Text = "Log P";
            // 
            // log_p
            // 
            this.log_p.AutoSize = true;
            this.log_p.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.log_p.Location = new System.Drawing.Point(240, 71);
            this.log_p.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.log_p.Name = "log_p";
            this.log_p.Size = new System.Drawing.Size(48, 19);
            this.log_p.TabIndex = 23;
            this.log_p.Text = "Value";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label29.Location = new System.Drawing.Point(4, 0);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(192, 19);
            this.label29.TabIndex = 22;
            this.label29.Text = "Токсичность LD50, мг/кг";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(4, 112);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(23, 23);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(368, 232);
            this.webBrowser1.TabIndex = 1;
            // 
            // Resize
            // 
            this.Resize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Resize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Resize.Image = ((System.Drawing.Image)(resources.GetObject("Resize.Image")));
            this.Resize.Location = new System.Drawing.Point(173, 351);
            this.Resize.Name = "Resize";
            this.Resize.Size = new System.Drawing.Size(30, 30);
            this.Resize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Resize.TabIndex = 2;
            this.Resize.TabStop = false;
            this.Resize.Click += new System.EventHandler(this.Resize_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 558);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(926, 27);
            this.progressBar1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выйтиToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(941, 29);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(67, 25);
            this.выйтиToolStripMenuItem.Text = "Выйти";
            this.выйтиToolStripMenuItem.Click += new System.EventHandler(this.выйтиToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(98, 25);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // ExplorerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 591);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.WindowPanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExplorerWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Прогнозирование характеристик антимикотика";
            this.WindowPanel.ResumeLayout(false);
            this.PropertiesPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ActivityPanel.ResumeLayout(false);
            this.ActivityPanel.PerformLayout();
            this.RightPanel.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Resize)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel WindowPanel;
        private System.Windows.Forms.RichTextBox SMILES_textbox;
        private System.Windows.Forms.TableLayoutPanel PropertiesPanel;
        private System.Windows.Forms.TableLayoutPanel ActivityPanel;
        private System.Windows.Forms.Label sr_p53;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label sr_mmp;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label sr_hse;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label sr_atad5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label sr_are;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label nr_ppar_gamma;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label nr_er_lbd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label nr_er;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label nr_aromatase;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label nr_ar_lbd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label nr_ar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label nr_ahr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel RightPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label sim;
        private System.Windows.Forms.Label ld50;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label log_p;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private GroupBox groupBox1;
        private PictureBox Resize;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
    }
}