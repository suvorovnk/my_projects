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
    public partial class EditEmp : Form
    {
        public EditEmp(int cod)
        {
            InitializeComponent();
            this.cod = cod;
        }
        public int cod;
        private void EditEmp_Load(object sender, EventArgs e)
        {
            Functions f = new Functions();
            textBox1.Text= f.Employer_Information(cod)[0];
            textBox2.Text = f.Employer_Information(cod)[1];
            textBox3.Text = f.Employer_Information(cod)[2];
            textBox4.Text = f.Employer_Information(cod)[3];
            textBox5.Text = f.Employer_Information(cod)[4];
            textBox6.Text = f.Employer_Information(cod)[5];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox5.Text != "") && (textBox6.Text != ""))
            {
                Functions f = new Functions();
                f.Editer_Employer(cod,textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
                MessageBox.Show("Информация о сотруднике успешно редактирована");
                this.Close();
            }
            else MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
