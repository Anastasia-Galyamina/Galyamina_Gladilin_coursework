using BankBusinessLogic.BindingModels;
using BankBusinessLogic.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Unity;

namespace BankAdminView
{
    public partial class FormRequest : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IRequestLogic logic;  
        private int id;
        private Dictionary<string, int> dict;
        public FormRequest(IRequestLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            id = logic.GetId();
        }
       private void LoadData()
       {
            try
            {
                dict = logic.Read();
                if (dict != null)
                {
                    dataGridView.DataSource = dict.ToList();
                    dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
       }
        private bool CheckEmail()
        {
            if (!Regex.IsMatch(textBoxEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("Неверный адрес почты");
                return false;                    
            }
            return true;
        }

        private void buttonFormRequestDOC_Click(object sender, EventArgs e)
        {
            try
            {
                if(CheckEmail())
                {
                    var model = new RequestBindingModel
                    {
                    Id = id,
                    Email = textBoxEmail.Text,
                    FileName = "Request.doc",
                    MoneyCount = dict,
                    DateCreation = DateTime.Now
                    };                
                    logic.DocRequest(model);
                    logic.SendMessage(model);
                }
                     
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFormRequestXLS_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckEmail())
                {
                    var model = new RequestBindingModel
                    {
                        Id = id,
                        Email = textBoxEmail.Text,
                        FileName = "Request.xls",
                        MoneyCount = dict,
                        DateCreation = DateTime.Now
                    };
                    logic.ExelRequest(model);
                    logic.SendMessage(model);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormRequest_Load(object sender, EventArgs e)
        {
            LoadData();            
        }

        private void buttonGetMoney_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckEmail())
                {
                    var model = new RequestBindingModel
                    {
                        Id = id,
                        Email = textBoxEmail.Text,
                        FileName = "",
                        MoneyCount = dict,
                        DateCreation = DateTime.Now
                    };
                    var viewModel = logic.GetRequest(model);
                    logic.Save(viewModel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
