using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Consultas_medicas.Models;
using Consultas_medicas.BLL;//chamada da classe intermediária
using Consultas_medicas.DAO;
using System.Runtime.InteropServices;//chamada da classe query

namespace Consultas_medicas.Formularios
{
    public partial class Form_consultaVeterinario : Form
    {

        // MOVER A TELA--------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr HWnd, int wMsg, int wParam, int IParam);



        public Form_consultaVeterinario()
        {
            InitializeComponent();
            rd_hoje.Checked = true;
        }

        private void Form_consultaVeterinario_Load(object sender, EventArgs e)
        {
            rd_hoje.Checked = true;
            listaVeterinarios();
            //Veterinarios vet = new Veterinarios();
            //pesquisarConsultas(vet);
            
        }

        public void listaVeterinarios()
        {
            VeterinarioBLL veterinariosBll = new VeterinarioBLL();
            this.cb_veterinario.ValueMember = "codVeterinario";
            this.cb_veterinario.DisplayMember = "nomeVeterinario";
            this.cb_veterinario.DataSource = veterinariosBll.listarVeteriNoCombobox();
        }
        
        /*private void listarConsultas()
        {
            ConsultaBLL consultaBLL = new ConsultaBLL();
            dtConsultas.DataSource = consultaBLL.ConsultasPorVeterinario();
        }*/

        private void colunasInvisiveis()
        {
            dtConsultas.Columns["CADASTRO"].Visible = false;
            dtConsultas.Columns["VACINAS"].Visible = false;
            dtConsultas.Columns["HISTORICO"].Visible = false;
            dtConsultas.Columns["PESO"].Visible = false;
            dtConsultas.Columns["IDADE"].Visible = false;
            dtConsultas.Columns["TAMANHO"].Visible = false;
            dtConsultas.Columns["COR"].Visible = false;
            dtConsultas.Columns["SEXO"].Visible = false;
            
        }
        //PESQUISAR TODAS CONSULTAS DO VETERINÁRIO
        private void pesquisarConsultas(Veterinarios vet)
        {
            try
            {
                ConsultaBLL consultasbll = new ConsultaBLL();
                vet.nomeVeterinario = cb_veterinario.Text.Trim();
                dtConsultas.DataSource = consultasbll.ConsultasPorVeterinario(vet);
                colunasInvisiveis();
            }
            catch (System.Exception)
            {
                MessageBox.Show("Erro ao encontrar consultas");
            }

        }

        //PESQUISAR CONSULTAS DE HOJE VETERINÁRIO
        private void pesquisarConsultasHoje(Veterinarios vet)
        {
            try
            {
                ConsultaBLL consultasbll = new ConsultaBLL();
                vet.nomeVeterinario = cb_veterinario.Text.Trim();
                dtConsultas.DataSource = consultasbll.ListarVeterinarioPorConsultaHoje(vet);
                colunasInvisiveis();
            }
            catch (System.Exception)
            {
                MessageBox.Show("Erro ao encontrar consultas");
            }

        }

        //PESQUISAR TODAS CONSULTAS DO VETERINÁRIO
        private void pesquisarConsultasMais3Dias(Veterinarios vet)
        {
            try
            {
                ConsultaBLL consultasbll = new ConsultaBLL();
                vet.nomeVeterinario = cb_veterinario.Text.Trim();
                dtConsultas.DataSource = consultasbll.ListarVeterinarioPorConsultaMais3Dias(vet);
                colunasInvisiveis();
            }
            catch (System.Exception)
            {
                MessageBox.Show("Erro ao encontrar consultas");
            }

        }

        //PESQUISAR TODAS CONSULTAS DO VETERINÁRIO
        private void pesquisarConsultasMenos3dias(Veterinarios vet)
        {
            try
            {
                ConsultaBLL consultasbll = new ConsultaBLL();
                vet.nomeVeterinario = cb_veterinario.Text.Trim();
                dtConsultas.DataSource = consultasbll.ListarVeterinarioPorConsultaMenos3Dias(vet);
                colunasInvisiveis();
            }
            catch (System.Exception)
            {
                MessageBox.Show("Erro ao encontrar consultas");
            }

        }

        private void cb_veterinario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            Veterinarios vet = new Veterinarios();
            

            if (rd_todos_dias.Checked == true)
            {
                pesquisarConsultas(vet);
                //dtConsultas.Columns["CADASTRO"].Visible = false;
            }

            if (rd_hoje.Checked == true)
            {
                pesquisarConsultasHoje(vet);

            }

            if (rd_3dias.Checked == true)
            {
                pesquisarConsultasMais3Dias(vet);
            }

            if (rd_menos3dias.Checked == true)
            {
                pesquisarConsultasMenos3dias(vet);
            }
        }

        private void dtConsultas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // exibe o ContesteMenuStrip na posição do mouse dentro do gridcontrol
                //CRM.Show(gridControl1.PointToScreen(new Point(e.X, e.Y)));
                sub_menu_cliente.Show(dtConsultas.PointToScreen(new Point(e.X, e.Y)));

            }
        }

        private void novoDiagnósticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtConsultas.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para serem buscados");
            }
            else
            {
                string cliente = dtConsultas.CurrentRow.Cells["CLIENTE"].Value.ToString();
                string raca = dtConsultas.CurrentRow.Cells["RACA"].Value.ToString();
                string tipo = dtConsultas.CurrentRow.Cells["TIPO"].Value.ToString();
                string nomepet = dtConsultas.CurrentRow.Cells["NOME"].Value.ToString();
                string peso = dtConsultas.CurrentRow.Cells["PESO"].Value.ToString();
                string idade = dtConsultas.CurrentRow.Cells["IDADE"].Value.ToString();
                string tamanho = dtConsultas.CurrentRow.Cells["TAMANHO"].Value.ToString();
                string cor = dtConsultas.CurrentRow.Cells["COR"].Value.ToString();
                string sexo = dtConsultas.CurrentRow.Cells["SEXO"].Value.ToString();
                string vacinas = dtConsultas.CurrentRow.Cells["VACINAS"].Value.ToString();
                string historico = dtConsultas.CurrentRow.Cells["HISTORICO"].Value.ToString();
                string cod_consultas = dtConsultas.CurrentRow.Cells["CODIGO"].Value.ToString();
                string cod_cadastro = dtConsultas.CurrentRow.Cells["CADASTRO"].Value.ToString();
                string nome_veterinario = dtConsultas.CurrentRow.Cells["VETERINARIO"].Value.ToString();

                Form_diagnosticos_gerais novo = new Form_diagnosticos_gerais(cliente, raca, tipo, nomepet, peso, idade, tamanho, cor, sexo, vacinas, historico, cod_consultas, cod_cadastro, nome_veterinario);
                novo.Show();
            }



        }

        private void picture_fechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_diagnosticos_gerais novo = new Form_diagnosticos_gerais();
            novo.Show();
        }

    }
}
