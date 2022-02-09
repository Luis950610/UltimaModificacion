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
    public class NEstudiante2sprint
    {
        // ===============================================================
        public DataTable Mostrar_Estudiante()
        {
            DEstudiante2sprint obj = new DEstudiante2sprint();
            DataTable tabla = new DataTable();
            tabla = obj.MostrarEstudiantes();
            return tabla;
        }
        // ===============================================================
        public void Agregar_Estudiante(EEstudiante2sprint ObjEstudiante)
        {
            DEstudiante2sprint obj = new DEstudiante2sprint();
            obj.AgregarEstudiantes(ObjEstudiante);
        }
        // ===============================================================
        public void Modificar_Estudiante(EEstudiante2sprint ObjEstudiante)
        {
            DEstudiante2sprint obj = new DEstudiante2sprint();
            obj.ModificarEstudiante(ObjEstudiante);
        }
        // ===============================================================
        public DataTable Buscar_Estudiante(EEstudiante2sprint ObjEstudiante)
        {
            DEstudiante2sprint obj = new DEstudiante2sprint();
            return obj.BuscarEstudianteCodigo(ObjEstudiante);            
        }
        // ===============================================================
        public void EliminarRegistro(EEstudiante2sprint ObjEstudiante)
        {
            DEstudiante2sprint obj = new DEstudiante2sprint();
            obj.EliminarEstudiante(ObjEstudiante);
        }



    }
}
