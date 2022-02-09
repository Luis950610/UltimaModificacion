using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace _2021
{
    public class CN_Matricula2sprint
    {
        CD_Matricula2sprint objetoCD_Matricula = new CD_Matricula2sprint();
        public DataTable N_Detalle_MatriculaDAI()
        {
            return objetoCD_Matricula.D_Detalle_MatriculaDAI();
        }


    }
    
}
