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
    public class CD_MatriculaPostergada
    {
        /*Conectar el proyecto con la base de datos mediante la cadena de conexion que se establecio en el AppConfig */
        //SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        /*Metodo para ejecutar el procedimiento almacenado  de la base de datos*/
        public void InsertarMatriculaPostergada(string CodMatricula,string CodEstudiante)
        {
            //Se indica el nombre del procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_InsertarMatriculaPostergada", conexion.LeerCadena());
            //Se indica que el comando es del tipo procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Se abre la conexion
            //conexion.Open();
            //Paso de parametros:
            cmd.Parameters.AddWithValue("@CodMatricula", CodMatricula);
            cmd.Parameters.AddWithValue("@CodEstudiante", CodEstudiante);

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
