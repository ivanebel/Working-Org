namespace Working_Org
{
    partial class MenuProduccion
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bodyPanel = new System.Windows.Forms.Panel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.btnLotes = new System.Windows.Forms.Button();
            this.btnProduccionDiaria = new System.Windows.Forms.Button();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bodyPanel
            // 
            this.bodyPanel.BackColor = System.Drawing.Color.White;
            this.bodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyPanel.Location = new System.Drawing.Point(0, 100);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Size = new System.Drawing.Size(900, 730);
            this.bodyPanel.TabIndex = 7;
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(192)))));
            this.menuPanel.Controls.Add(this.btnLotes);
            this.menuPanel.Controls.Add(this.btnProduccionDiaria);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(900, 100);
            this.menuPanel.TabIndex = 6;
            // 
            // btnLotes
            // 
            this.btnLotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnLotes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLotes.FlatAppearance.BorderSize = 0;
            this.btnLotes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnLotes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(96)))));
            this.btnLotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLotes.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLotes.ForeColor = System.Drawing.Color.White;
            this.btnLotes.Location = new System.Drawing.Point(454, 28);
            this.btnLotes.Name = "btnLotes";
            this.btnLotes.Size = new System.Drawing.Size(186, 45);
            this.btnLotes.TabIndex = 44;
            this.btnLotes.Text = "Lotes";
            this.btnLotes.UseVisualStyleBackColor = false;
            this.btnLotes.Click += new System.EventHandler(this.btnLotes_Click);
            // 
            // btnProduccionDiaria
            // 
            this.btnProduccionDiaria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnProduccionDiaria.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnProduccionDiaria.FlatAppearance.BorderSize = 0;
            this.btnProduccionDiaria.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnProduccionDiaria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(96)))));
            this.btnProduccionDiaria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduccionDiaria.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduccionDiaria.ForeColor = System.Drawing.Color.White;
            this.btnProduccionDiaria.Location = new System.Drawing.Point(259, 28);
            this.btnProduccionDiaria.Name = "btnProduccionDiaria";
            this.btnProduccionDiaria.Size = new System.Drawing.Size(186, 45);
            this.btnProduccionDiaria.TabIndex = 42;
            this.btnProduccionDiaria.Text = "Producción Diaria";
            this.btnProduccionDiaria.UseVisualStyleBackColor = false;
            this.btnProduccionDiaria.Click += new System.EventHandler(this.btnProduccionDiaria_Click);
            // 
            // MenuProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bodyPanel);
            this.Controls.Add(this.menuPanel);
            this.Name = "MenuProduccion";
            this.Size = new System.Drawing.Size(900, 830);
            this.Load += new System.EventHandler(this.MenuProduccion_Load);
            this.menuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bodyPanel;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button btnLotes;
        private System.Windows.Forms.Button btnProduccionDiaria;
    }
}
