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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void docente_Click(object sender, EventArgs e)
        {
            InDocente a = new InDocente();
            a.ShowDialog();
        }

        private void Estudiante_Click(object sender, EventArgs e)
        {
            FormMantenimientoEstudiante t = new FormMantenimientoEstudiante();
            t.ShowDialog();
        }

        private void curso_Click(object sender, EventArgs e)
        {
            InterfazMantenimientoCurso t = new InterfazMantenimientoCurso();
            //InMC t = new InMC();
            t.Show();

        }

        private void activacion_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Interfaz_Activar nuevo = new Interfaz_Activar();
            nuevo.Show();
        }

        private void matricula_Click(object sender, EventArgs e)
        {
            VntMatriculaEstudiantes vntnAsignacion = new VntMatriculaEstudiantes();
            vntnAsignacion.Show();
        }

        private void Asignacion_Click(object sender, EventArgs e)
        {
            FormPadre Formulario = new FormPadre();
            Formulario.Show();
        }

        private void ButtonTM_Click(object sender, EventArgs e)
        {
            
        }

        private void BMLB_Click(object sender, EventArgs e)
        {
            VntMantenimientoLaboratorio l = new VntMantenimientoLaboratorio();
            l.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            InTipoMatricula ultimo = new InTipoMatricula();
            ultimo.ShowDialog();
        }

        private void BBIC_Click(object sender, EventArgs e)
        {
            ImpresionCertificados t = new ImpresionCertificados();
            t.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FormMantenimientoPaquete t = new FormMantenimientoPaquete();
            t.ShowDialog();
        }

        private void BRN_Click(object sender, EventArgs e)
        {
            FormRegistroDeNotas1 t = new FormRegistroDeNotas1();
            t.ShowDialog();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            InRegistroAsistencia t = new InRegistroAsistencia();
            t.ShowDialog();
        }

        private void BCG_Click(object sender, EventArgs e)
        {
            CambioGrupo t = new CambioGrupo();
            t.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1Pao f = new Form1Pao();
            f.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MatriculasDAI N = new MatriculasDAI();
            N.ShowDialog();
        }
    }
}
