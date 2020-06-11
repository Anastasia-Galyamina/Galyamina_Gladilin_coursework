using AxAcroPDFLib;
using System;

namespace BankClientView
{
    partial class FormReportDealsMoney
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportDealsMoney));
            this.buttonSend = new System.Windows.Forms.Button();
            this.ReportDealMoneyViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.axAcroPDF = new AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDealMoneyViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(17, 16);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(126, 22);
            this.buttonSend.TabIndex = 0;
            this.buttonSend.Text = "отправить на почту";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // ReportDealMoneyViewModelBindingSource
            // 
            this.ReportDealMoneyViewModelBindingSource.DataSource = typeof(BankBusinessLogic.ViewModels.ReportDealMoneyViewModel);
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF.Enabled = true;
            this.axAcroPDF.Location = new System.Drawing.Point(17, 44);
            this.axAcroPDF.Name = "axAcroPDF1";
            this.axAcroPDF.Size = new System.Drawing.Size(753, 368);
            this.axAcroPDF.TabIndex = 2;
            // 
            // FormReportDealsMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 424);
            this.Controls.Add(this.axAcroPDF);
            this.Controls.Add(this.buttonSend);
            this.Name = "FormReportDealsMoney";
            this.Text = "Отчет по подписанным сделкам";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportDealMoneyViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.BindingSource ReportDealMoneyViewModelBindingSource;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF;
    }
}