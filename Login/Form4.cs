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

namespace Login
{
    public partial class Form4: Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text !="" && textBox2.Text !="" && textBox3.Text != "")
            {
                if(textBox3.Text == textBox2.Text)
                {
                    if(textBox2.Text.Length >=6 && textBox3.Text.Length >=6)
                    {
                        string userLogin = textBox1.Text.Trim();
                        string userPass = textBox2.Text.Trim();

                        SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-L1QHDCQ;Initial Catalog=pavlovNikolay;Integrated Security=True");
                        string query = "SELECT * FROM users WHERE login = '" + userLogin + "'";

                        con1.Open();
                        SqlCommand cmd = new SqlCommand(query, con1);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if(reader.HasRows)
                        {
                            MessageBox.Show("Данный пользователь уже существует");
                            reader.Close();
                        }
                        else
                        {
                            reader.Close();
                            string insertquery = "INSERT INTO users (login, password) VALUES ('" + userLogin + "','" + userPass + "')";
                            SqlCommand cmd2 = new SqlCommand(insertquery, con1);
                            cmd2.ExecuteNonQuery();
                            MessageBox.Show("Вы успешно зарегистрированы");
                            Form4.ActiveForm.Close();
                        }
                        con1.Close();
                    }
                    else
                    {
                        MessageBox.Show("Паароли должен иметь длину больше или равно 6 символов");
                    }
                }
                else
                {
                    MessageBox.Show("Паароли должны совпадать");
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }
    }
}
