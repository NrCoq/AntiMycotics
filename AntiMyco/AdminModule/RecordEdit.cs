using AntiMyco.DataModels.Antimycotics;
using AntiMyco.DataModels.Users;
using AntiMyco.DataModels.TechnologicalSchemeDataModel;
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
using System.Security.Cryptography;

namespace AntiMyco.AdminModule
{
    public partial class RecordEdit : Form
    {
        private List<AdminWindow.PropertyTemplate> Properties { get; set; }
        private string Mode { get; set; }
        Type DbTableType { get; set; }

        private byte[] ImgBytes { get; set; }
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

                if (property.Type == typeof(string) || property.Type == typeof(double))
                {
                    TextBox textBox = new()
                    {
                        Name = "tb_" + i.ToString(),
                        Size = new Size(215, 23),
                        Text = property.Value
                    };

                    if (property.Type == typeof(double)) textBox.KeyPress += KeyPress;

                    flowLayoutPanel.Controls.Add(textBox);
                }
                else if(property.Type == typeof(byte[]))
                {
                    Button button = new()
                    {
                        Name = "fileBtn",
                        Size = new Size(110, 23),
                        Text = "Выбрать модель"
                    };
                    button.Click += FileBtn_Click;

                    Label fileLabel = new Label()
                    {
                        Name = "file",
                        Font = new Font("Segoe UI", 8.0f),
                        Margin = new Padding(3, 3, 3, 0),
                        Text = "",
                        Size = new Size(100, 23),
                        AutoSize = false
                    };

                    flowLayoutPanel.Controls.Add(button);
                    flowLayoutPanel.Controls.Add(fileLabel);
                    i--;

                }
                else
                {
                    ComboBox comboBox = new()
                    {
                        Name = "cb",
                        Size = new Size(215, 23)
                    };

                    if (dbTableType == typeof(User))
                    {
                        using (UsersContext context = new())
                        {
                            var roles = context.Roles.ToList();
                            foreach (var role in roles)
                                comboBox.Items.Add(role.Role1);
                        }

                        flowLayoutPanel.Controls.Add(comboBox);
                    }
                    else
                    {
                        using (AntimycoticsContext context = new())
                        {
                            var precursors = context.Precursors.ToList();
                            foreach (var precursor in precursors)
                                comboBox.Items.Add(precursor.Name);
                        }

                        flowLayoutPanel.Controls.Add(comboBox);

                    }
                    i--;
                }

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

            if (mode == "edit")
            {
                TextBox tbx = this.Controls.Find("tb_0", true).FirstOrDefault() as TextBox;
                tbx.ReadOnly = true;
            }

            this.Width = 400;
            this.Height = y + 80;
            this.ActiveControl = this.Controls.Find("tb_" + selectedIndex.ToString(), true).FirstOrDefault() as TextBox;
        }

        private void FileBtn_Click(object? sender, EventArgs e)
        {
            openFileDialog1.Filter = "PNG files(*.png)|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            Label lbl = this.Controls.Find("file", true).FirstOrDefault() as Label;
            lbl.Text = openFileDialog1.SafeFileName;

            string filename = openFileDialog1.FileName;

            Image img = Image.FromFile(filename);
            byte[] bytes;
            using (var ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                ImgBytes = ms.ToArray();
            }   

        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            void EditRecordData(object recordForEdit)
            {
                int i = 0;
                foreach (var property in Properties)
                {
                    if (property.Type == typeof(string) || property.Type == typeof(double))
                    {
                        TextBox tbx = this.Controls.Find("tb_" + i.ToString(), true).FirstOrDefault() as TextBox;
                        var prop = DbTableType.GetProperty(property.DbName);
                        try
                        {
                            prop.SetValue(recordForEdit, tbx.Text);
                        }
                        catch (System.ArgumentException)
                        {
                            prop.SetValue(recordForEdit, decimal.Parse(tbx.Text));
                        }
                        i++;
                    }
                    else if (property.Type == typeof(byte[]))
                    {
                        var prop = DbTableType.GetProperty(property.DbName);
                        prop.SetValue(recordForEdit, ImgBytes);
                    }
                    else
                    {
                        ComboBox cbx = this.Controls.Find("cb", true).FirstOrDefault() as ComboBox;
                        var prop = DbTableType.GetProperty(property.DbName);
                        prop.SetValue(recordForEdit, cbx.SelectedIndex + 1);
                    }

                }
            }

            if (Mode == "add")
            {
                var table = CreateConstructor(DbTableType);
                var record = table();

                EditRecordData(record);


                if (DbTableType == typeof(Disease))
                {
                    AntimycoticsContext context = new();
                    context.Diseases.Add((Disease)record);
                    context.SaveChanges();
                }
                else if (DbTableType == typeof(SideEffect))
                {
                    AntimycoticsContext context = new();
                    context.SideEffects.Add((SideEffect)record);
                    context.SaveChanges();
                }
                else if (DbTableType == typeof(Precursor))
                {
                    AntimycoticsContext context = new();
                    context.Precursors.Add((Precursor)record);
                    context.SaveChanges();
                }
                else if (DbTableType == typeof(Antimycotic))
                {
                    AntimycoticsContext context = new();
                    context.Antimycotics.Add((Antimycotic)record);
                    context.SaveChanges();
                }
                else if (DbTableType == typeof(User))
                {
                    UsersContext context = new();

                    var prop = DbTableType.GetProperty("Password");
                    var passwordBytes = ASCIIEncoding.ASCII.GetBytes(prop.GetValue(record).ToString());
                    var passwordHash = ASCIIEncoding.ASCII.GetString(SHA256.HashData(passwordBytes));
                    prop.SetValue(record, passwordHash);

                    context.Users.Add((User)record);
                    context.SaveChanges();
                }
                else if (DbTableType == typeof(Equipment))
                {
                    DataModels.TechnologicalSchemeDataModel.TechnologicalSchemeDBContext context = new();
                    context.Equipment.Add((Equipment)record);
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
                else if (DbTableType == typeof(User))
                {
                    UsersContext context = new();

                    TextBox pk_tbx = this.Controls.Find("tb_0", true).FirstOrDefault() as TextBox;
                    var recordForEdit = context.Users.FirstOrDefault(x => x.Login == pk_tbx.Text);
                    EditRecordData(recordForEdit);

                    var prop = DbTableType.GetProperty("Password");
                    var passwordBytes = ASCIIEncoding.ASCII.GetBytes(prop.GetValue(recordForEdit).ToString());
                    var passwordHash = ASCIIEncoding.ASCII.GetString(SHA256.HashData(passwordBytes));
                    prop.SetValue(recordForEdit, passwordHash);

                    context.Entry(recordForEdit).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else if (DbTableType == typeof(Equipment))
                {
                    DataModels.TechnologicalSchemeDataModel.TechnologicalSchemeDBContext context = new();

                    TextBox pk_tbx = this.Controls.Find("tb_0", true).FirstOrDefault() as TextBox;
                    var recordForEdit = context.Equipment.ToList().FirstOrDefault(x => x.Name == pk_tbx.Text);
                    EditRecordData(recordForEdit);
                    context.Entry(recordForEdit).State = EntityState.Modified;
                    context.SaveChanges();
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
