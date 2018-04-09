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
    public partial class UcProveedor_CuentaCorriente : UserControl
    {

        private static UcProveedor_CuentaCorriente _instance;

        private Extras extras = new Extras();
        
        public static UcProveedor_CuentaCorriente Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcProveedor_CuentaCorriente();
                }

                return _instance;
            }
        }
        public UcProveedor_CuentaCorriente()
        {
            InitializeComponent();
        }

        private void UcProveedor_CuentaCorriente_Load(object sender, EventArgs e)
        {
            Controles_Inicio();

            //SetTable_MovimientosProveedor();

            List<Proveedor> listaProveedores = extras.GetProveedores();

            if (listaProveedores.Count != 0)
            {
                foreach (Proveedor proveedor in listaProveedores)
                {
                    cmbProveedores.Items.Add(proveedor.Id + ". " + proveedor.Nombre + " (CUIT: " + proveedor.CUIT + ")");
                }
            }
        }


        
        private void cmbProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProveedores.SelectedItem != null)
            {
                //btnNuevo.Enabled = true;

                long idProveedor = extras.GetId(cmbProveedores.SelectedItem.ToString());
                Proveedor proveedor = new Proveedor() { Id = idProveedor };
                proveedor = extras.GetProveedor(proveedor);

                decimal saldo = decimal.Round(extras.GetProveedor_Saldo(proveedor), 2);

                txtSaldo.Text = saldo.ToString();

                SetTable_MovimientosProveedor(proveedor);

            }
            else
            {
                btnNuevo.Enabled = false;
            }




        }

        private void SetTable_MovimientosProveedor()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", Type.GetType("System.Int16"));
            dt.Columns.Add("Fecha", Type.GetType("System.String"));
            dt.Columns.Add("Documento", Type.GetType("System.String"));
            dt.Columns.Add("Monto", Type.GetType("System.Decimal"));
            //dt.Columns.Add("IVA", Type.GetType("System.Decimal"));
            //dt.Columns.Add("Impuestos", Type.GetType("System.Decimal"));
            //dt.Columns.Add("Total", Type.GetType("System.Decimal"));

            List<MovimientoProveedor> listaMovimientos = extras.GetMovimientoProveedores();

            dgvMovimientos.DataSource = null;
            dgvMovimientos.Rows.Clear();

            if (listaMovimientos.Count != 0)
            {
                foreach (MovimientoProveedor mov in listaMovimientos)
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

        private void SetTable_MovimientosProveedor(Proveedor proveedor)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", Type.GetType("System.Int16"));
            dt.Columns.Add("Fecha", Type.GetType("System.String"));
            dt.Columns.Add("Documento", Type.GetType("System.String"));
            dt.Columns.Add("Monto", Type.GetType("System.Decimal"));
            //dt.Columns.Add("IVA", Type.GetType("System.Decimal"));
            //dt.Columns.Add("Impuestos", Type.GetType("System.Decimal"));
            //dt.Columns.Add("Total", Type.GetType("System.Decimal"));

            List<MovimientoProveedor> listaMovimientos = extras.GetMovimientoProveedores(proveedor);

            dgvMovimientos.DataSource = null;
            dgvMovimientos.Rows.Clear();

            if (listaMovimientos.Count != 0)
            {
                foreach (MovimientoProveedor mov in listaMovimientos)
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

        private void dgvMovimientos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void Controles_Inicio()
        {
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnConfirmar.Enabled = false;
            btnVolver.Enabled = false;

            cmbProveedores.Enabled = true;
            //groupBox2.Enabled = false;
            dtpFecha.Enabled = false;
            cmbTipoDocumento.Enabled = false;
            txtNumDoc.ReadOnly = true;
            txtMonto.ReadOnly = true;
            txtImpuestos.Enabled = false;
            txtIva.Enabled = false;
            txtObservaciones.ReadOnly = true;
            txtTotal.Enabled = false;

            dgvMovimientos.Enabled = true;

            cmbProveedores.Focus();
        }

        private void Controles_Nuevo()
        {
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnConfirmar.Enabled = true;
            btnVolver.Enabled = true;

            cmbProveedores.Enabled = false;
            //groupBox2.Enabled = false;
            dtpFecha.Enabled = true;
            cmbTipoDocumento.Enabled = true;
            txtNumDoc.ReadOnly = false;
            txtMonto.ReadOnly = false;
            txtImpuestos.Enabled = false;
            txtIva.Enabled = false;
            txtObservaciones.ReadOnly = false;
            txtTotal.Enabled = false;

            dgvMovimientos.Enabled = false;

            dtpFecha.Focus();
        }

        public void DescartarCambios()
        {
            txtNumDoc.Text = "";
            txtMonto.Text = "";
            txtIva.Text = "";
            txtImpuestos.Text = "";
            txtObservaciones.Text = "";
            txtTotal.Text = "";

            cmbTipoDocumento.Items.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Controles_Nuevo();

            //cmbTipoDocumento.Items.Clear();
            cmbProveedores.Enabled = false;
            DescartarCambios();

            List<Tipos> tiposDocumento = extras.GetTipos("TIPODOCUMENTO");
            if (tiposDocumento.Count != 0)
            {
                foreach (Tipos tipo in tiposDocumento)
                {
                    if (tipo.Detalle != "no")
                        cmbTipoDocumento.Items.Add(tipo.Nombre);
                }
            }

            cmbTipoDocumento.Focus();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //chequeos
            if (cmbTipoDocumento.SelectedItem == null)
                return;

            //OJO


            MovimientoProveedor nuevoMovimiento = new MovimientoProveedor()
            {
                Id = extras.GetMovimientoProveedor_Id() + 1,
                IdProveedor = extras.GetId(cmbProveedores.SelectedItem.ToString()),
                CreditoDebito = GetIf_CreditoDebito(cmbTipoDocumento.SelectedItem.ToString()),
                Fecha = dtpFecha.Value.ToString("yyyy-MM-dd"),
                TipoDocumento = cmbTipoDocumento.SelectedItem.ToString(),
                NumDocumento = txtNumDoc.Text,
                Monto = decimal.Parse(txtMonto.Text),
                Observaciones = txtObservaciones.Text
            };


            extras.AddMovimientoProveedor(nuevoMovimiento);

            if (cmbProveedores.SelectedItem != null)
            {
                long idProveedor = extras.GetId(cmbProveedores.SelectedItem.ToString());
                Proveedor proveedor = new Proveedor() { Id = idProveedor };
                proveedor = extras.GetProveedor(proveedor);

                txtSaldo.Text = extras.GetProveedor_Saldo(proveedor).ToString();

                SetTable_MovimientosProveedor(proveedor);

            }

            DescartarCambios();

            Controles_Inicio();
        }

        private string GetIf_CreditoDebito(string tipoDocumento)
        {
            switch (tipoDocumento)
            {
                case "FACTURA A":
                    return "DEBITO";
                case "FACTURA B":
                    return "DEBITO";
                case "FACTURA C":
                    return "DEBITO";
                case "NOTA DE DEBITO":
                    return "DEBITO";
                case "NOTA DE CREDITO":
                    return "CREDITO";
                case "RECIBO":
                    return "CREDITO";
                default:
                    return "OJO";
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            DescartarCambios();
            Controles_Inicio();
        }
    }
}
