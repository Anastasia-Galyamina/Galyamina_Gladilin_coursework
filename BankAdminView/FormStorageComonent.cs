using BankBusinessLogic.BindingModels;
using BankBusinessLogic.BusnessLogic;
using BankBusinessLogic.InterFaces;
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

namespace BankAdminView
{
    public partial class FormStorageComonent : Form
    {
        private readonly MainLogic mainLogic;
        private readonly IStorageLogic storageLogic;
        private readonly IMoneyLogic componentLogic;
        private List<StorageViewModel> storageViews;
        private List<MoneyViewModel> ComponentViews;

        public FormStorageComonent(MainLogic mainLogic, IStorageLogic storageLogic, IMoneyLogic componentLogic)
        {
            InitializeComponent();
            this.mainLogic = mainLogic;
            this.storageLogic = storageLogic;
            this.componentLogic = componentLogic;
            LoadData();
        }
        private void LoadData()
        {
            storageViews = storageLogic.Read(null);
            if (storageViews != null)
            {
                comboBoxStor.DataSource = storageViews;
                comboBoxStor.DisplayMember = "StorageName";
            }
            ComponentViews = componentLogic.Read(null);
            if (ComponentViews != null)
            {
                comboBoxComponent.DataSource = ComponentViews;
                comboBoxComponent.DisplayMember = "ComponentName";
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (textBoxCount.Text == string.Empty)
                throw new Exception("Введите количество материала");

            mainLogic.AddMaterials(new StorageAddMoneyBindingModel()
            {
                StorageId = (comboBoxStor.SelectedItem as StorageViewModel).Id,
                MoneyId = (comboBoxComponent.SelectedItem as MoneyViewModel).Id,
                MoneyCount = Convert.ToInt32(textBoxCount.Text)
            });
            DialogResult = DialogResult.OK;
            Close();
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
