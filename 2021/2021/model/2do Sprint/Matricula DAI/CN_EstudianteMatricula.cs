using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace _2021
{
    public class CN_EstudianteMatricula
    {
        CD_EstudianteMatricula objd = new CD_EstudianteMatricula();

        public DataTable N_BuscarAlumnoMatriculado(CE_EstudianteMatriculado obje)
        {
            return objd.D_BuscarAlumnosMatriculados(obje);
        }

    }
}
