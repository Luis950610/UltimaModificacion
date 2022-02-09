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
    internal class CD_CambioGrupo
    {
        conexion conexion = new conexion();

        /*Conectar el proyecto con la base de datos mediante la cadena de conexion que se establecio en el AppConfig */
        //SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        /*Metodo para ejecutar el procedimiento almacenado SP_SeleccionCursos de la base de datos*/
   

        
        public DataTable BuscarCursosxTodosLosCamposxCategorias(string Tipo, string Periodo, string Año)
        {
            //Esta variable almacenara los registros del procedimiento almacenado
            SqlDataReader LeerFilas;
            //Se indica el nombre del procedimieto almacenado y la cadena de conexion
            SqlCommand cmd = new SqlCommand("SP_SeleccionCursosxTipoPeriodoAnio", conexion.LeerCadena());
            //Se indica el tipo del procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Se abre la conexion
            conexion.LeerCadena();
            //Paso de parametros:
            cmd.Parameters.AddWithValue("@Tipo", Tipo);
            cmd.Parameters.AddWithValue("@Periodo", Periodo);
            cmd.Parameters.AddWithValue("@Año", Año);
            //cmd.Parameters.AddWithValue("@cadena", cadena);
            //Se crea una instancia del DATATABLE
            DataTable tabla = new DataTable();

            try //Se ejecuta el comando si no existe ningun tipo de error
            {
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
            conexion.LeerCadena();
            //Retorna la tabla
            return tabla;
        }

        //=====================================================================
        /*Metodo para ejecutar el procedimiento almacenado SP_SeleccionAlumnosxCursos de la base de datos*/
        public DataTable SelectAlumnosxCurso(string Tipo, string Periodo, string Año, string CodCurso)
        {
            //Se crea una instancia para almacenar los registros al ejecutar el procedimiento almacenado
            SqlDataReader LeerFilas;
            //Se indica el nombre del procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_SeleccionAlumnosxCurso", conexion.LeerCadena());
            //Se indica que el comando es del tipo procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Se abre la conexion
            conexion.LeerCadena();
            //Paso de parametros:
            cmd.Parameters.AddWithValue("@Tipo", Tipo);
            cmd.Parameters.AddWithValue("@Periodo", Periodo);
            cmd.Parameters.AddWithValue("@Año", Año);
            cmd.Parameters.AddWithValue("@CodCurso", Int64.Parse(CodCurso));

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
            conexion.LeerCadena();
            //Retorna la tabla
            return tabla;

        }
        /*Metodo para ejecutar el procedimiento almacenado sp_CambioGrupo de la base de datos*/
        public DataTable CambioGrupo(string CodCurso, string NCodCurso, string NGrupo, string CodAlumno)
        {
            //Se crea una instancia para almacenar los registros al ejecutar el procedimiento almacenado
            SqlDataReader LeerFilas;
            //Se indica el nombre del procedimiento almacenado
            SqlCommand cmd = new SqlCommand("sp_CambioGrupoAlum", conexion.LeerCadena());
            //Se indica que el comando es del tipo procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Se abre la conexion
            conexion.LeerCadena();
            //Paso de parametros:
            //MessageBox.Show(CodCurso + " " + NCodCurso + " " + NGrupo + " " + CodAlumno);

            cmd.Parameters.AddWithValue("@CodCurso", Int64.Parse(CodCurso));
            cmd.Parameters.AddWithValue("@NCodCurso", Int64.Parse(NCodCurso));
            cmd.Parameters.AddWithValue("@NGrupo", char.Parse(NGrupo));
            cmd.Parameters.AddWithValue("@CodAlumno", Int64.Parse(CodAlumno));

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
            conexion.LeerCadena();
            //Retorna la tabla
            return tabla;

        }
    }
}
