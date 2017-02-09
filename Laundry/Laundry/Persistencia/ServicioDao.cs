using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Models;

namespace WindowsFormsApplication1.Persistencia
{
    class ServicioDao
    {
        public static int Agregar(Servicio servicio)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into Servicio (nombreServicio, precioServicio) values ('{0}','{1}')",
                servicio.NombreServicio, servicio.precioServicio), BdComun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static List<Servicio> Buscar()
        {
            List<Servicio> _lista = new List<Servicio>();

            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT * FROM Servicio"), BdComun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();

            while (_reader.Read())
            {
                Servicio servicio = new Servicio();
                servicio.idServicio = _reader.GetInt32(0);
                servicio.NombreServicio = _reader.GetString(1);
                servicio.precioServicio = _reader.GetFloat(2);
                _lista.Add(servicio);
            }

            return _lista;
        }
    }
}
