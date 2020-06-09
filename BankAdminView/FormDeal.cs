using BankBusinessLogic.BindingModels;
using BankBusinessLogic.Enums;
using BankBusinessLogic.InterFaces;
using BankBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace BankAdminView
{
    public partial class FormDeal : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IDealLogic logic;        
        private readonly IClientLogic clientLogic;

        private int? id;
        private Dictionary<int, (string, DateTime?)> DealCredits;
        public FormDeal(IDealLogic dealLogic, IClientLogic clientLogic)
        {
            InitializeComponent();
            dataGridView.Columns.Add("Id", "Id");
            dataGridView.Columns.Add("CreditName", "Кредит");
            dataGridView.Columns.Add("DateImplement", "дата погашения");
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.logic = dealLogic;            
            this.clientLogic = clientLogic;
            var list = clientLogic.Read(null);
            comboBoxClient.DataSource = list;
            comboBoxClient.DisplayMember = "ClientFIO";
            comboBoxClient.ValueMember = "Id";
            comboBoxClient.SelectedItem = null;
            LoadData();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDealCredit>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (DealCredits.ContainsKey(form.Id))
                {
                    DealCredits[form.Id] = (form.CreditName, form.date);
                }
                else
                {
                    DealCredits.Add(form.Id, (form.CreditName, form.date));
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
                        comboBoxClient.Text = view.ClientFIO;
                        DealCredits = view.DealCredits;
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
                DealCredits = new Dictionary<int, (string,DateTime?)>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (DealCredits != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in DealCredits)
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
            if (DealCredits == null || DealCredits.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new DealBindingModel
                {
                    ClientId = Convert.ToInt32(comboBoxClient.SelectedValue),
                    DealName = textBoxName.Text,
                    Status = DealStatus.Принят,
                    Id = id,
                    ClientFIO = comboBoxClient.Text,
                    DealCredits = DealCredits

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

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DealCredits.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    LoadData();
                }
            }
        }
    }
}
