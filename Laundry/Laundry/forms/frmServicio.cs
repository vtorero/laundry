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
    public partial class frmServicio : Form
    {
        public frmServicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Servicio servicio = new Servicio();
            int resultado = 0;


            if ((!string.IsNullOrWhiteSpace(txtNombre.Text))
                && (!string.IsNullOrWhiteSpace(txtPrecio.Text))
                )
            {
                servicio.NombreServicio = txtNombre.Text.Trim();
                servicio.precioServicio = float.Parse(txtPrecio.Text);
                resultado = ServicioDao.Agregar(servicio);
            }
            else
            {
                resultado = 0;
                MessageBox.Show("Debe ingresar los valores");
            }

            if (resultado > 0)
            {

                MessageBox.Show("Servicio guardado con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar el servicio", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
