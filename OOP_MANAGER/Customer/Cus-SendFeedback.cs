using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OOP
{
    public class SendFeedback
    {
        private string connectionString;

        public SendFeedback()
        {
            
            connectionString = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ConnectionString;
        }
        public string GenerateFeedbackID()
        {
            string lastId = null;
            string newId = "F001";

            string query = "SELECT TOP 1 FeedbackID FROM Feedback ORDER BY FeedbackID DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    lastId = result.ToString(); // e.g., "F015"
                    int number = int.Parse(lastId.Substring(1)) + 1;
                    newId = "F" + number.ToString("D3");
                }
            }

            return newId;
        }
        public bool InsertFeedback(string userId, int rating, string comment)
        {
            if (string.IsNullOrWhiteSpace(userId) || rating < 1 || rating > 5)
                throw new ArgumentException("Invalid input");

            string feedbackId = GenerateFeedbackID();
            string query = "INSERT INTO Feedback (FeedbackID, UserID, Feedback, Date, Response, Rating) " +
                           "VALUES (@FeedbackID, @UserID, @Comment, @Date, NULL, @Rating)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@FeedbackID", feedbackId);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@Comment", comment);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                cmd.Parameters.AddWithValue("@Rating", rating);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
