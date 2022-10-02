namespace Vista
{
    partial class Ayuda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ayuda));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.txtProductos = new System.Windows.Forms.Button();
            this.txtMarcas = new System.Windows.Forms.Button();
            this.txtUbicacion = new System.Windows.Forms.Button();
            this.hlpComuna = new System.Windows.Forms.Button();
            this.HlpCategoria = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(155, 536);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.txtProductos);
            this.panel2.Controls.Add(this.txtMarcas);
            this.panel2.Controls.Add(this.txtUbicacion);
            this.panel2.Controls.Add(this.hlpComuna);
            this.panel2.Controls.Add(this.HlpCategoria);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 155);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(155, 201);
            this.panel2.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.Location = new System.Drawing.Point(0, 150);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(155, 30);
            this.button3.TabIndex = 5;
            this.button3.Text = "Ventas";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // txtProductos
            // 
            this.txtProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtProductos.Location = new System.Drawing.Point(0, 120);
            this.txtProductos.Name = "txtProductos";
            this.txtProductos.Size = new System.Drawing.Size(155, 30);
            this.txtProductos.TabIndex = 4;
            this.txtProductos.Text = "Productos";
            this.txtProductos.UseVisualStyleBackColor = true;
            // 
            // txtMarcas
            // 
            this.txtMarcas.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtMarcas.Location = new System.Drawing.Point(0, 90);
            this.txtMarcas.Name = "txtMarcas";
            this.txtMarcas.Size = new System.Drawing.Size(155, 30);
            this.txtMarcas.TabIndex = 3;
            this.txtMarcas.Text = "Marcas";
            this.txtMarcas.UseVisualStyleBackColor = true;
            this.txtMarcas.Click += new System.EventHandler(this.txtMarcas_Click);
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtUbicacion.Location = new System.Drawing.Point(0, 60);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(155, 30);
            this.txtUbicacion.TabIndex = 2;
            this.txtUbicacion.Text = "Ubicacion";
            this.txtUbicacion.UseVisualStyleBackColor = true;
            this.txtUbicacion.Click += new System.EventHandler(this.txtUbicacion_Click);
            // 
            // hlpComuna
            // 
            this.hlpComuna.Dock = System.Windows.Forms.DockStyle.Top;
            this.hlpComuna.Location = new System.Drawing.Point(0, 30);
            this.hlpComuna.Name = "hlpComuna";
            this.hlpComuna.Size = new System.Drawing.Size(155, 30);
            this.hlpComuna.TabIndex = 1;
            this.hlpComuna.Text = "Comuna";
            this.hlpComuna.UseVisualStyleBackColor = true;
            this.hlpComuna.Click += new System.EventHandler(this.hlpComuna_Click);
            // 
            // HlpCategoria
            // 
            this.HlpCategoria.Dock = System.Windows.Forms.DockStyle.Top;
            this.HlpCategoria.Location = new System.Drawing.Point(0, 0);
            this.HlpCategoria.Name = "HlpCategoria";
            this.HlpCategoria.Size = new System.Drawing.Size(155, 30);
            this.HlpCategoria.TabIndex = 0;
            this.HlpCategoria.Text = "Categoria";
            this.HlpCategoria.UseVisualStyleBackColor = true;
            this.HlpCategoria.Click += new System.EventHandler(this.HlpCategoria_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 155);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(161, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(675, 512);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 491);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 45);
            this.button1.TabIndex = 4;
            this.button1.Text = "Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Ayuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 536);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Ayuda";
            this.Text = "Ayuda";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button txtMarcas;
        private System.Windows.Forms.Button txtUbicacion;
        private System.Windows.Forms.Button hlpComuna;
        private System.Windows.Forms.Button HlpCategoria;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button txtProductos;
        private System.Windows.Forms.Button button1;
    }
}