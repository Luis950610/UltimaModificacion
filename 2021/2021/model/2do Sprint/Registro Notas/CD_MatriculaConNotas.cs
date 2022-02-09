using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace _2021
{
    public class CD_MatriculaConNotas
    {
        /*Conectar el proyecto con la base de datos mediante la cadena de conexion que se establecio en el AppConfig */
        //SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        /*Metodo para ejecutar el procedimiento almacenado "SP_MostrarNotasAlumnos" de la base de datos*/
        public DataTable MostrarCargaAcademicaConDocentes(string Año, string Periodo,string Tipo)
        {
            //Se crea una instancia para almacenar los registros al ejecutar el procedimiento almacenado
            SqlDataReader LeerFilas;
            //Se indica el nombre del procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_MostrarCargaAcademica_Docentes", conexion.LeerCadena());
            //Se indica que el comando es del tipo procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Se abre la conexion
            //conexion.Open();
            //Paso de parametros:
            cmd.Parameters.AddWithValue("@Año", Año);
            cmd.Parameters.AddWithValue("@Periodo", Periodo);
            cmd.Parameters.AddWithValue("@Tipo", Tipo);

            //Se crea una instancia del DATATABLE
            DataTable tabla = new DataTable();

            try //Se ejecuta el comando si no existe ningun tipo de error
            {
                //Se ejecuta el procedimiento almacenado
                LeerFilas = cmd.ExecuteReader();

            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.ToString());
                throw;
            }
            //Se carga todos los registros a la tabla
            tabla.Load(LeerFilas);
            //Se cierra la conexion
            //conexion.Close();
            //Retorna la tabla
            return tabla;

        }

        /*Metodo para ejecutar el procedimiento almacenado "SP_MostrarNotasAlumnos" y una cadena para buscar por el campo CodCurso de la base de datos*/
        public DataTable MostrarCargaAcademicaConDocentesYBuscarxCodigoCurso(string Año, string Periodo, string Tipo,string cadena)
        {
            //Se crea una instancia para almacenar los registros al ejecutar el procedimiento almacenado
            SqlDataReader LeerFilas;
            //Se indica el nombre del procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_MostrarCargaAcademica_Docentes_BuscarxCodigoCurso", conexion.LeerCadena());
            //Se indica que el comando es del tipo procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Se abre la conexion
            //conexion.Open();
            //Paso de parametros:
            cmd.Parameters.AddWithValue("@Año", Año);
            cmd.Parameters.AddWithValue("@Periodo", Periodo);
            cmd.Parameters.AddWithValue("@Tipo", Tipo);
            cmd.Parameters.AddWithValue("@cadena", cadena);

            //Se crea una instancia del DATATABLE
            DataTable tabla = new DataTable();

            try //Se ejecuta el comando si no existe ningun tipo de error
            {
                //Se ejecuta el procedimiento almacenado
                LeerFilas = cmd.ExecuteReader();

            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.ToString());
                throw;
            }
            //Se carga todos los registros a la tabla
            tabla.Load(LeerFilas);
            //Se cierra la conexion
            //conexion.Close();
            //Retorna la tabla
            return tabla;

        }


        /*Metodo para ejecutar el procedimiento almacenado "SP_MostrarNotasAlumnos" y una cadena para buscar por el campo CodCurso de la base de datos*/
        public DataTable MostrarCargaAcademicaConDocentesYBuscarxNombreAsignatura(string Año, string Periodo, string Tipo, string cadena)
        {
            //Se crea una instancia para almacenar los registros al ejecutar el procedimiento almacenado
            SqlDataReader LeerFilas;
            //Se indica el nombre del procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_MostrarCargaAcademica_Docentes_BuscarxNombreAsignatura", conexion.LeerCadena());
            //Se indica que el comando es del tipo procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Se abre la conexion
            //conexion.Open();
            //Paso de parametros:
            cmd.Parameters.AddWithValue("@Año", Año);
            cmd.Parameters.AddWithValue("@Periodo", Periodo);
            cmd.Parameters.AddWithValue("@Tipo", Tipo);
            cmd.Parameters.AddWithValue("@cadena", cadena);

            //Se crea una instancia del DATATABLE
            DataTable tabla = new DataTable();

            try //Se ejecuta el comando si no existe ningun tipo de error
            {
                //Se ejecuta el procedimiento almacenado
                LeerFilas = cmd.ExecuteReader();

            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.ToString());
                throw;
            }
            //Se carga todos los registros a la tabla
            tabla.Load(LeerFilas);
            //Se cierra la conexion
            //conexion.Close();
            //Retorna la tabla
            return tabla;

        }

        /*Metodo para ejecutar el procedimiento almacenado "SP_MostrarNotasAlumnos" y una cadena para buscar por el campo Docente de la base de datos*/
        public DataTable MostrarCargaAcademicaConDocentesYBuscarxDocente(string Año, string Periodo, string Tipo, string cadena)
        {
            //Se crea una instancia para almacenar los registros al ejecutar el procedimiento almacenado
            SqlDataReader LeerFilas;
            //Se indica el nombre del procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_MostrarCargaAcademica_Docentes_BuscarxDocente", conexion.LeerCadena());
            //Se indica que el comando es del tipo procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Se abre la conexion
            //conexion.Open();
            //Paso de parametros:
            cmd.Parameters.AddWithValue("@Año", Año);
            cmd.Parameters.AddWithValue("@Periodo", Periodo);
            cmd.Parameters.AddWithValue("@Tipo", Tipo);
            cmd.Parameters.AddWithValue("@cadena", cadena);

            //Se crea una instancia del DATATABLE
            DataTable tabla = new DataTable();

            try //Se ejecuta el comando si no existe ningun tipo de error
            {
                //Se ejecuta el procedimiento almacenado
                LeerFilas = cmd.ExecuteReader();

            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.ToString());
                throw;
            }
            //Se carga todos los registros a la tabla
            tabla.Load(LeerFilas);
            //Se cierra la conexion
            //conexion.Close();
            //Retorna la tabla
            return tabla;

        }

        /*=================================================================================
         *                           PARA EL  REGISTRO DE NOTAS
         ===================================================================================
         */

        /*Metodo para ejecutar el procedimiento almacenado "SP_MostrarNotasAlumnos" de la base de datos*/
        public DataTable SelectRegistroNotas(string CodCurso,string Grupo,string Año, string Periodo)
        {
            //Se crea una instancia para almacenar los registros al ejecutar el procedimiento almacenado
            SqlDataReader LeerFilas;
            //Se indica el nombre del procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_MostrarNotasAlumnos", conexion.LeerCadena());
            //Se indica que el comando es del tipo procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Se abre la conexion
            //conexion.Open();
            //Paso de parametros:
            cmd.Parameters.AddWithValue("@CodCurso", CodCurso);
            cmd.Parameters.AddWithValue("@Grupo", Grupo);
            cmd.Parameters.AddWithValue("@Año", Año);
            cmd.Parameters.AddWithValue("@Periodo", Periodo);
            //Se crea una instancia del DATATABLE
            DataTable tabla = new DataTable();

            try //Se ejecuta el comando si no existe ningun tipo de error
            {
                //Se ejecuta el procedimiento almacenado
                LeerFilas = cmd.ExecuteReader();

            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.ToString());
                throw;
            }
            //Se carga todos los registros a la tabla
            tabla.Load(LeerFilas);
            //Se cierra la conexion
            //conexion.Close();
            //Retorna la tabla
            return tabla;

        }

        /*Metodo para ejecutar el procedimiento almacenado "SP_MostrarNotasAlumnos"  y buscar por codigo de alumno de la base de datos*/
        public DataTable SelectRegistroNotasYBuscarxCodigoAlumno(string CodCurso, string Grupo, string Año, string Periodo, string cadena)
        {
            //Se crea una instancia para almacenar los registros al ejecutar el procedimiento almacenado
            SqlDataReader LeerFilas;
            //Se indica el nombre del procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_MostrarNotasAlumnos_BuscarxCodigo", conexion.LeerCadena());
            //Se indica que el comando es del tipo procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Se abre la conexion
            //conexion.Open();
            //Paso de parametros:
            cmd.Parameters.AddWithValue("@CodCurso", CodCurso);
            cmd.Parameters.AddWithValue("@Grupo", Grupo);
            cmd.Parameters.AddWithValue("@Año", Año);
            cmd.Parameters.AddWithValue("@Periodo", Periodo);
            cmd.Parameters.AddWithValue("@cadena", cadena);

            //Se crea una instancia del DATATABLE
            DataTable tabla = new DataTable();

            try //Se ejecuta el comando si no existe ningun tipo de error
            {
                //Se ejecuta el procedimiento almacenado
                LeerFilas = cmd.ExecuteReader();

            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.ToString());
                throw;
            }
            //Se carga todos los registros a la tabla
            tabla.Load(LeerFilas);
            //Se cierra la conexion
            //conexion.Close();
            //Retorna la tabla
            return tabla;

        }

        /*Metodo para ejecutar el procedimiento almacenado "SP_MostrarNotasAlumnos"  y buscar por apellidos y nombres de alumno de la base de datos*/
        public DataTable SelectRegistroNotasYBuscarxApellidosNombres(string CodCurso, string Grupo, string Año, string Periodo, string cadena)
        {
            //Se crea una instancia para almacenar los registros al ejecutar el procedimiento almacenado
            SqlDataReader LeerFilas;
            //Se indica el nombre del procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_MostrarNotasAlumnos_BuscarxApellidosNombres", conexion.LeerCadena());
            //Se indica que el comando es del tipo procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Se abre la conexion
            //conexion.Open();
            //Paso de parametros:
            cmd.Parameters.AddWithValue("@CodCurso", CodCurso);
            cmd.Parameters.AddWithValue("@Grupo", Grupo);
            cmd.Parameters.AddWithValue("@Año", Año);
            cmd.Parameters.AddWithValue("@Periodo", Periodo);
            cmd.Parameters.AddWithValue("@cadena", cadena);

            //Se crea una instancia del DATATABLE
            DataTable tabla = new DataTable();

            try //Se ejecuta el comando si no existe ningun tipo de error
            {
                //Se ejecuta el procedimiento almacenado
                LeerFilas = cmd.ExecuteReader();

            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.ToString());
                throw;
            }
            //Se carga todos los registros a la tabla
            tabla.Load(LeerFilas);
            //Se cierra la conexion
            //conexion.Close();
            //Retorna la tabla
            return tabla;

        }


        /*=================================================================================
         *                           PARA Obtener la tabla paquete
         ===================================================================================
         */

        public DataTable ObtenerCursosPaquete(string CodCurso)
        {
            //Se crea una instancia para almacenar los registros al ejecutar el procedimiento almacenado
            SqlDataReader LeerFilas;
            //Se indica el nombre del procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_ObtenerCursosPaquete", conexion.LeerCadena());
            //Se indica que el comando es del tipo procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Se abre la conexion
            //conexion.Open();
            //Paso de parametros:
            cmd.Parameters.AddWithValue("@CodCurso", CodCurso);

            //Se crea una instancia del DATATABLE
            DataTable tabla = new DataTable();

            try //Se ejecuta el comando si no existe ningun tipo de error
            {
                //Se ejecuta el procedimiento almacenado
                LeerFilas = cmd.ExecuteReader();

            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.ToString());
                throw;
            }
            //Se carga todos los registros a la tabla
            tabla.Load(LeerFilas);
            //Se cierra la conexion
            //conexion.Close();
            //Retorna la tabla
            return tabla;

        }

        /*==========================================================================================================
        *                           PARA Crear el registro de notas y limpiar el registro de notas
        ============================================================================================================
        */
        public void CrearRegistroDeNotas(string CodMatricula,float nota1, float nota2, float nota3, float nota4, float nota5, float nota6, float nota7, float nota8, float nota9, float nota10)
        {
            //Se indica el nombre del procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_CrearRegistroDeNotas", conexion.LeerCadena());
            //Se indica que el comando es del tipo procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Se abre la conexion
            //conexion.Open();
            //Paso de parametros:
            cmd.Parameters.AddWithValue("@CodMatricula", CodMatricula);
            cmd.Parameters.AddWithValue("@nota1", nota1);
            cmd.Parameters.AddWithValue("@nota2", nota2);
            cmd.Parameters.AddWithValue("@nota3", nota3);
            cmd.Parameters.AddWithValue("@nota4", nota4);
            cmd.Parameters.AddWithValue("@nota5", nota5);
            cmd.Parameters.AddWithValue("@nota6", nota6);
            cmd.Parameters.AddWithValue("@nota7", nota7);
            cmd.Parameters.AddWithValue("@nota8", nota8);
            cmd.Parameters.AddWithValue("@nota9", nota9);
            cmd.Parameters.AddWithValue("@nota10", nota10);

            //Se crea una instancia del DATATABLE
            DataTable tabla = new DataTable();

            try //Se ejecuta el comando si no existe ningun tipo de error
            {
                //Se ejecuta el procedimiento almacenado
                cmd.ExecuteReader();

            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.ToString());
                throw;
            }
            //conexion.Close();
            

        }

        public void LimpiarRegistroDeNotas(string CodMatricula)
        {
            //Se indica el nombre del procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_LimpiarRegistroDeNotas", conexion.LeerCadena());
            //Se indica que el comando es del tipo procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Se abre la conexion
            //conexion.Open();
            //Paso de parametros:
            cmd.Parameters.AddWithValue("@CodMatricula", CodMatricula);

            //Verificar algun tipo de error al ejecutar el procedimiento

            try //El comando se ejecuta de forma exitosa
            {
                cmd.ExecuteReader();
            }
            catch (SqlException EX) //Existe algun tipo de error al ejecutar el procedimiento almacenado
            {
                MessageBox.Show(EX.ToString());
                throw;
            }
            //conexion.Close();

        }


    }
}
