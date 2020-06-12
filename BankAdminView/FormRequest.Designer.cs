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
            this.buttonFormRequestXLS = new System.Windows.Forms.Button();
            this.buttonGetMoney = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
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
            this.buttonFormRequestDOC.Size = new System.Drawing.Size(214, 36);
            this.buttonFormRequestDOC.TabIndex = 1;
            this.buttonFormRequestDOC.Text = "Сформировать заявку в DOC";
            this.buttonFormRequestDOC.UseVisualStyleBackColor = true;
            this.buttonFormRequestDOC.Click += new System.EventHandler(this.buttonFormRequestDOC_Click);
            // 
            // buttonFormRequestXLS
            // 
            this.buttonFormRequestXLS.Location = new System.Drawing.Point(385, 93);
            this.buttonFormRequestXLS.Name = "buttonFormRequestXLS";
            this.buttonFormRequestXLS.Size = new System.Drawing.Size(214, 32);
            this.buttonFormRequestXLS.TabIndex = 4;
            this.buttonFormRequestXLS.Text = "Сформировать заявку в XLS";
            this.buttonFormRequestXLS.UseVisualStyleBackColor = true;
            this.buttonFormRequestXLS.Click += new System.EventHandler(this.buttonFormRequestXLS_Click);
            // 
            // buttonGetMoney
            // 
            this.buttonGetMoney.Location = new System.Drawing.Point(385, 131);
            this.buttonGetMoney.Name = "buttonGetMoney";
            this.buttonGetMoney.Size = new System.Drawing.Size(214, 31);
            this.buttonGetMoney.TabIndex = 5;
            this.buttonGetMoney.Text = "Сохранить заявку и получить деньги";
            this.buttonGetMoney.UseVisualStyleBackColor = true;
            this.buttonGetMoney.Click += new System.EventHandler(this.buttonGetMoney_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(385, 168);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(215, 30);
            this.buttonRef.TabIndex = 6;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // FormRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 336);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonGetMoney);
            this.Controls.Add(this.buttonFormRequestXLS);
            this.Controls.Add(this.buttonFormRequestDOC);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormRequest";
            this.Text = "Заявка на деньги";
            this.Load += new System.EventHandler(this.FormRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonFormRequestDOC;
        private System.Windows.Forms.Button buttonFormRequestXLS;
        private System.Windows.Forms.Button buttonGetMoney;
        private System.Windows.Forms.Button buttonRef;
    }
}