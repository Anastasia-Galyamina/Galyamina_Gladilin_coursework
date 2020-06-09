using System;

namespace BankAdminView
{
    partial class Formtest2
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
            this.buttonSend = new System.Windows.Forms.Button();
            this.ReportDealMoneyViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDealMoneyViewModelBindingSource)).BeginInit();
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
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(37, 58);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(652, 321);
            this.richTextBox.TabIndex = 1;
            this.richTextBox.Text = "";
            // 
            // Formtest2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 424);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.buttonSend);
            this.Name = "Formtest2";
            this.Text = "FormTest3";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportDealMoneyViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        private void Form_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.BindingSource ReportDealMoneyViewModelBindingSource;
        private System.Windows.Forms.RichTextBox richTextBox;
    }
}