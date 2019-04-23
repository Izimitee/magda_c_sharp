using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Magda_c_sharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            DataSet ds_especialista = new DataSet();
            MySqlConnection mySQL_Empresa = new MySqlConnection();
            mySQL_Empresa.ConnectionString = "server=localhost;database=projetosconstrucao2;uid=root";
            try
            {
                mySQL_Empresa.Open();
                MessageBox.Show("Sucesso");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message.ToString());
            }
            MySqlDataAdapter mySQL_Consulta = new MySqlDataAdapter("select * from funcionario,especialista where funcionario.n_funcionario = especialista.n_funcionario ", mySQL_Empresa);
            mySQL_Consulta.Fill(ds_especialista, "funcionario");
            //Apresenta os dados na GridView
            dataGridView1.DataSource = ds_especialista;
            dataGridView1.DataMember = "funcionario";
            mySQL_Empresa.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ds_especialista = new DataSet();
            mySQL_Empresa = new MySqlConnection();
            mySQL_Empresa.ConnectionString = "server=localhost;database=projetosconstrucao2;uid=root";
            try
            {
                mySQL_Empresa.Open();
                MessageBox.Show("Sucesso");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message.ToString());
            }
            MySqlDataAdapter mySQL_consulta = new MySqlDataAdapter("select * from funcionario",mySQL_Empresa);
            mySQL_consulta.Fill(ds_especialista,"funcionario");

        }
        private DataSet ds_especialista;
        private MySqlConnection mySQL_Empresa;

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
