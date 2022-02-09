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
    public class NCurso
    {
        DCurso objd = new DCurso();
        public DataTable N_listar_mCurso()
        {
            return objd.D_listar_mCurso();
        }
    }
}
