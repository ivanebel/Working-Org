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
    public partial class UcPrincipal : UserControl
    {
        private static UcPrincipal _instance;

        public static UcPrincipal Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcPrincipal();
                }

                return _instance;
            }
        }

        public UcPrincipal()
        {
            InitializeComponent();
        }

        private void UcPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
