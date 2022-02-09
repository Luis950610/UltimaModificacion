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
    public class CD_CursoDAI
    {
        
        
        //SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conentarsql"].ConnectionString);
        public DataTable D_listar_Curso()
        {
            try
            {
                //Nos permitira obtener el procedimiento (nombre,variable)sp_listar_mCurso
                SqlCommand CMD = new SqlCommand("sp_listar_mCurso", conexion.LeerCadena());
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
        public DataTable D_Buscar_CursoC(CE_CursoDAI Obje)
        {
            try {
                //Nos permitira obtener el procedimiento (nombre,variable)
                SqlCommand CMD = new SqlCommand("sp_Buscar_mCurso", conexion.LeerCadena());
                //Nos permitira usar parametros o variables desl sql 
                CMD.CommandType = CommandType.StoredProcedure;
                //BUSCAR POR EL NOMBRE SE CURSO
                CMD.Parameters.AddWithValue("@Nombre", Obje.CodCurso);
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
        public DataTable D_Buscar_CursoN(CE_CursoDAI Obje)
        {
            try
            {
                //Nos permitira obtener el procedimiento (nombre,variable)
                SqlCommand CMD = new SqlCommand("sp_Buscar_mCurso", conexion.LeerCadena());
                //Nos permitira usar parametros o variables desl sql 
                CMD.CommandType = CommandType.StoredProcedure;
                //BUSCAR POR EL NOMBRE SE CURSO
                CMD.Parameters.AddWithValue("@Nombre", Obje.Nombre);
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
