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

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;

namespace _2021
{
    public partial class FormRegistroDeNotas1 : Form
    {
        /*Atributos*/
        private string aCodCurso;
        private string aGrupo;
        private string aNombreCurso;
        private string aDocente;
        //private string aCodMatricula;
        private string aFiltroCurso;
        private string aFiltroAlumno;
        // atributo para saber el numero de notas que hay
        private int aCantidadDeNotas;
        //Atributos para almacenar el codigo del estudiante y la matricula
        private string aCodEstudiante;
        private string aCodMatricula;
        //Ativuto para crear y eliminar los registros de cada matricula
        private string aCodMatriculaOperaciones=null;
        
        private CN_MatriculaConNotas objetoCN_MatriculaConNotas = new CN_MatriculaConNotas();
        private CN_MatriculaPostergada objetoCN_MatriculaPostergada = new CN_MatriculaPostergada();
        public FormRegistroDeNotas1()
        {
            InitializeComponent();
            //Inicializar las variables por defecto
            aFiltroCurso = "Codigo Curso";
            aFiltroAlumno = "Codigo Alumno";
            refreshDataGridView();
        }

        public void refreshDataGridView()
        {
            //Se puede poner los procedimientos almacenados con buscadores
            //dataGridViewAsignaturas.DataSource = objetoCN_MatriculaConNotas.MostrarCargaAcademicaConDocentesYBuscarxCodigoCurso(comboBoxAnio.Text, comboBoxPeriodo.Text, comboBoxTipo.Text,txtboxBuscarCursos.Text);
            // Cargar al data gridview las asignaciones de carga academica
            dataGridViewAsignaturas.DataSource = objetoCN_MatriculaConNotas.MostrarCargaAcademicaConDocentes(comboBoxAnio.Text, comboBoxPeriodo.Text, comboBoxTipo.Text);

            //Se borra el contenido del label que mostraba el codigo del curso seleccionado
            labelCodigoSeleccionado.Text = "";
            //Cargar al data gridview los registros de notas sin registro alguno
            dataGridViewNotas.DataSource = null;
            //dataGridViewNotas.DataSource = objetoCN_RegistroNotas.MostrarRegistroNotas();


        }
        private void txtboxBuscarCursos_Enter(object sender, EventArgs e)
        {
            if (txtboxBuscarCursos.Text == "Buscar...")
            {
                txtboxBuscarCursos.Text = "";
                txtboxBuscarCursos.ForeColor = Color.FromArgb(29, 29, 29);
            }

        }

        private void txtboxBuscarCursos_Leave(object sender, EventArgs e)
        {
            if (txtboxBuscarCursos.Text == "")
            {
                txtboxBuscarCursos.Text = "Buscar...";
                txtboxBuscarCursos.ForeColor = Color.FromArgb(29, 29, 29);
            }
        }

        private void textBoxBuscarAlumnos_Enter(object sender, EventArgs e)
        {
            if (textBoxBuscarAlumnos.Text == "Buscar...")
            {
                textBoxBuscarAlumnos.Text = "";
                textBoxBuscarAlumnos.ForeColor = Color.FromArgb(29, 29, 29);
            }
        }

        private void textBoxBuscarAlumnos_Leave(object sender, EventArgs e)
        {
            if (textBoxBuscarAlumnos.Text == "")
            {
                textBoxBuscarAlumnos.Text = "Buscar...";
                textBoxBuscarAlumnos.ForeColor = Color.FromArgb(29, 29, 29);
            }
        }

