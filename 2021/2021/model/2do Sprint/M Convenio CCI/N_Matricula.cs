using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace _2021
{
    public class N_Matricula
    {
        D_Matricula objetoCD_Matricula = new D_Matricula();
        //----------------------------------------------------------
        public DataTable N_Detalle_MatriculadoCurso()
        {
            return objetoCD_Matricula.D_Detalle_MatriculadoCurso();
        }
        public DataTable N_Detalle_Matricula_Estudiante_Pago()
        {
            return objetoCD_Matricula.D_Detalle_Matricula_Estudiante_Pago();
        }
        public String N_InseratarDatosMatricula(E_Matricula Obj)
        {
            return objetoCD_Matricula.D_InsertarDatosMatricula(Obj);
        }
    }
    
}
