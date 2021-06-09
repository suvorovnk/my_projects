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
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            AddEmployer a = new AddEmployer();
            a.Show();
        }

        private void AdminMenu_Load(object sender, EventArgs e)
        {
            Functions f = new Functions();
            f.ShowEmployers(dataGridView1);
        }
        private void label5_Click(object sender, EventArgs e)
        {
            Functions f = new Functions();
            string question = "Вы хотите уволить сотрудника " + f.ChooseEmployer(dataGridView1)[1] + " " + f.ChooseEmployer(dataGridView1)[2] + "?";
            DialogResult result = MessageBox.Show(question, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show(f.Delete_Employer(int.Parse(f.ChooseEmployer(dataGridView1)[0])));
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
            Functions f = new Functions();
            string question = "Вы хотите редактировать данные о сотруднике " + f.ChooseEmployer(dataGridView1)[1] + " " + f.ChooseEmployer(dataGridView1)[2] + "?";
            DialogResult result = MessageBox.Show(question, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                EditEmp ed = new EditEmp(int.Parse(f.ChooseEmployer(dataGridView1)[0]));
                ed.Show();
            }
        }
        private void label18_Click(object sender, EventArgs e)
        {
            Functions f = new Functions();
            f.ShowEmployers(dataGridView1);
        }
        private void AdminMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Authorize a = (Authorize)Application.OpenForms["Authorize"];
            a.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
