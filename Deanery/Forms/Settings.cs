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
    public partial class Settings : Form
    {
        private UserList _userList;

        public Settings()
        {
            InitializeComponent();
            dgvUsers.AutoGenerateColumns = false;
            cmbRole.SelectedIndex = 2;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            if (Service.CurrentUser.Role != User.UserRole.Admin)
            {
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                dgvUsers.Visible = false;
                cmbRole.Visible = false;
                lblLogin.Location = new System.Drawing.Point(40, 54);
                lblPassword.Location = new System.Drawing.Point(40, 90);
                lblFio.Location = new System.Drawing.Point(40, 120);
                txtLogin.Location = new System.Drawing.Point(117, 48);
                txtPassword.Location = new System.Drawing.Point(117, 85);
                txtFio.Location = new System.Drawing.Point(117, 117);
                btnSave.Location = new System.Drawing.Point(240, 148);
                ClientSize = new System.Drawing.Size(341, 240);

                txtLogin.Text = Service.CurrentUser.Login;
                txtPassword.Text = Service.CurrentUser.Password;
                txtFio.Text = Service.CurrentUser.Fio;
            }


            _userList = new UserList();
            _userList.Fill();

            dgvUsers.DataSource = _userList.Value;
        }

        private void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtLogin.Text = dgvUsers[0, e.RowIndex].Value.ToString();
            txtPassword.Text = dgvUsers[1, e.RowIndex].Value.ToString();
            txtFio.Text = dgvUsers[2, e.RowIndex].Value.ToString();
            string role = dgvUsers[3, e.RowIndex].Value.ToString();
            if (role == User.UserRole.Admin.ToString())
                cmbRole.SelectedIndex = 0;
            else if (role == User.UserRole.Professor.ToString())
                cmbRole.SelectedIndex = 1;
            else if (role == User.UserRole.Student.ToString())
                cmbRole.SelectedIndex = 2;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == "" || txtPassword.Text == "" || txtFio.Text == "")
                MessageBox.Show("Не все поля заполнены!", "Ошибка!");
            else
            {
                var newUser = new User();
                newUser.Login = txtLogin.Text;
                newUser.Password = txtPassword.Text;
                newUser.Fio = txtFio.Text;
                newUser.Role = (User.UserRole)cmbRole.SelectedIndex;

                _userList.Add(newUser);

                dgvUsers.DataSource = typeof(List<User>);
                dgvUsers.DataSource = _userList.Value;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var removeUser = new User();
            removeUser.Login = txtLogin.Text;
            removeUser.Password = txtPassword.Text;
            removeUser.Fio = txtFio.Text;
            removeUser.Role = (User.UserRole)cmbRole.SelectedIndex;

            bool a = _userList.Remove(removeUser);
            dgvUsers.DataSource = typeof(List<User>);
            dgvUsers.DataSource = _userList.Value;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _userList.Update();
            dgvUsers.DataSource = typeof(List<User>);
            dgvUsers.DataSource = _userList.Value;
        }
    }
}
