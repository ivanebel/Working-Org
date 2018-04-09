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
    public partial class UcInformes_A : UserControl
    {
        private static UcInformes_A _instance;

        private Extras extras = new Extras();

        public static UcInformes_A Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcInformes_A();
                }

                return _instance;
            }
        }

        public UcInformes_A()
        {
            InitializeComponent();
        }

        private void UcInformes_A_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            decimal costoTotal = extras.GetFinanzas_TotalCompras(dtpFechaDesde.Value, dtpFechaHasta.Value);
            decimal kilos = extras.GetFinanzas_TotalKgProducido(dtpFechaDesde.Value, dtpFechaHasta.Value);
            decimal costoKilo = costoTotal / kilos;

            lblCostoTotal.Text += costoTotal.ToString();
            lblKilosProducidos.Text += kilos.ToString();
            lblCostoKilo.Text += costoKilo.ToString();
        }
    }
}
