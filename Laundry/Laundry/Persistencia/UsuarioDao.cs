using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Models;

namespace WindowsFormsApplication1.Persistencia
{
    class UsuarioDao
    {
        public  static Usuario Consultar(string user,string pass)
        {
            List<Usuario> _lista = new List<Usuario>();

            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT * FROM usuario where nombre='{0}' and password='{1}'",user,pass), BdComun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            Usuario usuario = new Usuario();
            while (_reader.Read())
            {
                 usuario.idUsuario = _reader.GetInt32(0);
                usuario.nombreUsuario = _reader.GetString(1);
                usuario.apellidoUsuario = _reader.GetString(2);
                usuario.emailUsuario = _reader.GetString(3);
                usuario.sucursalUsuario = _reader.GetString(4);
                usuario.tipoUsuario = _reader.GetInt32(6);

              
            }
            return usuario;
        }

    }
}
