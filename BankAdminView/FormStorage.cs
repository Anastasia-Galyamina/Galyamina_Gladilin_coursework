using BankBusinessLogic.BindingModels;
using BankBusinessLogic.InterFaces;
using BankDataBaseImplement;
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

namespace BankAdminView
{
    public partial class FormStorage : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IStorageLogic logic;
        public FormStorage(IStorageLogic storageLogic)
        {
            InitializeComponent();
            this.logic = storageLogic;
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
                    var list = context.StorageMoney.ToList();
                    if (list != null)
                    {
                        dataGridViewStorage.DataSource = list;
                        dataGridViewStorage.Columns[0].Visible = false;
                        dataGridViewStorage.Columns[1].Visible = false;
                        dataGridViewStorage.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        
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
