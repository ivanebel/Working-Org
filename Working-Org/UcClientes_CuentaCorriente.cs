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
    public partial class UcClientes_CuentaCorriente : UserControl
    {
        private static UcClientes_CuentaCorriente _instance;

        private Extras extras = new Extras();

        public static UcClientes_CuentaCorriente Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcClientes_CuentaCorriente();
                }

                return _instance;
            }
        }

        public UcClientes_CuentaCorriente()
        {
            InitializeComponent();
        }

        private void UcClientes_CuentaCorriente_Load(object sender, EventArgs e)
        {
            Controles_Inicio();

            List<Cliente> listaClientes = extras.GetClientes();

            if(listaClientes.Count != 0)
            {
                foreach (Cliente cliente in listaClientes)
                {
                    cmbClientes.Items.Add(cliente.Id + ". " + cliente.Nombre + " (CUIT " + cliente.CUIT + ")");
                }

                cmbClientes.SelectedIndex = 0;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Controles_Nuevo();
        }



        private void Controles_Inicio()
        {
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;

            cmbClientes.Enabled = true;

            dtpFecha.Enabled = false;
            cmbTipoDocumento.Enabled = false;
            txtNumDoc.ReadOnly = true;
            txtMonto.ReadOnly = true;
            txtIva.ReadOnly = true;
            txtImpuestos.ReadOnly = true;
            txtTotal.ReadOnly = true;
            txtObservaciones.ReadOnly = true;
        }

        private void Controles_Nuevo()
        {
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnConfirmar.Enabled = true;
            btnVolver.Enabled = true;

            cmbClientes.Enabled = false;

            dtpFecha.Enabled = true;
            cmbTipoDocumento.Enabled = true;
            txtNumDoc.ReadOnly = false;
            txtMonto.ReadOnly = false;
            txtIva.ReadOnly = false;
            txtImpuestos.ReadOnly = false;
            txtTotal.ReadOnly = true;
            txtObservaciones.ReadOnly = false;
        }

        public void DescartarCambios()
        {
            dgvMovimientos.Rows.Clear();

            dtpFecha.Value = DateTime.Today;
            txtNumDoc.Text = "";
            txtMonto.Text = "";
            txtIva.Text = "";
            txtImpuestos.Text = "";
            txtTotal.Text = "";
            txtObservaciones.Text = "";

        }

        private void SetTable_Movimientos(Cliente cliente)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", Type.GetType("System.Int16"));
            dt.Columns.Add("Fecha", Type.GetType("System.String"));
            dt.Columns.Add("Documento", Type.GetType("System.String"));
            dt.Columns.Add("Monto", Type.GetType("System.Decimal"));
            //dt.Columns.Add("IVA", Type.GetType("System.Decimal"));
            //dt.Columns.Add("Impuestos", Type.GetType("System.Decimal"));
            //dt.Columns.Add("Total", Type.GetType("System.Decimal"));

            List<MovimientoCliente> listaMovimientos = extras.GetMovimientoClientes(cliente);

            dgvMovimientos.DataSource = null;
            dgvMovimientos.Rows.Clear();
            
            if (listaMovimientos.Count != 0)
            {
                foreach (MovimientoCliente mov in listaMovimientos)
                {
                    dt.Rows.Add(mov.Id, mov.Fecha, mov.TipoDocumento + " " + mov.NumDocumento, mov.Monto);
                }

                dgvMovimientos.DataSource = dt;

                dgvMovimientos.Columns["Id"].Visible = false;
                dgvMovimientos.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMovimientos.Columns["Documento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMovimientos.Columns["Monto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            long idCliente = extras.GetId(cmbClientes.SelectedItem.ToString());

            btnNuevo.Enabled = true;

            Cliente cliente = new Cliente() { Id = idCliente };
            cliente = extras.GetCliente(cliente);

            

            lblTelefono.Text = "Teléfono: " + cliente.Telefono;
            lblEmail.Text = "E-Mail: " + cliente.Email;

            SetTable_Movimientos(cliente);

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            DescartarCambios();
        }
    }
}
