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
    public class D_Estudiante
    {
        //SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conentarsql"].ConnectionString);

        // MODULO PARA INSERTAR LOS DATOS DE ESTUDIANTE  EN LA BASE DE DATOS 
        public String D_Mantenimiento_EstudianteMatriculado(E_Estudiante Obje)
        {
            try
            {
                String accion = "";
                //Nos permitira obtener el procedimiento (nombre,variable)
                SqlCommand CMD = new SqlCommand("SP_Mantenimiento_EstudianteMatriculado", conexion.LeerCadena());
                //Nos permitira usar parametros o variables desl sql 
                CMD.CommandType = CommandType.StoredProcedure;
                //BUSCAR POR EL codigo,nombre,tipo,tema,horas
                CMD.Parameters.AddWithValue("@CodEstudiante", Obje.Codigo);
                CMD.Parameters.AddWithValue("@Nombre", Obje.Nombre);
                CMD.Parameters.AddWithValue("@AppPaterno", Obje.AppPaterno);
                CMD.Parameters.AddWithValue("@AppMaterno", Obje.AppMaterno);
                CMD.Parameters.AddWithValue("@DNI", Obje.DNI);
                CMD.Parameters.AddWithValue("@Email", Obje.Email);
                CMD.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = Obje.accion;
                CMD.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
                //if (conexion.State == ConnectionState.Open) conexion.Close();
                //conexion.Open();
                CMD.ExecuteNonQuery();
                accion = CMD.Parameters["@accion"].Value.ToString();
                //conexion.Close();
                return accion;
            }
            catch (Exception)
            {
                throw;
            }


        }
        //MODULO PARA BUSCAR POR CODIGO A ALUMNO 
        public DataTable D_Buscar_EstudianteMatriculado(E_Estudiante Obje)
        {
            try
            {
                //Nos permitira obtener el procedimiento (nombre,variable)
                SqlCommand CMD = new SqlCommand("SP_Buscar_EstudianteMatriculado", conexion.LeerCadena());
                //Nos permitira usar parametros o variables desl sql 
                CMD.CommandType = CommandType.StoredProcedure;
                //BUSCAR POR EL NOMBRE SE CURSO
                CMD.Parameters.AddWithValue("@Codigo", Obje.Codigo);
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
        //---------------------------------------------------------------------------------
        

    }
}
