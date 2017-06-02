using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseConnectionLib
{
    public class DBConnectionLib
    {


        private static SqlConnection _connection;

        private static void DatabseConnection()
        {
            _connection = new SqlConnection(SqlQueryClassConnectionLib.DATABASE_CONNECTION_STRING);
        }

        public static SqlConnection GetDatabseConnection()
        {
            DatabseConnection();
            return _connection;
        }

        public static void GetItems(string sql, ref DataGridView dataGridView)
        {
            DatabseConnection();
            using (_connection)
            {
                _connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, _connection);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
            }
        }

    }
}
