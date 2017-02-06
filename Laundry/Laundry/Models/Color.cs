using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApplication1.Models
{
    public class Color
    {
         public int idColor { get; set; }
        public string nombreColor { get; set; }
        public string valorColor { get; set; }
        



        public  Color() { }

        public Color(int idColor, string nombreColor, string valorColor)
        {
            this.idColor = idColor;
            this.nombreColor= nombreColor;
            this.valorColor=valorColor   ;
            

        }
    }
}
