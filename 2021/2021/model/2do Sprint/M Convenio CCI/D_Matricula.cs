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
    public class D_Matricula
    {
        //SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conentarsql"].ConnectionString);

        //MODULO PARA MOSTRAR CURSOS CON LA CANTIDAD DE ALUMNOS CONVENIO  MATRICULADOS 
        public DataTable D_Detalle_MatriculadoCurso()
        {
            try
            {
                //Nos permitira obtener el procedimiento (nombre,variable)
                SqlCommand CMD = new SqlCommand("SP_DetalleMatriculaCurso", conexion.LeerCadena());
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
        //MODULO RECUPERAR Y MOSTRAR EN TABLA DATOS DE ALUMNOS CONVENIO
        public DataTable D_Detalle_Matricula_Estudiante_Pago()
        {
            try
            {
                //Nos permitira obtener el procedimiento (nombre,variable)
                SqlCommand CMD = new SqlCommand("SP_Detalle_Matricula_Estudiante_Pago", conexion.LeerCadena());
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
        // MODULO PARA INSERTAR LOS DATOS DE MATRICULA EN LA BASE DE DATOS 
        public String D_InsertarDatosMatricula(E_Matricula Obje)
        {
            try
            {
                String accion = "";
                //Nos permitira obtener el procedimiento (nombre,variable)
                SqlCommand CMD = new SqlCommand("SP_InsertarDatosMatricula", conexion.LeerCadena());
                //Nos permitira usar parametros o variables desl sql 
                CMD.CommandType = CommandType.StoredProcedure;
                //BUSCAR POR EL codigo,nombre,tipo,tema,horas
                CMD.Parameters.AddWithValue("@CodMatricula", Obje.CodMatricula);
                CMD.Parameters.AddWithValue("@Anio", Obje.Anio);
                CMD.Parameters.AddWithValue("@Mes", Obje.Mes);
                CMD.Parameters.AddWithValue("@TipoMatricula", Obje.Tipo_Matricula);
                CMD.Parameters.AddWithValue("@Cod_CurActivo", Obje.Cod_CurActivo);
                CMD.Parameters.AddWithValue("@CodBoleta", Obje.CodBoleta);
                CMD.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = Obje.accion;
                CMD.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
                
                CMD.ExecuteNonQuery();
                accion = CMD.Parameters["@accion"].Value.ToString();
                
                return accion;
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}
