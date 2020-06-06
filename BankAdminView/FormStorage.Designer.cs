namespace BankAdminView
{
    partial class FormStorage
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
            this.dataGridViewStorage = new System.Windows.Forms.DataGridView();
            this.buttonReserveMoney = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorage)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewStorage
            // 
            this.dataGridViewStorage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStorage.Location = new System.Drawing.Point(12, 30);
            this.dataGridViewStorage.Name = "dataGridViewStorage";
            this.dataGridViewStorage.Size = new System.Drawing.Size(584, 399);
            this.dataGridViewStorage.TabIndex = 0;
            // 
            // buttonReserveMoney
            // 
            this.buttonReserveMoney.Location = new System.Drawing.Point(625, 30);
            this.buttonReserveMoney.Name = "buttonReserveMoney";
            this.buttonReserveMoney.Size = new System.Drawing.Size(193, 43);
            this.buttonReserveMoney.TabIndex = 15;
            this.buttonReserveMoney.Text = "Отправить заявку на деньги";
            this.buttonReserveMoney.UseVisualStyleBackColor = true;
            this.buttonReserveMoney.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Деньги";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(625, 79);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(193, 40);
            this.buttonRefresh.TabIndex = 20;
            this.buttonRefresh.Text = "Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            // 
            // FormStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 460);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonReserveMoney);
            this.Controls.Add(this.dataGridViewStorage);
            this.Name = "FormStorage";
            this.Text = "Склад";
            this.Load += new System.EventHandler(this.FormStorage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewStorage;
        private System.Windows.Forms.Button buttonReserveMoney;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRefresh;
    }
}