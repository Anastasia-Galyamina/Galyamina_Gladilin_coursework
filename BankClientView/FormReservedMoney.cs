using BankBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BankClientView
{
    public partial class FormReservedMoney : Form
    {
        public FormReservedMoney()
        {
            InitializeComponent();
            LoadList();

        }
        private void LoadList()
        {
            try
            {
               /* dataGridView.DataSource = APIClient.GetRequest<List<ReservedMoneyViewModel>>($"api/main/getreservedmoney?clientId={Program.Client.Id}");
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].Visible = true;
                dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView.Columns[3].Visible = true;*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form_Load(object sender, EventArgs e)
        {
            LoadList();
        }
        private void buttonRef_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = new FormReservMoney();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadList();
            }
        }
        private void buttonUpd_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
