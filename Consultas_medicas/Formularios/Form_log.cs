using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Consultas_medicas.Formularios
{
    public partial class Form_log : Form
    {
        public Form_log()
        {
            InitializeComponent();

        }
        public Form_log(string user,string data)
        {
            InitializeComponent();
            lbl_user.Text = user;
            lbl_data_hora.Text = Convert.ToString(data);
        }


    }
}
