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
    public partial class UcPedidos_Envio : UserControl
    {
        private static UcPedidos_Envio _instance;

        private Extras extras = new Extras();
        
        public static UcPedidos_Envio Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcPedidos_Envio();
                }

                return _instance;
            }
        }


        public UcPedidos_Envio()
        {
            InitializeComponent();
        }

        private void UcEnvios_Load(object sender, EventArgs e)
        {
            Controles_Inicio();

        }

        private void btnNuevoEnvio_Click(object sender, EventArgs e)
        {
            SetTable_Pedidos();
            Controles_Nuevo();
            lblBarra1.Visible = true;
        }

        private void dgvPedidos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count != 0)
            {
                Pedido pedido = new Pedido() { Id = long.Parse(dgvPedidos.SelectedRows[0].Cells["IdPedido"].Value.ToString()) };
                pedido = extras.GetPedido(pedido);

                dgvContenido.Rows.Clear();

                List<LineaPedido> lineasPedido = extras.GetLineasPedido(pedido);

                foreach (LineaPedido linea in lineasPedido)
                {
                    Producto producto = new Producto() { Id = linea.IdProducto };
                    producto = extras.GetProducto(producto);

                    // get peso producto

                    dgvContenido.Rows.Add(linea.Id, 
                                          producto.Id + ". " + producto.Nombre, 
                                          linea.Cantidad, 
                                          linea.Pendiente,
                                          linea.Pendiente
                                          );
                }

            }
        }

        private void btnSeleccionarOC_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count != 0)
            {
                Controles_SeleccionarOC();

                Pedido pedido = new Pedido() { Id = long.Parse(dgvPedidos.SelectedRows[0].Cells["IdPedido"].Value.ToString()) };
                pedido = extras.GetPedido(pedido);

                dtpFechaEnvio.Value = DateTime.Parse(pedido.FechaEntrega).AddDays(-1);

                txtDestino.Text = extras.GetCD_Direccion(pedido.CD);
            }

        }

        private void dgvContenido_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvContenido.SelectedRows.Count != 0)
            {
                if (dgvContenido.SelectedRows[0].Cells["cBultosE"].Value.ToString() == "")
                    dgvContenido.SelectedRows[0].Cells["cBultosE"].Value = 0;

                decimal bultos = decimal.Parse(dgvContenido.SelectedRows[0].Cells["cBultosE"].Value.ToString());

                dgvContenido.SelectedRows[0].Cells["cUnidadesE"].Value = (bultos * 20);
            }
        }

        private void btnContinuarPedido_Click(object sender, EventArgs e)
        {
            Controles_ComenzarEnvio();
        }

        private void BtnGenerarIdPallet_Click(object sender, EventArgs e)
        {
            //string[] args = { "", "", "", "", "", "", "", "", "", "" };
            //args[0] = _pedidoSeleccionado.CD.ToString();

            //FrmReport frmReport = new FrmReport(_pedidoSeleccionado, args);
            //frmReport.Show();
        }

        private void btnFinalizarEnvio_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDescartarCambios_Click(object sender, EventArgs e)
        {

        }



        #region Funciones

        private void SetTable_Pedidos()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("IdPedido", Type.GetType("System.Int16"));
            dt.Columns.Add("Cliente", Type.GetType("System.String"));
            dt.Columns.Add("OC", Type.GetType("System.Int32"));
            dt.Columns.Add("CD", Type.GetType("System.Int16"));
            dt.Columns.Add("Fecha Entrega", Type.GetType("System.String"));
            dt.Columns.Add("Hora Entrega", Type.GetType("System.String"));
            dt.Columns.Add("Muelle", Type.GetType("System.String"));
            dt.Columns.Add("Reprog.", Type.GetType("System.Int16"));
            dt.Columns.Add("Cantidad", Type.GetType("System.Decimal"));
            dt.Columns.Add("Pendiente", Type.GetType("System.Decimal"));

            List<Pedido> list = extras.GetPedidos("ABIERTO", false);

            if (list.Count != 0)
            {
                foreach (Pedido pedido in list)
                {
                    Cliente cliente = extras.GetCliente(new Cliente() { Id = pedido.IdCliente });
                    //decimal cantidadBultos = extras.GetPedido_TotalBultosPedids(pedido);

                    dt.Rows.Add(pedido.Id, cliente.Id + ". " + cliente.Nombre, pedido.OC, pedido.CD, pedido.FechaEntrega,
                                        pedido.HoraEntrega, pedido.MuelleEntrega, pedido.Reprogramaciones, pedido.Total, pedido.Pendiente);
                }

                dgvPedidos.DataSource = dt;

                dgvPedidos.Columns["IdPedido"].Visible = false;
                dgvPedidos.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvPedidos.Columns["OC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvPedidos.Columns["CD"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvPedidos.Columns["Fecha Entrega"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvPedidos.Columns["Hora Entrega"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvPedidos.Columns["Muelle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvPedidos.Columns["Reprog."].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvPedidos.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvPedidos.Columns["Pendiente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            }
        }

        private void Controles_Inicio()
        {
            btnNuevoEnvio.Enabled = true;
            btnConfirmar.Enabled = false;
            btnVolver.Enabled = false;

            dgvPedidos.Enabled = false;
            btnSeleccionarOC.Enabled = false;

            dgvContenido.Enabled = false;
            btnComenzarEnvio.Enabled = false;

            dtpFechaEnvio.Enabled = false;
            txtRemito.ReadOnly = true;
            txtDestino.ReadOnly = true;
            cmbCantidadPallets.ReadOnly = true;
            dtpFechaVencimiento.Enabled = false;

            BtnGenerarIdPallet.Enabled = false;
            BtnGenerarRemito.Enabled = false;

            btnFinalizarEnvio.Enabled = false;
        }
        private void Controles_Nuevo()
        {
            btnNuevoEnvio.Enabled = false;
            btnConfirmar.Enabled = false;
            btnVolver.Enabled = true;

            dgvPedidos.Enabled = true;
            btnSeleccionarOC.Enabled = true;

            dgvContenido.Enabled = false;           
            btnComenzarEnvio.Enabled = false;

            dtpFechaEnvio.Enabled = false;
            txtRemito.ReadOnly = true;
            txtDestino.ReadOnly = true;
            cmbCantidadPallets.ReadOnly = true;
            dtpFechaVencimiento.Enabled = false;

            BtnGenerarIdPallet.Enabled = false;
            BtnGenerarRemito.Enabled = false;

            btnFinalizarEnvio.Enabled = false;
        }
        private void Controles_SeleccionarOC()
        {
            btnNuevoEnvio.Enabled = false;
            btnConfirmar.Enabled = false;
            btnVolver.Enabled = true;

            dgvPedidos.Enabled = false;
            btnSeleccionarOC.Enabled = false;

            dgvContenido.Enabled = true;
            btnComenzarEnvio.Enabled = true;

            dtpFechaEnvio.Enabled = false;
            txtRemito.ReadOnly = true;
            txtDestino.ReadOnly = true;
            cmbCantidadPallets.Enabled = false;
            dtpFechaVencimiento.Enabled = false;

            BtnGenerarIdPallet.Enabled = false;
            BtnGenerarRemito.Enabled = false;

            btnFinalizarEnvio.Enabled = false;
        }
        private void Controles_ComenzarEnvio()
        {
            btnNuevoEnvio.Enabled = false;
            btnConfirmar.Enabled = true;
            btnVolver.Enabled = true;

            dgvPedidos.Enabled = false;
            btnSeleccionarOC.Enabled = false;

            dgvContenido.Enabled = false;
            btnComenzarEnvio.Enabled = false;

            dtpFechaEnvio.Enabled = true;
            txtRemito.ReadOnly = false;
            txtDestino.ReadOnly = false;
            cmbCantidadPallets.Enabled = true;
            dtpFechaVencimiento.Enabled = true;

            BtnGenerarIdPallet.Enabled = true;
            BtnGenerarRemito.Enabled = true;

            btnFinalizarEnvio.Enabled = true;
        }








        #endregion

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //chequeos

            //Actualizo el estado del pedido seleccionado
            Pedido pedido = extras.GetPedido(new Pedido() { Id = long.Parse(dgvPedidos.SelectedRows[0].Cells["IdPedido"].Value.ToString()) });

            pedido.Estado = "ENTREGADO";

            Remito remito = new Remito()
            {
                Id = extras.GetRemito_Id() + 1,
                EmisionRecepcion = "EMISION",
                IdEmisor = 0,
                IdDestinatario = pedido.IdCliente,
                FechaEmision = dtpFechaEnvio.Value.AddDays(-1).ToString("yyyy-MM-dd"),
                FechaEntrega = dtpFechaEnvio.Value.ToString("yyyy-MM-dd"),
                Numero = txtRemito.Text,
                Estado = "ABIERTO",
                Observaciones = txtDestino.Text
            };

            List<LineaPedido> lineasPedido = new List<LineaPedido>();
            List<LineaRemito> lineasRemito = new List<LineaRemito>();
            List<MovimientoProducto> movimientosProducto = new List<MovimientoProducto>();

            foreach (DataGridViewRow row in dgvContenido.Rows)
            {
                LineaPedido lineaPedido = extras.GetLineaPedido(new LineaPedido() { Id = long.Parse(row.Cells["cId"].Value.ToString()) });

                //lineaPedido = decimal.Parse(row.Cells["cBultosE"].Value.ToString());
                //lineaPedido.UnidadesEntregadas = decimal.Parse(row.Cells["cUnidadesE"].Value.ToString());
                //lineaPedido.KilosEntregados = decimal.Parse(row.Cells["cKilosE"].Value.ToString());

                lineasPedido.Add(lineaPedido);

                LineaRemito lineaRemito = new LineaRemito()
                {
                    Id = extras.GetLineaRemito_Id() + 1,
                    IdRemito = remito.Id,
                    IdProducto = lineaPedido.IdProducto,
                    //Cantidad = lineaPedido.KilosEntregados,
                    Estado = "ABIERTO"
                };

                lineasRemito.Add(lineaRemito);

                MovimientoProducto movimiento = new MovimientoProducto()
                {
                    Id = extras.GetMovimientoProducto_Id() + 1,
                    IdProducto = lineaPedido.IdProducto,
                    TipoMovimiento = "ENTREGA",
                    //Cantidad = lineaPedido.KilosEntregados * -1,
                    Fecha = dtpFechaEnvio.Value.ToString("yyyy-MM-dd"),
                    Stock = 0,
                    Observaciones = "Remito " + remito.Numero
                };

                movimientosProducto.Add(movimiento);
            }

            extras.EditPedido(pedido, false);

            foreach (LineaPedido linea in lineasPedido)
            {
                extras.EditLineaPedido(linea);
            }

            extras.AddRemito(remito);
            extras.AddLineaRemito(lineasRemito);
            extras.AddMovimientoProducto(movimientosProducto);


            //Finalizo
            DescartarCambios();
            lblBarra1.Visible = false;
            this.Controles_Inicio();
            dgvPedidos.Focus();
            

            SetTable_Pedidos();

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            DescartarCambios();
            Controles_Inicio();
            dgvPedidos.Focus();
            SetTable_Pedidos();
        }


        public void DescartarCambios()
        {

            dgvPedidos.DataSource = null;
            dgvPedidos.Rows.Clear();
            dgvContenido.DataSource = null;
            dgvContenido.Rows.Clear();
            dtpFechaEnvio.Value = DateTime.Today;
            txtDestino.Text = "";
            txtRemito.Text = "";
            cmbCantidadPallets.Value = 1;
            dtpFechaVencimiento.Value = DateTime.Today;
            lblBarra1.Visible = false;
        }

        private void BtnGenerarRemito_Click(object sender, EventArgs e)
        {
            extras.Script_CompletarLineaPedido();
            MessageBox.Show("jeje");
        }
    }
}
