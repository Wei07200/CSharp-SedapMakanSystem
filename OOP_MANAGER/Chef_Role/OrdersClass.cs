using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Security.Cryptography;

namespace OOP
{
    public class OrdersClass
    {
        public string ConnectionString = "Data Source=NE-NB-012;Initial Catalog=OOP;Integrated Security=True;";

        // Properties from OrderItems table
        public string OrderID { get; set; }
        public string CustomerID { get; set; }
        public string OrderDate { get; set; }
        public string TotalAMount { get; set; }
        public string OrderStatus { get; set; }

        //Property from OrderItems table
        public string OrderItemID { get; set; }
        public string ItemID { get; set; }
        public string Quantity { get; set; }


        // Constructors for OrdersClass
        public OrdersClass(string orderId, string customerId, string orderDate, string totalAmount, string orderStatus)
        {
            OrderID = orderId;
            CustomerID = customerId;
            OrderDate = orderDate;
            TotalAMount = totalAmount;
            OrderStatus = orderStatus;
        }

        public OrdersClass()
        {
        }

        // Load orders from the database 
        public static DataTable LoadOrders()
        {
            string con = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ToString();

            using (SqlConnection orders = new SqlConnection(con))
            {
                orders.Open();
                string query = "SELECT OrderID, CustomerID, OrderDate, TotalAmount, OrderStatus FROM Orders";
                SqlDataAdapter adapter = new SqlDataAdapter(query, orders);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Load Order with the status of "Cooking"
        public static DataTable LoadCookingOrders()
        {
            string con = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ToString();
            using (SqlConnection orders = new SqlConnection(con))
            {
                orders.Open();
                string query = "SELECT OrderID, CustomerID, OrderDate, TotalAmount, OrderStatus FROM Orders WHERE OrderStatus = 'Cooking'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, orders);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Load Order with the status of "Completed"
        public static DataTable LoadCompletedOrders()
        {
            string con = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ToString();
            using (SqlConnection orders = new SqlConnection(con))
            {
                orders.Open();
                string query = "SELECT OrderID, CustomerID, OrderDate, TotalAmount, OrderStatus FROM Orders WHERE OrderStatus = 'Completed'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, orders);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        //Load order with the status of "Cancelled"
        public static DataTable LoadCancelledOrders()
        {
            string con = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ToString();
            using (SqlConnection orders = new SqlConnection(con))
            {
                orders.Open();
                string query = "SELECT OrderID, CustomerID, OrderDate, TotalAmount, OrderStatus FROM Orders WHERE OrderStatus = 'Cancelled'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, orders);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Load order details by OrderId
        public static DataTable LoadOrderDetails(string OrderID)
        {
            string con = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ToString();
            using (SqlConnection details = new SqlConnection(con))
            {
                details.Open();
                string query = "SELECT oi.OrderItemID, oi.OrderID, mi.Name AS MenuItemName, oi.Quantity " +
                               "FROM OrderItems oi " +
                               "JOIN MenuItems mi ON oi.ItemID = mi.ItemID " +
                               "WHERE oi.OrderID = @OrderID";

                SqlCommand cmd = new SqlCommand(query, details);
                cmd.Parameters.AddWithValue("@OrderID", OrderID);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }

        //Update order status from Cooking to compleete
        public static bool UpdateOrderStatus(string orderId, string newStatus)
        {
            string con = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ToString();
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                string query = "UPDATE Orders SET OrderStatus = @status WHERE OrderID = @orderId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@orderId", orderId);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Get the status of a specific order
        public static string GetOrderStatus(string orderId)
        {
            string con = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ToString();
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                string query = "SELECT OrderStatus FROM Orders WHERE OrderID = @orderId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orderId", orderId);

                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : null;
            }
        }
    }
}
