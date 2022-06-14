
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
using AntiMyco.AdminModule;
using AntiMyco.ExplorerModule;
using AntiMyco.DataModels.Users;

namespace AntiMyco
{
    public partial class AuthWindow : Form
    {
        enum Roles
        {
            Admin = 1,
            Designer,
            Explorer
        }
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (UsersContext db = new UsersContext())
            {
                var passwordBytes = ASCIIEncoding.ASCII.GetBytes(Password_tb.Text);
                var passwordHash = ASCIIEncoding.ASCII.GetString(SHA256.HashData(passwordBytes));

                User user = db.Users.FirstOrDefault(user => user.Login == Login_tb.Text && user.Password == passwordHash);
                if  (user != null)
                {

                    switch (user.RoleId)
                    {
                        case (int)Roles.Admin:
                            this.Hide();
                            var adminForm = new AdminWindow();
                            adminForm.Closed += (s, args) => this.Close();
                            adminForm.Show();
                            break;

                        case (int)Roles.Designer:
                            this.Hide();
                            var designerForm = new TechnologicalSchemeModule.Overview();
                            designerForm.Closed += (s, args) => this.Close();
                            designerForm.Show();
                            break;
                        case (int)Roles.Explorer:
                            this.Hide();
                            var explorerForm = new ExplorerWindow();
                            explorerForm.Closed += (s, args) => this.Close();
                            explorerForm.Show();
                            break;

                    }
                       
                }
                else MessageBox.Show("Неверный логин и/или пароль!");
            }
        }
    }
}
