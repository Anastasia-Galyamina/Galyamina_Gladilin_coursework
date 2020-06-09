using BankBusinessLogic.BusnessLogic;
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
    public partial class FormRequest : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
       // private readonly RequestLogic logic;       
        public int Id { set { id = value; } }
       
        private int? id;
        /*public FormRequest(RequestLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            
        }*/

        private void buttonFormRequestDOC_Click(object sender, EventArgs e)
        {
            try
            {
                
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFormRequestXLS_Click(object sender, EventArgs e)
        {

        }

        private void FormRequest_Load(object sender, EventArgs e)
        {

        }
    }
}
