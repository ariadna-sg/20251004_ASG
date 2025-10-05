using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace CRUD_04102025
{
    public partial class Form1 : Form
    { 
        public Form1()
        {
            InitializeComponent();
        }

        string CadenaConexion = "Server=localhost;user=root;pasword=;port=3306;database=pruebacensa";

        private void btnConexion_Click(object sender, EventArgs e)
        {
            PruebaConexion();
        }
        public void PruebaConexion()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);

            try
            {
                mySqlConnection.Open();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse a la DB" + ex.Message);
                return;
            }
            mySqlConnection.Close();
            MessageBox.Show("Conectado exitosamente a la DB");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Create();
        }

        public void Create()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "INSERT INTO `pruebacensa`.`crud`(`id`,`nombre`,`apellido`) VALUES ('" + txtID.Text + "', '" + txtName.Text + "', '" + txtLName.Text + "' );";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro Insertado Exitosamente");
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            Update_();
        }

        public void Update_()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "UPDATE pruebacensa.crud " + "SET nombre = '" + txtName.Text + "', apellido = '" + txtLName.Text + "' " + "WHERE id = '" + txtID.Text + "';";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro Actualizado Exitosamente");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Delete();
        }

        public void Delete()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "DELETE FROM `pruebacensa`.`crud`" + "WHERE ID = '" + txtID.Text + "' ";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro Eliminado Exitosamente");
        }
    }
}
