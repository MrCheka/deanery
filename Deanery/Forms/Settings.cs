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
        private int _selectedUserId;

        public Settings()
        {
            _selectedUserId = 0;
            InitializeComponent();
            dgvUsers.AutoGenerateColumns = false;
            cmbRole.SelectedIndex = 2;
            RoleColumn.CellTemplate = new UserRoleDGVTextBoxCell();
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
            _selectedUserId = Convert.ToInt32(dgvUsers[0, e.RowIndex].Value);
            txtLogin.Text = dgvUsers[1, e.RowIndex].Value.ToString();
            txtPassword.Text = dgvUsers[2, e.RowIndex].Value.ToString();
            txtFio.Text = dgvUsers[3, e.RowIndex].Value.ToString();
            cmbRole.SelectedIndex = Convert.ToInt32(dgvUsers[4, e.RowIndex].Value);
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
                _userList.Fill();

                dgvUsers.DataSource = typeof(List<User>);
                dgvUsers.DataSource = _userList.Value;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvUsers.SelectedRows;
            for (int i = 0; i < selectedRows.Count; i++)
            {
                var removeUser = new User();
                removeUser.UserId = Convert.ToInt32(selectedRows[i].Cells[0].Value);
                _userList.Remove(removeUser);
            }

            txtLogin.Text = "";
            txtPassword.Text = "";
            txtFio.Text = "";
            cmbRole.SelectedIndex = 2;

            dgvUsers.DataSource = typeof(List<User>);
            dgvUsers.DataSource = _userList.Value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Service.CurrentUser.Role != User.UserRole.Admin)
            {
                if (txtLogin.Text == "" || txtPassword.Text == "" || txtFio.Text == "")
                    MessageBox.Show("Не все поля заполнены!", "Ошибка!");
                else
                {
                    User oldUser = _userList.Find(Service.CurrentUser);
                    oldUser.Login = txtLogin.Text;
                    oldUser.Password = txtPassword.Text;
                    oldUser.Fio = txtFio.Text;
                    oldUser.Role = (User.UserRole)cmbRole.SelectedIndex;

                    _userList.Update();
                }
            }
            else
            {
                var editedUser = new User();
                editedUser.Login = txtLogin.Text;
                editedUser.Password = txtPassword.Text;
                editedUser.Fio = txtFio.Text;
                editedUser.Role = (User.UserRole)cmbRole.SelectedIndex;

                _userList.Replace(_selectedUserId, editedUser);
                _userList.Update();
            }
            if (_selectedUserId == Service.CurrentUser.UserId)
                _userList.SetNewCurrentUser();
            dgvUsers.DataSource = typeof(List<User>);
            dgvUsers.DataSource = _userList.Value;
        }
    }

    public class UserRoleDGVTextBoxCell : DataGridViewTextBoxCell
    {
        protected override object GetFormattedValue(object value,
            int rowIndex,
            ref DataGridViewCellStyle cellStyle,
            TypeConverter valueTypeConverter,
            TypeConverter formattedValueTypeConverter,
            DataGridViewDataErrorContexts context)
        {
            User.UserRole role = (User.UserRole)(int)value;
            switch (role)
            {
                case User.UserRole.Admin: return "Сотрудник деканата";
                case User.UserRole.Professor: return "Преподаватель";
                case User.UserRole.Student: return "Студент";
                default: throw new NotImplementedException();
            };
        }
    }
}
