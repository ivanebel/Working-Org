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
    public partial class UcCompras_Presupuesto : UserControl
    {
        private static UcCompras_Presupuesto _instance;


        public static UcCompras_Presupuesto Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcCompras_Presupuesto();
                }

                return _instance;
            }
        }

        public UcCompras_Presupuesto()
        {
            InitializeComponent();
        }

        private void UcCompras_Presupuesto_Load(object sender, EventArgs e)
        {

        }
    }
}
