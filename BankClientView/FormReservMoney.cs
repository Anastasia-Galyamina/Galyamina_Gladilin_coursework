using BankBusinessLogic.BindingModels;
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
    public partial class FormReservMoney : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        public FormReservMoney()
        {
            InitializeComponent();
            List<DealViewModel> list = APIClient.GetRequest<List<DealViewModel>>($"api/main/getdeals?clientId={Program.Client.Id}");
            if (list != null)
            {
                comboBox.DisplayMember = "DealName";
                comboBox.ValueMember = "Id";
                comboBox.DataSource = list;
                comboBox.SelectedItem = null;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            List<DealBindingModel> list = APIClient.GetRequest<List<DealBindingModel>>($"api/main/getdeals?clientId={Program.Client.Id}");
            
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Введите количество", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                /*APIClient.PostRequest("api/main/reservmoney", new ReservedMoneyBindingModel
                {
                    ClientId = Program.Client.Id,
                    DealName = comboBox.Text,
                    countMoney = Convert.ToInt32(textBoxCount.Text),
                    DealId = comboBox.SelectedIndex,
                    Id = id
                });*/
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }

        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void FormComponent_Load(object sender, EventArgs e)
        {
            
        }
    }
}
