using System;
using System.Collections.Generic;
using System.Data;
using DataAccessLayer.Interfaces;
using Entities;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    public class DBUser: DataAccess, IDBUser
    {
        public bool CreateUser( string username, string password, DateTime creationDate, string firstName, string lastName, string email )
        {
            try
            {


                con.Open();
                string sql = "insert into users (user_name, password, creation_date, accountType,first_name,last_name,email ) values( @user_name, @password, @creation_date, @accountType, @first_name, @last_name, @email);";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("user_name", username);
                cmd.Parameters.AddWithValue("password", password);
                cmd.Parameters.AddWithValue("first_name", firstName);
                cmd.Parameters.AddWithValue("last_name", lastName);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("accountType", AccountType.Customer.ToString());

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
        public List<User> GetAllUsers()
        {
            try
            {
                List<User> users = new List<User>();
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * from users";
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    AccountType accType = Enum.Parse<AccountType>(dr.GetString("accountType"));
                    users.Add(new User(dr.GetInt32("user_id"), dr.GetString("email"), dr.GetString("password"), dr.GetString("firstName"), dr.GetString("lastName"), dr.GetString("user_name"), dr.GetDateTime("creation_date"), accType));
                }
                return users;



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
      
        public void UpdateUser(string username, string password, string oldUsername)
        {
            try
            {
                con.Open();
                var cmd = new MySqlCommand("UPDATE users SET user_name = @new_user_name, password = @password  WHERE user_name = @old_username", con);
                cmd.Parameters.AddWithValue("@new_user_name", username);
                cmd.Parameters.AddWithValue("@password", password);
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
        public User GetUser(int id)
        {
            try
            {
                con.Open();
                User user = null;
                var cmd = con.CreateCommand();
                cmd.CommandText = "select user_id, user_name, creation_date, accountType, first_name, last_name, email from users where @user_id=user_id;";
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    AccountType accType = Enum.Parse<AccountType>(dr.GetString("accountType"));
                    user = new User(dr.GetInt32("user_id"), dr.GetString("email"), dr.GetString("password"), dr.GetString("firstName"), dr.GetString("lastName"), dr.GetString("user_name"), dr.GetDateTime("creation_date"), accType);
                    
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

        public void UpdateUsername(string username, string oldUsername)
        {
            try
            {
                con.Open();
                var cmd = new MySqlCommand("UPDATE users SET user_name = @username  WHERE user_name = @oldUsername", con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@oldUsername", oldUsername);
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
        public void UpdatePassword(string username, string password)
        {
            try
            {
                con.Open();
                var cmd = new MySqlCommand("UPDATE users SET password = @password  WHERE user_name = @Username", con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@password", password);
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

        public User CheckLogin(string email)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand("select user_id, user_name, password, creation_date, accountType, first_name, last_name, email from users where @email=email;", con);
                cmd.Parameters.AddWithValue("email", email);
               
                con.Open();
                User user = null;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    AccountType accType = Enum.Parse<AccountType>(dr.GetString("accountType"));
                   
                    user = new User(dr.GetInt32("user_id"), dr.GetString("email"), dr.GetString("password"), dr.GetString("first_name"), dr.GetString("last_name"), dr.GetString("user_name"), dr.GetDateTime("creation_date"), accType);

                }
                return user;
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
