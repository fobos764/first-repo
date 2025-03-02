using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Login
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pavlovNikolayDataSet.users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.pavlovNikolayDataSet.users);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Connect1 = new SqlConnection(@"Data Source=DESKTOP-L1QHDCQ;Initial Catalog=pavlovNikolay;Integrated Security=True");
            String query = "Select * FROM users WHERE login='" + comboBox1.Text + "'and password='" + textBox1.Text + "'";
            Connect1.Open();
            SqlCommand cmd = new SqlCommand(query, Connect1);
            SqlDataReader rdr = cmd.ExecuteReader();
            if(rdr.HasRows)
            {
                while(rdr.Read())
                {
                    object Login = rdr.GetValue(0);
                    object Password = rdr.GetValue(1);

                    string login = Login.ToString();
                    string password = Password.ToString();
                    if(login == "admin")
                    {
                        Form2 frm2 = new Form2();
                        frm2.Show();
                        this.Hide();
                    }
                    else if(login == "user1")
                    {
                        Form3 frm3 = new Form3();
                        frm3.Show();
                        this.Hide();
                    }
                }
            }
            else
            {
                MessageBox.Show("Не правильный пароль", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
