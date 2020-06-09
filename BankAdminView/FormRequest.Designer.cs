namespace BankAdminView
{
    partial class FormRequest
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonFormRequestDOC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.buttonFormRequestXLS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(358, 301);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonFormRequestDOC
            // 
            this.buttonFormRequestDOC.Location = new System.Drawing.Point(385, 51);
            this.buttonFormRequestDOC.Name = "buttonFormRequestDOC";
            this.buttonFormRequestDOC.Size = new System.Drawing.Size(155, 56);
            this.buttonFormRequestDOC.TabIndex = 1;
            this.buttonFormRequestDOC.Text = "Сформировать заявку в DOC";
            this.buttonFormRequestDOC.UseVisualStyleBackColor = true;
            this.buttonFormRequestDOC.Click += new System.EventHandler(this.buttonFormRequestDOC_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(382, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Почта";
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(427, 9);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(140, 22);
            this.textBoxMail.TabIndex = 3;
            // 
            // buttonFormRequestXLS
            // 
            this.buttonFormRequestXLS.Location = new System.Drawing.Point(562, 51);
            this.buttonFormRequestXLS.Name = "buttonFormRequestXLS";
            this.buttonFormRequestXLS.Size = new System.Drawing.Size(155, 56);
            this.buttonFormRequestXLS.TabIndex = 4;
            this.buttonFormRequestXLS.Text = "Сформировать заявку в XLS";
            this.buttonFormRequestXLS.UseVisualStyleBackColor = true;
            this.buttonFormRequestXLS.Click += new System.EventHandler(this.buttonFormRequestXLS_Click);
            // 
            // FormRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonFormRequestXLS);
            this.Controls.Add(this.textBoxMail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonFormRequestDOC);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormRequest";
            this.Text = "Заявка на деньги";
            this.Load += new System.EventHandler(this.FormRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonFormRequestDOC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.Button buttonFormRequestXLS;
    }
}