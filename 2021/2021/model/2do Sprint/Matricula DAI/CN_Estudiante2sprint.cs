using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace _2021
{
    public class CN_Estudiante2sprint
    {
        CD_Estudiante2sprint objd = new CD_Estudiante2sprint();
        public DataTable N_listar_Alumnos()
        {
            return objd.D_listar_Alumno();
        }
        public DataTable N_Buscar_EstudianteMatriculadoC(CE_Estudiante2sprint obje)
        {
            return objd.D_Buscar_AlumnoC(obje);
        }
        public DataTable N_Buscar_EstudianteMatriculadoN(CE_Estudiante2sprint obje)
        {
            return objd.D_Buscar_AlumnoN(obje);
        }
        public DataTable N_Buscar_EstudianteMatriculadoAP(CE_Estudiante2sprint obje)
        {
            return objd.D_Buscar_AlumnoAP(obje);
        }
        public DataTable N_Buscar_EstudianteMatriculadoAM(CE_Estudiante2sprint obje)
        {
            return objd.D_Buscar_AlumnoAM(obje);
        }
        public String N_Insertar_EstudianteMatriculado(CE_Estudiante2sprint obje)
        {
            return objd.D_Insertar_EstudianteMatriculado(obje);
        }

    }
}
