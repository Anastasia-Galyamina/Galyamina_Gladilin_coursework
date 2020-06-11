using BankBusinessLogic.BindingModels;
using BankBusinessLogic.InterFaces;
using BankDataBaseImplement;
using System;
using System.Windows.Forms;
using Unity;

namespace BankAdminView
{
    public partial class FormStorage : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IStorageMoneyLogic logic;
        public FormStorage(IStorageMoneyLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormStorage_Load(object sender, EventArgs e)
        {
            LoadData();         
        }
        public void LoadData()
        {
            try
            {                
                using (var context = new BankDataBase())
                {
                    var list = logic.Read(null);                    
                    if (list != null)
                    {
                        dataGridViewStorage.DataSource = list;                       
                        dataGridViewStorage.Columns[0].Visible = false;
                        dataGridViewStorage.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dataGridViewStorage.Columns[3].Visible = false;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }    
        

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
