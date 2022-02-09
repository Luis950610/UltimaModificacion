using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace _2021
{
    public class NPaquete
    {
       
        // ===============================================================
        public void Agregar_Paquete(EPaquete ObjPaquete,string[]cursos,int k)
        {
            DPaquete obj = new DPaquete();
            obj.AgregarPaquete(ObjPaquete, cursos,k);
        }
        public void Agregar_Detalle_Paquete(string Codigo_Curso)
        {
            DPaquete obj = new DPaquete();
        }
        // ===============================================================
        public void Modificar_Paquete(EPaquete ObjPaquete, string[] cursos, int k)
        {
            DPaquete obj = new DPaquete();
            obj.ModificarPaquete(ObjPaquete,cursos, k);
        }
        // ===============================================================
        public DataTable Buscar_Paquete(EPaquete ObjPaquete)
        {
            DPaquete obj = new DPaquete();
            return obj.BuscarPaqueteDenominacion(ObjPaquete);
        }
        // ===============================================================
        public void Eliminar_Paquete(EPaquete ObjPaquete)
        {
            DPaquete obj = new DPaquete();
            obj.EliminarPaquete(ObjPaquete);
        }       
        // ===============================================================
        public DataTable Mostrar_Paquetes()
        {
            DPaquete obj = new DPaquete();
            DataTable tabla = new DataTable();
            tabla = obj.MostrarPaquetes();
            return tabla;
        }
        // ===============================================================
        public DataTable Mostrar_Detalle_Paquete(string Codigo_Paquete)
        {
            DPaquete obj = new DPaquete();
            DataTable tabla = new DataTable();
            tabla = obj.MostrarDetallePaquete(Codigo_Paquete);
            return tabla;
        }
    }
}
