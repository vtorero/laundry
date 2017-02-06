using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Persistencia;

namespace WindowsFormsApplication1.forms
{
    public partial class frmColor : Form
    {
        public frmColor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                txtValorColor.Text = colorDialog1.Color.Name;
                label2.BackColor = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Models.Color color = new WindowsFormsApplication1.Models.Color();
            int resultado = 0;


            if ((!string.IsNullOrWhiteSpace(txtNombreColor.Text)) && (!string.IsNullOrWhiteSpace(txtValorColor.Text)))
            {
                color.nombreColor = txtNombreColor.Text.Trim();
                color.valorColor = txtValorColor.Text.Trim();
                resultado = ColorDao.Agregar(color);
            }
            else
            {
                resultado = 0;
                MessageBox.Show("Debe ingresar los valores");
            }

            if (resultado > 0)
            {
                
                MessageBox.Show("Color Guardada Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar el Color", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
