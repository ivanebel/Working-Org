namespace Working_Org
{
    partial class UcPedidos_Envio
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcPedidos_Envio));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label7 = new System.Windows.Forms.Label();
            this.btnFinalizarEnvio = new System.Windows.Forms.Button();
            this.groupDatosEnvio = new System.Windows.Forms.GroupBox();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnGenerarRemito = new System.Windows.Forms.Button();
            this.BtnGenerarIdPallet = new System.Windows.Forms.Button();
            this.cmbCantidadPallets = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemito = new System.Windows.Forms.TextBox();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFechaEnvio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnComenzarEnvio = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSeleccionarOC = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblBarra1 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnNuevoEnvio = new System.Windows.Forms.Button();
            this.dgvContenido = new System.Windows.Forms.DataGridView();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.cId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBultos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEnvio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cKilosEnvio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupDatosEnvio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCantidadPallets)).BeginInit();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContenido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(21, 254);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 18);
            this.label7.TabIndex = 24;
            this.label7.Text = "Contenido del Pedido:";
            // 
            // btnFinalizarEnvio
            // 
            this.btnFinalizarEnvio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(70)))));
            this.btnFinalizarEnvio.Enabled = false;
            this.btnFinalizarEnvio.FlatAppearance.BorderSize = 0;
            this.btnFinalizarEnvio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(95)))), ((int)(((byte)(80)))));
            this.btnFinalizarEnvio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(65)))), ((int)(((byte)(50)))));
            this.btnFinalizarEnvio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizarEnvio.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarEnvio.ForeColor = System.Drawing.Color.White;
            this.btnFinalizarEnvio.Location = new System.Drawing.Point(705, 659);
            this.btnFinalizarEnvio.Name = "btnFinalizarEnvio";
            this.btnFinalizarEnvio.Size = new System.Drawing.Size(175, 51);
            this.btnFinalizarEnvio.TabIndex = 20;
            this.btnFinalizarEnvio.Text = "Finalizar Envío";
            this.btnFinalizarEnvio.UseVisualStyleBackColor = false;
            this.btnFinalizarEnvio.Visible = false;
            this.btnFinalizarEnvio.Click += new System.EventHandler(this.btnFinalizarEnvio_Click);
            // 
            // groupDatosEnvio
            // 
            this.groupDatosEnvio.Controls.Add(this.txtDestino);
            this.groupDatosEnvio.Controls.Add(this.label6);
            this.groupDatosEnvio.Controls.Add(this.pictureBox2);
            this.groupDatosEnvio.Controls.Add(this.pictureBox1);
            this.groupDatosEnvio.Controls.Add(this.BtnGenerarRemito);
            this.groupDatosEnvio.Controls.Add(this.BtnGenerarIdPallet);
            this.groupDatosEnvio.Controls.Add(this.cmbCantidadPallets);
            this.groupDatosEnvio.Controls.Add(this.label5);
            this.groupDatosEnvio.Controls.Add(this.txtRemito);
            this.groupDatosEnvio.Controls.Add(this.dtpFechaVencimiento);
            this.groupDatosEnvio.Controls.Add(this.label4);
            this.groupDatosEnvio.Controls.Add(this.dtpFechaEnvio);
            this.groupDatosEnvio.Controls.Add(this.label2);
            this.groupDatosEnvio.Controls.Add(this.label3);
            this.groupDatosEnvio.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDatosEnvio.ForeColor = System.Drawing.Color.Black;
            this.groupDatosEnvio.Location = new System.Drawing.Point(24, 441);
            this.groupDatosEnvio.Name = "groupDatosEnvio";
            this.groupDatosEnvio.Size = new System.Drawing.Size(540, 269);
            this.groupDatosEnvio.TabIndex = 19;
            this.groupDatosEnvio.TabStop = false;
            this.groupDatosEnvio.Text = "Datos del envío";
            // 
            // txtDestino
            // 
            this.txtDestino.BackColor = System.Drawing.Color.White;
            this.txtDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDestino.ForeColor = System.Drawing.Color.Black;
            this.txtDestino.Location = new System.Drawing.Point(130, 60);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(386, 26);
            this.txtDestino.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(16, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "Destino:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(210, 232);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(210, 203);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // BtnGenerarRemito
            // 
            this.BtnGenerarRemito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.BtnGenerarRemito.FlatAppearance.BorderSize = 0;
            this.BtnGenerarRemito.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.BtnGenerarRemito.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.BtnGenerarRemito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerarRemito.Location = new System.Drawing.Point(19, 232);
            this.BtnGenerarRemito.Name = "BtnGenerarRemito";
            this.BtnGenerarRemito.Size = new System.Drawing.Size(175, 25);
            this.BtnGenerarRemito.TabIndex = 10;
            this.BtnGenerarRemito.Text = "Generar Remito";
            this.BtnGenerarRemito.UseVisualStyleBackColor = false;
            this.BtnGenerarRemito.Click += new System.EventHandler(this.BtnGenerarRemito_Click);
            // 
            // BtnGenerarIdPallet
            // 
            this.BtnGenerarIdPallet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.BtnGenerarIdPallet.FlatAppearance.BorderSize = 0;
            this.BtnGenerarIdPallet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.BtnGenerarIdPallet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.BtnGenerarIdPallet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerarIdPallet.Location = new System.Drawing.Point(19, 203);
            this.BtnGenerarIdPallet.Name = "BtnGenerarIdPallet";
            this.BtnGenerarIdPallet.Size = new System.Drawing.Size(175, 25);
            this.BtnGenerarIdPallet.TabIndex = 9;
            this.BtnGenerarIdPallet.Text = "Generar Identificador Pallet";
            this.BtnGenerarIdPallet.UseVisualStyleBackColor = false;
            this.BtnGenerarIdPallet.Click += new System.EventHandler(this.BtnGenerarIdPallet_Click);
            // 
            // cmbCantidadPallets
            // 
            this.cmbCantidadPallets.BackColor = System.Drawing.Color.White;
            this.cmbCantidadPallets.ForeColor = System.Drawing.Color.Black;
            this.cmbCantidadPallets.Location = new System.Drawing.Point(130, 128);
            this.cmbCantidadPallets.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cmbCantidadPallets.Name = "cmbCantidadPallets";
            this.cmbCantidadPallets.Size = new System.Drawing.Size(52, 26);
            this.cmbCantidadPallets.TabIndex = 8;
            this.cmbCantidadPallets.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cmbCantidadPallets.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(16, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "Pallets:";
            // 
            // txtRemito
            // 
            this.txtRemito.BackColor = System.Drawing.Color.White;
            this.txtRemito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemito.ForeColor = System.Drawing.Color.Black;
            this.txtRemito.Location = new System.Drawing.Point(130, 94);
            this.txtRemito.Name = "txtRemito";
            this.txtRemito.Size = new System.Drawing.Size(137, 26);
            this.txtRemito.TabIndex = 5;
            this.txtRemito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(130, 162);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(138, 26);
            this.dtpFechaVencimiento.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(16, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Vencimiento:";
            // 
            // dtpFechaEnvio
            // 
            this.dtpFechaEnvio.Location = new System.Drawing.Point(130, 25);
            this.dtpFechaEnvio.Name = "dtpFechaEnvio";
            this.dtpFechaEnvio.Size = new System.Drawing.Size(251, 26);
            this.dtpFechaEnvio.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(16, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha de Envío:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Remito N°:";
            // 
            // btnComenzarEnvio
            // 
            this.btnComenzarEnvio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnComenzarEnvio.FlatAppearance.BorderSize = 0;
            this.btnComenzarEnvio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.btnComenzarEnvio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.btnComenzarEnvio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComenzarEnvio.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComenzarEnvio.ForeColor = System.Drawing.Color.White;
            this.btnComenzarEnvio.Location = new System.Drawing.Point(704, 415);
            this.btnComenzarEnvio.Name = "btnComenzarEnvio";
            this.btnComenzarEnvio.Size = new System.Drawing.Size(175, 25);
            this.btnComenzarEnvio.TabIndex = 18;
            this.btnComenzarEnvio.Text = "Confirmar Cantidades";
            this.btnComenzarEnvio.UseVisualStyleBackColor = false;
            this.btnComenzarEnvio.Click += new System.EventHandler(this.btnContinuarPedido_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(21, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "Pedidos pendientes de envío:";
            // 
            // btnSeleccionarOC
            // 
            this.btnSeleccionarOC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnSeleccionarOC.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarOC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.btnSeleccionarOC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnSeleccionarOC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarOC.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarOC.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionarOC.Location = new System.Drawing.Point(705, 226);
            this.btnSeleccionarOC.Name = "btnSeleccionarOC";
            this.btnSeleccionarOC.Size = new System.Drawing.Size(175, 25);
            this.btnSeleccionarOC.TabIndex = 25;
            this.btnSeleccionarOC.Text = "Seleccionar Pedido";
            this.btnSeleccionarOC.UseVisualStyleBackColor = false;
            this.btnSeleccionarOC.Click += new System.EventHandler(this.btnSeleccionarOC_Click);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            this.topPanel.Controls.Add(this.lblBarra1);
            this.topPanel.Controls.Add(this.btnVolver);
            this.topPanel.Controls.Add(this.btnConfirmar);
            this.topPanel.Controls.Add(this.btnNuevoEnvio);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(900, 55);
            this.topPanel.TabIndex = 29;
            // 
            // lblBarra1
            // 
            this.lblBarra1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.lblBarra1.Location = new System.Drawing.Point(60, 50);
            this.lblBarra1.Name = "lblBarra1";
            this.lblBarra1.Size = new System.Drawing.Size(175, 5);
            this.lblBarra1.TabIndex = 27;
            this.lblBarra1.Visible = false;
            // 
            // btnVolver
            // 
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(13)))));
            this.btnVolver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnVolver.Image")));
            this.btnVolver.Location = new System.Drawing.Point(0, 0);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(55, 55);
            this.btnVolver.TabIndex = 26;
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(13)))));
            this.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmar.Image")));
            this.btnConfirmar.Location = new System.Drawing.Point(845, 0);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(55, 55);
            this.btnConfirmar.TabIndex = 25;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnNuevoEnvio
            // 
            this.btnNuevoEnvio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            this.btnNuevoEnvio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNuevoEnvio.FlatAppearance.BorderSize = 0;
            this.btnNuevoEnvio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(13)))));
            this.btnNuevoEnvio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnNuevoEnvio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoEnvio.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoEnvio.ForeColor = System.Drawing.Color.Black;
            this.btnNuevoEnvio.Location = new System.Drawing.Point(60, 0);
            this.btnNuevoEnvio.Name = "btnNuevoEnvio";
            this.btnNuevoEnvio.Size = new System.Drawing.Size(175, 56);
            this.btnNuevoEnvio.TabIndex = 0;
            this.btnNuevoEnvio.Text = "NUEVO ENVIO";
            this.btnNuevoEnvio.UseVisualStyleBackColor = false;
            this.btnNuevoEnvio.Click += new System.EventHandler(this.btnNuevoEnvio_Click);
            // 
            // dgvContenido
            // 
            this.dgvContenido.AllowUserToAddRows = false;
            this.dgvContenido.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(238)))));
            this.dgvContenido.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvContenido.BackgroundColor = System.Drawing.Color.White;
            this.dgvContenido.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvContenido.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContenido.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvContenido.ColumnHeadersHeight = 35;
            this.dgvContenido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvContenido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cId,
            this.cProducto,
            this.cBultos,
            this.cPendiente,
            this.cEnvio,
            this.cKilosEnvio});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(14)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvContenido.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvContenido.EnableHeadersVisualStyles = false;
            this.dgvContenido.Location = new System.Drawing.Point(22, 275);
            this.dgvContenido.MultiSelect = false;
            this.dgvContenido.Name = "dgvContenido";
            this.dgvContenido.RowHeadersVisible = false;
            this.dgvContenido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContenido.Size = new System.Drawing.Size(857, 140);
            this.dgvContenido.TabIndex = 43;
            this.dgvContenido.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContenido_CellEndEdit);
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(238)))));
            this.dgvPedidos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPedidos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPedidos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPedidos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPedidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPedidos.ColumnHeadersHeight = 40;
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(14)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPedidos.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPedidos.EnableHeadersVisualStyles = false;
            this.dgvPedidos.Location = new System.Drawing.Point(22, 80);
            this.dgvPedidos.MultiSelect = false;
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.RowHeadersVisible = false;
            this.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidos.Size = new System.Drawing.Size(857, 146);
            this.dgvPedidos.TabIndex = 44;
            this.dgvPedidos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidos_RowEnter);
            // 
            // cId
            // 
            this.cId.HeaderText = "Id";
            this.cId.Name = "cId";
            this.cId.Visible = false;
            // 
            // cProducto
            // 
            this.cProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cProducto.HeaderText = "Producto";
            this.cProducto.Name = "cProducto";
            this.cProducto.ReadOnly = true;
            this.cProducto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cProducto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cBultos
            // 
            this.cBultos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cBultos.HeaderText = "Bultos Pedidos";
            this.cBultos.Name = "cBultos";
            this.cBultos.ReadOnly = true;
            this.cBultos.Width = 105;
            // 
            // cPendiente
            // 
            this.cPendiente.HeaderText = "Bultos Pendientes";
            this.cPendiente.Name = "cPendiente";
            this.cPendiente.ReadOnly = true;
            // 
            // cEnvio
            // 
            this.cEnvio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cEnvio.HeaderText = "Bultos a Enviar";
            this.cEnvio.Name = "cEnvio";
            this.cEnvio.Width = 103;
            // 
            // cKilosEnvio
            // 
            this.cKilosEnvio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cKilosEnvio.HeaderText = "Kilos a Enviar";
            this.cKilosEnvio.Name = "cKilosEnvio";
            this.cKilosEnvio.Width = 96;
            // 
            // UcPedidos_Envio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvPedidos);
            this.Controls.Add(this.dgvContenido);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.btnSeleccionarOC);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnFinalizarEnvio);
            this.Controls.Add(this.groupDatosEnvio);
            this.Controls.Add(this.btnComenzarEnvio);
            this.Controls.Add(this.label1);
            this.Name = "UcPedidos_Envio";
            this.Size = new System.Drawing.Size(900, 730);
            this.Load += new System.EventHandler(this.UcEnvios_Load);
            this.groupDatosEnvio.ResumeLayout(false);
            this.groupDatosEnvio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCantidadPallets)).EndInit();
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContenido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFinalizarEnvio;
        private System.Windows.Forms.GroupBox groupDatosEnvio;
        private System.Windows.Forms.Button BtnGenerarRemito;
        private System.Windows.Forms.Button BtnGenerarIdPallet;
        private System.Windows.Forms.NumericUpDown cmbCantidadPallets;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRemito;
        private System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaEnvio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnComenzarEnvio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSeleccionarOC;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button btnNuevoEnvio;
        private System.Windows.Forms.DataGridView dgvContenido;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblBarra1;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cBultos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPendiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEnvio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cKilosEnvio;
    }
}
