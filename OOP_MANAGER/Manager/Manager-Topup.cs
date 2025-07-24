using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP
{
    public class Topup
    {
        private string connectionString;

        public Topup()
        {
            
            connectionString = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ConnectionString;
        }
        public string GenerateTransactionID()
        {
            string newId = "T001"; // Default starting ID if table is empty

            using (SqlConnection conn = new SqlConnection(connectionString)) // Open DB connection
            {
                conn.Open();
                string query = "SELECT TOP 1 TransactionID FROM EWalletTransactions ORDER BY TransactionID DESC"; // Get last used TransactionID
                SqlCommand cmd = new SqlCommand(query, conn);

                object result = cmd.ExecuteScalar(); // Execute the query and return the first value (top 1)

                if (result != null)
                {
                    string lastId = result.ToString();           // Example: T005
                    int number = int.Parse(lastId.Substring(1)); // Extract number part: 5
                    newId = $"T{(number + 1):D3}";               // Generate new ID: T006
                }
            }

            return newId; // Return new unique TransactionID
        }

        // Save a new top-up transaction to the database
        public bool SaveTransaction(string walletId, string type, decimal amount)
        {
            // Validate input fields
            if (string.IsNullOrEmpty(walletId) || string.IsNullOrEmpty(type) || amount <= 0)
                return false; // Return false if any input is invalid

            string transactionId = GenerateTransactionID(); // Auto-generate a new TransactionID
            DateTime transactionDate = DateTime.Today;      // Set transaction date to today's date

            using (SqlConnection conn = new SqlConnection(connectionString)) // Connect to database
            {
                conn.Open();
                string query = @"INSERT INTO EWalletTransactions (TransactionID, WalletID, Type, Amount, TransactionDate)
                         VALUES (@id, @wallet, @type, @amount, @date)"; // SQL query to insert new record

                SqlCommand cmd = new SqlCommand(query, conn); // Create command object with the query
                cmd.Parameters.AddWithValue("@id", transactionId);   // Bind transaction ID
                cmd.Parameters.AddWithValue("@wallet", walletId);    // Bind wallet ID
                cmd.Parameters.AddWithValue("@type", type);          // Bind payment type
                cmd.Parameters.AddWithValue("@amount", amount);      // Bind amount
                cmd.Parameters.AddWithValue("@date", transactionDate); // Bind date

                int rowsAffected = cmd.ExecuteNonQuery(); // Execute the insert command
                return rowsAffected > 0; // Return true if a row was inserted
            }
        }

        public decimal AddToWalletBalance(string walletId, decimal topupAmount)
        {
            decimal newBalance = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Get current balance
                string selectQuery = "SELECT Balance FROM EWallet WHERE WalletID = @WalletID";
                SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
                selectCmd.Parameters.AddWithValue("@WalletID", walletId);
                object result = selectCmd.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("EWallet not found.", "Top-up Error");
                    return 0;
                }

                decimal currentBalance = Convert.ToDecimal(result);
                newBalance = currentBalance + topupAmount;

                // Update balance
                string updateQuery = "UPDATE EWallet SET Balance = @Balance WHERE WalletID = @WalletID";
                SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@Balance", newBalance);
                updateCmd.Parameters.AddWithValue("@WalletID", walletId);
                updateCmd.ExecuteNonQuery();
            }

            return newBalance;
        }
        public bool WalletExists(string walletId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM EWallet WHERE WalletID = @WalletID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@WalletID", walletId);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

    }
}