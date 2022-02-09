
namespace _2021
{
    partial class VntMantenimientoLaboratorio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VntMantenimientoLaboratorio));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bntEliminar = new System.Windows.Forms.Button();
            this.bntModificar = new System.Windows.Forms.Button();
            this.bntGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Nuevo = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbModalidad = new System.Windows.Forms.ComboBox();
            this.textSala = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textCodLab = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textUbic = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textCapac = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBuscxNomb = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.textBuscxCod = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sPListarLaboratoriosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbBDmantenimientolaboDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            //this.db_BDmantenimientolaboDataSet = new CapaPresentacion.db_BDmantenimientolaboDataSet();
            //this.sP_Listar_LaboratoriosTableAdapter = new CapaPresentacion.db_BDmantenimientolaboDataSetTableAdapters.SP_Listar_LaboratoriosTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPListarLaboratoriosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBDmantenimientolaboDataSetBindingSource)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.db_BDmantenimientolaboDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.MidnightBlue;
            this.groupBox1.Controls.Add(this.bntEliminar);
            this.groupBox1.Controls.Add(this.bntModificar);
            this.groupBox1.Controls.Add(this.bntGuardar);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(11, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(220, 593);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // bntEliminar
            // 
            this.bntEliminar.BackColor = System.Drawing.Color.Transparent;
            this.bntEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bntEliminar.BackgroundImage")));
            this.bntEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntEliminar.FlatAppearance.BorderSize = 0;
            this.bntEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bntEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntEliminar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntEliminar.Location = new System.Drawing.Point(48, 362);
            this.bntEliminar.Name = "bntEliminar";
            this.bntEliminar.Size = new System.Drawing.Size(114, 31);
            this.bntEliminar.TabIndex = 18;
            this.bntEliminar.Text = "ELIMINAR";
            this.bntEliminar.UseVisualStyleBackColor = false;
            this.bntEliminar.Click += new System.EventHandler(this.BntEliminar_Click);
            // 
            // bntModificar
            // 
            this.bntModificar.BackColor = System.Drawing.Color.Transparent;
            this.bntModificar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bntModificar.BackgroundImage")));
            this.bntModificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntModificar.FlatAppearance.BorderSize = 0;
            this.bntModificar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bntModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntModificar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntModificar.Location = new System.Drawing.Point(48, 414);
            this.bntModificar.Name = "bntModificar";
            this.bntModificar.Size = new System.Drawing.Size(114, 31);
            this.bntModificar.TabIndex = 17;
            this.bntModificar.Text = "MODIFICAR";
            this.bntModificar.UseVisualStyleBackColor = false;
            this.bntModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // bntGuardar
            // 
            this.bntGuardar.BackColor = System.Drawing.Color.Transparent;
            this.bntGuardar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bntGuardar.BackgroundImage")));
            this.bntGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntGuardar.FlatAppearance.BorderSize = 0;
            this.bntGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bntGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntGuardar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntGuardar.Location = new System.Drawing.Point(48, 307);
            this.bntGuardar.Name = "bntGuardar";
            this.bntGuardar.Size = new System.Drawing.Size(114, 31);
            this.bntGuardar.TabIndex = 15;
            this.bntGuardar.Text = "GUARDAR";
            this.bntGuardar.UseVisualStyleBackColor = false;
            this.bntGuardar.Click += new System.EventHandler(this.BntGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.Transparent;
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(48, 254);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(114, 31);
            this.btnNuevo.TabIndex = 14;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(16, 185);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "CENTRO DE CAPACITACIÓN \r\n          INFORMATICA";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(39, 17);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(236, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(459, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "MANTENIMIENTO LABORATORIO         ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbModalidad);
            this.groupBox2.Controls.Add(this.textSala);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textCodLab);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textUbic);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textCapac);
            this.groupBox2.Controls.Add(this.textNombre);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(241, 52);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(805, 136);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Laboratorio";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // cmbModalidad
            // 
            this.cmbModalidad.FormattingEnabled = true;
            this.cmbModalidad.Location = new System.Drawing.Point(457, 58);
            this.cmbModalidad.Margin = new System.Windows.Forms.Padding(2);
            this.cmbModalidad.Name = "cmbModalidad";
            this.cmbModalidad.Size = new System.Drawing.Size(241, 25);
            this.cmbModalidad.TabIndex = 35;
            this.cmbModalidad.Text = "VIRTUAL";
            this.cmbModalidad.SelectedIndexChanged += new System.EventHandler(this.CmbModalidad_SelectedIndexChanged);
            this.cmbModalidad.Leave += new System.EventHandler(this.CmbModalidad_Leave);
            // 
            // textSala
            // 
            this.textSala.Location = new System.Drawing.Point(457, 92);
            this.textSala.Margin = new System.Windows.Forms.Padding(2);
            this.textSala.Name = "textSala";
            this.textSala.Size = new System.Drawing.Size(335, 25);
            this.textSala.TabIndex = 27;
            this.textSala.Click += new System.EventHandler(this.TextSala_Click);
            this.textSala.TextChanged += new System.EventHandler(this.textSala_TextChanged);
            this.textSala.Leave += new System.EventHandler(this.TextSala_Leave);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(367, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 23);
            this.label9.TabIndex = 25;
            this.label9.Text = "Sala:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(367, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 24;
            this.label8.Text = "Modalidad:";
            // 
            // textCodLab
            // 
            this.textCodLab.Location = new System.Drawing.Point(117, 24);
            this.textCodLab.Margin = new System.Windows.Forms.Padding(2);
            this.textCodLab.Name = "textCodLab";
            this.textCodLab.Size = new System.Drawing.Size(162, 25);
            this.textCodLab.TabIndex = 20;
            this.textCodLab.CursorChanged += new System.EventHandler(this.TextCodLab_CursorChanged);
            this.textCodLab.TextChanged += new System.EventHandler(this.TextCodLab_TextChanged);
            this.textCodLab.Enter += new System.EventHandler(this.TextCodLab_Enter);
            this.textCodLab.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextCodLab_KeyPress);
            this.textCodLab.Leave += new System.EventHandler(this.TextCodLab_Leave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(658, 83);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(0, 0);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click_2);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 23);
            this.label3.TabIndex = 23;
            this.label3.Text = "Codigo:";
            this.label3.Click += new System.EventHandler(this.Label3_Click_1);
            // 
            // textUbic
            // 
            this.textUbic.Location = new System.Drawing.Point(457, 24);
            this.textUbic.Margin = new System.Windows.Forms.Padding(2);
            this.textUbic.Name = "textUbic";
            this.textUbic.Size = new System.Drawing.Size(241, 25);
            this.textUbic.TabIndex = 13;
            this.textUbic.TextChanged += new System.EventHandler(this.TextUbic_TextChanged);
            this.textUbic.Leave += new System.EventHandler(this.TextUbic_Leave);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(367, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 19;
            this.label6.Text = "Ubicacion:";
            // 
            // textCapac
            // 
            this.textCapac.Location = new System.Drawing.Point(117, 92);
            this.textCapac.Margin = new System.Windows.Forms.Padding(2);
            this.textCapac.Name = "textCapac";
            this.textCapac.Size = new System.Drawing.Size(162, 25);
            this.textCapac.TabIndex = 9;
            this.textCapac.TextChanged += new System.EventHandler(this.TextCapac_TextChanged);
            this.textCapac.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCapac_KeyPress);
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(117, 58);
            this.textNombre.Margin = new System.Windows.Forms.Padding(2);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(241, 25);
            this.textNombre.TabIndex = 7;
            this.textNombre.TextChanged += new System.EventHandler(this.textNombre_TextChanged);
            this.textNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textNombre_KeyPress);
            this.textNombre.Leave += new System.EventHandler(this.TextNombre_Leave);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 21;
            this.label5.Text = "Capacidad:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 22;
            this.label4.Text = "Nombre:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.textBuscxNomb);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.btnBuscar);
            this.groupBox3.Controls.Add(this.textBuscxCod);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(241, 205);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(805, 87);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Busquedas";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(235, 52);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 27);
            this.button1.TabIndex = 37;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnBuscarxNomb_Click);
            // 
            // textBuscxNomb
            // 
            this.textBuscxNomb.Location = new System.Drawing.Point(15, 53);
            this.textBuscxNomb.Margin = new System.Windows.Forms.Padding(2);
            this.textBuscxNomb.Name = "textBuscxNomb";
            this.textBuscxNomb.Size = new System.Drawing.Size(216, 25);
            this.textBuscxNomb.TabIndex = 36;
            this.textBuscxNomb.TextChanged += new System.EventHandler(this.TextBox3_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 31);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(157, 17);
            this.label10.TabIndex = 35;
            this.label10.Text = "Buscar por Nombre:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscar.Location = new System.Drawing.Point(590, 52);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(28, 27);
            this.btnBuscar.TabIndex = 34;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscarxCod_Click);
            // 
            // textBuscxCod
            // 
            this.textBuscxCod.Location = new System.Drawing.Point(370, 54);
            this.textBuscxCod.Margin = new System.Windows.Forms.Padding(2);
            this.textBuscxCod.Name = "textBuscxCod";
            this.textBuscxCod.Size = new System.Drawing.Size(216, 25);
            this.textBuscxCod.TabIndex = 33;
            this.textBuscxCod.TextChanged += new System.EventHandler(this.TextBuscxCod_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(367, 31);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "Buscar por Codigo:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(241, 297);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(595, 303);
            this.dataGridView1.TabIndex = 34;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // sPListarLaboratoriosBindingSource
            // 
            //this.sPListarLaboratoriosBindingSource.DataMember = "SP_Listar_Laboratorios";
            //this.sPListarLaboratoriosBindingSource.DataSource = this.dbBDmantenimientolaboDataSetBindingSource;
            // 
            // dbBDmantenimientolaboDataSetBindingSource
            // 
            //this.dbBDmantenimientolaboDataSetBindingSource.DataSource = this.db_BDmantenimientolaboDataSet;
            //this.dbBDmantenimientolaboDataSetBindingSource.Position = 0;
            // 
            // db_BDmantenimientolaboDataSet
            // 
            //this.db_BDmantenimientolaboDataSet.DataSetName = "db_BDmantenimientolaboDataSet";
            //this.db_BDmantenimientolaboDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sP_Listar_LaboratoriosTableAdapter
            // 
            //this.sP_Listar_LaboratoriosTableAdapter.ClearBeforeFill = true;
            // 
            // VntMantenimientoLaboratorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1064, 609);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "VntMantenimientoLaboratorio";
            this.Text = "Mantenimiento Laboratorio";
            this.Load += new System.EventHandler(this.VntMantenimientoLaboratorio_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPListarLaboratoriosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBDmantenimientolaboDataSetBindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.db_BDmantenimientolaboDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker Nuevo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textCapac;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBuscxCod;
        private System.Windows.Forms.Button bntModificar;
        private System.Windows.Forms.Button bntGuardar;
        //private System.Diagnostics.PerformanceCounter performanceCounter1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textUbic;
        private System.Windows.Forms.Button bntEliminar;
        private System.Windows.Forms.TextBox textCodLab;
        private System.Windows.Forms.BindingSource dbBDmantenimientolaboDataSetBindingSource;
        //private db_BDmantenimientolaboDataSet db_BDmantenimientolaboDataSet;
        private System.Windows.Forms.BindingSource sPListarLaboratoriosBindingSource;
        //private db_BDmantenimientolaboDataSetTableAdapters.SP_Listar_LaboratoriosTableAdapter sP_Listar_LaboratoriosTableAdapter;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox textSala;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBuscxNomb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbModalidad;
    }
}