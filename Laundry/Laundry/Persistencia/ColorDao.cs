﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Models;

namespace WindowsFormsApplication1.Persistencia
{
    class ColorDao
    {
        public static int Agregar(Color color)
        {
            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into Color (nombreColor, valorColor) values ('{0}','{1}')",
                color.nombreColor, color.valorColor), BdComun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static List<Color> Buscar()
        {
            List<Color> _lista = new List<Color>();

            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT idColor nombreColor FROM Color"), BdComun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();

            while (_reader.Read())
            {
                Color color = new Color();

                color.idColor= _reader.GetInt32(0);
                color.nombreColor= _reader.GetString(1);
                color.valorColor= _reader.GetString(2);
                

                _lista.Add(color);
            }

            return _lista;
        }


    }
}