using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021
{
    public class CTCurso
    {
        public int Codigo_Curso { get; set; }
        public string Nombre_Curso { get; set; }
        public string Grupo { get; set; }
        public int Costo { get; set; }
        public string DescripHorario { get; set; }
        public string CodLabo { get; set; }
        public string Docente { get; set; }
        public CTCurso()
        {

        }
        public CTCurso(int pCodigo_Curso, string pNombre_Curso, string pGrupo, int pCosto, string pDescripHorario, string pCodLabo, string pDocente)
        {
            this.Codigo_Curso = pCodigo_Curso;
            this.Nombre_Curso = pNombre_Curso;
            this.Grupo = pGrupo;
            this.Costo = pCosto;
            this.DescripHorario = pDescripHorario;
            this.CodLabo = pCodLabo;
            this.Docente = pDocente;
        }
        public CTCurso(string pCodigo)
        {
            this.Nombre_Curso = pCodigo;
        }
    }
}
