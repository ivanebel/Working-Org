using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Core;

namespace Working_Org
{
    public partial class UcVentas_Cobranza : UserControl
    {
        private static UcVentas_Cobranza _instance;

        private Extras extras = new Extras();

        private decimal _totalFacturas;
        private decimal _totalDebitos;
        private decimal _totalRetenciones;

        private bool _isNuevo = false;

        public static UcVentas_Cobranza Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcVentas_Cobranza();
                }

                return _instance;
            }

        }
        public UcVentas_Cobranza()
        {
            InitializeComponent();
        }

        private void UcVentas_Cobranza_Load(object sender, EventArgs e)
        {
            Controles_Inicio();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(UcInformes_B.Instance))
            {
                mainPanel.Controls.Add(UcInformes_B.Instance);
                UcInformes_B.Instance.Dock = DockStyle.Fill;
                UcInformes_B.Instance.BringToFront();
            }
            else
            {
                UcInformes_B.Instance.BringToFront();
            }



            //Controles_Nuevo();

            //List<Cliente> listaClientes = extras.GetClientes();

            //cmbClientes.Items.Clear();

            //foreach (Cliente cliente in listaClientes)
            //{
            //    cmbClientes.Items.Add(cliente.Id + ". " + cliente.Nombre);
            //}

            //cmbClientes.SelectedIndex = 0;

            //cmbTipoDocumento.SelectedIndex = 0;
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedItem != null)
            {
                Cliente cliente = new Cliente() { Id = extras.GetId(cmbClientes.SelectedItem.ToString()) };

                List<Factura> listaFacturas = extras.GetFacturas(cliente, "ABIERTO");

                SetTable_Facturas(listaFacturas);
            }

        }


        private void btnSeleccionarPedido_Click(object sender, EventArgs e)
        {
            Controles_FacturaSeleccionada();

            _totalFacturas = 0;

            decimal montoSiniva = 0;

            foreach (DataGridViewRow row in dgvFacturas.SelectedRows)
            {
                montoSiniva += decimal.Parse(row.Cells["Monto"].Value.ToString());
                decimal montoFactura = decimal.Parse(row.Cells["Monto c/IVA"].Value.ToString());

                _totalFacturas += montoFactura;

            }

            lblTotalFacturas.Text = "$ " + _totalFacturas.ToString();

            txtBaseGanancias.Text = montoSiniva.ToString();
            txtBaseIIBB.Text = montoSiniva.ToString();

        }

        private void btnAgregarND_Click(object sender, EventArgs e)
        {
            int idRow = dgvDebitos.Rows.Count;

            dgvDebitos.Rows.Add();

            dgvDebitos.Rows[idRow].Cells["cTipo"].Value = "NOTA DE DÉBITO";
            dgvDebitos.Rows[idRow].Cells["cMonto"].Value = "0,00";
            dgvDebitos.Rows[idRow].Cells["cIva"].Value = "21";
            dgvDebitos.Rows[idRow].Cells["cTotalIva"].Value = "0,00";
            dgvDebitos.Rows[idRow].Cells["cTotal"].Value = "0,00";
        }

        private void btnAgregarNC_Click(object sender, EventArgs e)
        {
            int idRow = dgvDebitos.Rows.Count;

            dgvDebitos.Rows.Add();

            dgvDebitos.Rows[idRow].Cells["cTipo"].Value = "NOTA DE CRÉDITO";
            dgvDebitos.Rows[idRow].Cells["cMonto"].Value = "0,00";
            dgvDebitos.Rows[idRow].Cells["cIva"].Value = "21";
            dgvDebitos.Rows[idRow].Cells["cTotalIva"].Value = "0,00";
            dgvDebitos.Rows[idRow].Cells["cTotal"].Value = "0,00";
        }

        private void dgvDebitos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDebitos.SelectedRows.Count != 0)
            {
                try
                {
                    decimal iva = 0;
                    decimal monto = 0;
                    decimal ivaTotal = 0;

                    decimal.TryParse(dgvDebitos.SelectedRows[0].Cells["cIva"].Value.ToString(), out iva);
                    decimal.TryParse(dgvDebitos.SelectedRows[0].Cells["cMonto"].Value.ToString(), out monto);

                    ivaTotal = (monto * (iva / 100));
                    dgvDebitos.SelectedRows[0].Cells["cTotalIva"].Value = ivaTotal;

                    dgvDebitos.SelectedRows[0].Cells["cTotal"].Value = (monto + ivaTotal).ToString();

                    ActualizarTotal();

                    //lblTotal.Text = "$ " + this._totalCobranza.ToString();
                }
                catch (Exception ex)
                {
                    dgvDebitos.SelectedRows[0].Cells["cMonto"].Value = 0;
                }



            }
        }

        private void ActualizarTotal()
        {
            _totalDebitos = 0;

            if (dgvDebitos.Rows.Count != 0)
            {
                foreach (DataGridViewRow row in dgvDebitos.Rows)
                {
                    int iDebito = 1;

                    string tipo = row.Cells["cTipo"].Value.ToString();

                    if (tipo == "NOTA DE CRÉDITO")
                        iDebito = -1;

                    decimal totalLinea = decimal.Parse(row.Cells["cTotal"].Value.ToString());

                    _totalDebitos += (totalLinea * iDebito);

                }
            }

            decimal rIIBB = decimal.Parse(txtTotalIIBB.Text);
            decimal rGanancias = decimal.Parse(txtTotalGanancias.Text);

            _totalRetenciones = (rIIBB + rGanancias);

            lblTotalFacturas.Text = "$ " + decimal.Round(_totalFacturas, 2).ToString();
            lblTotalND.Text = "$ " + decimal.Round(_totalDebitos, 2).ToString();
            lblTotalRetenciones.Text = "$ " + decimal.Round(_totalRetenciones, 2).ToString();
            lblTotalCobranza.Text = "$ " + decimal.Round(_totalFacturas - _totalDebitos - _totalRetenciones, 2).ToString();



        }


        #region FUNCTIONS

        private void ArmarTablaDocumentos()
        {
            DataTable dataTable = new DataTable();

            //dataTable.Columns.Add("Id", Type.GetType("System.Int16"));
            dataTable.Columns.Add("Tipo", Type.GetType("System.String"));
            dataTable.Columns.Add("Número Documento", Type.GetType("System.String"));
            dataTable.Columns.Add("Detalle", Type.GetType("System.String"));
            dataTable.Columns.Add("Monto", Type.GetType("System.Decimal"));
            dataTable.Columns.Add("IVA", Type.GetType("System.Decimal"));
            dataTable.Columns.Add("Total IVA", Type.GetType("System.Decimal"));
            dataTable.Columns.Add("Total", Type.GetType("System.Decimal"));

            dgvDebitos.DataSource = dataTable;
        }

        private void SetTable_Facturas(List<Factura> listaFacturas)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", Type.GetType("System.Int16"));
            dt.Columns.Add("Fecha", Type.GetType("System.String"));
            dt.Columns.Add("Factura", Type.GetType("System.String"));
            dt.Columns.Add("Monto", Type.GetType("System.Decimal"));
            dt.Columns.Add("Monto c/IVA", Type.GetType("System.Decimal"));

            foreach (Factura factura in listaFacturas)
            {
                dt.Rows.Add(factura.Id, factura.FechaEmision, "FAC " + factura.Numero, factura.ImporteNeto, factura.ImporteTotal);
            }

            dgvFacturas.DataSource = dt;

            dgvFacturas.Columns["Id"].Visible = false;
            dgvFacturas.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvFacturas.Columns["Factura"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFacturas.Columns["Monto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvFacturas.Columns["Monto c/IVA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


        }



        #endregion





        private void btnContinuarCobranza_Click(object sender, EventArgs e)
        {
            Controles_MontosConfirmados();

            cmbBancos.SelectedIndex = 0;
            txtMontoTotalCheques.Text = (_totalFacturas - _totalDebitos - _totalRetenciones).ToString();

            dtpFechaCobroCheque.Value = dtpFechaEmisionCheque.Value.AddDays(60);
        }

        private void btnGenerarCheques_Click(object sender, EventArgs e)
        {
            dgvCheques.Rows.Clear();

            int cantidadCheques = int.Parse(txtCantidadCheques.Text);
            decimal montoTotal = decimal.Parse(txtMontoTotalCheques.Text);
            int numeracionCheque = int.Parse(txtNumeroInicial.Text);

            decimal montoCheque = montoTotal / cantidadCheques;
            montoCheque = decimal.Round(montoCheque, 2);

            for (int i = 0; i <= cantidadCheques - 1; i++)
            {
                //numeracionCheque += i;
                dgvCheques.Rows.Add((numeracionCheque + i).ToString(), montoCheque.ToString());

            }

        }

        private void dgvCheques_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCheques_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            // Creo COBRANZA
            Cobranza cobranza = new Cobranza()
            {
                Id = extras.GetCobranza_Id() + 1,
                IdCliente = extras.GetId(cmbClientes.SelectedItem.ToString()),
                TipoDocumento = cmbTipoDocumento.SelectedItem.ToString(),
                NroDocumento = txtNroDocumento.Text,
                Monto = (_totalFacturas - _totalDebitos - _totalRetenciones),
                Fecha = dtpFecha.Value.ToString("yyyy-MM-dd")
            };

            // Añado Facturas, ND, NC a las LINEAS COBRANZA
            List<LineaCobranza> lineasCobranza = new List<LineaCobranza>();

            long idLineaCobranza = extras.GetLineaCobranza_Id();

            //Añado la/s factura/s
            foreach (DataGridViewRow rowFactura in dgvFacturas.SelectedRows)
            {
                string[] doc = rowFactura.Cells["Factura"].Value.ToString().Split(' ');
                decimal monto = decimal.Parse(rowFactura.Cells["Monto"].Value.ToString());
                decimal montoTotal = decimal.Parse(rowFactura.Cells["Monto c/IVA"].Value.ToString());

                string tipoDoc = doc[0];
                string numeroDoc = doc[1].Trim();

                idLineaCobranza += 1;

                LineaCobranza linea = new LineaCobranza
                {
                    Id = idLineaCobranza,
                    IdCobranza = cobranza.Id,
                    TipoDocumento = tipoDoc,
                    NroDocumento = numeroDoc,
                    Detalle = "FACTURA",
                    Monto = monto,
                    Iva = 21,
                    IvaTotal = (montoTotal - monto),
                    Total = montoTotal
                };

                lineasCobranza.Add(linea);
            }

            //Añado lás ND/NC
            foreach (DataGridViewRow rowDebitos in dgvDebitos.Rows)
            {
                string tipoDocumento = rowDebitos.Cells["cTipo"].Value.ToString();
                string nroDocumento = rowDebitos.Cells["cNumero"].Value.ToString();
                string detalle = rowDebitos.Cells["cDetalle"].Value.ToString();
                decimal monto = decimal.Parse(rowDebitos.Cells["cMonto"].Value.ToString());
                decimal iva = decimal.Parse(rowDebitos.Cells["cIva"].Value.ToString());
                decimal totalIva = decimal.Parse(rowDebitos.Cells["cTotalIva"].Value.ToString());
                decimal total = decimal.Parse(rowDebitos.Cells["cTotal"].Value.ToString());

                idLineaCobranza += 1;

                LineaCobranza linea = new LineaCobranza
                {
                    Id = idLineaCobranza,
                    IdCobranza = cobranza.Id,
                    TipoDocumento = tipoDocumento,
                    NroDocumento = nroDocumento,
                    Detalle = detalle,
                    Monto = monto,
                    Iva = iva,
                    IvaTotal = totalIva,
                    Total = total
                };

                lineasCobranza.Add(linea);
            }

            // Genero CHEQUES

            List<Cheque> listaCheques = new List<Cheque>();
            long idCheque = extras.GetCheque_Id();

            foreach (DataGridViewRow rowCheque in dgvCheques.Rows)
            {
                string numero = rowCheque.Cells["cNumeroCheque"].Value.ToString();
                decimal monto = decimal.Parse(rowCheque.Cells["cMontoCheque"].Value.ToString());

                idCheque += 1;

                Cheque cheque = new Cheque()
                {
                    Id = idCheque,
                    Numero = numero,
                    Banco = cmbBancos.SelectedItem.ToString(),
                    Tipo = "DIFERIDO",
                    FechaEmision = dtpFechaEmisionCheque.Value.ToString("yyyy-MM-dd"),
                    FechaCobro = dtpFechaCobroCheque.Value.ToString("yyyy-MM-dd"),
                    IdCliente = extras.GetId(cmbClientes.SelectedItem.ToString()),
                    Monto = monto,
                    Ubicacion = "WORKING",
                    Observaciones = ""
                };

                listaCheques.Add(cheque);
            }

            extras.AddCobranza(cobranza);
            extras.AddLineaCobranza(lineasCobranza);
            extras.AddCheque(listaCheques);

            // Cambio estado de VENTA
            foreach (DataGridViewRow rowFactura in dgvFacturas.SelectedRows)
            {
                Factura factura = new Factura() { Id = long.Parse(rowFactura.Cells["Id"].Value.ToString()) };
                factura = extras.GetFactura(factura);

                factura.Estado = "CERRADO";

                extras.EditFactura(factura);
            }

            MessageBox.Show("jeje");

            DescartarCambios();
            Controles_Inicio();

        }





        private void Controles_Inicio()
        {
            btnNuevo.Enabled = true;
            //btnEditar.Enabled = false;
            btnConfirmar.Enabled = false;
            btnVolver.Enabled = false;

            cmbClientes.Enabled = false;
            dtpFecha.Enabled = false;
            cmbTipoDocumento.Enabled = false;
            txtNroDocumento.ReadOnly = true;
            dgvFacturas.Enabled = false;
            btnSeleccionar.Enabled = false;

            dgvDebitos.Enabled = false;
            btnAgregarNC.Enabled = false;
            btnAgregarND.Enabled = false;
            btnBorrar.Enabled = false;

            groupCheques.Enabled = false;
        }

        private void Controles_Nuevo()
        {
            btnNuevo.Enabled = false;
            //btnEditar.Enabled = false;
            btnConfirmar.Enabled = false;
            btnVolver.Enabled = true;

            cmbClientes.Enabled = true;
            dtpFecha.Enabled = true;
            cmbTipoDocumento.Enabled = true;
            txtNroDocumento.ReadOnly = false;
            dgvFacturas.Enabled = true;
            btnSeleccionar.Enabled = true;

            dgvDebitos.Enabled = false;
            btnAgregarNC.Enabled = false;
            btnAgregarND.Enabled = false;
            btnBorrar.Enabled = false;

            groupCheques.Enabled = false;
        }

        private void Controles_FacturaSeleccionada()
        {
            btnNuevo.Enabled = false;
            //btnEditar.Enabled = false;
            btnConfirmar.Enabled = false;
            btnVolver.Enabled = true;

            cmbClientes.Enabled = false;
            dtpFecha.Enabled = true;
            cmbTipoDocumento.Enabled = true;
            txtNroDocumento.ReadOnly = false;
            dgvFacturas.Enabled = false;
            btnSeleccionar.Enabled = false;

            dgvDebitos.Enabled = true;
            btnAgregarNC.Enabled = true;
            btnAgregarND.Enabled = true;
            btnBorrar.Enabled = true;

            groupCheques.Enabled = false;
        }

        private void Controles_MontosConfirmados()
        {
            btnNuevo.Enabled = false;
            //btnEditar.Enabled = false;
            btnConfirmar.Enabled = true;
            btnVolver.Enabled = true;

            cmbClientes.Enabled = false;
            dtpFecha.Enabled = true;
            cmbTipoDocumento.Enabled = true;
            txtNroDocumento.ReadOnly = true;
            dgvFacturas.Enabled = false;
            btnSeleccionar.Enabled = false;

            dgvDebitos.Enabled = true;
            btnAgregarNC.Enabled = true;
            btnAgregarND.Enabled = true;
            btnBorrar.Enabled = true;

            groupCheques.Enabled = true;
        }

        private void btnDescartar_Click(object sender, EventArgs e)
        {
            DescartarCambios();
            Controles_Inicio();
        }

        public void DescartarCambios()
        {
            dgvCheques.Rows.Clear();
            txtNumeroInicial.Text = "";
            txtCantidadCheques.Text = "0";
            txtMontoTotalCheques.Text = "0,00";

            dgvDebitos.Rows.Clear();

            txtNroDocumento.Text = "";
            dgvFacturas.Rows.Clear();
            cmbClientes.SelectedItem = null;
        }

        private void txtTotalIIBB_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotal();
        }

        private void txtTotalGanancias_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotal();
        }

        private void txtBaseIIBB_TextChanged(object sender, EventArgs e)
        {
            if (txtBaseIIBB.Text == "")
                txtBaseIIBB.Text = "0,00";

            decimal dBase = decimal.Parse(txtBaseIIBB.Text);
            decimal dAlicuota = decimal.Parse(txtAlicuotaIIBB.Text) / 100;

            txtTotalIIBB.Text = decimal.Round(dBase * dAlicuota, 2).ToString();
        }

        private void txtBaseGanancias_TextChanged(object sender, EventArgs e)
        {
            if (txtBaseGanancias.Text == "")
                txtBaseGanancias.Text = "0,00";

            decimal dBase = decimal.Parse(txtBaseGanancias.Text);
            decimal dAlicuota = decimal.Parse(txtAlicuotaGanancias.Text) / 100;

            txtTotalGanancias.Text = decimal.Round(dBase * dAlicuota, 2).ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Creo COBRANZA
            Cobranza cobranza = new Cobranza()
            {
                Id = extras.GetCobranza_Id() + 1,
                IdCliente = extras.GetId(cmbClientes.SelectedItem.ToString()),
                TipoDocumento = cmbTipoDocumento.SelectedItem.ToString(),
                NroDocumento = txtNroDocumento.Text,
                Monto = (_totalFacturas - _totalDebitos - _totalRetenciones),
                Fecha = dtpFecha.Value.ToString("yyyy-MM-dd")
            };

            // Añado Facturas, ND, NC a las LINEAS COBRANZA
            List<LineaCobranza> lineasCobranza = new List<LineaCobranza>();

            long idLineaCobranza = extras.GetLineaCobranza_Id();

            //Añado la/s factura/s
            foreach (DataGridViewRow rowFactura in dgvFacturas.SelectedRows)
            {
                string[] doc = rowFactura.Cells["Factura"].Value.ToString().Split(' ');
                decimal monto = decimal.Parse(rowFactura.Cells["Monto"].Value.ToString());
                decimal montoTotal = decimal.Parse(rowFactura.Cells["Monto c/IVA"].Value.ToString());

                string tipoDoc = doc[0];
                string numeroDoc = doc[1].Trim();

                idLineaCobranza += 1;

                LineaCobranza linea = new LineaCobranza
                {
                    Id = idLineaCobranza,
                    IdCobranza = cobranza.Id,
                    TipoDocumento = tipoDoc,
                    NroDocumento = numeroDoc,
                    Detalle = "FACTURA",
                    Monto = monto,
                    Iva = 21,
                    IvaTotal = (montoTotal - monto),
                    Total = montoTotal
                };

                lineasCobranza.Add(linea);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            DescartarCambios();
            Controles_Inicio();
        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(UcInformes_C.Instance))
            {
                mainPanel.Controls.Add(UcInformes_C.Instance);
                UcInformes_C.Instance.Dock = DockStyle.Fill;
                UcInformes_C.Instance.BringToFront();
            }
            else
            {
                UcInformes_C.Instance.BringToFront();
            }
        }
    }
}
