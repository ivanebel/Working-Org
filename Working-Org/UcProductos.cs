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
    public partial class UcProductos : UserControl
    {
        private static UcProductos _instance;

        private IList<Producto> _listaProductos = new List<Producto>();

        private Producto _productoSeleccionado;
        private Extras extras = new Extras();

        public static UcProductos Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcProductos();
                }

                return _instance;
            }
        }

        


        public UcProductos()
        {
            InitializeComponent();
        }

        private void UcProductos_Load(object sender, EventArgs e)
        {
            Controles_Inicio();

            SetTable_Productos();

            
        }



        #region DATABASE

        private void GetProductos()
        {
            using (var db = new proveedorEntities())
            {
                _listaProductos = (from producto in db.Productoes
                                        select producto).ToList();

                db.Dispose();
            }
        }

        private long GetProductos_LastId()
        {
            long id = 0;

            using (var db = new proveedorEntities())
            {
                try
                {
                    if (db.Productoes.Count() != 0)
                    {
                        id = db.Productoes.Max(c => c.Id);
                    }

                    db.Dispose();

                    return id;
                }
                catch (EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }

        private void SaveProducto(Producto producto, bool isEdit)
        {
            using (var db = new proveedorEntities())
            {
                if (isEdit)
                {
                    Producto oProducto = (from p in db.Productoes
                                          where p.Id == producto.Id
                                          select producto).SingleOrDefault();

                    oProducto = producto;

                }
                else
                {
                    db.Productoes.Add(producto);
                }

                db.SaveChanges();
                db.Dispose();
            }
        }


        #endregion


        #region FUNCTIONS

        private void SetTable_Productos()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", Type.GetType("System.Int16"));
            dt.Columns.Add("Nombre", Type.GetType("System.String"));
            //_dataTable.Columns.Add("Descripción", Type.GetType("System.String"));
            dt.Columns.Add("Tipo", Type.GetType("System.String"));
            dt.Columns.Add("U. de Medida", Type.GetType("System.String"));
            //dt.Columns.Add("Presentación", Type.GetType("System.String"));
            //dt.Columns.Add("Stock Mín.", Type.GetType("System.Decimal"));
            //dt.Columns.Add("Stock Máx.", Type.GetType("System.Decimal"));

            List<Producto> list = extras.GetProductos();

            if (list.Count != 0)
            {
                foreach (Producto producto in list)
                {
                   dt.Rows.Add(producto.Id, producto.Nombre, producto.TipoProducto, producto.UnidadDeMedida); //, producto.StockMin, producto.StockMax);
                }

                dgvProductos.DataSource = dt;

                dgvProductos.Columns["Id"].Visible = false;

                dgvProductos.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvProductos.Columns["Nombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvProductos.Columns["Nombre"].DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft };
                //dgvProductos.Columns["Descripción"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvProductos.Columns["Tipo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dgvProductos.Columns["Tipo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dgvProductos.Columns["Tipo"].DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight };
                dgvProductos.Columns["U. de Medida"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dgvProductos.Columns["Presentación"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dgvProductos.Columns["Stock Mín."].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dgvProductos.Columns["Stock Máx."].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //dgvProductos.Columns["U. de Medida"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvProductos.Focus();
            }
        }

        private void Controles_Inicio()
        {
            btnNuevoProducto.Enabled = true;
            btnEditarProducto.Enabled = false;
            btnGuardarCambios.Enabled = false;
            btnDescartarCambios.Enabled = false;

            txtNombre.ReadOnly = true;
            txtDescripcion.ReadOnly = true;
            cmbTipo.Enabled = false;
            cmbUnidad.Enabled = false;
            txtPresentacion.ReadOnly = true;

            txtStockMaximo.ReadOnly = true;
            txtStockMinimo.ReadOnly = true;
            txtStockOptimo.ReadOnly = true;
            txtStockActual.ReadOnly = true;

            txtPrecioUnitario.ReadOnly = true;
            txtAlicuotaIva.ReadOnly = true;
            txtTotal.ReadOnly = true;

            dgvProductos.Enabled = true;
        }

        private void Controles_Nuevo()
        {
            btnNuevoProducto.Enabled = false;
            btnEditarProducto.Enabled = false;
            btnGuardarCambios.Enabled = true;
            btnDescartarCambios.Enabled = true;

            txtNombre.ReadOnly = false;
            txtDescripcion.ReadOnly = false;
            cmbTipo.Enabled = true;
            cmbUnidad.Enabled = true;
            txtPresentacion.ReadOnly = false;

            txtStockMaximo.Enabled = true;
            txtStockMinimo.Enabled = true;
            txtStockOptimo.Enabled = true;
            txtStockActual.Enabled = true;

            txtPrecioUnitario.ReadOnly = true;
            txtAlicuotaIva.ReadOnly = true;
            txtTotal.ReadOnly = true;

            dgvProductos.Enabled = false;
        }

        #endregion

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            Controles_Nuevo();

            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPresentacion.Text = "";
            txtStockOptimo.Text = "0";
            txtStockMaximo.Text = "0";
            txtStockMinimo.Text = "0";
            txtStockActual.Text = "0";
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            //chequeos


            Producto producto = new Producto()
            {
                Id = GetProductos_LastId() + 1,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                UnidadDeMedida = cmbUnidad.SelectedItem.ToString(),
                TipoProducto = cmbTipo.SelectedItem.ToString(),
                StockMinimo = decimal.Parse(txtStockMinimo.Text),
                StockMaximo = decimal.Parse(txtStockMaximo.Text)
            };

            SaveProducto(producto, false);

            SetTable_Productos();
        }

        private void dgvProductos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.SelectedRows.Count != 0)
            {
                long idProducto = long.Parse(dgvProductos.SelectedRows[0].Cells["Id"].Value.ToString());
                Producto producto = new Producto() { Id = idProducto };
                producto = extras.GetProducto(producto);

                txtNombre.Text = producto.Nombre;
                txtDescripcion.Text = producto.Descripcion;
                cmbTipo.Text = producto.TipoProducto;
                cmbUnidad.Text = producto.UnidadDeMedida;
                txtStockMinimo.Text = producto.StockMinimo.ToString();
                txtStockMaximo.Text = producto.StockMaximo.ToString();

                decimal stockActual = extras.GetProducto_Stock(producto);

                txtStockActual.Text = stockActual.ToString();

                if (stockActual < producto.StockMinimo)
                    txtStockActual.BackColor = Color.Red;
                else if (stockActual > producto.StockMaximo)
                    txtStockActual.BackColor = Color.Red;
                else
                    txtStockActual.BackColor = Color.White;

                SetTable_Precios(producto);
                
            }
        }

        private void SetTable_Precios(Producto producto)
        {
            dgvPrecios.Rows.Clear();

            List<PrecioProducto> list = extras.GetProducto_ListaPrecios(producto);

            if (list.Count != 0)
            {
                foreach (PrecioProducto precio in list)
                {
                    Proveedor proveedor = new Proveedor() { Id = precio.IdProveedor };

                    if (proveedor.Id == 0)
                    {
                        proveedor.Nombre = "WORKING SRL";
                    }
                    else
                    {
                        proveedor = extras.GetProveedor(proveedor);
                    }


                    dgvPrecios.Rows.Add(proveedor.Nombre, decimal.Round(precio.Precio, 2), decimal.Round(precio.PrecioTotal, 2));
                }
            }
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPrecio_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count != 0)
            {
                long idProducto = long.Parse(dgvProductos.SelectedRows[0].Cells["Id"].Value.ToString());
                Producto producto = new Producto() { Id = idProducto };
                producto = extras.GetProducto(producto);

                List<Proveedor> listaProveedores = extras.GetProveedores();

                panelPrecio.Visible = true;
                //pictureBox1.Visible = true;

                cmbProveedor.Items.Clear();

                if (listaProveedores.Count != 0)
                {
                    foreach (Proveedor proveedor in listaProveedores)
                    {
                        cmbProveedor.Items.Add(proveedor.Id + ". " + proveedor.Nombre);
                    }

                    cmbProveedor.SelectedIndex = 0;
                }

                txtPrecioUnitario.Text = "0";
                txtAlicuotaIva.Text = "0,21";
                txtPrecioUnitario.ReadOnly = false;
                txtAlicuotaIva.ReadOnly = false;
            }
        }

        private void txtPrecioUnitario_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecioUnitario.Text == "")
            {
                txtPrecioUnitario.Text = "0";
            }

            decimal precio = decimal.Parse(txtPrecioUnitario.Text);
            decimal alicuota = decimal.Parse(txtAlicuotaIva.Text);

            txtTotal.Text = decimal.Round(precio + (precio * alicuota), 2).ToString();
        }

        private void btnGuardarPrecio_Click(object sender, EventArgs e)
        {
            long idProducto = long.Parse(dgvProductos.SelectedRows[0].Cells["Id"].Value.ToString());
            Producto producto = new Producto() { Id = idProducto };

            PrecioProducto precio = new PrecioProducto()
            {
                Id = extras.GetPrecioProducto_Id() + 1,
                IdProducto = producto.Id,
                IdProveedor = extras.GetId(cmbProveedor.SelectedItem.ToString()),
                Fecha = DateTime.Today.ToString("yyyy-MM-dd"),
                Precio = decimal.Parse(txtPrecioUnitario.Text),
                Iva = decimal.Parse(txtAlicuotaIva.Text),
                PrecioTotal = decimal.Parse(txtTotal.Text),
                Observaciones = ""
            };

            extras.AddPrecioProducto(precio);

            SetTable_Precios(producto);

            panelPrecio.Visible = false;
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOkPrecio_Click(object sender, EventArgs e)
        {
            long idProducto = long.Parse(dgvProductos.SelectedRows[0].Cells["Id"].Value.ToString());
            Producto producto = new Producto() { Id = idProducto };

            PrecioProducto precio = new PrecioProducto()
            {
                Id = extras.GetPrecioProducto_Id() + 1,
                IdProducto = producto.Id,
                IdProveedor = extras.GetId(cmbProveedor.SelectedItem.ToString()),
                Fecha = DateTime.Today.ToString("yyyy-MM-dd"),
                Precio = decimal.Parse(txtPrecioUnitario.Text),
                Iva = decimal.Parse(txtAlicuotaIva.Text),
                PrecioTotal = decimal.Parse(txtTotal.Text),
                Observaciones = ""
            };

            extras.AddPrecioProducto(precio);

            SetTable_Precios(producto);

            panelPrecio.Visible = false;
        }

        private void btnDescartarPrecio_Click(object sender, EventArgs e)
        {

        }

        private void btnNoPrecio_Click(object sender, EventArgs e)
        {
            //pictureBox1.Visible = false;
            panelPrecio.Visible = false;
        }
    }
}
