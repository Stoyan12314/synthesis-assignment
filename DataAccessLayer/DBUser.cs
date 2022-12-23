using System;
using System.Collections.Generic;
using System.Data;
using DataAccessLayer.Interfaces;
using Entities;
using Entities.Enum;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;

namespace DataAccessLayer
{
    public class DBUser: DataAccess, IDBUser
    {
        public bool CreateUser(string username, string password, DateTime creationDate, string firstName, string lastName, string email, string shipAddress, string shipCity, string shipPostalCode, string shipCountry)
        {
            try
            {


                con.Open();
                string sql = "insert into users (user_name, password, creation_date, accountType,first_name,last_name,email,ship_address, ship_city,ship_postal_code, ship_country ) values( @user_name, @password, @creation_date, @accountType, @first_name, @last_name, @email, @shipAddress, @shipCity, @shipPostalCode, @shipcountry );";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("user_name", username);
                cmd.Parameters.AddWithValue("creation_date", creationDate);
                cmd.Parameters.AddWithValue("password", password);
                cmd.Parameters.AddWithValue("first_name", firstName);
                cmd.Parameters.AddWithValue("last_name", lastName);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("accountType", AccountType.Customer.ToString());
                cmd.Parameters.AddWithValue("shipAddress", shipAddress);
                cmd.Parameters.AddWithValue("shipCity", shipCity);
                cmd.Parameters.AddWithValue("shipPostalCode", shipPostalCode);
                cmd.Parameters.AddWithValue("shipcountry", shipCountry);
                cmd.ExecuteNonQuery();
                int userId = (int)cmd.LastInsertedId;
                this.con.Close();
                CreateBonusCard(userId);
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
       
        private void CreateBonusCard(int userId)
        {
            try
            {
                
                con.Open();
                string sql = "insert into bonus (user_id, bonus_points) values (@user_id, @bonus_points);";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("user_id", userId);
                cmd.Parameters.AddWithValue("bonus_points", 0);

                cmd.ExecuteNonQuery();
                int bonusCardId = (int)cmd.LastInsertedId;
                this.con.Close();
                InsertBonusCardIdToUser(userId, bonusCardId);


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
        private void InsertBonusCardIdToUser(int userId, int bonusCardId)
        {
            try
            {
                con.Open();
                
                string sql = "UPDATE users set  bonus_card_id = @bonus_card_id where user_id = @user_id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("bonus_card_id", bonusCardId);
                cmd.Parameters.AddWithValue("user_id", userId);

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
       
       
        public User GetUser(int id)
        {
            try
            {
                con.Open();
                User user = null;
                var cmd = con.CreateCommand();
                cmd.CommandText = "select user_id, email, user_name, creation_date, accountType, first_name, last_name, ship_address, ship_city, ship_postal_code, ship_country from users where @user_id=user_id;";
                cmd.Parameters.AddWithValue("@user_id", id);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    AccountType accType = Enum.Parse<AccountType>(dr.GetString("accountType"));
                    user = new User(dr.GetInt32("user_id"), dr.GetString("email"), dr.GetString("first_name"), dr.GetString("last_name"), dr.GetString("user_name"), dr.GetDateTime("creation_date"), accType, dr.GetString("ship_address"), dr.GetString("ship_city"), dr.GetString("ship_postal_code"), dr.GetString("ship_country"));

                }
                return user;
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

        public string FindUserId(string username)
        {
            try
            {
                con.Open();
                string id = null;
                var cmd = con.CreateCommand();
                cmd.CommandText = "Select user_id from users where user_name = @user_name";
                cmd.Parameters.AddWithValue("@user_name", username);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    id = dr.GetInt32("user_id").ToString();

                }
                return id;
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

       

        public User CheckLogin(string email)
        {

            try
            {
              
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select user_id, user_name, password, creation_date, accountType, first_name, last_name, email, ship_address, ship_city, ship_postal_code, ship_country from users where email=@email", con);
                cmd.Parameters.AddWithValue("@email", email);
               
                
                User user = null;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    AccountType accType = Enum.Parse<AccountType>(dr.GetString("accountType"));
                   
                    user = new User(dr.GetInt32("user_id"), dr.GetString("email"), dr.GetString("password"), dr.GetString("first_name"), dr.GetString("last_name"), dr.GetString("user_name"), dr.GetDateTime("creation_date"), accType, dr.GetString("ship_address"), dr.GetString("ship_city"), dr.GetString("ship_postal_code"), dr.GetString("ship_country"));

                }
                return user;
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

        public void UpdateUserShippingCredentials(int userId, string address, string country, string postalCode, string city)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE users SET ship_address = @ship_address, ship_city = @ship_city, ship_postal_code = @ship_postal_code, ship_country = @ship_country  WHERE user_id = @user_id", con);

                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@ship_address", address);
                cmd.Parameters.AddWithValue("@ship_city", city);
                cmd.Parameters.AddWithValue("@ship_postal_code", postalCode);
                cmd.Parameters.AddWithValue("@ship_country", country);
                cmd.ExecuteNonQuery();  
            }
            catch (Exception)
            {

                throw;
            }
            finally 
            { con.Close(); }
        }
    }
}