        private void txtboxBuscarCursos_TextChanged(object sender, EventArgs e)
        {
            //Buscar por los campos siguientes seleccionados:
            if (aFiltroCurso == "Codigo Curso")
            {
                //Buscar Carga Academica por CodCurso
                dataGridViewAsignaturas.DataSource = objetoCN_MatriculaConNotas.MostrarCargaAcademicaConDocentesYBuscarxCodigoCurso(comboBoxAnio.Text, comboBoxPeriodo.Text, comboBoxTipo.Text,txtboxBuscarCursos.Text);
            }
            else
            {
                if (aFiltroCurso == "Nombre")
                {
                    //Buscar carga academica por nombre
                    dataGridViewAsignaturas.DataSource = objetoCN_MatriculaConNotas.MostrarCargaAcademicaConDocentesYBuscarxNombreAsignatura(comboBoxAnio.Text, comboBoxPeriodo.Text, comboBoxTipo.Text, txtboxBuscarCursos.Text);
                }
                else
                {
                    if (aFiltroCurso == "Docente")
                    {
                        //Buscar carga academica por Docente
                        dataGridViewAsignaturas.DataSource = objetoCN_MatriculaConNotas.MostrarCargaAcademicaConDocentesYBuscarxDocente(comboBoxAnio.Text, comboBoxPeriodo.Text, comboBoxTipo.Text, txtboxBuscarCursos.Text);
                    }

                }
            }
        }

        private void textBoxBuscarAlumnos_TextChanged(object sender, EventArgs e)
        {
            //Mas antes realizar la comparacion porque puede que no se haya inicializado el codigo del curso
            if(aCodCurso!=null)
            {
                //Buscar por los campos siguientes seleccionados:
                if (aFiltroAlumno == "Codigo Alumno")
                {
                    //Buscar alumnos por Codigo
                    dataGridViewNotas.DataSource = objetoCN_MatriculaConNotas.SelectRegistroNotasYBuscarxCodigoAlumno(aCodCurso,aGrupo, comboBoxAnio.Text, comboBoxPeriodo.Text, textBoxBuscarAlumnos.Text);
                }
                else
                {
                    if (aFiltroAlumno == "Apellidos y Nombres")
                    {
                        //Buscar alumnos por nombre
                        dataGridViewNotas.DataSource = objetoCN_MatriculaConNotas.SelectRegistroNotasYBuscarxApellidosNombres(aCodCurso, aGrupo, comboBoxAnio.Text, comboBoxPeriodo.Text, textBoxBuscarAlumnos.Text);

                    }

                }
            }
            
        }

        private void dataGridViewAsignaturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
                // Se inicializan la variable codcurso para mostrarse en el data gridview de los alumnos
                aCodCurso = dataGridViewAsignaturas.Rows[e.RowIndex].Cells["CodCursoActivo"].FormattedValue.ToString();
                aGrupo = dataGridViewAsignaturas.Rows[e.RowIndex].Cells["Grupo"].FormattedValue.ToString();
                aNombreCurso= dataGridViewAsignaturas.Rows[e.RowIndex].Cells["Nombre"].FormattedValue.ToString();
                aDocente= dataGridViewAsignaturas.Rows[e.RowIndex].Cells["Docente"].FormattedValue.ToString();

                //Borrar los valores que estaban anteriormente guardadas en las variables de codEstudiante y CodMatricula
                aCodEstudiante = null;
                aCodMatricula = null;
                //Inicializar el label del codigo de curso seleccionado
                labelCodigoSeleccionado.Text = aCodCurso+"-"+aGrupo;
                //Inicializar el datagridview de la relacion de alumnos(registro de notas)
                dataGridViewNotas.DataSource = objetoCN_MatriculaConNotas.SelectRegistroNotas(aCodCurso, aGrupo, comboBoxAnio.Text, comboBoxPeriodo.Text);

                //Ocultar la columna que muestr el codigo de matricula
                dataGridViewNotas.Columns["CodMatricula"].Visible = false;
                //Ocultar la columna que contenia el lapiz
                dataGridViewNotas.Columns[0].Visible = false;
                //Cambiamos los nombres de las columnas de Cod_Estudiante y Alumnos
                dataGridViewNotas.Columns["Codigo_Estudiante"].HeaderText = "Codigo Alumno";
                dataGridViewNotas.Columns["Alumnos"].HeaderText = "Apellidos y Nombres";

                //Cambiar todas las columnas a su forma antigua.

                //Obtener los cursos que estan dentro el paquete para cambiar el nombre de la tabla en general 
                DataTable TablaPaquete = objetoCN_MatriculaConNotas.ObtenerCursosPaquete(aCodCurso);
                aCantidadDeNotas = 5;//TablaPaquete.Rows.Count;

