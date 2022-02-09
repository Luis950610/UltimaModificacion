using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace _2021
{
    public class DCurso
    {
         // CN
        public DataTable D_listar_mCurso()
        {
            try
            {
                // objetos que nos permitiran recuperar registros de la base de datos
                DataTable tabla = new DataTable();
                SqlDataReader Leer;
                // Crear objeto comando y pasar por parametro el storedprocedure a ejecutar
                // y establecer la conexion con la base de datos
                SqlCommand cmd = new SqlCommand("sp_listar_mCurso", conexion.LeerCadena());
                cmd.CommandType = CommandType.StoredProcedure;

                                                                   // abrir conexion
                Leer = cmd.ExecuteReader();                                             // extraer los registros de la tabla estudiante
                tabla.Load(Leer);                                                       // cargar los registros en el objeto tabla
                                                              // cerrar conexion
                return tabla;                                                           // retornar la tabla con los registros obtenidos
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public DataTable D_Buscar_mCurso(ClassEntidad Obje) //ClassEntidad Obje
        //{
        //    //Nos permitira obtener el procedimiento (nombre,variable)
        //    SqlCommand CMD = new SqlCommand("sp_Buscar_mCurso", conexion.CN());
        //    //Nos permitira usar parametros o variables desl sql 
        //    CMD.CommandType = CommandType.StoredProcedure;
        //    //BUSCAR POR EL NOMBRE SE CURSO
        //    CMD.Parameters.AddWithValue("@Nombre", Obje.Nombre);
        //    //hace puente entre la base de datos y la tabla del formulario 
        //    SqlDataAdapter DA = new SqlDataAdapter(CMD);
        //    DataTable DT = new DataTable();
        //    DA.Fill(DT);
        //    return DT;
        //}

    }
}
