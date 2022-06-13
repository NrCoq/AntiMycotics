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
            if (webBrowser1.Url.ToString() != String.Empty)
            {
                StructureWindow form = new(webBrowser1.Url.ToString());
                form.ShowDialog();
            }
        }
    }
}
