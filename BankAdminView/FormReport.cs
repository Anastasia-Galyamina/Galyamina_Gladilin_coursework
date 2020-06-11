using BankBusinessLogic.BindingModels;
using BankBusinessLogic.BusnessLogic;
using BankBusinessLogic.InterFaces;
using iTextSharp.text.pdf.parser;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAdminView
{
    public partial class FormReport : Form
    {
        private readonly ReportLogicAdmin logic;
        private readonly IRequestLogic requestLogic;
        public FormReport(ReportLogicAdmin logic, IRequestLogic requestLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.requestLogic = requestLogic;
        }

        [Obsolete]
        private void buttonPDF_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            var requests = requestLogic.ReadRequests(null);
            foreach (var request in requests)
            {
                if( request.DateCreation>= dateTimePickerFrom.Value && request.DateCreation <= dateTimePickerTo.Value)
                {
                    ids.Add(request.Id);                
                }
            }
            logic.SaveToPdfFile(new ReportBindingModelAdmin
            {
                FileName = "Report.pdf",
                RequestsId = ids

            });
            logic.SendMessage(new ReportBindingModelAdmin
            {
                FileName = "Report.pdf"
            });
            MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            reportViewer.Clear();
            reportViewer.LocalReport.DataSources.Clear();
            List<int> ids = new List<int>();
            var requests = requestLogic.ReadRequests(null);
            foreach (var request in requests)
            {
                if (request.DateCreation >= dateTimePickerFrom.Value && request.DateCreation <= dateTimePickerTo.Value)
                {
                    ids.Add(request.Id);
                }
            }
            try
            {
                var dataSource = logic.GetRequestsMoney(new ReportBindingModelAdmin
                {
                    FileName = "D:\\Report.pdf",
                    RequestsId = ids

                });
                ReportDataSource source = new ReportDataSource("DataSetPdf", dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
