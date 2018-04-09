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
    public partial class MenuProducto : UserControl
    {
        private static MenuProducto _instance;

        private Extras extras = new Extras();

        public static MenuProducto Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MenuProducto();
                }

                return _instance;
            }
        }


        public MenuProducto()
        {
            InitializeComponent();
        }

        private void MenuProducto_Load(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcProductos.Instance))
            {
                bodyPanel.Controls.Add(UcProductos.Instance);
                UcProductos.Instance.Dock = DockStyle.Fill;
                UcProductos.Instance.BringToFront();
            }
            else
            {
                UcProductos.Instance.BringToFront();
            }

            btnListaProductos.BackColor = extras.COLOR_RED_REGULAR;
            btnMovimientos.BackColor = extras.COLOR_BLUE_REGULAR;
            btnRecibirProductos.BackColor = extras.COLOR_BLUE_REGULAR;
        }

        private void btnListaProductos_Click(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcProductos.Instance))
            {
                bodyPanel.Controls.Add(UcProductos.Instance);
                UcProductos.Instance.Dock = DockStyle.Fill;
                UcProductos.Instance.BringToFront();
            }
            else
            {
                UcProductos.Instance.BringToFront();
            }

            btnListaProductos.BackColor = extras.COLOR_RED_REGULAR;
            btnMovimientos.BackColor = extras.COLOR_BLUE_REGULAR;
            btnRecibirProductos.BackColor = extras.COLOR_BLUE_REGULAR;

            UcProductos_Recibir.Instance.DescartarCambios();
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcProductos_Movimientos.Instance))
            {
                bodyPanel.Controls.Add(UcProductos_Movimientos.Instance);
                UcProductos_Movimientos.Instance.Dock = DockStyle.Fill;
                UcProductos_Movimientos.Instance.BringToFront();
            }
            else
            {
                UcProductos_Movimientos.Instance.BringToFront();
            }

            btnListaProductos.BackColor = extras.COLOR_BLUE_REGULAR;
            btnMovimientos.BackColor = extras.COLOR_RED_REGULAR;
            btnRecibirProductos.BackColor = extras.COLOR_BLUE_REGULAR;
        }

        private void btnRecibirProductos_Click(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcProductos_Recibir.Instance))
            {
                bodyPanel.Controls.Add(UcProductos_Recibir.Instance);
                UcProductos_Recibir.Instance.Dock = DockStyle.Fill;
                UcProductos_Recibir.Instance.BringToFront();
            }
            else
            {
                UcProductos_Recibir.Instance.BringToFront();
            }

            btnListaProductos.BackColor = extras.COLOR_BLUE_REGULAR;
            btnMovimientos.BackColor = extras.COLOR_BLUE_REGULAR;
            btnRecibirProductos.BackColor = extras.COLOR_RED_REGULAR;
        }
    }
}
