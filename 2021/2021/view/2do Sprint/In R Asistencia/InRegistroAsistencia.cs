
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace _2021
{
    public partial class InRegistroAsistencia : Form
    {
        private string path = @"F:\UNSAAC\DESARROLLO DE SOFTWARE\A PROYECTO FINAL\2021\2021\RegistroA.xlsx";
        public InRegistroAsistencia()
        {
            InitializeComponent();
        }
        CMisModulos t = new CMisModulos();
        private void Form1_Load(object sender, EventArgs e)
        {
            //InUsuario ini = new InUsuario();
            //ini.NombreMostrar.Text = Listar.CurrentRow.Cells["Nombre"].Value.ToString();
            //ini.imagen.Image = Image.FromStream(m); // mostrar la foto en el picturebox
            //ini.ShowDialog();
            //Listar1.DataSource = t.ListarCurso();
            

        }

        private void BImportar_Click(object sender, EventArgs e)
        {
            SLDocument sl = new SLDocument(path);
            int indice = 2;
            List<CExcel> lst = new List<CExcel>();
            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(indice, 1)))
            {
                CExcel oExcel = new CExcel();
                oExcel.IdCursoHabilitado = sl.GetCellValueAsString(indice, 1);
                oExcel.IdDetalleMatricula = sl.GetCellValueAsString(indice, 2);
                oExcel.CodAlumno = sl.GetCellValueAsString(indice, 3);
                oExcel.ApellidosNombres = sl.GetCellValueAsString(indice, 4);
                oExcel.dia1 = sl.GetCellValueAsString(indice, 5);
                oExcel.dia2 = sl.GetCellValueAsString(indice, 6);
                oExcel.dia3 = sl.GetCellValueAsString(indice, 7);
                oExcel.dia4 = sl.GetCellValueAsString(indice, 8);
                oExcel.dia5 = sl.GetCellValueAsString(indice, 9);
                oExcel.dia6 = sl.GetCellValueAsString(indice, 10);
                oExcel.dia7 = sl.GetCellValueAsString(indice, 11);
                oExcel.dia8 = sl.GetCellValueAsString(indice, 12);
                oExcel.dia9 = sl.GetCellValueAsString(indice, 13);
                oExcel.dia10 = sl.GetCellValueAsString(indice, 14);
                oExcel.dia11 = sl.GetCellValueAsString(indice, 15);
                oExcel.dia12 = sl.GetCellValueAsString(indice, 16);
                oExcel.dia13 = sl.GetCellValueAsString(indice, 17);
                oExcel.dia14 = sl.GetCellValueAsString(indice, 18);
                oExcel.dia15 = sl.GetCellValueAsString(indice, 19); 

                lst.Add(oExcel);
                indice++;
                
            }
            DataTable dt = new DataTable();
            
            Listar2.DataSource = lst;
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Listar1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBuscar.Text = Listar1.CurrentRow.Cells[1].Value.ToString();
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {

            //Creamos una memoria para guardar informacion
            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CTCurso d = new CTCurso();
            d.Nombre_Curso = textBuscar.Text;

            if (textBuscar.Text != "")
            {
                try
                {

                    DataTable n = CMisModulos.BuscarDocente(d);
                    //CodigoNuevo.Text = validar.ToString();
                    Listar1.DataSource = n;
                    

                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR DE BUSQUEDA POR NOMBRE", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            else
            {
                MessageBox.Show("NOMBRE EN BLANCO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listar1.DataSource = t.ListarCurso();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lista Guardada Exitosamente");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BGenerarReporte_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{0}.pdf", DateTime.Now.ToString("ddMMyyyyHHmmss"));



            //string PaginaHTML_Texto = "<table border=\"1\"><tr><td>HOLA MUNDO</td></tr></table>";
            string PaginaHTML_Texto = Properties.Resources.Plantilla.ToString();
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CURSO", textBuscar.Text);
            //aginaHTML_Texto = PaginaHTML_Texto.Replace("@DOCENTE", txtDocente.Text);
            //aginaHTML_Texto = PaginaHTML_Texto.Replace("@HORARIO", txtHorario.Text);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@PERIODO", txtPeriodo.Text + int.Parse(txtAnio.Text));
           //aginaHTML_Texto = PaginaHTML_Texto.Replace("@AULA", txtCodigo.Text);

            string filas = string.Empty;

            foreach (DataGridViewRow row in Listar2.Rows)
            {
                filas += "<tr>";
                //filas += "<td>" + row.Cells["Nro"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Codigo"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Apellidos y Nombres"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["dia1"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["dia2"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["dia3"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["dia4"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["dia5"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["dia6"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["dia7"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["dia8"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["dia9"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["dia10"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["dia11"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["dia12"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["dia13"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["dia14"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["dia15"].Value.ToString() + "</td>";

                filas += "</tr>";

            }
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);



            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    //Creamos un nuevo documento y lo definimos como PDF
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));

                    //Agregamos la imagen del banner al documento
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.unsaac, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(60, 60);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;

                    //img.SetAbsolutePosition(10,100);
                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                    pdfDoc.Add(img);


                    //pdfDoc.Add(new Phrase("Hola Mundo"));
                    using (StringReader sr = new StringReader(PaginaHTML_Texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                }

            }
        }
    }
}
