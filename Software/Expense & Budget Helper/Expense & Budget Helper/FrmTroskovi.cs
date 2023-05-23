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

        }

        private void btnUnos_Click(object sender, EventArgs e)
        {
            FrmUnos frmUnos = new FrmUnos();
            frmUnos.ShowDialog();
        }
    }
}
