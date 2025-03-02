using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Form3: Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pavlovNikolayDataSet2.Ocenki". При необходимости она может быть перемещена или удалена.
            this.ocenkiTableAdapter.Fill(this.pavlovNikolayDataSet2.Ocenki);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pavlovNikolayDataSet11.users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.pavlovNikolayDataSet11.users);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
                    }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        { 
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.CurrentCell = null;
                dataGridView1.Rows[i].Visible = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            dataGridView1.Rows[i].Visible = true;
                            break;
                        }
                    }
            }
        }
    }
}
