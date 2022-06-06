using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AntiMyco.DataModels;
using Microsoft.EntityFrameworkCore;

namespace AntiMyco
{
    public partial class AdminWindow : Form
    {

        #warning Серега делай уже диплом!!

        enum TableType
        {
            Users = 0,
            Diseases,
            SideEffects,
            Precursors,
            Antimycotics
        }
        public AdminWindow()
        {
            InitializeComponent();
        }

        #region Вывод таблиц

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearTable();
            switch (comboBox1.SelectedIndex)
            {
                case (int)TableType.Users:
                    DrawUsersTable();
                    break;
                case (int)TableType.Diseases:
                    DrawDiseasesTable();
                    break;
                case (int)TableType.SideEffects:
                    DrawSideEffectsTable();
                    break;
                case (int)TableType.Precursors:
                    DrawPrecursorsTable();
                    break;
                case (int)TableType.Antimycotics:
                    DrawAntimycoticsTable();
                    break;

            }
        }
        private void ClearTable()
        {
            while (dataGridView1.Rows.Count > 0)
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    dataGridView1.Rows.Remove(dataGridView1.Rows[i]);

            dataGridView1.Rows.Clear();

            while (dataGridView1.Columns.Count > 0)
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    dataGridView1.Columns.Remove(dataGridView1.Columns[i]);

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
        }

        private void DrawUsersTable()
        {
            dataGridView1.AutoGenerateColumns = false;

            var col1 = new DataGridViewColumn(new DataGridViewHeaderCell())
            {
                CellTemplate = new DataGridViewImageCell(),
                HeaderText = "Логин",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            dataGridView1.Columns.Add(col1);

            col1 = new DataGridViewColumn(new DataGridViewHeaderCell())
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                HeaderText = "Пароль",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridView1.Columns.Add(col1);

            col1 = new DataGridViewColumn(new DataGridViewHeaderCell())
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                HeaderText = "Роль",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridView1.Columns.Add(col1);

            using (DataModels.Users.UsersContext db = new ())
            {
                var users = db.Users.ToList();
                foreach (var user in users)
                {
                    dataGridView1.Rows.Add(user.Login, user.Password, user.Role);
                }
            }
        }

        private void DrawDiseasesTable()
        {
            dataGridView1.AutoGenerateColumns = false;

            var col1 = new DataGridViewColumn(new DataGridViewHeaderCell())
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                HeaderText = "Наименование",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridView1.Columns.Add(col1);

            col1 = new DataGridViewColumn(new DataGridViewHeaderCell())
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                HeaderText = "Описание",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridView1.Columns.Add(col1);

            using DataModels.Antimycotics.AntimycoticsContext db = new();
            var diseases = db.Diseases.ToList();
            foreach (var disease in diseases)
            {
                dataGridView1.Rows.Add(disease.Name, disease.Description);
            }
        }

        private void DrawSideEffectsTable()
        {
            dataGridView1.AutoGenerateColumns = false;

            var col1 = new DataGridViewColumn(new DataGridViewHeaderCell())
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                HeaderText = "Описание",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridView1.Columns.Add(col1);

            using DataModels.Antimycotics.AntimycoticsContext db = new();
            var sideEffects = db.SideEffects.ToList();
            foreach (var sideEffect in sideEffects)
            {
                dataGridView1.Rows.Add(sideEffect.Description);
            }
        }
        private void DrawPrecursorsTable()
        {
            dataGridView1.AutoGenerateColumns = false;

            var col1 = new DataGridViewColumn(new DataGridViewHeaderCell())
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                HeaderText = "Наименование",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridView1.Columns.Add(col1);

            col1 = new DataGridViewColumn(new DataGridViewHeaderCell())
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                HeaderText = "SMILES",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridView1.Columns.Add(col1);

            using DataModels.Antimycotics.AntimycoticsContext db = new();
            var precursors = db.Precursors.ToList();
            foreach (var precursor in precursors)
            {
                dataGridView1.Rows.Add(precursor.Name, precursor.Smiles);
            }
        }
        private void DrawAntimycoticsTable()
        {
            dataGridView1.AutoGenerateColumns = false;

            var col1 = new DataGridViewColumn(new DataGridViewHeaderCell())
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                HeaderText = "Наименование",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridView1.Columns.Add(col1);

            col1 = new DataGridViewColumn(new DataGridViewHeaderCell())
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                HeaderText = "Прекурсор",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridView1.Columns.Add(col1);

            col1 = new DataGridViewColumn(new DataGridViewHeaderCell())
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                HeaderText = "SMILES",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridView1.Columns.Add(col1);

            col1 = new DataGridViewColumn(new DataGridViewHeaderCell())
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                HeaderText = "Свойства",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridView1.Columns.Add(col1);

            col1 = new DataGridViewColumn(new DataGridViewHeaderCell())
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                HeaderText = "Токсичность",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridView1.Columns.Add(col1);

            using DataModels.Antimycotics.AntimycoticsContext db = new();
            var antimycotics = db.Antimycotics.ToList();
            foreach (var antimycotic in antimycotics)
            {
                dataGridView1.Rows.Add(antimycotic.Name, antimycotic.Precursor.Name, antimycotic.Smiles, antimycotic.Properties, antimycotic.Toxicity);
            }
        }

        #endregion
        public class PropertyTemplate
        {
            public string RuName { get; set; }
            public string DbName { get; set; }
            public Type Type { get; set; }

            public string Value { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<PropertyTemplate> properties = new();
            PropertyTemplate property = null;
            RecordEdit form = null;

            switch (comboBox1.SelectedIndex)
            {
                case (int)TableType.Users:
                    DrawUsersTable();
                    break;
                case (int)TableType.Diseases:

                    property = new()
                    {
                        RuName = "Наименование",
                        DbName = "name",
                        Type = typeof(string),
                        Value = ""
                    };
                    properties.Add(property);

                    property = new()
                    {
                        RuName = "Описание",
                        DbName = "description",
                        Type = typeof(string),
                        Value = ""
                    };
                    properties.Add(property);

                    form = new RecordEdit(properties);
                    form.ShowDialog();

                    break;
                case (int)TableType.SideEffects:
                    DrawSideEffectsTable();
                    break;
                case (int)TableType.Precursors:
                    DrawPrecursorsTable();
                    break;
                case (int)TableType.Antimycotics:
                    property = new()
                    {
                        RuName = "Наименование",
                        DbName = "name",
                        Type = typeof(string),
                        Value = "name"
                    };
                    properties.Add(property);

                    property = new()
                    {
                        RuName = "Прекурсор",
                        DbName = "precursor_id",
                        Type = typeof(string),
                        Value = "some"
                    };
                    properties.Add(property);

                    property = new()
                    {
                        RuName = "SMILES",
                        DbName = "SMILES",
                        Type = typeof(string),
                        Value = "CCCCCC"
                    };
                    properties.Add(property);

                    property = new()
                    {
                        RuName = "Свойства",
                        DbName = "properties",
                        Type = typeof(string),
                        Value = "la-la-la"
                    };
                    properties.Add(property);

                    property = new()
                    {
                        RuName = "Токсичность",
                        DbName = "toxicity",
                        Type = typeof(double),
                        Value = "54.2"
                    };
                    properties.Add(property);

                    form = new RecordEdit(properties);
                    form.ShowDialog();
                    break;

            }
        }
    }
}
