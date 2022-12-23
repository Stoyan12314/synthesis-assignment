using DataAccessLayer.Interfaces;
using Entities.Enum;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class DBBonusCard : DataAccess , IDBBonusCard
    {
        public bool AddPointsToCard(int userId, double price)
        {
            try
            {
                con.Open();
                string sql = "UPDATE bonus set  bonus_points = bonus_points + @bonus_points  where user_id = @user_id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@bonus_points", price);

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

        public int GetPointsFromCard(int userId)
        {
            try
            {
                con.Open();
                int bonusPoints = 0;
                var cmd = con.CreateCommand();
                cmd.CommandText = "select bonus_points from bonus where user_id = @user_id";
                cmd.Parameters.AddWithValue("@user_id", userId);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    bonusPoints = dr.GetInt32("bonus_points");

                }
                return bonusPoints;
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

        public void SpentPointsFromCard(int userId, double total)
        {
            try
            {
                con.Open();
                string sql = "UPDATE bonus set  bonus_points = bonus_points - @bonus_points where user_id = @user_id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@bonus_points", total);

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

      
    }
}
