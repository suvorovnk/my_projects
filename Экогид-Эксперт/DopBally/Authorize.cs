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
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Functions f = new Functions();
            if (f.CheckUser(textBox1.Text, textBox2.Text) == "директор")
            {
                AdminMenu am = new AdminMenu();
                this.Hide();
                am.Show();
            }
            else if (f.CheckUser(textBox1.Text, textBox2.Text) == "ошибка") MessageBox.Show("Неправильный логин или пароль");
            else
            {
                WorkerMenu w = new WorkerMenu(f.emplo_id);
                this.Hide();
                w.Show();
            }
        }

        private void Authorize_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Authorize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1_Click(sender, e);
        }
    }
}
