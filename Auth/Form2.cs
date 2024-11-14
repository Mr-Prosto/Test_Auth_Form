using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auth
{
    public partial class Form2 : Form
    {
        private Connecting db;
        private bool flag = false;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            db = new Connecting();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f1 = new();
            f1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (db)
                {
                    Account user = new Account { login = textBox1.Text, password = textBox2.Text};
                    db.accounts.Add(user);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Произошла ошибка. Подробнее: {ex.Message}");
            }
            finally
            {
                if (flag == false)
                {
                    MessageBox.Show($"Данные некорректны!");
                }
            }
        }
    }
}