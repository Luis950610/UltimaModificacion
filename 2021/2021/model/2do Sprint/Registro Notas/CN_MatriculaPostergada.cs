using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace _2021
{
    public class CN_MatriculaPostergada
    {
        /*Se Crea una instancia de la Clase CD_CargaAcademica*/
        CD_MatriculaPostergada objetoCD_MatriculaPostergada = new CD_MatriculaPostergada();

        //Metodo para Mostrar los registros de la carga Academica
        public void InsertarMatriculaPostergada(string CodMatricula, string CodEstudiante)
        {
            objetoCD_MatriculaPostergada.InsertarMatriculaPostergada(CodMatricula, CodEstudiante);
        }
    }
}
