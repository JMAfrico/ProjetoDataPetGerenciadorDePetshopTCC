using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Consultas_medicas
{
    public partial class Form_splash_screen : Form
    {
        public Form_splash_screen()
        {
            InitializeComponent();
        }

        private void timer_splash_Tick(object sender, EventArgs e)
        {
            //contador da barra
            if(progressBar1.Value < 100){

                //valor da barra de progresso vai enchendo de 2 em 2 e o valor da barra é atribuido ao label
                progressBar1.Value = progressBar1.Value + 2;
                lbl_porcentagem.Text = progressBar1.Value.ToString()+ "%";

            }
            else
            {
                timer_splash.Enabled = false;
                this.Visible = false;

                Form_Login novo = new Form_Login();
                novo.Visible = true;
            }
        }
    }
}
