using BankBusinessLogic.BindingModels;
using BankBusinessLogic.BusinessLogic;
using BankBusinessLogic.Interfaсes;
using BankBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace BankViewClient
{
    public partial class FormDeal : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IDealLogic logic;
        private readonly ICreditLogic creditLogic;
        private int? id;
        private Dictionary<int, (string, int)> DealCredit;
        public FormDeal(IDealLogic dealLogic, ICreditLogic creditLogic)
        {
            InitializeComponent();
            dataGridView.Columns.Add("Id", "Id");
            dataGridView.Columns.Add("CreditName", "Название кредита");
            dataGridView.Columns.Add("Date", "Срок погашения");
            dataGridView.Columns.Add("Type", "Тип");            
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.logic = dealLogic;
            this.creditLogic = creditLogic;
            LoadData();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAddCredit>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (DealCredit.ContainsKey(form.Id))
                {
                    DealCredit[form.Id] = (form.CreditName, form.Count);
                }
                else
                {
                    DealCredit.Add(form.Id, (form.CreditName, form.Count));
                }
                LoadData();
            }
        }

        private void FormDeal_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    DealViewModel view = logic.Read(new DealBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.DealName;
                        DealCredit = view.DealCredit;
                        LoadData();
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
                DealCredit = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (DealCredit != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in DealCredit)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2});
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
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
            if (DealCredit == null || DealCredit.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new DealBindingModel
                {
                    Id = id,
                    DealName = textBoxName.Text,
                    DealCredits = DealCredit
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

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
