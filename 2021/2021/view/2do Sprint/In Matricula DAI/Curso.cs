using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace _2021
{
    public partial class RelacionCurso : Form
    {
        CE_CursoDAI oEnt = new CE_CursoDAI();
        CN_CursoDAI oNeg = new CN_CursoDAI();
        
       
        public RelacionCurso()
        {
            InitializeComponent();
        }

        private void Curso_Load(object sender, EventArgs e)
        {

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
  

            if (txtBuscarNombre.Text != "")
            {
                oEnt.Nombre = txtBuscarNombre.Text;
                DataTable DT = new DataTable();
                DT = oNeg.N_Buscar_CursoDAIN(oEnt);
                dataGridView1.DataSource = DT;
            }
            else
            {
                dataGridView1.DataSource = oNeg.N_listar_CursoDAI();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)

        {
            if (txtBuscarNombre.Text != "")
            {
                oEnt.Nombre = txtBuscarNombre.Text;
                DataTable DT = new DataTable();
                DT = oNeg.N_Buscar_CursoDAIC(oEnt);
                dataGridView1.DataSource = DT;
            }
            else
            {
                dataGridView1.DataSource = oNeg.N_listar_CursoDAI();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
