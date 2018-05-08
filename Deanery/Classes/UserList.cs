using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using Deanery.Interfaces;

namespace Deanery.Classes
{
    public class UserList: IMyList<User>
    {
        private List<User> _userList;

        public List<User> Value
        {
            get { return _userList; }
        }

        public UserList()
        {
            _userList = new List<User>();
        }

        public void Add(User item)
        {
            if (Find(item) != null)
                return;

            SqlConnection connection = Service.OpenConnection();

            string request = " INSERT INTO Users " +
                   " (login, password, fio, role) " +
                   " VALUES ( " +
                   " @login, " +
                   " @password, " +
                   " @fio, " +
                   " @role) ";

            var command = new SqlCommand(request, connection);

            var parameter = new SqlParameter();
            parameter.ParameterName = "@login";
            parameter.Value = item.Login;
            parameter.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@password";
            parameter.Value = item.Password;
            parameter.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@fio";
            parameter.Value = item.Fio;
            parameter.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@role";
            parameter.Value = item.Role;
            parameter.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(parameter);

            if (command.ExecuteNonQuery() != 0)
                _userList.Add(item);

            Service.CloseConnection(connection);
        }

        public bool Remove(User item)
        {
            SqlConnection connection = Service.OpenConnection();

            if (item.UserId == 0)
                return _userList.Remove(item);

            string request = " DELETE FROM Users " +
                   " WHERE user_id = @user_id ";

            var command = new SqlCommand(request, connection);

            var parameter = new SqlParameter();
            parameter.ParameterName = "@user_id";
            parameter.Value = item.UserId;
            parameter.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(parameter);

            command.ExecuteNonQuery();

            Service.CloseConnection(connection);

            return _userList.Remove(item);
        }

        public bool RemoveAt(int index)
        {
            return Remove(_userList[index]);
        }

        public User Find(User item)
        {
            return _userList.Find(i => i == item);
        }

        public User Find(string login, string password)
        {
            var findingUser = new User(login, password);
            return _userList.Find(i => i == findingUser);
        }

        public int FindIndex(User item)
        {
            return _userList.FindIndex(i => i == item);
        }

        public void Fill()
        {
            SqlConnection connection = Service.OpenConnection();

            string request = " SELECT * FROM Users ";
            var command = new SqlCommand(request, connection);
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    var newUser = new User
                    {
                        UserId = Convert.ToInt32(dataReader["user_id"]),
                        Login = dataReader["login"].ToString(),
                        Password = dataReader["password"].ToString(),
                        Fio = dataReader["fio"].ToString()
                    };
                    if (Convert.ToInt32(dataReader["role"]) == 0)
                        newUser.Role = User.UserRole.Admin;
                    else if (Convert.ToInt32(dataReader["role"]) == 1)
                        newUser.Role = User.UserRole.Professor;
                    else if (Convert.ToInt32(dataReader["role"]) == 2)
                        newUser.Role = User.UserRole.Student;

                    _userList.Add(newUser);
                }
            }

            Service.CloseConnection(connection);
        }

        public bool Update()
        {
            int num = 0;

            SqlConnection connection = Service.OpenConnection();
            SqlTransaction transaction = connection.BeginTransaction();

            for (int i = 0; i < _userList.Count; i++)
            {
                if (_userList[i].UserId != 0)
                {
                    string request = " UPDATE Users " +
                   " SET login = @login, " +
                   " password = @password, " +
                   " fio = @fio, " +
                   " role = @role " +
                   " WHERE user_id = @user_id ";

                    var command = new SqlCommand
                    {
                        Transaction = transaction,
                        CommandText = request
                    };

                    var parameter = new SqlParameter();
                    parameter.ParameterName = "@login";
                    parameter.Value = _userList[i].Login;
                    parameter.SqlDbType = SqlDbType.VarChar;
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter();
                    parameter.ParameterName = "@password";
                    parameter.Value = _userList[i].Password;
                    parameter.SqlDbType = SqlDbType.VarChar;
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter();
                    parameter.ParameterName = "@fio";
                    parameter.Value = _userList[i].Fio;
                    parameter.SqlDbType = SqlDbType.VarChar;
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter();
                    parameter.ParameterName = "@role";
                    parameter.Value = _userList[i].Role;
                    parameter.SqlDbType = SqlDbType.Int;
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter();
                    parameter.ParameterName = "@user_id";
                    parameter.Value = _userList[i].UserId;
                    parameter.SqlDbType = SqlDbType.Int;
                    command.Parameters.Add(parameter);

                    num += command.ExecuteNonQuery();
                }
                else
                    Add(_userList[i]);
            }

            try
            {
                transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
                transaction.Rollback();
            }

            Service.CloseConnection(connection);

            return num == 0;
        }
    }
}
