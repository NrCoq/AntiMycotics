using AntiMyco.DataModels.Antimycotics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiMyco.AdminModule
{
    public partial class RecordEdit : Form
    {
        private List<AdminWindow.PropertyTemplate> Properties { get; set; }
        private string Mode { get; set; }
        Type DbTableType { get; set; }

        public RecordEdit(List<AdminWindow.PropertyTemplate> properties, Type dbTableType, string mode, int selectedIndex)
        {
            Properties = properties;
            Mode = mode;

            DbTableType = dbTableType;

            int i = 0;
            int x = 12;
            int y = 12;
            foreach (AdminWindow.PropertyTemplate property in properties)
            {
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

                y += 37;
                i++;
            }

            Button btn = new Button()
            {
                Name = "saveBtn",
                Location = new Point(150, y),
                Font = new Font("Segoe UI", 12.0f),
                Margin = new Padding(3),
                Text = "Сохранить",
                AutoSize = true
            };

            btn.Click += Btn_Click;
            this.Controls.Add(btn);

            InitializeComponent();
            this.Width = 400;
            this.Height = y + 80;
            this.ActiveControl = this.Controls.Find("tb_" + selectedIndex.ToString(), true).FirstOrDefault() as TextBox;
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            void EditRecordData(object recordForEdit)
            {
                int i = 0;
                foreach (var property in Properties)
                {
                    TextBox tbx = this.Controls.Find("tb_" + i.ToString(), true).FirstOrDefault() as TextBox;
                    var prop = DbTableType.GetProperty(property.DbName);
                    prop.SetValue(recordForEdit, tbx.Text);
                    i++;
                }
            }

            if (Mode == "add")
            {
                var table = CreateConstructor(DbTableType);
                var record = table();

                int i = 0;
                foreach (var property in Properties)
                {
                    TextBox tbx = this.Controls.Find("tb_" + i.ToString(), true).FirstOrDefault() as TextBox;
                    var prop = DbTableType.GetProperty(property.DbName);
                    prop.SetValue(record, tbx.Text);
                    i++;
                }

                if (DbTableType == typeof(Disease))
                {
                    AntimycoticsContext context = new();
                    context.Diseases.Add((Disease)record);
                    context.SaveChanges();
                }

            }
            else if (Mode == "edit")
            {
                if (DbTableType == typeof(Disease))
                {
                    using (AntimycoticsContext context = new())
                    {
                        TextBox pk_tbx = this.Controls.Find("tb_0", true).FirstOrDefault() as TextBox;
                        var recordForEdit = context.Diseases.FirstOrDefault(x => x.Name == pk_tbx.Text);
                        EditRecordData(recordForEdit);

                        context.Entry(recordForEdit).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            }

            MessageBox.Show("Запись успешно добавлена", "Добавление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public delegate object ConstructorDelegate(params object[] args);

        public static ConstructorDelegate CreateConstructor(Type type, params Type[]? parameters )
        {
            // Мета для конструктора
            var constructorInfo = type.GetConstructor(parameters);

            // Определение списка параметров
            var paramExpr = Expression.Parameter(typeof(Object[]));

            // Генерация параметров для конструктора
            var constructorParameters = parameters.Select((paramType, index) =>
                // Конвертация в фактический тип параметров
                Expression.Convert(
                    Expression.ArrayAccess(
                        paramExpr,
                        Expression.Constant(index)),
                    paramType)).ToArray();

            // Опередление оператора вызова конструктора
            var body = Expression.New(constructorInfo, constructorParameters);

            var constructor = Expression.Lambda<ConstructorDelegate>(body, paramExpr);
            return constructor.Compile();
        }

    }
}
