using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class FeedbackManager
    {
        private string connectionString;

        public FeedbackManager()
        {
            // Get connection string from App.config
            connectionString = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ConnectionString;
        }

        // Method to retrieve feedback data
        public DataTable GetFeedbackData()
        {
            DataTable feedbackTable = new DataTable();
            string query = "SELECT * FROM Feedback";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(feedbackTable);
                    }
                }
                catch (Exception ex)
                {
                    // Optional: log or throw the exception
                    throw new Exception("Error loading feedback data: " + ex.Message);
                }
            }

            return feedbackTable;
        }
    }
}
    
