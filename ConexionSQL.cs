using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AgenciaConSQL
{
    class ConexionSQL
    {
       string cadenaConexion = "data source =LAPTOP-5P36DV0Q;initial catalog=Autos;integrated security=true";
       public SqlConnection Conectarse = new SqlConnection();
       //Constructor:
        public ConexionSQL()
        {
            Conectarse.ConnectionString = cadenaConexion;
        }
        //Metodo para conectarse:
        public void abrirConexion()
        {

            Conectarse.Open();
        }
        //Cerrar conexion:
        public void cerrarConexion()
        {
            Conectarse.Close();
        }
        //Metodo para agregar informacion a una base de datos:
        //En este caso a una tabla 
        //NOTA: Si el dato es de tipo cadena:'"+Variable+"'
        //Si es de tipo int: "+Variable+"

        public void agregarInformacion(string Placa,string Agencia,int anio,string Nombre)
        {
            try
            {
                //Comandos de SQL
                string cadenaInsertar ="Insert into autosInfo(Placa,Agencia,Anio,Nombre) values('"+Placa+"','"+Agencia+"',"+anio+",'"+Nombre+"')";
                SqlCommand addInfo = new SqlCommand(cadenaInsertar,Conectarse);
                addInfo.ExecuteNonQuery();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }
        //Para mostrar los datos:
        DataTable dt;
        SqlDataAdapter da;
        public void showinfo(DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("Select * from autosInfo",Conectarse);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch(Exception j)
            {
                MessageBox.Show(j.Message);
            }  
        }
     //Realizar una busqueda:
     public void buscarInformacion(string placaBuscar,DataGridView tabla)
        {
            try
            {
                string cadenaBusqueda = "Select Placa from autosInfo where Placa like '%'";
                SqlDataAdapter buscar = new SqlDataAdapter(cadenaBusqueda + placaBuscar + "'%'", Conectarse);
                DataSet ds = new DataSet();
                buscar.Fill(ds, "Autos");
                tabla.DataSource = ds.Tables[0];
            }
            catch(Exception k)
            {
                MessageBox.Show(k.Message);
            }
        }

    }
}
