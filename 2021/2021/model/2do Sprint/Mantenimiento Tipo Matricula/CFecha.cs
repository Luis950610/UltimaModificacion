using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021
{
    public class CFecha
    {
        public string Año { get; set; }
        public string Mes { get; set; }
        public string Dia { get; set; }
        public CFecha()
        {

        }
        public CFecha(string pAño, string pMes, string pDia)
        {
            this.Año = pAño;
            this.Mes = pMes;
            this.Dia = pDia;
            
        }
        public CFecha(string pAño)
        {
            this.Año = pAño;
        }
    }
}
