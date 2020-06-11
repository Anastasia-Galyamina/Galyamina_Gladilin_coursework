using BankBusinessLogic.BindingModels;
using BankBusinessLogic.BusnessLogic;
using BankBusinessLogic.Enums;
using BankBusinessLogic.InterFaces;
using BankBusinessLogic.ViewModels;
using BankClientView;
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
    public partial class FormDeal : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        private Dictionary<int, (string, DateTime?)> DealCredits;
        public FormDeal()
        {
            InitializeComponent();
            dataGridView.Columns.Add("Id", "Id");
            dataGridView.Columns.Add("CreditName", "Кредит");
            dataGridView.Columns.Add("DateImplement", "дата погашения");
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            LoadData();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = new FormCreateOrder();
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
                    dataGridView.DataSource = APIClient.GetRequest<List<DealViewModel>>($"api/main/getdeals?clientId={Program.Client.Id}");
                    
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
                APIClient.PostRequest("api/main/createdeal", new DealBindingModel
                {
                    ClientId = Program.Client.Id,
                    ClientFIO = Program.Client.ClientFIO,
                    DealName = textBoxName.Text,
                    Status = DealStatus.Принят,
                    Id = id,
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
    }
}
