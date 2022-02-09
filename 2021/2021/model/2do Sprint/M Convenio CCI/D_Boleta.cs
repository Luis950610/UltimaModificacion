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
    public class D_Boleta
    {
        //SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conentarsql"].ConnectionString);

        // MODULO PARA INSERTAR DATOS DE BOLETA ESTUDIANTE EN LA BASE DE DATOS 
        public String D_Mantenimiento_BoletadeMatricula(E_Boleta Obje)
        {
            try
            {
                String accion = "";
                //Nos permitira obtener el procedimiento (nombre,variable)
                SqlCommand CMD = new SqlCommand("SP_Mantenimiento_BoletadeMatricula", conexion.LeerCadena());
                //Nos permitira usar parametros o variables desl sql 
                CMD.CommandType = CommandType.StoredProcedure;
                //BUSCAR POR EL codigo,nombre,tipo,tema,horas
                CMD.Parameters.AddWithValue("@CodBoleta", Obje.Codigo);
                CMD.Parameters.AddWithValue("@NroSerie", Obje.NroSerie);
                CMD.Parameters.AddWithValue("@FechaEmision", Obje.FechaEmision);
                CMD.Parameters.AddWithValue("@Costo", Obje.Costo);
                CMD.Parameters.AddWithValue("@TipoDsto", Obje.TipoDscto);
                CMD.Parameters.AddWithValue("@Pago", Obje.Pago);
                CMD.Parameters.AddWithValue("@Codigo_CursoActivo", Obje.Codigo_CursoActivo);
                CMD.Parameters.AddWithValue("@CodEstudiante", Obje.CodEstudiante);
                CMD.Parameters.AddWithValue("@Observacion", Obje.Observacion);
                CMD.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = Obje.accion;
                CMD.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
                
                CMD.ExecuteNonQuery();
                accion = CMD.Parameters["@accion"].Value.ToString();
                
                return accion;

            }
            catch (Exception )
            {
               
                throw;
           
            }
            
            

        }

        
    }
    
}
