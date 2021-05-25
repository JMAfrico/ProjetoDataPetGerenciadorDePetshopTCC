namespace Consultas_medicas.Formularios
{
    partial class Form_consultaVeterinario
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.picture_fechar = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rd_menos3dias = new System.Windows.Forms.RadioButton();
            this.rd_todos_dias = new System.Windows.Forms.RadioButton();
            this.rd_3dias = new System.Windows.Forms.RadioButton();
            this.rd_hoje = new System.Windows.Forms.RadioButton();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.cb_veterinario = new System.Windows.Forms.ComboBox();
            this.dtConsultas = new System.Windows.Forms.DataGridView();
            this.sub_menu_cliente = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.diagnósticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoDiagnósticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarDiagnósticosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_fechar)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtConsultas)).BeginInit();
            this.sub_menu_cliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btn_buscar);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.cb_veterinario);
            this.panel1.Controls.Add(this.dtConsultas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(893, 398);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(646, 355);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(235, 36);
            this.button1.TabIndex = 168;
            this.button1.Text = "Lista de diagnósticos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Teal;
            this.panel3.Controls.Add(this.picture_fechar);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(889, 33);
            this.panel3.TabIndex = 167;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDown);
            // 
            // picture_fechar
            // 
            this.picture_fechar.BackColor = System.Drawing.Color.Teal;
            this.picture_fechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picture_fechar.Image = global::Consultas_medicas.Properties.Resources.fechar;
            this.picture_fechar.Location = new System.Drawing.Point(8, 3);
            this.picture_fechar.Name = "picture_fechar";
            this.picture_fechar.Size = new System.Drawing.Size(25, 25);
            this.picture_fechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_fechar.TabIndex = 138;
            this.picture_fechar.TabStop = false;
            this.picture_fechar.Click += new System.EventHandler(this.picture_fechar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(386, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(148, 19);
            this.label10.TabIndex = 2;
            this.label10.Text = "Consultas agendadas";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rd_menos3dias);
            this.groupBox1.Controls.Add(this.rd_todos_dias);
            this.groupBox1.Controls.Add(this.rd_3dias);
            this.groupBox1.Controls.Add(this.rd_hoje);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Location = new System.Drawing.Point(390, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 51);
            this.groupBox1.TabIndex = 166;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data";
            // 
            // rd_menos3dias
            // 
            this.rd_menos3dias.AutoSize = true;
            this.rd_menos3dias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rd_menos3dias.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_menos3dias.ForeColor = System.Drawing.Color.DarkViolet;
            this.rd_menos3dias.Location = new System.Drawing.Point(18, 17);
            this.rd_menos3dias.Name = "rd_menos3dias";
            this.rd_menos3dias.Size = new System.Drawing.Size(69, 22);
            this.rd_menos3dias.TabIndex = 168;
            this.rd_menos3dias.Text = "- 3 Dias";
            this.rd_menos3dias.UseVisualStyleBackColor = true;
            // 
            // rd_todos_dias
            // 
            this.rd_todos_dias.AutoSize = true;
            this.rd_todos_dias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rd_todos_dias.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_todos_dias.ForeColor = System.Drawing.Color.Aqua;
            this.rd_todos_dias.Location = new System.Drawing.Point(279, 17);
            this.rd_todos_dias.Name = "rd_todos_dias";
            this.rd_todos_dias.Size = new System.Drawing.Size(60, 22);
            this.rd_todos_dias.TabIndex = 167;
            this.rd_todos_dias.Text = "Todas";
            this.rd_todos_dias.UseVisualStyleBackColor = true;
            // 
            // rd_3dias
            // 
            this.rd_3dias.AutoSize = true;
            this.rd_3dias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rd_3dias.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_3dias.ForeColor = System.Drawing.Color.Chartreuse;
            this.rd_3dias.Location = new System.Drawing.Point(184, 17);
            this.rd_3dias.Name = "rd_3dias";
            this.rd_3dias.Size = new System.Drawing.Size(71, 22);
            this.rd_3dias.TabIndex = 2;
            this.rd_3dias.Text = "+ 3 Dias";
            this.rd_3dias.UseVisualStyleBackColor = true;
            // 
            // rd_hoje
            // 
            this.rd_hoje.AutoSize = true;
            this.rd_hoje.Checked = true;
            this.rd_hoje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rd_hoje.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_hoje.ForeColor = System.Drawing.Color.Orange;
            this.rd_hoje.Location = new System.Drawing.Point(112, 17);
            this.rd_hoje.Name = "rd_hoje";
            this.rd_hoje.Size = new System.Drawing.Size(54, 22);
            this.rd_hoje.TabIndex = 1;
            this.rd_hoje.TabStop = true;
            this.rd_hoje.Text = "Hoje";
            this.rd_hoje.UseVisualStyleBackColor = true;
            // 
            // btn_buscar
            // 
            this.btn_buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_buscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_buscar.FlatAppearance.BorderSize = 2;
            this.btn_buscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buscar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar.ForeColor = System.Drawing.Color.White;
            this.btn_buscar.Location = new System.Drawing.Point(772, 48);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(109, 72);
            this.btn_buscar.TabIndex = 165;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.label16.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label16.Location = new System.Drawing.Point(27, 81);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 19);
            this.label16.TabIndex = 163;
            this.label16.Text = "Veterinário:";
            // 
            // cb_veterinario
            // 
            this.cb_veterinario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.cb_veterinario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_veterinario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cb_veterinario.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_veterinario.ForeColor = System.Drawing.Color.White;
            this.cb_veterinario.FormattingEnabled = true;
            this.cb_veterinario.Location = new System.Drawing.Point(131, 73);
            this.cb_veterinario.Name = "cb_veterinario";
            this.cb_veterinario.Size = new System.Drawing.Size(233, 27);
            this.cb_veterinario.TabIndex = 164;
            this.cb_veterinario.SelectedIndexChanged += new System.EventHandler(this.cb_veterinario_SelectedIndexChanged);
            // 
            // dtConsultas
            // 
            this.dtConsultas.AllowUserToAddRows = false;
            this.dtConsultas.AllowUserToDeleteRows = false;
            this.dtConsultas.AllowUserToResizeColumns = false;
            this.dtConsultas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Lime;
            this.dtConsultas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtConsultas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtConsultas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtConsultas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.dtConsultas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtConsultas.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dtConsultas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtConsultas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtConsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtConsultas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtConsultas.EnableHeadersVisualStyles = false;
            this.dtConsultas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.dtConsultas.Location = new System.Drawing.Point(21, 126);
            this.dtConsultas.Name = "dtConsultas";
            this.dtConsultas.RowHeadersVisible = false;
            this.dtConsultas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.LimeGreen;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.dtConsultas.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtConsultas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtConsultas.Size = new System.Drawing.Size(860, 224);
            this.dtConsultas.TabIndex = 125;
            this.dtConsultas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtConsultas_MouseDown);
            // 
            // sub_menu_cliente
            // 
            this.sub_menu_cliente.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diagnósticoToolStripMenuItem});
            this.sub_menu_cliente.Name = "sub_menu_cliente";
            this.sub_menu_cliente.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sub_menu_cliente.Size = new System.Drawing.Size(138, 26);
            // 
            // diagnósticoToolStripMenuItem
            // 
            this.diagnósticoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoDiagnósticoToolStripMenuItem,
            this.visualizarDiagnósticosToolStripMenuItem});
            this.diagnósticoToolStripMenuItem.Name = "diagnósticoToolStripMenuItem";
            this.diagnósticoToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.diagnósticoToolStripMenuItem.Text = "Diagnóstico";
            // 
            // novoDiagnósticoToolStripMenuItem
            // 
            this.novoDiagnósticoToolStripMenuItem.Name = "novoDiagnósticoToolStripMenuItem";
            this.novoDiagnósticoToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.novoDiagnósticoToolStripMenuItem.Text = "Novo Diagnóstico";
            this.novoDiagnósticoToolStripMenuItem.Click += new System.EventHandler(this.novoDiagnósticoToolStripMenuItem_Click);
            // 
            // visualizarDiagnósticosToolStripMenuItem
            // 
            this.visualizarDiagnósticosToolStripMenuItem.Name = "visualizarDiagnósticosToolStripMenuItem";
            this.visualizarDiagnósticosToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.visualizarDiagnósticosToolStripMenuItem.Text = "Visualizar Diagnósticos";
            this.visualizarDiagnósticosToolStripMenuItem.Visible = false;
            // 
            // Form_consultaVeterinario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(893, 398);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_consultaVeterinario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultas por veterinario";
            this.Load += new System.EventHandler(this.Form_consultaVeterinario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_fechar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtConsultas)).EndInit();
            this.sub_menu_cliente.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtConsultas;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cb_veterinario;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rd_todos_dias;
        private System.Windows.Forms.RadioButton rd_3dias;
        private System.Windows.Forms.RadioButton rd_hoje;
        private System.Windows.Forms.RadioButton rd_menos3dias;
        private System.Windows.Forms.ContextMenuStrip sub_menu_cliente;
        private System.Windows.Forms.ToolStripMenuItem diagnósticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoDiagnósticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarDiagnósticosToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox picture_fechar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
    }
}