using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;



namespace pryOpenDb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataReader LectorDB;


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new OleDbConnection();
                connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\VERDULEROS.mdb;";
                connection.Open();
                MessageBox.Show("Conexion establecida");
            }
            catch (Exception ex)
            {
                MessageBox.Show("La Conexion no ha sido establecida" + "\n" + ex );
                throw;
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                float filtrar = Convert.ToSingle(nupFiltrar.Value);
                command = new OleDbCommand();
                command.Connection = connection; // CONECTAR EL COMAND CON EL CONNECTION
                command.CommandType = CommandType.TableDirect;

                // tabla dentro del acces de verduleros, llamada productos
                command.CommandText = "Productos";

                LectorDB = command.ExecuteReader();
                while (LectorDB.Read())
                {
                    float precioP = Convert.ToSingle(LectorDB[3]);
                    if (filtrar <= precioP)
                    {
                        dgvMostrar.Rows.Add(LectorDB[0], LectorDB[1], LectorDB[2], LectorDB[3]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido mostrar la tabla" + "\n" + ex);
            }

        }
    }
}
