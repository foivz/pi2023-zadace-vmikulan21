﻿namespace Expense___Budget_Helper
{
    partial class FrmTroskovi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvTroskovi = new System.Windows.Forms.DataGridView();
            this.btnUnos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTroskovi)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTroskovi
            // 
            this.dgvTroskovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTroskovi.Location = new System.Drawing.Point(12, 12);
            this.dgvTroskovi.Name = "dgvTroskovi";
            this.dgvTroskovi.Size = new System.Drawing.Size(776, 426);
            this.dgvTroskovi.TabIndex = 0;
            // 
            // btnUnos
            // 
            this.btnUnos.Location = new System.Drawing.Point(340, 477);
            this.btnUnos.Name = "btnUnos";
            this.btnUnos.Size = new System.Drawing.Size(96, 23);
            this.btnUnos.TabIndex = 1;
            this.btnUnos.Text = "Unesi Trošak";
            this.btnUnos.UseVisualStyleBackColor = true;
            this.btnUnos.Click += new System.EventHandler(this.btnUnos_Click);
            // 
            // FrmTroskovi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 533);
            this.Controls.Add(this.btnUnos);
            this.Controls.Add(this.dgvTroskovi);
            this.Name = "FrmTroskovi";
            this.Text = "FrmTroskovi";
            this.Load += new System.EventHandler(this.FrmTroskovi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTroskovi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTroskovi;
        private System.Windows.Forms.Button btnUnos;
    }
}