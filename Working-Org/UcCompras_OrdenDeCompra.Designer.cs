namespace Working_Org
{
    partial class UcCompras_OrdenDeCompra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcCompras_OrdenDeCompra));
            this.topPanel = new System.Windows.Forms.Panel();
            this.btnDescartarCambios = new System.Windows.Forms.Button();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.btnEnviarOrden = new System.Windows.Forms.Button();
            this.btnEditarOrden = new System.Windows.Forms.Button();
            this.btnNuevaCompra = new System.Windows.Forms.Button();
            this.dgvCompras = new System.Windows.Forms.DataGridView();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpFechaCierre = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaApertura = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.bodyPanel = new System.Windows.Forms.Panel();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvContenido = new System.Windows.Forms.DataGridView();
            this.cId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProducto = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cStockActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCantidadPedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCantidadEntregada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblBarra1 = new System.Windows.Forms.Label();
            this.btnQuitarLinea = new System.Windows.Forms.Button();
            this.btnAgregarLinea = new System.Windows.Forms.Button();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            this.bodyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContenido)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            this.topPanel.Controls.Add(this.lblBarra1);
            this.topPanel.Controls.Add(this.btnVolver);
            this.topPanel.Controls.Add(this.btnConfirmar);
            this.topPanel.Controls.Add(this.btnEnviarOrden);
            this.topPanel.Controls.Add(this.btnEditarOrden);
            this.topPanel.Controls.Add(this.btnNuevaCompra);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(900, 55);
            this.topPanel.TabIndex = 4;
            // 
            // btnDescartarCambios
            // 
            this.btnDescartarCambios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnDescartarCambios.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDescartarCambios.FlatAppearance.BorderSize = 0;
            this.btnDescartarCambios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnDescartarCambios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnDescartarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescartarCambios.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescartarCambios.ForeColor = System.Drawing.Color.White;
            this.btnDescartarCambios.Location = new System.Drawing.Point(579, 488);
            this.btnDescartarCambios.Name = "btnDescartarCambios";
            this.btnDescartarCambios.Size = new System.Drawing.Size(150, 40);
            this.btnDescartarCambios.TabIndex = 4;
            this.btnDescartarCambios.Text = "Descartar Cambios";
            this.btnDescartarCambios.UseVisualStyleBackColor = false;
            this.btnDescartarCambios.Visible = false;
            this.btnDescartarCambios.Click += new System.EventHandler(this.btnDescartarCambios_Click);
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(70)))));
            this.btnGuardarCambios.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGuardarCambios.FlatAppearance.BorderSize = 0;
            this.btnGuardarCambios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(95)))), ((int)(((byte)(80)))));
            this.btnGuardarCambios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(65)))), ((int)(((byte)(50)))));
            this.btnGuardarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCambios.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCambios.ForeColor = System.Drawing.Color.White;
            this.btnGuardarCambios.Location = new System.Drawing.Point(423, 488);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(150, 40);
            this.btnGuardarCambios.TabIndex = 3;
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = false;
            this.btnGuardarCambios.Visible = false;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // btnEnviarOrden
            // 
            this.btnEnviarOrden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            this.btnEnviarOrden.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEnviarOrden.FlatAppearance.BorderSize = 0;
            this.btnEnviarOrden.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(13)))));
            this.btnEnviarOrden.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnEnviarOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviarOrden.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarOrden.ForeColor = System.Drawing.Color.Black;
            this.btnEnviarOrden.Location = new System.Drawing.Point(410, 0);
            this.btnEnviarOrden.Name = "btnEnviarOrden";
            this.btnEnviarOrden.Size = new System.Drawing.Size(175, 56);
            this.btnEnviarOrden.TabIndex = 2;
            this.btnEnviarOrden.Text = "ENVIAR ORDEN DE COMPRA";
            this.btnEnviarOrden.UseVisualStyleBackColor = false;
            this.btnEnviarOrden.Click += new System.EventHandler(this.btnEnviarOrden_Click);
            // 
            // btnEditarOrden
            // 
            this.btnEditarOrden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            this.btnEditarOrden.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEditarOrden.FlatAppearance.BorderSize = 0;
            this.btnEditarOrden.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(13)))));
            this.btnEditarOrden.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnEditarOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarOrden.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarOrden.ForeColor = System.Drawing.Color.Black;
            this.btnEditarOrden.Location = new System.Drawing.Point(235, 0);
            this.btnEditarOrden.Name = "btnEditarOrden";
            this.btnEditarOrden.Size = new System.Drawing.Size(175, 56);
            this.btnEditarOrden.TabIndex = 1;
            this.btnEditarOrden.Text = "EDITAR ORDEN DE COMPRA";
            this.btnEditarOrden.UseVisualStyleBackColor = false;
            this.btnEditarOrden.Click += new System.EventHandler(this.btnEditarOrden_Click);
            // 
            // btnNuevaCompra
            // 
            this.btnNuevaCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            this.btnNuevaCompra.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNuevaCompra.FlatAppearance.BorderSize = 0;
            this.btnNuevaCompra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(13)))));
            this.btnNuevaCompra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnNuevaCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaCompra.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaCompra.ForeColor = System.Drawing.Color.Black;
            this.btnNuevaCompra.Location = new System.Drawing.Point(60, 0);
            this.btnNuevaCompra.Name = "btnNuevaCompra";
            this.btnNuevaCompra.Size = new System.Drawing.Size(175, 56);
            this.btnNuevaCompra.TabIndex = 0;
            this.btnNuevaCompra.Text = "NUEVA ORDEN DE COMPRA";
            this.btnNuevaCompra.UseVisualStyleBackColor = false;
            this.btnNuevaCompra.Click += new System.EventHandler(this.btnNuevaCompra_Click);
            // 
            // dgvCompras
            // 
            this.dgvCompras.AllowUserToAddRows = false;
            this.dgvCompras.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(238)))));
            this.dgvCompras.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCompras.BackgroundColor = System.Drawing.Color.White;
            this.dgvCompras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCompras.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCompras.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(147)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(14)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCompras.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvCompras.EnableHeadersVisualStyles = false;
            this.dgvCompras.Location = new System.Drawing.Point(26, 488);
            this.dgvCompras.MultiSelect = false;
            this.dgvCompras.Name = "dgvCompras";
            this.dgvCompras.ReadOnly = true;
            this.dgvCompras.RowHeadersVisible = false;
            this.dgvCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompras.Size = new System.Drawing.Size(849, 222);
            this.dgvCompras.TabIndex = 5;
            this.dgvCompras.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompras_RowEnter);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BackColor = System.Drawing.Color.White;
            this.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservaciones.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.ForeColor = System.Drawing.Color.White;
            this.txtObservaciones.Location = new System.Drawing.Point(192, 191);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ReadOnly = true;
            this.txtObservaciones.Size = new System.Drawing.Size(651, 42);
            this.txtObservaciones.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(58, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 18);
            this.label8.TabIndex = 35;
            this.label8.Text = "Observaciones:";
            // 
            // dtpFechaCierre
            // 
            this.dtpFechaCierre.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaCierre.Location = new System.Drawing.Point(587, 151);
            this.dtpFechaCierre.Name = "dtpFechaCierre";
            this.dtpFechaCierre.Size = new System.Drawing.Size(256, 26);
            this.dtpFechaCierre.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(465, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 18);
            this.label5.TabIndex = 32;
            this.label5.Text = "Fecha de Cierre:";
            // 
            // dtpFechaApertura
            // 
            this.dtpFechaApertura.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaApertura.Location = new System.Drawing.Point(192, 151);
            this.dtpFechaApertura.Name = "dtpFechaApertura";
            this.dtpFechaApertura.Size = new System.Drawing.Size(256, 26);
            this.dtpFechaApertura.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(58, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 18);
            this.label4.TabIndex = 29;
            this.label4.Text = "Fecha de Apertura:";
            // 
            // txtOc
            // 
            this.txtOc.BackColor = System.Drawing.Color.White;
            this.txtOc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOc.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOc.ForeColor = System.Drawing.Color.White;
            this.txtOc.Location = new System.Drawing.Point(192, 114);
            this.txtOc.Name = "txtOc";
            this.txtOc.ReadOnly = true;
            this.txtOc.Size = new System.Drawing.Size(127, 27);
            this.txtOc.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(58, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "Orden de Compra:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(58, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 19;
            this.label1.Text = "Proveedor:";
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.BackColor = System.Drawing.Color.White;
            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProveedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(13)))));
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(144, 76);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(396, 27);
            this.cmbProveedor.TabIndex = 20;
            this.cmbProveedor.SelectedIndexChanged += new System.EventHandler(this.cmbProveedor_SelectedIndexChanged);
            // 
            // bodyPanel
            // 
            this.bodyPanel.BackColor = System.Drawing.Color.White;
            this.bodyPanel.Controls.Add(this.btnQuitarLinea);
            this.bodyPanel.Controls.Add(this.btnAgregarLinea);
            this.bodyPanel.Controls.Add(this.btnDescartarCambios);
            this.bodyPanel.Controls.Add(this.btnQuitar);
            this.bodyPanel.Controls.Add(this.btnGuardarCambios);
            this.bodyPanel.Controls.Add(this.label1);
            this.bodyPanel.Controls.Add(this.btnAgregar);
            this.bodyPanel.Controls.Add(this.txtOc);
            this.bodyPanel.Controls.Add(this.dgvContenido);
            this.bodyPanel.Controls.Add(this.label4);
            this.bodyPanel.Controls.Add(this.txtObservaciones);
            this.bodyPanel.Controls.Add(this.topPanel);
            this.bodyPanel.Controls.Add(this.label2);
            this.bodyPanel.Controls.Add(this.dgvCompras);
            this.bodyPanel.Controls.Add(this.label8);
            this.bodyPanel.Controls.Add(this.label5);
            this.bodyPanel.Controls.Add(this.dtpFechaApertura);
            this.bodyPanel.Controls.Add(this.dtpFechaCierre);
            this.bodyPanel.Controls.Add(this.cmbProveedor);
            this.bodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyPanel.Location = new System.Drawing.Point(0, 0);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Size = new System.Drawing.Size(900, 730);
            this.bodyPanel.TabIndex = 8;
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnQuitar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnQuitar.FlatAppearance.BorderSize = 0;
            this.btnQuitar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.btnQuitar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.ForeColor = System.Drawing.Color.White;
            this.btnQuitar.Location = new System.Drawing.Point(549, 413);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(130, 25);
            this.btnQuitar.TabIndex = 40;
            this.btnQuitar.Text = "Quitar Linea";
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Visible = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(70)))));
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(549, 444);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(130, 25);
            this.btnAgregar.TabIndex = 39;
            this.btnAgregar.Text = "Agregar Linea";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Visible = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvContenido
            // 
            this.dgvContenido.AllowUserToAddRows = false;
            this.dgvContenido.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(238)))));
            this.dgvContenido.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvContenido.BackgroundColor = System.Drawing.Color.White;
            this.dgvContenido.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvContenido.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(147)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContenido.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvContenido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvContenido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cId,
            this.cProducto,
            this.cStockActual,
            this.cCantidadPedida,
            this.cCantidadEntregada});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(14)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvContenido.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvContenido.EnableHeadersVisualStyles = false;
            this.dgvContenido.Location = new System.Drawing.Point(59, 266);
            this.dgvContenido.MultiSelect = false;
            this.dgvContenido.Name = "dgvContenido";
            this.dgvContenido.RowHeadersVisible = false;
            this.dgvContenido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContenido.Size = new System.Drawing.Size(717, 140);
            this.dgvContenido.TabIndex = 38;
            this.dgvContenido.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContenido_CellEndEdit);
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
            // 
            // cStockActual
            // 
            this.cStockActual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cStockActual.HeaderText = "Stock Actual";
            this.cStockActual.Name = "cStockActual";
            this.cStockActual.Width = 118;
            // 
            // cCantidadPedida
            // 
            this.cCantidadPedida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cCantidadPedida.HeaderText = "Cantidad Pedida";
            this.cCantidadPedida.Name = "cCantidadPedida";
            this.cCantidadPedida.Width = 140;
            // 
            // cCantidadEntregada
            // 
            this.cCantidadEntregada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cCantidadEntregada.HeaderText = "Cantidad Entregada";
            this.cCantidadEntregada.Name = "cCantidadEntregada";
            this.cCantidadEntregada.ReadOnly = true;
            this.cCantidadEntregada.Width = 162;
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
            // btnQuitarLinea
            // 
            this.btnQuitarLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnQuitarLinea.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnQuitarLinea.FlatAppearance.BorderSize = 0;
            this.btnQuitarLinea.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(13)))));
            this.btnQuitarLinea.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(97)))));
            this.btnQuitarLinea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarLinea.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarLinea.ForeColor = System.Drawing.Color.Black;
            this.btnQuitarLinea.Image = global::Working_Org.Properties.Resources.Pic_Clear2x;
            this.btnQuitarLinea.Location = new System.Drawing.Point(782, 346);
            this.btnQuitarLinea.Name = "btnQuitarLinea";
            this.btnQuitarLinea.Size = new System.Drawing.Size(60, 60);
            this.btnQuitarLinea.TabIndex = 47;
            this.btnQuitarLinea.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuitarLinea.UseVisualStyleBackColor = false;
            this.btnQuitarLinea.Click += new System.EventHandler(this.btnQuitarLinea_Click);
            // 
            // btnAgregarLinea
            // 
            this.btnAgregarLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnAgregarLinea.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAgregarLinea.FlatAppearance.BorderSize = 0;
            this.btnAgregarLinea.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(13)))));
            this.btnAgregarLinea.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(97)))));
            this.btnAgregarLinea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarLinea.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarLinea.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarLinea.Image = global::Working_Org.Properties.Resources.Pic_Add2x;
            this.btnAgregarLinea.Location = new System.Drawing.Point(782, 284);
            this.btnAgregarLinea.Name = "btnAgregarLinea";
            this.btnAgregarLinea.Size = new System.Drawing.Size(60, 60);
            this.btnAgregarLinea.TabIndex = 46;
            this.btnAgregarLinea.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarLinea.UseVisualStyleBackColor = false;
            this.btnAgregarLinea.Click += new System.EventHandler(this.btnAgregarLinea_Click);
            // 
            // UcCompras_OrdenDeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bodyPanel);
            this.Name = "UcCompras_OrdenDeCompra";
            this.Size = new System.Drawing.Size(900, 730);
            this.Load += new System.EventHandler(this.UcCompras_Load);
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            this.bodyPanel.ResumeLayout(false);
            this.bodyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContenido)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button btnDescartarCambios;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.Button btnEnviarOrden;
        private System.Windows.Forms.Button btnEditarOrden;
        private System.Windows.Forms.Button btnNuevaCompra;
        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpFechaCierre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFechaApertura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Panel bodyPanel;
        private System.Windows.Forms.DataGridView dgvContenido;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cId;
        private System.Windows.Forms.DataGridViewComboBoxColumn cProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStockActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCantidadPedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCantidadEntregada;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblBarra1;
        private System.Windows.Forms.Button btnQuitarLinea;
        private System.Windows.Forms.Button btnAgregarLinea;
    }
}
