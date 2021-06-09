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
    public partial class AddPurchase : Form
    {
        public AddPurchase(int code_employer,int code_client)
        {
            InitializeComponent();
            this.code_employer = code_employer;
            this.code_client = code_client;
        }
        public int code_employer, code_client;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (float.Parse(textBox2.Text) > 0)
                {
                    if ((textBox1.Text != "") && (textBox2.Text != ""))
                    {
                        Functions f = new Functions();
                        f.AddingPurchase(code_employer, code_client, textBox1.Text, float.Parse(textBox2.Text), DateTime.Now, dateTimePicker1.Value);
                        MessageBox.Show("Заказ успешно добавлен");
                        this.Close();
                    }
                    else MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
                else MessageBox.Show("Неправильно введена стоимость!","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Неправильно введена стоимость!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddPurchase_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.MinDate = DateTime.Now;
        }
    }
}
