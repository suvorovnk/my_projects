using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DopBally
{
    class Functions
    {
        public static ecologyEntities db = new ecologyEntities();
        public int emplo_id;
        
        // Метод авторизации пользователя
        public string CheckUser(string l, string p)
        {
            List<employers> workers = (from emps in db.employers select emps).ToList();
            string role="ошибка";
            foreach (var emps in workers)
            {
                if ((emps.login == l) && (emps.password == p))
                {
                    emplo_id = emps.emp_id;
                    role = emps.role;
                }
            }
            return role;
        }
        public void ShowEmployers(DataGridView dataGridView1)
        {
            var query = (from e in db.employers orderby e.surname, e.name, e.patronymic select e).ToList();
            dataGridView1.DataSource = query;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Отчество";
            dataGridView1.Columns[4].HeaderText = "Логин";
            dataGridView1.Columns[5].HeaderText = "Пароль";
            dataGridView1.Columns[6].HeaderText = "Должность";
            dataGridView1.Columns[7].Visible = false;
        }
        public void ShowClients(DataGridView dataGridView1)
        {
            var query = (from c in db.clients orderby c.surname, c.name, c.patronymic select c).ToList();
            dataGridView1.DataSource = query;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Отчество";
            dataGridView1.Columns[4].HeaderText = "Номер телефона";
            dataGridView1.Columns[5].HeaderText = "Почта";
            dataGridView1.Columns[6].HeaderText = "Название организации";
            dataGridView1.Columns[7].Visible = false;
        }
        public float ShowPurchases(DataGridView dataGridView1)
        {


            var query = (from c in db.clients
                         join p in db.purchase on c.client_id equals p.client_id
                         join em in db.employers on p.emp_id equals em.emp_id
                         select new { p.purchase_id, c.company, c.surname, c.name, p.service, p.price, p.date_add, p.date_end, p.done, p.registry }).ToList();
            dataGridView1.DataSource = query;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Название организации";
            dataGridView1.Columns[2].HeaderText = "Фамилия заказчика";
            dataGridView1.Columns[3].HeaderText = "Имя заказчика";
            dataGridView1.Columns[4].HeaderText = "Услуга";
            dataGridView1.Columns[5].HeaderText = "Стоимость";
            dataGridView1.Columns[6].HeaderText = "Дата заявки на услугу";
            dataGridView1.Columns[7].HeaderText = "Срок сдачи";
            dataGridView1.Columns[8].HeaderText = "Выполнен заказ?";
            dataGridView1.Columns[9].HeaderText = "Выплачен заказ?";
            try
            {
                return (from c in db.clients
                        join p in db.purchase on c.client_id equals p.client_id
                        join em in db.employers on p.emp_id equals em.emp_id
                        select p.price).Sum();
            }
            catch (System.InvalidOperationException)
            {
                return 0;
            }
        }
        public float ShowDonePurchases(DataGridView dataGridView1)
        {



            var query = (from c in db.clients
                         join p in db.purchase on c.client_id equals p.client_id
                         join em in db.employers on p.emp_id equals em.emp_id
                         where p.done == true
                         select new { p.purchase_id, c.company, c.surname, c.name, p.service, p.price, p.date_add, p.date_end, p.done, p.registry }).ToList();
            dataGridView1.DataSource = query;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Название организации";
            dataGridView1.Columns[2].HeaderText = "Фамилия заказчика";
            dataGridView1.Columns[3].HeaderText = "Имя заказчика";
            dataGridView1.Columns[4].HeaderText = "Услуга";
            dataGridView1.Columns[5].HeaderText = "Стоимость";
            dataGridView1.Columns[6].HeaderText = "Дата заявки на услугу";
            dataGridView1.Columns[7].HeaderText = "Срок сдачи";
            dataGridView1.Columns[8].HeaderText = "Выполнен заказ?";
            dataGridView1.Columns[9].HeaderText = "Выплачен заказ?";
            try
            {
                return (from c in db.clients
                        join p in db.purchase on c.client_id equals p.client_id
                        join em in db.employers on p.emp_id equals em.emp_id
                        where p.done == true
                        select p.price).Sum();
            }
            catch (System.InvalidOperationException)
            {
                return 0;
            }
        }
        public float ShowBoughtPurchases(DataGridView dataGridView1)
        {

            var query = (from c in db.clients
                         join p in db.purchase on c.client_id equals p.client_id
                         join em in db.employers on p.emp_id equals em.emp_id
                         where p.registry == true
                         select new { p.purchase_id, c.company, c.surname, c.name, p.service, p.price, p.date_add, p.date_end, p.done, p.registry }).ToList();
            dataGridView1.DataSource = query;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Название организации";
            dataGridView1.Columns[2].HeaderText = "Фамилия заказчика";
            dataGridView1.Columns[3].HeaderText = "Имя заказчика";
            dataGridView1.Columns[4].HeaderText = "Услуга";
            dataGridView1.Columns[5].HeaderText = "Стоимость";
            dataGridView1.Columns[6].HeaderText = "Дата заявки на услугу";
            dataGridView1.Columns[7].HeaderText = "Срок сдачи";
            dataGridView1.Columns[8].HeaderText = "Выполнен заказ?";
            dataGridView1.Columns[9].HeaderText = "Выплачен заказ?";
            try
            {
                return (from c in db.clients
                        join p in db.purchase on c.client_id equals p.client_id
                        join em in db.employers on p.emp_id equals em.emp_id
                        where p.registry == true
                        select p.price).Sum();
            }
            catch (System.InvalidOperationException)
            {
                return 0;
            }
        }
        public float ShowDoneBoughtPurchases(DataGridView dataGridView1)
        {

            var query = (from c in db.clients
                         join p in db.purchase on c.client_id equals p.client_id
                         join em in db.employers on p.emp_id equals em.emp_id
                         where (p.registry == true) && (p.done == true)
                         select new { p.purchase_id, c.company, c.surname, c.name, p.service, p.price, p.date_add, p.date_end, p.done, p.registry }).ToList();
            dataGridView1.DataSource = query;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Название организации";
            dataGridView1.Columns[2].HeaderText = "Фамилия заказчика";
            dataGridView1.Columns[3].HeaderText = "Имя заказчика";
            dataGridView1.Columns[4].HeaderText = "Услуга";
            dataGridView1.Columns[5].HeaderText = "Стоимость";
            dataGridView1.Columns[6].HeaderText = "Дата заявки на услугу";
            dataGridView1.Columns[7].HeaderText = "Срок сдачи";
            dataGridView1.Columns[8].HeaderText = "Выполнен заказ?";
            dataGridView1.Columns[9].HeaderText = "Выплачен заказ?";
            try
            {
                return (from c in db.clients
                        join p in db.purchase on c.client_id equals p.client_id
                        join em in db.employers on p.emp_id equals em.emp_id
                        where (p.registry == true) && (p.done == true)
                        select p.price).Sum();
            }
            catch (System.InvalidOperationException)
            {
                return 0;
            }
        }

        public float ShowDatePurchases(DataGridView dataGridView1, DateTime d1, DateTime d2)
        {

            var query = (from c in db.clients
                         join p in db.purchase on c.client_id equals p.client_id
                         join em in db.employers on p.emp_id equals em.emp_id
                         where (p.date_add > d1) && (p.date_add < d2)
                         select new { p.purchase_id, c.company, c.surname, c.name, p.service, p.price, p.date_add, p.date_end, p.done, p.registry }).ToList();
            dataGridView1.DataSource = query;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Название организации";
            dataGridView1.Columns[2].HeaderText = "Фамилия заказчика";
            dataGridView1.Columns[3].HeaderText = "Имя заказчика";
            dataGridView1.Columns[4].HeaderText = "Услуга";
            dataGridView1.Columns[5].HeaderText = "Стоимость";
            dataGridView1.Columns[6].HeaderText = "Дата заявки на услугу";
            dataGridView1.Columns[7].HeaderText = "Срок сдачи";
            dataGridView1.Columns[8].HeaderText = "Выполнен заказ?";
            dataGridView1.Columns[9].HeaderText = "Выплачен заказ?";
            try
            {
                return (from c in db.clients
                        join p in db.purchase on c.client_id equals p.client_id
                        join em in db.employers on p.emp_id equals em.emp_id
                        where (p.date_add > d1) && (p.date_add < d2)
                        select p.price).Sum();
            }
            catch (System.InvalidOperationException)
            {
                return 0;
            }
        }
        public float ShowDateDonePurchases(DataGridView dataGridView1, DateTime d1, DateTime d2)
        {

            var query = (from c in db.clients
                         join p in db.purchase on c.client_id equals p.client_id
                         join em in db.employers on p.emp_id equals em.emp_id
                         where (p.date_add > d1) && (p.date_add < d2) && (p.done == true)
                         select new { p.purchase_id, c.company, c.surname, c.name, p.service, p.price, p.date_add, p.date_end, p.done, p.registry }).ToList();
            dataGridView1.DataSource = query;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Название организации";
            dataGridView1.Columns[2].HeaderText = "Фамилия заказчика";
            dataGridView1.Columns[3].HeaderText = "Имя заказчика";
            dataGridView1.Columns[4].HeaderText = "Услуга";
            dataGridView1.Columns[5].HeaderText = "Стоимость";
            dataGridView1.Columns[6].HeaderText = "Дата заявки на услугу";
            dataGridView1.Columns[7].HeaderText = "Срок сдачи";
            dataGridView1.Columns[8].HeaderText = "Выполнен заказ?";
            dataGridView1.Columns[9].HeaderText = "Выплачен заказ?";
            try
            {
                return (from c in db.clients
                        join p in db.purchase on c.client_id equals p.client_id
                        join em in db.employers on p.emp_id equals em.emp_id
                        where (p.date_add > d1) && (p.date_add < d2) && (p.done == true)
                        select p.price).Sum();
            }
            catch (System.InvalidOperationException)
            {
                return 0;
            }
        }
        public float ShowDateBoughtPurchases(DataGridView dataGridView1, DateTime d1, DateTime d2)
        {

            var query = (from c in db.clients
                         join p in db.purchase on c.client_id equals p.client_id
                         join em in db.employers on p.emp_id equals em.emp_id
                         where (p.date_add > d1) && (p.date_add < d2) && (p.registry == true)
                         select new { p.purchase_id, c.company, c.surname, c.name, p.service, p.price, p.date_add, p.date_end, p.done, p.registry }).ToList();
            dataGridView1.DataSource = query;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Название организации";
            dataGridView1.Columns[2].HeaderText = "Фамилия заказчика";
            dataGridView1.Columns[3].HeaderText = "Имя заказчика";
            dataGridView1.Columns[4].HeaderText = "Услуга";
            dataGridView1.Columns[5].HeaderText = "Стоимость";
            dataGridView1.Columns[6].HeaderText = "Дата заявки на услугу";
            dataGridView1.Columns[7].HeaderText = "Срок сдачи";
            dataGridView1.Columns[8].HeaderText = "Выполнен заказ?";
            dataGridView1.Columns[9].HeaderText = "Выплачен заказ?";
            try
            {
                return (from c in db.clients
                        join p in db.purchase on c.client_id equals p.client_id
                        join em in db.employers on p.emp_id equals em.emp_id
                        where (p.date_add > d1) && (p.date_add < d2) && (p.registry == true)
                        select p.price).Sum();
            }
            catch (System.InvalidOperationException)
            {
                return 0;
            }
        }
        public float ShowAllFilterPurchases(DataGridView dataGridView1, DateTime d1, DateTime d2)
        {

            var query = (from c in db.clients
                         join p in db.purchase on c.client_id equals p.client_id
                         join em in db.employers on p.emp_id equals em.emp_id
                         where (p.date_add > d1) && (p.date_add < d2) && (p.done == true) && (p.registry == true)
                         select new { p.purchase_id, c.company, c.surname, c.name, p.service, p.price, p.date_add, p.date_end, p.done, p.registry }).ToList();
            dataGridView1.DataSource = query;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Название организации";
            dataGridView1.Columns[2].HeaderText = "Фамилия заказчика";
            dataGridView1.Columns[3].HeaderText = "Имя заказчика";
            dataGridView1.Columns[4].HeaderText = "Услуга";
            dataGridView1.Columns[5].HeaderText = "Стоимость";
            dataGridView1.Columns[6].HeaderText = "Дата заявки на услугу";
            dataGridView1.Columns[7].HeaderText = "Срок сдачи";
            dataGridView1.Columns[8].HeaderText = "Выполнен заказ?";
            dataGridView1.Columns[9].HeaderText = "Выплачен заказ?";
            try
            {
                return (from c in db.clients
                        join p in db.purchase on c.client_id equals p.client_id
                        join em in db.employers on p.emp_id equals em.emp_id
                        where (p.date_add > d1) && (p.date_add < d2) && (p.done == true) && (p.registry == true)
                        select p.price).Sum();
            }
            catch (System.InvalidOperationException)
            {
                return 0;
            }
        }
        public void AddingClient(string new_company, string new_surname, string new_name, string new_patronymic, string new_phone, string new_mail)
        {
            int number_client;
            if (db.clients.Count() == 0) number_client = 1;
            else number_client = db.clients.Max(we => we.client_id) + 1;
            clients new_client = new clients { client_id = number_client, company = new_company, surname = new_surname, name = new_name, patronymic = new_patronymic, phone_number = new_phone, mail = new_mail };
            db.clients.Add(new_client);
            db.SaveChanges();
        }
        public void AddingEmployer(string new_surname, string new_name, string new_patronymic, string new_login, string new_password, string new_role)
        {
            int number_employer;
            if (db.employers.Count() == 0) number_employer = 1;
            else number_employer = db.employers.Max(we => we.emp_id) + 1;
            employers new_employer = new employers { emp_id = number_employer, surname = new_surname, name = new_name, patronymic = new_patronymic, login = new_login, password = new_password, role = new_role };
            db.employers.Add(new_employer);
            db.SaveChanges();
        }
        public List<string> ChooseClient(DataGridView dgv)
        {
            List<clients> query = (from c in db.clients select c).ToList();
            clients client_choose = query.First(w => w.client_id.ToString() == dgv.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
            List<string> client_info = new List<string>();
            client_info.Add(client_choose.client_id.ToString());
            client_info.Add(client_choose.surname);
            client_info.Add(client_choose.name);
            return client_info;
        }
        public List<string> ChooseEmployer(DataGridView dgv)
        {
            List<employers> query = (from c in db.employers select c).ToList();
            employers emp_choose = query.First(w => w.emp_id.ToString() == dgv.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
            List<string> emp_info = new List<string>();
            emp_info.Add(emp_choose.emp_id.ToString());
            emp_info.Add(emp_choose.surname);
            emp_info.Add(emp_choose.name);
            return emp_info;
        }
        public string Delete_Employer(int cod)
        {

            int count_purchase = (from p in db.purchase where p.emp_id == cod select p).Count();
            if (count_purchase != 0)
            {
                var emp = db.employers.SingleOrDefault(w => w.emp_id == cod);
                emp.login = "";
                emp.password = "";
                emp.role = "";
                db.SaveChanges();
                return "Сотрудник уволен. Данные о нём сохранились, однако войти в систему он не может и должности не имеет." + count_purchase;
            }
            else
            {
                var emp = db.employers.SingleOrDefault(w => w.emp_id == cod);
                db.employers.Remove(emp);
                db.SaveChanges();
                return "Сотрудник уволен. Все данные о нём удалены";
            }
        }
        public string Delete_Client(int cod)
        {

            int count_purchase = (from p in db.purchase where p.client_id == cod select p).Count();
            if (count_purchase != 0)
            {
                return "Невозможно удалить клиента, так как он оформил заказ";
            }
            else
            {
                var cl = db.clients.SingleOrDefault(w => w.client_id == cod);
                db.clients.Remove(cl);
                db.SaveChanges();
                return "Все данные о клиенте удалены";
            }
        }
        public string Delete_Purchase(int cod)
        {
            var p = db.purchase.SingleOrDefault(w => w.purchase_id == cod);
            db.purchase.Remove(p);
            db.SaveChanges();
            return "Все данные о заказе удалены";
        }

        public List<string> Client_Information(int cod)
        {
            List<clients> query = (from c in db.clients select c).ToList();
            clients client_to_edit = query.First(w => w.client_id.ToString() == cod.ToString());
            List<string> client_info = new List<string>();
            client_info.Add(client_to_edit.company);
            client_info.Add(client_to_edit.surname);
            client_info.Add(client_to_edit.name);
            client_info.Add(client_to_edit.patronymic);
            client_info.Add(client_to_edit.phone_number);
            client_info.Add(client_to_edit.mail);

            return client_info;
        }
        public List<string> Employer_Information(int cod)
        {
            List<employers> query = (from c in db.employers select c).ToList();
            employers emp_to_edit = query.First(w => w.emp_id.ToString() == cod.ToString());
            List<string> emp_info = new List<string>();
            emp_info.Add(emp_to_edit.surname);
            emp_info.Add(emp_to_edit.name);
            emp_info.Add(emp_to_edit.patronymic);
            emp_info.Add(emp_to_edit.login);
            emp_info.Add(emp_to_edit.password);
            emp_info.Add(emp_to_edit.role);
            return emp_info;
        }
        public List<string> Purchase_Information(int cod)
        {
            List<purchase> query = (from c in db.purchase select c).ToList();
            purchase purchase_to_edit = query.First(w => w.purchase_id.ToString() == cod.ToString());
            List<string> purchase_info = new List<string>();
            purchase_info.Add(purchase_to_edit.service);
            purchase_info.Add(purchase_to_edit.price.ToString());
            purchase_info.Add(purchase_to_edit.date_end.ToShortDateString());
            purchase_info.Add(purchase_to_edit.done.ToString());
            purchase_info.Add(purchase_to_edit.registry.ToString());
            return purchase_info;
        }
        public List<string> ChoosePurchase(DataGridView dgv)
        {
            List<purchase> query = (from p in db.purchase
                                    select p).ToList();
            purchase purchase_choose = query.First(w => w.purchase_id.ToString() == dgv.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
            List<string> purchase_info = new List<string>();
            purchase_info.Add(purchase_choose.service);
            purchase_info.Add(purchase_choose.price.ToString());
            purchase_info.Add(purchase_choose.date_end.ToShortDateString());
            purchase_info.Add(purchase_choose.purchase_id.ToString());
            purchase_info.Add(purchase_choose.done.ToString());
            purchase_info.Add(purchase_choose.registry.ToString());
            return purchase_info;
        }
        public void Purchase_done(int cod_purchase)
        {
            var purch = db.purchase.SingleOrDefault(w => w.purchase_id == cod_purchase);
            purch.done = true;
            db.SaveChanges();
        }
        public void Purchase_bought(int cod_purchase)
        {
            var purch = db.purchase.SingleOrDefault(w => w.purchase_id == cod_purchase);
            purch.registry = true;
            db.SaveChanges();
        }
        public void Editer_Client(int cod, string co, string s, string n, string p, string pn, string m)
        {
            var cl = db.clients.SingleOrDefault(w => w.client_id == cod);
            cl.company = co;
            cl.surname = s;
            cl.name = n;
            cl.patronymic = p;
            cl.phone_number = pn;
            cl.mail = m;
            db.SaveChanges();
        }
        public void Editer_Purchase(int cod, string s, float p, DateTime d1,DateTime d2, bool done, bool reg)
        {
            var pur = db.purchase.SingleOrDefault(w => w.purchase_id == cod);
            pur.service = s;
            pur.price = p;
            pur.date_add = d1;
            pur.date_end = d2;
            pur.done = done;
            pur.registry = reg;
            db.SaveChanges();
        }
        public void Editer_Employer(int cod, string s, string n, string p, string l, string pw, string r)
        {
            var emp = db.employers.SingleOrDefault(w => w.emp_id == cod);
            emp.surname = s;
            emp.name = n;
            emp.patronymic = p;
            emp.login = l;
            emp.password = pw;
            emp.role = r;
            db.SaveChanges();
        }
        public void AddingPurchase(int e_id, int c_id, string services, float prices, DateTime date1, DateTime date2)
        {
            int number_p;
            if (db.purchase.Count() == 0) number_p = 1;
            else number_p = db.purchase.Max(we => we.purchase_id) + 1;
            purchase new_purchase = new purchase { emp_id = e_id, client_id = c_id, service = services, price = prices, date_add = date1, date_end = date2 };
            db.purchase.Add(new_purchase);
            db.SaveChanges();
        }

        public List<string> Info(DateTime d1, DateTime d2)
        {
            List<string> information = new List<string>();
            try
            {
                int count_purchase = (from p in db.purchase where (p.date_add >= d1) && (p.date_add <= d2) select p).Count();
                int count_done_purchase = (from p in db.purchase where (p.date_end >= d1) && (p.date_end <= d2) && (p.done == true) select p).Count();
                float money = (from p in db.purchase where (p.date_end >= d1) && (p.date_end <= d2) && (p.done == true) select p.price).Sum();
                information.Add(count_purchase.ToString());
                information.Add(count_done_purchase.ToString());
                information.Add(money.ToString());
                return information;
            }
            catch (System.InvalidOperationException)
            {
                information.Add("0");
                information.Add("0");
                information.Add("0");
                return information;
            }
        }
    }
}
