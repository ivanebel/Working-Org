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
    public partial class MenuClientes : UserControl
    {
        private static MenuClientes _instance;

        private Extras extras = new Extras();

        public static MenuClientes Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MenuClientes();
                }

                return _instance;
            }
        }

        public MenuClientes()
        {
            InitializeComponent();
        }

        private void MenuClientes_Load(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcClientes.Instance))
            {
                bodyPanel.Controls.Add(UcClientes.Instance);
                UcClientes.Instance.Dock = DockStyle.Fill;
                UcClientes.Instance.BringToFront();
            }
            else
            {
                UcClientes.Instance.BringToFront();
            }

            btnListaClientes.BackColor = extras.COLOR_RED_REGULAR;
            btnCuentaCorriente.BackColor = extras.COLOR_BLUE_REGULAR;
            btnCobranzas.BackColor = extras.COLOR_BLUE_REGULAR;

        }

        private void btnListaClientes_Click(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcClientes.Instance))
            {
                bodyPanel.Controls.Add(UcClientes.Instance);
                UcClientes.Instance.Dock = DockStyle.Fill;
                UcClientes.Instance.BringToFront();
            }
            else
            {
                UcClientes.Instance.BringToFront();
            }

            btnListaClientes.BackColor = extras.COLOR_RED_REGULAR;
            btnCuentaCorriente.BackColor = extras.COLOR_BLUE_REGULAR;
            btnCobranzas.BackColor = extras.COLOR_BLUE_REGULAR;
        }

        private void btnCuentaCorriente_Click(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcClientes_CuentaCorriente.Instance))
            {
                bodyPanel.Controls.Add(UcClientes_CuentaCorriente.Instance);
                UcClientes_CuentaCorriente.Instance.Dock = DockStyle.Fill;
                UcClientes_CuentaCorriente.Instance.BringToFront();
            }
            else
            {
                UcClientes_CuentaCorriente.Instance.BringToFront();
            }

            btnListaClientes.BackColor = extras.COLOR_BLUE_REGULAR;
            btnCuentaCorriente.BackColor = extras.COLOR_RED_REGULAR;
            btnCobranzas.BackColor = extras.COLOR_BLUE_REGULAR;
        }

        
    }
}