                //Si no hay respuesta(numero de filas igual a cero, entonces solo considerar una nota y cambair el nombre de la columna)
                if (TablaPaquete.Rows.Count==0)
                {
                    //Restablecer los nombres de las columnas y las visibilidad
                    for (int i = 4; i < dataGridViewNotas.Columns.Count; i++)
                    {
                        dataGridViewNotas.Columns[i].Visible = true;
                        dataGridViewNotas.Columns[i].HeaderText = "nota" + Convert.ToString(i - 3);
                    }
                    dataGridViewNotas.Columns["nota1"].HeaderText = aNombreCurso;
                    //Y ocultar las otras columnas
                    for(int i=5; i<dataGridViewNotas.Columns.Count;i++)
                    {
                        dataGridViewNotas.Columns[i].Visible = false;
                    }
                }
                else
                {
                    //Restablecer los nombres de las columnas y las visibilidad
                    for (int i = 4; i < dataGridViewNotas.Columns.Count; i++)
                    {
                        dataGridViewNotas.Columns[i].Visible = true;
                        dataGridViewNotas.Columns[i].HeaderText ="nota"+Convert.ToString(i-3);
                    }
                    //cambiar el titulo de las columnas con los nombres de las que estan en el paquete
                    int columnNotas = 4;
                    foreach(DataRow Fila in TablaPaquete.Rows)
                    {
                        string nombreSubCurso = Fila["Nombre_Curso"].ToString();
                        dataGridViewNotas.Columns[columnNotas].HeaderText = nombreSubCurso;
                        columnNotas++;
                    }
                    aCantidadDeNotas = columnNotas; // se asigna la cantidad de filas que recorrio
                    //Ocultar las otras columnas del datagirdview
                    for (; columnNotas < dataGridViewNotas.Columns.Count; columnNotas++)
                    {
                        dataGridViewNotas.Columns[columnNotas].Visible = false;
                    }
                }
                //Cambiar al modo solo lectura
                dataGridViewNotas.ReadOnly = true;

            }
        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshDataGridView();
        }

        private void comboBoxAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshDataGridView();
        }

        private void comboBoxPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshDataGridView();;
        }

        private void dataGridViewNotas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Se inicializan la variables que serviran para postergar la matricula
                aCodMatricula = dataGridViewNotas.Rows[e.RowIndex].Cells["CodMatricula"].FormattedValue.ToString();
                aCodEstudiante = dataGridViewNotas.Rows[e.RowIndex].Cells["Codigo_Estudiante"].FormattedValue.ToString();
            }


        }

        //Eventos al pulsar los botones
        private void btnCrearRegistro_Click(object sender, EventArgs e)
        {
            if(aCodCurso==null)
            {
                MessageBox.Show("Para Crear un registro de notas, primero debe de seleccionar una asignatura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Mostrar un mensaje donde el ususario pueda confirmar si se desea crear el registro de notas
                DialogResult dialogoPostergar = MessageBox.Show("Se Creara un registro de notas para la asignatura seleccionada; si en caso ya existan notas dentro del registro, se modificaran con el valor de cero ¿Desea Continuar?", "Crear Registro de notas ("+aCodCurso+", "+aNombreCurso+","+aGrupo+" )", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                //Crear registro de notas(inicializar todas las notas con el valor de cero)
                if (dialogoPostergar == DialogResult.Yes)
                {
                    foreach (DataGridViewRow Fila in dataGridViewNotas.Rows)
                    {
                        aCodMatriculaOperaciones = Fila.Cells["CodMatricula"].Value.ToString();
                        //Limpiar en la base de datos
                        objetoCN_MatriculaConNotas.CrearRegistroDeNotas(aCodMatriculaOperaciones, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    }
                    //Y refrescar otra vez la tabla
                    dataGridViewNotas.DataSource = objetoCN_MatriculaConNotas.SelectRegistroNotas(aCodCurso, aGrupo, comboBoxAnio.Text, comboBoxPeriodo.Text);
                }
            }

            
        }

        private void btnEliminarRegistro_Click(object sender, EventArgs e)
        {
            if(aCodCurso==null)
            {
                MessageBox.Show("Para Eliminar un registro de notas, primero debe de seleccionar una asignatura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogoPostergar = MessageBox.Show("Se eliminara las notas de los alumnos matriculados en la asignatura seleccionada ¿Desea Continuar?", "Elimnar Registro de notas (" + aCodCurso + ", " + aNombreCurso + "," + aGrupo + " )", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                //Crear registro de notas(inicializar todas las notas con el valor de cero)
                if (dialogoPostergar == DialogResult.Yes)
                {
                    foreach (DataGridViewRow Fila in dataGridViewNotas.Rows)
                    {
                        aCodMatriculaOperaciones = Fila.Cells["CodMatricula"].Value.ToString();
                        //Limpiar en la base de datos
                        objetoCN_MatriculaConNotas.LimpiarRegistroDeNotas(aCodMatriculaOperaciones);
                    }
                    //Y refrescar otra vez la tabla
                    dataGridViewNotas.DataSource = objetoCN_MatriculaConNotas.SelectRegistroNotas(aCodCurso, aGrupo, comboBoxAnio.Text, comboBoxPeriodo.Text);
                }
            }
            
        }

        private void btnPostergarMatricula_Click(object sender, EventArgs e)
        {
            //Si todavia no se han seleccionado la postergacion de matricula 
            if(aCodMatricula!=null)
            {
                DialogResult dialogoPostergar = MessageBox.Show("Postergara la matricula del estudiante con codigo: "+aCodEstudiante+" para el curso con codigo: "+aCodCurso+" del grupo "+aGrupo+"\n¿Desea Continuar?", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //Postergar la matricula
                if(dialogoPostergar==DialogResult.Yes)
                {
                    objetoCN_MatriculaPostergada.InsertarMatriculaPostergada(aCodMatricula, aCodEstudiante);
                    //DEBERIA DE INICIALIZAR LAS NOTAS O NOTA DEL ESTUDIANTE CON EL VALOR DE CERO.
                    MessageBox.Show("La matricula del estudiante con codigo: " + aCodEstudiante + " ha sido postergada.","Confirmacion");
                }
            }
            else
            {
                //Mostrar mensaje indicando que debe de seleccionar a un alumno
                MessageBox.Show("Primero debe de seleccionar a un alumno, para postergar la matricula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnDescargarRegistro_Click(object sender, EventArgs e)
        {
            if (aCodCurso == null)
            {
                MessageBox.Show("Primero debe de seleccionar una asignatura, para descargar el registro de notas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Abrir un filestream y preguntar por la ruta para descargar
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.FileName = "RegNotas"+ aNombreCurso +aGrupo+"_"+ comboBoxPeriodo.Text+ comboBoxAnio.Text+ comboBoxTipo.Text;//DateTime.Now.ToString("ddmmyyyyhhmmss");// + ".pdf";//"RegNotas+CodAsignatura+NombreAsignatura+Periodo+Año.pdf";
                guardar.Filter = "PDF Files (*.pdf)|*.pdf| All Files (*.*)|*.*";

                /*Para guardar como archivo pdf
                 Se importa un paquete nuget dentro de la capa de Presentacion
                -ItextSharp   V.5.5.13
                -ItexSharp xml worker V.5.5.13
                Despues de haber instalado estas librerias
            
                 Creamos una carpeta recurso(abriendo la opcion propiedades), que contendra una plantilla HTML para descargar el registro de notas*/

                string paginahtml = Properties.Resources.PlantillaHTML.ToString();
                //Copiar el Codigo de Asignatura
                paginahtml = paginahtml.Replace("@Codigo", aCodCurso);
                //Copiar el Nombre de la asignatura
                paginahtml = paginahtml.Replace("@Asignatura", aNombreCurso);
                //Copiar el Docente a quien se le asigno el curso
                paginahtml = paginahtml.Replace("@Docente", aDocente);
                //Copiar el tipo de asignatura
                paginahtml = paginahtml.Replace("@Tipo", comboBoxTipo.Text);
                //Copiar el Año 
                paginahtml = paginahtml.Replace("@Periodo", comboBoxPeriodo.Text);
                //Copiar el periodo
                paginahtml = paginahtml.Replace("@Año", comboBoxAnio.Text);



                //Copiar las columnas
                string Columnas = string.Empty;
                Columnas += "<tr>";
                for(int i=2;i<aCantidadDeNotas;i++) // dataGridViewNotas.Columns.Count
                {
                    Columnas+= "<th>" + dataGridViewNotas.Columns[i].HeaderText + "</th>";// es distinto a poner column.name
                }
                Columnas += "</tr>";
                paginahtml = paginahtml.Replace("@COLUMNAS", Columnas);


                //Copiar las filas
                string filas = string.Empty;
                foreach (DataGridViewRow row in dataGridViewNotas.Rows)
                {
                    filas += "<tr>";
                    //copiar solo la cantidad de notas que se muestran en el datagridview
                    for(int i=2;i<aCantidadDeNotas;i++)
                    {
                        filas += "<td>" + row.Cells[i].Value.ToString() + "</td>";
                    }
                    filas += "</tr>";

                }
                paginahtml = paginahtml.Replace("@FILAS", filas);

                //Guardar el pdf
                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    //Guardar en memoria
                    using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(new Phrase(""));
                        //Agregar la imagen al archivo pdf
                        iTextSharp.text.Image Img = iTextSharp.text.Image.GetInstance(Properties.Resources.UnsaacLogo, System.Drawing.Imaging.ImageFormat.Png);
                        //tamaño de la imagen
                        Img.ScaleToFit(100, 80);
                        //Para que sobre ponga sobre el texto
                        Img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        //la posicion X,Y ; se toma como origen el final de la hoja izquierda
                        Img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 70);
                        pdfDoc.Add(Img);

                        //Agregar la imagen 2 al archivo pdf
                        iTextSharp.text.Image Img2 = iTextSharp.text.Image.GetInstance(Properties.Resources.LogoCon_fondo_CCI, System.Drawing.Imaging.ImageFormat.Png);
                        //tamaño de la imagen
                        Img2.ScaleToFit(90, 75);
                        //Para que sobre ponga sobre el texto
                        Img2.Alignment = iTextSharp.text.Image.UNDERLYING;
                        //la posicion X,Y ; se toma como origen el final de la hoja izquierda
                        Img2.SetAbsolutePosition(pdfDoc.LeftMargin + 490, pdfDoc.Top - 65);
                        pdfDoc.Add(Img2);




                        //Agregamos el contenido al archivo pdf
                        using (StringReader SR = new StringReader(paginahtml))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, SR);
                        }
                        pdfDoc.Close();
                        stream.Close();

                    }
                    MessageBox.Show("El Registro De Notas se descargo exitosamente ", "Descarga Finalizada",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }


        }

        private void comboBoxFiltroCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            aFiltroCurso = comboBoxFiltroCurso.Text;
        }

        private void comboBoxFiltroAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            aFiltroAlumno = comboBoxFiltroAlumno.Text;
        }

        //Boton de Guardar
        private void button2_Click(object sender, EventArgs e)
        {
            if (aCodCurso == null)
            {
                MessageBox.Show("Para Guardar un registro de notas, primero debe de seleccionar una asignatura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Deshabilitar la edicion del datagridview
                dataGridViewNotas.ReadOnly = true;
                //Guardar los datos modificados a la base de datos
                string PrimeraNota = string.Empty;
                string segundaNota = string.Empty;
                string TerceraNota = string.Empty;
                string CuartaNota = string.Empty;
                string QuintaNota = string.Empty;
                string SextaaNota = string.Empty;
                string SetimaNota = string.Empty;
                string OctavaNota = string.Empty;
                string NovenaNota = string.Empty;
                string DecimaNota = string.Empty;
                //Crear una variable para almacenar el codigo matricula de cada fila
                string aCodMatriculaFila;
                foreach (DataGridViewRow fila in dataGridViewNotas.Rows)
                {
                    //Recorrer cada columna que contiene a las notas de la tabla
                    aCodMatriculaFila = fila.Cells[1].Value.ToString();
                    PrimeraNota = fila.Cells[4].Value.ToString();
                    segundaNota = fila.Cells[5].Value.ToString();
                    TerceraNota = fila.Cells[6].Value.ToString();
                    CuartaNota = fila.Cells[7].Value.ToString();
                    QuintaNota = fila.Cells[8].Value.ToString();
                    SextaaNota = fila.Cells[9].Value.ToString();
                    SetimaNota = fila.Cells[10].Value.ToString();
                    OctavaNota = fila.Cells[11].Value.ToString();
                    NovenaNota = fila.Cells[12].Value.ToString();
                    DecimaNota = fila.Cells[13].Value.ToString();

                    //Se reemplaza las notas del data griddview
                    float nota1;
                    float nota2;
                    float nota3;
                    float nota4;
                    float nota5;
                    float nota6;
                    float nota7;
                    float nota8;
                    float nota9;
                    float nota10;
                    if (PrimeraNota == "")
                    {
                        nota1 = 0;
                    }
                    else
                    {
                        nota1 = float.Parse(PrimeraNota);
                    }
                    if (segundaNota == "")
                    {
                        nota2 = 0;
                    }
                    else
                    {
                        nota2 = float.Parse(segundaNota);
                    }
                    if (TerceraNota == "")
                    {
                        nota3 = 0;
                    }
                    else
                    {
                        nota3 = float.Parse(TerceraNota);
                    }
                    if (CuartaNota == "")
                    {
                        nota4 = 0;
                    }
                    else
                    {
                        nota4 = float.Parse(CuartaNota);
                    }
                    if (QuintaNota == "")
                    {
                        nota5 = 0;
                    }
                    else
                    {
                        nota5 = float.Parse(QuintaNota);
                    }
                    if (SextaaNota == "")
                    {
                        nota6 = 0;
                    }
                    else
                    {
                        nota6 = float.Parse(SextaaNota);
                    }
                    if (SetimaNota == "")
                    {
                        nota7 = 0;
                    }
                    else
                    {
                        nota7 = float.Parse(SetimaNota);
                    }
                    if (OctavaNota == "")
                    {
                        nota8 = 0;
                    }
                    else
                    {
                        nota8 = float.Parse(OctavaNota);
                    }

                    if (NovenaNota == "")
                    {
                        nota9 = 0;
                    }
                    else
                    {
                        nota9 = float.Parse(NovenaNota);
                    }
                    if (DecimaNota == "")
                    {
                        nota10 = 0;
                    }
                    else
                    {
                        nota10 = float.Parse(DecimaNota);
                    }

                    objetoCN_MatriculaConNotas.CrearRegistroDeNotas(aCodMatriculaFila, nota1, nota2, nota3, nota4, nota5, nota6, nota7, nota8, nota9, nota10);
                }

                //Mostrar un mensaje informando que se actualizo el registro de notas
                MessageBox.Show("El Registro de notas se Actualizo exitosamente !", "Registro de Notas Actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Refrescar el dataGridView
                dataGridViewNotas.DataSource = objetoCN_MatriculaConNotas.SelectRegistroNotas(aCodCurso, aGrupo, comboBoxAnio.Text, comboBoxPeriodo.Text);

            }

        }
        //Boton de Editar
        private void button1_Click(object sender, EventArgs e)
        {
            if (aCodCurso == null)
            {
                MessageBox.Show("Para habilitar la edicion de un registro de notas, primero debe de seleccionar una asignatura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Habilitar la edicion de todas las filas a excepcion de los codigos de los alumnos
                dataGridViewNotas.ReadOnly = false;
                //Deshabilitar la edicion de las columnas de los alumnos
                dataGridViewNotas.Columns[2].ReadOnly = true;

                //Mostrar un mensaje al usuario indicando que ahora puede editar las notas
                //MessageBox.Show("Ahora puede editar las notas de la asignatura");
            }
            
        }

        private void FormRegistroDeNotas1_Load(object sender, EventArgs e)
        {

        }
    }
}
