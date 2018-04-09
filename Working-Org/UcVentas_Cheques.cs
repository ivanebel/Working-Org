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
    public partial class UcVentas_Cheques : UserControl
    {
        private static UcVentas_Cheques _instance;

        private Extras extras = new Extras();

        public static UcVentas_Cheques Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcVentas_Cheques();
                }

                return _instance;
            }
        }

        public UcVentas_Cheques()
        {
            InitializeComponent();
        }

        private void UcVentas_Cobranza_Load(object sender, EventArgs e)
        {
            Controles_Inicio();
            SetTable_Cheques();
        }

        private void SetTable_Cheques()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", Type.GetType("System.Int16"));
            dt.Columns.Add("Emisor", Type.GetType("System.String"));
            dt.Columns.Add("Banco", Type.GetType("System.String"));
            dt.Columns.Add("Tipo", Type.GetType("System.String"));
            dt.Columns.Add("Fecha Emisión", Type.GetType("System.String"));
            dt.Columns.Add("Fecha Cobro", Type.GetType("System.String"));
            dt.Columns.Add("Monto", Type.GetType("System.Decimal"));
            dt.Columns.Add("Ubicación", Type.GetType("System.String"));

            List<Cheque> listaCheques = extras.GetCheques();

            if (listaCheques.Count != 0)
            {
                foreach (Cheque cheque in listaCheques)
                {
                    Cliente cliente = new Cliente() { Id = cheque.IdCliente };

                    if (cheque.IdCliente != 0)
                    {
                        cliente = extras.GetCliente(cliente);
                    }
                    else
                    {
                        cliente.Nombre = "WORKING SRL";
                    }

                    dt.Rows.Add(cheque.Id, cliente.Nombre, cheque.Banco, cheque.Tipo, cheque.FechaEmision, cheque.FechaCobro, cheque.Monto, cheque.Ubicacion);
                }
            }

            dgvCheques.DataSource = dt;

            dgvCheques.Columns["Id"].Visible = false;

            dgvCheques.Columns["Emisor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCheques.Columns["Banco"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCheques.Columns["Tipo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCheques.Columns["Fecha Emisión"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCheques.Columns["Fecha Cobro"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCheques.Columns["Monto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCheques.Columns["Ubicación"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


        }

        private void Controles_Inicio()
        {
            btnNew.Enabled = true;
            btnEdit.Enabled = false;
            btnConfirmar.Enabled = false;
            btnVolver.Enabled = false;

            cmbBancos.Enabled = false;
            txtEmisor.ReadOnly = true;
            txtNumero.ReadOnly = true;
            txtMonto.ReadOnly = true;
            dtpFechaEmisionCheque.Enabled = false;
            dtpFechaCobroCheque.Enabled = false;

            dgvCheques.Enabled = true;
        }

        private void Controles_Nuevo()
        {
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnConfirmar.Enabled = true;
            btnVolver.Enabled = true;

            cmbBancos.Enabled = true;
            txtEmisor.ReadOnly = false;
            txtNumero.ReadOnly = false;
            txtMonto.ReadOnly = false;
            dtpFechaEmisionCheque.Enabled = true;
            dtpFechaCobroCheque.Enabled = true;

            dgvCheques.Enabled = false;
        }
    }
}
