using Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class DBOrder : DataAccess
    {
        //public bool CreateOrder(Order order)
        //{
        //    try
        //    {


        //        con.Open();
        //        string sql = "insert into item (Name, item_image, SubCategory, Category ,Price,Unit, amount, description ) values( @Name, @item_image, @SubCategory, @Category, @Price, @Unit, @amount, @description);";
        //        MySqlCommand cmd = new MySqlCommand(sql, con);
        //        cmd.Parameters.AddWithValue("Name", item.name);
        //        cmd.Parameters.AddWithValue("item_image", item.image);
        //        cmd.Parameters.AddWithValue("SubCategory", item.subCategory);
        //        cmd.Parameters.AddWithValue("Category", item.category);
        //        cmd.Parameters.AddWithValue("Price", item.price);
        //        cmd.Parameters.AddWithValue("Unit", item.unit.ToString());
        //        cmd.Parameters.AddWithValue("amount", item.amount);
        //        cmd.Parameters.AddWithValue("description", item.description);
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally
        //    {
        //        this.con.Close();
        //    }
        //}

    }
}
