using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varonic.DataBase
{
    public class Commands
    {
        private static string SelectFromSourceLocations =
            "select [LocationOnDisk] from [Varonis-Test].[dbo].[SourceLocations] where Id = '{0}'";

        public string ConnectionString { get; }

        private Commands()
        {
            ConnectionString = ConfigurationManager.AppSettings["DataBaseConnectionString"];
        }

        /// <summary>
        /// Singleton
        /// </summary>
        private static Commands _instance = null;

        public static Commands Instance => _instance ?? (_instance = new Commands());

        public string GetPathCommand(string id)
        {


            try
            {
                var connection = new SqlConnection(ConnectionString);
                connection.Open();
                var command = new SqlCommand(string.Format(SelectFromSourceLocations, id), connection);
                var dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    return (string)dataReader.GetValue(0);
                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception when connect to Data base, Error message: {ex.Message}");
                return null;
            }
            return null;
        }
    }
}
