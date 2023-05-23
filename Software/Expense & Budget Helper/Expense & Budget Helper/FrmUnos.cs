using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Expense___Budget_Helper.Models;
using Expense___Budget_Helper.Repositories;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Expense___Budget_Helper
{
    public partial class FrmUnos : Form
    {
        public FrmUnos()
        {
            InitializeComponent();
            List<Trosak> troskovi = TrosakRepository.GetTroskovi();
            cboVrsta.DataSource = troskovi;
            cboVrsta.DisplayMember = "Naziv_vrste";
            cboVrsta.ValueMember = "Id_vrste";
        }

        public void btnUnesi_Click(object sender, EventArgs e)
        {
            int Id_Troska = int.Parse(txtId.Text);
            int cijena = int.Parse(txtCijena.Text);
            DateTime datum = dateDatum.Value;
            string opis = txtOpis.Text;
            int vrsta = int.Parse(cboVrsta.SelectedValue.ToString());

            var trosak = new Trosak
            {
                Id = Id_Troska,
                Cijena = cijena,
                Datum = datum,
                Opis = opis,
                Id_vrste = vrsta
            };

            TrosakRepository.InsertTrosak(trosak);

            MessageBox.Show("Trosak uspješno dodan!");

        }
    }
}
