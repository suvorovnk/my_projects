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
    public partial class WorkerMenu : Form
    {
        public WorkerMenu(int code_employer)
        {
            InitializeComponent();
            this.code_employer = code_employer;
        }
        public int code_employer;
        private void AddClients(object sender, EventArgs e)
        {
            AddClient ac = new AddClient();
            ac.Show();
        }

        private void UpdateClients(object sender, EventArgs e)
        {
            Functions f = new Functions();
            f.ShowClients(dataGridView1);
        }
        private void UpdatePurchases(object sender, EventArgs e)
        {
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            Functions f = new Functions();
            textBox1.Text = f.ShowPurchases(dataGridView2).ToString();
        }

        private void AddPurchases(object sender, EventArgs e)
        {
            Functions f = new Functions();
            string question = "Вы хотите оформить заказ на клиента " + f.ChooseClient(dataGridView1)[1] + " " + f.ChooseClient(dataGridView1)[2] + "?";
            DialogResult result = MessageBox.Show(question, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) MessageBox.Show("Выберите из списка клиентов другого заказчика");
            else
            {
                AddPurchase ap = new AddPurchase(code_employer, int.Parse(f.ChooseClient(dataGridView1)[0]));
                ap.Show();
            }
        }


        private void PurchaseDone(object sender, EventArgs e)
        {
            Functions f = new Functions();

            if (bool.Parse(f.ChoosePurchase(dataGridView2)[4]) == true) MessageBox.Show("Заказ уже выполнен");
            else
            {
                string question = "Вы хотите отметить как выполненный заказ <" + f.ChoosePurchase(dataGridView2)[0] + "> стоимостью " + f.ChoosePurchase(dataGridView2)[1] + " рублей и сроком сдачи " + f.ChoosePurchase(dataGridView2)[2] + "?";
                DialogResult result = MessageBox.Show(question, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) MessageBox.Show("Выберите из списка заказов другой заказ");
                else
                {
                    f.Purchase_done(int.Parse(f.ChoosePurchase(dataGridView2)[3]));
                    MessageBox.Show("Заказ отмечен как выполненный");
                }
            }


        }
        private void EditPurchases(object sender, EventArgs e)
        {
            try
            {
                Functions f = new Functions();
                string question = "Вы хотите редактировать информацию о заказе <" + f.ChoosePurchase(dataGridView2)[0] + "> стоимостью " + f.ChoosePurchase(dataGridView2)[1] + " рублей и сроком сдачи " + f.ChoosePurchase(dataGridView2)[2] + "?";
                DialogResult result = MessageBox.Show(question, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) MessageBox.Show("Выберите из списка заказов другой заказ");
                else
                {
                    EditPurchase ep = new EditPurchase(int.Parse(f.ChoosePurchase(dataGridView2)[3]));
                    ep.Show();
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Сначала выберете что хотите редактировать");
            }
        }
        private void EditClients(object sender, EventArgs e)
        {
            try
            {
                Functions f = new Functions();
                string question = "Вы хотите редактировать информацию о клиенте " + f.ChooseClient(dataGridView1)[1] + " " + f.ChooseClient(dataGridView1)[2] + "?";
                DialogResult result = MessageBox.Show(question, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) MessageBox.Show("Выберите из списка клиентов другого заказчика");
                else
                {
                    EditClient ec = new EditClient(int.Parse(f.ChooseClient(dataGridView1)[0]));
                    ec.Show();
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Сначала выберете что хотите редактировать");
            }
        }

        private void WorkerMenu_Load(object sender, EventArgs e)
        {
            Functions f = new Functions();
            f.ShowClients(dataGridView1);
            textBox1.Text=f.ShowPurchases(dataGridView2).ToString();
            dateTimePicker1.MaxDate = DateTime.Now;
            dateTimePicker2.MaxDate = DateTime.Now;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Functions f = new Functions();
            string question = "Вы хотите удалить информацию о клиенте " + f.ChooseClient(dataGridView1)[1] + " " + f.ChooseClient(dataGridView1)[2] + "?";
            DialogResult result = MessageBox.Show(question, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show(f.Delete_Client(int.Parse(f.ChooseClient(dataGridView1)[0])));
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void WorkerMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Authorize a = (Authorize)Application.OpenForms["Authorize"];
            a.Show();
            a.textBox1.Text = "";
            a.textBox2.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button12.Enabled = false;
            Functions f = new Functions();
            if ((button13.Enabled == true) && (button14.Enabled == true))
            {
                textBox1.Text=f.ShowDonePurchases(dataGridView2).ToString();
            }
            else if ((button13.Enabled == false) && (button14.Enabled == true))
            {
                textBox1.Text = f.ShowDoneBoughtPurchases(dataGridView2).ToString();
            }
            else if ((button13.Enabled == false) && (button14.Enabled == false))
            {
                textBox1.Text = f.ShowAllFilterPurchases(dataGridView2, dateTimePicker1.Value, dateTimePicker2.Value).ToString();
            }
            else if ((button13.Enabled == true) && (button14.Enabled == false))
            {
                textBox1.Text = f.ShowDateDonePurchases(dataGridView2, dateTimePicker1.Value, dateTimePicker2.Value).ToString();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            button13.Enabled = false;
            Functions f = new Functions();
            if ((button12.Enabled == true) && (button14.Enabled == true))
            {
                textBox1.Text = f.ShowBoughtPurchases(dataGridView2).ToString();
            }
            else if ((button12.Enabled == false) && (button14.Enabled == true))
            {
                textBox1.Text = f.ShowDoneBoughtPurchases(dataGridView2).ToString();
            }
            else if ((button12.Enabled == false) && (button14.Enabled == false))
            {
                textBox1.Text = f.ShowAllFilterPurchases(dataGridView2, dateTimePicker1.Value, dateTimePicker2.Value).ToString();
            }
            else if ((button12.Enabled == true) && (button14.Enabled == false))
            {
                textBox1.Text = f.ShowDateBoughtPurchases(dataGridView2, dateTimePicker1.Value, dateTimePicker2.Value).ToString();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            button14.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            Functions f = new Functions();
            if ((button12.Enabled == true) && (button13.Enabled == true))
            {
                textBox1.Text = f.ShowDatePurchases(dataGridView2, dateTimePicker1.Value, dateTimePicker2.Value).ToString();
            }
            else if ((button12.Enabled == false) && (button13.Enabled == true))
            {
                textBox1.Text = f.ShowDateDonePurchases(dataGridView2, dateTimePicker1.Value, dateTimePicker2.Value).ToString();
            }
            else if ((button12.Enabled == false) && (button13.Enabled == false))
            {
                textBox1.Text = f.ShowAllFilterPurchases(dataGridView2, dateTimePicker1.Value, dateTimePicker2.Value).ToString();
            }
            else if ((button12.Enabled == true) && (button13.Enabled == false))
            {
                textBox1.Text = f.ShowDateBoughtPurchases(dataGridView2, dateTimePicker1.Value, dateTimePicker2.Value).ToString();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Functions f = new Functions();

            if (bool.Parse(f.ChoosePurchase(dataGridView2)[5]) == true) MessageBox.Show("Заказ уже оплачен");
            else
            {
                string question = "Вы хотите отметить как оплаченный заказ <" + f.ChoosePurchase(dataGridView2)[0] + "> стоимостью " + f.ChoosePurchase(dataGridView2)[1] + " рублей и сроком сдачи " + f.ChoosePurchase(dataGridView2)[2] + "?";
                DialogResult result = MessageBox.Show(question, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) MessageBox.Show("Выберите из списка заказов другой заказ");
                else
                {
                    f.Purchase_bought(int.Parse(f.ChoosePurchase(dataGridView2)[3]));
                    MessageBox.Show("Заказ отмечен как оплаченный");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                Functions f = new Functions();
                string question = "Вы хотите удалить заказ <" + f.ChoosePurchase(dataGridView2)[0] + "> стоимостью " + f.ChoosePurchase(dataGridView2)[1] + " рублей и сроком сдачи " + f.ChoosePurchase(dataGridView2)[2] + "?";
                DialogResult result = MessageBox.Show(question, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) MessageBox.Show("Выберите из списка заказов другой заказ");
                else
                {
                    MessageBox.Show(f.Delete_Purchase(int.Parse(f.ChoosePurchase(dataGridView2)[3])));
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Сначала выберете что хотите удалить");
            }
        }
    }
}
