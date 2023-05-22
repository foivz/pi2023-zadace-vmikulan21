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
    public class TrosakRepository
    {
        public Trosak GetTrosak(int id)
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
        public static List<Trosak> GetTrosak()
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
            string opis = reader["opis"].ToString();
            DateTime datum = DateTime.Parse(reader["datum"].ToString());
            int cijena = int.Parse(reader["Cijena"].ToString());
            string naziv = reader["Naziv_Troska"].ToString();

            var trosak = new Trosak
            {
                Id = id,
                Opis = opis,
                Datum = datum,
                Cijena = cijena,
                NazivTroska = naziv
            };
            return trosak;

        }


    }
}
