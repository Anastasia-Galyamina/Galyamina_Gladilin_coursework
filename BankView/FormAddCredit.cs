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
        public int Id { set { id = value; } }
        private readonly ICreditLogic logic;
        private readonly IMoneyLogic logicM;
        private int? id;
        public int IdC
        {
            get { return Convert.ToInt32(comboBoxCurr.SelectedValue); }
            set { comboBoxCurr.SelectedValue = value; }
        }
        public string ComponentName { get { return comboBoxCurr.Text; } }
        public FormAddCredit(ICreditLogic logic , IMoneyLogic logicM)
        {
            InitializeComponent();
            this.logic = logic;
            this.logicM = logicM;
            List<MoneyViewModel> list = logicM.Read(null);
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
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new CreditBindingModel
                {
                    Id = id,
                    CreditName = textBoxName.Text,
                    CountMoney = Convert.ToInt32(textBoxCount.Text),
                    DateImplement = dateTimePicker.Value,
                    currency = comboBoxCurr.Text
                });
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
    }
}
