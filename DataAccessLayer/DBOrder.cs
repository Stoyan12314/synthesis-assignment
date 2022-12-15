using BuisnessLogicLayer;
using DataAccessLayer.Interfaces;
using Entities;
using Entities.Enum;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class DBOrder : DataAccess, IDBOrder
    {
        public bool CreateOrder(Order order)
        {
            try
            {
                con.Open();
                string sql = "insert into orders (userId, order_date, delivery_option ,delivery_date, order_status, ship_address, ship_city, ship_postal_code, ship_country ) values( @userId, @order_date, @delivery_option, @delivery_date, @order_status, @ship_address, @ship_city, @ship_postal_code, @ship_country);";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("userId", order.userId);
                cmd.Parameters.AddWithValue("order_date", order.OrderDate);
                cmd.Parameters.AddWithValue("delivery_option", order.DeliveryOption.ToString());
                cmd.Parameters.AddWithValue("delivery_date", order.DeliveryDate);
                cmd.Parameters.AddWithValue("order_status", order.DeliveryStatus.ToString());
                cmd.Parameters.AddWithValue("ship_address", order.shipAddress);
                cmd.Parameters.AddWithValue("ship_city", order.shipCity);
                cmd.Parameters.AddWithValue("ship_postal_code", order.shipPostCode);
                cmd.Parameters.AddWithValue("ship_country", order.shipCountry);
                cmd.ExecuteNonQuery();
                int orderId  =  (int)cmd.LastInsertedId;
                this.con.Close();
                AddOrderDetail(order, orderId);
                

                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally 
            {
                this.con.Close();
            }
           
        }
        public void AddOrderDetail(Order order, int orderId)
        {
            try
            {
              
                foreach (OrderedItem item in order.orderedItems)
                {
                    con.Open();
                    string sql = "insert into orderdetail (order_id, item_id, quantity) values(@order_id, @item_id, @quantity)";
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("order_id", orderId);
                    cmd.Parameters.AddWithValue("item_id", item.item.id);
                    cmd.Parameters.AddWithValue("quantity", item.quantity);
                    cmd.ExecuteNonQuery();
                    this.con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                this.con.Close();   
            }
        }
       
        public List<Order> GetOrders(int limit)
        {
            try
            {
                con.Open();
                List<Order> orders = new List<Order>();
                var cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * from orders ORDER BY order_id LIMIT @limit;";
                cmd.Parameters.AddWithValue("limit", limit);
                MySqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    DeliveryOption deliveryOption = Enum.Parse<DeliveryOption>(dr.GetString("delivery_option"));
                    DeliveryStatus deliveryStatus = Enum.Parse<DeliveryStatus>(dr.GetString("order_status"));
                    orders.Add(new Order(dr.GetInt32("order_id"), dr.GetInt32("userId"), dr.GetDateTime("order_date"), dr.GetDateTime("delivery_date"), deliveryOption, deliveryStatus, dr.GetString("ship_address"), dr.GetString("ship_city"), dr.GetString("ship_postal_code"), dr.GetString("ship_country")));
                }
                return orders;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                this.con.Close();
            }
        }
        public Order GetOrder(int id)
        {
            try
            {
                Order order = null;
                con.Open();
                string sql = "select * from orders where order_id = @order_id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("order_id", id);
                MySqlDataReader dr = cmd.ExecuteReader();
                byte[] picture = null;
                if (dr.Read())
                {
                    DeliveryOption deliveryOption = Enum.Parse<DeliveryOption>(dr.GetString("delivery_option"));
                    DeliveryStatus deliveryStatus = Enum.Parse<DeliveryStatus>(dr.GetString("order_status"));
                    order = new Order(dr.GetInt32("order_id"), dr.GetInt32("userId"), dr.GetDateTime("order_date"), dr.GetDateTime("delivery_date"), deliveryOption, deliveryStatus, dr.GetString("ship_address"), dr.GetString("ship_city"), dr.GetString("ship_postal_code"), dr.GetString("ship_country"));
                }
                return order;
            }
            catch (Exception)
            {

                throw;
            }
            finally 
            {
                this.con.Close();
            }
        }

        public void UpgradeOrder(DeliveryStatus status, int order_id)
        {
            try
            {
                    
                    this.con.Open();
                    var cmd = new MySqlCommand("UPDATE orders SET order_status = @order_status WHERE order_id = @order_id", con);
                    cmd.Parameters.AddWithValue("@order_status", status);
                    cmd.Parameters.AddWithValue("@order_id", order_id);
                    cmd.ExecuteNonQuery();
                    
            }
            catch (Exception)
            {
                throw;
            }
            finally 
            { 
                con.Close(); 
            }
        }
    }
}
