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
        int pos;
        public frmColor()
        {
            
            InitializeComponent();
        }

     

           

        private void tabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (dgvColores.RowCount == 0)
            {
                dgvColores.DataSource = ColorDao.Listar();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            pos = dgvColores.CurrentRow.Index;
            lblCodigo.Visible = true;
            txtCodigo.Visible = true;
            txtCodigo.Text = Convert.ToString(dgvColores[0, pos].Value);
            txtNombreColor.Text = Convert.ToString(dgvColores[1, pos].Value);
            txtValorColor.Text = Convert.ToString(dgvColores[2, pos].Value);
            lblColor.BackColor = System.Drawing.ColorTranslator.FromHtml(Convert.ToString(dgvColores[2,pos].Value));
            
            tabControl1.SelectedTab = tabPage1;
            btnGuardar.Text = "&Actualizar";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                txtValorColor.Text = colorDialog1.Color.Name;
                if (colorDialog1.Color.IsKnownColor)
                {
                    lblColor.BackColor = colorDialog1.Color;
                    txtValorColor.Text = colorDialog1.Color.Name;
                }
                else {
                    txtValorColor.Text = "#"+colorDialog1.Color.Name;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
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
