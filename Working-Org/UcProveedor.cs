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
    public partial class UcProveedor : UserControl
    {
        private static UcProveedor _instance;
        private Extras extras = new Extras();
        private bool isEdit = false;
        
        public static UcProveedor Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcProveedor();
                }

                return _instance;
            }
        }

        public UcProveedor()
        {
            InitializeComponent();
        }

        private void UcProveedor_Load(object sender, EventArgs e)
        {
            Controles_Inicio();

            List<Tipos> listaTipos = extras.GetTipos("TIPOPROVEEDOR");
            foreach (Tipos tipo in listaTipos)
                cmbTipo.Items.Add(tipo.Nombre);



            //SetTable_Proveedores();

        }


        private void SetTable_Proveedores()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Nombre", System.Type.GetType("System.String"));
            dt.Columns.Add("CUIT", System.Type.GetType("System.String"));
            dt.Columns.Add("Tipo", System.Type.GetType("System.String"));
            dt.Columns.Add("Email", System.Type.GetType("System.String"));
            dt.Columns.Add("Telefono", System.Type.GetType("System.String"));

            List<Proveedor> listaProveedores = extras.GetProveedores();

            if (listaProveedores.Count != 0)
            {
                foreach (Proveedor p in listaProveedores)
                {
                    dt.Rows.Add(p.Id, p.Nombre, p.CUIT, p.TipoProveedor, p.Email, p.Telefono);
                }
            }

            dgvProveedores.DataSource = dt;
            // 40, 50, 65

            dgvProveedores.Columns["Id"].Visible = false;
            dgvProveedores.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProveedores.Columns["CUIT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvProveedores.Columns["Tipo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvProveedores.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvProveedores.Columns["Telefono"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }


        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            Controles_NuevoProveedor();

            txtNombre.Text = "";
            txtCuit.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtObservaciones.Text = "";

            txtNombre.Focus();
        }

        private void dgvProveedores_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count != 0)
            {
                btnEditar.Enabled = true;

                long idProveedor = long.Parse(dgvProveedores.SelectedRows[0].Cells["Id"].Value.ToString());
                Proveedor proveedor = new Proveedor() { Id = idProveedor };
                proveedor = extras.GetProveedor(proveedor);

                txtNombre.Text = proveedor.Nombre;
                txtCuit.Text = proveedor.CUIT;
                txtEmail.Text = proveedor.Email;
                txtTelefono.Text = proveedor.Telefono;
                txtObservaciones.Text = proveedor.Observaciones;

                int i = GetIndexOfItem(proveedor.TipoProveedor);
                cmbTipo.SelectedIndex = i;
            }
            else
            {
                btnEditar.Enabled = false;
            }
        }

        private void Controles_Inicio()
        {
            txtNombre.ReadOnly = true;
            txtCuit.ReadOnly = true;
            cmbTipo.Enabled = false;
            txtEmail.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            txtObservaciones.ReadOnly = true;

            dgvProveedores.Enabled = true;

            btnEditar.Enabled = false;
            btnConfirmar.Enabled = false;
            btnVolver.Enabled = false;
        }

        private void Controles_NuevoProveedor()
        {
            txtNombre.ReadOnly = false;
            txtCuit.ReadOnly = false;
            cmbTipo.Enabled = true;
            txtEmail.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtObservaciones.ReadOnly = false;

            dgvProveedores.Enabled = false;

            btnEditar.Enabled = false;
            btnConfirmar.Enabled = true;
            btnVolver.Enabled = true;
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            //chequeos

            if (!isEdit)
            {
                Proveedor proveedor = new Proveedor()
                {
                    Id = extras.GetProveedor_Id() + 1,
                    Nombre = txtNombre.Text,
                    CUIT = txtCuit.Text,
                    TipoProveedor = cmbTipo.SelectedItem.ToString(),
                    Email = txtEmail.Text,
                    Telefono = txtTelefono.Text,
                    Observaciones = txtObservaciones.Text
                };

                extras.AddProveedor(proveedor);
            }
            else
            {
                long idProveedor = long.Parse(dgvProveedores.SelectedRows[0].Cells["Id"].Value.ToString());

                Proveedor proveedor = new Proveedor()
                {
                    Id = idProveedor,
                    Nombre = txtNombre.Text,
                    CUIT = txtCuit.Text,
                    TipoProveedor = cmbTipo.SelectedItem.ToString(),
                    Email = txtEmail.Text,
                    Telefono = txtTelefono.Text,
                    Observaciones = txtObservaciones.Text
                };

                extras.EditProveedor(proveedor);
            }
            
            Controles_Inicio();
            DescartarCambios();
            SetTable_Proveedores();
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            isEdit = true;
            Controles_NuevoProveedor();

        }

        public void DescartarCambios()
        {
            txtNombre.Text = "";
            txtCuit.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtObservaciones.Text = "";
            txtTelefono.Text = "";
            dgvProveedores.Rows.Clear();
            cmbTipo.SelectedItem = null;
        }

        private int GetIndexOfItem(string str)
        {
            for (int i=0; i <= cmbTipo.Items.Count - 1; i++)
            {
                if (cmbTipo.Items[i].ToString() == str)
                {
                    return i;
                }
            }

            return -1;
        }

        private bool ExecChequeos()
        {
            if (cmbTipo.SelectedItem == null)
                return false;

            if (txtNombre.Text == "")
                return false;

            return true;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //chequeos

            if (!ExecChequeos())
                return;



            if (!isEdit)
            {
                if (!extras.CkConfirmacion("ingresar un nuevo proveedor"))
                    return;

                Proveedor proveedor = new Proveedor()
                {
                    Id = extras.GetProveedor_Id() + 1,
                    Nombre = txtNombre.Text,
                    CUIT = txtCuit.Text,
                    TipoProveedor = cmbTipo.SelectedItem.ToString(),
                    Email = txtEmail.Text,
                    Telefono = txtTelefono.Text,
                    Observaciones = txtObservaciones.Text
                };

                extras.AddProveedor(proveedor);
            }
            else
            {
                long idProveedor = long.Parse(dgvProveedores.SelectedRows[0].Cells["Id"].Value.ToString());

                Proveedor proveedor = new Proveedor()
                {
                    Id = idProveedor,
                    Nombre = txtNombre.Text,
                    CUIT = txtCuit.Text,
                    TipoProveedor = cmbTipo.SelectedItem.ToString(),
                    Email = txtEmail.Text,
                    Telefono = txtTelefono.Text,
                    Observaciones = txtObservaciones.Text
                };

                extras.EditProveedor(proveedor);
            }

            Controles_Inicio();
            DescartarCambios();
            SetTable_Proveedores();
        }

        private void btnDescartarCambios_Click(object sender, EventArgs e)
        {

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}