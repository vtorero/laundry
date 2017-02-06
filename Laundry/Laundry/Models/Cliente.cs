using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Models
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public string NombreCliente{ get; set; }
        public string dniCliente { get; set; }
        public string correoCliente{ get; set; }
        public string direccionCliente { get; set; }
        public string telefonoCliente { get; set; }



        public Cliente() { }

        public Cliente(int idCliente, string NombreC, string dni, string correo,string direccion,string telefono)
        {
            this.idCliente = idCliente;
            this.NombreCliente = NombreC;
            this.dniCliente = dni;
            this.correoCliente = correo;
            this.direccionCliente = direccion;
            this.telefonoCliente = telefono;
            
        }
    }
}
