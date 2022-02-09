using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021
{
    public class CFecha1
    {
        public int Año { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }
        public CFecha1()
        {

        }

        public CFecha1(int pAño, int pMes, int pDia)
        {
            this.Año = pAño;
            this.Mes = pMes;
            this.Dia = pDia;
        }
        public CFecha1(int pAño)
        {
            this.Año = pAño;
        }
    }
}
