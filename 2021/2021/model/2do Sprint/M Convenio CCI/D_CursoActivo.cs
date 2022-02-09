using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace _2021
{
    public class D_CursoActivo
    {
        //SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conentarsql"].ConnectionString);
        // MODULO PARA MOSTRAR EN TABLA LOS CURSOS ACTIVOS
        public DataTable D_Mostrar_CursoActivo()
        {
            try { 
                //Nos permitira obtener el procedimiento (nombre,variable)
                SqlCommand CMD = new SqlCommand("SP_Mostrar_CursoActivo", conexion.LeerCadena());
                //hace puente entre la base de datos y la tabla del formulario 
                SqlDataAdapter DA = new SqlDataAdapter(CMD);//es como un filtro para q los datps se pueddan agregar auna tabla
                DataTable DT = new DataTable();
                //PARA LLENAR TABLA
                DA.Fill(DT);
                return DT;
            }
            catch (Exception)
            {
                throw;
            }

        }
        //MODULO PARA MOSTRAR DATOS DE ALUMNOS CONVENIO 
        public DataTable D_Detalle_Alumnos_Matriculados(E_CursoActivo Obje)
        {
            try
            {
                //Nos permitira obtener el procedimiento (nombre,variable)
                SqlCommand CMD = new SqlCommand("SP_Detalle_Alumnos_Matriculados", conexion.LeerCadena());
                //Nos permitira usar parametros o variables desl sql 
                CMD.CommandType = CommandType.StoredProcedure;
                //BUSCAR POR EL NOMBRE SE CURSO
                CMD.Parameters.AddWithValue("@CodCursoActivo", Obje.CodCurso);
                //hace puente entre la base de datos y la tabla del formulario 
                SqlDataAdapter DA = new SqlDataAdapter(CMD);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                return DT;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
    
}
