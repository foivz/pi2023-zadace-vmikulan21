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

namespace Expense___Budget_Helper
{
    public partial class FrmTroskovi : Form
    {
        public FrmTroskovi()
        {
            InitializeComponent();
        }

        private void FrmTroskovi_Load(object sender, EventArgs e)
        {
            ShowTroskovi();
        }
        private void ShowTroskovi()
        {
            List<Trosak> troskovi = TrosakRepository.GetTroskovi();
            dgvTroskovi.DataSource = troskovi;
            DataGridViewTextBoxColumn vrstaTroskaColumn = new DataGridViewTextBoxColumn();
            vrstaTroskaColumn.Name = "VrstaTroska";
            vrstaTroskaColumn.HeaderText = "Vrsta troska";
            DataGridViewTextBoxColumn kategorijaColumn = new DataGridViewTextBoxColumn();
            kategorijaColumn.Name = "Kategorija";
            kategorijaColumn.HeaderText = "Kategorija";
            dgvTroskovi.Columns.Add(kategorijaColumn);
            dgvTroskovi.Columns.Add(vrstaTroskaColumn);
            dgvTroskovi.Columns["Id_vrste"].Visible = false;


            foreach (DataGridViewRow row in dgvTroskovi.Rows)
            {
                DataGridViewCell vrstaTroskaCell = row.Cells["VrstaTroska"];
                VrstaTroska vrstaTroska = VrsteTroskovaRepository.GetVrstaTroska(int.Parse(row.Cells["Id_vrste"].Value.ToString()));
                vrstaTroskaCell.Value = vrstaTroska.Naziv;

                DataGridViewCell kategorijaCell = row.Cells["Kategorija"];
                Kategorija kategorija = KategorijeRepository.GetKategorija(vrstaTroska.Id_kategorije);
                kategorijaCell.Value = kategorija.Naziv;
            }

        }

        private void btnUnos_Click(object sender, EventArgs e)
        {
            FrmUnos frmUnos = new FrmUnos();
            frmUnos.ShowDialog();
        }
    }
}
