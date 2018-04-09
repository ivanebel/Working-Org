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
    public partial class MenuProduccion : UserControl
    {
        private static MenuProduccion _instance;

        private Extras extras = new Extras();

        public static MenuProduccion Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MenuProduccion();
                }

                return _instance;
            }
        }

        public MenuProduccion()
        {
            InitializeComponent();
        }

        private void btnProduccion_Click(object sender, EventArgs e)
        {
            
        }

        private void MenuProduccion_Load(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcProduccion.Instance))
            {
                bodyPanel.Controls.Add(UcProduccion.Instance);
                UcProduccion.Instance.Dock = DockStyle.Fill;
                UcProduccion.Instance.BringToFront();
            }
            else
            {
                UcProduccion.Instance.BringToFront();
            }

            btnProduccionDiaria.BackColor = extras.COLOR_RED_REGULAR;
            btnLotes.BackColor = extras.COLOR_BLUE_REGULAR;
        }

        private void btnProduccionDiaria_Click(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcProduccion.Instance))
            {
                bodyPanel.Controls.Add(UcProduccion.Instance);
                UcProduccion.Instance.Dock = DockStyle.Fill;
                UcProduccion.Instance.BringToFront();
            }
            else
            {
                UcProduccion.Instance.BringToFront();
            }

            btnProduccionDiaria.BackColor = extras.COLOR_RED_REGULAR;
            btnLotes.BackColor = extras.COLOR_BLUE_REGULAR;
        }

        private void btnLotes_Click(object sender, EventArgs e)
        {
            if (!bodyPanel.Controls.Contains(UcLotes.Instance))
            {
                bodyPanel.Controls.Add(UcLotes.Instance);
                UcLotes.Instance.Dock = DockStyle.Fill;
                UcLotes.Instance.BringToFront();
            }
            else
            {
                UcLotes.Instance.BringToFront();
            }

            btnProduccionDiaria.BackColor = extras.COLOR_BLUE_REGULAR;
            btnLotes.BackColor = extras.COLOR_RED_REGULAR; 
        }
    }
}
