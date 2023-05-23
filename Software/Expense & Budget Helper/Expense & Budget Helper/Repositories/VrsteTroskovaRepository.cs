using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;
using Expense___Budget_Helper.Models;

namespace Expense___Budget_Helper.Repositories
{
    public static class VrsteTroskovaRepository
    {
        public static VrstaTroska GetVrstaTroska(int id)
        {
            VrstaTroska vrstaTroska = new VrstaTroska();
            string sql = $"SELECT * FROM VrsteTroskova WHERE Id_vrste = {id}";

            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                vrstaTroska = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return vrstaTroska;

        }
        public static List<VrstaTroska> GetListaVrstaTroskova()
        {
            List<VrstaTroska> listaVrstaTroskova = new List<VrstaTroska>();
            string sql = "SELECT * FROM VrsteTroskova";

            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                VrstaTroska vrstaTroska = CreateObject(reader);
                listaVrstaTroskova.Add(vrstaTroska);
            }
            reader.Close();
            DB.CloseConnection();
            return listaVrstaTroskova;
        }

        private static VrstaTroska CreateObject(SqlDataReader reader)
        {

            int id = int.Parse(reader["Id_vrste"].ToString());
            string naziv = reader["Naziv_vrste"].ToString();
            int id_kategorije = int.Parse(reader["Id_kategorije"].ToString());

            var vrstaTroska = new VrstaTroska
            {
                Id = id,
                Naziv = naziv,
                Id_kategorije = id_kategorije,
            };
            return vrstaTroska;

        }


        public static void InsertVrstaTroska(VrstaTroska vrstaTroska)
        {
            string sql = $"INSERT INTO VrsteTroskova (Naziv_vrste, Id_kategorije) VALUES ('{vrstaTroska.Naziv}', '{vrstaTroska.Id_kategorije}')";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }

    }
}
