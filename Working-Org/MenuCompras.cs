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
    public partial class MenuCompras : UserControl
    {
        private static MenuCompras _instance;

        private Extras extras = new Extras();

        public static MenuCompras Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MenuCompras();
                }

                return _instance;
            }
        }

        public MenuCompras()
        {
            InitializeComponent();
        }

        private void bodyPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuCompras_Load(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcCompras_OrdenDeCompra.Instance))
            {
                bodyPanel.Controls.Add(UcCompras_OrdenDeCompra.Instance);
                UcCompras_OrdenDeCompra.Instance.Dock = DockStyle.Fill;
                UcCompras_OrdenDeCompra.Instance.BringToFront();
            }
            else
            {
                UcCompras_OrdenDeCompra.Instance.BringToFront();
            }

            btnOrdenesDeCompra.BackColor = extras.COLOR_RED_REGULAR;
            btnListaCompras.BackColor = extras.COLOR_BLUE_REGULAR;
            btnFacturas.BackColor = extras.COLOR_BLUE_REGULAR;
            btnPresupuestos.BackColor = extras.COLOR_BLUE_REGULAR;
        }


        private void btnPresupuestos_Click_1(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcCompras_Presupuesto.Instance))
            {
                bodyPanel.Controls.Add(UcCompras_Presupuesto.Instance);
                UcCompras_Presupuesto.Instance.Dock = DockStyle.Fill;
                UcCompras_Presupuesto.Instance.BringToFront();
            }
            else
            {
                UcCompras_Presupuesto.Instance.BringToFront();
            }

            btnOrdenesDeCompra.BackColor = extras.COLOR_BLUE_REGULAR;
            btnListaCompras.BackColor = extras.COLOR_BLUE_REGULAR;
            btnFacturas.BackColor = extras.COLOR_BLUE_REGULAR;
            btnPresupuestos.BackColor = extras.COLOR_RED_REGULAR;
        }

        private void btnbtnOrdenesDeCompra_Click(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcCompras_OrdenDeCompra.Instance))
            {
                bodyPanel.Controls.Add(UcCompras_OrdenDeCompra.Instance);
                UcCompras_OrdenDeCompra.Instance.Dock = DockStyle.Fill;
                UcCompras_OrdenDeCompra.Instance.BringToFront();
            }
            else
            {
                UcCompras_OrdenDeCompra.Instance.BringToFront();
            }

            btnOrdenesDeCompra.BackColor = extras.COLOR_BLUE_REGULAR;
            btnListaCompras.BackColor = extras.COLOR_BLUE_REGULAR;
            btnFacturas.BackColor = extras.COLOR_BLUE_REGULAR;
            btnPresupuestos.BackColor = extras.COLOR_BLUE_REGULAR;
        }

        private void btnListaCompras_Click(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcCompras_Facturas.Instance))
            {
                bodyPanel.Controls.Add(UcCompras_Facturas.Instance);
                UcCompras_Facturas.Instance.Dock = DockStyle.Fill;
                UcCompras_Facturas.Instance.BringToFront();
            }
            else
            {
                UcCompras_Facturas.Instance.BringToFront();
            }

            btnOrdenesDeCompra.BackColor = extras.COLOR_BLUE_REGULAR;
            btnListaCompras.BackColor = extras.COLOR_RED_REGULAR;
            btnFacturas.BackColor = extras.COLOR_BLUE_REGULAR;
            btnPresupuestos.BackColor = extras.COLOR_BLUE_REGULAR;
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcCompras_Factura.Instance))
            {
                bodyPanel.Controls.Add(UcCompras_Factura.Instance);
                UcCompras_Factura.Instance.Dock = DockStyle.Fill;
                UcCompras_Factura.Instance.BringToFront();
            }
            else
            {
                UcCompras_Factura.Instance.BringToFront();
            }

            btnOrdenesDeCompra.BackColor = extras.COLOR_BLUE_REGULAR;
            btnListaCompras.BackColor = extras.COLOR_BLUE_REGULAR;
            btnFacturas.BackColor = extras.COLOR_RED_REGULAR;
            btnPresupuestos.BackColor = extras.COLOR_BLUE_REGULAR;
        }
    }
}
