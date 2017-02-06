using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Models;

namespace WindowsFormsApplication1.Persistencia
{
    class ClienteDao
    {
        public static int Agregar(Cliente cliente)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into Cliente (nombreCliente, dniCliente, correoCliente,direccionCliente,telefonoCliente) values ('{0}','{1}','{2}','{3}','{4}')",
                cliente.NombreCliente, cliente.dniCliente, cliente.correoCliente,cliente.direccionCliente,cliente.telefonoCliente), BdComun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static List<Cliente> Buscar()
        {
            List<Cliente> _lista = new List<Cliente>();

            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT * FROM Cliente"), BdComun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();

            while (_reader.Read())
            {
                Cliente cliente= new Cliente();
                cliente.idCliente = _reader.GetInt32(0);
                cliente.NombreCliente = _reader.GetString(1);
                cliente.dniCliente = _reader.GetString(2);
                cliente.correoCliente = _reader.GetString(3);
                cliente.direccionCliente = _reader.GetString(4);
                cliente.telefonoCliente = _reader.GetString(5);
                _lista.Add(cliente);
            }

            return _lista;
        }


    }
}
