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
    public partial class UcPedidos_Historicos : UserControl
    {
        private static UcPedidos_Historicos _instance;

        private Extras extras = new Extras();

        public Pedido _pedidoSeleccionado = new Pedido();
        public List<LineaPedido> _lineasPedido = new List<LineaPedido>();

        private DataTable _dtPedidos;

        public static UcPedidos_Historicos Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcPedidos_Historicos();
                }

                return _instance;
            }
        }
        public UcPedidos_Historicos()
        {
            InitializeComponent();
        }

        private void UcPedidosHistoricos_Load(object sender, EventArgs e)
        {
            this.Controles_Inicio();

            SetTable_Pedidos();
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

                txtCliente.Text = cliente.Id + ". " + cliente.Nombre;
                txtOc.Text = pedido.OC.ToString();
                txtFechaEmision.Value = DateTime.Parse(pedido.FechaEmision);
                txtFechaEntrega.Value = DateTime.Parse(pedido.FechaEntrega);
                txtHoraEntrega.Value = DateTime.Parse(pedido.HoraEntrega);
                txtMuelle.Text = pedido.MuelleEntrega;
                txtObservaciones.Text = pedido.Observaciones;

                if (pedido.Reprogramaciones != 0)
                    chkReprogramado.Checked = true;

                txtCd.Text = GetCD(pedido.CD);
                txtDireccionCD.Text = GetDireccionCD(pedido.CD);

                foreach (LineaPedido linea in lineasPedido)
                {
                    Producto producto = new Producto() { Id = linea.IdProducto };
                    producto = extras.GetProducto(producto);

                    //dgvContenido.Rows.Add(linea.Id, producto.Id + ". " + producto.Nombre, linea.BultosPedidos, 
                    //    linea.BultosEntregados, linea.UnidadesPedidas, linea.UnidadesEntregadas, linea.KilosPedidos, linea.KilosEntregados);
                }

            }
        }

        private void btnPedidosActuales_Click(object sender, EventArgs e)
        {

        }

        private void btnPedidosHistoricos_Click(object sender, EventArgs e)
        {

        }

        private void topPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNuevoPedido_Click(object sender, EventArgs e)
        {

        }
        
        #region FUNCIONES

        private void SetTable_Pedidos()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", Type.GetType("System.Int16"));
            //_dtPedidos.Columns.Add("IdCliente", Type.GetType("System.Int16"));
            dt.Columns.Add("Cliente", Type.GetType("System.String"));
            dt.Columns.Add("OC", Type.GetType("System.Int32"));
            dt.Columns.Add("CD", Type.GetType("System.Int16"));
            dt.Columns.Add("Fecha Emisión", Type.GetType("System.DateTime"));
            dt.Columns.Add("Fecha Entrega", Type.GetType("System.DateTime"));
            dt.Columns.Add("Hora", Type.GetType("System.String"));
            dt.Columns.Add("Muelle", Type.GetType("System.String"));
            dt.Columns.Add("Reprog.", Type.GetType("System.Int16"));
            dt.Columns.Add("Estado", Type.GetType("System.String"));
            //_dtPedidos.Columns.Add("Observaciones", Type.GetType("System.String"));

            List<Pedido> listaPedidos = extras.GetPedidos();

            if (listaPedidos.Count != 0)
            {
                foreach (Pedido pedido in listaPedidos)
                {
                    Cliente cliente = new Cliente() { Id = pedido.IdCliente };
                    cliente = extras.GetCliente(cliente);

                    dt.Rows.Add(pedido.Id, cliente.Nombre, pedido.OC, pedido.CD, DateTime.Parse(pedido.FechaEmision),
                        DateTime.Parse(pedido.FechaEntrega), pedido.HoraEntrega, pedido.MuelleEntrega, pedido.Reprogramaciones, pedido.Estado);
                }
            }

            dgvPedidos.DataSource = dt;

            dgvPedidos.Columns["Id"].Visible = false;
            //dgvPedidos.Columns["IdCliente"].Visible = false;

            dgvPedidos.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPedidos.Columns["OC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["CD"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Fecha Emisión"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Fecha Entrega"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Hora"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Muelle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Reprog."].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dgvPedidos.Columns["Observaciones"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //if (dgvPedidos.Rows.Count != 0)
            //{
            //    dgvPedidos.Select();
            //}
        }

        private void Controles_Inicio()
        {
            txtCliente.ReadOnly = true;
            txtOc.ReadOnly = true;
            txtFechaEmision.Enabled = false;
            txtCd.ReadOnly = true;
            txtDireccionCD.ReadOnly = true;
            txtFechaEntrega.Enabled = false;
            txtHoraEntrega.Enabled = false;
            txtMuelle.ReadOnly = true;
            chkReprogramado.Enabled = false;

            dgvContenido.Enabled = false;
            dgvPedidos.Enabled = true;
        }

        private string GetCD(long index)
        {
            switch (index)
            {
                case 501:
                    return "501. VICENTE LÓPEZ";
                case 503:
                    return "503. BURZACO";
                case 506:
                    return "506. SALTA";
                case 509:
                    return "509. PARANÁ";
                case 510:
                    return "510. AVELLANEDA";
                case 511:
                    return "511. TORTUGUITAS";
                default:
                    return "";
            }
        }

        private string GetDireccionCD(long index)
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



        #endregion


    }
}
