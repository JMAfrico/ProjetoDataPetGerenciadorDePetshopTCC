using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Consultas_medicas.Relatorios
{
    public partial class Form_relatorio_clientes : Form
    {
        //Microsoft.Reporting.WinForms.LocalReport report;

        public Form_relatorio_clientes()
        {
            InitializeComponent();
        }


        private void Form_relatorio_clientes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'petshop_2020DataSet.tb_raca' table. You can move, or remove it, as needed.
           
            //this.tb_racaTableAdapter.Fill(this.petshop_2020DataSet.tb_raca);
            // TODO: This line of code loads data into the 'petshop_2020DataSet11.tb_produtos' table. You can move, or remove it, as needed.
            //this.tb_produtosTableAdapter.Fill(this.petshop_2020DataSet11.tb_produtos);
            // TODO: This line of code loads data into the 'petshop_2020DataSet.tb_funcionario' table. You can move, or remove it, as needed.
            //this.tb_funcionarioTableAdapter.Fill(this.petshop_2020DataSet.tb_funcionario);
            // TODO: This line of code loads data into the 'petshop_2020DataSet.tb_veterinario' table. You can move, or remove it, as needed.
            //this.tb_veterinarioTableAdapter.Fill(this.petshop_2020DataSet.tb_veterinario);

            // TODO: This line of code loads data into the 'petshop_2020DataSet.tb_raca' table. You can move, or remove it, as needed.
            //this.tb_racaTableAdapter.Fill(this.petshop_2020DataSet.tb_raca);
            // TODO: This line of code loads data into the 'petshop_2020DataSet.tb_raca' table. You can move, or remove it, as needed.
            //this.tb_racaTableAdapter.Fill(this.petshop_2020DataSet.tb_raca);

            // TODO: This line of code loads data into the 'petshop_2020DataSet1.tb_raca' table. You can move, or remove it, as needed.
            //this.tb_racaTableAdapter.Fill(this.petshop_2020DataSet1.tb_raca);

            // TODO: This line of code loads data into the 'petshop_2020DataSet.tb_raca' table. You can move, or remove it, as needed.
            //this.tb_racaTableAdapter.Fill(this.petshop_2020DataSet.tb_raca);
            relatoriosDesativados();
            
            // TODO: This line of code loads data into the 'petshop_2020DataSet.tb_clienteanimais' table. You can move, or remove it, as needed.
            //this.tb_clienteanimaisTableAdapter.Fill(this.petshop_2020DataSet.tb_clienteanimais);

            // TODO: This line of code loads data into the 'petshop_2020DataSet.tb_veterinario' table. You can move, or remove it, as needed.
            //this.tb_veterinarioTableAdapter.Fill(this.petshop_2020DataSet.tb_veterinario);

            // TODO: This line of code loads data into the 'petshop_2020DataSet.tb_funcionario' table. You can move, or remove it, as needed.
            //this.tb_funcionarioTableAdapter.Fill(this.petshop_2020DataSet.tb_funcionario);

            // TODO: This line of code loads data into the 'petshop_2020DataSet.tb_raca' table. You can move, or remove it, as needed.
            //this.tb_racaTableAdapter.Fill(this.petshop_2020DataSet.tb_raca);

            // TODO: This line of code loads data into the 'petshop_2020DataSet.tb_tipo_animal' table. You can move, or remove it, as needed.
            //this.tb_tipo_animalTableAdapter.Fill(this.petshop_2020DataSet.tb_tipo_animal);

            // TODO: This line of code loads data into the 'petshop_2020DataSet.tb_consulta' table. You can move, or remove it, as needed.
            //this.tb_consultaTableAdapter.Fill(this.petshop_2020DataSet.tb_consulta);

            // TODO: This line of code loads data into the 'petshop_2020DataSet.tb_servicos' table. You can move, or remove it, as needed.
            //this.tb_servicosTableAdapter.Fill(this.petshop_2020DataSet.tb_servicos);

            // TODO: This line of code loads data into the 'petshop_2020DataSet.tb_cliente' table. You can move, or remove it, as needed.
            //this.tb_clienteTableAdapter.Fill(this.petshop_2020DataSet.tb_cliente);
                                
            //this.reportViewer_cliente.RefreshReport();
            //this.reportViewer_cliente.Visible = false;

            //this.reportViewer_servicos.RefreshReport();
            //this.reportViewer_servicos.Visible = false;

            //this.reportViewer_consultas.RefreshReport();
            //this.reportViewer_consultas.Visible = false;

            //this.reportViewer_tipo.RefreshReport();
            //this.reportViewer_tipo.Visible = false;

            //this.reportViewer_raca.RefreshReport();
            //this.reportViewer_raca.Visible = false;

            //this.reportViewer_funcionario.RefreshReport();
            //this.reportViewer_funcionario.Visible = false;

            //this.reportViewer_veterinario.RefreshReport();
            //this.reportViewer_veterinario.Visible = false;

            //this.reportViewer_relacionamento.RefreshReport();
            //this.reportViewer_relacionamento.Visible = false;


            btn_fechar_relatório.Enabled = false;
            //this.reportViewer1.RefreshReport();
            //this.report_racas.RefreshReport();
            //this.reportViewer_produtos.RefreshReport();
        }

        private void relatoriosDesativados()
        {
            this.reportViewer_cliente.Visible = false;
            this.reportViewer_servicos.Visible = false;
            this.reportViewer_consultas.Visible = false;
            this.reportViewer_tipo.Visible = false;
            this.reportViewer_raca.Visible = false;
            this.reportViewer_funcionario.Visible = false;
            this.reportViewer_veterinario.Visible = false;
            this.reportViewer_relacionamento.Visible = false;
            this.report_racas.Visible = false;
            this.reportViewer_produtos.Visible = false;
        }

        private void relatoriosOpen()
        {
            btn_criar_relatorio.Enabled = false;
            btn_fechar_relatório.Enabled = true;
            cb_tipo_relatório.Enabled = false;
        }
        private void relatoriosClose()
        {
            btn_criar_relatorio.Enabled = true;
            btn_fechar_relatório.Enabled = false;
            cb_tipo_relatório.Enabled = true;
        }

        private void cb_tipo_relatório_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (cb_tipo_relatório.Text == "Clientes")//cliente
            {
                this.reportViewer_servicos.Visible = false;
                this.reportViewer_cliente.Visible = true;
                this.reportViewer_consultas.Visible = false;
                this.reportViewer_tipo.Visible = false;
                this.reportViewer_raca.Visible = false;
                this.reportViewer_funcionario.Visible = false;
                this.reportViewer_veterinario.Visible = false;
                this.reportViewer_relacionamento.Visible = false;
            }*/

            /*if (cb_tipo_relatório.Text == "Serviços")//servicos
            {
                this.reportViewer_servicos.Visible = true;
                this.reportViewer_cliente.Visible = false;
                this.reportViewer_consultas.Visible = false;
                this.reportViewer_tipo.Visible = false;
                this.reportViewer_raca.Visible = false;
                this.reportViewer_funcionario.Visible = false;
                this.reportViewer_veterinario.Visible = false;
                this.reportViewer_relacionamento.Visible = false;
            }*/

            /*if (cb_tipo_relatório.Text == "Consultas")//consultas
            {
                this.reportViewer_servicos.Visible = false;
                this.reportViewer_cliente.Visible = false;
                this.reportViewer_consultas.Visible = true;
                this.reportViewer_tipo.Visible = false;
                this.reportViewer_raca.Visible = false;
                this.reportViewer_funcionario.Visible = false;
                this.reportViewer_veterinario.Visible = false;
                this.reportViewer_relacionamento.Visible = false;
            }*/

           /* if (cb_tipo_relatório.Text == "Tipos")
            {
                this.reportViewer_servicos.Visible = false;
                this.reportViewer_cliente.Visible = false;
                this.reportViewer_consultas.Visible = false;
                this.reportViewer_tipo.Visible = true;
                this.reportViewer_raca.Visible = false;
                this.reportViewer_funcionario.Visible = false;
                this.reportViewer_veterinario.Visible = false;
                this.reportViewer_relacionamento.Visible = false;
            }*/

            /*if (cb_tipo_relatório.Text == "Funcionários")
            {
                this.reportViewer_servicos.Visible = false;
                this.reportViewer_cliente.Visible = false;
                this.reportViewer_consultas.Visible = false;
                this.reportViewer_tipo.Visible = false;
                this.reportViewer_raca.Visible = false;
                this.reportViewer_funcionario.Visible = true;
                this.reportViewer_veterinario.Visible = false;
                this.reportViewer_relacionamento.Visible = false;
            }*/

            /*if (cb_tipo_relatório.Text == "Raças")
            {
                this.reportViewer_servicos.Visible = false;
                this.reportViewer_cliente.Visible = false;
                this.reportViewer_consultas.Visible = false;
                this.reportViewer_tipo.Visible = false;
                this.reportViewer_raca.Visible = true;
                this.reportViewer_funcionario.Visible = false;
                this.reportViewer_veterinario.Visible = false;
                this.reportViewer_relacionamento.Visible = false;
            }*/

            /*if (cb_tipo_relatório.Text == "Veterinários")
            {
                this.reportViewer_servicos.Visible = false;
                this.reportViewer_cliente.Visible = false;
                this.reportViewer_consultas.Visible = false;
                this.reportViewer_tipo.Visible = false;
                this.reportViewer_raca.Visible = false;
                this.reportViewer_funcionario.Visible = false;
                this.reportViewer_veterinario.Visible = true;
                this.reportViewer_relacionamento.Visible = false;
            }*/

            /*if (cb_tipo_relatório.Text == "Clientes X Animais")
            {
                this.reportViewer_servicos.Visible = false;
                this.reportViewer_cliente.Visible = false;
                this.reportViewer_consultas.Visible = false;
                this.reportViewer_tipo.Visible = false;
                this.reportViewer_raca.Visible = false;
                this.reportViewer_funcionario.Visible = false;
                this.reportViewer_veterinario.Visible = false;
                this.reportViewer_relacionamento.Visible = true;
            }*/
        }

        private void picture_fechar_Click(object sender, EventArgs e)
        {
            Menu_principal novo = new Menu_principal();
            novo.Show();
            this.Visible = false;
        }

        private void picture_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void reportViewer_raca_ReportExport(object sender, Microsoft.Reporting.WinForms.ReportExportEventArgs e)
        {

        }

        private void painel_exportar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_pdf_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_criar_relatorio_Click(object sender, EventArgs e)
        {
            try
            {
                relatoriosOpen();

                if (cb_tipo_relatório.Text == "Funcionários")
                {
                    this.reportViewer_funcionario.Visible = true;
                    this.tb_funcionarioTableAdapter.Fill(this.petshop_2020DataSet.tb_funcionario);
                    this.reportViewer_funcionario.RefreshReport();
                }

                if (cb_tipo_relatório.Text == "Veterinários")
                {
                    this.reportViewer_veterinario.Visible = true;
                    this.tb_veterinarioTableAdapter.Fill(this.petshop_2020DataSet.tb_veterinario);
                    this.reportViewer_veterinario.RefreshReport();
                }

                if (cb_tipo_relatório.Text == "Clientes")
                {
                    this.reportViewer_cliente.Visible = true;
                    this.tb_clienteTableAdapter.Fill(this.petshop_2020DataSet.tb_cliente);
                    this.reportViewer_cliente.RefreshReport();
                }

                if (cb_tipo_relatório.Text == "Clientes X Animais")
                {
                    this.reportViewer_relacionamento.Visible = true;
                    this.tb_clienteanimaisTableAdapter.Fill(this.petshop_2020DataSet.tb_clienteanimais);
                    this.reportViewer_relacionamento.RefreshReport();
                    
                }

                if (cb_tipo_relatório.Text == "Raças")
                {
                    
                    this.report_racas.Visible = true;
                    this.tb_racaTableAdapter.Fill(this.petshop_2020DataSet.tb_raca);
                    this.report_racas.RefreshReport();


                }
                if (cb_tipo_relatório.Text == "Serviços")
                {
                    this.reportViewer_servicos.Visible = true;
                    this.tb_servicosTableAdapter.Fill(this.petshop_2020DataSet.tb_servicos);
                    this.reportViewer_servicos.RefreshReport();
                }

                if (cb_tipo_relatório.Text == "Tipos")
                {
                    this.reportViewer_tipo.Visible = true;
                    this.tb_tipo_animalTableAdapter.Fill(this.petshop_2020DataSet.tb_tipo_animal);
                    this.reportViewer_tipo.RefreshReport();
                }

                if (cb_tipo_relatório.Text == "Consultas")
                {
                    this.reportViewer_consultas.Visible = true;
                    this.tb_consultaTableAdapter.Fill(this.petshop_2020DataSet.tb_consulta);
                    this.reportViewer_consultas.RefreshReport();
                }

                if (cb_tipo_relatório.Text == "Produtos")
                {
                    this.reportViewer_produtos.Visible = true;
                    this.tb_produtosTableAdapter.Fill(this.petshop_2020DataSet11.tb_produtos);
                    this.reportViewer_produtos.RefreshReport();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao gerar relatório");
            }
        }

        private void btn_fechar_relatório_Click(object sender, EventArgs e)
        {
            relatoriosClose();
            relatoriosDesativados();
        }




    }
}
