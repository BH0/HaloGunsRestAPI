using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;

using HaloGuns.Models;
using HaloGuns.PrivateFiles; 

using MySql.Data;


namespace HaloGuns
{
    public class GunPersistence
    {
        private MySql.Data.MySqlClient.MySqlConnection conn;
        string MySqlConnectionString;
        
        public GunPersistence()
        {
            PrivateFiles.PrivateFiles _private = new PrivateFiles.PrivateFiles();
            string password = _private.MySqlPassword; 
            MySqlConnectionString = "server=localhost;port=3306;database=haloguns;user=root;password=" + password; 

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = MySqlConnectionString;
                conn.Open(); 
            } catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Issue connecting"); 
            }
        }

        //// CRUD Operations 

        /// Get All Guns 
        public ArrayList getGuns()
        {
            ArrayList guns = new ArrayList(); 

            MySql.Data.MySqlClient.MySqlDataReader reader = null; 
            string query = "SELECT * FROM tblGuns";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);

            reader = cmd.ExecuteReader(); 

            while (reader.Read())
            {
                Gun gun = new Gun();
                gun.ID = reader.GetInt32(0);
                gun.name = reader.GetString(1);
                gun.faction = reader.GetString(2);
                gun.race = reader.GetString(3); 
                // gun.range = reader.GetString(3); 
                gun.type = reader.GetString(4);
                gun.technology = reader.GetString(5); 

                guns.Add(gun); 
            }
            return guns; 
        }

        /// Get Gun By Identification/identifier 
        public Gun getGun(long ID)
        { 
            Gun gun = new Gun();
            MySql.Data.MySqlClient.MySqlDataReader reader = null; 
            string query = "SELECT * FROM tblGuns WHERE ID =" + ID.ToString();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);

            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                gun.ID = reader.GetInt32(0);
                gun.name = reader.GetString(1);
                gun.faction = reader.GetString(2);
                gun.race = reader.GetString(3);
                // gun.range = reader.GetString(3); 
                gun.type = reader.GetString(4);
                gun.technology = reader.GetString(5);

                return gun;
            }
            else
            {
                return null;
            }
        } 

        public long saveGun(Gun newGun) 
        {
            // try { 
            string query = "INSERT INTO tblGuns (name, faction, race, type, technology) VALUES ('" + newGun.name + "', '" + newGun.faction + "', '" + newGun.race+ "', '" + newGun.type + "', '" + newGun.technology + "')";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            long ID = cmd.LastInsertedId;
            return ID; 
            // catch { } 
        }

        public bool updateGun(long ID, Gun updatedGun)
        {
            MySql.Data.MySqlClient.MySqlDataReader reader = null;
            // string query = "UPDATE tblGuns SET name='" + updatedGun.name + "', faction='" + updatedGun.faction + "', race='" + updatedGun.race + "', type='" + updatedGun.type + "', technology='" + updatedGun.technology + "' WHERE ID = " + ID.ToString();
            // string query = "UPDATE tblGuns SET name='Angel', faction='Salt', race='Ace', type='Sigmond', technology='Poor' WHERE ID = " + ID.ToString(); 
            string query = "SELECT * FROM tblGuns WHERE ID = " + ID.ToString(); 
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn); 
        
            reader = cmd.ExecuteReader(); 
            if (reader.Read())
            {
                reader.Close();
                // query = "UPDATE tblGuns SET name='Angel', faction='Salt', race='Ace', type='Sigmond', technology='Poor' WHERE ID = " + ID.ToString();
                query = "UPDATE tblGuns SET name='" + updatedGun.name + "', faction='" + updatedGun.faction + "', race='" + updatedGun.race + "', type='" + updatedGun.type + "', technology='" + updatedGun.technology + "' WHERE ID = " + ID.ToString();
                cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                // try { 
                return true;
                // catch { } 
            }
            else
            {
                return false;
            }
        }

        public bool deleteGun(long ID)
        {
            Gun gun = new Gun();
            MySql.Data.MySqlClient.MySqlDataReader reader = null;
            string query = "SELECT * FROM tblGuns WHERE ID =" + ID.ToString();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);

            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                query = "DELETE FROM tblGuns WHERE ID =" + ID.ToString();
                cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                // try { 
                return true;
                // catch { } 
            }
            else
            {
                return false;
            }
        }
    }
}
