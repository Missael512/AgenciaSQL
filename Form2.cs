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
    public partial class Form2 : Form
    {
        //Instancias:
        ConexionSQL registrarInformacion = new ConexionSQL();
       
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 goBack = new Form1();
            this.Hide();
            goBack.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                registrarInformacion.abrirConexion();
                registrarInformacion.agregarInformacion(placaTextbox.Text, agenciaTextbox.Text, Convert.ToInt32(anioTextbox.Text), nombreTextbox.Text);
                MessageBox.Show("Registrado con exito!!");
                registrarInformacion.cerrarConexion();
            }
            catch(Exception error)
            {
                MessageBox.Show("Ocurrio un error,verifique:\n"+error.Message);
                registrarInformacion.cerrarConexion();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            placaTextbox.Clear();
            agenciaTextbox.Clear();
            anioTextbox.Clear();
            nombreTextbox.Clear();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            registrarInformacion.abrirConexion();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            registrarInformacion.cerrarConexion();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de salir?", "Saliendo del sistema", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
