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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            Cliente cliente = new Cliente();
            int resultado = 0;


            if ((!string.IsNullOrWhiteSpace(txtNombres.Text)) 
                && (!string.IsNullOrWhiteSpace(txtDNI.Text))
                && (!string.IsNullOrWhiteSpace(txtDNI.Text))
                )
            {
                cliente.NombreCliente= txtNombres.Text.Trim();
                cliente.dniCliente = txtDNI.Text.Trim();
                cliente.correoCliente = txtEmail.Text.Trim();
                cliente.direccionCliente = txtDireccion.Text.Trim();
                cliente.telefonoCliente=txtTelefono.Text.Trim();
                
                resultado = ClienteDao.Agregar(cliente);
            }
            else
            {
                resultado = 0;
                MessageBox.Show("Debe ingresar los valores");
            }

            if (resultado > 0)
            {

                MessageBox.Show("Cliente guardado con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar el cliente", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            dgvClientes.DataSource = ClienteDao.Buscar();
        
        }
    }
}
