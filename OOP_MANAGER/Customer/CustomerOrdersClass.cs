using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace OOP
{
    public class MyOrder
    {
        public string ItemID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Amount => Price * Quantity;

        public static string OrderID { get; set; }
        public static string OrderStatus { get; set; }






        public static class OrderManage
        {
            public static List<MyOrder> Cart = new List<MyOrder>();

            public static void AddToCart(string itemId, string name, decimal price)
            {
                var item = Cart.FirstOrDefault(i => i.ItemID == itemId);
                if (item != null)
                    item.Quantity++;
                else
                    Cart.Add(new MyOrder { ItemID = itemId, Name = name, Price = price, Quantity = 1 });
            }

            public static decimal GetTotal() => Cart.Sum(i => i.Amount);

            public static void ClearCart() => Cart.Clear();
        }
    }
    public class OrderProcessor
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ConnectionString;

        public string GenerateOrderID()
        {
            string newId = "O001";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT TOP 1 OrderID FROM Orders ORDER BY OrderID DESC"; 
                SqlCommand cmd = new SqlCommand(query, conn);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    string lastId = result.ToString(); // e.g., "O005"
                    if (int.TryParse(lastId.Substring(1), out int number))
                    {
                        newId = $"O{(number + 1):D3}";
                    } // Generate new ID with leading zeros
                }
            }
            return newId;
        }

        public string GenerateOrderItemID()
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT TOP 1 OrderItemID FROM OrderItems ORDER BY OrderItemID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);

                object result = cmd.ExecuteScalar();
                return result?.ToString(); // e.g., "OI027"
            }

        }

        public decimal GetWalletBalance(string customerId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Balance FROM EWallet WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", customerId);

                object result = cmd.ExecuteScalar();
                

                if (result == null)
                {
                    MessageBox.Show("Wallet not found for this user.");
                    return 0;
                }   
                return result != null ? Convert.ToDecimal(result) : 0;
            }
        }

        public void UpdateWalletBalance(string customerId, decimal newBalance)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE EWallet SET Balance = @Balance WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", customerId);
                cmd.Parameters.AddWithValue("@Balance", newBalance);
                cmd.ExecuteNonQuery();
            }
        }

        public string PlaceOrder(string customerId)
        {
            decimal total = MyOrder.OrderManage.GetTotal();
            decimal balance = GetWalletBalance(customerId);


            if (balance < total)
            {
                MessageBox.Show("Insufficient balance.");
                return null;
            }

            string orderId = GenerateOrderID();
            List<MyOrder> cart = MyOrder.OrderManage.Cart;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Insert Order
                    SqlCommand orderCmd = new SqlCommand("INSERT INTO Orders (OrderID, CustomerID, OrderDate, TotalAmount, OrderStatus) VALUES (@OrderID, @CustomerID, @OrderDate, @TotalAmount, @OrderStatus)", conn, transaction);
                    orderCmd.Parameters.AddWithValue("@OrderID", orderId);
                    orderCmd.Parameters.AddWithValue("@CustomerID", customerId);
                    orderCmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    orderCmd.Parameters.AddWithValue("@TotalAmount", total);
                    orderCmd.Parameters.AddWithValue("@OrderStatus", "In Progress");
                    orderCmd.ExecuteNonQuery();

                    // Insert Order Items

                    string lastId = GenerateOrderItemID(); // Custom helper
                    int baseNumber = 0;
                    if (!string.IsNullOrEmpty(lastId) && int.TryParse(lastId.Substring(2), out int lastNumber))
                    {
                        baseNumber = lastNumber;
                    }
                    foreach (var item in cart)
                    {
                        baseNumber++;
                        string orderItemId = $"OI{baseNumber:D3}";

                        SqlCommand itemCmd = new SqlCommand("INSERT INTO OrderItems (OrderItemID, OrderID, ItemID, Quantity) VALUES (@OrderItemID, @OrderID, @ItemID, @Quantity)", conn, transaction);
                        itemCmd.Parameters.AddWithValue("@OrderItemID", orderItemId);
                        itemCmd.Parameters.AddWithValue("@OrderID", orderId);
                        itemCmd.Parameters.AddWithValue("@ItemID", item.ItemID);
                        itemCmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                        itemCmd.ExecuteNonQuery();
                    }

                    // Deduct Wallet Balance
                    decimal newBalance = balance - total;
                    UpdateWalletBalance(customerId, newBalance);

                    transaction.Commit();
                    MyOrder.OrderManage.ClearCart();
                    return orderId;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Error placing order: {ex.Message}");
                    return null;
                }

            }


        }


    }

}
