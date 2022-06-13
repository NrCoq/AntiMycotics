
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
                var loginBytes = ASCIIEncoding.ASCII.GetBytes(Login_tb.Text);
                var passwordBytes = ASCIIEncoding.ASCII.GetBytes(Password_tb.Text);

                var loginHash = ASCIIEncoding.ASCII.GetString(SHA256.HashData(loginBytes)); 
                var passwordHash = ASCIIEncoding.ASCII.GetString(SHA256.HashData(passwordBytes));

                User user = db.Users.FirstOrDefault(user => user.Login == loginHash && user.Password == passwordHash);
                if  (user != null)
                {
                    switch (user.RoleId)
                    {
                        case (int)Roles.Admin:
                            AdminWindow form = new AdminWindow();
                            form.ShowDialog();
                            this.Close();
                            break;

                        case (int)Roles.Designer:
                            AdminWindow form1 = new AdminWindow();
                            form1.ShowDialog();
                            this.Close();
                            break;
                        case (int)Roles.Explorer:
                            ExplorerWindow form2 = new ExplorerWindow();
                            this.Close();
                            form2.ShowDialog();
                            this.Close();
                            break;

                    }
                       
                }
                else MessageBox.Show("failed");
            }
        }
    }
}
