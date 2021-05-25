namespace Consultas_medicas
{
    partial class form_prodServ_cliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_nome_cliente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_total_geral = new System.Windows.Forms.Label();
            this.dt_itens_servicos1 = new System.Windows.Forms.DataGridView();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_data = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_codigo = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txt_cod = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_hora = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cb_status_pagamento = new System.Windows.Forms.ComboBox();
            this.txt_troco = new System.Windows.Forms.TextBox();
            this.txt_total_pagar = new System.Windows.Forms.TextBox();
            this.cb_forma_pagamento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_dinheiro = new System.Windows.Forms.TextBox();
            this.btn_efetuar_pagamento = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_status_pagamento = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.picture_fechar = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dt_itens_servicos1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_fechar)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_nome_cliente
            // 
            this.lbl_nome_cliente.AutoSize = true;
            this.lbl_nome_cliente.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nome_cliente.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_nome_cliente.Location = new System.Drawing.Point(83, 73);
            this.lbl_nome_cliente.Name = "lbl_nome_cliente";
            this.lbl_nome_cliente.Size = new System.Drawing.Size(14, 19);
            this.lbl_nome_cliente.TabIndex = 1;
            this.lbl_nome_cliente.Text = "-";
            this.lbl_nome_cliente.TextChanged += new System.EventHandler(this.lbl_nome_cliente_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(15, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(19, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total:";
            // 
            // lbl_total_geral
            // 
            this.lbl_total_geral.AutoSize = true;
            this.lbl_total_geral.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_geral.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_total_geral.Location = new System.Drawing.Point(67, 19);
            this.lbl_total_geral.Name = "lbl_total_geral";
            this.lbl_total_geral.Size = new System.Drawing.Size(14, 19);
            this.lbl_total_geral.TabIndex = 7;
            this.lbl_total_geral.Text = "-";
            // 
            // dt_itens_servicos1
            // 
            this.dt_itens_servicos1.AllowUserToAddRows = false;
            this.dt_itens_servicos1.AllowUserToDeleteRows = false;
            this.dt_itens_servicos1.AllowUserToResizeColumns = false;
            this.dt_itens_servicos1.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Lime;
            this.dt_itens_servicos1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dt_itens_servicos1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dt_itens_servicos1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dt_itens_servicos1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.dt_itens_servicos1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dt_itens_servicos1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_itens_servicos1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dt_itens_servicos1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_itens_servicos1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dt_itens_servicos1.EnableHeadersVisualStyles = false;
            this.dt_itens_servicos1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.dt_itens_servicos1.Location = new System.Drawing.Point(12, 99);
            this.dt_itens_servicos1.Name = "dt_itens_servicos1";
            this.dt_itens_servicos1.RowHeadersVisible = false;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Calibri", 11.25F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle15.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.dt_itens_servicos1.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dt_itens_servicos1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_itens_servicos1.Size = new System.Drawing.Size(624, 312);
            this.dt_itens_servicos1.TabIndex = 10;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(524, 2);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(140, 20);
            this.txtCliente.TabIndex = 12;
            this.txtCliente.Visible = false;
            this.txtCliente.TextChanged += new System.EventHandler(this.txtCliente_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(356, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 19);
            this.label5.TabIndex = 13;
            this.label5.Text = "Data:";
            // 
            // lbl_data
            // 
            this.lbl_data.AutoSize = true;
            this.lbl_data.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_data.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_data.Location = new System.Drawing.Point(400, 40);
            this.lbl_data.Name = "lbl_data";
            this.lbl_data.Size = new System.Drawing.Size(14, 19);
            this.lbl_data.TabIndex = 14;
            this.lbl_data.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(15, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 19);
            this.label6.TabIndex = 16;
            this.label6.Text = "Consulta:";
            // 
            // lbl_codigo
            // 
            this.lbl_codigo.AutoSize = true;
            this.lbl_codigo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_codigo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_codigo.Location = new System.Drawing.Point(90, 44);
            this.lbl_codigo.Name = "lbl_codigo";
            this.lbl_codigo.Size = new System.Drawing.Size(14, 19);
            this.lbl_codigo.TabIndex = 17;
            this.lbl_codigo.Text = "-";
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(524, 28);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(140, 20);
            this.txtData.TabIndex = 15;
            this.txtData.Visible = false;
            this.txtData.TextChanged += new System.EventHandler(this.txtData_TextChanged);
            // 
            // txt_cod
            // 
            this.txt_cod.Location = new System.Drawing.Point(524, 54);
            this.txt_cod.Name = "txt_cod";
            this.txt_cod.Size = new System.Drawing.Size(140, 20);
            this.txt_cod.TabIndex = 18;
            this.txt_cod.Visible = false;
            this.txt_cod.TextChanged += new System.EventHandler(this.txt_cod_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(703, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Pesquisa nome/data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_hora
            // 
            this.lbl_hora.AutoSize = true;
            this.lbl_hora.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hora.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_hora.Location = new System.Drawing.Point(404, 71);
            this.lbl_hora.Name = "lbl_hora";
            this.lbl_hora.Size = new System.Drawing.Size(14, 19);
            this.lbl_hora.TabIndex = 21;
            this.lbl_hora.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(356, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 19);
            this.label4.TabIndex = 20;
            this.label4.Text = "Hora:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.cb_status_pagamento);
            this.panel1.Controls.Add(this.txt_troco);
            this.panel1.Controls.Add(this.txt_total_pagar);
            this.panel1.Controls.Add(this.cb_forma_pagamento);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lbl_total_geral);
            this.panel1.Controls.Add(this.txt_dinheiro);
            this.panel1.Controls.Add(this.btn_efetuar_pagamento);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Location = new System.Drawing.Point(659, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 312);
            this.panel1.TabIndex = 22;
            // 
            // cb_status_pagamento
            // 
            this.cb_status_pagamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.cb_status_pagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_status_pagamento.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cb_status_pagamento.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_status_pagamento.ForeColor = System.Drawing.Color.White;
            this.cb_status_pagamento.FormattingEnabled = true;
            this.cb_status_pagamento.Location = new System.Drawing.Point(144, 16);
            this.cb_status_pagamento.Name = "cb_status_pagamento";
            this.cb_status_pagamento.Size = new System.Drawing.Size(116, 27);
            this.cb_status_pagamento.TabIndex = 183;
            this.cb_status_pagamento.Visible = false;
            // 
            // txt_troco
            // 
            this.txt_troco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.txt_troco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_troco.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_troco.ForeColor = System.Drawing.Color.LawnGreen;
            this.txt_troco.Location = new System.Drawing.Point(86, 212);
            this.txt_troco.Name = "txt_troco";
            this.txt_troco.Size = new System.Drawing.Size(100, 31);
            this.txt_troco.TabIndex = 199;
            // 
            // txt_total_pagar
            // 
            this.txt_total_pagar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.txt_total_pagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_total_pagar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_total_pagar.ForeColor = System.Drawing.Color.Yellow;
            this.txt_total_pagar.Location = new System.Drawing.Point(86, 124);
            this.txt_total_pagar.Name = "txt_total_pagar";
            this.txt_total_pagar.Size = new System.Drawing.Size(100, 31);
            this.txt_total_pagar.TabIndex = 198;
            // 
            // cb_forma_pagamento
            // 
            this.cb_forma_pagamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.cb_forma_pagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_forma_pagamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_forma_pagamento.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_forma_pagamento.ForeColor = System.Drawing.Color.White;
            this.cb_forma_pagamento.FormattingEnabled = true;
            this.cb_forma_pagamento.Location = new System.Drawing.Point(24, 88);
            this.cb_forma_pagamento.Name = "cb_forma_pagamento";
            this.cb_forma_pagamento.Size = new System.Drawing.Size(229, 27);
            this.cb_forma_pagamento.TabIndex = 166;
            this.cb_forma_pagamento.SelectedIndexChanged += new System.EventHandler(this.cb_forma_pagamento_SelectedIndexChanged);
            this.cb_forma_pagamento.Click += new System.EventHandler(this.cb_forma_pagamento_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(19, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Forma de pagamento:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(25, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 19);
            this.label7.TabIndex = 197;
            this.label7.Text = "Troco:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Consultas_medicas.Properties.Resources.download_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(192, 143);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 192;
            this.pictureBox1.TabStop = false;
            // 
            // txt_dinheiro
            // 
            this.txt_dinheiro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.txt_dinheiro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_dinheiro.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dinheiro.ForeColor = System.Drawing.Color.White;
            this.txt_dinheiro.Location = new System.Drawing.Point(86, 167);
            this.txt_dinheiro.Name = "txt_dinheiro";
            this.txt_dinheiro.Size = new System.Drawing.Size(100, 31);
            this.txt_dinheiro.TabIndex = 193;
            this.txt_dinheiro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_dinheiro_KeyDown);
            this.txt_dinheiro.Leave += new System.EventHandler(this.txt_dinheiro_Leave);
            // 
            // btn_efetuar_pagamento
            // 
            this.btn_efetuar_pagamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_efetuar_pagamento.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.btn_efetuar_pagamento.FlatAppearance.BorderSize = 3;
            this.btn_efetuar_pagamento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SpringGreen;
            this.btn_efetuar_pagamento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SpringGreen;
            this.btn_efetuar_pagamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_efetuar_pagamento.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_efetuar_pagamento.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_efetuar_pagamento.Location = new System.Drawing.Point(58, 259);
            this.btn_efetuar_pagamento.Name = "btn_efetuar_pagamento";
            this.btn_efetuar_pagamento.Size = new System.Drawing.Size(163, 47);
            this.btn_efetuar_pagamento.TabIndex = 194;
            this.btn_efetuar_pagamento.Text = "Efetuar Pagamento";
            this.btn_efetuar_pagamento.UseVisualStyleBackColor = true;
            this.btn_efetuar_pagamento.Click += new System.EventHandler(this.btn_efetuar_pagamento_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.label25.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(12, 172);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 19);
            this.label25.TabIndex = 195;
            this.label25.Text = "Dinheiro:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(31, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 19);
            this.label8.TabIndex = 196;
            this.label8.Text = "Total:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.Location = new System.Drawing.Point(58, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(167, 19);
            this.label9.TabIndex = 23;
            this.label9.Text = "Pagamento de Consulta:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(659, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(271, 32);
            this.panel2.TabIndex = 24;
            // 
            // lbl_status_pagamento
            // 
            this.lbl_status_pagamento.AutoSize = true;
            this.lbl_status_pagamento.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status_pagamento.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_status_pagamento.Location = new System.Drawing.Point(803, 43);
            this.lbl_status_pagamento.Name = "lbl_status_pagamento";
            this.lbl_status_pagamento.Size = new System.Drawing.Size(14, 19);
            this.lbl_status_pagamento.TabIndex = 26;
            this.lbl_status_pagamento.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label11.Location = new System.Drawing.Point(713, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 19);
            this.label11.TabIndex = 25;
            this.label11.Text = "Pagamento:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Teal;
            this.panel3.Controls.Add(this.picture_fechar);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(942, 33);
            this.panel3.TabIndex = 27;
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
            this.label10.Location = new System.Drawing.Point(292, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(226, 19);
            this.label10.TabIndex = 2;
            this.label10.Text = "Detalhamento serviços do cliente";
            // 
            // form_prodServ_cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(942, 467);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lbl_status_pagamento);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_hora);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_cod);
            this.Controls.Add(this.lbl_codigo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.lbl_data);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.dt_itens_servicos1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_nome_cliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "form_prodServ_cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Itens do Cliente";
            this.Load += new System.EventHandler(this.form_prodServ_cliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dt_itens_servicos1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_fechar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_nome_cliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_total_geral;
        private System.Windows.Forms.DataGridView dt_itens_servicos1;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_data;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_codigo;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.TextBox txt_cod;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_hora;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_forma_pagamento;
        private System.Windows.Forms.TextBox txt_troco;
        private System.Windows.Forms.TextBox txt_total_pagar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_dinheiro;
        private System.Windows.Forms.Button btn_efetuar_pagamento;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cb_status_pagamento;
        private System.Windows.Forms.Label lbl_status_pagamento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox picture_fechar;
        private System.Windows.Forms.Label label10;
    }
}