using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;
using Expense___Budget_Helper.Models;

namespace Expense___Budget_Helper.Repositories
{
    public static class TrosakRepository
    {
        public static Trosak GetTrosak(int id)
        {
            Trosak trosak = new Trosak();
            string sql = $"SELECT * FROM Troskovi WHERE Id_troska = {id}";

            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                trosak = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return trosak;

        }
        public static List<Trosak> GetTroskovi()
        {
            List<Trosak> troskovi = new List<Trosak>();
            string sql = "SELECT * FROM Troskovi";
        
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Trosak trosak = CreateObject(reader);
                troskovi.Add(trosak);
            }
            reader.Close();
            DB.CloseConnection();
            return troskovi;
        }

        private static Trosak CreateObject(SqlDataReader reader)
        {

            int id = int.Parse(reader["Id_troska"].ToString());
            string opis = reader["Opis"].ToString();
            DateTime datum = DateTime.Parse(reader["Datum"].ToString());
            int cijena = int.Parse(reader["Cijena"].ToString());
            int id_vrste = int.Parse(reader["Id_vrste"].ToString());

            var trosak = new Trosak
            {
                Id = id,
                Opis = opis,
                Datum = datum,
                Cijena = cijena,
                Id_vrste = id_vrste
            };
            return trosak;

        }


        public static void InsertTrosak(Trosak trosak)
        {
            string sql = $"INSERT INTO Troskovi (Opis, Cijena, Datum, Id_vrste) VALUES ('{trosak.Opis}', {trosak.Cijena}, '{trosak.Datum.ToString("yyyy-MM-dd")}','{trosak.Id_vrste}')";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }
        public static void UpdateTrosak(Trosak trosak)
        {
            string sql = $"UPDATE Troskovi SET Opis = '{trosak.Opis}', Cijena = '{trosak.Cijena}', Datum = '{trosak.Datum.ToString("yyyy-MM-dd")}', Id_vrste = '{trosak.Id_vrste}' WHERE Id_troska = '{trosak.Id}'";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }
        public static void DeleteTrosak(int id)
        {
            string sql = $"DELETE FROM Troskovi WHERE Id_troska = '{id}'";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }
        public static List<Trosak> SearchTrosak(string opis)
        {
            List<Trosak> rezultati = new List<Trosak>();
            string sql = $"SELECT * FROM Troskovi WHERE Opis LIKE '%{opis}%'";

            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Trosak trosak = CreateObject(reader);
                rezultati.Add(trosak);
            }
            reader.Close();
            DB.CloseConnection();

            return rezultati;
        }


    }
}
