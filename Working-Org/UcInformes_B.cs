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
    public partial class UcInformes_B : UserControl
    {
        private static UcInformes_B _instance;

        public static UcInformes_B Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcInformes_B();
                }

                return _instance;
            }
        }

        public UcInformes_B()
        {
            InitializeComponent();
        }

        private void UcInformes_B_Load(object sender, EventArgs e)
        {

        }
    }
}
