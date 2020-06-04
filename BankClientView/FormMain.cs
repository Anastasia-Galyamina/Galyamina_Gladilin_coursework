using BankAdminView;
using BankBusinessLogic.BindingModels;
using BankBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace BankClientView
{
    public partial class FormMain : Form
    {
        public FormMain()
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
        private void UpdateDataToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            var form = new FormUpdateData(); form.ShowDialog();
        }
        private void CreateOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormDeal(); 
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadList();
            }
        }
        private void RefreshOrderListToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            LoadList(); 
        }

        private void зарезервированныеДеньгиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormReservedMoney();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadList();
            }
        }
        private void WordToolStripMenuItem_Clicl(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormReportDealsCredits();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadList();
            }
        }
    }
}
