using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public static class ReportRepository
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ConnectionString;

        public static DataTable LoadWalletReport()
        {
            string query = "SELECT * FROM WalletReport";
            return ExecuteQuery(query);
        }

        public static DataTable LoadSalesReport()
        {
            string query = "SELECT * FROM SalesReport";
            return ExecuteQuery(query);
        }

        private static DataTable ExecuteQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}
