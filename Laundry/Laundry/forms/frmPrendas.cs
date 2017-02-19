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
using WindowsFormsApplication1.util;

namespace WindowsFormsApplication1.forms
{
    public partial class frmPrendas : Form

    {
        int pos;
        Validacion v = new Validacion();
        public frmPrendas()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

      
     

        private void button2_Click(object sender, EventArgs e)
        {
          //  MySqlDataAdapter myadap = new MySqlDataAdapter(String.Format(
          //"SELECT idPrenda, NombrePrenda, DescripcionPrenda, PrecioServicio FROM Prenda"), BdComun.ObtenerConexion());
          //  DataSet ds = new DataSet();
          //  myadap.Fill(ds, "Prendas");
          //  cryrep.Load(@"D:\laundry\Laundry\Laundry\Reportes\crPrendas.rpt");
          //  cryrep.SetDataSource(ds);
          //  frmReporte rt = new frmReporte();
          //  rt.crystalReportViewer1.ReportSource = cryrep;
          //  rt.Show();﻿

        }

        private void frmPrendas_Load(object sender, EventArgs e)
        {
           
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            pos = dgvPrendas.CurrentRow.Index;
            lblCodigo.Visible = true;
            txtCodigo.Visible = true;
            txtCodigo.Text = Convert.ToString(dgvPrendas[0, pos].Value);
            txtNombre.Text = Convert.ToString(dgvPrendas[1, pos].Value);
            txtDescripcion.Text = Convert.ToString(dgvPrendas[2, pos].Value);
            txtPrecio.Text = Convert.ToString(dgvPrendas[3, pos].Value);
            tabControl1.SelectedTab = tabPage1;
            btnGuardar.Text = "&Actualizar";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (dgvPrendas.RowCount == 0)
            {
                dgvPrendas.DataSource = PrendaDao.Listar();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Prenda prenda = new Prenda();
            int resultado = 0;
            string msj = "";



            if ((!string.IsNullOrWhiteSpace(txtNombre.Text)) && (!string.IsNullOrWhiteSpace(txtDescripcion.Text)))
            {
                prenda.NombrePrenda = txtNombre.Text.Trim();
                prenda.Descripcion = txtDescripcion.Text.Trim();
                prenda.precioServicio = float.Parse(txtPrecio.Text.Trim());


                if (btnGuardar.Text.Equals("&Registrar"))
                {
                    msj = "Prenda registrada con éxito!!";
                    resultado = PrendaDao.Agregar(prenda);
                }
                if (btnGuardar.Text.Equals("&Actualizar"))
                {
                    msj = "Prenda actualizada con éxito!!";
                    prenda.idPrenda = Convert.ToInt32(txtCodigo.Text.Trim());
                    resultado = PrendaDao.Modificar(prenda);

                }

               
            }
            else
            {
                resultado = 0;
                MessageBox.Show("Debe ingresar los valores");
            }

            if (resultado > 0)
            {

                
                dgvPrendas.DataSource = PrendaDao.Listar();
                tabControl1.SelectedTab = tabPage2;
                btnGuardar.Text = "&Registrar";
                resetValores();
                MessageBox.Show(msj, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar la prenda", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void resetValores()
        {
            lblCodigo.Text = "";
            txtCodigo.Text = "";
            lblCodigo.Visible = false;
            txtCodigo.Visible = false;
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            pos = dgvPrendas.CurrentRow.Index;
            string id = Convert.ToString(dgvPrendas[0, pos].Value);

            DialogResult result = MessageBox.Show("Eliminar la prenda: " + id, "Confirmar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                PrendaDao.Eliminar(Convert.ToInt32(id));
                dgvPrendas.DataSource = PrendaDao.Listar();
                MessageBox.Show("Prenda eliminada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
           
        }

   
     
    }
}
