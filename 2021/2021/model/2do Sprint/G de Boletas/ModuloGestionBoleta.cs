using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace _2021
{
    public class ModuloGestionBoleta
    {
        public static int EditarGestionBoletas(GestionBoleta Obje)
        {
            try
            {

                int r = 0;
                using (SqlConnection c = conexion.LeerCadena())
                {
                    //SqlCommand t = new SqlCommand(string.Format("update GestionBoletas set  Nombre = '{0}', ApellidoP = '{1}', ApellidoM = '{2}', TipoGestionBoletas = '{3}', Direccion = '{4}', Correo = '{5}', Celular = '{6}', Sexo = '{7}' where CodDocente = '{8}'",
                    //   d.Nombre, d.Ap, d.Am, d.Tipo, d.Direccion, d.Email, d.Telefono, d.Sexo, d.Codigo), conexion.LeerCadena());
                    SqlCommand CMD = new SqlCommand("EditarGestionBoletas", conexion.LeerCadena());
                    //Nos permitira usar parametros o variables desl sql 
                    CMD.CommandType = CommandType.StoredProcedure;
                    //BUSCAR POR EL codigo,nombre,tipo,tema,horas
                    CMD.Parameters.AddWithValue("@Estado", Obje.Estado);
                    CMD.Parameters.AddWithValue("@Serie", Obje.Serie);
                    CMD.Parameters.AddWithValue("@Comprobante", Obje.Comprobante);
                    CMD.Parameters.AddWithValue("@IDComprobante", Obje.IDComprobante);
                    CMD.Parameters.AddWithValue("@Descripcion", Obje.Descripcion);
                    CMD.Parameters.AddWithValue("@Doc", Obje.Doc);
                    CMD.Parameters.AddWithValue("@CodAlumno", Obje.CodAlumno);
                    CMD.Parameters.AddWithValue("@ApellidosNombres", Obje.ApellidosNombres);
                    CMD.Parameters.AddWithValue("@Monto", Obje.Monto);
                    r = CMD.ExecuteNonQuery();

                }

                return r;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable ListarGestionBoletas()
        {
            // //Nos permitira obtener el procedimiento (nombre,variable)
            SqlDataAdapter da = new SqlDataAdapter("ListarGestionBoletas", conexion.LeerCadena());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable BuscarIDComprobante(GestionBoleta Obje)
        {
            //Nos permitira obtener el procedimiento (Estado,variable)
            SqlCommand CMD = new SqlCommand("BuscarIDComprobante", conexion.LeerCadena());
            //Nos permitira usar parametros o variables desl sql 
            CMD.CommandType = CommandType.StoredProcedure;
            //BUSCAR POR EL Estado SE CURSO
            CMD.Parameters.AddWithValue("@IDComprobante", Obje.IDComprobante);
            //hace puente entre la base de datos y la tabla del formulario 
            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            return DT;
        }
        public static DataTable BuscarDescripcion(GestionBoleta Obje)
        {
            //Nos permitira obtener el procedimiento (Estado,variable)
            SqlCommand CMD = new SqlCommand("BuscarDescripcion12", conexion.LeerCadena());
            //Nos permitira usar parametros o variables desl sql 
            CMD.CommandType = CommandType.StoredProcedure;
            //BUSCAR POR EL Estado SE CURSO
            CMD.Parameters.AddWithValue("@Descripcion", Obje.Descripcion);
            //hace puente entre la base de datos y la tabla del formulario 
            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            return DT;
        }
        public static DataTable BuscarEstado(GestionBoleta Obje)
        {
            //Nos permitira obtener el procedimiento (Estado,variable)
            SqlCommand CMD = new SqlCommand("BuscarEstado", conexion.LeerCadena());
            //Nos permitira usar parametros o variables desl sql 
            CMD.CommandType = CommandType.StoredProcedure;
            //BUSCAR POR EL Estado SE CURSO
            CMD.Parameters.AddWithValue("@Estado", Obje.Estado);
            //hace puente entre la base de datos y la tabla del formulario 
            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            return DT;
        }
        public static DataTable BuscarSerie(GestionBoleta Obje)
        {
            //Nos permitira obtener el procedimiento (Estado,variable)
            SqlCommand CMD = new SqlCommand("BuscarSerie", conexion.LeerCadena());
            //Nos permitira usar parametros o variables desl sql 
            CMD.CommandType = CommandType.StoredProcedure;
            //BUSCAR POR EL Estado SE CURSO
            CMD.Parameters.AddWithValue("@Serie", Obje.Serie);
            //hace puente entre la base de datos y la tabla del formulario 
            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            return DT;
        }
        public static DataTable BuscarComprobante(GestionBoleta Obje)
        {
            //Nos permitira obtener el procedimiento (Estado,variable)
            SqlCommand CMD = new SqlCommand("BuscarComprobante", conexion.LeerCadena());
            //Nos permitira usar parametros o variables desl sql 
            CMD.CommandType = CommandType.StoredProcedure;
            //BUSCAR POR EL Estado SE CURSO
            CMD.Parameters.AddWithValue("@Comprobante", Obje.Comprobante);
            //hace puente entre la base de datos y la tabla del formulario 
            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            return DT;
        }
        public static DataTable BuscarDoc(GestionBoleta Obje)
        {
            //Nos permitira obtener el procedimiento (Estado,variable)
            SqlCommand CMD = new SqlCommand("BuscarDoc", conexion.LeerCadena());
            //Nos permitira usar parametros o variables desl sql 
            CMD.CommandType = CommandType.StoredProcedure;
            //BUSCAR POR EL Estado SE CURSO
            CMD.Parameters.AddWithValue("@Doc", Obje.Doc);
            //hace puente entre la base de datos y la tabla del formulario 
            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            return DT;
        }
        public static DataTable BuscarCodAlumno(GestionBoleta Obje)
        {
            //Nos permitira obtener el procedimiento (Estado,variable)
            SqlCommand CMD = new SqlCommand("BuscarCodAlumno", conexion.LeerCadena());
            //Nos permitira usar parametros o variables desl sql 
            CMD.CommandType = CommandType.StoredProcedure;
            //BUSCAR POR EL Estado SE CURSO
            CMD.Parameters.AddWithValue("@CodAlumno", Obje.CodAlumno);
            //hace puente entre la base de datos y la tabla del formulario 
            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            return DT;
        }
        public static DataTable BuscarApellidosNombres(GestionBoleta Obje)
        {
            //Nos permitira obtener el procedimiento (Estado,variable)
            SqlCommand CMD = new SqlCommand("BuscarApellidosNombres", conexion.LeerCadena());
            //Nos permitira usar parametros o variables desl sql 
            CMD.CommandType = CommandType.StoredProcedure;
            //BUSCAR POR EL Estado SE CURSO
            CMD.Parameters.AddWithValue("@ApellidosNombres", Obje.ApellidosNombres);
            //hace puente entre la base de datos y la tabla del formulario 
            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            return DT;
        }
        public static DataTable BuscarFechaAño(CFecha1 Obje)
        {
            //Nos permitira obtener el procedimiento (Estado,variable)
            SqlCommand CMD = new SqlCommand("BuscarFechaAño", conexion.LeerCadena());
            //Nos permitira usar parametros o variables desl sql 
            CMD.CommandType = CommandType.StoredProcedure;
            //BUSCAR POR EL Estado SE CURSO
            CMD.Parameters.AddWithValue("@Año", Obje.Año);
            //hace puente entre la base de datos y la tabla del formulario 
            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            return DT;
        }
        public static DataTable BuscarFechaPeriodo(CFecha1 Obje)
        {
            //Nos permitira obtener el procedimiento (Estado,variable)
            SqlCommand CMD = new SqlCommand("BuscarPeriodo", conexion.LeerCadena());
            //Nos permitira usar parametros o variables desl sql 
            CMD.CommandType = CommandType.StoredProcedure;
            //BUSCAR POR EL Estado SE CURSO
            CMD.Parameters.AddWithValue("@Periodo", Obje.Mes);
            //hace puente entre la base de datos y la tabla del formulario 
            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            return DT;
        }
        public DataTable ListarNombres()
        {
            // //Nos permitira obtener el procedimiento (nombre,variable)
            SqlDataAdapter da = new SqlDataAdapter("ListarGestionBoletas", conexion.LeerCadena());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void Seleccionar(ComboBox cb)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

            cb.Items.Clear();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from fnTablaGBoletas()", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb.Items.Add(dr[9].ToString());

            }
            cn.Close();
            cb.Items.Insert(0, "Selecione un item ");
            cb.SelectedIndex = 0;

        }
        public void SeleccionarCodigo(ComboBox cb)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

            cb.Items.Clear();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from fnTablaGBoletas()", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb.Items.Add(dr[8].ToString());
            }
            cn.Close();
            cb.Items.Insert(0, "Selecione un item ");
            cb.SelectedIndex = 0;

        }

        public void TransferirBoleta(int Id, string codigo, string nombres)
        {
            try
            {
                using (SqlConnection c = conexion.LeerCadena())
                {
                    SqlCommand CMD = new SqlCommand("Transferir", conexion.LeerCadena());
                    //Nos permitira usar parametros o variables desl sql 
                    CMD.CommandType = CommandType.StoredProcedure;
                    //Pasamos los parametros necesarios
                    CMD.Parameters.AddWithValue("@Id", Id);
                    CMD.Parameters.AddWithValue("@CodAlumno", codigo);
                    CMD.Parameters.AddWithValue("@ApellidosNombres", nombres);
                    CMD.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
