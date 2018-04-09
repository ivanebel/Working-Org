namespace Working_Org
{
    partial class UcPedidos_Historicos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bodyPanel = new System.Windows.Forms.Panel();
            this.dgvContenido = new System.Windows.Forms.DataGridView();
            this.cId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBultos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBultosE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUnidades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUnidadesE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cKilos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cKilosE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.txtFechaEmision = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDireccionCD = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.txtHoraEntrega = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMuelle = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOc = new System.Windows.Forms.TextBox();
            this.txtFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkReprogramado = new System.Windows.Forms.CheckBox();
            this.bodyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContenido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // bodyPanel
            // 
            this.bodyPanel.BackColor = System.Drawing.Color.White;
            this.bodyPanel.Controls.Add(this.dgvContenido);
            this.bodyPanel.Controls.Add(this.label1);
            this.bodyPanel.Controls.Add(this.txtCd);
            this.bodyPanel.Controls.Add(this.label4);
            this.bodyPanel.Controls.Add(this.txtCliente);
            this.bodyPanel.Controls.Add(this.dgvPedidos);
            this.bodyPanel.Controls.Add(this.txtFechaEmision);
            this.bodyPanel.Controls.Add(this.label2);
            this.bodyPanel.Controls.Add(this.txtDireccionCD);
            this.bodyPanel.Controls.Add(this.label7);
            this.bodyPanel.Controls.Add(this.txtObservaciones);
            this.bodyPanel.Controls.Add(this.txtHoraEntrega);
            this.bodyPanel.Controls.Add(this.label5);
            this.bodyPanel.Controls.Add(this.txtMuelle);
            this.bodyPanel.Controls.Add(this.label8);
            this.bodyPanel.Controls.Add(this.txtOc);
            this.bodyPanel.Controls.Add(this.txtFechaEntrega);
            this.bodyPanel.Controls.Add(this.label6);
            this.bodyPanel.Controls.Add(this.label3);
            this.bodyPanel.Controls.Add(this.chkReprogramado);
            this.bodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyPanel.Location = new System.Drawing.Point(0, 0);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Size = new System.Drawing.Size(900, 730);
            this.bodyPanel.TabIndex = 8;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContenido.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvContenido.ColumnHeadersHeight = 40;
            this.dgvContenido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvContenido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cId,
            this.cProducto,
            this.cBultos,
            this.cBultosE,
            this.cUnidades,
            this.cUnidadesE,
            this.cKilos,
            this.cKilosE});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(14)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvContenido.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvContenido.EnableHeadersVisualStyles = false;
            this.dgvContenido.Location = new System.Drawing.Point(18, 235);
            this.dgvContenido.MultiSelect = false;
            this.dgvContenido.Name = "dgvContenido";
            this.dgvContenido.RowHeadersVisible = false;
            this.dgvContenido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContenido.Size = new System.Drawing.Size(865, 140);
            this.dgvContenido.TabIndex = 42;
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
            this.cProducto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cProducto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cBultos
            // 
            this.cBultos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cBultos.HeaderText = "Bultos Pedidos";
            this.cBultos.Name = "cBultos";
            this.cBultos.Width = 105;
            // 
            // cBultosE
            // 
            this.cBultosE.HeaderText = "Bultos Entregados";
            this.cBultosE.Name = "cBultosE";
            // 
            // cUnidades
            // 
            this.cUnidades.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cUnidades.HeaderText = "Unidades Pedidas";
            this.cUnidades.Name = "cUnidades";
            this.cUnidades.ReadOnly = true;
            this.cUnidades.Width = 121;
            // 
            // cUnidadesE
            // 
            this.cUnidadesE.HeaderText = "Unidades Entregadas";
            this.cUnidadesE.Name = "cUnidadesE";
            // 
            // cKilos
            // 
            this.cKilos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cKilos.HeaderText = "Kilos Pedidos";
            this.cKilos.Name = "cKilos";
            this.cKilos.ReadOnly = true;
            this.cKilos.Width = 98;
            // 
            // cKilosE
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cKilosE.DefaultCellStyle = dataGridViewCellStyle3;
            this.cKilosE.HeaderText = "Kilos Entregados";
            this.cKilosE.Name = "cKilosE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(34, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 19;
            this.label1.Text = "Cliente:";
            // 
            // txtCd
            // 
            this.txtCd.BackColor = System.Drawing.Color.White;
            this.txtCd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCd.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCd.ForeColor = System.Drawing.Color.Black;
            this.txtCd.Location = new System.Drawing.Point(168, 106);
            this.txtCd.Name = "txtCd";
            this.txtCd.Size = new System.Drawing.Size(240, 26);
            this.txtCd.TabIndex = 37;
            this.txtCd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(421, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 18);
            this.label4.TabIndex = 29;
            this.label4.Text = "Fecha Emisión:";
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.White;
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.ForeColor = System.Drawing.Color.Black;
            this.txtCliente.Location = new System.Drawing.Point(99, 32);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(396, 26);
            this.txtCliente.TabIndex = 36;
            this.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(238)))));
            this.dgvPedidos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPedidos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPedidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPedidos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPedidos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPedidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPedidos.ColumnHeadersHeight = 40;
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(14)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPedidos.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPedidos.EnableHeadersVisualStyles = false;
            this.dgvPedidos.Location = new System.Drawing.Point(37, 445);
            this.dgvPedidos.MultiSelect = false;
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.RowHeadersVisible = false;
            this.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidos.Size = new System.Drawing.Size(821, 256);
            this.dgvPedidos.TabIndex = 2;
            this.dgvPedidos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidos_RowEnter);
            // 
            // txtFechaEmision
            // 
            this.txtFechaEmision.Enabled = false;
            this.txtFechaEmision.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaEmision.Location = new System.Drawing.Point(538, 69);
            this.txtFechaEmision.Name = "txtFechaEmision";
            this.txtFechaEmision.Size = new System.Drawing.Size(320, 26);
            this.txtFechaEmision.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(34, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "Orden de Compra:";
            // 
            // txtDireccionCD
            // 
            this.txtDireccionCD.BackColor = System.Drawing.Color.White;
            this.txtDireccionCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccionCD.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccionCD.ForeColor = System.Drawing.Color.Black;
            this.txtDireccionCD.Location = new System.Drawing.Point(453, 106);
            this.txtDireccionCD.Name = "txtDireccionCD";
            this.txtDireccionCD.ReadOnly = true;
            this.txtDireccionCD.Size = new System.Drawing.Size(405, 26);
            this.txtDireccionCD.TabIndex = 27;
            this.txtDireccionCD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(475, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 18);
            this.label7.TabIndex = 34;
            this.label7.Text = "Muelle:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BackColor = System.Drawing.Color.White;
            this.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservaciones.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.ForeColor = System.Drawing.Color.Black;
            this.txtObservaciones.Location = new System.Drawing.Point(168, 180);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ReadOnly = true;
            this.txtObservaciones.Size = new System.Drawing.Size(690, 42);
            this.txtObservaciones.TabIndex = 31;
            // 
            // txtHoraEntrega
            // 
            this.txtHoraEntrega.CustomFormat = "HH:mm";
            this.txtHoraEntrega.Enabled = false;
            this.txtHoraEntrega.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoraEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtHoraEntrega.Location = new System.Drawing.Point(378, 141);
            this.txtHoraEntrega.Name = "txtHoraEntrega";
            this.txtHoraEntrega.Size = new System.Drawing.Size(67, 26);
            this.txtHoraEntrega.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(34, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 18);
            this.label5.TabIndex = 32;
            this.label5.Text = "Fecha Entrega:";
            // 
            // txtMuelle
            // 
            this.txtMuelle.BackColor = System.Drawing.Color.White;
            this.txtMuelle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMuelle.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMuelle.ForeColor = System.Drawing.Color.Black;
            this.txtMuelle.Location = new System.Drawing.Point(538, 141);
            this.txtMuelle.Name = "txtMuelle";
            this.txtMuelle.ReadOnly = true;
            this.txtMuelle.Size = new System.Drawing.Size(55, 26);
            this.txtMuelle.TabIndex = 28;
            this.txtMuelle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(34, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 18);
            this.label8.TabIndex = 35;
            this.label8.Text = "Observaciones:";
            // 
            // txtOc
            // 
            this.txtOc.BackColor = System.Drawing.Color.White;
            this.txtOc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOc.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOc.ForeColor = System.Drawing.Color.Black;
            this.txtOc.Location = new System.Drawing.Point(168, 69);
            this.txtOc.Name = "txtOc";
            this.txtOc.ReadOnly = true;
            this.txtOc.Size = new System.Drawing.Size(127, 26);
            this.txtOc.TabIndex = 21;
            this.txtOc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFechaEntrega
            // 
            this.txtFechaEntrega.Enabled = false;
            this.txtFechaEntrega.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaEntrega.Location = new System.Drawing.Point(168, 141);
            this.txtFechaEntrega.Name = "txtFechaEntrega";
            this.txtFechaEntrega.Size = new System.Drawing.Size(98, 26);
            this.txtFechaEntrega.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(272, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 18);
            this.label6.TabIndex = 33;
            this.label6.Text = "Hora Entrega:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(34, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 18);
            this.label3.TabIndex = 24;
            this.label3.Text = "Lugar de Entrega:";
            // 
            // chkReprogramado
            // 
            this.chkReprogramado.AutoSize = true;
            this.chkReprogramado.Enabled = false;
            this.chkReprogramado.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReprogramado.ForeColor = System.Drawing.Color.Black;
            this.chkReprogramado.Location = new System.Drawing.Point(683, 33);
            this.chkReprogramado.Name = "chkReprogramado";
            this.chkReprogramado.Size = new System.Drawing.Size(175, 22);
            this.chkReprogramado.TabIndex = 30;
            this.chkReprogramado.Text = "Pedido Reprogramado";
            this.chkReprogramado.UseVisualStyleBackColor = true;
            // 
            // UcPedidos_Historicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bodyPanel);
            this.Name = "UcPedidos_Historicos";
            this.Size = new System.Drawing.Size(900, 730);
            this.Load += new System.EventHandler(this.UcPedidosHistoricos_Load);
            this.bodyPanel.ResumeLayout(false);
            this.bodyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContenido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bodyPanel;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.CheckBox chkReprogramado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMuelle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtHoraEntrega;
        private System.Windows.Forms.TextBox txtOc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtFechaEntrega;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDireccionCD;
        private System.Windows.Forms.DateTimePicker txtFechaEmision;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCd;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.DataGridView dgvContenido;
        private System.Windows.Forms.DataGridViewTextBoxColumn cId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cBultos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cBultosE;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUnidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUnidadesE;
        private System.Windows.Forms.DataGridViewTextBoxColumn cKilos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cKilosE;
    }
}
