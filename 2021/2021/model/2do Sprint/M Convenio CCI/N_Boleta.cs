using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace _2021
{
    public class N_Boleta
    {
        D_Boleta objd = new D_Boleta();

        public String N_Mantenimiento_BoletadeMatricula(E_Boleta obje)
        {
            return objd.D_Mantenimiento_BoletadeMatricula(obje);
        }
    }
}
