using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace _2021
{
    public class N_CursoActivo
    {
        D_CursoActivo objd = new D_CursoActivo();

        public DataTable N_Mostrar_CursoActivo()
        {
            return objd.D_Mostrar_CursoActivo();
        }
        public DataTable N_Detalle_Alumnos_Matriculados(E_CursoActivo obje)
        {
            return objd.D_Detalle_Alumnos_Matriculados(obje);
        }

    }
}
