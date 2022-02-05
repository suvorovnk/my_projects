using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DopBally
{
    public partial class Authorize : Form
    {
        public Authorize()
        {
            InitializeComponent();

        }

        // Функция "Показать/скрыть пароль"
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

        // Обработка события нажатия кнопки "Войти"
        private void button1_Click(object sender, EventArgs e)
        {
            Functions function = new Functions();
            // Открытие формы в зависимости от роли 
            if (function.CheckUser(textBox1.Text, textBox2.Text) == "директор")
            {
                AdminMenu adminMenu = new AdminMenu();
                this.Hide();
                adminMenu.Show();
            }
            else if (function.CheckUser(textBox1.Text, textBox2.Text) == "ошибка") MessageBox.Show("Неправильный логин или пароль");
            else
            {
                WorkerMenu workerMenu = new WorkerMenu(function.emplo_id);
                this.Hide();
                workerMenu.Show();
            }
        }

        // Обработчик закрытия формы авторизации
        private void Authorize_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // При нажатии клавиши Enter будет производиться вход
        private void Authorize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1_Click(sender, e);
        }
    }
}
