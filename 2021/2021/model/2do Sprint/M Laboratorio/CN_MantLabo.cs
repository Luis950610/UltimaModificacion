/*  ********************************************************************************* 
	|				CAPA DE NEGOCIOS: MANTENIMIENTO DE LABORATORIOS				|
	*********************************************************************************  */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace _2021
{
    /* Clase para la capa de negocios */
    public class CN_MantLabo
    {
        CD_MantLabo objetoCD_MntLab = new CD_MantLabo();

        /* Metodo para Listar Laboratoros: Llama a la capa de datos */
        public DataTable N_Listar_Laboratorios()
        {
            return objetoCD_MntLab.D_Listar_Laboratorios();
        }

        /* Metodo para Mantenimiento Laboratoros: Llama a la capa de datos */
        public String N_Mantenimiento_Laboratorio(CE_MantLabo objeto)
        {
            return objetoCD_MntLab.D_Mantenimiento_Laboratorio(objeto);
        }

        /* Metodo para Buscar Laboratorio por su codigo: Llama a la capa de datos */
        public DataTable N_Buscar_LaboratorioxCod(CE_MantLabo objeto)
        {
            return objetoCD_MntLab.D_Buscar_LaboratarioxCod(objeto);
        }

        /* Metodo para Buscar Laboratorio por su nombre: Llama a la capa de datos */
        public DataTable N_Buscar_LaboratorioxNomb(CE_MantLabo objeto)
        {
            return objetoCD_MntLab.D_Buscar_LaboratarioxNomb(objeto);
        }

    }   
}
