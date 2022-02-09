/*  ********************************************************************************* 
	|				CAPA DE ENTIDADES: MANTENIMIENTO DE LABORATORIOS				|
	*********************************************************************************  */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021
{
    /* Clase para modificar los atributos de la tabla laboratorio */
    public class CE_MantLabo
    {
        public String CodLaboratorio { get; set; }
        public String Nombre { get; set; }
        public int Capacidad { get; set; }
        public String Ubicacion { get; set; }
        public String Modalidad { get; set; }
        public String Sala { get; set; }

        // La entidad accion se usa para la opcion guardar, eliminar, modificar.
        public String Accion { get; set; }
    }
}
