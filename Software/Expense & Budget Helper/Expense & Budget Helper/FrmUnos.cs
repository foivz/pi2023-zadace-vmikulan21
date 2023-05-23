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
        }

        public void btnUnesi_Click(object sender, EventArgs e)
        {
            int cijena = int.Parse(txtCijena.Text);
            DateTime datum = dateDatum.Value;
            string opis = txtOpis.Text;
            int vrsta = int.Parse(cboVrsta.SelectedValue.ToString());


            var trosak = new Trosak
            {
                Cijena = cijena,
                Datum = datum,
                Opis = opis,
                Id_vrste = vrsta
            };

            TrosakRepository.InsertTrosak(trosak);

            MessageBox.Show("Trosak uspješno dodan!");

        }

        private void cboVrsta_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cboVrsta.SelectedValue != null)
            {
                var odabranaVrstaTroska = (VrstaTroska) cboVrsta.SelectedItem;
                Kategorija kategorija = KategorijeRepository.GetKategorija(odabranaVrstaTroska.Id_kategorije);
                txtKategorija.Text = kategorija.Naziv;
            }

        }

        private void FrmUnos_Load(object sender, EventArgs e)
        {
            List<VrstaTroska> vrsteTroskova = VrsteTroskovaRepository.GetListaVrstaTroskova();
            cboVrsta.DataSource = vrsteTroskova;
            cboVrsta.DisplayMember = "Naziv";
            cboVrsta.ValueMember = "Id";
        }
    }
}
