using Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using DataAccessLayer.Interfaces;
using Entities.Enum;

namespace DataAccessLayer
{
    public class DBItem: DataAccess, IDBItem
    {
        public bool CreateItem(Item item)
        {
            try
            {


                con.Open();
                string sql = "insert into item (Name, item_image, SubCategory, Category ,Price,Unit, amount, description ) values( @Name, @item_image, @SubCategory, @Category, @Price, @Unit, @amount, @description);";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("Name", item.name);
                cmd.Parameters.AddWithValue("item_image", item.image);
                cmd.Parameters.AddWithValue("SubCategory", item.subCategory);
                cmd.Parameters.AddWithValue("Category", item.category);
                cmd.Parameters.AddWithValue("Price", item.price);
                cmd.Parameters.AddWithValue("Unit", item.unit.ToString());
                cmd.Parameters.AddWithValue("amount", item.amount);
                cmd.Parameters.AddWithValue("description", item.description);
                cmd.ExecuteNonQuery();
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
        public bool DeleteItem(int id) 
        {
            try
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "DELETE from item where item_id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
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
        public Item GetItemWith(int id)
        {
            try
            {
                con.Open();
                Item item = null;
                var cmd = con.CreateCommand();
                cmd.CommandText = "Select * from item where item_id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader dr = cmd.ExecuteReader();
                byte[] picture = null;
                if (dr.Read())
                {
                    picture = (byte[])dr["item_image"];
                    UnitType unitType = Enum.Parse<UnitType>(dr.GetString("Unit"));
                    item = new Item(dr.GetInt32("item_id"), dr.GetString("Name"), dr.GetString("SubCategory"), dr.GetString("Category"), unitType, dr.GetDouble("Price"),  dr.GetInt32("amount"), picture, dr.GetString("description"));
                }
                return item;
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
        public void UpdateItem(int id, Item item)
        {
            try
            {
                con.Open();
                var cmd = new MySqlCommand("UPDATE item SET item_image = @item_image, Name = @item_name, SubCategory = @SubCategory, Category = @Category, Price = @Price, Unit = @Unit, amount= @amount, description = @description WHERE item_id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@item_image", item.image);
                cmd.Parameters.AddWithValue("@item_name", item.name);
                cmd.Parameters.AddWithValue("@SubCategory", item.subCategory);
                cmd.Parameters.AddWithValue("@Category", item.category);
                cmd.Parameters.AddWithValue("@Price", item.price);
                cmd.Parameters.AddWithValue("@Unit", item.unit.ToString());
                cmd.Parameters.AddWithValue("@amount", item.amount);
                cmd.Parameters.AddWithValue("@description", item.description);
                cmd.ExecuteNonQuery();
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
        public List<Item> GetAllItems()
        {
            try
            {
                con.Open();
               List<Item> items = new List<Item>();
                var cmd = con.CreateCommand();
                cmd.CommandText = "Select * from item";
                MySqlDataReader dr = cmd.ExecuteReader();
                byte[] picture = null;
                while (dr.Read())
                {
                    picture = (byte[])dr["item_image"];
                    UnitType unitType = Enum.Parse<UnitType>(dr.GetString("Unit"));
                    items.Add(new Item(dr.GetInt32("item_id"), dr.GetString("Name"), dr.GetString("SubCategory"), dr.GetString("Category"), unitType, dr.GetDouble("Price"), dr.GetInt32("amount"), picture, dr.GetString("description")));
                }
                return items;
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
    }
}
