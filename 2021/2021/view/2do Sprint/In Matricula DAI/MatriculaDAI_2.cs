using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _2021
{
    public partial class MatriculaDAI_2 : Form
    {
        CE_EstudianteMatriculado oEnt = new CE_EstudianteMatriculado();
        CN_EstudianteMatricula oNeg = new CN_EstudianteMatricula();
        CN_Matricula oNegmatricula = new CN_Matricula();
        /*
        CN_Estudiante N_Estudiante=new CN_Estudiante();
        CE_Estudiante E_Estudiante = new CE_Estudiante();
        CN_Boleta N_Boleta=new CN_Boleta();
        CE_Boleta E_Boleta=new CE_Boleta();
        CN_CursoDAI N_CursoAct=new CN_CursoDAI();
        CE_CursoDAI E_CursoAct = new CE_CursoDAI();*/
        public MatriculaDAI_2()
        {
            InitializeComponent();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnBoleta Boleta = new btnBoleta();
            Boleta.Show();
        }

        private void MatriculaDAI_Load(object sender, EventArgs e)
        {
            
        }

        private void dgvAlumnosMatriculados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
