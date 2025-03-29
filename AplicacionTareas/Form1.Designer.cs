namespace AplicacionTareas
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BTN_ELIMINAR = new System.Windows.Forms.Button();
            this.BTN_ACTUALIZAR = new System.Windows.Forms.Button();
            this.txt_cuerpo = new System.Windows.Forms.TextBox();
            this.txt_estado = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_fecha_final = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_fecha_inicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.BTN_GUARDAR = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ListPendientes = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(907, 450);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.BTN_ELIMINAR);
            this.panel3.Controls.Add(this.BTN_ACTUALIZAR);
            this.panel3.Controls.Add(this.txt_cuerpo);
            this.panel3.Controls.Add(this.txt_estado);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txt_fecha_final);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txt_fecha_inicio);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txt_nombre);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel3.Location = new System.Drawing.Point(265, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(642, 450);
            this.panel3.TabIndex = 1;
            // 
            // BTN_ELIMINAR
            // 
            this.BTN_ELIMINAR.Location = new System.Drawing.Point(382, 415);
            this.BTN_ELIMINAR.Name = "BTN_ELIMINAR";
            this.BTN_ELIMINAR.Size = new System.Drawing.Size(105, 23);
            this.BTN_ELIMINAR.TabIndex = 10;
            this.BTN_ELIMINAR.Text = "&Eliminar Tarea";
            this.BTN_ELIMINAR.UseVisualStyleBackColor = true;
            this.BTN_ELIMINAR.Click += new System.EventHandler(this.BTN_ELIMINAR_Click);
            // 
            // BTN_ACTUALIZAR
            // 
            this.BTN_ACTUALIZAR.Location = new System.Drawing.Point(512, 415);
            this.BTN_ACTUALIZAR.Name = "BTN_ACTUALIZAR";
            this.BTN_ACTUALIZAR.Size = new System.Drawing.Size(112, 23);
            this.BTN_ACTUALIZAR.TabIndex = 1;
            this.BTN_ACTUALIZAR.Text = "&Guardar Cambios";
            this.BTN_ACTUALIZAR.UseVisualStyleBackColor = true;
            this.BTN_ACTUALIZAR.Click += new System.EventHandler(this.BTN_ACTUALIZAR_Click);
            // 
            // txt_cuerpo
            // 
            this.txt_cuerpo.Location = new System.Drawing.Point(18, 61);
            this.txt_cuerpo.Multiline = true;
            this.txt_cuerpo.Name = "txt_cuerpo";
            this.txt_cuerpo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_cuerpo.Size = new System.Drawing.Size(606, 348);
            this.txt_cuerpo.TabIndex = 9;
            // 
            // txt_estado
            // 
            this.txt_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_estado.FormattingEnabled = true;
            this.txt_estado.Location = new System.Drawing.Point(503, 34);
            this.txt_estado.Name = "txt_estado";
            this.txt_estado.Size = new System.Drawing.Size(121, 21);
            this.txt_estado.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(500, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Estado";
            // 
            // txt_fecha_final
            // 
            this.txt_fecha_final.Location = new System.Drawing.Point(338, 34);
            this.txt_fecha_final.Name = "txt_fecha_final";
            this.txt_fecha_final.Size = new System.Drawing.Size(149, 20);
            this.txt_fecha_final.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Final";
            // 
            // txt_fecha_inicio
            // 
            this.txt_fecha_inicio.Location = new System.Drawing.Point(166, 34);
            this.txt_fecha_inicio.Name = "txt_fecha_inicio";
            this.txt_fecha_inicio.Size = new System.Drawing.Size(149, 20);
            this.txt_fecha_inicio.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Inicial";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre (No repetir nombres)";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(18, 34);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(100, 20);
            this.txt_nombre.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 450);
            this.panel2.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(265, 450);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Controls.Add(this.BTN_GUARDAR);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(257, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Todos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(251, 381);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // BTN_GUARDAR
            // 
            this.BTN_GUARDAR.Location = new System.Drawing.Point(45, 390);
            this.BTN_GUARDAR.Name = "BTN_GUARDAR";
            this.BTN_GUARDAR.Size = new System.Drawing.Size(134, 23);
            this.BTN_GUARDAR.TabIndex = 10;
            this.BTN_GUARDAR.Text = "&Nueva Tarea";
            this.BTN_GUARDAR.UseVisualStyleBackColor = true;
            this.BTN_GUARDAR.Click += new System.EventHandler(this.BTN_GUARDAR_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ListPendientes);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(257, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pendientes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // ListPendientes
            // 
            this.ListPendientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.ListPendientes.FormattingEnabled = true;
            this.ListPendientes.Location = new System.Drawing.Point(3, 3);
            this.ListPendientes.Name = "ListPendientes";
            this.ListPendientes.Size = new System.Drawing.Size(251, 381);
            this.ListPendientes.TabIndex = 1;
            this.ListPendientes.SelectedIndexChanged += new System.EventHandler(this.ListPendientes_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "&Crear txt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nota Tareas";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox txt_estado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker txt_fecha_final;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txt_fecha_inicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_cuerpo;
        private System.Windows.Forms.Button BTN_GUARDAR;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button BTN_ACTUALIZAR;
        private System.Windows.Forms.Button BTN_ELIMINAR;
        private System.Windows.Forms.ListBox ListPendientes;
        private System.Windows.Forms.Button button1;
    }
}

