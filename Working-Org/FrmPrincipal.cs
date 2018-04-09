using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Working_Org
{
    public partial class FrmPrincipal : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private Extras extras = new Extras();

        public FrmPrincipal()
        {
            InitializeComponent();
        }


        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            extras.TryConnection();

            if (!mainPanel.Controls.Contains(UcPrincipal.Instance))
            {
                mainPanel.Controls.Add(UcPrincipal.Instance);
                UcPrincipal.Instance.Dock = DockStyle.Fill;
                UcPrincipal.Instance.BringToFront();
            }
            else
            {
                UcPrincipal.Instance.BringToFront();
            }
        }

        private void FrmPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(MenuCompras.Instance))
            {
                mainPanel.Controls.Add(MenuCompras.Instance);
                MenuCompras.Instance.Dock = DockStyle.Fill;
                MenuCompras.Instance.BringToFront();
            }
            else
            {
                MenuCompras.Instance.BringToFront();
            }

            ResetButtons();
            btnCompras.BackColor = Color.FromArgb(25, 118, 210);
        }

        private void sidePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void titlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(MenuPedidos.Instance))
            {
                mainPanel.Controls.Add(MenuPedidos.Instance);
                MenuPedidos.Instance.Dock = DockStyle.Fill;
                MenuPedidos.Instance.BringToFront();
            }
            else
            {
                MenuPedidos.Instance.BringToFront();
            }

            ResetButtons();
            btnPedidos.BackColor = Color.FromArgb(25, 118, 210);
        }

        private void btnProduccion_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(MenuProduccion.Instance))
            {
                mainPanel.Controls.Add(MenuProduccion.Instance);
                MenuProduccion.Instance.Dock = DockStyle.Fill;
                MenuProduccion.Instance.BringToFront();
            }
            else
            {
                MenuProduccion.Instance.BringToFront();
            }

            ResetButtons();
            btnProduccion.BackColor = Color.FromArgb(25, 118, 210);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(MenuVentas.Instance))
            {
                mainPanel.Controls.Add(MenuVentas.Instance);
                MenuVentas.Instance.Dock = DockStyle.Fill;
                MenuVentas.Instance.BringToFront();
            }
            else
            {
                MenuVentas.Instance.BringToFront();
            }

            ResetButtons();
            btnVentas.BackColor = Color.FromArgb(25, 118, 210);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(MenuProducto.Instance))
            {
                mainPanel.Controls.Add(MenuProducto.Instance);
                MenuProducto.Instance.Dock = DockStyle.Fill;
                MenuProducto.Instance.BringToFront();
            }
            else
            {
                MenuProducto.Instance.BringToFront();
            }

            ResetButtons();
            btnProductos.BackColor = Color.FromArgb(25, 118, 210);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(MenuProveedor.Instance))
            {
                mainPanel.Controls.Add(MenuProveedor.Instance);
                MenuProveedor.Instance.Dock = DockStyle.Fill;
                MenuProveedor.Instance.BringToFront();
            }
            else
            {
                MenuProveedor.Instance.BringToFront();
            }

            ResetButtons();
            btnProveedores.BackColor = Color.FromArgb(25, 118, 210);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(MenuClientes.Instance))
            {
                mainPanel.Controls.Add(MenuClientes.Instance);
                MenuClientes.Instance.Dock = DockStyle.Fill;
                MenuClientes.Instance.BringToFront();
            }
            else
            {
                MenuClientes.Instance.BringToFront();
            }

            ResetButtons();
            btnClientes.BackColor = Color.FromArgb(25, 118, 210);
        }

        private void btnImpuestos_Click(object sender, EventArgs e)
        {

            if (!mainPanel.Controls.Contains(MenuClientes.Instance))
            {
                mainPanel.Controls.Add(MenuClientes.Instance);
                MenuClientes.Instance.Dock = DockStyle.Fill;
                MenuClientes.Instance.BringToFront();
            }
            else
            {
                MenuClientes.Instance.BringToFront();
            }

            ResetButtons();
            btnImpuestos.BackColor = Color.FromArgb(25, 118, 210);
        }

        private void btnInformes_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(UcInformes_A.Instance))
            {
                mainPanel.Controls.Add(UcInformes_A.Instance);
                UcInformes_A.Instance.Dock = DockStyle.Fill;
                UcInformes_A.Instance.BringToFront();
            }
            else
            {
                UcInformes_A.Instance.BringToFront();
            }

            ResetButtons();
            btnInformes.BackColor = Color.FromArgb(25, 118, 210);
        }


        private void ResetButtons()
        {
            btnPedidos.BackColor = Color.FromArgb(33, 150, 243);
            btnProduccion.BackColor = Color.FromArgb(33, 150, 243);
            btnCompras.BackColor = Color.FromArgb(33, 150, 243);
            btnVentas.BackColor = Color.FromArgb(33, 150, 243);
            btnClientes.BackColor = Color.FromArgb(33, 150, 243);
            btnProveedores.BackColor = Color.FromArgb(33, 150, 243);
            btnProductos.BackColor = Color.FromArgb(33, 150, 243);
            btnInformes.BackColor = Color.FromArgb(33, 150, 243);
            btnImpuestos.BackColor = Color.FromArgb(33, 150, 243);
        }

        private void picClose_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void picClose_MouseDown(object sender, MouseEventArgs e)
        {
            //picClose.Image = Bitmap.FromFile("C:\\close-button-v.png");
        }

        private void picClose_MouseLeave(object sender, EventArgs e)
        {
            //picClose.Image = Bitmap.FromFile("C:\\close-button-g.png");
        }

        private void picClose_MouseUp(object sender, MouseEventArgs e)
        {
            //picClose.Image = Bitmap.FromFile("C:\\close-button-g.png");
        }

        private void picClose_MouseEnter(object sender, EventArgs e)
        {
            //picClose.Image = Bitmap.FromFile("C:\\close-button-y.png");
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        




        //private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    pictureBox1.Image = Bitmap.FromFile("C:\\data\\Button2-PEDIDOS-d.png");
        //}

        //private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        //{
        //    pictureBox1.Image = Bitmap.FromFile("C:\\data\\Button2-PEDIDOS.png");
        //}
    }
}
