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
        bool inicijalizirano = false;
        public FrmTroskovi()
        {
            InitializeComponent();
        }

        private void FrmTroskovi_Load(object sender, EventArgs e)
        {
            ShowTroskovi(false);
        }
        private void ShowTroskovi(bool pretrazivanje)
        {
            if (!pretrazivanje)
            {
                List<Trosak> troskovi = TrosakRepository.GetTroskovi();
                dgvTroskovi.DataSource = troskovi;
            }
            else
            {
                string opis = txtSearch.Text;
                List<Trosak> rezultati = TrosakRepository.SearchTrosak(opis);
                dgvTroskovi.DataSource = rezultati;
            }
            if (!inicijalizirano)
            {
                DataGridViewTextBoxColumn vrstaTroskaColumn = new DataGridViewTextBoxColumn();
                vrstaTroskaColumn.Name = "VrstaTroska";
                vrstaTroskaColumn.HeaderText = "Vrsta troska";
                DataGridViewTextBoxColumn kategorijaColumn = new DataGridViewTextBoxColumn();
                kategorijaColumn.Name = "Kategorija";
                kategorijaColumn.HeaderText = "Kategorija";
                dgvTroskovi.Columns.Add(kategorijaColumn);
                dgvTroskovi.Columns.Add(vrstaTroskaColumn);
                dgvTroskovi.Columns["Id_vrste"].Visible = false;
                inicijalizirano = true;
            }


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
            ShowTroskovi(false);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvTroskovi.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Potrebno je odabrati redak!");
            }
            else
            {
                DataGridViewRow row = dgvTroskovi.SelectedRows[0];
                Trosak trosak = new Trosak();
                trosak.Id = int.Parse(row.Cells["Id"].Value.ToString());
                trosak.Opis = row.Cells["Opis"].Value.ToString();
                trosak.Datum = DateTime.Parse(row.Cells["Datum"].Value.ToString());
                trosak.Cijena = int.Parse(row.Cells["Cijena"].Value.ToString());
                trosak.Id_vrste = int.Parse(row.Cells["Id_vrste"].Value.ToString());
                FrmUnos frmUnos = new FrmUnos(trosak);
                frmUnos.ShowDialog();
                ShowTroskovi(false);

            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTroskovi.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Potrebno je odabrati redak!");
            }
            else
            {
                DataGridViewRow row = dgvTroskovi.SelectedRows[0];
                int Id = int.Parse(row.Cells["Id"].Value.ToString());
                TrosakRepository.DeleteTrosak(Id);
                MessageBox.Show("Uspješno obrisan redak!");
            }
            ShowTroskovi(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowTroskovi(true);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowTroskovi(false);
            txtSearch.Text = string.Empty;
        }
    }
}
