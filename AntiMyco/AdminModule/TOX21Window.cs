using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiMyco.AdminModule
{
    public partial class TOX21Window : Form
    {
        public TOX21Window()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "CSV files(*.csv)|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = openFileDialog1.FileName;

            var startInfo = new ProcessStartInfo
            {
                FileName = @"cmd.exe",
                Arguments = @"/K " + @"C:\ProgramData\Anaconda3\Scripts\activate.bat C:\ProgramData\Anaconda3\envs\rdkit37",
                UseShellExecute = false,
                CreateNoWindow = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = false

            };

            var proc = new Process();
            proc.StartInfo = startInfo;
            proc.Start();
            proc.StandardInput.WriteLine("cd "+ Directory.GetCurrentDirectory() + "\\Python\\Modeling\\modeling_tox21");
            proc.StandardInput.WriteLine("python CatBoostForTox21.py " + filename + " 20 10 1000 8");
        }
    }
    
}
