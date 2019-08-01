namespace prueba_lector_huellas
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ImgHuella = new System.Windows.Forms.PictureBox();
            this.btn_captura = new System.Windows.Forms.Button();
            this.lblRespuesta = new System.Windows.Forms.Label();
            this.lbl_mensaje = new System.Windows.Forms.Label();
            this.lbl_mensaje_2 = new System.Windows.Forms.Label();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarHuellaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgHuella)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(248, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ImgHuella
            // 
            this.ImgHuella.Location = new System.Drawing.Point(12, 111);
            this.ImgHuella.Name = "ImgHuella";
            this.ImgHuella.Size = new System.Drawing.Size(214, 208);
            this.ImgHuella.TabIndex = 1;
            this.ImgHuella.TabStop = false;
            // 
            // btn_captura
            // 
            this.btn_captura.Location = new System.Drawing.Point(12, 41);
            this.btn_captura.Name = "btn_captura";
            this.btn_captura.Size = new System.Drawing.Size(214, 49);
            this.btn_captura.TabIndex = 2;
            this.btn_captura.Text = "Iniciar captura";
            this.btn_captura.UseVisualStyleBackColor = true;
            this.btn_captura.Click += new System.EventHandler(this.btn_captura_Click);
            // 
            // lblRespuesta
            // 
            this.lblRespuesta.AutoSize = true;
            this.lblRespuesta.Location = new System.Drawing.Point(13, 326);
            this.lblRespuesta.Name = "lblRespuesta";
            this.lblRespuesta.Size = new System.Drawing.Size(40, 13);
            this.lblRespuesta.TabIndex = 3;
            this.lblRespuesta.Text = "reporte";
            // 
            // lbl_mensaje
            // 
            this.lbl_mensaje.AutoSize = true;
            this.lbl_mensaje.Location = new System.Drawing.Point(16, 359);
            this.lbl_mensaje.Name = "lbl_mensaje";
            this.lbl_mensaje.Size = new System.Drawing.Size(46, 13);
            this.lbl_mensaje.TabIndex = 4;
            this.lbl_mensaje.Text = "mensaje";
            // 
            // lbl_mensaje_2
            // 
            this.lbl_mensaje_2.AutoSize = true;
            this.lbl_mensaje_2.Location = new System.Drawing.Point(16, 388);
            this.lbl_mensaje_2.Name = "lbl_mensaje_2";
            this.lbl_mensaje_2.Size = new System.Drawing.Size(55, 13);
            this.lbl_mensaje_2.TabIndex = 5;
            this.lbl_mensaje_2.Text = "mensaje 2";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarHuellaToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // registrarHuellaToolStripMenuItem
            // 
            this.registrarHuellaToolStripMenuItem.Name = "registrarHuellaToolStripMenuItem";
            this.registrarHuellaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.registrarHuellaToolStripMenuItem.Text = "Registrar huella";
            this.registrarHuellaToolStripMenuItem.Click += new System.EventHandler(this.registrarHuellaToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 431);
            this.Controls.Add(this.lbl_mensaje_2);
            this.Controls.Add(this.lbl_mensaje);
            this.Controls.Add(this.lblRespuesta);
            this.Controls.Add(this.btn_captura);
            this.Controls.Add(this.ImgHuella);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgHuella)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox ImgHuella;
        private System.Windows.Forms.Button btn_captura;
        private System.Windows.Forms.Label lblRespuesta;
        private System.Windows.Forms.Label lbl_mensaje;
        private System.Windows.Forms.Label lbl_mensaje_2;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarHuellaToolStripMenuItem;
    }
}

