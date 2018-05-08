using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Deanery.Classes;

namespace Deanery.Forms
{
    public partial class Authorization : Form
    {
        private UserList _userList;

        public Authorization()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            User currentUser = _userList.Find(txtLogin.Text, txtPassword.Text);
            if (currentUser != null)
            {
                Service.CurrentUser = currentUser;
                var studentsForm = new Students();
                studentsForm.AddOwnedForm(this);
                Hide();
                studentsForm.Show();
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует!", "Ошибка!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            _userList = new UserList();
            _userList.Fill();
        }
    }
}
