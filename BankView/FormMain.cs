using BankBusinessLogic.Interfaсes;
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
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        //private readonly MainLogic logic;
        //private readonly IOrderLogic orderLogic;
        //private readonly ReportLogic report;
        private readonly ICreditLogic creditLogic;
        private readonly IMoneyLogic moneyLogic;
        private readonly IDealLogic dealLogic;
        public FormMain( IMoneyLogic moneyLogic ,ICreditLogic creditLogic, IDealLogic dealLogic)
        {
            InitializeComponent();
            this.creditLogic = creditLogic;
            this.moneyLogic = moneyLogic;
            this.dealLogic = dealLogic;
            dataGridView.Columns.Add("Id", "Номер сделки");
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

        private void сделкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDeal>();
            form.ShowDialog();
            LoadData();
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
                    dataGridView.Columns[1].Visible = true;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonContent_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 2)
            {
                var form = Container.Resolve < FormDeal>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
    }
}
