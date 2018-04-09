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
    public partial class UcLotes : UserControl
    {
        private static UcLotes _instance;

        public static UcLotes Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UcLotes();
                }

                return _instance;
            }
        }

        public UcLotes()
        {
            InitializeComponent();
        }

        private void UcLotes_Load(object sender, EventArgs e)
        {

        }
    }
}
