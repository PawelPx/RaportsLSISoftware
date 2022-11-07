using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaportsLSISoftware
{
    internal class DataAccess
    {
        private static string connectionString = ConfigurationManager.AppSettings["connectionString"];
        public SqlConnection connection = new SqlConnection(connectionString);
        public void ExecuteCommand(string text)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(text, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<DbDataRecord> ReadData(string text)
        {
            List<DbDataRecord> list = new List<DbDataRecord>();
            connection.Open();
            SqlCommand command = new SqlCommand(text, connection);
            command.ExecuteNonQuery();
            using (DbDataReader dataReader = command.ExecuteReader())
            {
                foreach (DbDataRecord row in dataReader)
                {
                    list.Add(row);
                }
            }
            connection.Close();
            return list;
        }
    }
}
