/*  ********************************************************************************* 
	|				CAPA DE DATOS: MANTENIMIENTO DE LABORATORIOS				|
	*********************************************************************************  */

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
    public class CD_MantLabo
    {
        /* Conectar a la base de datos */
        

        /* Metodo para Listar Laboratoros: Llama al almacenamiento almacenado */
        public DataTable D_Listar_Laboratorios()
        {
            try
            {
                // Nos permitira obtener el procedimiento (nombre,variable)
                SqlCommand CMD = new SqlCommand("SP_Listar_Laboratorios", conexion.LeerCadena());
                // Hace puente entre la base de datos y la tabla del formulario 
                SqlDataAdapter DA = new SqlDataAdapter(CMD);//es como un filtro para q los datps se pueddan agregar auna tabla
                DataTable DT = new DataTable();
                // PARA LLENAR TABLA
                DA.Fill(DT);
                return DT;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Metodo para Mantenimiento Laboratoros: Llama al almacenamiento almacenado */
        public String D_Mantenimiento_Laboratorio(CE_MantLabo Obje)
        {
            try

            {
                String accion = "";
                //Nos permitira obtener el procedimiento (nombre,variable)
                SqlCommand CMD = new SqlCommand("SP_Mantenimiento_Laboratorio", conexion.LeerCadena());
                //Nos permitira usar parametros o variables desl sql 
                CMD.CommandType = CommandType.StoredProcedure;
                //BUSCAR POR EL codigo,nombre,tipo,tema,horas
                CMD.Parameters.AddWithValue("@CodLaboratorio", Obje.CodLaboratorio);
                CMD.Parameters.AddWithValue("@Nombre", Obje.Nombre);
                CMD.Parameters.AddWithValue("@Capacidad", Obje.Capacidad);
                CMD.Parameters.AddWithValue("@Ubicacion", Obje.Ubicacion);
                CMD.Parameters.AddWithValue("@Modalidad", Obje.Modalidad);
                CMD.Parameters.AddWithValue("@Sala", Obje.Sala);

                CMD.Parameters.Add("@Accion", SqlDbType.VarChar, 50).Value = Obje.Accion;
                CMD.Parameters["@Accion"].Direction = ParameterDirection.InputOutput;
                
                CMD.ExecuteNonQuery();
                accion = CMD.Parameters["@Accion"].Value.ToString();
                
                return accion;

            }
            catch (Exception)
            {

                throw;

            }
        }

        /* Metodo para Buscar Laboratorio por su codigo: Llama al almacenamiento almacenado */
        public DataTable D_Buscar_LaboratarioxCod(CE_MantLabo Obje)
        {
            try
            {
                //Nos permitira obtener el procedimiento (nombre,variable)
                SqlCommand CMD = new SqlCommand("SP_Buscar_LaboratorioxCod", conexion.LeerCadena());
                //Nos permitira usar parametros o variables desl sql 
                CMD.CommandType = CommandType.StoredProcedure;
                //BUSCAR POR EL NOMBRE SE CURSO
                CMD.Parameters.AddWithValue("@Codigo", Obje.CodLaboratorio);
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

        /* Metodo para Buscar Laboratorio por su nombre: Llama al almacenamiento almacenado */
        public DataTable D_Buscar_LaboratarioxNomb(CE_MantLabo Obje)
        {
            try
            {
                //Nos permitira obtener el procedimiento (nombre,variable)
                SqlCommand CMD = new SqlCommand("SP_Buscar_LaboratorioxNomb", conexion.LeerCadena());
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
