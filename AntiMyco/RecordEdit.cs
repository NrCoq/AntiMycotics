using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiMyco
{
    public partial class RecordEdit : Form
    {
        public RecordEdit(List<AdminWindow.PropertyTemplate> properties)
        {
            int i = 0;
            foreach (AdminWindow.PropertyTemplate property in properties)
            {
                int x = 12;
                int y = 12 + 37 * i; // 49
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel()
                {
                    Name = "panel_" + i.ToString(),
                    Location = new Point(x, y),
                    Size = new Size(450, 31),
                    Margin = new Padding(3),
                    FlowDirection = FlowDirection.LeftToRight
                };

                Label label = new Label()
                {
                    Name = "label_" + i.ToString(),
                    Font = new Font("Segoe UI", 12.0f),
                    Margin = new Padding(3, 3, 3, 0),
                    Text = property.RuName,
                    AutoSize = true
                };

                flowLayoutPanel.Controls.Add(label);

                TextBox textBox = new TextBox()
                {
                    Name = "tb_" + i.ToString(),
                    Size = new Size(215, 23),
                    Text = property.Value
                };

                if (property.Type == typeof(double)) textBox.KeyPress += KeyPress;

                flowLayoutPanel.Controls.Add(textBox);

                this.Controls.Add(flowLayoutPanel);
                i++;
            }
            InitializeComponent();
        }

        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                e.KeyChar = ','; //замена точки на запятую

            if (e.KeyChar == ',')
            {
                if (((sender as TextBox).Text.IndexOf(',') != -1) //запятая уже есть
                    || (sender as TextBox).Text.Length == 0) //число не введено
                    e.Handled = true;
                return;
            }

            if (!char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    e.Handled = false;
                    return;
                }

                e.Handled = true;
                return;
            }

            return;
        }
    }
}
