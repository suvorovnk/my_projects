using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DopBally
{
    public partial class AddEmployer : Form
    {
        public AddEmployer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((textBox1.Text!="")&& (textBox2.Text != "")&& (textBox3.Text != "")&& (textBox4.Text != "")&& (textBox5.Text != "")&& (textBox6.Text != ""))
            {
                Functions f = new Functions();
                f.AddingEmployer(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
                MessageBox.Show("Сотрудник успешно добавлен");
                this.Close();
            }
            else MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

       
    }
}
