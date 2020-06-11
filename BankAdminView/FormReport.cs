using BankBusinessLogic.BindingModels;
using BankBusinessLogic.BusnessLogic;
using BankBusinessLogic.InterFaces;
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
                ids.Add(request.Id);                
            }
            logic.SaveToPdfFile(new ReportBindingModelAdmin
            {
                FileName = "C:\\Users\\anast\\Report.pdf",
                RequestsId = ids

            });
        }
    }
}
