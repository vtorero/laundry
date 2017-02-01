using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Models
{
    public class Prenda
    {
        public int idPrenda { get; set; }
        public string NombrePrenda { get; set; }
        public string Descripcion { get; set; }
        public float precioServicio { get; set; }



        public Prenda() { }

        public Prenda(int idPrenda, string NombrePrenda, string Descripcion, float precioServicio)
        {
            this.idPrenda = idPrenda;
            this.NombrePrenda = NombrePrenda;
            this.Descripcion = Descripcion;
            this.precioServicio = precioServicio;

        }

    }
}