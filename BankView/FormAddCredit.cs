using BankBusinessLogic.BindingModels;
using BankBusinessLogic.Interfaсes;
using BankBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace BankView
{
    public partial class FormAddCredit : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IMoneyLogic logic;
        public int Id
        {
            get { return Convert.ToInt32(comboBoxCurr.SelectedValue); }
            set { comboBoxCurr.SelectedValue = value; }
        }
        public string CreditName { get { return textBoxName.Text; } }
        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }
        public DateTime date
        {
            get { return dateTimePicker.Value; }
            set
            {
                dateTimePicker.Value = value;
            }
        }
        public string currency
        {
            get { return comboBoxCurr.Text; }
        }
        public FormAddCredit(ICreditLogic logic , IMoneyLogic moneyLogic)
        {
            InitializeComponent();
            this.logic = moneyLogic;
            List<MoneyViewModel> list = moneyLogic.Read(null);
            if (list != null)
            {
                comboBoxCurr.DisplayMember = "currency";
                comboBoxCurr.ValueMember = "Id";
                comboBoxCurr.DataSource = list;
                comboBoxCurr.SelectedItem = null;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxCurr.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
