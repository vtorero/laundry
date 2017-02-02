using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public class BdComun
    {
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = new MySqlConnection("server=67.23.231.144; database=cualesmi_api; Uid=cualesmi_web; pwd=vji2002;");
            conectar.Open();
                return conectar;
          
        }
    }
}