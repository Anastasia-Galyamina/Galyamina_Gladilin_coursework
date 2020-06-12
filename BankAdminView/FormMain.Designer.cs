namespace BankAdminView
{
    partial class FormMain
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
            this.buttonCreateDeal = new System.Windows.Forms.Button();
            this.buttonSignDeal = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.деньгиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кредитыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заявкаНаДеньгиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonOpenDeal = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCreateDeal
            // 
            this.buttonCreateDeal.Location = new System.Drawing.Point(772, 61);
            this.buttonCreateDeal.Name = "buttonCreateDeal";
            this.buttonCreateDeal.Size = new System.Drawing.Size(206, 25);
            this.buttonCreateDeal.TabIndex = 0;
            this.buttonCreateDeal.Text = "Создать сделку";
            this.buttonCreateDeal.UseVisualStyleBackColor = true;
            this.buttonCreateDeal.Click += new System.EventHandler(this.buttonCreateDeal_Click);
            // 
            // buttonSignDeal
            // 
            this.buttonSignDeal.Location = new System.Drawing.Point(772, 92);
            this.buttonSignDeal.Name = "buttonSignDeal";
            this.buttonSignDeal.Size = new System.Drawing.Size(206, 25);
            this.buttonSignDeal.TabIndex = 1;
            this.buttonSignDeal.Text = "Подписать сделку";
            this.buttonSignDeal.UseVisualStyleBackColor = true;
            this.buttonSignDeal.Click += new System.EventHandler(this.buttonSignDeal_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(772, 155);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(206, 25);
            this.buttonRef.TabIndex = 4;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.заявкаНаДеньгиToolStripMenuItem,
            this.отчётToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1004, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.деньгиToolStripMenuItem,
            this.кредитыToolStripMenuItem,
            this.складыToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // деньгиToolStripMenuItem
            // 
            this.деньгиToolStripMenuItem.Name = "деньгиToolStripMenuItem";
            this.деньгиToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.деньгиToolStripMenuItem.Text = "Деньги";
            this.деньгиToolStripMenuItem.Click += new System.EventHandler(this.деньгиToolStripMenuItem_Click);
            // 
            // кредитыToolStripMenuItem
            // 
            this.кредитыToolStripMenuItem.Name = "кредитыToolStripMenuItem";
            this.кредитыToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.кредитыToolStripMenuItem.Text = "Кредиты";
            this.кредитыToolStripMenuItem.Click += new System.EventHandler(this.кредитыToolStripMenuItem_Click);
            // 
            // складыToolStripMenuItem
            // 
            this.складыToolStripMenuItem.Name = "складыToolStripMenuItem";
            this.складыToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.складыToolStripMenuItem.Text = "Склад";
            this.складыToolStripMenuItem.Click += new System.EventHandler(this.СкладыToolStripMenuItem_Click);
            // 
            // заявкаНаДеньгиToolStripMenuItem
            // 
            this.заявкаНаДеньгиToolStripMenuItem.Name = "заявкаНаДеньгиToolStripMenuItem";
            this.заявкаНаДеньгиToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.заявкаНаДеньгиToolStripMenuItem.Text = "Заявка на деньги";
            this.заявкаНаДеньгиToolStripMenuItem.Click += new System.EventHandler(this.заявкаНаДеньгиToolStripMenuItem_Click);
            // 
            // отчётToolStripMenuItem
            // 
            this.отчётToolStripMenuItem.Name = "отчётToolStripMenuItem";
            this.отчётToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.отчётToolStripMenuItem.Text = "Отчёт";
            this.отчётToolStripMenuItem.Click += new System.EventHandler(this.отчётToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 29);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(754, 397);
            this.dataGridView.TabIndex = 6;
            // 
            // buttonOpenDeal
            // 
            this.buttonOpenDeal.Location = new System.Drawing.Point(772, 123);
            this.buttonOpenDeal.Name = "buttonOpenDeal";
            this.buttonOpenDeal.Size = new System.Drawing.Size(206, 26);
            this.buttonOpenDeal.TabIndex = 7;
            this.buttonOpenDeal.Text = "Содержимое сделки ";
            this.buttonOpenDeal.UseVisualStyleBackColor = true;
            this.buttonOpenDeal.Click += new System.EventHandler(this.buttonOpenDeal_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 449);
            this.Controls.Add(this.buttonOpenDeal);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonSignDeal);
            this.Controls.Add(this.buttonCreateDeal);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Банк";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateDeal;
        private System.Windows.Forms.Button buttonSignDeal;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem деньгиToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripMenuItem кредитыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem;
        private System.Windows.Forms.Button buttonOpenDeal;
        private System.Windows.Forms.ToolStripMenuItem заявкаНаДеньгиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётToolStripMenuItem;
    }
}