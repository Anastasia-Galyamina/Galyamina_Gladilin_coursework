using System;
using System.Windows.Forms;
using Unity;
using BankBusinessLogic.BusnessLogic;
using BankBusinessLogic.InterFaces;
using BankBusinessLogic.BindingModels;

namespace BankAdminView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly MainLogic logic;
        private readonly IDealLogic dealLogic;
        public FormMain(MainLogic logic, IDealLogic orderLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.dealLogic = orderLogic;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = dealLogic.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;                    
                    dataGridView.Columns[6].Visible = false;
                    dataGridView.Columns[7].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void деньгиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormMoney>();
            form.ShowDialog();
        }
        private void кредитыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCredits>();
            form.ShowDialog();
        }
        private void buttonCreateDeal_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDeal>();
            form.ShowDialog();
            LoadData();
        }
        private void buttonSignDeal_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    logic.TakDealInWork(new ChangeStatusBindingModel { DealId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
       
        private void СкладыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormStorage>();
            form.ShowDialog();
        }
       
        private void buttonOpenDeal_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormDeal>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void заявкаНаДеньгиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRequest>();
            form.ShowDialog();
        }

        private void отчётToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReport>();
            form.ShowDialog();
        }
    }
}
