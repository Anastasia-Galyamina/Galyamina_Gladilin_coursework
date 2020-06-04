using BankBusinessLogic.BindingModels;
using BankBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace BankClientView
{
    public partial class FormReportDealsCredits : Form
    {
        private List<int> ids = new List<int>();
        private string str = "";
        private List<DealViewModel> deals = APIClient.GetRequest<List<DealViewModel>>($"api/main/getdeals?clientId={Program.Client.Id}");
        public FormReportDealsCredits()
        {
            InitializeComponent();
            LoadList();      
        }
        private void LoadList()
        {
            try
            {
                dataGridView.DataSource = APIClient.GetRequest<List<DealViewModel>>($"api/main/getdeals?clientId={Program.Client.Id}");
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView.Columns[3].Visible = true;
                dataGridView.Columns[5].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ids.Add(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
            foreach(var deal in deals)
            {
                if(deal.Id == Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value))
                {
                    str += deal.DealName +Environment.NewLine;
                }
            }
            textBox.Text = str;
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {         
            //		FileName	"D:\\CreditDeal.docx"	string
            APIClient.PostRequest($"api/main/doccreditdial", new ReportBindingModel
            {
                FileName = "D:\\CreditDeal.docx",
                ClientId = Program.Client.Id,
                DealsId = ids
            });
            MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("labwork15kafis@gmail.com");
            // кому отправляем
            MailAddress to = new MailAddress("samsonov_1958@bk.ru");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            m.Attachments.Add(new Attachment("D:\\CreditDeal.docx"));
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("labwork15kafis@gmail.com", "passlab15");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }

    }
}
