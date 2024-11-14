using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Auth
{
    public partial class Form1 : Form
    {
        private Connecting db;
        private bool flag = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db = new Connecting();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 f2 = new();
            f2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (db)
                {
                    var accounts = db.accounts.ToList();
                    foreach (var n in accounts)
                    {
                        if (n.login == textBox1.Text && n.password == textBox2.Text)
                        {
                            MessageBox.Show("Добро пожаловать!");
                            flag = true;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка. Подробнее: {ex.Message}");
            }
            finally
            {
                if(flag == false)
                {
                    MessageBox.Show($"В доступе отказано!");
                }
            }
        }
    }
}
