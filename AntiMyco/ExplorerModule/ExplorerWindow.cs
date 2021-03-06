using Microsoft.Extensions.Configuration;
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

                    var builder = new ConfigurationBuilder();
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                    builder.AddJsonFile("connection.json");

                    var config = builder.Build();
                    string connectionString = config.GetConnectionString("RDKitPath");

                    var startInfo = new ProcessStartInfo
                    {
                        FileName = @"cmd.exe",
                        Arguments = @"/K " + connectionString,
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
                        if (progressBar1.Value >= 90) throw new Exception("Превышено время ожидания ответа от модуля");
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

                    if (SMILES_textbox.Text == @"CC1C=CC=CCCC=CC=CC=CC=CC(CC2C(C(CC(O2)(CC(C(CCC(CC(CC(CC(=O)OC(C(C1O)C)C)O)O)O)O)O)O)O)C(=O)O)OC3C(C(C(C(O3)C)O)N)O")
                    {
                        DialogResult dialogResult = MessageBox.Show("Данный антимикотик найден в базе данных! Хотите просмотреть подробно его свойства?", "Антимикотик найден в базе данных", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            PropForm form = new();
                            form.ShowDialog();
                        }
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Данное вещество не найдено в базе данных! Хотите его добавить?", "Вещество не найдено в базе данных", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            AddForm form = new(SMILES_textbox.Text, decimal.Parse(ld50.Text.Replace('.',',')));
                            form.ShowDialog();
                        }
                    }

                    progressBar1.Value = 0;
                }
            }
            catch (Exception ex)
            {
                progressBar1.Value = 100;
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
    }
}
