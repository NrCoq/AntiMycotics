using AntiMyco.Models.Users;
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

namespace AntiMyco
{
    public partial class AuthWindow : Form
    {
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
                    MessageBox.Show("success");
                }
                else MessageBox.Show("failed");
            }
        }
    }
}
