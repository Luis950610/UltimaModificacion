using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//using CapaDatos;
using System.Data.SqlClient;

namespace _2021
{
    internal class CN_CambioGrupo
    {
        /*Se Crea una instancia de la Clase CD_CursosActivos*/
        CD_CambioGrupo objetoCD_CambioGrupo = new CD_CambioGrupo();
        //Metodo para Mostrar los registros de los Cursos Activos de la base de datos
        

        //Metodo para mostrar y buscar por categoria y por todos los campos de la tabla Cursos Activos
        public DataTable MostrarBuscarCursosxTodosLosCamposxCategorias(string Tipo, string Periodo, string Año)
        {
            DataTable tablaCD = new DataTable();

            tablaCD = objetoCD_CambioGrupo.BuscarCursosxTodosLosCamposxCategorias(Tipo, Periodo, Año);

            return tablaCD;
        }
        //=====================================================================
        //Mostrar alumnos matriculados en un curso
        public DataTable MostrarAlumnosxCurso(string Tipo, string Periodo, string Año, string CodCurso)
        {
            DataTable tablaCD = new DataTable();
            tablaCD = objetoCD_CambioGrupo.SelectAlumnosxCurso(Tipo, Periodo, Año, CodCurso);
            return tablaCD;
        }
        public DataTable CambioGrupo(string CodCurso, string NCodCurso, string NGrupo, string CodAlumno)
        {
            DataTable tablaCD = new DataTable();
            tablaCD = objetoCD_CambioGrupo.CambioGrupo(CodCurso, NCodCurso, NGrupo, CodAlumno);
            return tablaCD;
        }
    }

}
