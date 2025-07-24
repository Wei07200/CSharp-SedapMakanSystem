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
    public class CustomerView
    {
        private string connectionString;

        public CustomerView()
        {

            connectionString = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ConnectionString;
        }
        public DataTable GetRefundByOrderID(string orderId, string userId)
        {
            DataTable RefundOrder = new DataTable();
            string query = @"SELECT RefundID, UserID, OrderID, Status, RequestDate, TotalAmount 
                             FROM Refund 
                             WHERE OrderID = @OrderID AND UserID = @UserID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                cmd.Parameters.AddWithValue("@UserID", userId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(RefundOrder);
            }

            return RefundOrder;
        }

        public DataTable GetOrderID(string orderId, string userId)
        {
            DataTable orderData = new DataTable();

            string query = @"SELECT OrderID, CustomerID, OrderDate, TotalAmount, OrderStatus
                             FROM Orders 
                             WHERE OrderID = @OrderID AND CustomerID = @UserID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                cmd.Parameters.AddWithValue("@UserID", userId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(orderData);
            }

            return orderData;
        }
        public string GenerateRefundID()
        {
            string newId = "R01"; // Default if no refunds exist

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT TOP 1 RefundID FROM Refund ORDER BY RefundID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string lastId = result.ToString();           // e.g., R05
                    int number = int.Parse(lastId.Substring(1)); // extract "05" → 5
                    newId = $"R{(number + 1):D2}";               // new ID ex: R06
                }
            }

            return newId;
        }
        public bool InsertRefundRequest(string orderId, string userId)
        {
            bool success = false;

            string selectQuery = @"SELECT TotalAmount FROM Orders 
                           WHERE OrderID = @OrderID AND CustomerID = @UserID";

            string insertQuery = @"INSERT INTO Refund (RefundID, OrderID, UserID, Status, RequestDate, TotalAmount)
                           VALUES (@RefundID, @OrderID, @UserID, 'Pending', @RequestDate, @TotalAmount)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Step 1: Get TotalAmount
                SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
                selectCmd.Parameters.AddWithValue("@OrderID", orderId);
                selectCmd.Parameters.AddWithValue("@UserID", userId);

                object result = selectCmd.ExecuteScalar();

                if (result != null)
                {
                    decimal totalAmount = Convert.ToDecimal(result);
                    string refundId = GenerateRefundID(); // Use simplified method
                    DateTime requestDate = DateTime.Today;

                    // Step 2: Insert refund
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@RefundID", refundId);
                    insertCmd.Parameters.AddWithValue("@OrderID", orderId);
                    insertCmd.Parameters.AddWithValue("@UserID", userId);
                    insertCmd.Parameters.AddWithValue("@RequestDate", requestDate);
                    insertCmd.Parameters.AddWithValue("@TotalAmount", totalAmount);

                    success = insertCmd.ExecuteNonQuery() > 0;
                }
            }

            return success;
        }


    }
}
