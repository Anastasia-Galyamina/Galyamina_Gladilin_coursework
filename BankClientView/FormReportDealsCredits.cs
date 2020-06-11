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
                dataGridView.Columns[6].Visible = false;
                dataGridView.Columns[7].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                ids.Add(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                foreach (var deal in deals)
                {
                    if (deal.Id == Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value))
                    {
                        str += deal.DealName + Environment.NewLine;
                    }
                }
                textBox.Text = str;
            }
            else
            {
                MessageBox.Show("Выберете одну сделку", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {         
            APIClient.PostRequest($"api/main/doccreditdial", new ReportBindingModel
            {
                FileName = "CreditDeal.docx",
                ClientId = Program.Client.Id,
                DealsId = ids
            });
            APIClient.PostRequest($"api/main/sendmessage", new ReportBindingModel
            {
                FileName = "CreditDeal.docx",
                Email = Program.Client.Email
            });
            MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonOkExcel_Click(object sender, EventArgs e)
        {
            APIClient.PostRequest($"api/main/exelcreditdial", new ReportBindingModel
            {
                FileName = "CreditDeal.xlsx",
                ClientId = Program.Client.Id,
                DealsId = ids
            });
            APIClient.PostRequest($"api/main/sendmessage", new ReportBindingModel
            {
                FileName = "CreditDeal.xlsx",
                Email = Program.Client.Email
            });
            MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
