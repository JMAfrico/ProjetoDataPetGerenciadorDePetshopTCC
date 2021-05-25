namespace Consultas_medicas.Formularios
{
    partial class Form_tipo_pagamento
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
            this.Barra_Titulo = new System.Windows.Forms.FlowLayoutPanel();
            this.picture_fechar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_troco = new System.Windows.Forms.TextBox();
            this.txt_total_pagar = new System.Windows.Forms.TextBox();
            this.lbl_troco = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_dinheiro = new System.Windows.Forms.TextBox();
            this.btn_efetuar_pagamento = new System.Windows.Forms.Button();
            this.lbl_total_a_pagar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.cb_forma_pagamento = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Barra_Titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_fechar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Barra_Titulo
            // 
            this.Barra_Titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.Barra_Titulo.Controls.Add(this.picture_fechar);
            this.Barra_Titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.Barra_Titulo.Location = new System.Drawing.Point(0, 0);
            this.Barra_Titulo.Name = "Barra_Titulo";
            this.Barra_Titulo.Size = new System.Drawing.Size(512, 32);
            this.Barra_Titulo.TabIndex = 9;
            this.Barra_Titulo.WrapContents = false;
            this.Barra_Titulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Barra_Titulo_MouseDown);
            // 
            // picture_fechar
            // 
            this.picture_fechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picture_fechar.Image = global::Consultas_medicas.Properties.Resources.fechar;
            this.picture_fechar.Location = new System.Drawing.Point(3, 3);
            this.picture_fechar.Name = "picture_fechar";
            this.picture_fechar.Size = new System.Drawing.Size(25, 25);
            this.picture_fechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_fechar.TabIndex = 0;
            this.picture_fechar.TabStop = false;
            this.picture_fechar.Click += new System.EventHandler(this.picture_fechar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.txt_troco);
            this.panel1.Controls.Add(this.txt_total_pagar);
            this.panel1.Controls.Add(this.lbl_troco);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_dinheiro);
            this.panel1.Controls.Add(this.btn_efetuar_pagamento);
            this.panel1.Controls.Add(this.lbl_total_a_pagar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.cb_forma_pagamento);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 147);
            this.panel1.TabIndex = 10;
            // 
            // txt_troco
            // 
            this.txt_troco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.txt_troco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_troco.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_troco.ForeColor = System.Drawing.Color.LawnGreen;
            this.txt_troco.Location = new System.Drawing.Point(207, 97);
            this.txt_troco.Name = "txt_troco";
            this.txt_troco.Size = new System.Drawing.Size(100, 31);
            this.txt_troco.TabIndex = 191;
            this.txt_troco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_troco_KeyDown);
            this.txt_troco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_troco_KeyPress);
            // 
            // txt_total_pagar
            // 
            this.txt_total_pagar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.txt_total_pagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_total_pagar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_total_pagar.ForeColor = System.Drawing.Color.Yellow;
            this.txt_total_pagar.Location = new System.Drawing.Point(207, 9);
            this.txt_total_pagar.Name = "txt_total_pagar";
            this.txt_total_pagar.Size = new System.Drawing.Size(100, 31);
            this.txt_total_pagar.TabIndex = 190;
            this.txt_total_pagar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_total_pagar_KeyDown);
            this.txt_total_pagar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_total_pagar_KeyPress);
            // 
            // lbl_troco
            // 
            this.lbl_troco.AutoSize = true;
            this.lbl_troco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.lbl_troco.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_troco.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_troco.Location = new System.Drawing.Point(476, 57);
            this.lbl_troco.Name = "lbl_troco";
            this.lbl_troco.Size = new System.Drawing.Size(14, 19);
            this.lbl_troco.TabIndex = 189;
            this.lbl_troco.Text = "-";
            this.lbl_troco.Visible = false;
            this.lbl_troco.Click += new System.EventHandler(this.lbl_troco_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(146, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 19);
            this.label2.TabIndex = 188;
            this.label2.Text = "Troco:";
            // 
            // txt_dinheiro
            // 
            this.txt_dinheiro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.txt_dinheiro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_dinheiro.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dinheiro.ForeColor = System.Drawing.Color.White;
            this.txt_dinheiro.Location = new System.Drawing.Point(207, 52);
            this.txt_dinheiro.Name = "txt_dinheiro";
            this.txt_dinheiro.Size = new System.Drawing.Size(100, 31);
            this.txt_dinheiro.TabIndex = 1;
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
            this.btn_efetuar_pagamento.Location = new System.Drawing.Point(324, 88);
            this.btn_efetuar_pagamento.Name = "btn_efetuar_pagamento";
            this.btn_efetuar_pagamento.Size = new System.Drawing.Size(163, 47);
            this.btn_efetuar_pagamento.TabIndex = 2;
            this.btn_efetuar_pagamento.Text = "Efetuar Pagamento";
            this.btn_efetuar_pagamento.UseVisualStyleBackColor = true;
            this.btn_efetuar_pagamento.Click += new System.EventHandler(this.btn_efetuar_pagamento_Click);
            // 
            // lbl_total_a_pagar
            // 
            this.lbl_total_a_pagar.AutoSize = true;
            this.lbl_total_a_pagar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.lbl_total_a_pagar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_a_pagar.ForeColor = System.Drawing.Color.Gold;
            this.lbl_total_a_pagar.Location = new System.Drawing.Point(456, 52);
            this.lbl_total_a_pagar.Name = "lbl_total_a_pagar";
            this.lbl_total_a_pagar.Size = new System.Drawing.Size(14, 19);
            this.lbl_total_a_pagar.TabIndex = 168;
            this.lbl_total_a_pagar.Text = "-";
            this.lbl_total_a_pagar.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(152, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 167;
            this.label1.Text = "Total:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.label25.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(133, 64);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 19);
            this.label25.TabIndex = 166;
            this.label25.Text = "Dinheiro:";
            // 
            // cb_forma_pagamento
            // 
            this.cb_forma_pagamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.cb_forma_pagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_forma_pagamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_forma_pagamento.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_forma_pagamento.ForeColor = System.Drawing.Color.White;
            this.cb_forma_pagamento.FormattingEnabled = true;
            this.cb_forma_pagamento.Location = new System.Drawing.Point(460, 6);
            this.cb_forma_pagamento.Name = "cb_forma_pagamento";
            this.cb_forma_pagamento.Size = new System.Drawing.Size(40, 27);
            this.cb_forma_pagamento.TabIndex = 165;
            this.cb_forma_pagamento.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Consultas_medicas.Properties.Resources.download_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form_tipo_pagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 179);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Barra_Titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_tipo_pagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_tipo_pagamento";
            this.Load += new System.EventHandler(this.Form_tipo_pagamento_Load);
            this.Barra_Titulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture_fechar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel Barra_Titulo;
        private System.Windows.Forms.PictureBox picture_fechar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_total_a_pagar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cb_forma_pagamento;
        private System.Windows.Forms.Button btn_efetuar_pagamento;
        private System.Windows.Forms.TextBox txt_dinheiro;
        private System.Windows.Forms.Label lbl_troco;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_total_pagar;
        private System.Windows.Forms.TextBox txt_troco;
    }
}