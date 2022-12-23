using Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Interfaces;
using System.Linq;
using System.Net;

namespace DataAccessLayer
{
    public class DBCategory : DataAccess, IDBCategory
    {

        public bool CreateCategory(string cat)
        {
            try
            {
                con.Open();
                string sql = "insert into categories (category) values( @category);";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("category", cat);
               
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
        public bool DeleteCategory(int id)
        {
            try
            {
                con.Open();
                string sql = "Delete from categories where category_id = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("id", id);

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
        public bool DeleteSubCategory(int id)
        {
            try
            {
                con.Open();
                string sql = "Delete from subcategory where subCategory_id = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("id", id);

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
        public bool CreateSubCategory(string subCategory, int CategoryId)
        {
            try
            {
                con.Open();
                string sql = "insert into subcategory (SubCatName, category_id) values( @subCategory, @category_id);";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("subCategory", subCategory);
                cmd.Parameters.AddWithValue("category_id", CategoryId);
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
       
        public List<Category> GetAllCategories()
        {
            try
            {
                List<Category> categories = new List<Category>();
                Category category;


                this.con.Open();
                var cm = con.CreateCommand();
                cm.CommandText = "SELECT * from categories";

                MySqlDataReader reader = cm.ExecuteReader();
                while (reader.Read())
                {

                    category = new Category(reader.GetInt32("category_id"), reader.GetString("category"));
                    categories.Add(category);
                }
                con.Close();
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "SELECT categories.category_id, categories.category, subcategory.subCatName, subcategory.subCategory_id  from subcategory inner join categories on categories.category_id = subcategory.category_id";

                MySqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    category = new Category(dr.GetInt32("category_id"), dr.GetString("category"), dr.GetInt32("subCategory_id"), dr.GetString("subCatName"));
                    
                    categories.Add(category);
                }
                return categories;
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
        public List<SubCategory> GetAllSubCat(int id)
        {
            try
            {
                List<SubCategory> categories = new List<SubCategory>();
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "SELECT subCatName, subCategory_id from subcategory where category_id = @id";
                cmd.Parameters.AddWithValue("id", id);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {   
                    SubCategory category = new SubCategory(dr.GetInt32("subCategory_id"), dr.GetString("subCatName"));
                    categories.Add(category);
                }
                return categories;
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
