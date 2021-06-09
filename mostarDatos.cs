using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgenciaConSQL
{
    public partial class mostarDatos : Form
    {
        public mostarDatos()
        {
            InitializeComponent();
            
        }
        
        ConexionSQL obj = new ConexionSQL();
        private void mostarDatos_Load(object sender, EventArgs e)
        {
            obj.showinfo(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mostarDatos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            obj.buscarInformacion(textBox1.Text, dataGridView1);
        }
    }
}
