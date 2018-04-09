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
using System.Data.Entity;

namespace Working_Org
{
    public partial class UcCompras_OrdenDeCompra : UserControl
    {
        private static UcCompras_OrdenDeCompra _instance;

        private Extras extras = new Extras();

        private bool _isNuevaCompra;
        private bool _isEdicionCompra;

        /// <summary>
        /// 
        /// </summary>
        public static UcCompras_OrdenDeCompra Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcCompras_OrdenDeCompra();
                }

                return _instance;
            }
        }

        public UcCompras_OrdenDeCompra()
        {
            InitializeComponent();
        }

        private void UcCompras_Load(object sender, EventArgs e)
        {
            Controles_Inicio();
            SetTable_Compras();

        }

        private void btnNuevaCompra_Click(object sender, EventArgs e)
        {
            Controles_Nuevo();

            _isNuevaCompra = true;

            cmbProveedor.Enabled = true;
            cmbProveedor.Items.Clear();
            txtOc.Enabled = true;
            //txtOc.Text = GenerateOC().ToString();
            dtpFechaApertura.Enabled = true;
            dtpFechaCierre.Enabled = true;
            txtObservaciones.Enabled = true;

            dtpFechaCierre.Value = dtpFechaApertura.Value.AddDays(15);

            List<Proveedor> listaProveedores = extras.GetProveedores("SERVICIOS", true);
            foreach (Proveedor proveedor in listaProveedores)
            {
                cmbProveedor.Items.Add(proveedor.Id + ". " + proveedor.Nombre);
            }

            //GetProductos();

            //if (_listaProductos.Count != 0)
            //{
            //    foreach (Producto producto in _listaProductos)
            //    {
            //        cmbProducto1.Items.Add(producto.Id + ". " + producto.Nombre);
            //        cmbProducto2.Items.Add(producto.Id + ". " + producto.Nombre);
            //        cmbProducto3.Items.Add(producto.Id + ". " + producto.Nombre);
            //    }
            //}

            //txtCantidadSolicitada1.Enabled = true;
            
        }

        private void btnEditarOrden_Click(object sender, EventArgs e)
        {
            _isEdicionCompra = true;
        }

        private void btnEnviarOrden_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            //chequeos
            OrdenDeCompra orden = new OrdenDeCompra()
            {
                Id = extras.GetOrdenDeCompra_Id() + 1,
                IdProveedor = extras.GetId(cmbProveedor.SelectedItem.ToString()),
                IdPresupuesto = 0,
                FechaCreacion = dtpFechaApertura.Value.ToString("yyyy-MM-dd"),
                FechaEntrega = dtpFechaCierre.Value.ToString("yyyy-MM-dd"),
                Estado = "ABIERTA",
                Observaciones = txtObservaciones.Text
            };

            long idLinea = extras.GetLineaOrdenDeCompra_Id();
            List<LineaOrdenDeCompra> listaLineas = new List<LineaOrdenDeCompra>();

            foreach (DataGridViewRow row in dgvContenido.Rows)
            {
                idLinea += 1;

                LineaOrdenDeCompra linea = new LineaOrdenDeCompra()
                {
                    Id = idLinea,
                    IdOrden = orden.Id,
                    IdProducto = extras.GetId(row.Cells["cProducto"].Value.ToString()),
                    CantidadPedida = decimal.Parse(row.Cells["cCantidadPedida"].Value.ToString()),
                    CantidadEntregada = decimal.Parse(row.Cells["cCantidadEntregada"].Value.ToString()),
                    Estado = "ABIERTA",
                    Observaciones = "N/A"
                };

                listaLineas.Add(linea);
            }

            extras.AddOrdenDeCompra(orden);
            extras.AddLineaOrdenDeCompra(listaLineas);

            
            SetTable_Compras();

            DescartarCambios();
            Controles_Inicio();
        }

        private void btnDescartarCambios_Click(object sender, EventArgs e)
        {
            DescartarCambios();
        }


        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor() { Id = extras.GetId(cmbProveedor.SelectedItem.ToString()) };
            proveedor = extras.GetProveedor(proveedor);


            //long idProveedor = GetId_FromText(cmbProveedor.SelectedItem.ToString());

            //foreach (Proveedor proveedor in _listaProveedores)
            //{
            //    if (proveedor.Id == idProveedor)
            //    {
            //        _proveedorSeleccionado = proveedor;
            //    }
            //}

            if (_isNuevaCompra)
            {
                txtOc.Text = "";
            }

            List<Producto> listaProductos = extras.GetProductos(proveedor);



            //GetProductos(this._proveedorSeleccionado);

            //if (this._listaProductosProveedor.Count != 0)
            //{
            //    cmbProducto1.Items.Clear();

            //    foreach (ProductoProveedor pp in this._listaProductosProveedor)
            //    {
            //        foreach (Producto prod in this._listaProductos)
            //        {
            //            if (pp.IdProducto == prod.Id)
            //            {
            //                cmbProducto1.Items.Add(prod.Id + ". " + prod.Nombre);
            //            }
            //        }
            //    }

            //    cmbProducto1.SelectedIndex = 0;
            //}

        }


        private void cmbProducto1_SelectedIndexChanged(object sender, EventArgs e) { }



        private void dgvCompras_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }


        #region FUNCTIONS

        private void SetTable_Compras()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", Type.GetType("System.Int16"));
            dt.Columns.Add("Proveedor", Type.GetType("System.String"));
            dt.Columns.Add("Fecha Creación", Type.GetType("System.String"));
            dt.Columns.Add("Fecha Entrega", Type.GetType("System.String"));
            dt.Columns.Add("Estado", Type.GetType("System.String"));

            List<OrdenDeCompra> listaOrdenes = extras.GetOrdenesDeCompra();

            foreach (OrdenDeCompra orden in listaOrdenes)
            {
                Proveedor proveedor = new Proveedor() { Id = orden.IdProveedor };
                proveedor = extras.GetProveedor(proveedor);

                dt.Rows.Add(orden.Id, proveedor.Nombre, orden.FechaCreacion, orden.FechaEntrega, orden.Estado);
            }

            dgvCompras.DataSource = dt;

            dgvCompras.Columns["Id"].Visible = false;
            dgvCompras.Columns["Proveedor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCompras.Columns["Fecha Creación"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCompras.Columns["Fecha Entrega"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCompras.Columns["Estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void SetTable_Compras(Proveedor proveedor)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", Type.GetType("System.Int16"));
            dt.Columns.Add("Proveedor", Type.GetType("System.String"));
            dt.Columns.Add("Fecha Creación", Type.GetType("System.String"));
            dt.Columns.Add("Fecha Entrega", Type.GetType("System.String"));
            dt.Columns.Add("Estado", Type.GetType("System.String"));

            List<OrdenDeCompra> listaOrdenes = extras.GetOrdenesDeCompra(proveedor);
            
            foreach (OrdenDeCompra orden in listaOrdenes)
            {
                dt.Rows.Add(orden.Id, proveedor.Nombre, orden.FechaCreacion, orden.FechaEntrega, orden.Estado);    
            }

            dgvCompras.DataSource = dt;

            dgvCompras.Columns["Id"].Visible = false;
            dgvCompras.Columns["Proveedor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCompras.Columns["Fecha Creación"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCompras.Columns["Fecha Entrega"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCompras.Columns["Estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //GetCompras();

            //if (_listaCompras.Count != 0)
            //{
            //    foreach (Compra compra in _listaCompras)
            //    {
            //        string nombreProveedor = GetProveedor_Nombre(compra.IdProveedor);
            //        dt.Rows.Add(compra.Id, nombreProveedor, compra.Oc, compra.FechaApertura, compra.FechaCierre, compra.Estado);
            //    }

            //    dgvCompras.DataSource = dt;

            //    dgvCompras.Columns["Id"].Visible = false;
            //    dgvCompras.Columns["Proveedor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //    dgvCompras.Columns["Orden de Compra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvCompras.Columns["Fecha Apertura"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvCompras.Columns["Fecha Cierre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvCompras.Columns["Estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //}

            //if (listaOrdenes.Count != 0)
            //{
            //    foreach (OrdenDeCompra orden in listaOrdenes)
            //    {
            //        Proveedor proveedor = extras.GetProveedor(new Proveedor() { Id = orden.IdProveedor });
            //        dt.Rows.Add(orden.Id, proveedor.Nombre, orden.FechaCreacion, orden.FechaEntrega, orden.Estado);
            //    }

               
            //}

        }

        
        #endregion

   

        private void txtCantidadSolicitada1_TextChanged(object sender, EventArgs e)
        {
            
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
            
            foreach(Producto p in listaProductos)
            {
                cProducto.Items.Add(p.Id + ". " + p.Nombre);
            }

            row.Cells["cCantidadPedida"].Value = 0;
            row.Cells["cCantidadEntregada"].Value = 0;
            
        }

        private void SetTable_Contenido()
        {
            
        }

        private void dgvContenido_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvContenido.SelectedRows.Count != 0)
            {
                //string col = dgvContenido.SelectedRows[0].Cells["cProducto"].Value.ToString();
                if (dgvContenido.SelectedRows[0].Cells["cProducto"].Value.ToString() != "")
                {
                    Producto producto = new Producto() { Id = extras.GetId(dgvContenido.SelectedRows[0].Cells["cProducto"].Value.ToString()) };
                    dgvContenido.SelectedRows[0].Cells["cStockActual"].Value = extras.GetProducto_Stock(producto);
                }
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvContenido.SelectedRows.Count != 0)
            {
                int i = dgvContenido.SelectedRows[0].Index;
                dgvContenido.Rows.RemoveAt(i);
            }
        }


        private void Controles_Inicio()
        {
            btnNuevaCompra.Enabled = true;
            btnEditarOrden.Enabled = false;
            btnEnviarOrden.Enabled = false;
            btnGuardarCambios.Enabled = false;
            btnDescartarCambios.Enabled = false;

            cmbProveedor.Enabled = false;
            txtOc.ReadOnly = true;
            dtpFechaApertura.Enabled = false;
            dtpFechaCierre.Enabled = false;
            txtObservaciones.ReadOnly = true;

            dgvContenido.Enabled = false;
            btnAgregar.Enabled = false;
            btnQuitar.Enabled = false;

            dgvCompras.Enabled = true;
        }
        private void Controles_Nuevo()
        {
            btnNuevaCompra.Enabled = false;
            btnEditarOrden.Enabled = false;
            btnEnviarOrden.Enabled = false;
            btnGuardarCambios.Enabled = true;
            btnDescartarCambios.Enabled = true;

            cmbProveedor.Enabled = true;
            txtOc.ReadOnly = false;
            dtpFechaApertura.Enabled = true;
            dtpFechaCierre.Enabled = true;
            txtObservaciones.ReadOnly = false;

            dgvContenido.Enabled = true;
            btnAgregar.Enabled = true;
            btnQuitar.Enabled = true;

            dgvCompras.Enabled = false;
        }

        public void DescartarCambios()
        {
            //foreach (Control c in this.Controls)
            //{
            //    TextBox tb = c as TextBox;
            //    if (tb != null)
            //    {
            //        tb.Text = "";
            //        tb.ReadOnly = true;
            //    }
                    
                
            //}

            cmbProveedor.Enabled = false;
            txtOc.Text = "";
            txtOc.Enabled = false;
            dtpFechaApertura.Value = DateTime.Today;
            dtpFechaApertura.Enabled = false;
            dtpFechaCierre.Value = DateTime.Today;
            dtpFechaCierre.Enabled = false;
            txtObservaciones.Text = "";
            txtObservaciones.Enabled = false;

            if (dgvContenido.Rows.Count != 0)
            {
                foreach (DataGridViewRow row in dgvContenido.Rows)
                {
                    dgvContenido.Rows.Remove(row);
                }
            }

            _isNuevaCompra = false;
            _isEdicionCompra = false;
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

            row.Cells["cCantidadPedida"].Value = 0;
            row.Cells["cCantidadEntregada"].Value = 0;
        }

        private void btnQuitarLinea_Click(object sender, EventArgs e)
        {
            if (dgvContenido.SelectedRows.Count != 0)
            {
                int i = dgvContenido.SelectedRows[0].Index;
                dgvContenido.Rows.RemoveAt(i);
            }
        }
    }
}
