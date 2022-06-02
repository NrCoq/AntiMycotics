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

using AntiMyco.Models.Users;

namespace AntiMyco
{
    public partial class AdminWindow : Form
    {
        enum TableType
        {
            Users = 0,
            Other
        }
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearTable();
            switch (comboBox1.SelectedIndex)
            {
                case (int)TableType.Users:
                    DrawUsersTable();
                    break;
                case 1:
                    break;

            }
        }
        private void ClearTable()
        {
            while (dataGridView1.Rows.Count > 0)
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    dataGridView1.Rows.Remove(dataGridView1.Rows[i]);

            dataGridView1.Rows.Clear();

            while (dataGridView1.Columns.Count > 0)
                for (int i = 0; i < dataGridView1.Columns.Count - 1; i++)
                    dataGridView1.Columns.Remove(dataGridView1.Columns[i]);

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
        }

        private void DrawUsersTable()
        {
            dataGridView1.AutoGenerateColumns = false;

            var col1 = new DataGridViewColumn(new DataGridViewHeaderCell());
            col1.CellTemplate = new DataGridViewTextBoxCell();
            col1.HeaderText = "Логин";
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView1.Columns.Add(col1);

            col1 = new DataGridViewColumn(new DataGridViewHeaderCell());
            col1.CellTemplate = new DataGridViewTextBoxCell();
            col1.HeaderText = "Пароль";
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns.Add(col1);

            col1 = new DataGridViewColumn(new DataGridViewHeaderCell());
            col1.CellTemplate = new DataGridViewTextBoxCell();
            col1.HeaderText = "Роль";
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns.Add(col1);

            using (UsersContext db = new UsersContext())
            {
                var users = db.Users.ToList();
                foreach (var user in users)
                {
                    dataGridView1.Rows.Add(user.Login, user.Password, user.Role);
                }
            }
        }
    }
}
