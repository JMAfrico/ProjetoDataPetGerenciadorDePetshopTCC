namespace Consultas_medicas
{
    partial class Form_Cadastro_tipo_animal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picture_fechar = new System.Windows.Forms.PictureBox();
            this.picture_minimizar = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.painel_animais = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.img_help = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_pesquisar_tipo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_voltar = new System.Windows.Forms.Button();
            this.btn_deletar_tipo_animal = new System.Windows.Forms.Button();
            this.dtListar_tipo_animais = new System.Windows.Forms.DataGridView();
            this.btn_editar_animal = new System.Windows.Forms.Button();
            this.btn_salvar_animal = new System.Windows.Forms.Button();
            this.paniel_tipo = new System.Windows.Forms.Panel();
            this.lbl_tipo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_codigo_tipo_pet = new System.Windows.Forms.TextBox();
            this.txt_nome_tipo_animal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.img_help_raca = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_voltar_raca_pet = new System.Windows.Forms.Button();
            this.txt_pesquisar_raca = new System.Windows.Forms.TextBox();
            this.btn_deletar_raca_pet = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_editar_raca_pet = new System.Windows.Forms.Button();
            this.dt_raca_animal = new System.Windows.Forms.DataGridView();
            this.btn_salvar_raca_pet = new System.Windows.Forms.Button();
            this.painel_raca = new System.Windows.Forms.Panel();
            this.txt_cod_cadastro_raca = new System.Windows.Forms.TextBox();
            this.txt_raca_pet = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_racaTipo_pet = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dt_todos_animais = new System.Windows.Forms.DataGridView();
            this.rb_tipo_animal = new System.Windows.Forms.RadioButton();
            this.rb_raca_animal = new System.Windows.Forms.RadioButton();
            this.txt_pesquisar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.msn = new System.Windows.Forms.ToolTip(this.components);
            this.msg2 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_fechar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_minimizar)).BeginInit();
            this.panel1.SuspendLayout();
            this.painel_animais.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_help)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtListar_tipo_animais)).BeginInit();
            this.paniel_tipo.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_help_raca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_raca_animal)).BeginInit();
            this.painel_raca.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_todos_animais)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.Controls.Add(this.picture_fechar);
            this.panel2.Controls.Add(this.picture_minimizar);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(822, 37);
            this.panel2.TabIndex = 10;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown_1);
            // 
            // picture_fechar
            // 
            this.picture_fechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picture_fechar.Image = global::Consultas_medicas.Properties.Resources.fechar;
            this.picture_fechar.Location = new System.Drawing.Point(7, 3);
            this.picture_fechar.Name = "picture_fechar";
            this.picture_fechar.Size = new System.Drawing.Size(25, 25);
            this.picture_fechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_fechar.TabIndex = 74;
            this.picture_fechar.TabStop = false;
            this.picture_fechar.Click += new System.EventHandler(this.picture_fechar_Click);
            // 
            // picture_minimizar
            // 
            this.picture_minimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picture_minimizar.Image = global::Consultas_medicas.Properties.Resources.minimizar;
            this.picture_minimizar.Location = new System.Drawing.Point(38, 3);
            this.picture_minimizar.Name = "picture_minimizar";
            this.picture_minimizar.Size = new System.Drawing.Size(29, 25);
            this.picture_minimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_minimizar.TabIndex = 73;
            this.picture_minimizar.TabStop = false;
            this.picture_minimizar.Click += new System.EventHandler(this.picture_minimizar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(348, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Cadastro de animal";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.painel_animais);
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(822, 554);
            this.panel1.TabIndex = 11;
            // 
            // painel_animais
            // 
            this.painel_animais.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.painel_animais.Controls.Add(this.tabPage1);
            this.painel_animais.Controls.Add(this.tabPage2);
            this.painel_animais.Controls.Add(this.tabPage3);
            this.painel_animais.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.painel_animais.Location = new System.Drawing.Point(6, 11);
            this.painel_animais.Name = "painel_animais";
            this.painel_animais.SelectedIndex = 0;
            this.painel_animais.Size = new System.Drawing.Size(811, 529);
            this.painel_animais.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.tabPage1.Controls.Add(this.img_help);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.txt_pesquisar_tipo);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.btn_voltar);
            this.tabPage1.Controls.Add(this.btn_deletar_tipo_animal);
            this.tabPage1.Controls.Add(this.dtListar_tipo_animais);
            this.tabPage1.Controls.Add(this.btn_editar_animal);
            this.tabPage1.Controls.Add(this.btn_salvar_animal);
            this.tabPage1.Controls.Add(this.paniel_tipo);
            this.tabPage1.Location = new System.Drawing.Point(4, 35);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(803, 490);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tipo";
            // 
            // img_help
            // 
            this.img_help.Image = global::Consultas_medicas.Properties.Resources.interrogacao;
            this.img_help.Location = new System.Drawing.Point(13, 160);
            this.img_help.Name = "img_help";
            this.img_help.Size = new System.Drawing.Size(30, 30);
            this.img_help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.img_help.TabIndex = 99;
            this.img_help.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Consultas_medicas.Properties.Resources.pesquisar_imagem_30px;
            this.pictureBox1.Location = new System.Drawing.Point(167, 159);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 98;
            this.pictureBox1.TabStop = false;
            // 
            // txt_pesquisar_tipo
            // 
            this.txt_pesquisar_tipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.txt_pesquisar_tipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_pesquisar_tipo.Font = new System.Drawing.Font("Calibri", 12F);
            this.txt_pesquisar_tipo.ForeColor = System.Drawing.Color.White;
            this.txt_pesquisar_tipo.Location = new System.Drawing.Point(293, 165);
            this.txt_pesquisar_tipo.Name = "txt_pesquisar_tipo";
            this.txt_pesquisar_tipo.Size = new System.Drawing.Size(445, 27);
            this.txt_pesquisar_tipo.TabIndex = 3;
            this.txt_pesquisar_tipo.TextChanged += new System.EventHandler(this.txt_pesquisar_tipo_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(198, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 19);
            this.label4.TabIndex = 24;
            this.label4.Text = "Pesquisar:";
            // 
            // btn_voltar
            // 
            this.btn_voltar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btn_voltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_voltar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_voltar.FlatAppearance.BorderSize = 3;
            this.btn_voltar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_voltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_voltar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_voltar.ForeColor = System.Drawing.Color.White;
            this.btn_voltar.Image = global::Consultas_medicas.Properties.Resources.img_voltar_30px;
            this.btn_voltar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_voltar.Location = new System.Drawing.Point(1, 425);
            this.btn_voltar.Name = "btn_voltar";
            this.btn_voltar.Size = new System.Drawing.Size(182, 72);
            this.btn_voltar.TabIndex = 7;
            this.btn_voltar.Text = "Cancelar";
            this.btn_voltar.UseVisualStyleBackColor = false;
            this.btn_voltar.Click += new System.EventHandler(this.btn_voltar_Click);
            // 
            // btn_deletar_tipo_animal
            // 
            this.btn_deletar_tipo_animal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btn_deletar_tipo_animal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_deletar_tipo_animal.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btn_deletar_tipo_animal.FlatAppearance.BorderSize = 3;
            this.btn_deletar_tipo_animal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btn_deletar_tipo_animal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_deletar_tipo_animal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deletar_tipo_animal.ForeColor = System.Drawing.Color.White;
            this.btn_deletar_tipo_animal.Image = global::Consultas_medicas.Properties.Resources.cancelar_30px;
            this.btn_deletar_tipo_animal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_deletar_tipo_animal.Location = new System.Drawing.Point(3, 347);
            this.btn_deletar_tipo_animal.Name = "btn_deletar_tipo_animal";
            this.btn_deletar_tipo_animal.Size = new System.Drawing.Size(180, 72);
            this.btn_deletar_tipo_animal.TabIndex = 6;
            this.btn_deletar_tipo_animal.Text = "Deletar";
            this.btn_deletar_tipo_animal.UseVisualStyleBackColor = false;
            this.btn_deletar_tipo_animal.Click += new System.EventHandler(this.btn_deletar_tipo_animal_Click);
            // 
            // dtListar_tipo_animais
            // 
            this.dtListar_tipo_animais.AllowUserToAddRows = false;
            this.dtListar_tipo_animais.AllowUserToDeleteRows = false;
            this.dtListar_tipo_animais.AllowUserToResizeColumns = false;
            this.dtListar_tipo_animais.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Lime;
            this.dtListar_tipo_animais.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dtListar_tipo_animais.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtListar_tipo_animais.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtListar_tipo_animais.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.dtListar_tipo_animais.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dtListar_tipo_animais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtListar_tipo_animais.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtListar_tipo_animais.EnableHeadersVisualStyles = false;
            this.dtListar_tipo_animais.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.dtListar_tipo_animais.Location = new System.Drawing.Point(189, 198);
            this.dtListar_tipo_animais.Name = "dtListar_tipo_animais";
            this.dtListar_tipo_animais.RowHeadersVisible = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.dtListar_tipo_animais.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dtListar_tipo_animais.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtListar_tipo_animais.Size = new System.Drawing.Size(609, 299);
            this.dtListar_tipo_animais.TabIndex = 97;
            this.dtListar_tipo_animais.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtListar_tipo_animais_CellContentClick);
            this.dtListar_tipo_animais.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtListar_tipo_animais_CellContentDoubleClick);
            // 
            // btn_editar_animal
            // 
            this.btn_editar_animal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btn_editar_animal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_editar_animal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_editar_animal.FlatAppearance.BorderSize = 3;
            this.btn_editar_animal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_editar_animal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editar_animal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editar_animal.ForeColor = System.Drawing.Color.White;
            this.btn_editar_animal.Image = global::Consultas_medicas.Properties.Resources.img_editar_30px;
            this.btn_editar_animal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_editar_animal.Location = new System.Drawing.Point(6, 275);
            this.btn_editar_animal.Name = "btn_editar_animal";
            this.btn_editar_animal.Size = new System.Drawing.Size(177, 66);
            this.btn_editar_animal.TabIndex = 5;
            this.btn_editar_animal.Text = "Confirmar Edição";
            this.btn_editar_animal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_editar_animal.UseVisualStyleBackColor = false;
            this.btn_editar_animal.Click += new System.EventHandler(this.btn_editar_animal_Click);
            // 
            // btn_salvar_animal
            // 
            this.btn_salvar_animal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btn_salvar_animal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salvar_animal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btn_salvar_animal.FlatAppearance.BorderSize = 3;
            this.btn_salvar_animal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btn_salvar_animal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salvar_animal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salvar_animal.ForeColor = System.Drawing.Color.White;
            this.btn_salvar_animal.Image = global::Consultas_medicas.Properties.Resources.ok_imagem2_50px;
            this.btn_salvar_animal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salvar_animal.Location = new System.Drawing.Point(6, 198);
            this.btn_salvar_animal.Name = "btn_salvar_animal";
            this.btn_salvar_animal.Size = new System.Drawing.Size(177, 71);
            this.btn_salvar_animal.TabIndex = 4;
            this.btn_salvar_animal.Text = "Salvar";
            this.btn_salvar_animal.UseVisualStyleBackColor = false;
            this.btn_salvar_animal.Click += new System.EventHandler(this.btn_salvar_animal_Click);
            // 
            // paniel_tipo
            // 
            this.paniel_tipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.paniel_tipo.Controls.Add(this.lbl_tipo);
            this.paniel_tipo.Controls.Add(this.label8);
            this.paniel_tipo.Controls.Add(this.txt_codigo_tipo_pet);
            this.paniel_tipo.Controls.Add(this.txt_nome_tipo_animal);
            this.paniel_tipo.Controls.Add(this.label1);
            this.paniel_tipo.Location = new System.Drawing.Point(1, 0);
            this.paniel_tipo.Name = "paniel_tipo";
            this.paniel_tipo.Size = new System.Drawing.Size(791, 152);
            this.paniel_tipo.TabIndex = 22;
            // 
            // lbl_tipo
            // 
            this.lbl_tipo.AutoSize = true;
            this.lbl_tipo.Location = new System.Drawing.Point(467, 31);
            this.lbl_tipo.Name = "lbl_tipo";
            this.lbl_tipo.Size = new System.Drawing.Size(59, 23);
            this.lbl_tipo.TabIndex = 9;
            this.lbl_tipo.Text = "label9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(202, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 19);
            this.label8.TabIndex = 8;
            this.label8.Text = "Código:";
            // 
            // txt_codigo_tipo_pet
            // 
            this.txt_codigo_tipo_pet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.txt_codigo_tipo_pet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_codigo_tipo_pet.Enabled = false;
            this.txt_codigo_tipo_pet.Font = new System.Drawing.Font("Calibri", 12F);
            this.txt_codigo_tipo_pet.ForeColor = System.Drawing.Color.White;
            this.txt_codigo_tipo_pet.Location = new System.Drawing.Point(275, 23);
            this.txt_codigo_tipo_pet.Name = "txt_codigo_tipo_pet";
            this.txt_codigo_tipo_pet.Size = new System.Drawing.Size(185, 27);
            this.txt_codigo_tipo_pet.TabIndex = 7;
            // 
            // txt_nome_tipo_animal
            // 
            this.txt_nome_tipo_animal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.txt_nome_tipo_animal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_nome_tipo_animal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_nome_tipo_animal.Font = new System.Drawing.Font("Calibri", 12F);
            this.txt_nome_tipo_animal.ForeColor = System.Drawing.Color.White;
            this.txt_nome_tipo_animal.Location = new System.Drawing.Point(275, 66);
            this.txt_nome_tipo_animal.Name = "txt_nome_tipo_animal";
            this.txt_nome_tipo_animal.Size = new System.Drawing.Size(447, 27);
            this.txt_nome_tipo_animal.TabIndex = 1;
            this.txt_nome_tipo_animal.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(117, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Novo tipo de animal:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.tabPage2.Controls.Add(this.img_help_raca);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.btn_voltar_raca_pet);
            this.tabPage2.Controls.Add(this.txt_pesquisar_raca);
            this.tabPage2.Controls.Add(this.btn_deletar_raca_pet);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.btn_editar_raca_pet);
            this.tabPage2.Controls.Add(this.dt_raca_animal);
            this.tabPage2.Controls.Add(this.btn_salvar_raca_pet);
            this.tabPage2.Controls.Add(this.painel_raca);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(803, 500);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Raça";
            // 
            // img_help_raca
            // 
            this.img_help_raca.Image = global::Consultas_medicas.Properties.Resources.interrogacao;
            this.img_help_raca.Location = new System.Drawing.Point(12, 179);
            this.img_help_raca.Name = "img_help_raca";
            this.img_help_raca.Size = new System.Drawing.Size(30, 30);
            this.img_help_raca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.img_help_raca.TabIndex = 102;
            this.img_help_raca.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Consultas_medicas.Properties.Resources.pesquisar_imagem_30px;
            this.pictureBox2.Location = new System.Drawing.Point(152, 183);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 101;
            this.pictureBox2.TabStop = false;
            // 
            // btn_voltar_raca_pet
            // 
            this.btn_voltar_raca_pet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btn_voltar_raca_pet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_voltar_raca_pet.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_voltar_raca_pet.FlatAppearance.BorderSize = 3;
            this.btn_voltar_raca_pet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_voltar_raca_pet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_voltar_raca_pet.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_voltar_raca_pet.ForeColor = System.Drawing.Color.White;
            this.btn_voltar_raca_pet.Image = global::Consultas_medicas.Properties.Resources.img_voltar_30px;
            this.btn_voltar_raca_pet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_voltar_raca_pet.Location = new System.Drawing.Point(6, 428);
            this.btn_voltar_raca_pet.Name = "btn_voltar_raca_pet";
            this.btn_voltar_raca_pet.Size = new System.Drawing.Size(159, 60);
            this.btn_voltar_raca_pet.TabIndex = 100;
            this.btn_voltar_raca_pet.Text = "Cancelar";
            this.btn_voltar_raca_pet.UseVisualStyleBackColor = false;
            this.btn_voltar_raca_pet.Click += new System.EventHandler(this.btn_voltar_raca_pet_Click);
            // 
            // txt_pesquisar_raca
            // 
            this.txt_pesquisar_raca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.txt_pesquisar_raca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_pesquisar_raca.Font = new System.Drawing.Font("Calibri", 12F);
            this.txt_pesquisar_raca.ForeColor = System.Drawing.Color.White;
            this.txt_pesquisar_raca.Location = new System.Drawing.Point(262, 187);
            this.txt_pesquisar_raca.Name = "txt_pesquisar_raca";
            this.txt_pesquisar_raca.Size = new System.Drawing.Size(410, 27);
            this.txt_pesquisar_raca.TabIndex = 25;
            this.txt_pesquisar_raca.TextChanged += new System.EventHandler(this.txt_pesquisar_raca_TextChanged);
            // 
            // btn_deletar_raca_pet
            // 
            this.btn_deletar_raca_pet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btn_deletar_raca_pet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_deletar_raca_pet.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btn_deletar_raca_pet.FlatAppearance.BorderSize = 3;
            this.btn_deletar_raca_pet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btn_deletar_raca_pet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_deletar_raca_pet.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deletar_raca_pet.ForeColor = System.Drawing.Color.White;
            this.btn_deletar_raca_pet.Image = global::Consultas_medicas.Properties.Resources.cancelar_30px;
            this.btn_deletar_raca_pet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_deletar_raca_pet.Location = new System.Drawing.Point(6, 360);
            this.btn_deletar_raca_pet.Name = "btn_deletar_raca_pet";
            this.btn_deletar_raca_pet.Size = new System.Drawing.Size(159, 62);
            this.btn_deletar_raca_pet.TabIndex = 99;
            this.btn_deletar_raca_pet.Text = "Deletar";
            this.btn_deletar_raca_pet.UseVisualStyleBackColor = false;
            this.btn_deletar_raca_pet.Click += new System.EventHandler(this.btn_deletar_raca_pet_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(185, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 19);
            this.label6.TabIndex = 26;
            this.label6.Text = "Pesquisar:";
            // 
            // btn_editar_raca_pet
            // 
            this.btn_editar_raca_pet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btn_editar_raca_pet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_editar_raca_pet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_editar_raca_pet.FlatAppearance.BorderSize = 3;
            this.btn_editar_raca_pet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_editar_raca_pet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editar_raca_pet.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editar_raca_pet.ForeColor = System.Drawing.Color.White;
            this.btn_editar_raca_pet.Image = global::Consultas_medicas.Properties.Resources.img_editar_30px;
            this.btn_editar_raca_pet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_editar_raca_pet.Location = new System.Drawing.Point(6, 289);
            this.btn_editar_raca_pet.Name = "btn_editar_raca_pet";
            this.btn_editar_raca_pet.Size = new System.Drawing.Size(159, 65);
            this.btn_editar_raca_pet.TabIndex = 26;
            this.btn_editar_raca_pet.Text = "Confirmar Edição";
            this.btn_editar_raca_pet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_editar_raca_pet.UseVisualStyleBackColor = false;
            this.btn_editar_raca_pet.Click += new System.EventHandler(this.btn_editar_raca_pet_Click);
            // 
            // dt_raca_animal
            // 
            this.dt_raca_animal.AllowUserToAddRows = false;
            this.dt_raca_animal.AllowUserToDeleteRows = false;
            this.dt_raca_animal.AllowUserToResizeColumns = false;
            this.dt_raca_animal.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Lime;
            this.dt_raca_animal.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dt_raca_animal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dt_raca_animal.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dt_raca_animal.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.dt_raca_animal.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dt_raca_animal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_raca_animal.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dt_raca_animal.EnableHeadersVisualStyles = false;
            this.dt_raca_animal.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.dt_raca_animal.Location = new System.Drawing.Point(171, 220);
            this.dt_raca_animal.Name = "dt_raca_animal";
            this.dt_raca_animal.RowHeadersVisible = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.dt_raca_animal.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dt_raca_animal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_raca_animal.Size = new System.Drawing.Size(626, 277);
            this.dt_raca_animal.TabIndex = 1;
            this.dt_raca_animal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_raca_animal_CellContentClick);
            this.dt_raca_animal.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_raca_animal_CellContentDoubleClick);
            // 
            // btn_salvar_raca_pet
            // 
            this.btn_salvar_raca_pet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btn_salvar_raca_pet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salvar_raca_pet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btn_salvar_raca_pet.FlatAppearance.BorderSize = 3;
            this.btn_salvar_raca_pet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btn_salvar_raca_pet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salvar_raca_pet.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salvar_raca_pet.ForeColor = System.Drawing.Color.White;
            this.btn_salvar_raca_pet.Image = global::Consultas_medicas.Properties.Resources.ok_imagem2_50px;
            this.btn_salvar_raca_pet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salvar_raca_pet.Location = new System.Drawing.Point(6, 220);
            this.btn_salvar_raca_pet.Name = "btn_salvar_raca_pet";
            this.btn_salvar_raca_pet.Size = new System.Drawing.Size(159, 63);
            this.btn_salvar_raca_pet.TabIndex = 27;
            this.btn_salvar_raca_pet.Text = "Salvar";
            this.btn_salvar_raca_pet.UseVisualStyleBackColor = false;
            this.btn_salvar_raca_pet.Click += new System.EventHandler(this.btn_salvar_raca_pet_Click);
            // 
            // painel_raca
            // 
            this.painel_raca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.painel_raca.Controls.Add(this.txt_cod_cadastro_raca);
            this.painel_raca.Controls.Add(this.txt_raca_pet);
            this.painel_raca.Controls.Add(this.label5);
            this.painel_raca.Controls.Add(this.label3);
            this.painel_raca.Controls.Add(this.cb_racaTipo_pet);
            this.painel_raca.Location = new System.Drawing.Point(-4, 0);
            this.painel_raca.Name = "painel_raca";
            this.painel_raca.Size = new System.Drawing.Size(803, 170);
            this.painel_raca.TabIndex = 0;
            // 
            // txt_cod_cadastro_raca
            // 
            this.txt_cod_cadastro_raca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.txt_cod_cadastro_raca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_cod_cadastro_raca.Enabled = false;
            this.txt_cod_cadastro_raca.Font = new System.Drawing.Font("Calibri", 12F);
            this.txt_cod_cadastro_raca.ForeColor = System.Drawing.Color.White;
            this.txt_cod_cadastro_raca.Location = new System.Drawing.Point(622, 10);
            this.txt_cod_cadastro_raca.Name = "txt_cod_cadastro_raca";
            this.txt_cod_cadastro_raca.Size = new System.Drawing.Size(57, 27);
            this.txt_cod_cadastro_raca.TabIndex = 10;
            // 
            // txt_raca_pet
            // 
            this.txt_raca_pet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.txt_raca_pet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_raca_pet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_raca_pet.Font = new System.Drawing.Font("Calibri", 12F);
            this.txt_raca_pet.ForeColor = System.Drawing.Color.White;
            this.txt_raca_pet.Location = new System.Drawing.Point(200, 48);
            this.txt_raca_pet.Name = "txt_raca_pet";
            this.txt_raca_pet.Size = new System.Drawing.Size(416, 27);
            this.txt_raca_pet.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(112, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nova Raça:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(84, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tipo do Animal:";
            // 
            // cb_racaTipo_pet
            // 
            this.cb_racaTipo_pet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.cb_racaTipo_pet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_racaTipo_pet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_racaTipo_pet.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_racaTipo_pet.ForeColor = System.Drawing.Color.White;
            this.cb_racaTipo_pet.FormattingEnabled = true;
            this.cb_racaTipo_pet.Location = new System.Drawing.Point(200, 10);
            this.cb_racaTipo_pet.Name = "cb_racaTipo_pet";
            this.cb_racaTipo_pet.Size = new System.Drawing.Size(416, 27);
            this.cb_racaTipo_pet.TabIndex = 2;
            this.cb_racaTipo_pet.SelectedIndexChanged += new System.EventHandler(this.cb_racaTipo_pet_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.tabPage3.Controls.Add(this.dt_todos_animais);
            this.tabPage3.Controls.Add(this.rb_tipo_animal);
            this.tabPage3.Controls.Add(this.rb_raca_animal);
            this.tabPage3.Controls.Add(this.txt_pesquisar);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(803, 500);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Geral";
            // 
            // dt_todos_animais
            // 
            this.dt_todos_animais.AllowUserToAddRows = false;
            this.dt_todos_animais.AllowUserToDeleteRows = false;
            this.dt_todos_animais.AllowUserToResizeColumns = false;
            this.dt_todos_animais.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Lime;
            this.dt_todos_animais.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dt_todos_animais.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dt_todos_animais.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dt_todos_animais.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.dt_todos_animais.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dt_todos_animais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_todos_animais.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dt_todos_animais.EnableHeadersVisualStyles = false;
            this.dt_todos_animais.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.dt_todos_animais.Location = new System.Drawing.Point(160, 176);
            this.dt_todos_animais.Name = "dt_todos_animais";
            this.dt_todos_animais.RowHeadersVisible = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle12.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.dt_todos_animais.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dt_todos_animais.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_todos_animais.Size = new System.Drawing.Size(546, 295);
            this.dt_todos_animais.TabIndex = 31;
            // 
            // rb_tipo_animal
            // 
            this.rb_tipo_animal.AutoSize = true;
            this.rb_tipo_animal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb_tipo_animal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_tipo_animal.ForeColor = System.Drawing.Color.GreenYellow;
            this.rb_tipo_animal.Location = new System.Drawing.Point(408, 21);
            this.rb_tipo_animal.Name = "rb_tipo_animal";
            this.rb_tipo_animal.Size = new System.Drawing.Size(60, 27);
            this.rb_tipo_animal.TabIndex = 30;
            this.rb_tipo_animal.TabStop = true;
            this.rb_tipo_animal.Text = "Tipo";
            this.rb_tipo_animal.UseVisualStyleBackColor = true;
            // 
            // rb_raca_animal
            // 
            this.rb_raca_animal.AutoSize = true;
            this.rb_raca_animal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb_raca_animal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_raca_animal.ForeColor = System.Drawing.Color.Cyan;
            this.rb_raca_animal.Location = new System.Drawing.Point(262, 21);
            this.rb_raca_animal.Name = "rb_raca_animal";
            this.rb_raca_animal.Size = new System.Drawing.Size(63, 27);
            this.rb_raca_animal.TabIndex = 29;
            this.rb_raca_animal.TabStop = true;
            this.rb_raca_animal.Text = "Raça";
            this.rb_raca_animal.UseVisualStyleBackColor = true;
            // 
            // txt_pesquisar
            // 
            this.txt_pesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.txt_pesquisar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_pesquisar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_pesquisar.Font = new System.Drawing.Font("Calibri", 12F);
            this.txt_pesquisar.ForeColor = System.Drawing.Color.White;
            this.txt_pesquisar.Location = new System.Drawing.Point(160, 73);
            this.txt_pesquisar.Name = "txt_pesquisar";
            this.txt_pesquisar.Size = new System.Drawing.Size(546, 27);
            this.txt_pesquisar.TabIndex = 27;
            this.txt_pesquisar.TextChanged += new System.EventHandler(this.txt_pesquisar_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(65, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 19);
            this.label7.TabIndex = 28;
            this.label7.Text = "Pesquisar:";
            // 
            // msn
            // 
            this.msn.AutoPopDelay = 10000;
            this.msn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.msn.InitialDelay = 500;
            this.msn.IsBalloon = true;
            this.msn.ReshowDelay = 100;
            // 
            // msg2
            // 
            this.msg2.AutoPopDelay = 10000;
            this.msg2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.msg2.InitialDelay = 500;
            this.msg2.IsBalloon = true;
            this.msg2.ReshowDelay = 100;
            // 
            // Form_Cadastro_tipo_animal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 584);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Cadastro_tipo_animal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Cadastro_tipo_animal";
            this.Load += new System.EventHandler(this.Form_Cadastro_tipo_animal_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_fechar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_minimizar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.painel_animais.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_help)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtListar_tipo_animais)).EndInit();
            this.paniel_tipo.ResumeLayout(false);
            this.paniel_tipo.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_help_raca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_raca_animal)).EndInit();
            this.painel_raca.ResumeLayout(false);
            this.painel_raca.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_todos_animais)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_nome_tipo_animal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_racaTipo_pet;
        private System.Windows.Forms.Panel paniel_tipo;
        private System.Windows.Forms.Button btn_salvar_animal;
        private System.Windows.Forms.Button btn_voltar;
        private System.Windows.Forms.Button btn_editar_animal;
        private System.Windows.Forms.Button btn_deletar_tipo_animal;
        private System.Windows.Forms.TextBox txt_pesquisar_tipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dtListar_tipo_animais;
        private System.Windows.Forms.PictureBox picture_minimizar;
        private System.Windows.Forms.PictureBox picture_fechar;
        private System.Windows.Forms.TabControl painel_animais;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel painel_raca;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txt_raca_pet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_voltar_raca_pet;
        private System.Windows.Forms.Button btn_deletar_raca_pet;
        private System.Windows.Forms.Button btn_editar_raca_pet;
        private System.Windows.Forms.Button btn_salvar_raca_pet;
        private System.Windows.Forms.TextBox txt_pesquisar_raca;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dt_raca_animal;
        private System.Windows.Forms.RadioButton rb_tipo_animal;
        private System.Windows.Forms.RadioButton rb_raca_animal;
        private System.Windows.Forms.TextBox txt_pesquisar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dt_todos_animais;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_codigo_tipo_pet;
        private System.Windows.Forms.Label lbl_tipo;
        private System.Windows.Forms.TextBox txt_cod_cadastro_raca;
        private System.Windows.Forms.PictureBox img_help;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip msn;
        private System.Windows.Forms.PictureBox img_help_raca;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolTip msg2;
    }
}