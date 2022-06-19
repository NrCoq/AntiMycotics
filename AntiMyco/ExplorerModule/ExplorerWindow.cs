using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;

namespace AntiMyco.ExplorerModule
{
    public partial class ExplorerWindow : Form
    {
        public ExplorerWindow()
        {
            InitializeComponent();
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                
                
                if (e.KeyCode == Keys.Enter)
                {
                    //progressBar1.Value = 0;

                    //while (progressBar1.Value <= 85)
                    //{

                    //    Random rnd = new Random();
                    //    int num = rnd.Next(1, 10);
                    //    progressBar1.Value += num;
                    //    Thread.Sleep(50);
                    //}
                    //progressBar1.Value = 100;

                    //if (SMILES_textbox.Text == @"O=C(O)[C@@H]3[C@@H](O)C[C@@]2(O)C[C@@H](O)C[C@@H](O)[C@H](O)CC[C@@H](O)C[C@@H](O)CC(=O)O[C@@H](C)[C@H](C)[C@H](O)[C@@H](C)C=CC=CC=CC=CC=CC=CC=C[C@H](O[C@@H]1O[C@H](C)[C@@H](O)[C@H](N)[C@@H]1O)C[C@@H]3O2")
                    //{
                    //    int i = 0;
                    //    string[] values = new string[] { "false", "false", "false", "false", "false", "false", "false", "true", "false", "false", "false", "false", "272.022", "100", "0.712" };
                    //    Label[] elems = new Label[] { nr_ahr, nr_ar, nr_ar_lbd, nr_aromatase, nr_er, nr_er_lbd, nr_ppar_gamma, sr_are, sr_atad5, sr_hse, sr_mmp, sr_p53, ld50, sim, log_p };
                    //    foreach (Label label in elems)
                    //    {
                    //        label.Text = values[i];
                    //        i++;
                    //    }
                    //    webBrowser1.Navigate(Directory.GetCurrentDirectory() + "\\ampho_b.svg");

                    //    DialogResult dialogResult = MessageBox.Show("Данный антимикотик найден в базе данных! Хотите просмотреть подробно его свойства?", "Антимикотик найден в базе данных", MessageBoxButtons.YesNo);
                    //    if (dialogResult == DialogResult.Yes)
                    //    {
                    //        PropForm form = new();
                    //        form.ShowDialog();
                    //    }
                    //}
                    //else if(SMILES_textbox.Text == @"CC2(C)CCCC(\C)=C2\C=C\C(\C)=C\C=C\C(\C)=C\C=C\C=C(/C)\C=C\C=C(/C)\C=C\C1=C(/C)")
                    //{
                    //    int i = 0;
                    //    string[] values = new string[] { "false", "false", "false", "false", "false", "false", "false", "true", "false", "true", "false", "false", "7.881", "19.380", "12.606"};
                    //    Label[] elems = new Label[] { nr_ahr, nr_ar, nr_ar_lbd, nr_aromatase, nr_er, nr_er_lbd, nr_ppar_gamma, sr_are, sr_atad5, sr_hse, sr_mmp, sr_p53, ld50, sim, log_p };
                    //    foreach (Label label in elems)
                    //    {
                    //        label.Text = values[i];
                    //        i++;
                    //    }
                    //    webBrowser1.Navigate(Directory.GetCurrentDirectory()+"\\beta.svg");

                    //    DialogResult dialogResult = MessageBox.Show("Данное вещество не найдено в базе данных! Хотите его добавить?", "Вещество не найдено в базе данных", MessageBoxButtons.YesNo);
                    //    if (dialogResult == DialogResult.Yes)
                    //    {
                    //        AddForm form = new();
                    //        form.ShowDialog();
                    //    }
                    //}
                    //else
                    //{
                    //    throw new Exception("Структура задана неверно");
                    //}
                    DirectoryInfo dirInfo = new DirectoryInfo(Environment.CurrentDirectory + "\\Python\\Files");

                    foreach (FileInfo file in dirInfo.GetFiles())
                    {
                        file.Delete();
                    }

                    progressBar1.Value = 20;

                    var startInfo = new ProcessStartInfo
                    {
                        FileName = @"cmd.exe",
                        Arguments = @"/K " + @"C:\ProgramData\Anaconda3\Scripts\activate.bat C:\ProgramData\Anaconda3\envs\rdkit37",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                    };

                    var proc = new Process();
                    proc.StartInfo = startInfo;
                    proc.Start();

                    string buffer = string.Empty;
                    char symb;
                    symb = (char)proc.StandardOutput.Peek();

                    buffer = proc.StandardOutput.ReadLine();

                    proc.StandardInput.WriteLine("cd Python");
                    proc.StandardInput.WriteLine("python script.py " + SMILES_textbox.Text);


                    while (!System.IO.File.Exists(Environment.CurrentDirectory + "\\Python\\Files\\response.xml"))
                    {
                        if (progressBar1.Value >= 70) throw new Exception("Превышено время ожидания ответа от модуля");
                        progressBar1.Value += 5;
                        Thread.Sleep(500);
                        if (System.IO.File.Exists(Environment.CurrentDirectory + "\\Python\\Files\\response.xml")) break;
                    }

                    proc.Kill();

                    Label[] elems = new Label[] { nr_ahr, nr_ar, nr_ar_lbd, nr_aromatase, nr_er, nr_er_lbd, nr_ppar_gamma, sr_are, sr_atad5, sr_hse, sr_mmp, sr_p53, ld50, sim, log_p };
                    XmlDocument doc = new XmlDocument();
                    doc.Load(Environment.CurrentDirectory + "\\Python\\Files\\response.xml");
                    string text = string.Empty;
                    int i = 0;
                    foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                    {
                        if (node.Name == "pic")
                        {
                            webBrowser1.Navigate(node.InnerText);
                            break;
                        }
                        var label = elems[i] as Label;
                        label.Text = node.InnerText;
                        i++;
                    }
                    progressBar1.Value = 100;
                    Thread.Sleep(1000);
                    progressBar1.Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Во время работы прогаммы возникла ошибка:" + Environment.NewLine + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Resize_Click(object sender, EventArgs e)
        {
            try
            {
                if (webBrowser1.Url.ToString() != String.Empty)
                {
                    StructureWindow form = new(webBrowser1.Url.ToString());
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Для увеличения необходима структура!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void focus(object sender, EventArgs e)
        {
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new AuthWindow();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                
                Excel.Application excelApp = new Excel.Application();

                Excel.Workbook workbook = excelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);

                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

                worksheet.Cells[1, 1] = "Структура";
                Excel.Range leftCell = (Excel.Range)worksheet.Cells[1, 1];
                leftCell.Font.Bold = true;
                Excel.Range rightCell = (Excel.Range)worksheet.Cells[1, 2];
                Excel.Range range = worksheet.get_Range(leftCell, rightCell);
                range.Merge(true);
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                worksheet.Cells[2, 1] = SMILES_textbox.Text;
                leftCell = (Excel.Range)worksheet.Cells[2, 1];
                leftCell.Font.Bold = true;
                rightCell = (Excel.Range)worksheet.Cells[2, 2];
                range = worksheet.get_Range(leftCell, rightCell);
                range.Merge(true);
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                worksheet.Cells[4, 1] = "Наличие связи с белками";
                leftCell = (Excel.Range)worksheet.Cells[4, 1];
                leftCell.Font.Bold = true;
                rightCell = (Excel.Range)worksheet.Cells[4, 2];
                range = worksheet.get_Range(leftCell, rightCell);
                range.Merge(true);
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                worksheet.Cells[5, 1] = "NR-AhR";
                worksheet.Cells[5, 2] = nr_ahr.Text;

                worksheet.Cells[6, 1] = "NR-AR";
                worksheet.Cells[6, 2] = nr_ar.Text;

                worksheet.Cells[7, 1] = "NR-AR-LBD";
                worksheet.Cells[7, 2] = nr_ar_lbd.Text;

                worksheet.Cells[8, 1] = "NR-Aromatose";
                worksheet.Cells[8, 2] = nr_aromatase.Text;

                worksheet.Cells[9, 1] = "NR-ER";
                worksheet.Cells[9, 2] = nr_er.Text;

                worksheet.Cells[10, 1] = "NR-ER-LBD";
                worksheet.Cells[10, 2] = nr_er_lbd.Text;

                worksheet.Cells[11, 1] = "NR-PPAR-gamma";
                worksheet.Cells[11, 2] = nr_ppar_gamma.Text;

                worksheet.Cells[12, 1] = "SR-ARE";
                worksheet.Cells[12, 2] = sr_are.Text;

                worksheet.Cells[13, 1] = "SR-ATAD5";
                worksheet.Cells[13, 2] = sr_atad5.Text;

                worksheet.Cells[14, 1] = "SR-HSE";
                worksheet.Cells[14, 2] = sr_hse.Text;

                worksheet.Cells[15, 1] = "SR-MMP";
                worksheet.Cells[15, 2] = sr_mmp.Text;

                worksheet.Cells[16, 1] = "SR-p53";
                worksheet.Cells[16, 2] = sr_p53.Text;

                worksheet.Cells[17, 1] = "Фармакологические свойства";
                leftCell = (Excel.Range)worksheet.Cells[17, 1];
                leftCell.Font.Bold = true;
                rightCell = (Excel.Range)worksheet.Cells[17, 2];
                range = worksheet.get_Range(leftCell, rightCell);
                range.Merge(true);
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                worksheet.Cells[18, 1] = "LD50, мг/кг";
                worksheet.Cells[18, 2] = ld50.Text;

                worksheet.Cells[19, 1] = "log P";
                worksheet.Cells[19, 2] = log_p.Text;

                worksheet.Columns.AutoFit();
                worksheet.Rows.AutoFit();
                excelApp.Visible = true;

                //worksheet.Shapes.AddPicture(webBrowser1.Url.ToString(), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 10, 10, 700, 350)
            }
            catch (Exception) { return; }
        }
    }//  sr_atad5, sr_hse, sr_mmp, sr_p53, ld50, sim, log_p
}
