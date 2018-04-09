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
    public partial class MenuVentas : UserControl
    {
        private static MenuVentas _instance;

        private Extras extras = new Extras();

        public static MenuVentas Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MenuVentas();
                }

                return _instance;
            }
        }

        public MenuVentas()
        {
            InitializeComponent();
        }

        private void MenuVentas_Load(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcVentas.Instance))
            {
                bodyPanel.Controls.Add(UcVentas.Instance);
                UcVentas.Instance.Dock = DockStyle.Fill;
                UcVentas.Instance.BringToFront();
            }
            else
            {
                UcVentas.Instance.BringToFront();
            }

            btnVentas.BackColor = extras.COLOR_RED_REGULAR;
            btnCobranzas.BackColor = extras.COLOR_BLUE_REGULAR;
            btnCheques.BackColor = extras.COLOR_BLUE_REGULAR;
        }

 
        private void btnVentas_Click(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcVentas.Instance))
            {
                bodyPanel.Controls.Add(UcVentas.Instance);
                UcVentas.Instance.Dock = DockStyle.Fill;
                UcVentas.Instance.BringToFront();
            }
            else
            {
                UcVentas.Instance.BringToFront();
            }

            btnVentas.BackColor = extras.COLOR_RED_REGULAR;
            btnCobranzas.BackColor = extras.COLOR_BLUE_REGULAR;
            btnCheques.BackColor = extras.COLOR_BLUE_REGULAR;
        }

        private void btnCobranzas_Click(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcVentas_Cobranza.Instance))
            {
                bodyPanel.Controls.Add(UcVentas_Cobranza.Instance);
                UcVentas_Cobranza.Instance.Dock = DockStyle.Fill;
                UcVentas_Cobranza.Instance.BringToFront();
            }
            else
            {
                UcVentas_Cobranza.Instance.BringToFront();
            }

            btnVentas.BackColor = extras.COLOR_BLUE_REGULAR;
            btnCobranzas.BackColor = extras.COLOR_RED_REGULAR;
            btnCheques.BackColor = extras.COLOR_BLUE_REGULAR;
        }

        private void btnCheques_Click_1(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcVentas_Cheques.Instance))
            {
                bodyPanel.Controls.Add(UcVentas_Cheques.Instance);
                UcVentas_Cheques.Instance.Dock = DockStyle.Fill;
                UcVentas_Cheques.Instance.BringToFront();
            }
            else
            {
                UcVentas_Cheques.Instance.BringToFront();
            }

            btnVentas.BackColor = extras.COLOR_BLUE_REGULAR;
            btnCobranzas.BackColor = extras.COLOR_BLUE_REGULAR;
            btnCheques.BackColor = extras.COLOR_RED_REGULAR;
        }
    }
}
