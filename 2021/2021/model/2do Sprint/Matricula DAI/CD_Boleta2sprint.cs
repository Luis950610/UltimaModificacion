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
    public class CD_Boleta2sprint
    {
        //SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conentarsql"].ConnectionString);
        public String D_Mantenimiento_BoletadeMatricula(CE_Boleta2sprint Obje)
        {
            try

            {
                String accion = "";
                //Nos permitira obtener el procedimiento (nombre,variable)
                SqlCommand CMD = new SqlCommand("sp_insertar_Boleta", conexion.LeerCadena());
                //Nos permitira usar parametros o variables desl sql 
                CMD.CommandType = CommandType.StoredProcedure;
                //BUSCAR POR EL codigo,nombre,tipo,tema,horas
                CMD.Parameters.AddWithValue("@NroBoleta", Obje.NroBoleta);
                CMD.Parameters.AddWithValue("@NroSerie", Obje.NroSerie);
                CMD.Parameters.AddWithValue("@Costo ", Obje.Costo);
                CMD.Parameters.AddWithValue("@Pago", Obje.Pago);
                CMD.Parameters.AddWithValue("@CodCurso", Obje.CodCursoActivo);
                CMD.Parameters.AddWithValue("@CodEstudiante", Obje.CodEstudiante);
                CMD.Parameters.AddWithValue("@Observacion", Obje.Observacion);


                CMD.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = Obje.accion;
                CMD.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
                //if (conexion.State == ConnectionState.Open) conexion.Close();
                //conexion.Open();
                CMD.ExecuteNonQuery();
                accion = CMD.Parameters["@accion"].Value.ToString();
                //conexion.Close();
                return accion;

            }
            catch (Exception )
            {
               
                throw;
                
            }
            
            

        }
        public DataTable D_Listar_Boleta()
        {
            try
            { 
                //Nos permitira obtener el procedimiento (nombre,variable)
                SqlCommand CMD = new SqlCommand("sp_listar_Boleta", conexion.LeerCadena());
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
    }
    
}
