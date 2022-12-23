using BuisnessLogicLayer;
using DataAccessLayer.Interfaces;
using Entities;
using Entities.Enum;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                string sql = "insert into orders (user_id, order_date, delivery_option ,delivery_date, order_status, ship_address, ship_city, ship_postal_code, ship_country ) values( @user_id, @order_date, @delivery_option, @delivery_date, @order_status, @ship_address, @ship_city, @ship_postal_code, @ship_country);";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("user_id", order.userId);
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
        private void AddOrderDetail(Order order, int orderId)
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
                    orders.Add(new Order(dr.GetInt32("order_id"), dr.GetInt32("user_id"), dr.GetDateTime("order_date"), dr.GetDateTime("delivery_date"), deliveryOption, deliveryStatus, dr.GetString("ship_address"), dr.GetString("ship_city"), dr.GetString("ship_postal_code"), dr.GetString("ship_country")));
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
                    order = new Order(dr.GetInt32("order_id"), dr.GetInt32("user_id"), dr.GetDateTime("order_date"), dr.GetDateTime("delivery_date"), deliveryOption, deliveryStatus, dr.GetString("ship_address"), dr.GetString("ship_city"), dr.GetString("ship_postal_code"), dr.GetString("ship_country"));
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
                    cmd.Parameters.AddWithValue("@order_status", status.ToString());
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
        
        public List<Order> GetUsersOrders(int userId)
        {
            try
            {
                con.Open();
                List<OrderedItem> orderedItems = new List<OrderedItem>();
                List<Order> orders = new List<Order>();
                var cmd = con.CreateCommand();
                cmd.CommandText = "select r.order_date, r.delivery_date, r.order_id, r.delivery_option, r.order_status, r.ship_address, r.ship_city, r.ship_postal_code, r.ship_country, o.item_id, o.quantity, i.item_image, i.Name, i.Price, i.Unit, i.amount, i.description, s.subCategory_id, s.subCatName, c.category_id, c.category from orderdetail as o inner join item as i on o.item_id = i.item_id inner join categories as c on i.category_id = c.category_id inner join subcategory as s on s.subCategory_id = i.subCategory_id inner join orders as r on o.order_id = r.order_id where r.user_id = @user_id";
                cmd.Parameters.AddWithValue("user_id",userId);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //string unit = dr.GetString("Unit");
                    //UnitType unitType = Enum.Parse<UnitType>(unit);
                    //byte[] picture = (byte[])dr["item_image"];
                    //Item item = new Item(dr.GetInt32("item_id"), dr.GetString("Name"), new SubCategory(dr.GetInt32("subCategory_id"), dr.GetString("subCatName")), new Category(dr.GetInt32("category_id"), dr.GetString("category")), unitType, dr.GetDouble("Price"), dr.GetInt32("amount"), picture, dr.GetString("description"));
                    //orderedItems.Add(new OrderedItem(item, dr.GetInt32("quantity")));



                    DeliveryOption deliveryOption = Enum.Parse<DeliveryOption>(dr.GetString("delivery_option"));
                    DeliveryStatus deliveryStatus = Enum.Parse<DeliveryStatus>(dr.GetString("order_status"));
                    Order order = new Order(dr.GetInt32("order_id"), userId, dr.GetDateTime("order_date"), dr.GetDateTime("delivery_date"), deliveryOption, deliveryStatus, dr.GetString("ship_address"), dr.GetString("ship_city"), dr.GetString("ship_postal_code"), dr.GetString("ship_country"));
                    
                    orders.Add(order);
                  
                }
               
                return orders;
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
        public List<OrderedItem> GetOrderedItems(int orderId)
        {
           
            try
            {
                con.Open();
                List<OrderedItem> orderedItems = new List<OrderedItem>();
                var cmd = con.CreateCommand();
                cmd.CommandText = "select o.item_id, o.quantity, i.item_image, i.Name, i.Price, i.Unit, i.amount, i.description, s.subCategory_id, s.subCatName, c.category_id, c.category from orderdetail as o inner join item as i on o.item_id = i.item_id inner join categories as c on i.category_id = c.category_id inner join subcategory as s on s.subCategory_id = i.subCategory_id where o.order_id = @order_id";
                cmd.Parameters.AddWithValue("order_id", orderId);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string unit = dr.GetString("Unit");
                    UnitType unitType = Enum.Parse<UnitType>(unit);
                    byte[] picture = (byte[])dr["item_image"];
                    Item item = new Item(dr.GetInt32("item_id"), dr.GetString("Name"), new SubCategory(dr.GetInt32("subCategory_id"), dr.GetString("subCatName")), new Category(dr.GetInt32("category_id"), dr.GetString("category")), unitType, dr.GetDouble("Price"), dr.GetInt32("amount"), picture, dr.GetString("description"));
                    orderedItems.Add(new OrderedItem(item,dr.GetInt32("quantity")));
                }
                return orderedItems;
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

        public bool ReturnOrderedItem(int itemId, int quantity, int orderId,string reason)
        {
            try
            {
				con.Open();
				string sql = "insert into returned_order_detail (order_id,item_id, quantity,reason_for_return ) values( @order_id, @item_id, @quantity,  @reason_for_return);";
				MySqlCommand cmd = new MySqlCommand(sql, con);
				cmd.Parameters.AddWithValue("order_id", orderId);
				cmd.Parameters.AddWithValue("item_id", itemId);
                cmd.Parameters.AddWithValue("quantity", quantity);
                cmd.Parameters.AddWithValue("reason_for_return", reason);
				
				cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                string mySql = "Delete from orderdetail where item_id=@item_id and order_id = @order_id";
                MySqlCommand c = new MySqlCommand(mySql, con);
                c.Parameters.AddWithValue("order_id", orderId);
                c.Parameters.AddWithValue("item_id", itemId);
                c.ExecuteNonQuery();
                return true;
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
