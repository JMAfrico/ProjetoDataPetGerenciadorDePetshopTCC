namespace Consultas_medicas.Formularios
{
    partial class Form_diagnostico_medico
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picture_fechar = new System.Windows.Forms.PictureBox();
            this.picture_minimizar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_diagnostico = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_salvar_medico = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_editar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_fechar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_minimizar)).BeginInit();
            this.panel_diagnostico.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1258, 899);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel2.Controls.Add(this.picture_fechar);
            this.panel2.Controls.Add(this.picture_minimizar);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1258, 32);
            this.panel2.TabIndex = 3;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // picture_fechar
            // 
            this.picture_fechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.picture_fechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picture_fechar.Image = global::Consultas_medicas.Properties.Resources.fechar;
            this.picture_fechar.Location = new System.Drawing.Point(7, 3);
            this.picture_fechar.Name = "picture_fechar";
            this.picture_fechar.Size = new System.Drawing.Size(25, 25);
            this.picture_fechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_fechar.TabIndex = 3;
            this.picture_fechar.TabStop = false;
            this.picture_fechar.Click += new System.EventHandler(this.picture_fechar_Click);
            // 
            // picture_minimizar
            // 
            this.picture_minimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.picture_minimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picture_minimizar.Image = global::Consultas_medicas.Properties.Resources.minimizar;
            this.picture_minimizar.Location = new System.Drawing.Point(41, 3);
            this.picture_minimizar.Name = "picture_minimizar";
            this.picture_minimizar.Size = new System.Drawing.Size(29, 25);
            this.picture_minimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_minimizar.TabIndex = 2;
            this.picture_minimizar.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(553, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Diagnóstico";
            // 
            // panel_diagnostico
            // 
            this.panel_diagnostico.Controls.Add(this.panel3);
            this.panel_diagnostico.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_diagnostico.Location = new System.Drawing.Point(0, 242);
            this.panel_diagnostico.Name = "panel_diagnostico";
            this.panel_diagnostico.Size = new System.Drawing.Size(1258, 657);
            this.panel_diagnostico.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Teal;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btn_salvar_medico);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btn_editar);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.ForeColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(0, 581);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1258, 76);
            this.panel3.TabIndex = 98;
            // 
            // btn_salvar_medico
            // 
            this.btn_salvar_medico.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_salvar_medico.BackColor = System.Drawing.Color.Teal;
            this.btn_salvar_medico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salvar_medico.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btn_salvar_medico.FlatAppearance.BorderSize = 3;
            this.btn_salvar_medico.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btn_salvar_medico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salvar_medico.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salvar_medico.ForeColor = System.Drawing.Color.White;
            this.btn_salvar_medico.Image = global::Consultas_medicas.Properties.Resources.ok_imagem2_50px;
            this.btn_salvar_medico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salvar_medico.Location = new System.Drawing.Point(164, 11);
            this.btn_salvar_medico.Name = "btn_salvar_medico";
            this.btn_salvar_medico.Size = new System.Drawing.Size(257, 55);
            this.btn_salvar_medico.TabIndex = 95;
            this.btn_salvar_medico.Text = "Salvar";
            this.btn_salvar_medico.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::Consultas_medicas.Properties.Resources.img_voltar_30px;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(525, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(257, 54);
            this.button1.TabIndex = 96;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btn_editar
            // 
            this.btn_editar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_editar.BackColor = System.Drawing.Color.Teal;
            this.btn_editar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_editar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_editar.FlatAppearance.BorderSize = 3;
            this.btn_editar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editar.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editar.ForeColor = System.Drawing.Color.White;
            this.btn_editar.Image = global::Consultas_medicas.Properties.Resources.img_editar_30px;
            this.btn_editar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_editar.Location = new System.Drawing.Point(872, 11);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(243, 55);
            this.btn_editar.TabIndex = 97;
            this.btn_editar.Text = "Confirmar Edição";
            this.btn_editar.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.label12.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(80, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 19);
            this.label12.TabIndex = 140;
            this.label12.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(450, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 19);
            this.label2.TabIndex = 141;
            this.label2.Text = "Cor:";
            // 
            // Form_diagnostico_medico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1258, 899);
            this.Controls.Add(this.panel_diagnostico);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_diagnostico_medico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_diagnostico_medico";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_fechar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_minimizar)).EndInit();
            this.panel_diagnostico.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picture_fechar;
        private System.Windows.Forms.PictureBox picture_minimizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_diagnostico;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_salvar_medico;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
    }
}