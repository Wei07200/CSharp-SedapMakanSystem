using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP
{
    public class ManageRefund
    {
        private string connectionString;

        public ManageRefund()
        {
            // Get connection string from App.config
            connectionString = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ConnectionString;
        }

        // Method to retrieve feedback data
        public DataTable GetRefundData()
        {
            DataTable RefundTable = new DataTable();
            string query = "SELECT * FROM Refund";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(RefundTable);
                    }
                }
                catch (Exception ex)
                {
                    // Optional: log or throw the exception
                    throw new Exception("Error loading refund data: " + ex.Message);
                }
            }

            return RefundTable;
        }

        public void ProcessRefund(string refundId, string status)
        {
            // Validate inputs
            if (string.IsNullOrEmpty(refundId) || (status != "Approved" && status != "Rejected"))
            {
                MessageBox.Show("Invalid input. Please enter a valid Refund ID and select a status.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();  // Open connection

                // Step 1: Retrieve the refund record
                string selectQuery = "SELECT * FROM Refund WHERE RefundID = @RefundID";
                SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
                selectCmd.Parameters.AddWithValue("@RefundID", refundId);

                SqlDataReader reader = selectCmd.ExecuteReader();

                if (!reader.Read())  // Check if refund exists
                {
                    MessageBox.Show("Refund ID not found.");
                    return;
                }

                // Step 2: Check if already processed
                string currentStatus = reader["Status"].ToString();
                if (currentStatus == "Approved" || currentStatus == "Rejected")
                {
                    MessageBox.Show("This refund has already been processed.");
                    return;
                }

                // Retrieve OrderID and TotalAmount from Refund
                string orderId = reader["OrderID"].ToString();
                decimal amount = Convert.ToDecimal(reader["TotalAmount"]);
                reader.Close();  // Close reader before running another query

                // Step 3: If Approved, process wallet update
                if (status == "Approved")
                {
                    // Retrieve UserID using OrderID from Orders table
                    string getUserQuery = "SELECT CustomerID FROM Orders WHERE OrderID = @OrderID";
                    SqlCommand userCmd = new SqlCommand(getUserQuery, conn);
                    userCmd.Parameters.AddWithValue("@OrderID", orderId);
                    string userId = userCmd.ExecuteScalar()?.ToString();

                    if (string.IsNullOrEmpty(userId))
                    {
                        MessageBox.Show("User not found for the order.");
                        return;
                    }

                    // Retrieve the current wallet balance
                    string getWalletQuery = "SELECT Balance FROM EWallet WHERE UserID = @UserID";
                    SqlCommand walletCmd = new SqlCommand(getWalletQuery, conn);
                    walletCmd.Parameters.AddWithValue("@UserID", userId);

                    object walletBalance = walletCmd.ExecuteScalar();
                    if (walletBalance == null)
                    {
                        MessageBox.Show("EWallet not found.");
                        return;
                    }

                    // Add refund amount to the current balance
                    decimal currentBalance = Convert.ToDecimal(walletBalance);
                    decimal newBalance = currentBalance + amount;

                    // Update Wallet with the new balance
                    string updateWallet = "UPDATE EWallet SET Balance = @Balance WHERE UserID = @UserID";
                    SqlCommand updateCmd = new SqlCommand(updateWallet, conn);
                    updateCmd.Parameters.AddWithValue("@Balance", newBalance);
                    updateCmd.Parameters.AddWithValue("@UserID", userId);
                    updateCmd.ExecuteNonQuery();  // Execute wallet update
                }

                // Step 4: Update refund status in the Refund table
                string updateRefund = "UPDATE Refund SET Status = @Status WHERE RefundID = @RefundID";
                SqlCommand updateStatusCmd = new SqlCommand(updateRefund, conn);
                updateStatusCmd.Parameters.AddWithValue("@Status", status);
                updateStatusCmd.Parameters.AddWithValue("@RefundID", refundId);
                updateStatusCmd.ExecuteNonQuery();

                // Step 5: Show confirmation to user
                MessageBox.Show($"Refund {refundId} has been {status.ToLower()}.");
            }
        }
    }
}
