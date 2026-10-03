using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UzenetKuldo.DatabaseManager;
using UzenetKuldo.Interfaces;
using UzenetKuldo.Models;

namespace UzenetKuldo.Services
{
    public class UzenetService : ICRUD
    {
        public string Create(Tablazat tablazat)
        {
            try
            {
                MySqlConnection conn = new DBManager().OpenDB();
                string sql = "INSERT INTO uzenet (Szoveg, KüldesiIdo, UzenetTipus, Telefon, Email) VALUES (@szoveg, @kuldesiido, @uzenettipus, @telefon, @email)";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@szoveg", (tablazat as Uzenet).Szoveg);
                cmd.Parameters.AddWithValue("@kuldesiido", (tablazat as Uzenet).KüldesiIdo);
                cmd.Parameters.AddWithValue("@uzenettipus", (tablazat as Uzenet).UzenetTipus);
                cmd.Parameters.AddWithValue("@telefon", (tablazat as Uzenet).Telefon);
                cmd.Parameters.AddWithValue("@email", (tablazat as Uzenet).Email);
                int eredmeny = cmd.ExecuteNonQuery();
                if (eredmeny > 0)
                {
                    return "Sikeres beszúrás!";
                }
                else
                {
                    return "Sikertelen beszúrás";
                }

            }
            catch (Exception ex)
            {
                return "Hiba történt az adatok lekérdezése során: " + ex.Message;

            }


        }

        public string Delete(int id)
        {
            try
            {
                MySqlConnection conn = new DBManager().OpenDB();
                string sql = "DELETE FROM uzenet WHERE Id = @id";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@id", id);
                int eredmeny = cmd.ExecuteNonQuery();
                if (eredmeny > 0)
                {
                    return "Sikeres törlés!";
                }
                else
                {
                    return "Sikertelen törlés";
                }

            }
            catch (Exception ex)
            {
                return "Hiba történt az adatok törlése során: " + ex.Message;

            }
        }

        public List<Tablazat> Read()
        {
            List<Tablazat> tablazatok = new List<Tablazat>();

            try
            {
                MySqlConnection conn = new DBManager().OpenDB();

                string sql = "SELECT * FROM uzenet";

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Uzenet uzenet = new Uzenet();

                    uzenet.Id = Convert.ToInt32(reader["Id"]);
                    uzenet.Szoveg = reader["Szoveg"].ToString();
                    uzenet.KüldesiIdo = Convert.ToDateTime(reader["KüldesiIdo"]);
                    uzenet.UzenetTipus = reader["UzenetTipus"].ToString();

                    uzenet.Telefon = reader["Telefon"] == DBNull.Value
                        ? null
                        : reader["Telefon"].ToString();

                    uzenet.Email = reader["Email"] == DBNull.Value
                        ? null
                        : reader["Email"].ToString();

                    tablazatok.Add(uzenet);
                }

                conn.Close();

                return tablazatok;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt az adatok lekérdezése során: " + ex.Message);
                return tablazatok;
            }
        }

        public string Update(Tablazat tablazat)
        {
            try
            {
                MySqlConnection conn = new DBManager().OpenDB();
                string sql = "UPDATE uzenet SET Szoveg=@szoveg, KüldesiIdo=@kuldesiido, UzenetTipus=@uzenettipus, Telefon=@telefon, Email=@email WHERE Id = @id";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@szoveg", (tablazat as Uzenet).Szoveg);
                cmd.Parameters.AddWithValue("@kuldesiido", (tablazat as Uzenet).KüldesiIdo);
                cmd.Parameters.AddWithValue("@uzenettipus", (tablazat as Uzenet).UzenetTipus);
                cmd.Parameters.AddWithValue("@telefon", (tablazat as Uzenet).Telefon);
                cmd.Parameters.AddWithValue("@email", (tablazat as Uzenet).Email);
                cmd.Parameters.AddWithValue("@id", (tablazat as Uzenet).Id);
                int eredmeny = cmd.ExecuteNonQuery();
                if (eredmeny > 0)
                {
                    return "Sikeres módosítás!";
                }
                else
                {
                    return "Sikertelen módosítás";
                }

            }
            catch (Exception ex)
            {
                return "Hiba történt az adatok módosítása során: " + ex.Message;

            }
        }
    }
}