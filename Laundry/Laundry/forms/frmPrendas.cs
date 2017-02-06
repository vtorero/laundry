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
using WindowsFormsApplication1.Models;
using WindowsFormsApplication1.Persistencia;

namespace WindowsFormsApplication1.forms
{
    public partial class frmPrendas : Form
    {
        ReportDocument cryrep = new ReportDocument();
        public frmPrendas()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prenda prenda= new Prenda();
            int resultado = 0;


            if ((!string.IsNullOrWhiteSpace(txtNombre.Text)) && (!string.IsNullOrWhiteSpace(txtDescripcion.Text)))
            {
                prenda.NombrePrenda = txtNombre.Text.Trim();
                prenda.Descripcion = txtDescripcion.Text.Trim();
                prenda.precioServicio = float.Parse(txtPrecio.Text.Trim());
                resultado = PrendaDao.Agregar(prenda);
            }
            else {
                resultado = 0;
                MessageBox.Show("Debe ingresar los valores");
            }

            if (resultado > 0)
            {
                dgvPrenda.DataSource = PrendaDao.Buscar();
                MessageBox.Show("Prenda Guardada Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar la prenda", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmPrendas_Load(object sender, EventArgs e)
        {
       
                      // dgvPrenda.DataSource = PrendaDao.Buscar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
