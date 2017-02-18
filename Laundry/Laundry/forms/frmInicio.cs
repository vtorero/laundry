using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.forms
{
    public partial class frmInicio : Form
    {
        //private int childFormNumber = 0;

        public frmInicio()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new frmPrendas();
            childForm.MdiParent = this;
            childForm.Text = "Mantenimiento de Prendas";
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            Form childForm = new frmServicio();
            childForm.MdiParent = this;
            childForm.Text = "Mantenimiento de Servicios";
            childForm.Show();
            
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Form childForm = new frmClientes();
            childForm.MdiParent = this;
            childForm.Text = "Mantenimiento de Clientes";
            childForm.Show();
        
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

      

    

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new frmColor();
            childForm.MdiParent = this;
            childForm.Text = "Mantenimiento de Colores";
            childForm.Show();
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void prendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDocument cryrep = new ReportDocument();
            MySqlDataAdapter myadap = new MySqlDataAdapter(String.Format(
         "SELECT idPrenda, NombrePrenda, DescripcionPrenda, PrecioServicio FROM Prenda"), BdComun.ObtenerConexion());
            DataSet ds = new DataSet();
            myadap.Fill(ds, "Prendas");
            cryrep.Load(@"D:\laundry\Laundry\Laundry\Reportes\crPrendas.rpt");
            cryrep.SetDataSource(ds);
            frmReporte rt = new frmReporte();
            rt.crystalReportViewer1.ReportSource = cryrep;
            rt.Show();﻿
        }
    }
}
