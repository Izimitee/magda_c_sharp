using System;
using System.Collections;
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
            MySqlConnection connection = new MySqlConnection("server=localhost;database=projetosconstrucao2;uid=root");

            string selectQuery = "select * from funcionario,especialista where funcionario.n_funcionario = especialista.n_funcionario";
            connection.Open();
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            MySqlDataReader reader = command.ExecuteReader();
            
            connection.Close();
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
            
            //Apresenta os numeros de funcionarios na comboBox
            
            comboBox_update_proj.DataSource = ds_especialista.Tables["funcionario,especialista"];
            comboBox_update_proj.DisplayMember = "n_funcionario";
            
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

        private void textBox_proj_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_inserir_Click(object sender, EventArgs e)
        {


            try
            {
                //This is my connection string i have assigned the database file address path  
                string MyConnection2 = "server=localhost;database=projetosconstrucao2;uid=root";
                //This is my insert query in which i am taking input from the user through windows forms  
                string Query = "insert into funcionario (n_funcionario,nome,extencao) values (" +
                    numericUpDown1.Value + ",'" +
                    textBox_insert_nome.Text +
                    "'," + numericUpDown2.Value + "); insert into especialista (tipo_projeto,n_funcionario) values ('" +
                    comboBox1.Text + "'," + numericUpDown1.Value + ")";


                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                //This is command class which will handle the query and connection object.  
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                // Here our query will be executed and data saved into the database.  
                MessageBox.Show("Game Saved ...");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mySQL_Empresa.Close();
            
            
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

        private void button_actualizar_Click(object sender, EventArgs e)
        {


            try
            {
                //This is my connection string i have assigned the database file address path  
                string MyConnection2 = "server=localhost;database=projetosconstrucao2;uid=root";
                //This is my insert query in which i am taking input from the user through windows forms  
                string Query = "UPDATE funcionario,especialista SET funcionario.nome = '" +
                    textBox_update_nome.Text + "',funcionario.extencao = '" +
                    numericUpDown_update_ext.Value + "',especialista.tipo_projeto = '" + comboBox_update_proj.Text + "' WHERE funcionario.n_funcionario = '" +
                    numericUpDown_update_n_func.Value + "' AND especialista.n_funcionario = '" + numericUpDown_update_n_func.Value + "'";
                
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                //This is command class which will handle the query and connection object.  
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                // Here our query will be executed and data saved into the database.  
                MessageBox.Show("Game Saved ...");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            mySQL_Empresa.Close();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                //This is my connection string i have assigned the database file address path  
                string MyConnection2 = "server=localhost;database=projetosconstrucao2;uid=root";
                //This is my insert query in which i am taking input from the user through windows forms  
                string Query = "delete from especialista where especialista.n_funcionario = "+ numericUpDown_delete_n_func.Value + ";" + 
                                "delete from funcionario where funcionario.n_funcionario = " + numericUpDown_delete_n_func.Value + ";";
                
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                //This is command class which will handle the query and connection object.  
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                // Here our query will be executed and data saved into the database.  
                MessageBox.Show("Game Saved ...");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
