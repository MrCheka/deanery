using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Deanery.Forms;

namespace Deanery
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Authorization());
        }

        public static string GetConnectionString()
        {
            string connectionString = string.Empty;

            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings["DeaneryDbConnectionString"];

            if (settings != null)
                connectionString = settings.ConnectionString;

            return connectionString;
        }
    }
}
