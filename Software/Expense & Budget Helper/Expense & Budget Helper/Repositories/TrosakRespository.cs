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
        public static List<Trosak> GetTroskovi()
        {
            List<Trosak> troskovi = new List<Trosak>();
            string sql = "SELECT * FROM Troskovi,Kategorije,VrsteTroskova WHERE Troskovi.Id_vrste = VrsteTroskova.Id_vrste AND VrsteTroskova.Id_kategorije = kategorije.Id_kategorije";
        
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
            string kategorija = reader["Naziv_kategorije"].ToString();
            string vrsta = reader["Naziv_vrste"].ToString();

            var trosak = new Trosak
            {
                Id = id,
                Opis = opis,
                Datum = datum,
                Cijena = cijena,
                Kategorija = kategorija,
                Vrsta = vrsta
            };
            return trosak;

        }


    }
}
