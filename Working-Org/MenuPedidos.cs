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
    public partial class MenuPedidos : UserControl
    {
        private static MenuPedidos _instance;

        private Extras extras = new Extras();

        public static MenuPedidos Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MenuPedidos();
                }

                return _instance;
            }
        }

        public MenuPedidos()
        {
            InitializeComponent();
        }

        private void MenuPedidos_Load(object sender, EventArgs e)
        {


            if (!bodyPanel.Controls.Contains(UcPedidos_Nuevo.Instance))
            {
                bodyPanel.Controls.Add(UcPedidos_Nuevo.Instance);
                UcPedidos_Nuevo.Instance.Dock = DockStyle.Fill;
                UcPedidos_Nuevo.Instance.BringToFront();
            }
            else
            {
                UcPedidos_Nuevo.Instance.BringToFront();
            }

            btnPedidosActuales.BackColor = extras.COLOR_RED_REGULAR;
            btnPedidosHistoricos.BackColor = extras.COLOR_BLUE_REGULAR;
            btnEnvios.BackColor = extras.COLOR_BLUE_REGULAR;
        }

        private void btnPedidosActuales_Click(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcPedidos_Nuevo.Instance))
            {
                bodyPanel.Controls.Add(UcPedidos_Nuevo.Instance);
                UcPedidos_Nuevo.Instance.Dock = DockStyle.Fill;
                UcPedidos_Nuevo.Instance.BringToFront();
            }
            else
            {
                UcPedidos_Nuevo.Instance.BringToFront();
            }

            btnPedidosActuales.BackColor = extras.COLOR_RED_REGULAR;
            btnPedidosHistoricos.BackColor = extras.COLOR_BLUE_REGULAR;
            btnEnvios.BackColor = extras.COLOR_BLUE_REGULAR;
        }

        private void btnPedidosHistoricos_Click(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcPedidos_Historicos.Instance))
            {
                bodyPanel.Controls.Add(UcPedidos_Historicos.Instance);
                UcPedidos_Historicos.Instance.Dock = DockStyle.Fill;
                UcPedidos_Historicos.Instance.BringToFront();
            }
            else
            {
                UcPedidos_Historicos.Instance.BringToFront();
            }

            btnPedidosActuales.BackColor = extras.COLOR_BLUE_REGULAR;
            btnPedidosHistoricos.BackColor = extras.COLOR_RED_REGULAR;
            btnEnvios.BackColor = extras.COLOR_BLUE_REGULAR;
        }

        private void btnEnvios_Click(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcPedidos_Envio.Instance))
            {
                bodyPanel.Controls.Add(UcPedidos_Envio.Instance);
                UcPedidos_Envio.Instance.Dock = DockStyle.Fill;
                UcPedidos_Envio.Instance.BringToFront();
            }
            else
            {
                UcPedidos_Envio.Instance.BringToFront();
            }

            btnPedidosActuales.BackColor = extras.COLOR_BLUE_REGULAR;
            btnPedidosHistoricos.BackColor = extras.COLOR_BLUE_REGULAR;
            btnEnvios.BackColor = extras.COLOR_RED_REGULAR;
        }
    }
}
