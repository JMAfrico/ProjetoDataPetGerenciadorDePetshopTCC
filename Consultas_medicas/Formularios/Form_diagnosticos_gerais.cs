using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Consultas_medicas.Models;
using Consultas_medicas.BLL;//chamada da classe intermediária
using Consultas_medicas.DAO;//chamada da classe query
using System.Reflection;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Consultas_medicas.Formularios
{
    public partial class Form_diagnosticos_gerais : Form
    {

        // MOVER A TELA--------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr HWnd, int wMsg, int wParam, int IParam);



        public Form_diagnosticos_gerais()
        {
            InitializeComponent();
            //listarDiagnosticos();
            //listaVeterinarios();
            brt_export_pdf_selecionado.Enabled = false;
            btn_diag_selecionado.Enabled = false;
        }

        public Form_diagnosticos_gerais(String cliente,String raca,String tipo,String nomepet,String peso,String idade,String tamanho,String cor,String sexo,String vacinas,String historico,String cod_consultas,String cod_cadastro,String nome_veterinario)
        {
            InitializeComponent();
            //listarDiagnosticos();
            lbl_diag_cliente.Text = cliente;
            lbl_diag_raca.Text = raca;
            lbl_diag_tipo_animal.Text = tipo;
            lbl_diag_idade.Text = idade;
            lbl_diag_nomePet.Text = nomepet;
            lbl_diag_peso.Text = peso;
            lbl_diag_tamanho.Text = tamanho;
            lbl_diag_cor.Text = cor;
            lbl_diag_sexo.Text = sexo;
            lbl_vacinas_tomadas.Text = vacinas;
            lbl_historico_medico.Text = historico;
            lbl_diag_codConsulta.Text = cod_consultas;
            lbl_diag_codCadastro.Text = cod_cadastro;
            lbl_nome_veterinario.Text = nome_veterinario;
            listaVeterinarios();
            brt_export_pdf_selecionado.Enabled = false;
            btn_diag_selecionado.Enabled = false;
            
        }

        public void limparCampos()
        {
            lista_diagnostico.Clear();
            lista_exames.Clear();
            lista_medicacao.Clear();
                
        }

        public void listarDiagnosticos()
        {
            Diagnostico_medicoBLL diagBLL = new Diagnostico_medicoBLL();
            dt_diagnosticos.DataSource = diagBLL.listarDiagnosticos();
        }

        private void picture_fechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void dt_diagnosticos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            brt_export_pdf_selecionado.Enabled = true;
            btn_diag_selecionado.Enabled = true;

            //lbl_cad.Text = dtAnimal.CurrentRow.Cells[0].Value.ToString();
            lbl_cliente.Text = dt_diagnosticos.CurrentRow.Cells["CLIENTE"].Value.ToString();
            lbl_raca.Text = dt_diagnosticos.CurrentRow.Cells["RACA"].Value.ToString();
            lbl_tipo.Text = dt_diagnosticos.CurrentRow.Cells["TIPO"].Value.ToString();
            lbl_pet.Text = dt_diagnosticos.CurrentRow.Cells["NOME"].Value.ToString();
            lbl_cor.Text = dt_diagnosticos.CurrentRow.Cells["COR"].Value.ToString();
            lbl_sexo.Text = dt_diagnosticos.CurrentRow.Cells["SEXO"].Value.ToString();
            lbl_tamanho.Text = dt_diagnosticos.CurrentRow.Cells["ALTURA"].Value.ToString();
            lbl_peso.Text = dt_diagnosticos.CurrentRow.Cells["PESO"].Value.ToString();
            lbl_idade.Text = dt_diagnosticos.CurrentRow.Cells["IDADE"].Value.ToString();
            txt_historico_medico.Text = dt_diagnosticos.CurrentRow.Cells["HISTORICO"].Value.ToString();
            txt_exames.Text = dt_diagnosticos.CurrentRow.Cells["EXAMES"].Value.ToString();
            txt_medicacao.Text = dt_diagnosticos.CurrentRow.Cells["MEDICACAO"].Value.ToString();
            txt_vacinas.Text = dt_diagnosticos.CurrentRow.Cells["VACINAS"].Value.ToString();
            txt_diagnostico.Text = dt_diagnosticos.CurrentRow.Cells["DIAGNOSTICO"].Value.ToString();

            
           // dt_diagnosticos.Columns["N DIAGNOSTICO"].Visible = false;
            dt_diagnosticos.Columns["CONSULTA"].Visible = false;
            dt_diagnosticos.Columns["CADASTRO"].Visible = false;

            string diag = dt_diagnosticos.CurrentRow.Cells["N DIAGNOSTICO"].Value.ToString();
            string cons = dt_diagnosticos.CurrentRow.Cells["CONSULTA"].Value.ToString();
            string cad = dt_diagnosticos.CurrentRow.Cells["CADASTRO"].Value.ToString();
            string data = dt_diagnosticos.CurrentRow.Cells["DATA"].Value.ToString();
            string hora = dt_diagnosticos.CurrentRow.Cells["HORA"].Value.ToString();

            dt_diagnostico_selecionado.Rows.Clear();
            dt_diagnostico_selecionado.Rows.Add(diag, cons, cad, lbl_cliente.Text, lbl_raca.Text, lbl_tipo.Text, lbl_pet.Text, lbl_idade.Text, lbl_peso.Text, lbl_tamanho.Text, lbl_cor.Text, lbl_sexo.Text, txt_vacinas.Text, txt_historico_medico.Text, txt_diagnostico.Text, txt_medicacao.Text, txt_exames.Text,data,hora);
            
        }

        private void btn_salvar_medico_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma os dados ?", "CONFIRMAR DIAGNÓSTICO? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Diagnostico_medico diag = new Diagnostico_medico();
                Salvar(diag);//

                {
                    if (MessageBox.Show("Deseja imprimir o diagnóstico ?", "PDF? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        String dia = Convert.ToString(DateTime.Now.Day);
                        String mes = Convert.ToString(DateTime.Now.Month);
                        String ano = Convert.ToString(DateTime.Now.Year);
                        String hora = Convert.ToString(DateTime.Now.Hour);
                        String minuto = Convert.ToString(DateTime.Now.Minute);
                        String segundo = Convert.ToString(DateTime.Now.Second);

                        exportarPDFDiagnosticoMarcado(@"J:\\Projetos\\ProjetoPetShop_2020\\ProjetoPetShop\\Relatorios_PDF\\RDiagnostico_Cliente " + dia + "" + mes + "" + ano + "_" + hora + "" + minuto + "" + segundo + ".pdf", "Relatório de Diagnósticos");
                        System.Diagnostics.Process.Start(@"J:\\Projetos\\ProjetoPetShop_2020\\ProjetoPetShop\\Relatorios_PDF\\RDiagnostico_Cliente " + dia + "" + mes + "" + ano + "_" + hora + "" + minuto + "" + segundo + ".pdf");
                        this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                    }

                }
            }
        }

        private void Salvar(Diagnostico_medico diagnostico)
        {
            try
            {
                if (lista_diagnostico.Text == String.Empty || lista_medicacao.Text == String.Empty)
                {
                    MessageBox.Show("Informações obrigatórias não preenchidas", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Diagnostico_medicoBLL diagnosticoBll = new Diagnostico_medicoBLL();

                    diagnostico.cod_cadastro = Convert.ToInt32(lbl_diag_codCadastro.Text);
                    diagnostico.cod_consulta = Convert.ToInt32(lbl_diag_codConsulta.Text);
                    diagnostico.descricao_diagnostico = lista_diagnostico.Text;
                    diagnostico.exames_diagnostico = lista_exames.Text;
                    diagnostico.medicacao_diagnostico = lista_medicacao.Text;
                    diagnostico.data_diagnostico = Convert.ToDateTime(lbl_data.Text);
                    diagnostico.hora_diagnostico = Convert.ToDateTime(lbl_hora.Text);

                    diagnosticoBll.salvar(diagnostico);
                    MessageBox.Show("Diagnostico salvo com sucesso !", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listarDiagnosticos();
                    //lista_diagnostico.Clear();
                    //lista_exames.Clear();
                    //lista_medicacao.Clear();
                }
            }
            catch(Exception erro)
            {
                MessageBox.Show("Não foi possível salvar diagnostico: erro = " + erro);
            }


        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lbl_hora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void Form_diagnosticos_gerais_Load(object sender, EventArgs e)
        {
            lbl_data.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btn_export_itensCliente_Click(object sender, EventArgs e)
        {
            //exportaExcelTodosDiagnosticos();
        }

        //EXPORTAR PARA O EXCEL
        Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
        private void exportaExcelTodosDiagnosticos()
        {
            if (dt_diagnosticos.Rows.Count == 0)
            {
                MessageBox.Show("Não a dados para serem gerados");
            }
            else
            {
                try
                {
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    //XcelApp.Cells[1, 2] = lbl_num_compra.Text;
                    //XcelApp.Cells[1, 2] = "LISTA GERAL DE COMPRAS EFETUADAS";
                    


                    for (int i = 1; i < dt_diagnosticos.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[2, i] = dt_diagnosticos.Columns[i - 1].HeaderText;//LINHA
                        
                        
                    }
                    //
                    for (int i = 0; i <= dt_diagnosticos.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dt_diagnosticos.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 3, j + 1] = dt_diagnosticos.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    
                    //
                    //XcelApp.get_Range
                    XcelApp.Columns.AutoFit();

                    //
                    XcelApp.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message);
                    XcelApp.Quit();
                }
            }
        }

        private void exportaExceldiagnosticoSelecionado()
        {

            if (dt_diagnostico_selecionado.Rows.Count > 0)
            {
                try
                {
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    //XcelApp.Cells[1, 2] = lbl_num_compra.Text;
                    //XcelApp.Cells[1, 2] = "LISTA GERAL DE COMPRAS EFETUADAS";



                    for (int i = 1; i < dt_diagnostico_selecionado.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[2, i] = dt_diagnostico_selecionado.Columns[i - 1].HeaderText;//LINHA


                    }
                    //
                    for (int i = 0; i <= dt_diagnostico_selecionado.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dt_diagnostico_selecionado.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 3, j + 1] = dt_diagnostico_selecionado.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    //
                    //XcelApp.get_Range
                    XcelApp.Columns.AutoFit();

                    //
                    XcelApp.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message);
                    XcelApp.Quit();
                }
            }
        }

        private void brn_exportar_excel_Click(object sender, EventArgs e)
        {
            exportaExcelTodosDiagnosticos();
        }

        private void brn_exportar_excel_Click_1(object sender, EventArgs e)
        {
            exportaExcelTodosDiagnosticos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            exportaExceldiagnosticoSelecionado();
        }

        public void listarConsultasHoje()
        {
            Diagnostico_medicoBLL diag = new Diagnostico_medicoBLL();
            dt_diagnosticos.DataSource = diag.listarDiagnosticosHoje();

        }

        public void listarConsultasUltimos3Dias()
        {
            Diagnostico_medicoBLL diag = new Diagnostico_medicoBLL();
            dt_diagnosticos.DataSource = diag.listarDiagnosticosUltimos3Dias();
        }

        public void listaVeterinarios()
        {
            VeterinarioBLL veterinariosBll = new VeterinarioBLL();
            this.cb_veterinario.ValueMember = "codVeterinario";
            this.cb_veterinario.DisplayMember = "nomeVeterinario";
            this.cb_veterinario.DataSource = veterinariosBll.listarVeteriNoCombobox();
        }

        //PESQUISAR TODOS DIAGNOSTICOS 
        private void pesquisarConsultas(Veterinarios vet)
        {
            try
            {
                Diagnostico_medicoBLL diag = new Diagnostico_medicoBLL();
                vet.nomeVeterinario = cb_veterinario.Text.Trim();

                dt_diagnosticos.DataSource = diag.listarDiagnosticos();

            }
            catch (System.Exception)
            {
                MessageBox.Show("Erro ao encontrar consultas");
            }

        }

        //PESQUISAR TODAS DIAGNOSTICOS DO VETERINÁRIO
        private void pesquisarConsultasSemData(Veterinarios vet)
        {
            try
            {
                Diagnostico_medicoBLL diag = new Diagnostico_medicoBLL();
                vet.nomeVeterinario = cb_veterinario.Text.Trim();

                dt_diagnosticos.DataSource = diag.ListarVeterinarioPorConsulta(vet);

            }
            catch (System.Exception)
            {
                MessageBox.Show("Erro ao encontrar consultas");
            }

        }

        //PESQUISAR DIAGNOSTICOS DE HOJE DO VETERINÁRIO
        private void pesquisarConsultasHoje(Veterinarios vet)
        {
            try
            {
                Diagnostico_medicoBLL diag = new Diagnostico_medicoBLL();
                vet.nomeVeterinario = cb_veterinario.Text.Trim();

                dt_diagnosticos.DataSource = diag.ListarVeterinarioPorConsultaHoje(vet);

            }
            catch (System.Exception)
            {
                MessageBox.Show("Erro ao encontrar consultas");
            }

        }

        //PESQUISAR DIAGNOSTICOS DE 3 DIAS ATRAZ
        private void pesquisarConsultas3dias(Veterinarios vet)
        {
            try
            {
                Diagnostico_medicoBLL diag = new Diagnostico_medicoBLL();
                vet.nomeVeterinario = cb_veterinario.Text.Trim();

                dt_diagnosticos.DataSource = diag.ListarVeterinarioPorConsultaMenos3Dias(vet);

            }
            catch (System.Exception)
            {
                MessageBox.Show("Erro ao encontrar consultas");
            }

        }

        private void rd_hoje_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rd_hoje_Click(object sender, EventArgs e)
        {
            //listarConsultasHoje();
        }

        private void rd_menos3dias_Click(object sender, EventArgs e)
        {
            //listarConsultasUltimos3Dias();
        }

        private void rd_todos_dias_Click(object sender, EventArgs e)
        {
            //listarDiagnosticos();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Existem dados preenchidos, deseja mesmo cancelar o diagnóstico ?", "CANCELAR DIAGNÓSTICO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                limparCampos();
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            Veterinarios vet = new Veterinarios();

            if (rd_hoje.Checked == true)
            {
                pesquisarConsultasHoje(vet);
            }

            if (rd_menos3dias.Checked == true)
            {
                pesquisarConsultas3dias(vet);
            }

            if (rd_todos_dias.Checked == true)
            {
                pesquisarConsultasSemData(vet);
            }

            if (rb_geral.Checked == true)
            {
                listarDiagnosticos();
            }

        }

        private void exportarPDFTodosDiagnosticos(DataGridView dt, String strPDF, string strHead)
        {
            System.IO.FileStream fs = new FileStream(strPDF, FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            doc.SetPageSize(iTextSharp.text.PageSize.A2);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            //CABEÇALHO
            BaseFont bfnHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfnHead, 22, 1, iTextSharp.text.BaseColor.BLACK);
            Paragraph paragrafo = new Paragraph();
            paragrafo.Alignment = Element.ALIGN_CENTER;
            paragrafo.Add(new Chunk(strHead.ToUpper(), fntHead));
            doc.Add(paragrafo);

            //DADOS
            Paragraph autor = new Paragraph();
            BaseFont bfnAutor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font Fontautor = new iTextSharp.text.Font(bfnHead, 16, 1, iTextSharp.text.BaseColor.GRAY);
            autor.Alignment = Element.ALIGN_LEFT;
            autor.Add(new Chunk("Autor : JOAO MARCOS", Fontautor));
            //autor.Add(new Chunk("\nCliente : " + lbl_nome_cliente.Text, Fontautor));
            autor.Add(new Chunk("\nData do Relatório:" + DateTime.Now, Fontautor));
            //autor.Add(new Chunk("\nTotal:" + lbl_total_geral.Text, Fontautor));
            autor.Add(new Chunk("\nQuantidade diagnósticos:" + dt_diagnosticos.RowCount, Fontautor));
            //autor.Add(new Chunk("\nTotal :" + lbl_TotalDasCompras.Text, Fontautor));

            autor.Add(new Chunk(" " + "", Fontautor));
            doc.Add(autor);

            //
            doc.Add(new Chunk("\n", fntHead));

            //TABELA
            PdfPTable pdfTable = new PdfPTable(dt_diagnosticos.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_JUSTIFIED_ALL;
            pdfTable.DefaultCell.BorderWidth = 1;

            foreach (DataGridViewColumn column in dt_diagnosticos.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);

            }

            //Adding DataRow
            foreach (DataGridViewRow row in dt_diagnosticos.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(cell.Value.ToString());
                }
            }

            doc.Add(pdfTable);
            doc.Close();
            writer.Close();
            fs.Close();
        }

        private void exportarPDFDiagnosticoSelecionado(DataGridView dt, String strPDF, string strHead)
        {
            try
            {
                System.IO.FileStream fs = new FileStream(strPDF, FileMode.Create, FileAccess.Write, FileShare.None);
                Document doc = new Document();
                doc.SetPageSize(iTextSharp.text.PageSize.A4);               
                PdfWriter writer = PdfWriter.GetInstance(doc,  fs);

                doc.Open();

                //CABEÇALHO
                BaseFont bfnHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfnHead, 16, 1, iTextSharp.text.BaseColor.BLACK);
                Paragraph paragrafo = new Paragraph();
                paragrafo.Alignment = Element.ALIGN_CENTER;
                paragrafo.Add(new Chunk(strHead.ToUpper(), fntHead));
                doc.Add(paragrafo);

                iTextSharp.text.Image imagem1 = iTextSharp.text.Image.GetInstance(@"J:\Projetos\ProjetoPetShop_2020\ProjetoPetShop\ProjectPet\LOGOnomePet-removebg-preview.png");
                imagem1.Alignment = Element.ALIGN_RIGHT;

                iTextSharp.text.Image imagem2 = iTextSharp.text.Image.GetInstance(@"J:\Projetos\ProjetoPetShop_2020\ProjetoPetShop\ProjectPet\ass.jpg");
                imagem2.Alignment = Element.ALIGN_BOTTOM;
                
                doc.Add(imagem1);

                //TITULOS E APRESENTAÇÕES
                Paragraph autor = new Paragraph();
                BaseFont bfnAutor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font Fontautor = new iTextSharp.text.Font(bfnHead, 12, 1, iTextSharp.text.BaseColor.GRAY);
                autor.Alignment = Element.ALIGN_LEFT;
                autor.Add(new Chunk("\nAutor : JOAO MARCOS", Fontautor));
                autor.Add(new Chunk("\nData do Relatório:" + DateTime.Now, Fontautor));
                autor.Add(new Chunk("\nVeterinário:" + dt_diagnosticos.CurrentRow.Cells["VETERINARIO"].Value.ToString(), Fontautor));
                autor.Add(new Chunk("\nDiagnóstico Nº:" + dt_diagnosticos.CurrentRow.Cells["N DIAGNOSTICO"].Value.ToString(), Fontautor));

                
                doc.Add(autor);


                //DADOS CLIENTE E PET
                Paragraph diag = new Paragraph();
                BaseFont bfndiag = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font FontDiag = new iTextSharp.text.Font(bfndiag, 12, 1, iTextSharp.text.BaseColor.BLACK);
                diag.Alignment = Element.ALIGN_LEFT;
                diag.Add(new Chunk("\n-----------------------------------------------------------\n ", FontDiag));
                diag.Add(new Chunk("\nCliente: " + dt_diagnosticos.CurrentRow.Cells["CLIENTE"].Value.ToString(), FontDiag));
                diag.Add(new Chunk("\nRaça: " + dt_diagnosticos.CurrentRow.Cells["RACA"].Value.ToString(), FontDiag));
                diag.Add(new Chunk("\nTipo:" + dt_diagnosticos.CurrentRow.Cells["TIPO"].Value.ToString(), FontDiag));
                diag.Add(new Chunk("\nSexo: " + dt_diagnosticos.CurrentRow.Cells["SEXO"].Value.ToString(), FontDiag));
                diag.Add(new Chunk("\nPET: " + dt_diagnosticos.CurrentRow.Cells["NOME"].Value.ToString(), FontDiag));
                diag.Add(new Chunk("\nCor:" + dt_diagnosticos.CurrentRow.Cells["COR"].Value.ToString(), FontDiag));
                diag.Add(new Chunk("\nAltura: " + dt_diagnosticos.CurrentRow.Cells["ALTURA"].Value.ToString(), FontDiag));
                diag.Add(new Chunk("\nPeso: " + dt_diagnosticos.CurrentRow.Cells["PESO"].Value.ToString(), FontDiag));
                diag.Add(new Chunk("\nIdade:" + dt_diagnosticos.CurrentRow.Cells["IDADE"].Value.ToString(), FontDiag));
                doc.Add(diag);

                //DADOS CLIENTE E PET
                Paragraph infos = new Paragraph();
                BaseFont baseInfos = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font FontInfos = new iTextSharp.text.Font(bfndiag, 12, 1, iTextSharp.text.BaseColor.DARK_GRAY);
                infos.Alignment = Element.ALIGN_LEFT;
                infos.Add(new Chunk("\n\nDiagnóstico:\n" + dt_diagnosticos.CurrentRow.Cells["DIAGNOSTICO"].Value.ToString()+"\n", FontInfos));
                //infos.Add(new Chunk("\n\nHistórico: " + dt_diagnosticos.CurrentRow.Cells["HISTORICO"].Value.ToString(), FontInfos));
                //infos.Add(new Chunk("\n\nVacinas: " + dt_diagnosticos.CurrentRow.Cells["VACINAS"].Value.ToString(), FontInfos));
                infos.Add(new Chunk("--------------------------------------------------------\n ", FontInfos));
                infos.Add(new Chunk("\n\nExames:\n" + dt_diagnosticos.CurrentRow.Cells["EXAMES"].Value.ToString()+"\n", FontInfos));
                infos.Add(new Chunk("---------------------------------------------------------\n ", FontInfos));
                infos.Add(new Chunk("\n\nMedicação:\n" + dt_diagnosticos.CurrentRow.Cells["MEDICACAO"].Value.ToString()+"\n", FontInfos));
                infos.Add(new Chunk("---------------------------------------------------------\n ", FontInfos));

                doc.Add(infos);
                doc.Add(imagem2);
                doc.Close();
                writer.Close();
                fs.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro\n" + erro);
            }
        }


        private void brt_export_pdf_todos_Click(object sender, EventArgs e)
        {
            if (dt_diagnosticos.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para serem buscados");
            }
            else
            {
                String dia = Convert.ToString(DateTime.Now.Day);
                String mes = Convert.ToString(DateTime.Now.Month);
                String ano = Convert.ToString(DateTime.Now.Year);
                String hora = Convert.ToString(DateTime.Now.Hour);
                String minuto = Convert.ToString(DateTime.Now.Minute);
                String segundo = Convert.ToString(DateTime.Now.Second);

                exportarPDFTodosDiagnosticos(dt_diagnosticos, @"J:\\Projetos\\ProjetoPetShop_2020\\ProjetoPetShop\\Relatorios_PDF\\RDiagnostico " + dia + "" + mes + "" + ano + "_" + hora + "" + minuto + "" + segundo + ".pdf", "Relatório de Diagnósticos");
                System.Diagnostics.Process.Start(@"J:\\Projetos\\ProjetoPetShop_2020\\ProjetoPetShop\\Relatorios_PDF\\RDiagnostico " + dia + "" + mes + "" + ano + "_" + hora + "" + minuto + "" + segundo + ".pdf");
                this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            }
        }

        private void brt_export_pdf_selecionado_Click(object sender, EventArgs e)
        {
            if (dt_diagnostico_selecionado.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para serem buscados");
            }
            else
            {
                String dia = Convert.ToString(DateTime.Now.Day);
                String mes = Convert.ToString(DateTime.Now.Month);
                String ano = Convert.ToString(DateTime.Now.Year);
                String hora = Convert.ToString(DateTime.Now.Hour);
                String minuto = Convert.ToString(DateTime.Now.Minute);
                String segundo = Convert.ToString(DateTime.Now.Second);

                exportarPDFDiagnosticoSelecionado(dt_diagnostico_selecionado, @"J:\\Projetos\\ProjetoPetShop_2020\\ProjetoPetShop\\Relatorios_PDF\\RDiagnostico_Cliente " + dia + "" + mes + "" + ano + "_" + hora + "" + minuto + "" + segundo + ".pdf", "Relatório de Diagnósticos");
                System.Diagnostics.Process.Start(@"J:\\Projetos\\ProjetoPetShop_2020\\ProjetoPetShop\\Relatorios_PDF\\RDiagnostico_Cliente " + dia + "" + mes + "" + ano + "_" + hora + "" + minuto + "" + segundo + ".pdf");
                this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            }
        }

        private void btn_carregar_diagnosticos_Click(object sender, EventArgs e)
        {
            listarDiagnosticos();
            dt_diagnosticos.Columns["N DIAGNOSTICO"].Visible = false;
            dt_diagnosticos.Columns["CONSULTA"].Visible = false;
            dt_diagnosticos.Columns["CADASTRO"].Visible = false;
            listaVeterinarios();
        }

        private void exportarPDFDiagnosticoMarcado(String strPDF, string strHead)
        {
            try
            {
                System.IO.FileStream fs = new FileStream(strPDF, FileMode.Create, FileAccess.Write, FileShare.None);
                Document doc = new Document();
                doc.SetPageSize(iTextSharp.text.PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);

                doc.Open();

                //CABEÇALHO
                BaseFont bfnHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfnHead, 16, 1, iTextSharp.text.BaseColor.BLACK);
                Paragraph paragrafo = new Paragraph();
                paragrafo.Alignment = Element.ALIGN_CENTER;
                paragrafo.Add(new Chunk(strHead.ToUpper(), fntHead));
                doc.Add(paragrafo);

                iTextSharp.text.Image imagem1 = iTextSharp.text.Image.GetInstance(@"J:\Projetos\ProjetoPetShop_2020\ProjetoPetShop\ProjectPet\LOGOnomePet-removebg-preview.png");
                imagem1.Alignment = Element.ALIGN_RIGHT;

                iTextSharp.text.Image imagem2 = iTextSharp.text.Image.GetInstance(@"J:\Projetos\ProjetoPetShop_2020\ProjetoPetShop\ProjectPet\ass.jpg");
                imagem2.Alignment = Element.ALIGN_BOTTOM;

                doc.Add(imagem1);
                

                //TITULOS E APRESENTAÇÕES
                Paragraph autor = new Paragraph();
                BaseFont bfnAutor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font Fontautor = new iTextSharp.text.Font(bfnHead, 12, 1, iTextSharp.text.BaseColor.GRAY);
                autor.Alignment = Element.ALIGN_LEFT;
                autor.Add(new Chunk("\nAutor : JOAO MARCOS", Fontautor));
                autor.Add(new Chunk("\nData do Relatório:" + DateTime.Now, Fontautor));
                autor.Add(new Chunk("\nVeterinário:" + lbl_nome_veterinario.Text, Fontautor));
                autor.Add(new Chunk("\nConsulta Nº:" + lbl_diag_codConsulta.Text, Fontautor));


                doc.Add(autor);


                //DADOS CLIENTE E PET
                Paragraph diag = new Paragraph();
                BaseFont bfndiag = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font FontDiag = new iTextSharp.text.Font(bfndiag, 12, 1, iTextSharp.text.BaseColor.BLACK);
                diag.Alignment = Element.ALIGN_LEFT;
                diag.Add(new Chunk("\n-----------------------------------------------------------\n ", FontDiag));
                diag.Add(new Chunk("\nCliente: " + lbl_diag_cliente.Text, FontDiag));
                diag.Add(new Chunk("\nRaça: " + lbl_diag_raca.Text, FontDiag));
                diag.Add(new Chunk("\nTipo: " + lbl_diag_tipo_animal.Text, FontDiag));
                diag.Add(new Chunk("\nSexo: " + lbl_diag_sexo.Text, FontDiag));
                diag.Add(new Chunk("\nPET: " + lbl_diag_nomePet.Text, FontDiag));
                diag.Add(new Chunk("\nCor: " + lbl_diag_cor.Text, FontDiag));
                diag.Add(new Chunk("\nAltura: " + lbl_diag_tamanho.Text, FontDiag));
                diag.Add(new Chunk("\nPeso: " + lbl_diag_peso.Text, FontDiag));
                diag.Add(new Chunk("\nIdade:" + lbl_diag_idade.Text, FontDiag));
                doc.Add(diag);

                //DADOS CLIENTE E PET
                Paragraph infos = new Paragraph();
                BaseFont baseInfos = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font FontInfos = new iTextSharp.text.Font(bfndiag, 12, 1, iTextSharp.text.BaseColor.DARK_GRAY);
                infos.Alignment = Element.ALIGN_LEFT;
                infos.Add(new Chunk("\n\nDiagnóstico:\n" + lista_diagnostico.Text + "\n", FontInfos));
                //infos.Add(new Chunk("\n\nHistórico: " + dt_diagnosticos.CurrentRow.Cells["HISTORICO"].Value.ToString(), FontInfos));
                //infos.Add(new Chunk("\n\nVacinas: " + dt_diagnosticos.CurrentRow.Cells["VACINAS"].Value.ToString(), FontInfos));
                infos.Add(new Chunk("--------------------------------------------------------\n ", FontInfos));
                infos.Add(new Chunk("\n\nExames:\n" + lista_exames.Text + "\n", FontInfos));
                infos.Add(new Chunk("---------------------------------------------------------\n ", FontInfos));
                infos.Add(new Chunk("\n\nMedicação:\n" + lista_medicacao.Text + "\n", FontInfos));
                infos.Add(new Chunk("---------------------------------------------------------\n ", FontInfos));

                doc.Add(infos);
                doc.Add(imagem2);
                
                doc.Close();
                writer.Close();
                fs.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro\n" + erro);
            }
        }


    }
}
