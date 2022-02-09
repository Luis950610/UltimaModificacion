//Estudiante:     Jhon Waldir Guerra Bellido
//Código:           171910

using System;
using System.Windows.Forms;
using System.IO;

//Instalar Nuget ITextSharp, ITextSharpXLMworker
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

//Instalar Nuget ceTe.DynamicPDF.Printing
using ceTe.DynamicPDF.Printing;

// instalar Nuget: Syncfusion.PdfViewer.Windows


namespace _2021
{
    public partial class VisualizarImpresion : Form
    {

        //Atributos
        private string aNroCertificado = "";
        private string aNroHoras = "";
        private string aFechaEmision = "";
        private string aAlumno = "";
        private string aCurso = "";
        private string aDenominacion= "";
        private string aNota = "";
        private string aTema = "";
        private string aTipo = "";
        private string afila = "";
        public byte[] a;

        public void CargarDatos(string pNroCertificado, string pNroHoras, string pFechaEmision, string pAlumno, string pCurso, 
                                                string pDenominacion, string pNota, string pTema, string pTipo, string pfila)
        {
             aNroCertificado = pNroCertificado;
             aNroHoras = pNroHoras;
             aFechaEmision = pFechaEmision;
             aAlumno = pAlumno;
             aCurso = pCurso;
            aDenominacion = pDenominacion;
            aNota = pNota;
            aTema = pTema;
            aTipo = pTipo;
            afila = pfila;
        }

        public VisualizarImpresion()
        {
            InitializeComponent();
        }
        private void VisualizarImpresion_Load(object sender, EventArgs e)
        {

            using (MemoryStream ms = new MemoryStream())
            {
                //Diseño del pdf
                string plantilla = Properties.Resources.Plantilla.ToString();
                string Plantilla2 = Properties.Resources.Plantilla2.ToString();
                string FechaImpresion = DateTime.Now.ToShortDateString();
                //Remplazar datos en la plantilla 1
                plantilla = plantilla.Replace("@NombreCompleto", aAlumno);
                plantilla = plantilla.Replace("@Denominacion", aDenominacion);
                plantilla = plantilla.Replace("@NroHoras", aNroHoras);
                plantilla = plantilla.Replace("@FechaImpresion", FechaImpresion);

                //Remplazar los datos en la la plantilla 2
                Plantilla2 = Plantilla2.Replace("@NombreCompleto", aAlumno);
                Plantilla2 = Plantilla2.Replace("@FILAS", afila);
                //Plantilla2 = Plantilla2.Replace("@Curso", aCurso);
                //Plantilla2 = Plantilla2.Replace("@Tema", aTema);
                //Plantilla2 = Plantilla2.Replace("@Nota", aNota);
                Plantilla2 = Plantilla2.Replace("@FechaImpresion", FechaImpresion);

                //Crear un Pdf
                Document doc = new Document(PageSize.A4.Rotate(), 120, 120, 0, 0);
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                doc.Open();
                //Añadimos la primera cara del certificado
                using (StringReader sr = new StringReader(plantilla))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, sr);
                }
                //Añadimos una segunda hoja y la segunda cara del certificado
                doc.NewPage();
                using (StringReader sr2 = new StringReader(Plantilla2))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, sr2);
                }
                doc.Close();
                //Convertir pdf a Bytes para imprimir
                // instalar Nuget: Syncfusion.PdfViewer.Windows
                a = ms.ToArray();
                MemoryStream Bpdf = new MemoryStream(a);
                pdfDocumentView1.Load(Bpdf);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void ImprimirMostrar(string ID, string pCodigo)
        {

        }
        private void TBImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                //Impresion de documentos
                InputPdf pdf = new InputPdf(a);
                PrintJob printJob = new PrintJob(Printer.Default, pdf);
                printJob.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
