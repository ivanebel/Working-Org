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
    public partial class UcInformes_C : UserControl
    {
        private static UcInformes_C _instance;

        public static UcInformes_C Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcInformes_C();
                }

                return _instance;
            }
        }

        public UcInformes_C()
        {
            InitializeComponent();
        }

        private void UcInformes_C_Load(object sender, EventArgs e)
        {

        }
    }
}
