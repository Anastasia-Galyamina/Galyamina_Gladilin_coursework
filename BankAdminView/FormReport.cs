using BankBusinessLogic.BindingModels;
using BankBusinessLogic.BusnessLogic;
using BankBusinessLogic.InterFaces;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BankAdminView
{
    public partial class FormReport : Form
    {
        private readonly ReportLogicAdmin logic;
        private readonly IRequestLogic requestLogic;
        private readonly IDealLogic dealLogic;
        public FormReport(ReportLogicAdmin logic, IRequestLogic requestLogic, IDealLogic dealLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.requestLogic = requestLogic;
            this.dealLogic = dealLogic;
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

            }, dateTimePickerFrom.Value, dateTimePickerTo.Value);
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
                var dataSource2 = dealLogic.FormReport(dateTimePickerFrom.Value, dateTimePickerTo.Value);
                ReportDataSource source = new ReportDataSource("DataSetPdf", dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                ReportDataSource source2 = new ReportDataSource("DataSetCredits", dataSource2);
                reportViewer.LocalReport.DataSources.Add(source2);
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
