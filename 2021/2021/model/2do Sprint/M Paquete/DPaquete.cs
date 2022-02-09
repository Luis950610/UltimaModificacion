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
    public class DPaquete
    {
        conexion conexion = new conexion();                                   // crear un objeto para la conexion con la base de datos

        // ==================================================================================
        public void AgregarPaquete(EPaquete obj, string[] cursos, int k)
        {
            int id;
            // Crear objeto comando y pasar por parametro el storedprocedure a ejecutar
            // y establecer la conexion con la base de datos
            SqlCommand cmd = new SqlCommand("spInsertar_Paquete", conexion.LeerCadena());
            cmd.CommandType = CommandType.StoredProcedure;                           // establecer el tipo de procedimiento almacenado a ejecutar

            try
            {
                //conexion.LeerCadena();                                              // abrir conexion                                                                            
                                                                                     // enviar los datos obtenidos de la capa de negocio a la base de datos
                cmd.Parameters.AddWithValue("@Denominacion", obj.DENOMINACION);
                cmd.Parameters.AddWithValue("@Nro_Requisitos", obj.NRO_REQUISITOS);
                id = (Int32)cmd.ExecuteScalar();                                     // recuperar id del paquete creado
                //conexion.CN().Close();                                               // cerrar conexion                
                AgregarDetallePaquete(cursos, k, id);                                // agregar detalle del paquete
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void AgregarDetallePaquete(string[] Codigo_Curso, int k, int id)
        {
            for (int i = 0; i < k; i++)
            {
                // Crear objeto comando y pasar por parametro el storedprocedure a ejecutar
                // y establecer la conexion con la base de datos
                SqlCommand cmd = new SqlCommand("spInsertar_Detalle_Paquete", conexion.LeerCadena());
                cmd.CommandType = CommandType.StoredProcedure;                          // establecer el tipo de procedimiento almacenado a ejecutar
                try
                {
                    
                    //conexion.CN().Open();                                               // abrir conexion
                    cmd.Parameters.AddWithValue("@Codigo_Paquete", id);                 // enviar los datos obtenidos de la capa de negocio a la base de datos
                    cmd.Parameters.AddWithValue("@Codigo_Curso", Codigo_Curso[i]);      // agregar cada codigo
                    cmd.ExecuteNonQuery();
                    //conexion.CN().Close();                                              // cerrar conexion
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // ==================================================================================
        public void ModificarPaquete(EPaquete obj, string[] cursos, int k)
        {
            //int id;
            try
            {
                // Crear objeto comando y pasar por parametro el storedprocedure a ejecutar
                // y establecer la conexion con la base de datos
                SqlCommand cmd = new SqlCommand("spEditar_Paquete", conexion.LeerCadena());
                cmd.CommandType = CommandType.StoredProcedure;                          // establecer el tipo de procedimiento almacenado a ejecutar

                //conexion.CN().Open();                                                // abrir conexion                                                                            
                cmd.Parameters.AddWithValue("@Codigo_Paquete", obj.CODIGO);          // enviar los datos obtenidos de la capa de negocio a la base de datos
                cmd.Parameters.AddWithValue("@Denominacion", obj.DENOMINACION);
                cmd.Parameters.AddWithValue("@Nro_Requisitos", obj.NRO_REQUISITOS);
                cmd.ExecuteNonQuery();
                //conexion.CN().Close();                                               // cerrar conexion
                EliminarDetallePaquete(obj.CODIGO);
                AgregarDetallePaquete(cursos, k, int.Parse(obj.CODIGO));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ==================================================================================
        public DataTable BuscarPaqueteDenominacion(EPaquete obj)
        {
            DataTable dt = new DataTable();                                             // objeto datatable
            try
            {
                // Crear objeto comando y pasar por parametro el storedprocedure a ejecutar
                // y establecer la conexion con la base de datos
                SqlCommand cmd = new SqlCommand("spBuscar_Paquete", conexion.LeerCadena());
                cmd.CommandType = CommandType.StoredProcedure;                          // establecer el tipo de procedimiento almacenado a ejecutar

                //conexion.CN().Open();                                                   // abrir conexion
                cmd.Parameters.AddWithValue("@Denominacion", obj.DENOMINACION);         // parametro a buscar en la base de datos
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);                                                            // recuperar registro
                //conexion.CN().Close();                                                  // cerrar conexion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;                                                              // retornar registro
        }
        // ==================================================================================
        public void EliminarPaquete(EPaquete obj)
        {
            try
            {
                EliminarDetallePaquete(obj.CODIGO);
                // Crear objeto comando y pasar por parametro el storedprocedure a ejecutar
                // y establecer la conexion con la base de datos
                SqlCommand cmd = new SqlCommand("spEliminar_Paquete", conexion.LeerCadena());
                cmd.CommandType = CommandType.StoredProcedure;                          // establecer el tipo de procedimiento almacenado a ejecutar

                //conexion.CN().Open();                                                   // abrir conexion
                cmd.Parameters.AddWithValue("@Codigo_Paquete", obj.CODIGO);          // pasar por parametro dato a modificar sobre el campo codigo
                cmd.ExecuteNonQuery();                                                  // ejecutar query
                cmd.Parameters.Clear();                                                 // limpiar los parametros
                //conexion.CN().Close();                                                 // cerrar conexion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void EliminarDetallePaquete(string Codigo_Paquete)
        {
            try
            {
                // Crear objeto comando y pasar por parametro el storedprocedure a ejecutar
                // y establecer la conexion con la base de datos
                SqlCommand cmd = new SqlCommand("spEliminar_Detalle_Paquete", conexion.LeerCadena());
                cmd.CommandType = CommandType.StoredProcedure;                          // establecer el tipo de procedimiento almacenado a ejecutar

               // conexion.CN().Open();                                                   // abrir conexion
                cmd.Parameters.AddWithValue("@Codigo_Paquete", Codigo_Paquete);          // pasar por parametro dato a modificar sobre el campo codigo
                cmd.ExecuteNonQuery();                                                  // ejecutar query
                cmd.Parameters.Clear();                                                 // limpiar los parametros
                //conexion.CN().Close();                                                  // cerrar conexion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // ==================================================================================
        public DataTable MostrarPaquetes()
        {
            // objetos que nos permitiran recuperar registros de la base de datos
            DataTable tabla = new DataTable();
            try
            {
                SqlDataReader Leer;
                // Crear objeto comando y pasar por parametro el storedprocedure a ejecutar
                // y establecer la conexion con la base de datos
                SqlCommand cmd = new SqlCommand("spListar_Paquetes", conexion.LeerCadena());
                cmd.CommandType = CommandType.StoredProcedure;

                //conexion.CN().Open();                                                   // abrir conexion
                Leer = cmd.ExecuteReader();                                             // extraer los registros de la tabla estudiante
                tabla.Load(Leer);                                                       // cargar los registros en el objeto tabla
                //conexion.CN().Close();                                                  // cerrar conexion
            }
            catch (Exception)
            {
                throw;
            }
            return tabla;                                                           // retornar la tabla con los registros obtenidos
        }

        public DataTable MostrarDetallePaquete(string Codigo_Paquete)
        {
            // objetos que nos permitiran recuperar registros de la base de datos
            DataTable dt = new DataTable();
            try
            {
                // Crear objeto comando y pasar por parametro el storedprocedure a ejecutar
                // y establecer la conexion con la base de datos
                SqlCommand cmd = new SqlCommand("spListar_Detalle_Paquete_especifico", conexion.LeerCadena());
                cmd.CommandType = CommandType.StoredProcedure;                          // establecer el tipo de procedimiento almacenado a ejecutar

                //conexion.CN().Open();                                                   // abrir conexion
                cmd.Parameters.AddWithValue("@Codigo_Paquete", Codigo_Paquete);         // parametro a buscar en la base de datos
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);                                                            // recuperar registro
                //conexion.CN().Close();                                                  // cerrar conexion
                return dt;                                                              // retornar registro detalle paquete
            }
            catch (Exception)
            {
                throw;
            }
        }






    }
}
