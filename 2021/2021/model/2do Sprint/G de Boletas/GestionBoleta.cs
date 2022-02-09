using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021
{
    public class GestionBoleta
    {

        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string Serie { get; set; }
        public string Comprobante { get; set; }
        public string IDComprobante { get; set; }
        public string Descripcion { get; set; }
        public string Doc { get; set; }
        public string CodAlumno{ get; set; }
        public string ApellidosNombres { get; set; }
        public float Monto { get; set; }
        public GestionBoleta()
        {

        }
        
        public GestionBoleta(DateTime pFecha,string pEstado, string pNroSerie, string pNroComprobante, string pIDComprobante, string pDescripcion, string pTipoDoc, string pEmail, string pApellidosNombres, float pMonto)
        {
            this.Fecha = pFecha;
            this.Estado = pEstado;
            this.Serie = pNroSerie;
            this.Comprobante = pNroComprobante;
            this.IDComprobante = pIDComprobante;
            this.Descripcion = pDescripcion;
            this.Doc = pTipoDoc;
            this.CodAlumno = pEmail;
            this.ApellidosNombres = pApellidosNombres;
            this.Monto = pMonto;
        }
        
    }
}
