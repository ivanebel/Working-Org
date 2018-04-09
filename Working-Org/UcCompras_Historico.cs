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
    public partial class UcCompras_Facturas : UserControl
    {
        private static UcCompras_Facturas _instance;

        public static UcCompras_Facturas Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcCompras_Facturas();
                }

                return _instance;
            }
        }

        public UcCompras_Facturas()
        {
            InitializeComponent();
        }

        private void UcCompras_Historico_Load(object sender, EventArgs e)
        {

        }
    }
}
