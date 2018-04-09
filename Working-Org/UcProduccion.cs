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
    public partial class UcProduccion : UserControl
    {
        private static UcProduccion _instance;

        private Extras extras = new Extras();

        private decimal _pesoUnidadMP = 0;
        private decimal _relacionMateriaProducto = 0;
        private decimal _cantidadElaborada = 0;

        public static UcProduccion Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcProduccion();
                }

                return _instance;
            }
        }


        public UcProduccion()
        {
            InitializeComponent();
        }

        private void UcProduccion_Load(object sender, EventArgs e)
        {
            this.Controles_Inicio();

            //this.GetProductoElaborado();
            //this.GetMateriaPrima();

            //if (_listaProductoElaborado.Count != 0)
            //{
            //    foreach (Producto p in _listaProductoElaborado)
            //        cmbProductoElaborado.Items.Add(p.Id + ". " + p.Nombre);
            //    cmbProductoElaborado.SelectedIndex = 0;
            //}

            //if (_listaMateriaPrima.Count != 0)
            //{
            //    foreach (Producto p in _listaMateriaPrima)
            //        cmbProducto.Items.Add(p.Id + ". " + p.Nombre);
            //    cmbProducto.SelectedIndex = 0;
            //}

            //dtpFechaLote.Value = GetNextWeekday(DateTime.Today, DayOfWeek.Tuesday);
            //dtpFechaVencimiento.Value = GetFechaVencimiento(dtpFechaLote.Value, 50);

            //_movimientoProductos = new DataTable();
            //_movimientoProductos.Columns.Add("IdProducto", Type.GetType("System.Int32"));
            //_movimientoProductos.Columns.Add("Cantidad", Type.GetType("System.Decimal"));
            //_movimientoProductos.Columns.Add("Stock", Type.GetType("System.Decimal"));
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevoPedido_Click(object sender, EventArgs e)
        {

        }

        private void txtUnidades_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidadMateriaPrima.Text == "")
                txtCantidadMateriaPrima.Text = "0";

            decimal unidades = decimal.Parse(txtCantidadMateriaPrima.Text);
            decimal kilosMateriaPrima = decimal.Round(unidades * this._pesoUnidadMP, 3);
            decimal kilosProducto = decimal.Round(kilosMateriaPrima / this._relacionMateriaProducto, 3);

            txtKilosMateriaPrima.Text = kilosMateriaPrima.ToString();
            txtKilosProducto.Text = kilosProducto.ToString();
        }

        private void btnPrevisualizar_Click(object sender, EventArgs e)
        {
            this.Controles_Previsualizar();

            DataTable dt = new DataTable();
            dt.Columns.Add("IdProducto", Type.GetType("System.Int32"));
            dt.Columns.Add("Producto", Type.GetType("System.String"));
            dt.Columns.Add("Cantidad", Type.GetType("System.Decimal"));
            dt.Columns.Add("Stock actual", Type.GetType("System.Decimal"));
            dt.Columns.Add("Stock post", Type.GetType("System.Decimal"));

            Producto producto = new Producto() { Id = extras.GetId(cmbProductoElaborado.SelectedItem.ToString()) };
            producto = extras.GetProducto(producto);

            Producto materiaPrima = new Producto() { Id = extras.GetId(cmbMateriaPrima.SelectedItem.ToString()) };
            materiaPrima = extras.GetProducto(materiaPrima);

            /// OJO OJO OJO OJO OJO
            
            ListaFabricacion listaFabricacion = extras.GetListaComponentes(materiaPrima, producto);

            //if (materiaPrima.Id == 3) //parma
            //    listaFabricacion.Id = 2;

            /// OJO OJO OJO OJO OJO
            
            List<DetalleListaFabricacion> detalleFabricacion = extras.GetProducto_DetalleFabricacion(listaFabricacion);

            decimal kilosMateriaPrima = decimal.Parse(txtKilosMateriaPrima.Text);
            kilosMateriaPrima = decimal.Round(kilosMateriaPrima, 3);

            decimal kilosProductoElaborado = decimal.Parse(txtKilosProducto.Text);
            kilosProductoElaborado = decimal.Round(kilosProductoElaborado, 3);

            decimal stockProductoElaborado = extras.GetProducto_Stock(producto);
            
            foreach (DetalleListaFabricacion linea in detalleFabricacion)
            {
                Producto componente = new Producto() { Id = linea.IdProducto };
                componente = extras.GetProducto(componente);

                decimal cantidad = (linea.Cantidad * kilosProductoElaborado);
                cantidad = decimal.Round(cantidad, 3);

                decimal stock = extras.GetProducto_Stock(componente);
                stock = decimal.Round(stock, 3);

                dt.Rows.Add(componente.Id, componente.Nombre, cantidad, stock, (stock - cantidad));
            }

            dgvProduccion.DataSource = dt;
            dgvProduccion.Columns["IdProducto"].Visible = false;
            dgvProduccion.Columns["Producto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProduccion.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvProduccion.Columns["Stock actual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvProduccion.Columns["Stock post"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("IdProducto", Type.GetType("System.Int32"));
            dt2.Columns.Add("Producto", Type.GetType("System.String"));
            dt2.Columns.Add("Cantidad", Type.GetType("System.Decimal"));
            dt2.Columns.Add("Stock actual", Type.GetType("System.Decimal"));
            dt2.Columns.Add("Stock post", Type.GetType("System.Decimal"));

            dt2.Rows.Add(producto.Id, producto.Nombre, kilosProductoElaborado, stockProductoElaborado, (stockProductoElaborado + kilosProductoElaborado));
            dt2.Rows.Add(0, "DESHECHOS/SOBRANTES", (kilosMateriaPrima - kilosProductoElaborado), 0, 0);

            dgvResultadosElaboracion.DataSource = dt2;
            dgvResultadosElaboracion.Columns["IdProducto"].Visible = false;
            dgvResultadosElaboracion.Columns["Producto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadosElaboracion.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvResultadosElaboracion.Columns["Stock actual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvResultadosElaboracion.Columns["Stock post"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }


        #region Funciones

        public static DateTime GetNextWeekday(DateTime start, DayOfWeek day)
        {
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd);
        }

        public DateTime GetFechaVencimiento(DateTime start, int dias) => start.AddDays(dias);

        private string GetNombreMateriaPrima(string str)
        {
            int largo = str.Length;
            int pos = (largo - 1) - (largo / 2);

            return str.Substring(pos);
        }

        private long GetIdProductoElaborado(string str)
        {
            string[] s = str.Split('.');
            return long.Parse(s[0]);
        }

        private void Controles_Inicio()
        {
            btnNuevaProduccion.Enabled = true;
            btnConfirmar.Enabled = false;
            btnVolver.Enabled = false;

            dtpFechaProduccion.Enabled = false;
            cmbProductoElaborado.Enabled = false;
            cmbMateriaPrima.Enabled = false;
            txtCantidadMateriaPrima.ReadOnly = true;
            txtKilosMateriaPrima.ReadOnly = true;
            txtCantidadProducto.ReadOnly = true;
            txtKilosProducto.ReadOnly = true;

            dtpFechaLote.Enabled = false;
            dtpFechaVencimiento.Enabled = false;
            btnPrevisualizar.Enabled = false;

            dgvProduccion.Enabled = false;
            dgvResultadosElaboracion.Enabled = false;
        }

        private void Controles_Nuevo()
        {
            btnNuevaProduccion.Enabled = false;
            btnConfirmar.Enabled = false;
            btnVolver.Enabled = true;

            dtpFechaProduccion.Enabled = true;
            cmbProductoElaborado.Enabled = true;
            cmbMateriaPrima.Enabled = true;
            txtCantidadMateriaPrima.ReadOnly = false;
            txtKilosMateriaPrima.ReadOnly = false;
            txtCantidadProducto.ReadOnly = false;
            txtKilosProducto.ReadOnly = false;

            dtpFechaLote.Enabled = true;
            dtpFechaVencimiento.Enabled = true;
            btnPrevisualizar.Enabled = true;

            dgvProduccion.Enabled = false;
            dgvResultadosElaboracion.Enabled = false;
        }

        private void Controles_Previsualizar()
        {
            btnNuevaProduccion.Enabled = false;
            btnConfirmar.Enabled = true;
            btnVolver.Enabled = true;

            dtpFechaProduccion.Enabled = true;
            cmbProductoElaborado.Enabled = true;
            cmbMateriaPrima.Enabled = true;
            txtCantidadMateriaPrima.ReadOnly = false;
            txtKilosMateriaPrima.ReadOnly = false;
            txtCantidadProducto.ReadOnly = false;
            txtKilosProducto.ReadOnly = false;

            dtpFechaLote.Enabled = true;
            dtpFechaVencimiento.Enabled = true;
            btnPrevisualizar.Enabled = true;

            dgvProduccion.Enabled = true;
            dgvResultadosElaboracion.Enabled = true;
        }


        #endregion


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnGuardarCambios_Click_1(object sender, EventArgs e)
        {
            if (txtCantidadMateriaPrima.Text == "" || txtCantidadMateriaPrima.Text == "0")
            {
                return;
            }

            // Nueva Produccion Diaria

            Producto productoElaborado = new Producto() { Id = extras.GetId(cmbProductoElaborado.SelectedItem.ToString()) };

            ProduccionDiaria produccionDiaria = new ProduccionDiaria()
            {
                Id = extras.GetProduccion_Id() + 1,
                IdProducto = productoElaborado.Id,
                FechaProduccion = dtpFechaProduccion.Value.ToString("yyyy-MM-dd"),
                Cantidad = decimal.Parse(txtKilosProducto.Text),
                FechaElaboracion = dtpFechaLote.Value.ToString("yyyy-MM-dd"),
                FechaVencimiento = dtpFechaVencimiento.Value.ToString("yyyy-MM-dd"),
                NumeroLote = dtpFechaLote.Value.ToString("yyMMdd"),
                Observaciones = txtObservaciones.Text,
                Ubicacion = "WORKING"
            };


            // Nuevo Movimiento de producto
            List<MovimientoProducto> listaMovimientos = new List<MovimientoProducto>();
            long idMovimientoProducto = extras.GetMovimientoProducto_Id();

            foreach (DataGridViewRow row in dgvProduccion.Rows)
            {
                idMovimientoProducto += 1;

                Producto producto = new Producto() { Id = long.Parse(row.Cells["IdProducto"].Value.ToString()) };
                decimal stockProducto = extras.GetProducto_Stock(producto);
                decimal cantidad = decimal.Parse(row.Cells["Cantidad"].Value.ToString());

                MovimientoProducto movimientoProducto = new MovimientoProducto()
                {
                    Id = idMovimientoProducto,
                    IdProducto = producto.Id,
                    TipoMovimiento = "PRODUCCIÓN DIARIA",
                    Cantidad = (cantidad * -1),
                    Fecha = dtpFechaProduccion.Value.ToString("yyyy-MM-dd"),
                    Stock = (stockProducto - cantidad),
                    Observaciones = "Producción diaria"
                };

                listaMovimientos.Add(movimientoProducto);
            }

            foreach (DataGridViewRow row in dgvResultadosElaboracion.Rows)
            {
                idMovimientoProducto += 1;

                Producto producto = new Producto() { Id = long.Parse(row.Cells["IdProducto"].Value.ToString()) };
                decimal stockProducto = extras.GetProducto_Stock(producto);
                decimal cantidad = decimal.Parse(row.Cells["Cantidad"].Value.ToString());

                MovimientoProducto movimientoProducto = new MovimientoProducto()
                {
                    Id = idMovimientoProducto,
                    IdProducto = producto.Id,
                    TipoMovimiento = "PRODUCCIÓN DIARIA",
                    Cantidad = cantidad,
                    Fecha = dtpFechaProduccion.Value.ToString("yyyy-MM-dd"),
                    Stock = (stockProducto + cantidad),
                    Observaciones = "Producción diaria"
                };

                listaMovimientos.Add(movimientoProducto);
            }



            extras.AddProduccion(produccionDiaria);
            extras.AddMovimientoProducto(listaMovimientos);

            // Actualizo Stock
            //foreach (DataRow row in this._movimientoProductos.Rows)
            //{
            //    ActualizarStock(long.Parse(row["IdProducto"].ToString()), decimal.Parse(row["Stock"].ToString()));
            //}

            MessageBox.Show("OK");

            this.Controles_Inicio();
        }

        private void btnNuevaProduccion_Click(object sender, EventArgs e)
        {
            this.Controles_Nuevo();

            lblBarra1.Visible = true;

            cmbProductoElaborado.Items.Clear();
            cmbMateriaPrima.Items.Clear();

            List<Producto> listaProductos = extras.GetProductos("VENTA", false);
            foreach (Producto producto in listaProductos)
            {
                cmbProductoElaborado.Items.Add(producto.Id + ". " + producto.Nombre);
            }
            cmbProductoElaborado.SelectedIndex = 0;

            List<Producto> listaMateriaPrima = extras.GetProductos("MATERIA PRIMA", false);
            foreach(Producto producto in listaMateriaPrima)
            {
                cmbMateriaPrima.Items.Add(producto.Id + ". " + producto.Nombre);
            }
            cmbMateriaPrima.SelectedIndex = 0;

            dtpFechaLote.Value = extras.GetFecha_Dia(DateTime.Today, DayOfWeek.Tuesday);
        }

        private void cmbMateriaPrima_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMateriaPrima.SelectedItem == null)
                return;

            Producto materiaPrima = new Producto() { Id = extras.GetId(cmbMateriaPrima.SelectedItem.ToString()) };
            Producto productoElaborado = new Producto() { Id = extras.GetId(cmbProductoElaborado.SelectedItem.ToString()) };
            this._pesoUnidadMP = extras.GetProducto_Peso(materiaPrima);
            this._relacionMateriaProducto = extras.GetProducto_RelacionProducto(materiaPrima, productoElaborado);

        }

        private void dtpFechaLote_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaVencimiento.Value = dtpFechaLote.Value.AddDays(50);
        }

        private void txtCantidadMateriaPrima_KeyPress(object sender, KeyPressEventArgs e)
        {
            extras.Validate_textBox(sender as TextBox, e);
        }

        private void txtKilosMateriaPrima_KeyPress(object sender, KeyPressEventArgs e)
        {
            extras.Validate_textBox(sender as TextBox, e);
        }

        private void txtCantidadProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            extras.Validate_textBox(sender as TextBox, e);
        }

        private void txtKilosProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            extras.Validate_textBox(sender as TextBox, e);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtCantidadMateriaPrima.Text == "" || txtCantidadMateriaPrima.Text == "0")
            {
                return;
            }


            if (!extras.CkConfirmacion("realizar la producción diaria con los valores ingresados"))
            {
                return;
            }

            // Nueva Produccion Diaria

            Producto productoElaborado = new Producto() { Id = extras.GetId(cmbProductoElaborado.SelectedItem.ToString()) };

            ProduccionDiaria produccionDiaria = new ProduccionDiaria()
            {
                Id = extras.GetProduccion_Id() + 1,
                IdProducto = productoElaborado.Id,
                FechaProduccion = dtpFechaProduccion.Value.ToString("yyyy-MM-dd"),
                Cantidad = decimal.Parse(txtKilosProducto.Text),
                FechaElaboracion = dtpFechaLote.Value.ToString("yyyy-MM-dd"),
                FechaVencimiento = dtpFechaVencimiento.Value.ToString("yyyy-MM-dd"),
                NumeroLote = dtpFechaLote.Value.ToString("yyMMdd"),
                Observaciones = txtObservaciones.Text,
                Ubicacion = "WORKING"
            };


            // Nuevo Movimiento de producto
            List<MovimientoProducto> listaMovimientos = new List<MovimientoProducto>();
            long idMovimientoProducto = extras.GetMovimientoProducto_Id();

            foreach (DataGridViewRow row in dgvProduccion.Rows)
            {
                idMovimientoProducto += 1;

                Producto producto = new Producto() { Id = long.Parse(row.Cells["IdProducto"].Value.ToString()) };
                decimal stockProducto = extras.GetProducto_Stock(producto);
                decimal cantidad = decimal.Parse(row.Cells["Cantidad"].Value.ToString());

                MovimientoProducto movimientoProducto = new MovimientoProducto()
                {
                    Id = idMovimientoProducto,
                    IdProducto = producto.Id,
                    TipoMovimiento = "PRODUCCION",
                    Cantidad = (cantidad * -1),
                    Fecha = dtpFechaProduccion.Value.ToString("yyyy-MM-dd"),
                    Stock = (stockProducto - cantidad),
                    Observaciones = "Producción diaria"
                };

                listaMovimientos.Add(movimientoProducto);
            }

            foreach (DataGridViewRow row in dgvResultadosElaboracion.Rows)
            {
                idMovimientoProducto += 1;

                Producto producto = new Producto() { Id = long.Parse(row.Cells["IdProducto"].Value.ToString()) };
                decimal stockProducto = extras.GetProducto_Stock(producto);
                decimal cantidad = decimal.Parse(row.Cells["Cantidad"].Value.ToString());

                MovimientoProducto movimientoProducto = new MovimientoProducto()
                {
                    Id = idMovimientoProducto,
                    IdProducto = producto.Id,
                    TipoMovimiento = "PRODUCCION",
                    Cantidad = cantidad,
                    Fecha = dtpFechaProduccion.Value.ToString("yyyy-MM-dd"),
                    Stock = (stockProducto + cantidad),
                    Observaciones = "Producción diaria"
                };

                listaMovimientos.Add(movimientoProducto);
            }



            extras.AddProduccion(produccionDiaria);
            extras.AddMovimientoProducto(listaMovimientos);

            // Actualizo Stock
            //foreach (DataRow row in this._movimientoProductos.Rows)
            //{
            //    ActualizarStock(long.Parse(row["IdProducto"].ToString()), decimal.Parse(row["Stock"].ToString()));
            //}

            MessageBox.Show("OK");

            lblBarra1.Visible = false;
            this.Controles_Inicio();
        }

        private void btnDescartarCambios_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            DescartarCambios();
            Controles_Inicio();
        }

        public void DescartarCambios()
        {
            dtpFechaProduccion.Value = DateTime.Today;
            cmbProductoElaborado.SelectedItem = null;
            cmbMateriaPrima.SelectedItem = null;
            txtCantidadMateriaPrima.Text = "0.00";
            txtCantidadProducto.Text = "0.00";
            txtKilosMateriaPrima.Text = "0.00";
            txtKilosProducto.Text = "0.00";
            txtObservaciones.Text = "";
            dgvProduccion.DataSource = null;
            dgvProduccion.Rows.Clear();
            dgvResultadosElaboracion.DataSource = null;
            dgvResultadosElaboracion.Rows.Clear();
        }

        private void cmbProductoElaborado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
