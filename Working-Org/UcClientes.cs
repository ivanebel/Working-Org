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
    public partial class UcClientes : UserControl
    {
        private static UcClientes _instance;

        private Extras extras = new Extras();

        public static UcClientes Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcClientes();
                }

                return _instance;
            }
        }

        public UcClientes()
        {
            InitializeComponent();
        }

        private void UcClientes_Load(object sender, EventArgs e)
        {
            Controles_Inicio();


            List<Tipos> listaTipos = extras.GetTipos("TIPOCLIENTE");
            foreach (Tipos tipo in listaTipos)
                cmbTipo.Items.Add(tipo.Nombre);
            

            SetTable_Clientes();
            dgvClientes.Focus();
        }

        private void dgvClientes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dgvClientes.SelectedRows[0];

                long idCliente = long.Parse(row.Cells["Id"].Value.ToString());
                Cliente cliente = new Cliente() { Id = idCliente };
                cliente = extras.GetCliente(cliente);

                txtNombre.Text = cliente.Nombre;
                txtCuit.Text = cliente.CUIT;
                txtEmail.Text = cliente.Email;
                txtTelefono.Text = cliente.Telefono;
                txtObservaciones.Text = cliente.Observaciones;
                //cmb

                for (int i = 0; i <= cmbTipo.Items.Count - 1; i++)
                {
                    string cmb = cmbTipo.Items[i].ToString();

                    if(cmb == cliente.TipoCliente)
                    {
                        cmbTipo.SelectedIndex = i;
                    }
                }

                btnEdit.Enabled = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Controles_Nuevo();
            DescartarCambios();

            lblBarra1.Location = new Point(60, 50);
            lblBarra1.Visible = true;


            cmbTipo.SelectedIndex = 0;
            txtNombre.Focus();
            
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            //chequeos

            if (!extras.CkConfirmacion("agregar este proveedor"))
                return;

            Cliente cliente = new Cliente()
            {
                Id = extras.GetCliente_Id() + 1,
                Nombre = txtNombre.Text,
                CUIT = txtCuit.Text,
                Email = txtEmail.Text,
                Telefono = txtTelefono.Text,
                Observaciones = txtObservaciones.Text,
                TipoCliente = cmbTipo.SelectedItem.ToString(),

            };

            extras.AddCliente(cliente);

            DescartarCambios();
            SetTable_Clientes();
            Controles_Inicio();
        }

        private void SetTable_Clientes()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", Type.GetType("System.Int16"));
            dt.Columns.Add("Cliente", Type.GetType("System.String"));
            dt.Columns.Add("CUIT", Type.GetType("System.String"));
            dt.Columns.Add("Teléfono", Type.GetType("System.String"));
            dt.Columns.Add("E-Mail", Type.GetType("System.String"));
            //dt.Columns.Add("Tipo")

            List<Cliente> listaClientes = extras.GetClientes();

            if (listaClientes.Count != 0)
            { 
                foreach (Cliente cliente in listaClientes)
                {
                    dt.Rows.Add(cliente.Id, cliente.Nombre, cliente.CUIT, cliente.Telefono, cliente.Email);
                }
            }

            dgvClientes.DataSource = dt;

            dgvClientes.Columns["Id"].Visible = false;

            dgvClientes.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvClientes.Columns["CUIT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientes.Columns["Teléfono"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientes.Columns["E-Mail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvClientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvClientes.CellBorderStyle = DataGridViewCellBorderStyle.None;

        }

        private void Controles_Inicio()
        {
            btnNew.Enabled = true;
            btnEdit.Enabled = false;
            btnGuardarCambios.Enabled = false;
            btnDescartarCambios.Enabled = false;

            txtNombre.ReadOnly = true;
            txtCuit.ReadOnly = true;
            txtDireccion.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            txtObservaciones.ReadOnly = true;
            cmbTipo.Enabled = false;

            dgvClientes.Enabled = true;
        }

        private void Controles_Nuevo()
        {
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnGuardarCambios.Enabled = true;
            btnDescartarCambios.Enabled = true;

            txtNombre.ReadOnly = false;
            txtCuit.ReadOnly = false;
            txtDireccion.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtObservaciones.ReadOnly = false;
            cmbTipo.Enabled = true;

            dgvClientes.Enabled = false;
        }

        public void DescartarCambios()
        {
            txtNombre.Text = "";
            txtCuit.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtObservaciones.Text = "";
            txtTelefono.Text = "";
            cmbTipo.SelectedItem = null;
        }

        private void btnDescartarCambios_Click(object sender, EventArgs e)
        {
            DescartarCambios();
            Controles_Inicio();
            dgvClientes.Focus();
        }



        private void picSave_Click(object sender, EventArgs e)
        {

        }

        private void picSave_MouseEnter(object sender, EventArgs e)
        {
            //picSave.Image = Bitmap.FromFile("C:\\data\\picarrow-h.png");
        }

        private void picSave_MouseLeave(object sender, EventArgs e)
        {
            //picSave.Image = Bitmap.FromFile("C:\\data\\picarrow.png");
        }

        private void picSave_MouseDown(object sender, MouseEventArgs e)
        {
            //picSave.Image = Bitmap.FromFile("C:\\data\\picarrow-b.png");
        }

        private void txtObservaciones_TextChanged(object sender, EventArgs e)
        {
           
        }

    

        private void btnVolver_Click(object sender, EventArgs e)
        {
            DescartarCambios();
            Controles_Inicio();

            lblBarra1.Visible = false;
            

            dgvClientes.Focus();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //chequeos

            if (!extras.CkConfirmacion("agregar este proveedor"))
                return;

            Cliente cliente = new Cliente()
            {
                Id = extras.GetCliente_Id() + 1,
                Nombre = txtNombre.Text,
                CUIT = txtCuit.Text,
                Email = txtEmail.Text,
                Telefono = txtTelefono.Text,
                Observaciones = txtObservaciones.Text,
                TipoCliente = cmbTipo.SelectedItem.ToString(),

            };

            extras.AddCliente(cliente);

            DescartarCambios();
            SetTable_Clientes();
            Controles_Inicio();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            lblBarra1.Location = new Point(175, 50);
            lblBarra1.Visible = true;
        }



        //private void picSave_MouseDown(object sender, MouseEventArgs e)
        //{
        //    picSave.Image = Bitmap.FromFile("C:\\data\\circle-save-d.png");
        //}

        //private void picSave_MouseUp(object sender, MouseEventArgs e)
        //{
        //    picSave.Image = Bitmap.FromFile("C:\\data\\circle-save.png");
        //}


    }
}
