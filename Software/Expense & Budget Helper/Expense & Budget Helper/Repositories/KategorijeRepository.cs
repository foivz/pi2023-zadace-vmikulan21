using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;

namespace Expense___Budget_Helper.Repositories
{
    public static class KategorijeRepository
    {
        public static Kategorija GetKategorija(int id)
        {
            Kategorija kategorija = new Kategorija();
            string sql = $"SELECT * FROM Kategorije WHERE Id_Kategorije = {id}";

            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                kategorija = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return kategorija;

        }
        public static List<Kategorija> GetListaKategorija()
        {
            List<Kategorija> listaKategorija = new List<Kategorija>();
            string sql = "SELECT * FROM Kategorije";

            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Kategorija kategorija = CreateObject(reader);
                listaKategorija.Add(kategorija);
            }
            reader.Close();
            DB.CloseConnection();
            return listaKategorija;
        }

        private static Kategorija CreateObject(SqlDataReader reader)
        {

            int id = int.Parse(reader["Id_kategorije"].ToString());
            string naziv = reader["Naziv_kategorije"].ToString();

            var kategorija = new Kategorija
            {
                Id = id,
                Naziv = naziv,
            };
            return kategorija;

        }


        public static void InsertKategorija(Kategorija kategorija)
        {
            string sql = $"INSERT INTO Kategorije (Naziv_kategorije) VALUES ('{kategorija.Naziv}')";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }
    }
}
