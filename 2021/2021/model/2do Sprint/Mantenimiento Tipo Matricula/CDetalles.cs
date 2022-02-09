using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021
{
    public class CDetalles
    {
        public string CodDetalles { get; set; }
        public string Año { get; set; }
        public string Periodo { get; set; }
        public string Documento { get; set; }
        public string Observaciones { get; set; }
        public string CodMMatricula { get; set; }
        public CDetalles()
        {

        }
        public CDetalles(string pCodDetalles,string pAño, string pPeriodo, string pDocumento, string pObservaciones, string pCodMMatricula)
        {
            this.CodDetalles = pCodDetalles;
            this.Año = pAño;
            this.Periodo = pPeriodo;
            this.Documento = pDocumento;
            this.Observaciones = pObservaciones;
            this.CodMMatricula = pCodMMatricula;
        }

        public CDetalles(string pCodDetalles)
        {
            this.CodDetalles = pCodDetalles;
        }

    }
}
