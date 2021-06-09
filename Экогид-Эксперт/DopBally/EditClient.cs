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
    public partial class EditClient : Form
    {
        public EditClient(int code_client)
        {
            InitializeComponent();
            this.code_client = code_client;
        }
        public int code_client;

        private void EditClient_Load(object sender, EventArgs e)
        {
            Functions f = new Functions();
            textBox1.Text= f.Client_Information(code_client)[0];
            textBox2.Text = f.Client_Information(code_client)[1];
            textBox3.Text = f.Client_Information(code_client)[2];
            textBox4.Text = f.Client_Information(code_client)[3];
            maskedTextBox1.Text = f.Client_Information(code_client)[4];
            textBox5.Text = f.Client_Information(code_client)[5];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "")&& (textBox3.Text != ""))
            {
                Functions f = new Functions();
                f.Editer_Client(code_client, textBox1.Text,textBox2.Text, textBox3.Text, textBox4.Text, maskedTextBox1.Text, textBox5.Text);
                MessageBox.Show("Информация о клиенте успешно редактирована");
                this.Close();
            }
            else MessageBox.Show("Заполните все обязательные поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
