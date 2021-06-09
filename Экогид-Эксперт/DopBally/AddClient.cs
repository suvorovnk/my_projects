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
    public partial class AddClient : Form
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "")&& (textBox3.Text != ""))
            {
                Functions f = new Functions();
                f.AddingClient(textBox1.Text,textBox2.Text, textBox3.Text, textBox4.Text, maskedTextBox1.Text, textBox5.Text);
                MessageBox.Show("Клиент упешно добавлен");
                this.Close();
            }
            else MessageBox.Show("Заполните все обязательные поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
