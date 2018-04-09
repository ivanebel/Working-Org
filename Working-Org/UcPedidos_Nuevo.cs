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

/// <summary>
/// LA UNIDAD DE MEDIDA POR DEFAULT VA A SER EL "BULTO".
/// 
/// En teoría, al emitir un pedido, me piden una cantidad de bultos, ya que cada uno corresponde a un peso aproximado.
/// Al enviar dicho pedido, es posible identificar qué bulto va a cada CD.
/// Además, podría saber cuánto pesa específicamente cada bulto, y así saber las cantidades enviadas.
/// 
/// </summary>


namespace Working_Org
{
    public partial class UcPedidos_Nuevo : UserControl
    {
        private static UcPedidos_Nuevo _instance;

        private Extras extras = new Extras();

        private Pedido _pedido;
        private bool _isEdit = false;


        
        public static UcPedidos_Nuevo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcPedidos_Nuevo();
                }

                return _instance;
            }
        }

        public UcPedidos_Nuevo()
        {
            InitializeComponent();
        }

        private void UcPedidosActuales_Load(object sender, EventArgs e)
        {
            dgvContenido_B.Visible = true;
            dgvContenido.Visible = false;

            this.Controles_Inicio();

            cmbCd.Items.Add("501. VICENTE LÓPEZ");
            cmbCd.Items.Add("503. BURZACO");
            cmbCd.Items.Add("506. SALTA");
            cmbCd.Items.Add("509. PARANÁ");
            cmbCd.Items.Add("510. AVELLANEDA");
            cmbCd.Items.Add("511. TORTUGUITAS");

            List<Cliente> listaClientes = extras.GetClientes(); 

            if (listaClientes.Count != 0)
            {
                foreach(Cliente cliente in listaClientes)
                {
                    cmbCliente.Items.Add(cliente.Id + ". " + cliente.Nombre);
                }

                cmbCliente.SelectedIndex = 0;
            }

            SetTable_Pedidos();

                       
        }
        
        private void btnNuevoPedido_Click(object sender, EventArgs e)
        {
            this.Controles_NuevoPedido();

            DescartarCambios();

            lblBarra1.Visible = true;

            dtpFechaEmision.Value = DateTime.Today;
            dtpFechaEntrega.Value = (DateTime.Today.AddDays(5));
            dtpHoraEntrega.Value = DateTime.Parse(DateTime.Now.ToString("HH:00"));

            cmbCd.SelectedIndex = 0;

            dgvContenido_B.Visible = false;
            dgvContenido.Visible = true;

            txtOc.Focus();
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            //chequeos
            if (!Chequeos())
                return;

            Pedido pedido = new Pedido
            {
                Id = extras.GetPedido_Id() + 1,
                IdCliente = 1,
                OC = long.Parse(txtOc.Text),
                CD = extras.GetId(cmbCd.SelectedItem.ToString()),
                FechaEmision = dtpFechaEmision.Value.ToString("yyyy-MM-dd"),
                FechaEntrega = dtpFechaEntrega.Value.ToString("yyyy-MM-dd"),
                HoraEntrega = dtpHoraEntrega.Value.ToString("HH:mm"),
                MuelleEntrega = txtMuelle.Text,
                Reprogramaciones = 0,
                Estado = "ABIERTO",
                Observaciones = txtObservaciones.Text
            };

            List<LineaPedido> lineasPedido = new List<LineaPedido>();

            foreach (DataGridViewRow row in dgvContenido.Rows)
            {

                LineaPedido linea = new LineaPedido
                {
                    Id = extras.GetLineaPedido_Id() + 1,
                    IdPedido = pedido.Id,
                    IdProducto = extras.GetId(row.Cells["cProducto"].Value.ToString()),
                    Cantidad = decimal.Parse(row.Cells["cBultos"].Value.ToString()),
                    Pendiente = decimal.Parse(row.Cells["cBultos"].Value.ToString())
                };

                lineasPedido.Add(linea);
            }

            extras.AddPedido(pedido);
            extras.AddLineaPedido(lineasPedido);
            
            DescartarCambios();

            lblBarra1.Visible = false;

            this.Controles_Inicio();
        }



        private void btnPedidosActuales_Click(object sender, EventArgs e)
        {
            UcPedidos_Nuevo.Instance.BringToFront();
            
        }



        private void bodyPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEditarPedido_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count <= 0)
                return;

            DataGridViewRow row = dgvPedidos.SelectedRows[0];

            _pedido = new Pedido() { Id = long.Parse(row.Cells["Id"].Value.ToString()) };
            _pedido = extras.GetPedido(_pedido);

            _isEdit = true;

            this.Controles_EditarPedido();



        }

        private void btnDescartarCambios_Click(object sender, EventArgs e)
        {
            this.Controles_Inicio();
        }



        private void cmbCd_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDireccionCD.Text = extras.GetCD_Direccion(extras.GetId(cmbCd.SelectedItem.ToString()));
        }


        #region FUNCTIONS

        
        private string obtenerDireccionCD(long index)
        {
            switch (index)
            {
                case 501:
                    return "AV. SAN MARTIN 4901, FLORIDA, V. LÓPEZ, BA";
                case 503:
                    return "GUATAMBÚ 1841, BURZACO, BA";
                case 506:
                    return "CANILLITA S/N, MANZ. 2, B° TORINO, CDAD. DE SALTA, SALTA";
                case 509:
                    return "CARLOS B. PATAT 1350, CNIA. AVELLANEDA, PARANÁ, ER";
                case 510:
                    return "CNEL. BOSCH 302, AVELLANEDA, BA";
                case 511:
                    return "ING. EIFEL 4250, ÁREA EL TRIÁNGULO, TORTUGUITAS, BA";
                default:
                    return "";
            }
        }

        private int getCDIndex(long cd)
        {
            switch (cd)
            {
                case 501:
                    return 0;
                case 503:
                    return 1;
                case 506:
                    return 2;
                case 509:
                    return 3;
                case 510:
                    return 4;
                case 511:
                    return 5;
                default:
                    return 9;
            }
        }

        private void Controles_Inicio()
        {
            btnNuevoPedido.Enabled = true;
            btnEditarPedido.Enabled = false;
            btnConfirmar.Enabled = false;
            btnVolver.Enabled = false;

            cmbCliente.Enabled = false;
            txtOc.ReadOnly = true;
            dtpFechaEmision.Enabled = false;
            cmbCd.Enabled = false;
            txtDireccionCD.ReadOnly = true;
            dtpFechaEntrega.Enabled = false;
            dtpHoraEntrega.Enabled = false;
            txtMuelle.ReadOnly = true;
            chkReprogramado.Enabled = false;
            txtObservaciones.ReadOnly = true;

            btnAgregarLinea.Enabled = false;
            btnQuitarLinea.Enabled = false;
            dgvContenido.Enabled = false;

            btnOpciones.Enabled = false;
        }

        private void Controles_NuevoPedido()
        {
            btnNuevoPedido.Enabled = false;
            btnEditarPedido.Enabled = false;
            btnConfirmar.Enabled = true;
            btnVolver.Enabled = true;

            cmbCliente.Enabled = true;
            txtOc.ReadOnly = false;
            dtpFechaEmision.Enabled = true;
            cmbCd.Enabled = true;
            txtDireccionCD.Enabled = false;
            dtpFechaEntrega.Enabled = true;
            dtpHoraEntrega.Enabled = true;
            txtMuelle.ReadOnly = false;
            chkReprogramado.Enabled = false;
            txtObservaciones.ReadOnly = false;

            btnAgregarLinea.Enabled = true;
            btnQuitarLinea.Enabled = true;
            dgvContenido.Enabled = true;

            btnOpciones.Enabled = false;
        }

        private void Controles_EditarPedido()
        {
            btnNuevoPedido.Enabled = false;
            btnEditarPedido.Enabled = false;
            btnConfirmar.Enabled = true;
            btnVolver.Enabled = true;

            cmbCliente.Enabled = true;
            txtOc.Enabled = true;
            dtpFechaEmision.Enabled = true;
            cmbCd.Enabled = true;
            txtDireccionCD.Enabled = false;
            dtpFechaEntrega.Enabled = true;
            dtpHoraEntrega.Enabled = true;
            txtMuelle.Enabled = true;
            chkReprogramado.Enabled = true;
            txtObservaciones.ReadOnly = false;

            btnAgregarLinea.Enabled = true;
            btnQuitarLinea.Enabled = true;
            dgvContenido.Enabled = true;

            btnOpciones.Enabled = true;
        }

        public void DescartarCambios()
        {
            txtOc.Text = "";
            dtpFechaEmision.Value = DateTime.Today;
            dtpHoraEntrega.Value = DateTime.Today;
            txtMuelle.Text = "";
            txtObservaciones.Text = "";

            //cmbCd.SelectedItem = null;
            txtDireccionCD.Text = "";

            dgvContenido.DataSource = null;
            dgvContenido.Rows.Clear();
        }

        private void SetTable_Pedidos()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", Type.GetType("System.Int16"));
            dt.Columns.Add("Cliente", Type.GetType("System.String"));
            dt.Columns.Add("OC", Type.GetType("System.Int32"));
            dt.Columns.Add("CD", Type.GetType("System.Int16"));
            dt.Columns.Add("Fecha Emisión", Type.GetType("System.DateTime"));
            dt.Columns.Add("Fecha Entrega", Type.GetType("System.DateTime"));
            dt.Columns.Add("Hora", Type.GetType("System.String"));
            dt.Columns.Add("Cantidad", Type.GetType("System.Decimal"));
            dt.Columns.Add("Reprog.", Type.GetType("System.Int16"));
            dt.Columns.Add("Estado", Type.GetType("System.String"));

            List<Pedido> listaPedidos = extras.GetPedidos("ABIERTO", false);

            if (listaPedidos.Count != 0)
            {
                foreach (Pedido pedido in listaPedidos)
                {
                    Cliente cliente = new Cliente() { Id = pedido.IdCliente };
                    cliente = extras.GetCliente(cliente);

                    dt.Rows.Add(pedido.Id, cliente.Id + ". " + cliente.Nombre, pedido.OC, pedido.CD, DateTime.Parse(pedido.FechaEmision),
                        DateTime.Parse(pedido.FechaEntrega), pedido.HoraEntrega, pedido.Total, pedido.Reprogramaciones, pedido.Estado);
                }
            }

            dgvPedidos.DataSource = dt;

            dgvPedidos.Columns["Id"].Visible = false;
            
            dgvPedidos.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPedidos.Columns["OC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["CD"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Fecha Emisión"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Fecha Entrega"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Hora"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Reprog."].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
           
        }

        private bool Chequeos()
        {
            if (txtOc.Text == "")
            {
                MessageBox.Show("El campo 'Orden de Compra' no puede estar vacío.");
                return false;
            }

            if (dtpFechaEntrega.Value <= dtpFechaEmision.Value)
            {
                MessageBox.Show("La fecha de entrega no puede ser anterior que la fecha de emisión del Pedido.");
                return false;
            }

            if (dgvContenido.Rows.Count <= 0)
            {
                MessageBox.Show("El Pedido debe tener al menos una Linea de Pedido.");
                return false;
            }

            //if (dgvContenido.Rows.Count > 0)
            //{

            //}

            return true;
        }

        #endregion

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


       

        private void dgvContenido_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvContenido.SelectedRows.Count != 0)
            {
                if (dgvContenido.SelectedRows[0].Cells["cProducto"].Value == null)
                    //try
                    //{
                    //    dgvContenido.SelectedRows[0].Cells["cProducto"].
                    //}
                    return;
                //string col = dgvContenido.SelectedRows[0].Cells["cProducto"].Value.ToString();
                if (dgvContenido.SelectedRows[0].Cells["cProducto"].Value.ToString() != "")
                {
                    if (dgvContenido.SelectedRows[0].Cells["cBultos"].Value.ToString() == "")
                        dgvContenido.SelectedRows[0].Cells["cBultos"].Value = 0;

                    decimal bultos = decimal.Parse(dgvContenido.SelectedRows[0].Cells["cBultos"].Value.ToString());

                    dgvContenido.SelectedRows[0].Cells["cPendiente"].Value = bultos;
                }
            }

            if (dgvContenido.Rows.Count != 0)
            {
                decimal bultos = 0;

                foreach (DataGridViewRow row in dgvContenido.Rows)
                {
                    decimal lBultos = 0;
                    decimal.TryParse(row.Cells["cBultos"].Value.ToString(), out lBultos);

                    if (lBultos >= 0)
                        bultos += long.Parse(row.Cells["cBultos"].Value.ToString());
                }

                txtTotalBultos.Text = bultos.ToString();
            }
        }

        private void btnAgregarLinea_Click(object sender, EventArgs e)
        {
            List<Producto> listaProductos = extras.GetProductos("VENTA", false);

            int iFila = dgvContenido.Rows.Add();

            DataGridViewRow row = dgvContenido.Rows[iFila];

            var cProducto = row.Cells["cProducto"] as DataGridViewComboBoxCell;

            foreach (Producto p in listaProductos)
            {
                cProducto.Items.Add(p.Id + ". " + p.Nombre);
            }

            row.Cells["cBultos"].Value = 0;
            row.Cells["cPendiente"].Value = 0;
        }

        private void btnQuitarLinea_Click(object sender, EventArgs e)
        {
            if (dgvContenido.SelectedRows.Count != 0)
            {
                int i = dgvContenido.SelectedRows[0].Index;
                dgvContenido.Rows.RemoveAt(i);
            }

            if (dgvContenido.Rows.Count != 0)
            {
                decimal bultos = 0;

                foreach (DataGridViewRow row in dgvContenido.Rows)
                {
                    decimal lBultos = 0;
                    decimal.TryParse(row.Cells["cBultos"].Value.ToString(), out lBultos);

                    if (lBultos >= 0)
                        bultos += long.Parse(row.Cells["cBultos"].Value.ToString());
                }

                txtTotalBultos.Text = bultos.ToString();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //chequeos
            if (!Chequeos())
                return;

            if (!extras.CkConfirmacion("ingresar este nuevo pedido"))
                return;

            long reprog = 0;
            if (chkReprogramado.Checked)
                reprog = 1;

            Pedido pedido = new Pedido
            {
                Id = extras.GetPedido_Id() + 1,
                IdCliente = 1,
                OC = long.Parse(txtOc.Text),
                CD = extras.GetId(cmbCd.SelectedItem.ToString()),
                FechaEmision = dtpFechaEmision.Value.ToString("yyyy-MM-dd"),
                FechaEntrega = dtpFechaEntrega.Value.ToString("yyyy-MM-dd"),
                HoraEntrega = dtpHoraEntrega.Value.ToString("HH:mm"),
                MuelleEntrega = txtMuelle.Text,
                Reprogramaciones = reprog,
                Estado = "ABIERTO",
                Observaciones = txtObservaciones.Text,
                Total = decimal.Parse(txtTotalBultos.Text),
                Pendiente = decimal.Parse(txtTotalBultos.Text)
            };


            if (_isEdit)
            {
                pedido.Id = _pedido.Id;
            }



            List<LineaPedido> lineasPedido = new List<LineaPedido>();

            foreach (DataGridViewRow row in dgvContenido.Rows)
            {

                LineaPedido linea = new LineaPedido
                {
                    Id = extras.GetLineaPedido_Id() + 1,
                    IdPedido = pedido.Id,
                    IdProducto = extras.GetId(row.Cells["cProducto"].Value.ToString()),
                    Cantidad = decimal.Parse(row.Cells["cBultos"].Value.ToString()),
                    Pendiente = decimal.Parse(row.Cells["cPendiente"].Value.ToString())
                };

                lineasPedido.Add(linea);

            }

            if (_isEdit)
                extras.EditPedido(pedido, false);
            else
                extras.AddPedido(pedido);

            extras.AddLineaPedido(lineasPedido);
                        

            lblBarra1.Visible = false;

            DescartarCambios();

            SetTable_Pedidos();

            this.Controles_Inicio();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            lblBarra1.Visible = false;
            DescartarCambios();

            dgvContenido.Visible = false;
            dgvContenido_B.Visible = true;

            _isEdit = false;
            
            this.Controles_Inicio();
        }

        private void dgvPedidos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count != 0)
            {
                dgvContenido.Rows.Clear();

                long idPedido = long.Parse(dgvPedidos.SelectedRows[0].Cells["Id"].Value.ToString());

                Pedido pedido = new Pedido() { Id = idPedido };
                pedido = extras.GetPedido(pedido);

                List<LineaPedido> lineasPedido = extras.GetLineasPedido(pedido);

                Cliente cliente = new Cliente() { Id = pedido.IdCliente };
                cliente = extras.GetCliente(cliente);

                //txtCliente.Text = cliente.Id + ". " + cliente.Nombre;
                txtOc.Text = pedido.OC.ToString();
                dtpFechaEmision.Value = DateTime.Parse(pedido.FechaEmision);
                dtpFechaEntrega.Value = DateTime.Parse(pedido.FechaEntrega);
                dtpHoraEntrega.Value = DateTime.Parse(pedido.HoraEntrega);
                txtMuelle.Text = pedido.MuelleEntrega;
                txtObservaciones.Text = pedido.Observaciones;

                if (pedido.Reprogramaciones != 0)
                    chkReprogramado.Checked = true;

                cmbCd.Text = (pedido.CD.ToString());
                txtDireccionCD.Text = extras.GetCD_Direccion(pedido.CD);

                txtTotalBultos.Text = pedido.Total.ToString();

                dgvContenido_B.Rows.Clear();

                foreach (LineaPedido linea in lineasPedido)
                {
                    Producto producto = new Producto() { Id = linea.IdProducto };
                    producto = extras.GetProducto(producto);

                    dgvContenido_B.Rows.Add(linea.Id, producto.Id + ". " + producto.Nombre, linea.Cantidad, linea.Pendiente);
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            extras.Script_CompletarLineaPedido();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menuOpciones.Show(Cursor.Position);

        }
    }

}



