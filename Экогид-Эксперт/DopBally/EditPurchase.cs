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
    public partial class EditPurchase : Form
    {
        public EditPurchase(int cod_pur)
        {
            InitializeComponent();
            this.cod_pur = cod_pur;
        }
        public int cod_pur;
        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != ""))
            {
                Functions f = new Functions();
                f.Editer_Purchase(cod_pur, textBox1.Text, float.Parse(textBox2.Text),dateTimePicker2.Value,dateTimePicker1.Value, checkBox1.Checked, checkBox2.Checked);
                MessageBox.Show("Информация о заказе успешно редактирована");
                this.Close();
            }
            else MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EditPurchase_Load(object sender, EventArgs e)
        {
            Functions f = new Functions();
            textBox1.Text = f.Purchase_Information(cod_pur)[0];
            textBox2.Text = f.Purchase_Information(cod_pur)[1];
            dateTimePicker1.Value = DateTime.Parse(f.Purchase_Information(cod_pur)[2]);
            dateTimePicker1.MinDate = DateTime.Now;
            checkBox1.Checked = bool.Parse(f.Purchase_Information(cod_pur)[3]);
            checkBox2.Checked = bool.Parse(f.Purchase_Information(cod_pur)[4]);
        }
    }
}
