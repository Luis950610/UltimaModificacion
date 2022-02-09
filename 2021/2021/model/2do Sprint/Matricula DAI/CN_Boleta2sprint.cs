using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace _2021
{
    public class CN_Boleta2sprint
    {
        CD_Boleta2sprint objd = new CD_Boleta2sprint();

        public String N_Mantenimiento_BoletadeMatricula(CE_Boleta2sprint obje)
        {
            return objd.D_Mantenimiento_BoletadeMatricula(obje);
        }
        public DataTable N_Listar_Boleta()
        {
            return objd.D_Listar_Boleta();
        }
    }
}
