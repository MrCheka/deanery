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
        private SqlConnection _connection;

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

            string request = " INSERT INTO Users " +
                   " (login, password, fio, role) " +
                   " VALUES ( " +
                   " @login, " +
                   " @password, " +
                   " @fio, " +
                   " @role) ";

            var command = new SqlCommand(request, _connection);

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
        }

        public bool Remove(User item)
        {
            string request = " DELETE FROM Users " +
                   " WHERE login = @login " +
                   " AND password = @password " +
                   " AND fio = @fio " +
                   " AND role = @role ";

            var command = new SqlCommand(request, _connection);

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

            command.ExecuteNonQuery();

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

        public void OpenConnection(string connectionString)
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = connectionString;
            _connection.Open();
        }

        public void CloseConnection()
        {
            _connection.Close();
        }

        public void Fill()
        {
            string request = " SELECT * FROM Users ";
            var command = new SqlCommand(request, _connection);
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    var newLogin = new User
                    {
                        Login = dataReader["login"].ToString(),
                        Password = dataReader["password"].ToString(),
                        Fio = dataReader["fio"].ToString()
                    };
                    if (Convert.ToInt32(dataReader["role"]) == 0)
                        newLogin.Role = User.UserRole.Admin;
                    else if (Convert.ToInt32(dataReader["role"]) == 1)
                        newLogin.Role = User.UserRole.Professor;
                    else if (Convert.ToInt32(dataReader["role"]) == 2)
                        newLogin.Role = User.UserRole.Student;

                    _userList.Add(newLogin);
                }
            }
        }

        public bool Update()
        {
            int num = 0;

            for (int i = 0; i < _userList.Count; i++)
            {
                string request = " UPDATE Users " +
                   " SET login = @login, " +
                   " password = @password, " +
                   " fio = @fio, " +
                   " role = @role " +
                   " WHERE login = @login ";

                var command = new SqlCommand(request, _connection);

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

                num += command.ExecuteNonQuery();
            }

            return num == 0;
        }
    }
}
