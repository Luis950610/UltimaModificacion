using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace _2021
{
    public class CN_CursoDAI
    {
        CD_CursoDAI objd = new CD_CursoDAI();

        public DataTable N_Buscar_CursoDAIC(CE_CursoDAI obje)
        {
            return objd.D_Buscar_CursoC(obje);
        }
        public DataTable N_Buscar_CursoDAIN(CE_CursoDAI obje)
        {
            return objd.D_Buscar_CursoN(obje);
        }
        public DataTable N_listar_CursoDAI()
        {
            return objd.D_listar_Curso();
        }

    }
}
