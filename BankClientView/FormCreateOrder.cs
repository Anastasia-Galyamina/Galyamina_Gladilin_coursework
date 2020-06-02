using BankBusinessLogic.BindingModels;
using BankBusinessLogic.BusnessLogic;
using BankBusinessLogic.InterFaces;
using BankBusinessLogic.ViewModels;
using BankClientView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
                                                       
namespace BankAdminView
{                                                      
    public partial class FormCreateOrder : Form        
    {
        public int Id
        {
            get { return Convert.ToInt32(comboBoxСredit.SelectedValue); }
            set { comboBoxСredit.SelectedValue = value; }
        }
        public string CreditName { get { return comboBoxСredit.Text; } }
        public DateTime date
        {
            get { return DateTime.Now; }
        }
        public FormCreateOrder()                       
        {                                              
            InitializeComponent();
        }
        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                comboBoxСredit.DisplayMember = "CreditName";
                comboBoxСredit.ValueMember = "Id";
                comboBoxСredit.DataSource = APIClient.GetRequest<List<CreditViewModel>>("api/main/getcreditlist");
                comboBoxСredit.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxСredit.SelectedValue == null)
            {
                MessageBox.Show("Выберите кредит", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
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
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}                                                      
                                                       