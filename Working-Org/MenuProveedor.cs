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
    public partial class MenuProveedor : UserControl
    {
        private static MenuProveedor _instance;

        private Extras extras = new Extras();

        public static MenuProveedor Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MenuProveedor();
                }

                return _instance;
            }
        }

        public MenuProveedor()
        {
            InitializeComponent();
        }

        private void MenuProveedor_Load(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcProveedor.Instance))
            {
                bodyPanel.Controls.Add(UcProveedor.Instance);
                UcProveedor.Instance.Dock = DockStyle.Fill;
                UcProveedor.Instance.BringToFront();
            }
            else
            {
                UcProveedor.Instance.BringToFront();
            }

            //extras.LoopControls(false, this);

            btnProveedores.BackColor = extras.COLOR_RED_REGULAR;
            btnCuentaCorriente.BackColor = extras.COLOR_BLUE_REGULAR;
            btnPagos.BackColor = extras.COLOR_BLUE_REGULAR;
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcProveedor.Instance))
            {
                bodyPanel.Controls.Add(UcProveedor.Instance);
                UcProveedor.Instance.Dock = DockStyle.Fill;
                UcProveedor.Instance.BringToFront();
            }
            else
            {
                UcProveedor.Instance.BringToFront();
            }

            btnProveedores.BackColor = extras.COLOR_RED_REGULAR;
            btnCuentaCorriente.BackColor = extras.COLOR_BLUE_REGULAR;
            btnPagos.BackColor = extras.COLOR_BLUE_REGULAR;
        }

        private void btnCuentaCorriente_Click_1(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcProveedor_CuentaCorriente.Instance))
            {
                bodyPanel.Controls.Add(UcProveedor_CuentaCorriente.Instance);
                UcProveedor_CuentaCorriente.Instance.Dock = DockStyle.Fill;
                UcProveedor_CuentaCorriente.Instance.BringToFront();
            }
            else
            {
                UcProveedor_CuentaCorriente.Instance.BringToFront();
            }

            btnProveedores.BackColor = extras.COLOR_BLUE_REGULAR;
            btnCuentaCorriente.BackColor = extras.COLOR_RED_REGULAR;
            btnPagos.BackColor = extras.COLOR_BLUE_REGULAR;
        }

        private void btnPagos_Click_1(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcProveedor_Pagos.Instance))
            {
                bodyPanel.Controls.Add(UcProveedor_Pagos.Instance);
                UcProveedor_Pagos.Instance.Dock = DockStyle.Fill;
                UcProveedor_Pagos.Instance.BringToFront();
            }
            else
            {
                UcProveedor_Pagos.Instance.BringToFront();
            }

            btnProveedores.BackColor = extras.COLOR_BLUE_REGULAR;
            btnCuentaCorriente.BackColor = extras.COLOR_BLUE_REGULAR;
            btnPagos.BackColor = extras.COLOR_RED_REGULAR;
        }
    }
}
