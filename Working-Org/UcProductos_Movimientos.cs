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
    public partial class UcProductos_Movimientos : UserControl
    {
        private static UcProductos_Movimientos _instance;

        private Extras extras = new Extras();

        public static UcProductos_Movimientos Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcProductos_Movimientos();
                }

                return _instance;
            }
        }

        public UcProductos_Movimientos()
        {
            InitializeComponent();
        }

        private void UcProductos_Movimientos_Load(object sender, EventArgs e)
        {
            SetTable_Movimientos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            List<Producto> listaProductos = extras.GetProductos();

            cmbProductos.Items.Clear();

            foreach (Producto producto in listaProductos)
            {
                cmbProductos.Items.Add(producto.Id + ". " + producto.Nombre);
            }

            dgvMovimientos.Enabled = false;
            panelStock.Visible = true;
            btnStock.Enabled = false;

        }

        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedItem != null)
            {
                Producto producto = new Producto() { Id = extras.GetId(cmbProductos.SelectedItem.ToString()) };
                producto = extras.GetProducto(producto);

                txtStockActual.Text = extras.GetProducto_Stock(producto).ToString();
                txtNuevoStock.Text = "0";

                lblStockActual.Text = producto.UnidadDeMedida;
                lblNuevoStock.Text = producto.UnidadDeMedida;
            }
        }

        private void btnGuardarStock_Click(object sender, EventArgs e)
        {
            //chequeos

            decimal stockActual = decimal.Parse(txtStockActual.Text);
            decimal stockNuevo = decimal.Parse(txtNuevoStock.Text);

            MovimientoProducto movimiento = new MovimientoProducto()
            {
                Id = extras.GetMovimientoProducto_Id() + 1,
                IdProducto = extras.GetId(cmbProductos.SelectedItem.ToString()),
                TipoMovimiento = "CORRECCION",
                Cantidad = (stockNuevo - stockActual),
                Fecha = DateTime.Today.ToString("yyyy-MM-dd"),
                Stock = 0,
                Observaciones = ""
            };

            extras.AddMovimientoProducto(movimiento);

            txtNuevoStock.Text = "0";
            txtStockActual.Text = "0";

            SetTable_Movimientos();

            btnStock.Enabled = true;
            panelStock.Visible = false;
            dgvMovimientos.Enabled = true;

        }

        private void btnDescartarStock_Click(object sender, EventArgs e)
        {
            txtNuevoStock.Text = "0";
            txtStockActual.Text = "0";

            btnStock.Enabled = true;
            panelStock.Visible = false;
            dgvMovimientos.Enabled = true;
        }

        public void SetTable_Movimientos()
        {
            List<MovimientoProducto> listaMovimientos = extras.GetMovimientosProductos();

            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int16"));
            dt.Columns.Add("IdProducto", Type.GetType("System.Int16"));
            dt.Columns.Add("Fecha", Type.GetType("System.String"));
            dt.Columns.Add("Producto", Type.GetType("System.String"));
            dt.Columns.Add("Tipo", Type.GetType("System.String"));
            dt.Columns.Add("Cantidad", Type.GetType("System.Decimal"));
            dt.Columns.Add("Stock", Type.GetType("System.Decimal"));

            foreach (MovimientoProducto movimiento in listaMovimientos)
            {
                Producto producto = new Producto() { Id = movimiento.IdProducto };

                if (producto.Id == 0)
                {
                    dt.Rows.Add(movimiento.Id, 0, movimiento.Fecha, "DESHECHO/SOBRAS", movimiento.TipoMovimiento, movimiento.Cantidad, movimiento.Stock);
                }
                else
                {
                    producto = extras.GetProducto(producto);
                    dt.Rows.Add(movimiento.Id, producto.Id, movimiento.Fecha, producto.Nombre, movimiento.TipoMovimiento, movimiento.Cantidad, movimiento.Stock);
                }



            }

            dgvMovimientos.DataSource = dt;

            dgvMovimientos.Columns["Id"].Visible = false;
            dgvMovimientos.Columns["IdProducto"].Visible = false;
            dgvMovimientos.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMovimientos.Columns["Producto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMovimientos.Columns["Tipo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMovimientos.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMovimientos.Columns["Stock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void btnOkPrecio_Click(object sender, EventArgs e)
        {
            //chequeos

            decimal stockActual = decimal.Parse(txtStockActual.Text);
            decimal stockNuevo = decimal.Parse(txtNuevoStock.Text);

            MovimientoProducto movimiento = new MovimientoProducto()
            {
                Id = extras.GetMovimientoProducto_Id() + 1,
                IdProducto = extras.GetId(cmbProductos.SelectedItem.ToString()),
                TipoMovimiento = "CORRECCION",
                Cantidad = (stockNuevo - stockActual),
                Fecha = DateTime.Today.ToString("yyyy-MM-dd"),
                Stock = 0,
                Observaciones = ""
            };

            extras.AddMovimientoProducto(movimiento);

            txtNuevoStock.Text = "0";
            txtStockActual.Text = "0";

            SetTable_Movimientos();

            btnStock.Enabled = true;
            panelStock.Visible = false;
            dgvMovimientos.Enabled = true;

        }

        private void btnNoPrecio_Click(object sender, EventArgs e)
        {
            txtNuevoStock.Text = "0";
            txtStockActual.Text = "0";

            btnStock.Enabled = true;
            panelStock.Visible = false;
            dgvMovimientos.Enabled = true;
        }
    }
}
