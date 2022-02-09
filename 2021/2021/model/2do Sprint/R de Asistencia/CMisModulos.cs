using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _2021
{
    public class CMisModulos
    {
        public DataTable ListarCurso()
        {
            // //Nos permitira obtener el procedimiento (nombre,variable)
            SqlDataAdapter da = new SqlDataAdapter("ListarCurso", conexion.LeerCadena());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable BuscarDocente(CTCurso Obje)
        {

            //Nos permitira obtener el procedimiento (nombre,variable)
            SqlCommand CMD = new SqlCommand("BuscarNombreCurso", conexion.LeerCadena());
            //Nos permitira usar parametros o variables desl sql 
            CMD.CommandType = CommandType.StoredProcedure;
            //BUSCAR POR EL NOMBRE SE CURSO
            CMD.Parameters.AddWithValue("@Codigo", Obje.Nombre_Curso);
            //hace puente entre la base de datos y la tabla del formulario 
            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            return DT;

        }


    }
}
