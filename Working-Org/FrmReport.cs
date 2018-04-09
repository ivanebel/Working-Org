using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Working_Org
{
    public partial class FrmReport : Form
    {
        public Pedido Pedido;
        public string[] Argumentos;

        private string _tipoReporte;

        public FrmReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicializa en base a un PEDIDO para generar la Información del Pallet
        /// </summary>
        /// <param name="pedido"></param>
        public FrmReport(Pedido pedido, string[] args)
        {
            this.Pedido = pedido;
            this.Argumentos = args;

            this._tipoReporte = "INFOPALLET";

            InitializeComponent();
        }

        private void FrmMovimientoProducto_Load(object sender, EventArgs e)
        {

            switch (this._tipoReporte)
            {
                case "INFOPALLET":
                    label1.Text = Pedido.FechaEmision.ToString();
                    break;

                default:
                    break;
            }
//            this.reportViewer.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reportViewer.LocalReport.ReportPath = "C:\\Users\\Ivan Ebel\\Source\\Repos\\Working-Org\\Working-Org\\Report_InfoPallet.rdlc";
            reportViewer.RefreshReport();
        }
    }
}
