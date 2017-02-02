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
            prenda.NombrePrenda = txtNombre.Text.Trim();
            prenda.Descripcion = txtDescripcion.Text.Trim();
            prenda.precioServicio = float.Parse(txtPrecio.Text.Trim());

            int resultado = PrendaDao.Agregar(prenda);
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
            //listView1.
                       dgvPrenda.DataSource = PrendaDao.Buscar();
        }
    }
}
