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
    public partial class UcProductos_Recibir : UserControl
    {
        private static UcProductos_Recibir _instance;

        private Extras extras = new Extras();

        public static UcProductos_Recibir Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcProductos_Recibir();
                }

                return _instance;
            }

        }
        public UcProductos_Recibir()
        {
            InitializeComponent();
        }

        private void UcCompras_Recibir_Load(object sender, EventArgs e)
        {
            Controles_Inicio();

            lblBarra1.Visible = false;

            List<Proveedor> listaProveedores = extras.GetProveedores();
            foreach(Proveedor proveedor in listaProveedores)
            {
                cmbProveedores.Items.Add(proveedor.Id + ". " + proveedor.Nombre);
            }

            //cmbProveedores.SelectedIndex = 0;

            dtpFechaEntrega.Value = DateTime.Today;


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Controles_Nuevo();


        }

        private void SetTable_Ordenes(List<OrdenDeCompra> lista)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", Type.GetType("System.Int16"));
            dt.Columns.Add("Fecha Creación", Type.GetType("System.String"));
            dt.Columns.Add("Fecha Entrega", Type.GetType("System.String"));
            dt.Columns.Add("Estado", Type.GetType("System.String"));

            foreach (OrdenDeCompra orden in lista)
            {
                dt.Rows.Add(orden.Id, orden.FechaCreacion, orden.FechaEntrega, orden.Estado);
            }

            dgvOrdenes.DataSource = dt;

            dgvOrdenes.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvOrdenes.Columns["Fecha Creación"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvOrdenes.Columns["Fecha Entrega"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvOrdenes.Columns["Estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void SetTable_LineasOrden(List<LineaOrdenDeCompra> lista)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", Type.GetType("System.Int16"));
            dt.Columns.Add("IdProducto", Type.GetType("System.Int16"));
            dt.Columns.Add("Producto", Type.GetType("System.String"));
            dt.Columns.Add("Cantidad Pedida", Type.GetType("System.Decimal"));
            dt.Columns.Add("Cantidad Recibida", Type.GetType("System.Decimal"));
            dt.Columns.Add("Estado", Type.GetType("System.String"));

            foreach (LineaOrdenDeCompra orden in lista)
            {
                Producto producto = extras.GetProducto(new Producto() { Id = orden.IdProducto });
                dt.Rows.Add(orden.Id, orden.IdProducto, producto.Nombre, orden.CantidadPedida, orden.CantidadEntregada, orden.Estado);
            }

            dgvContenido.DataSource = dt;

            dgvContenido.Columns["Id"].Visible = false;
            dgvContenido.Columns["IdProducto"].Visible = false;
            dgvContenido.Columns["Producto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvContenido.Columns["Cantidad Pedida"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvContenido.Columns["Cantidad Recibida"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvContenido.Columns["Estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void Controles_Inicio()
        {
            btnNew.Enabled = true;
            btnConfirmar.Enabled = false;
            btnVolver.Enabled = false;

            cmbProveedores.Enabled = false;
            dtpFechaEmision.Enabled = false;
            dtpFechaEntrega.Enabled = false;
            txtRemito.ReadOnly = true;
            dgvOrdenes.Enabled = false;
            btnSeleccionar.Enabled = false;
            btnIngresarCantidades.Enabled = false;


            dgvContenido.Enabled = false;
        }
        private void Controles_Nuevo()
        {
            btnNew.Enabled = false;
            btnConfirmar.Enabled = false;
            btnVolver.Enabled = true;

            cmbProveedores.Enabled = true;
            dtpFechaEmision.Enabled = true;
            dtpFechaEntrega.Enabled = true;
            txtRemito.ReadOnly = false;
            dgvOrdenes.Enabled = true;
            btnSeleccionar.Enabled = false;

            btnIngresarCantidades.Enabled = false;
            btnConfirmarCantidades.Enabled = false;

            dgvContenido.Enabled = false;
        }

        private void Controles_OCSeleccionada()
        {
            btnNew.Enabled = false;
            btnConfirmar.Enabled = false;
            btnVolver.Enabled = true;

            cmbProveedores.Enabled = true;
            dtpFechaEmision.Enabled = true;
            dtpFechaEntrega.Enabled = true;
            txtRemito.ReadOnly = false;
            dgvOrdenes.Enabled = false;
            btnSeleccionar.Enabled = false;

            btnIngresarCantidades.Enabled = true;
            btnConfirmarCantidades.Enabled = false;

            dgvContenido.Enabled = false;
        }

        private void Controles_IngresoCantidades()
        {
            btnNew.Enabled = false;
            btnConfirmar.Enabled = false;
            btnVolver.Enabled = true;

            cmbProveedores.Enabled = true;
            dtpFechaEmision.Enabled = true;
            dtpFechaEntrega.Enabled = true;
            txtRemito.ReadOnly = false;
            dgvOrdenes.Enabled = true;
            btnSeleccionar.Enabled = false;

            btnIngresarCantidades.Enabled = false;
            btnConfirmarCantidades.Enabled = true;

            dgvContenido.Enabled = true;
        }

        private void Controles_LimpiarSeleccion()
        {
            btnNew.Enabled = false;
            btnConfirmar.Enabled = true;
            btnVolver.Enabled = true;

            cmbProveedores.Enabled = true;
            dtpFechaEmision.Enabled = true;
            dtpFechaEntrega.Enabled = true;
            txtRemito.ReadOnly = false;
            dgvOrdenes.Enabled = true;
            btnSeleccionar.Enabled = false;

            btnConfirmarCantidades.Enabled = true;

            dgvContenido.Enabled = true;
        }

        private void Controles_ConfirmarCantidades()
        {
            btnNew.Enabled = false;
            btnConfirmar.Enabled = true;
            btnVolver.Enabled = true;

            cmbProveedores.Enabled = true;
            dtpFechaEmision.Enabled = true;
            dtpFechaEntrega.Enabled = true;
            txtRemito.ReadOnly = false;
            dgvOrdenes.Enabled = true;
            btnSeleccionar.Enabled = false;
            
            btnIngresarCantidades.Enabled = true;
            btnConfirmarCantidades.Enabled = false;

            dgvContenido.Enabled = true;
        }

        private void cmbProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<OrdenDeCompra> listaOrdenes = extras.GetOrdenesDeCompra(new Proveedor() { Id = extras.GetId(cmbProveedores.SelectedItem.ToString()) },"ABIERTA");
            SetTable_Ordenes(listaOrdenes);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Controles_OCSeleccionada();
            btnIngresarCantidades.Focus();
        }

        private void dgvOrdenes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrdenes.SelectedRows.Count != 0)
            {
                long idOrden = long.Parse(dgvOrdenes.SelectedRows[0].Cells["Id"].Value.ToString());
                List<LineaOrdenDeCompra> lineas = extras.GetLineasOrdenDeCompra(new OrdenDeCompra() { Id = idOrden }, "ABIERTA");

                SetTable_LineasOrden(lineas);

                btnSeleccionar.Enabled = true;
            }
        }

        private void btnIngresarCantidades_Click(object sender, EventArgs e)
        {
            Controles_IngresoCantidades();
            dgvContenido.Focus();
        }

        private void btnLimpiarSeleccion_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmarCantidades_Click(object sender, EventArgs e)
        {
            Controles_ConfirmarCantidades();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //chequeos
            //Actualizo estado de Orden de Compra
            OrdenDeCompra orden = new OrdenDeCompra() { Id = long.Parse(dgvOrdenes.SelectedRows[0].Cells["Id"].Value.ToString()) };
            orden = extras.GetOrdenDeCompra(orden);

            orden.Estado = "ENTREGADA";

            extras.EditOrdenDeCompra(orden);

            //Ingreso el remito/recepción

            Proveedor proveedor = new Proveedor() { Id = extras.GetId(cmbProveedores.SelectedItem.ToString()) };

            Remito remito = new Remito()
            {
                Id = extras.GetRemito_Id() + 1,
                EmisionRecepcion = "RECEPCIÓN",
                IdEmisor = proveedor.Id,
                IdDestinatario = 0,
                FechaEmision = dtpFechaEmision.Value.ToString("yyyy-MM-dd"),
                FechaEntrega = dtpFechaEntrega.Value.ToString("yyyy-MM-dd"),
                Numero = txtRemito.Text,
                Estado = "ENTREGADO",
                Observaciones = "N/A"
            };

            List<LineaRemito> lineasRemito = new List<LineaRemito>();
            long idLineaRemito = extras.GetLineaRemito_Id();

            List<MovimientoProducto> listaMovimientos = new List<MovimientoProducto>();
            long idMovimientoProducto = extras.GetMovimientoProducto_Id();

            foreach (DataGridViewRow row in dgvContenido.Rows)
            {
                idLineaRemito += 1;
                idMovimientoProducto += 1;

                Producto producto = new Producto() { Id = long.Parse(row.Cells["IdProducto"].Value.ToString()) };
                producto = extras.GetProducto(producto);

                decimal cantidadPedida = decimal.Parse(row.Cells["Cantidad Pedida"].Value.ToString());
                decimal cantidadRecibida = decimal.Parse(row.Cells["Cantidad Recibida"].Value.ToString());

                string estado = "";

                if (cantidadRecibida >= cantidadPedida)
                    estado = "RECIBIDO";
                else if (cantidadRecibida > 0 && cantidadRecibida < cantidadPedida)
                    estado = "PARCIALMENTE RECIBIDO";
                else
                    estado = "NO RECIBIDO";
                    
                LineaRemito lineaRemito = new LineaRemito()
                {
                    Id = idLineaRemito,
                    IdRemito = remito.Id,
                    IdProducto = producto.Id,
                    Cantidad = cantidadRecibida,
                    Estado = estado
                };

                lineasRemito.Add(lineaRemito);

                MovimientoProducto movimiento = new MovimientoProducto()
                {
                    Id = idMovimientoProducto,
                    IdProducto = producto.Id,
                    TipoMovimiento = "COMPRA",
                    Cantidad = cantidadRecibida,
                    Fecha = dtpFechaEntrega.Value.ToString("yyyy-MM-dd"),
                    Stock = extras.GetProducto_Stock(producto) + cantidadRecibida,
                    Observaciones = "Remito: " + remito.Numero
                };

                listaMovimientos.Add(movimiento);
            }

            extras.AddRemito(remito);
            extras.AddLineaRemito(lineasRemito);
            extras.AddMovimientoProducto(listaMovimientos);

            MessageBox.Show("Jeje");

            this.Controles_Inicio();

            dgvContenido.DataSource = new DataTable();
            dgvOrdenes.DataSource = new DataTable();

            txtRemito.Text = "";
            dtpFechaEmision.Value = DateTime.Today;
            dtpFechaEntrega.Value = DateTime.Today;

            cmbProveedores.SelectedIndex = 0;
            

            //Actualizo stock de articulos
        }

        private void btnDescartar_Click(object sender, EventArgs e)
        {

        }

        public void DescartarCambios()
        {
            txtRemito.Text = "";
            Controles_Inicio();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //chequeos

            if (!extras.CkConfirmacion("registrar la recepción de esta Orden de Compra"))
                return;

            //Actualizo estado de Orden de Compra
            OrdenDeCompra orden = new OrdenDeCompra() { Id = long.Parse(dgvOrdenes.SelectedRows[0].Cells["Id"].Value.ToString()) };
            orden = extras.GetOrdenDeCompra(orden);
            orden.Estado = "CERRADA";

            List<LineaOrdenDeCompra> lineasOC = extras.GetLineasOrdenDeCompra(orden);

            foreach(LineaOrdenDeCompra linea in lineasOC)
            {
                if (linea.Estado == "ABIERTA")
                    orden.Estado = "ABIERTA";

            }
            
            extras.EditOrdenDeCompra(orden);

            //Ingreso el remito/recepción

            Proveedor proveedor = new Proveedor() { Id = extras.GetId(cmbProveedores.SelectedItem.ToString()) };

            Remito remito = new Remito()
            {
                Id = extras.GetRemito_Id() + 1,
                EmisionRecepcion = "RECEPCIÓN",
                IdEmisor = proveedor.Id,
                IdDestinatario = 0,
                FechaEmision = dtpFechaEmision.Value.ToString("yyyy-MM-dd"),
                FechaEntrega = dtpFechaEntrega.Value.ToString("yyyy-MM-dd"),
                Numero = txtRemito.Text,
                Estado = "ENTREGADO",
                Observaciones = "N/A"
            };

            List<LineaRemito> lineasRemito = new List<LineaRemito>();
            long idLineaRemito = extras.GetLineaRemito_Id();

            List<MovimientoProducto> listaMovimientos = new List<MovimientoProducto>();
            long idMovimientoProducto = extras.GetMovimientoProducto_Id();

            foreach (DataGridViewRow row in dgvContenido.Rows)
            {
                idLineaRemito += 1;
                idMovimientoProducto += 1;

                Producto producto = new Producto() { Id = long.Parse(row.Cells["IdProducto"].Value.ToString()) };
                producto = extras.GetProducto(producto);

                decimal cantidadPedida = decimal.Parse(row.Cells["Cantidad Pedida"].Value.ToString());
                decimal cantidadRecibida = decimal.Parse(row.Cells["Cantidad Recibida"].Value.ToString());

                string estado = "";

                if (cantidadRecibida >= cantidadPedida)
                    estado = "RECIBIDO";
                else if (cantidadRecibida > 0 && cantidadRecibida < cantidadPedida)
                    estado = "PARCIALMENTE RECIBIDO";
                else
                    estado = "NO RECIBIDO";

                LineaRemito lineaRemito = new LineaRemito()
                {
                    Id = idLineaRemito,
                    IdRemito = remito.Id,
                    IdProducto = producto.Id,
                    Cantidad = cantidadRecibida,
                    Estado = estado
                };

                lineasRemito.Add(lineaRemito);

                MovimientoProducto movimiento = new MovimientoProducto()
                {
                    Id = idMovimientoProducto,
                    IdProducto = producto.Id,
                    TipoMovimiento = "COMPRA",
                    Cantidad = cantidadRecibida,
                    Fecha = dtpFechaEntrega.Value.ToString("yyyy-MM-dd"),
                    Stock = extras.GetProducto_Stock(producto) + cantidadRecibida,
                    Observaciones = "Remito: " + remito.Numero
                };

                listaMovimientos.Add(movimiento);
            }

            extras.AddRemito(remito);
            extras.AddLineaRemito(lineasRemito);
            extras.AddMovimientoProducto(listaMovimientos);

            MessageBox.Show("Jeje");

            this.Controles_Inicio();

            dgvContenido.DataSource = new DataTable();
            dgvOrdenes.DataSource = new DataTable();

            txtRemito.Text = "";
            dtpFechaEmision.Value = DateTime.Today;
            dtpFechaEntrega.Value = DateTime.Today;

            cmbProveedores.SelectedIndex = 0;


            //Actualizo stock de articulos
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Controles_Nuevo();
        }
    }
}
