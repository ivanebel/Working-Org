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
using System.Globalization;

namespace Working_Org
{
    public partial class UcVentas : UserControl
    {
        private static UcVentas _instance;

        private Extras extras = new Extras();

        public static UcVentas Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcVentas();
                }

                return _instance;
            }
        }

        public UcVentas()
        {
            InitializeComponent();
        }

        private void UcVentas_Load(object sender, EventArgs e)
        {
            Controles_Inicio();

            cmbTipoDocumento.Items.Add("FACTURA A");
            cmbTipoDocumento.Items.Add("FACTURA B");
            cmbTipoDocumento.Items.Add("FACTURA C");
            cmbTipoDocumento.Items.Add("NOTA DE DÉBITO");
            cmbTipoDocumento.Items.Add("NOTA DE CRÉDITO");

            SetTable_Facturas();


        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente() { Id = extras.GetId(cmbClientes.SelectedItem.ToString()) };
            cliente = extras.GetCliente(cliente);

            List<Pedido> list = extras.GetPedidos(cliente, "ENTREGADO");

            SetTable_Pedidos(list);

            dgvPedidos.Focus();
        }

        private void dgvPedidos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnSeleccionarPedido_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count != 0)
            {
                Controles_PedidoSeleccionado();

                dgvContenido.Rows.Clear();

                long idPedido = long.Parse(dgvPedidos.SelectedRows[0].Cells["Id"].Value.ToString());
                Pedido pedido = new Pedido() { Id = idPedido };

                List<LineaPedido> list = extras.GetLineasPedido(pedido);

                decimal totalSinIva = 0;
                decimal totalConIva = 0;

                if (list.Count != 0)
                {
                    foreach(LineaPedido linea in list)
                    {
                        Producto producto = new Producto() { Id = linea.IdProducto };
                        producto = extras.GetProducto(producto);

                        PrecioProducto precio = extras.GetProducto_UltimoPrecio(producto);

                        //decimal subtotal = decimal.Round(linea.KilosPedidos * precio.Precio);
                        //decimal iva = decimal.Round(subtotal * precio.Iva, 2);

                        //dgvContenido.Rows.Add(linea.Id, producto.Id + ". " + producto.Nombre, linea.KilosPedidos, precio.Precio, subtotal, precio.Iva, iva, (subtotal + iva));

                        //totalSinIva += subtotal;
                        //totalConIva += (subtotal + iva);
                    }

                    txtTotalSinIva.Text = decimal.Round(totalSinIva, 2).ToString();
                    txtTotalConIva.Text = decimal.Round(totalConIva, 2).ToString();

                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //chequeos
            decimal importeNeto = decimal.Parse(txtTotalSinIva.Text);
            decimal importeTotal = decimal.Parse(txtTotalConIva.Text);

            Factura factura = new Factura()
            {
                Id = extras.GetFactura_Id() + 1,
                CompraVenta = "VENTA",
                IdEmisor = 0,
                IdDestinatario = extras.GetId(cmbClientes.SelectedItem.ToString()),
                FechaEmision = dtpFecha.Value.ToString("yyyy-MM-dd"),
                FechaVencimiento = dtpFecha.Value.AddDays(15).ToString("yyyy-MM-dd"),
                Numero = txtNroDocumento.Text,
                ImporteNeto = importeNeto,
                ImporteTotal = importeTotal,
                Observaciones = "",
                Iva = (importeTotal - importeNeto),
                Estado = "ABIERTO"
            };
            
            List<LineaFactura> lineasFactura = new List<LineaFactura>();

            foreach (DataGridViewRow row in dgvContenido.Rows)
            {
                decimal cantidad = decimal.Parse(row.Cells["cCantidad"].Value.ToString());
                decimal precioUnitario = decimal.Parse(row.Cells["cPrecioUnitario"].Value.ToString());
                decimal alicuota = decimal.Parse(row.Cells["cAlicuotaIva"].Value.ToString());
                decimal iva = decimal.Round((cantidad * precioUnitario) * alicuota, 2);

                LineaFactura linea = new LineaFactura()
                {
                    Id = extras.GetLineaFactura_Id() + 1,
                    IdFactura = factura.Id,
                    IdProducto = extras.GetId(row.Cells["cProducto"].Value.ToString()),
                    Cantidad = cantidad,
                    PrecioUnitario = precioUnitario,
                    Subtotal = decimal.Round(cantidad * precioUnitario, 2),
                    AlicuotaIva = alicuota,
                    Iva = iva,
                    Total = decimal.Round(cantidad * precioUnitario + iva,2),
                    Estado = "ABIERTO"
                };

                lineasFactura.Add(linea);
            }

            extras.AddFactura(factura);
            extras.AddLineaFactura(lineasFactura);

            foreach (DataGridViewRow row in dgvPedidos.SelectedRows)
            {
                long idPedido = long.Parse(row.Cells["Id"].Value.ToString());
                Pedido pedido = new Pedido() { Id = idPedido };
                pedido = extras.GetPedido(pedido);

                pedido.Estado = "FACTURADO";

                extras.EditPedido(pedido, false);
            }
            
            SetTable_Facturas();
            
        }

        
        #region FUNCTIONS

        private void SetTable_Pedidos(List<Pedido> list)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", Type.GetType("System.Int16"));
            dt.Columns.Add("Orden de Compra", Type.GetType("System.Int32"));
            dt.Columns.Add("Fecha Entrega", Type.GetType("System.String"));
            dt.Columns.Add("Entrega Parc.", Type.GetType("System.Boolean"));

            foreach (Pedido pedido in list)
            {
                bool isParcial = false;
                if (pedido.Estado != "ENTREGADO")
                    isParcial = true;

                dt.Rows.Add(pedido.Id, pedido.OC, pedido.FechaEntrega, isParcial);
            }

            dgvPedidos.DataSource = dt;

            dgvPedidos.Columns["Id"].Visible = false;
            dgvPedidos.Columns["Orden de Compra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPedidos.Columns["Fecha Entrega"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Entrega Parc."].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            
        }

        private void SetTable_Facturas()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", Type.GetType("System.Int16"));
            dt.Columns.Add("Fecha", Type.GetType("System.String"));
            dt.Columns.Add("Cliente", Type.GetType("System.String"));
            dt.Columns.Add("Documento", Type.GetType("System.String"));
            dt.Columns.Add("Monto", Type.GetType("System.Decimal"));
            dt.Columns.Add("Monto c/IVA", Type.GetType("System.Decimal"));
            dt.Columns.Add("Estado", Type.GetType("System.String"));

            List<Factura> list = extras.GetFacturas("VENTA");

            if (list.Count != 0)
            {
                foreach (Factura factura in list)
                {
                    Cliente cliente = new Cliente() { Id = factura.IdDestinatario };
                    cliente = extras.GetCliente(cliente);
                    
                    dt.Rows.Add(factura.Id, factura.FechaEmision, cliente.Id + ". " + cliente.Nombre, "FA " + factura.Numero, factura.ImporteNeto, factura.ImporteTotal, factura.Estado);
                }
            }

            dgvVentas.DataSource = dt;

            dgvVentas.Columns["Id"].Visible = false;
            dgvVentas.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvVentas.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvVentas.Columns["Documento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvVentas.Columns["Monto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvVentas.Columns["Monto c/IVA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvVentas.Columns["Estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }

        

        private void Controles_Inicio()
        {
            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnGuardar.Enabled = false;
            btnDescartar.Enabled = false;

            cmbClientes.Enabled = false;
            dtpFecha.Enabled = false;
            cmbTipoDocumento.Enabled = false;
            txtNroDocumento.Enabled = false;
            dgvPedidos.Enabled = false;
            btnSeleccionarPedido.Enabled = false;

           // tableLayoutPanel1.Enabled = false;

            btnConfirmar.Enabled = false;

            dgvVentas.Enabled = true;
        }

        private void Controles_Nuevo()
        {
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGuardar.Enabled = true;
            btnDescartar.Enabled = true;

            cmbClientes.Enabled = true;
            dtpFecha.Enabled = true;
            cmbTipoDocumento.Enabled = true;
            txtNroDocumento.Enabled = true;
            dgvPedidos.Enabled = true;
            btnSeleccionarPedido.Enabled = true;

            //tableLayoutPanel1.Enabled = false;

            btnConfirmar.Enabled = false;

            dgvVentas.Enabled = false;
        }

        private void Controles_PedidoSeleccionado()
        {
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGuardar.Enabled = true;
            btnDescartar.Enabled = true;

            cmbClientes.Enabled = false;
            dtpFecha.Enabled = true;
            cmbTipoDocumento.Enabled = true;
            txtNroDocumento.Enabled = true;
            dgvPedidos.Enabled = true;
            btnSeleccionarPedido.Enabled = true;

            //tableLayoutPanel1.Enabled = true;

            btnConfirmar.Enabled = true;

            dgvVentas.Enabled = false;
        }


        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            List<Producto> listaProductos = extras.GetProductos("VENTA", false);
            int iFila = dgvContenido.Rows.Add();

            DataGridViewRow row = dgvContenido.Rows[iFila];

            var cProducto = row.Cells["cProducto"] as DataGridViewComboBoxCell;

            foreach (Producto p in listaProductos)
            {
                cProducto.Items.Add(p.Id + ". " + p.Nombre);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            Controles_Nuevo();

            cmbClientes.Items.Clear();

            List<Cliente> listaClientes = extras.GetClientes();
            foreach (Cliente cliente in listaClientes)
            {
                cmbClientes.Items.Add(cliente.Id + ". " + cliente.Nombre);
            }

            cmbTipoDocumento.SelectedIndex = 0;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //chequeos
            decimal importeNeto = decimal.Parse(txtTotalSinIva.Text);
            decimal importeTotal = decimal.Parse(txtTotalConIva.Text);

            Factura factura = new Factura()
            {
                Id = extras.GetFactura_Id() + 1,
                CompraVenta = "VENTA",
                IdEmisor = 0,
                IdDestinatario = extras.GetId(cmbClientes.SelectedItem.ToString()),
                FechaEmision = dtpFecha.Value.ToString("yyyy-MM-dd"),
                FechaVencimiento = dtpFecha.Value.AddDays(15).ToString("yyyy-MM-dd"),
                Numero = txtNroDocumento.Text,
                ImporteNeto = importeNeto,
                ImporteTotal = importeTotal,
                Observaciones = "",
                Iva = (importeTotal - importeNeto),
                Estado = "ABIERTO"
            };

            List<LineaFactura> lineasFactura = new List<LineaFactura>();

            foreach (DataGridViewRow row in dgvContenido.Rows)
            {
                decimal cantidad = decimal.Parse(row.Cells["cCantidad"].Value.ToString());
                decimal precioUnitario = decimal.Parse(row.Cells["cPrecioUnitario"].Value.ToString());
                decimal alicuota = decimal.Parse(row.Cells["cAlicuotaIva"].Value.ToString());
                decimal iva = decimal.Round((cantidad * precioUnitario) * alicuota, 2);

                LineaFactura linea = new LineaFactura()
                {
                    Id = extras.GetLineaFactura_Id() + 1,
                    IdFactura = factura.Id,
                    IdProducto = extras.GetId(row.Cells["cProducto"].Value.ToString()),
                    Cantidad = cantidad,
                    PrecioUnitario = precioUnitario,
                    Subtotal = decimal.Round(cantidad * precioUnitario, 2),
                    AlicuotaIva = alicuota,
                    Iva = iva,
                    Total = decimal.Round(cantidad * precioUnitario + iva, 2),
                    Estado = "ABIERTO"
                };

                lineasFactura.Add(linea);
            }

            extras.AddFactura(factura);
            extras.AddLineaFactura(lineasFactura);

            foreach (DataGridViewRow row in dgvPedidos.SelectedRows)
            {
                long idPedido = long.Parse(row.Cells["Id"].Value.ToString());
                Pedido pedido = new Pedido() { Id = idPedido };
                pedido = extras.GetPedido(pedido);

                pedido.Estado = "FACTURADO";

                extras.EditPedido(pedido, false);
            }

            SetTable_Facturas();
        }

        private void btnDescartar_Click(object sender, EventArgs e)
        {

        }
    }
}
