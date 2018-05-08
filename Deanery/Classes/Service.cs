using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Deanery.Classes
{
    public static class Service
    {
        public static User CurrentUser { get; set; }

        public static string GetConnectionString()
        {
            string connectionString = string.Empty;

            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings["DeaneryDbConnectionString"];

            if (settings != null)
                connectionString = settings.ConnectionString;

            return connectionString;
        }

        public static SqlConnection OpenConnection()
        {
            string connectionString = GetConnectionString();
            var connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
            }
            return connection;
        }

        public static void CloseConnection(SqlConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
            }
        }
    }
}
