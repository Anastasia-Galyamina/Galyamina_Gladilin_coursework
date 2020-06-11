using BankAdminView;
using BankBusinessLogic.BindingModels;
using BankBusinessLogic.Enums;
using BankBusinessLogic.ViewModels;
using BankDataBaseImplement;
using BankDataBaseImplement.Implements;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
        
        DealLogic logic = new DealLogic();
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
                //dataGridView.Columns[3].Visible = true;
                dataGridView.Columns[6].Visible = false;
                dataGridView.Columns[7].Visible = false;
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

        private void зарезервироватьДеньгиToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);

                try
                {
                    using (var context = new BankDataBase())
                    {
                        foreach (var deal in context.Deals)
                        {
                            if (deal.Id == id)
                            {
                                if (deal.reserved == true)
                                {
                                    MessageBox.Show("Деньги уже были зарезервированы","Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error);
                                }
                                else
                                { 
                                    deal.reserved = true;
                                    logic.ReserveMoney(id);                    
                                     MessageBox.Show("Деньги зарезервированы");
                                }
                            }
                        }
                        context.SaveChanges();
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберете одну сделку","Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void отчетПоВыполненнымСделкамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormReportDealsMoney();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadList();
            }
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
