using BankBusinessLogic.BusinessLogic;
using BankBusinessLogic.Interfaсes;
using System;
using System.Windows.Forms;
using Unity;

namespace BankViewClient
{
    public partial class FormCredits : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ICreditLogic logic;
        private readonly MainLogic logicM;
        public FormCredits(ICreditLogic logic , MainLogic mainLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.logicM = mainLogic;
        }
        
        private void LoadData()
        {
            try
            {
                var list = logic.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }

        }

        private void FormCredits_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
