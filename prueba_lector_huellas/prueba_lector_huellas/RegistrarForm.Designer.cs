namespace prueba_lector_huellas
{
    partial class RegistrarForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.txt_estado = new System.Windows.Forms.RichTextBox();
            this.check_uno = new System.Windows.Forms.CheckBox();
            this.check_dos = new System.Windows.Forms.CheckBox();
            this.check_tres = new System.Windows.Forms.CheckBox();
            this.check_cuatro = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.img_huella = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_huella)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(279, 55);
            this.button1.TabIndex = 0;
            this.button1.Text = "Registrar huella";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_estado
            // 
            this.txt_estado.Enabled = false;
            this.txt_estado.Location = new System.Drawing.Point(12, 213);
            this.txt_estado.Name = "txt_estado";
            this.txt_estado.Size = new System.Drawing.Size(280, 223);
            this.txt_estado.TabIndex = 1;
            this.txt_estado.Text = "";
            // 
            // check_uno
            // 
            this.check_uno.AutoSize = true;
            this.check_uno.Location = new System.Drawing.Point(174, 22);
            this.check_uno.Name = "check_uno";
            this.check_uno.Size = new System.Drawing.Size(71, 17);
            this.check_uno.TabIndex = 2;
            this.check_uno.Text = "Lectura 1";
            this.check_uno.UseVisualStyleBackColor = true;
            // 
            // check_dos
            // 
            this.check_dos.AutoSize = true;
            this.check_dos.Location = new System.Drawing.Point(174, 49);
            this.check_dos.Name = "check_dos";
            this.check_dos.Size = new System.Drawing.Size(71, 17);
            this.check_dos.TabIndex = 3;
            this.check_dos.Text = "Lectura 2";
            this.check_dos.UseVisualStyleBackColor = true;
            // 
            // check_tres
            // 
            this.check_tres.AutoSize = true;
            this.check_tres.Location = new System.Drawing.Point(174, 76);
            this.check_tres.Name = "check_tres";
            this.check_tres.Size = new System.Drawing.Size(71, 17);
            this.check_tres.TabIndex = 4;
            this.check_tres.Text = "Lectura 3";
            this.check_tres.UseVisualStyleBackColor = true;
            // 
            // check_cuatro
            // 
            this.check_cuatro.AutoSize = true;
            this.check_cuatro.Location = new System.Drawing.Point(174, 103);
            this.check_cuatro.Name = "check_cuatro";
            this.check_cuatro.Size = new System.Drawing.Size(71, 17);
            this.check_cuatro.TabIndex = 5;
            this.check_cuatro.Text = "Lectura 4";
            this.check_cuatro.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.img_huella);
            this.groupBox1.Controls.Add(this.check_uno);
            this.groupBox1.Controls.Add(this.check_cuatro);
            this.groupBox1.Controls.Add(this.check_dos);
            this.groupBox1.Controls.Add(this.check_tres);
            this.groupBox1.Location = new System.Drawing.Point(13, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 133);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lecturas";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(173, 442);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 39);
            this.button2.TabIndex = 7;
            this.button2.Text = "SALIR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // img_huella
            // 
            this.img_huella.Location = new System.Drawing.Point(13, 22);
            this.img_huella.Name = "img_huella";
            this.img_huella.Size = new System.Drawing.Size(100, 98);
            this.img_huella.TabIndex = 6;
            this.img_huella.TabStop = false;
            // 
            // RegistrarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 493);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_estado);
            this.Controls.Add(this.button1);
            this.Name = "RegistrarForm";
            this.Text = "RegistrarForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_huella)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox txt_estado;
        private System.Windows.Forms.CheckBox check_uno;
        private System.Windows.Forms.CheckBox check_dos;
        private System.Windows.Forms.CheckBox check_tres;
        private System.Windows.Forms.CheckBox check_cuatro;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox img_huella;
    }
}