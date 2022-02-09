using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace _2021
{
    public class CN_MatriculaConNotas
    {
        /*Se Crea una instancia de la Clase CD_CargaAcademica*/
        CD_MatriculaConNotas objetoCD_MatriculaConNotas = new CD_MatriculaConNotas();

        /*=================================================================================
         *                           PARA LA CARGA ACADEMICA
         ===================================================================================
         */

        //Metodo para Mostrar los registros de la carga Academica con los docentes encargados
        public DataTable MostrarCargaAcademicaConDocentes(string Año, string Periodo, string Tipo)
        {
            DataTable tablaCD = new DataTable();
            tablaCD = objetoCD_MatriculaConNotas.MostrarCargaAcademicaConDocentes(Año, Periodo.ToUpper(), Tipo);
            return tablaCD;
        }

        //Metodo para Mostrar los registros de la carga Academica con los docentes encargados y buscar por codigo
        public DataTable MostrarCargaAcademicaConDocentesYBuscarxCodigoCurso(string Año, string Periodo, string Tipo,string cadena)
        {
            DataTable tablaCD = new DataTable();
            if (cadena == "Buscar...")
            {
                tablaCD = objetoCD_MatriculaConNotas.MostrarCargaAcademicaConDocentesYBuscarxCodigoCurso(Año, Periodo.ToUpper(), Tipo, "");
            }
            else
            {
                if (cadena == "")
                    tablaCD = objetoCD_MatriculaConNotas.MostrarCargaAcademicaConDocentesYBuscarxCodigoCurso(Año, Periodo.ToUpper(), Tipo, "");
                else
                    tablaCD = objetoCD_MatriculaConNotas.MostrarCargaAcademicaConDocentesYBuscarxCodigoCurso(Año, Periodo.ToUpper(), Tipo, cadena);
            }

            return tablaCD;
        }

        //Metodo para Mostrar los registros de la carga Academica con los docentes encargados y buscar por nombre asignatura
        public DataTable MostrarCargaAcademicaConDocentesYBuscarxNombreAsignatura(string Año, string Periodo, string Tipo, string cadena)
        {
            DataTable tablaCD = new DataTable();
            if (cadena == "Buscar...")
            {
                tablaCD = objetoCD_MatriculaConNotas.MostrarCargaAcademicaConDocentesYBuscarxNombreAsignatura(Año, Periodo.ToUpper(), Tipo, "");
            }
            else
            {
                if (cadena == "")
                    tablaCD = objetoCD_MatriculaConNotas.MostrarCargaAcademicaConDocentesYBuscarxNombreAsignatura(Año, Periodo.ToUpper(), Tipo, "");
                else
                    tablaCD = objetoCD_MatriculaConNotas.MostrarCargaAcademicaConDocentesYBuscarxNombreAsignatura(Año, Periodo.ToUpper(), Tipo, cadena);
            }

            return tablaCD;
        }

        //Metodo para Mostrar los registros de la carga Academica con los docentes encargados y buscar por docente
        public DataTable MostrarCargaAcademicaConDocentesYBuscarxDocente(string Año, string Periodo, string Tipo, string cadena)
        {
            DataTable tablaCD = new DataTable();
            if (cadena == "Buscar...")
            {
                tablaCD = objetoCD_MatriculaConNotas.MostrarCargaAcademicaConDocentesYBuscarxDocente(Año, Periodo.ToUpper(), Tipo, "");
            }
            else
            {
                if (cadena == "")
                    tablaCD = objetoCD_MatriculaConNotas.MostrarCargaAcademicaConDocentesYBuscarxDocente(Año, Periodo.ToUpper(), Tipo, "");
                else
                    tablaCD = objetoCD_MatriculaConNotas.MostrarCargaAcademicaConDocentesYBuscarxDocente(Año, Periodo.ToUpper(), Tipo, cadena);
            }

            return tablaCD;

        }

        /*=================================================================================
         *                           PARA EL  REGISTRO DE NOTAS
         ===================================================================================
         */

        //Metodo para Mostrar los registros de la carga Academica con los docentes encargados
        public DataTable SelectRegistroNotas(string CodCurso,string Grupo, string Año, string Periodo)
        {
            DataTable tablaCD = new DataTable();
            tablaCD = objetoCD_MatriculaConNotas.SelectRegistroNotas(CodCurso,Grupo,Año, Periodo.ToUpper());
            return tablaCD;
        }

        //Metodo para Mostrar los registros del registro
        public DataTable SelectRegistroNotasYBuscarxCodigoAlumno(string CodCurso, string Grupo, string Año, string Periodo,string cadena)
        {
            DataTable tablaCD = new DataTable();
            if (cadena == "Buscar...")
            {
                tablaCD = objetoCD_MatriculaConNotas.SelectRegistroNotasYBuscarxCodigoAlumno(CodCurso,Grupo, Año, Periodo.ToUpper(), "");
            }
            else
            {
                if (cadena == "")
                    tablaCD = objetoCD_MatriculaConNotas.SelectRegistroNotasYBuscarxCodigoAlumno(CodCurso, Grupo, Año, Periodo.ToUpper(), "");
                else
                    tablaCD = objetoCD_MatriculaConNotas.SelectRegistroNotasYBuscarxCodigoAlumno(CodCurso, Grupo, Año, Periodo.ToUpper(), cadena);
            }

            return tablaCD;
        }

        //Metodo para Mostrar los registros de la carga Academica con los docentes encargados
        public DataTable SelectRegistroNotasYBuscarxApellidosNombres(string CodCurso, string Grupo, string Año, string Periodo, string cadena)
        {
            DataTable tablaCD = new DataTable();
            if (cadena == "Buscar...")
            {
                tablaCD = objetoCD_MatriculaConNotas.SelectRegistroNotasYBuscarxApellidosNombres(CodCurso, Grupo, Año, Periodo.ToUpper(), "");
            }
            else
            {
                if (cadena == "")
                    tablaCD = objetoCD_MatriculaConNotas.SelectRegistroNotasYBuscarxApellidosNombres(CodCurso, Grupo, Año, Periodo.ToUpper(), "");
                else
                    tablaCD = objetoCD_MatriculaConNotas.SelectRegistroNotasYBuscarxApellidosNombres(CodCurso, Grupo, Año, Periodo.ToUpper(), cadena);
            }
            return tablaCD;

        }

        //Metodo para mostrar los cursos que hay en un paquete
        public DataTable ObtenerCursosPaquete(string CodCurso)
        {
            DataTable tablaCD = new DataTable();
            tablaCD = objetoCD_MatriculaConNotas.ObtenerCursosPaquete(CodCurso);
            return tablaCD;

        }

        /*=================================================================================
         *                           PARA Crear y eliminar(limpiar registro)
         ===================================================================================
         */
        public void CrearRegistroDeNotas(string CodMatricula, float nota1, float nota2, float nota3, float nota4, float nota5, float nota6, float nota7, float nota8, float nota9, float nota10)
        {
            objetoCD_MatriculaConNotas.CrearRegistroDeNotas(CodMatricula, nota1, nota2, nota3, nota4, nota5, nota6, nota7, nota8, nota9, nota10);
        }
        public void LimpiarRegistroDeNotas(string CodMatricula)
        {
            objetoCD_MatriculaConNotas.LimpiarRegistroDeNotas(CodMatricula);
        }
    }
}
