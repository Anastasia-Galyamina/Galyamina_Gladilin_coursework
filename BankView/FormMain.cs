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
            var form = Container.Resolve<FormDeals>();
            form.ShowDialog();
        }
    }
}
