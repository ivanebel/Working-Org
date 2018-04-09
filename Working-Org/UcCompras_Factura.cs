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
    public partial class UcCompras_Factura : UserControl
    {
        private static UcCompras_Factura _instance;

        private Extras extras = new Extras();

        public static UcCompras_Factura Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcCompras_Factura();
                }

                return _instance;
            }
        }

        public UcCompras_Factura()
        {
            InitializeComponent();
        }

        private void UcCompras_Factura_Load(object sender, EventArgs e)
        {
            Controles_Inicio();

            SetTable_Facturas();


        }

        private void SetTable_Facturas()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", Type.GetType("System.Int16"));
            dt.Columns.Add("Emisor", Type.GetType("System.String"));
            dt.Columns.Add("Documento", Type.GetType("System.String"));
            dt.Columns.Add("Fecha Emisión", Type.GetType("System.String"));
            dt.Columns.Add("Subtotal", Type.GetType("System.Decimal"));
            dt.Columns.Add("IVA", Type.GetType("System.Decimal"));
            dt.Columns.Add("Total", Type.GetType("System.Decimal"));

            List<Factura> listaFacturas = extras.GetFacturas("COMPRA");

            if (listaFacturas.Count != 0)
            {
                foreach (Factura factura in listaFacturas)
                {
                    Proveedor proveedor = new Proveedor() { Id = factura.IdEmisor };
                    proveedor = extras.GetProveedor(proveedor);

                    dt.Rows.Add(factura.Id, proveedor.Nombre, "FA " + factura.Numero, factura.FechaEmision, factura.ImporteNeto, factura.Iva, factura.ImporteTotal);
                }

                dgvFacturas.DataSource = dt;

                dgvFacturas.Columns["Id"].Visible = false;
                dgvFacturas.Columns["Emisor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvFacturas.Columns["Documento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvFacturas.Columns["Fecha Emisión"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvFacturas.Columns["Subtotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvFacturas.Columns["IVA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvFacturas.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbProveedor.SelectedItem == null)
            {
                return;
            }

            Proveedor proveedor = new Proveedor() { Id = extras.GetId(cmbProveedor.SelectedItem.ToString()) };
            proveedor = extras.GetProveedor(proveedor);

            List<Producto> listaProductos = extras.GetProductos(proveedor);

            int iFila = dgvContenido.Rows.Add();

            DataGridViewRow row = dgvContenido.Rows[iFila];

            var cProducto = row.Cells["cProducto"] as DataGridViewComboBoxCell;

            foreach (Producto p in listaProductos)
            {
                cProducto.Items.Add(p.Id + ". " + p.Nombre);
            }

            row.Cells["cCantidad"].Value = decimal.Round(0, 2);
            row.Cells["cPrecioUnitario"].Value = decimal.Round(0, 2);
            row.Cells["cSubtotal"].Value = decimal.Round(0, 2);
            row.Cells["cAlicuotaIva"].Value = decimal.Round(21,2);
            row.Cells["cIVA"].Value = decimal.Round(0, 2);
            row.Cells["cTotal"].Value = decimal.Round(0, 2);

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Controles_Nuevo();

            List<Proveedor> list = extras.GetProveedores();

            foreach (Proveedor proveedor in list)
            {
                cmbProveedor.Items.Add(proveedor.Id + ". " + proveedor.Nombre);
            }

            txtObservaciones.Text = "N/A";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //chequeos

            Factura factura = new Factura()
            {
                Id = extras.GetFactura_Id() + 1,
                CompraVenta = "COMPRA",
                IdEmisor = extras.GetId(cmbProveedor.SelectedItem.ToString()),
                IdDestinatario = 0,
                FechaEmision = dtpFechaEmision.Value.ToString("yyyy-MM-dd"),
                FechaVencimiento = dtpFechaVencimiento.Value.ToString("yyyy-MM-dd"),
                Numero = txtNumero.Text,
                ImporteNeto = decimal.Parse(txtTotalSinIva.Text),
                ImporteTotal = decimal.Parse(txtTotalConIva.Text),
                Estado = "ABIERTO",
                Observaciones = txtObservaciones.Text,
            };

            List<LineaFactura> list = new List<LineaFactura>();

            foreach (DataGridViewRow row in dgvContenido.Rows)
            {

                LineaFactura linea = new LineaFactura()
                {
                    Id = extras.GetLineaFactura_Id() + 1,
                    IdProducto = extras.GetId(row.Cells["cProducto"].Value.ToString()),
                    Cantidad = decimal.Parse(row.Cells["cCantidad"].Value.ToString()),
                    PrecioUnitario = decimal.Parse(row.Cells["cPrecioUnitario"].Value.ToString()),
                    Subtotal = decimal.Parse(row.Cells["cSubtotal"].Value.ToString()),
                    AlicuotaIva = decimal.Parse(row.Cells["cAlicuotaIva"].Value.ToString()),
                    Total = decimal.Parse(row.Cells["cTotal"].Value.ToString()),
                    Estado = "ABIERTO"
                };

            }

            MovimientoProveedor movimiento = new MovimientoProveedor()
            {
                Id = extras.GetMovimientoProveedor_Id() + 1,
                IdProveedor = extras.GetId(cmbProveedor.SelectedItem.ToString()),
                CreditoDebito = "DEBITO",
                Fecha = dtpFechaEmision.Value.ToString("yyyy-MM-dd"),
                TipoDocumento = cmbTipoDocumento.SelectedItem.ToString(),
                NumDocumento = txtNumero.Text,
                Monto = decimal.Parse(txtTotalConIva.Text),
                Observaciones = txtObservaciones.Text
                
            };

            extras.AddFactura(factura);
            extras.AddLineaFactura(list);
            extras.AddMovimientoProveedor(movimiento);

            MessageBox.Show("jeje");

            Controles_Inicio();
            DescartarCambios();
        }

        private void btnDescartar_Click(object sender, EventArgs e)
        {
            DescartarCambios();
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProveedor.SelectedItem != null)
            {
                Controles_ProveedorSeleccionado();
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {

        }

        private void dgvContenido_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvContenido.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dgvContenido.SelectedRows[0];

                if (row.Cells["cProducto"].Value.ToString() != "")
                {
                    Producto producto = new Producto() { Id = extras.GetId(row.Cells["cProducto"].Value.ToString()) };
                    PrecioProducto precio = extras.GetProducto_UltimoPrecio(producto);

                    bool hayprecio = bool.Parse(row.Cells["cHayPrecio"].Value.ToString());

                    decimal precioUnitario = 0;

                    if (precio != null)
                    {
                        if (!hayprecio)
                        {
                            precioUnitario = precio.Precio;
                            row.Cells["cPrecioUnitario"].Value = decimal.Round(precioUnitario, 2);
                            row.Cells["cAlicuotaIva"].Value = precio.Iva;
                            row.Cells["cHayPrecio"].Value = "true";
                        }
                    }
                    else
                    {
                        if (!hayprecio)
                        {
                            precio = new PrecioProducto();

                            precioUnitario = 0;
                            row.Cells["cPrecioUnitario"].Value = decimal.Round(precioUnitario, 2);

                            precio.Iva = 0.21m;


                            row.Cells["cHayPrecio"].Value = "true";
                        }
                        else
                        {
                            decimal.TryParse(row.Cells["cPrecioUnitario"].Value.ToString(), out precioUnitario);
                        }
                        
                    }

                    decimal cantidad = 0;
                    decimal.TryParse(row.Cells["cCantidad"].Value.ToString(), out cantidad);
                    
                    decimal subtotal = decimal.Round(cantidad * precioUnitario, 2);

                    row.Cells["cSubtotal"].Value = subtotal;

                    decimal alicuotaIva = 0.21m;
                    decimal.TryParse(row.Cells["cAlicuotaIva"].Value.ToString(), out alicuotaIva);
                    //row.Cells["cAlicuotaIva"].Value = precio.Iva;

                    decimal iva = decimal.Round((subtotal * alicuotaIva), 2);
                    row.Cells["cIVA"].Value = iva;

                    row.Cells["cTotal"].Value = (subtotal + iva);

                    //if (ultimoPrecio <= 0)
                    //{
                    //    row.Cells["cPrecioUnitario"].Value = decimal.Round(0, 2);
                    //    row.Cells["cSubtotal"].Value = decimal.Round(0, 2);
                    //    row.Cells["cAlicuotaIva"].Value = decimal.Round(21, 2);
                    //    row.Cells["cIVA"].Value = decimal.Round(0, 2);
                    //    row.Cells["cTotal"].Value = decimal.Round(0, 2);
                    //}


                    txtTotalSinIva.Text = row.Cells["cSubtotal"].Value.ToString();
                    txtTotalConIva.Text = row.Cells["cTotal"].Value.ToString();


                }
            }
        }

        private void dgvContenido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Controles_Inicio()
        {
            btnNew.Enabled = true;
            btnVerFacturas.Enabled = true;
            btnConfirmar.Enabled = false;
            btnVolver.Enabled = false;

            cmbProveedor.Enabled = false;
            txtOc.ReadOnly = true;
            dtpFechaEmision.Enabled = false;
            dtpFechaVencimiento.Enabled = false;
            cmbTipoDocumento.Enabled = false;
            txtNumero.ReadOnly = true;
            txtObservaciones.ReadOnly = true;

            dgvContenido.Enabled = false;
            btnAgregarLinea.Enabled = false;
            btnQuitarLinea.Enabled = false;

            dgvFacturas.Enabled = true;
        }
        private void Controles_Nuevo()
        {
            btnNew.Enabled = false;
            btnVerFacturas.Enabled = false;
            btnConfirmar.Enabled = false;
            btnVolver.Enabled = true;

            cmbProveedor.Enabled = true;
            txtOc.ReadOnly = true;
            dtpFechaEmision.Enabled = true;
            dtpFechaVencimiento.Enabled = true;
            cmbTipoDocumento.Enabled = true;
            txtNumero.ReadOnly = false;
            txtObservaciones.ReadOnly = false;

            dgvContenido.Enabled = false;
            btnAgregarLinea.Enabled = true;
            btnQuitarLinea.Enabled = true;

            dgvFacturas.Enabled = false;

        }
        private void Controles_ProveedorSeleccionado()
        {
            btnNew.Enabled = false;
            btnVerFacturas.Enabled = false;
            btnConfirmar.Enabled = true;
            btnVolver.Enabled = true;

            cmbProveedor.Enabled = true;
            txtOc.ReadOnly = true;
            dtpFechaEmision.Enabled = true;
            dtpFechaVencimiento.Enabled = true;
            cmbTipoDocumento.Enabled = true;
            txtNumero.ReadOnly = false;
            txtObservaciones.ReadOnly = false;

            dgvContenido.Enabled = true;
            btnAgregarLinea.Enabled = true;
            btnQuitarLinea.Enabled = true;

            dgvFacturas.Enabled = false;
        }

        public void DescartarCambios()
        {
            txtNumero.Text = "";
            txtObservaciones.Text = "";

            dgvContenido.DataSource = null;

            if (dgvContenido.Rows.Count != 0)
            {
                dgvContenido.Rows.Clear();
            }

            txtTotalConIva.Text = "";
            txtTotalSinIva.Text = "";
        }

        private void dtpFechaEmision_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaVencimiento.Value = dtpFechaEmision.Value.AddDays(15);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Controles_Nuevo();

            lblBarra1.Location = new Point(60, 50);

            dgvFacturas.Location = new Point(21, 504);
            dgvFacturas.Height = 211;
            dgvFacturas.Width = 858;

            List<Proveedor> list = extras.GetProveedores();

            cmbProveedor.Items.Clear();

            foreach (Proveedor proveedor in list)
            {
                cmbProveedor.Items.Add(proveedor.Id + ". " + proveedor.Nombre);
            }

            txtObservaciones.Text = "N/A";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dgvFacturas.Location = new Point(21, 62);
            dgvFacturas.Height = 653;
            dgvFacturas.Width = 858;

            lblBarra1.Location = new Point(235, 50);

            btnVolver.Enabled = true;
                //21, 62    s858, 653
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            DescartarCambios();
            Controles_Inicio();

            dgvFacturas.Location = new Point(21, 504);
            dgvFacturas.Height = 211;
            dgvFacturas.Width = 858;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //chequeos
            if (!extras.CkConfirmacion("ingresar esta nueva factura"))
                return;

            decimal importeNeto = decimal.Parse(txtTotalSinIva.Text);
            decimal importeTotal = decimal.Parse(txtTotalConIva.Text);


            Factura factura = new Factura()
            {
                Id = extras.GetFactura_Id() + 1,
                CompraVenta = "COMPRA",
                IdEmisor = extras.GetId(cmbProveedor.SelectedItem.ToString()),
                IdDestinatario = 0,
                FechaEmision = dtpFechaEmision.Value.ToString("yyyy-MM-dd"),
                FechaVencimiento = dtpFechaVencimiento.Value.ToString("yyyy-MM-dd"),
                Numero = txtNumero.Text,
                ImporteNeto = importeNeto,
                ImporteTotal = importeTotal,
                Estado = "ABIERTO",
                Observaciones = txtObservaciones.Text,
                Iva = (importeTotal - importeNeto)
            };

            List<LineaFactura> list = new List<LineaFactura>();

            foreach (DataGridViewRow row in dgvContenido.Rows)
            {

                LineaFactura linea = new LineaFactura()
                {
                    Id = extras.GetLineaFactura_Id() + 1,
                    IdFactura = factura.Id,
                    IdProducto = extras.GetId(row.Cells["cProducto"].Value.ToString()),
                    Cantidad = decimal.Parse(row.Cells["cCantidad"].Value.ToString()),
                    PrecioUnitario = decimal.Parse(row.Cells["cPrecioUnitario"].Value.ToString()),
                    Subtotal = decimal.Parse(row.Cells["cSubtotal"].Value.ToString()),
                    AlicuotaIva = decimal.Parse(row.Cells["cAlicuotaIva"].Value.ToString()),
                    Total = decimal.Parse(row.Cells["cTotal"].Value.ToString()),
                    Estado = "ABIERTO"
                };

                list.Add(linea);

            }

            MovimientoProveedor movimiento = new MovimientoProveedor()
            {
                Id = extras.GetMovimientoProveedor_Id() + 1,
                IdProveedor = extras.GetId(cmbProveedor.SelectedItem.ToString()),
                CreditoDebito = "DEBITO",
                Fecha = dtpFechaEmision.Value.ToString("yyyy-MM-dd"),
                TipoDocumento = cmbTipoDocumento.SelectedItem.ToString(),
                NumDocumento = txtNumero.Text,
                Monto = decimal.Parse(txtTotalConIva.Text),
                Observaciones = txtObservaciones.Text

            };

            extras.AddFactura(factura);
            extras.AddLineaFactura(list);
            extras.AddMovimientoProveedor(movimiento);

            MessageBox.Show("La Factura " + txtNumero.Text + " fue ingresada correctamente.");

            SetTable_Facturas();

            Controles_Inicio();
            DescartarCambios();
        }

        private void lblBarra1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarLinea_Click(object sender, EventArgs e)
        {
            if (cmbProveedor.SelectedItem == null)
            {
                return;
            }

            Proveedor proveedor = new Proveedor() { Id = extras.GetId(cmbProveedor.SelectedItem.ToString()) };
            proveedor = extras.GetProveedor(proveedor);

            List<Producto> listaProductos = extras.GetProductos(proveedor);

            int iFila = dgvContenido.Rows.Add();

            DataGridViewRow row = dgvContenido.Rows[iFila];

            var cProducto = row.Cells["cProducto"] as DataGridViewComboBoxCell;

            foreach (Producto p in listaProductos)
            {
                cProducto.Items.Add(p.Id + ". " + p.Nombre);
            }

            row.Cells["cCantidad"].Value = decimal.Round(0, 2);
            row.Cells["cPrecioUnitario"].Value = decimal.Round(0, 2);
            row.Cells["cSubtotal"].Value = decimal.Round(0, 2);
            row.Cells["cAlicuotaIva"].Value = decimal.Round(0.21m, 2);
            row.Cells["cIVA"].Value = decimal.Round(0, 2);
            row.Cells["cTotal"].Value = decimal.Round(0, 2);
            row.Cells["cHayPrecio"].Value = "false";

        }

        

        private void btnQuitarLinea_Click(object sender, EventArgs e)
        {

        }
    }
}
