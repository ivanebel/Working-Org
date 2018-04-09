using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Working_Org
{
    public partial class UcProveedor_Pagos : UserControl
    {
        private static UcProveedor_Pagos _instance;

        private Proveedor _proveedorSeleccionado;
        private Extras extras = new Extras();

        public static UcProveedor_Pagos Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcProveedor_Pagos();
                }

                return _instance;
            }
        }

        public UcProveedor_Pagos()
        {
            InitializeComponent();
        }

        private void UcProveedor_Pagos_Load(object sender, EventArgs e)
        {
            Controles_Inicio();

            panelCheques.Visible = false;
            panelCheques.Location = new Point(21, 22);

        }


        #region FUNCTIONS

        private void ActualizarMontos(Proveedor proveedor)
        {
            decimal saldoTotal = 0;
            decimal chequesTerceros = 0;
            decimal chequesPropios = 0;

            saldoTotal = extras.GetProveedor_Saldo(proveedor);

            if (dgvChequesTerceros.Rows.Count != 0)
            {
                foreach (DataGridViewRow row in dgvChequesTerceros.Rows)
                {
                    chequesTerceros += decimal.Parse(row.Cells["cMonto"].Value.ToString());
                }
            }

            if (dgvChequesPropios.Rows.Count != 0)
            {
                foreach (DataGridViewRow row in dgvChequesPropios.Rows)
                {
                    chequesPropios += decimal.Parse(row.Cells["cPMonto"].Value.ToString());
                }
            }


            lblTotalSaldo.Text = "$ " + decimal.Round(saldoTotal,2).ToString();
            //lblMontoAPagar.Text = "$ " + decimal.Round(montoAPagar,2).ToString();
            lblTotalChequesTerceros.Text = "$ " + decimal.Round(chequesTerceros, 2).ToString();
            lblTotalChequesPropios.Text = "$ " + decimal.Round(chequesPropios, 2).ToString();
            lblTotalEntregado.Text = "$ " + decimal.Round(chequesTerceros + chequesPropios, 2).ToString();
            lblSaldo.Text = "$ " + decimal.Round(saldoTotal - chequesTerceros - chequesPropios, 2).ToString();    

        }


        #endregion

        private void dgvChequesTerceros_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregarChequesTerceros_Click(object sender, EventArgs e)
        {
            List<Cheque> list = extras.GetCheques("WORKING");

            DataTable dt = new DataTable();

            dt.Columns.Add("Id", Type.GetType("System.Int16"));
            dt.Columns.Add("Número", Type.GetType("System.String"));
            dt.Columns.Add("Fecha Cobro", Type.GetType("System.String"));
            dt.Columns.Add("Monto", Type.GetType("System.Decimal"));

            foreach (Cheque cheque in list)
            {
                dt.Rows.Add(cheque.Id, cheque.Numero, cheque.FechaCobro, cheque.Monto);
            }
        
            dgvChequesDisponibles.DataSource = dt;

            dgvChequesDisponibles.Columns["Id"].Visible = false;
            dgvChequesDisponibles.Columns["Número"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvChequesDisponibles.Columns["Fecha Cobro"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChequesDisponibles.Columns["Monto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            panelCheques.Location = new Point(65, 290);
            panelCheques.Visible = true;
            //pictureBox1.Location = new Point(64, 250);
            //pictureBox1.Visible = true;
            mainPanel.Enabled = false;
            topPanel.Enabled = false;
        }

        private void btnSeleccionarCheques_Click(object sender, EventArgs e)
        {
            if (dgvChequesDisponibles.SelectedRows.Count != 0)
            {
                foreach (DataGridViewRow row in dgvChequesDisponibles.SelectedRows)
                {
                    Cheque cheque = new Cheque() { Id = long.Parse(row.Cells["Id"].Value.ToString()) };
                    cheque = extras.GetCheque(cheque);

                    dgvChequesTerceros.Rows.Add(cheque.Id, cheque.Numero, cheque.FechaEmision, cheque.FechaCobro, cheque.Monto);
                    
                }

                Proveedor proveedor = new Proveedor() { Id = extras.GetId(cmbProveedores.SelectedItem.ToString()) };

                ActualizarMontos(proveedor);
            }


            panelCheques.Visible = false;
            panelCheques.Location = new Point(0, 0);
            mainPanel.Enabled = true;
            topPanel.Enabled = true;
        }

        private void cmbProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            long idProveedor = extras.GetId(cmbProveedores.SelectedItem.ToString());

            Proveedor proveedor = new Proveedor() { Id = idProveedor };

            List<MovimientoProveedor> listaMovimientos = extras.GetMovimientoProveedores(proveedor);

            DataTable dt = new DataTable();

            dt.Columns.Add("Id", Type.GetType("System.Int16"));
            dt.Columns.Add("Fecha", Type.GetType("System.String"));
            dt.Columns.Add("Documento", Type.GetType("System.String"));
            dt.Columns.Add("Monto", Type.GetType("System.Decimal"));

            foreach (MovimientoProveedor movimiento in listaMovimientos)
            {
                dt.Rows.Add(movimiento.Id, movimiento.Fecha, movimiento.TipoDocumento + " " + movimiento.NumDocumento, movimiento.Monto);
            }

            dgvMovimientos.DataSource = dt;

            dgvMovimientos.Columns["Id"].Visible = false;
            dgvMovimientos.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMovimientos.Columns["Documento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMovimientos.Columns["Monto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            decimal saldoProveedor = extras.GetProveedor_Saldo(proveedor);
            lblTotalProveedor.Text = "$ " + decimal.Round(saldoProveedor, 2).ToString();

            ActualizarMontos(proveedor);

        }

        private void btnSeleccionarFacturas_Click(object sender, EventArgs e)
        {
            //if (dgvMovimientos.SelectedRows.Count != 0)
            //{
            //    decimal monto = 0;

            //    foreach (DataGridViewRow row in dgvMovimientos.SelectedRows)
            //    {
            //        monto += decimal.Parse(row.Cells["Monto"].Value.ToString());
            //    }

            //    txtMonto.Text = monto.ToString();
            //}
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Agrego nuevo movimientoproveedor
            decimal chequesTerceros = 0;
            decimal chequesPropios = 0;

            if (dgvChequesTerceros.Rows.Count != 0)
            {
                foreach (DataGridViewRow row in dgvChequesTerceros.Rows)
                {
                    chequesTerceros += decimal.Parse(row.Cells["cMonto"].Value.ToString());
                }
            }

            if (dgvChequesPropios.Rows.Count != 0)
            {
                foreach (DataGridViewRow row in dgvChequesPropios.Rows)
                {
                    chequesPropios += decimal.Parse(row.Cells["cPMonto"].Value.ToString());
                }
            }


            MovimientoProveedor movimiento = new MovimientoProveedor()
            {
                Id = extras.GetMovimientoProveedor_Id() + 1,
                IdProveedor = extras.GetId(cmbProveedores.SelectedItem.ToString()),
                CreditoDebito = "CREDITO",
                Fecha = dtpFecha.Value.ToString("yyyy-MM-dd"),
                TipoDocumento = "RECIBO",
                NumDocumento = txtNumRecibo.Text,
                Monto = (chequesTerceros + chequesPropios),
                Observaciones = txtMotivo.Text
            };

            extras.AddMovimientoProveedor(movimiento);

            // Cambio estado de cheques

            if (dgvChequesTerceros.Rows.Count != 0)
            {
                foreach (DataGridViewRow row in dgvChequesTerceros.Rows)
                {
                    Cheque cheque = new Cheque() { Id = long.Parse(row.Cells["cId"].Value.ToString()) };
                    cheque = extras.GetCheque(cheque);

                    cheque.Ubicacion = extras.GetId(cmbProveedores.SelectedItem.ToString()).ToString();

                    extras.EditCheque(cheque);
                }
            }

            if (dgvChequesPropios.Rows.Count != 0)
            {
                foreach (DataGridViewRow row in dgvChequesPropios.Rows)
                {
                    Cheque cheque = new Cheque()
                    {
                        Id = long.Parse(row.Cells["cPId"].Value.ToString()),
                        Numero = row.Cells["cPNumero"].Value.ToString(),
                        Banco = row.Cells["cPBanco"].Value.ToString(),
                        Tipo = "DIFERIDO",
                        FechaEmision = row.Cells["cPFechaEmision"].Value.ToString(),
                        FechaCobro = row.Cells["cPFechaCobro"].Value.ToString(),
                        Monto = decimal.Parse(row.Cells["cPMonto"].Value.ToString()),
                        IdCliente = 0,
                        Ubicacion = extras.GetId(cmbProveedores.SelectedItem.ToString()).ToString(),
                        Observaciones = "N/A"
                    };

                    extras.AddCheque(cheque);
                }
            }

            MessageBox.Show("jeje");

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Controles_Nuevo();

            cmbProveedores.Items.Clear();

            List<Proveedor> list = extras.GetProveedores();
            foreach (Proveedor proveedor in list)
            {
                cmbProveedores.Items.Add(proveedor.Id + ". " + proveedor.Nombre);
            }

            cmbProveedores.Focus();
            //cmbProveedores.SelectedIndex = 0;

        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            if (txtMonto.Text == "")
                txtMonto.Text = "0";

  
        }

        private void btnAgregarChequesPropios_Click(object sender, EventArgs e)
        {
            panelChequesPropios.Location = new Point(66, 250);
            panelChequesPropios.Visible = true;
            mainPanel.Enabled = false;
            topPanel.Enabled = false;
        }



        private void Controles_Inicio()
        {
            btnNuevo.Enabled = true;
            btnOk.Enabled = false;
            btnVolver.Enabled = false;

            cmbProveedores.Enabled = false;
            dtpFecha.Enabled = false;
            txtNumRecibo.ReadOnly = true;
            txtMonto.ReadOnly = true;
            txtMotivo.ReadOnly = true;
            dgvMovimientos.Enabled = false;
            btnSeleccionar.Enabled = false;

            dgvChequesTerceros.Enabled = false;
            btnAgregarChequesTerceros.Enabled = false;
            dgvChequesPropios.Enabled = false;
            btnAgregarChequesPropios.Enabled = false;

        }

        private void Controles_Nuevo()
        {
            btnNuevo.Enabled = false;
            btnOk.Enabled = true;
            btnVolver.Enabled = true;

            cmbProveedores.Enabled = true;
            dtpFecha.Enabled = true;
            txtNumRecibo.ReadOnly = false;
            txtMonto.ReadOnly = false;
            txtMotivo.ReadOnly = false;
            dgvMovimientos.Enabled = true;
            btnSeleccionar.Enabled = true;

            dgvChequesTerceros.Enabled = true;
            btnAgregarChequesTerceros.Enabled = true;
            dgvChequesPropios.Enabled = true;
            btnAgregarChequesPropios.Enabled = true;

            dgvChequesDisponibles.Enabled = true;
            btnSeleccionarCheques.Enabled = true;

        }

        private void btnAceptarChequePropio_Click(object sender, EventArgs e)
        {
            //chequeos

            decimal monto = decimal.Round(decimal.Parse(txtCPMonto.Text), 2);

            Cheque cheque = new Cheque()
            {
                Id = extras.GetCheque_Id() +1,
                Numero = txtCPNumero.Text,
                Banco = cmbCPBanco.SelectedItem.ToString(),
                Tipo = "DIFERIDO",
                FechaEmision = dtpCPFechaEmision.Value.ToString("yyyy-MM-dd"),
                FechaCobro = dtpCPFechaCobro.Value.ToString("yyyy-MM-dd"),
                Monto = monto
            };

            dgvChequesPropios.Rows.Add(cheque.Id, cheque.Banco, cheque.Numero, cheque.FechaEmision, cheque.FechaCobro, cheque.Monto);

            Proveedor proveedor = new Proveedor() { Id = extras.GetId(cmbProveedores.SelectedItem.ToString()) };

            ActualizarMontos(proveedor);
            
            panelChequesPropios.Visible = false;
            panelChequesPropios.Location = new Point(0, 0);
            mainPanel.Enabled = true;
            topPanel.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Agrego nuevo movimientoproveedor
            decimal chequesTerceros = 0;
            decimal chequesPropios = 0;

            if (dgvChequesTerceros.Rows.Count != 0)
            {
                foreach (DataGridViewRow row in dgvChequesTerceros.Rows)
                {
                    chequesTerceros += decimal.Parse(row.Cells["cMonto"].Value.ToString());
                }
            }

            if (dgvChequesPropios.Rows.Count != 0)
            {
                foreach (DataGridViewRow row in dgvChequesPropios.Rows)
                {
                    chequesPropios += decimal.Parse(row.Cells["cPMonto"].Value.ToString());
                }
            }


            MovimientoProveedor movimiento = new MovimientoProveedor()
            {
                Id = extras.GetMovimientoProveedor_Id() + 1,
                IdProveedor = extras.GetId(cmbProveedores.SelectedItem.ToString()),
                CreditoDebito = "CREDITO",
                Fecha = dtpFecha.Value.ToString("yyyy-MM-dd"),
                TipoDocumento = "RECIBO",
                NumDocumento = txtNumRecibo.Text,
                Monto = (chequesTerceros + chequesPropios),
                Observaciones = txtMotivo.Text
            };

            extras.AddMovimientoProveedor(movimiento);

            // Cambio estado de cheques

            if (dgvChequesTerceros.Rows.Count != 0)
            {
                foreach (DataGridViewRow row in dgvChequesTerceros.Rows)
                {
                    Cheque cheque = new Cheque() { Id = long.Parse(row.Cells["cId"].Value.ToString()) };
                    cheque = extras.GetCheque(cheque);

                    cheque.Ubicacion = extras.GetId(cmbProveedores.SelectedItem.ToString()).ToString();

                    extras.EditCheque(cheque);
                }
            }

            if (dgvChequesPropios.Rows.Count != 0)
            {
                foreach (DataGridViewRow row in dgvChequesPropios.Rows)
                {
                    Cheque cheque = new Cheque()
                    {
                        Id = long.Parse(row.Cells["cPId"].Value.ToString()),
                        Numero = row.Cells["cPNumero"].Value.ToString(),
                        Banco = row.Cells["cPBanco"].Value.ToString(),
                        Tipo = "DIFERIDO",
                        FechaEmision = row.Cells["cPFechaEmision"].Value.ToString(),
                        FechaCobro = row.Cells["cPFechaCobro"].Value.ToString(),
                        Monto = decimal.Parse(row.Cells["cPMonto"].Value.ToString()),
                        IdCliente = 0,
                        Ubicacion = extras.GetId(cmbProveedores.SelectedItem.ToString()).ToString(),
                        Observaciones = "N/A"
                    };

                    extras.AddCheque(cheque);
                }
            }

            MessageBox.Show("jeje");
        }

        private void btnDescartar_Click(object sender, EventArgs e)
        {

        }
    }
}
