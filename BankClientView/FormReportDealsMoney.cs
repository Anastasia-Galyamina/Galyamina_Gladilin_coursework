using BankBusinessLogic.BindingModels;
using BankBusinessLogic.Enums;
using BankBusinessLogic.ViewModels;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BankClientView
{
    public partial class FormReportDealsMoney : Form
    {
        public FormReportDealsMoney()
        {
            InitializeComponent();
        }
        private void Form_Load(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            var deals = APIClient.GetRequest<List<DealViewModel>>($"api/main/getdeals?clientId={Program.Client.Id}");
            foreach (var deal in deals)
            {
                if (deal.Status == DealStatus.Подписан)
                {
                    ids.Add(deal.Id);
                }
            }
            APIClient.PostRequest($"api/main/PdfDialMoney", new ReportBindingModel
            {
                FileName = "D:\\CreditMoney.pdf",
                ClientId = Program.Client.Id,
                DealsId = ids
            });
            try
            {
                axAcroPDF.src = "D:\\CreditMoney.pdf";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            var deals = APIClient.GetRequest<List<DealViewModel>>($"api/main/getdeals?clientId={Program.Client.Id}");
            foreach (var deal in deals)
            {
                if (deal.Status == DealStatus.Подписан)
                {
                    ids.Add(deal.Id);
                }
            }
            APIClient.PostRequest($"api/main/PdfDialMoney", new ReportBindingModel
            {
                FileName = "CreditMoney.pdf",
                ClientId = Program.Client.Id,
                DealsId = ids
            });
            APIClient.PostRequest($"api/main/sendmessage", new ReportBindingModel
            {
                FileName = "CreditMoney.pdf",
                Email = Program.Client.Email
            });
            MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
