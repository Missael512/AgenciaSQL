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
    public partial class Form1 : Form
    {
        //Instancias:
        Form2 registarAuto = new Form2();
        //SQL:
        ConexionSQL sqlConexion = new ConexionSQL();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            registarAuto.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                sqlConexion.abrirConexion();
                MessageBox.Show("Conexion exitosa!");
                sqlConexion.cerrarConexion();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mostarDatos obj = new mostarDatos();
            obj.Show();
        }
    }
}
