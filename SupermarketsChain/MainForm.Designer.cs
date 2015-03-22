namespace SupermarketsChain
{
    partial class MainForm
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
            this.dataTransferBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataTransferComboBox = new System.Windows.Forms.ComboBox();
            this.transferStatusRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.reportComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reportBtn = new System.Windows.Forms.Button();
            this.startDateTxt = new System.Windows.Forms.Label();
            this.EndDateTxt = new System.Windows.Forms.Label();
            this.startDateTextBox = new System.Windows.Forms.TextBox();
            this.endDateTextBox = new System.Windows.Forms.TextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.getStartDateBnt = new System.Windows.Forms.Button();
            this.getEndDateBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dataTransferBtn
            // 
            this.dataTransferBtn.Location = new System.Drawing.Point(175, 124);
            this.dataTransferBtn.Margin = new System.Windows.Forms.Padding(4);
            this.dataTransferBtn.Name = "dataTransferBtn";
            this.dataTransferBtn.Size = new System.Drawing.Size(147, 28);
            this.dataTransferBtn.TabIndex = 0;
            this.dataTransferBtn.Text = "Transfer data";
            this.dataTransferBtn.UseVisualStyleBackColor = true;
            this.dataTransferBtn.Click += new System.EventHandler(this.dataTransferBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data Transfer";
            // 
            // dataTransferComboBox
            // 
            this.dataTransferComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataTransferComboBox.FormattingEnabled = true;
            this.dataTransferComboBox.Items.AddRange(new object[] {
            "From Oracle to MS SQL",
            "From MS SQL to MySQL",
            "From Zip to MS SQL",
            "From XML to MS SQL",
            "From JSON to Mongo"});
            this.dataTransferComboBox.Location = new System.Drawing.Point(55, 73);
            this.dataTransferComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.dataTransferComboBox.Name = "dataTransferComboBox";
            this.dataTransferComboBox.Size = new System.Drawing.Size(265, 28);
            this.dataTransferComboBox.TabIndex = 2;
            // 
            // transferStatusRichTextBox
            // 
            this.transferStatusRichTextBox.Location = new System.Drawing.Point(55, 244);
            this.transferStatusRichTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.transferStatusRichTextBox.Name = "transferStatusRichTextBox";
            this.transferStatusRichTextBox.Size = new System.Drawing.Size(516, 310);
            this.transferStatusRichTextBox.TabIndex = 3;
            this.transferStatusRichTextBox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 194);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Transfer Status";
            // 
            // reportComboBox
            // 
            this.reportComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportComboBox.FormattingEnabled = true;
            this.reportComboBox.Items.AddRange(new object[] {
            "Sales Pdf report",
            "Sales XML report",
            "Sales JSON report",
            "Excel Vendors Financial Result report"});
            this.reportComboBox.Location = new System.Drawing.Point(672, 194);
            this.reportComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.reportComboBox.Name = "reportComboBox";
            this.reportComboBox.Size = new System.Drawing.Size(388, 28);
            this.reportComboBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(667, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Reports";
            // 
            // reportBtn
            // 
            this.reportBtn.Location = new System.Drawing.Point(915, 246);
            this.reportBtn.Margin = new System.Windows.Forms.Padding(4);
            this.reportBtn.Name = "reportBtn";
            this.reportBtn.Size = new System.Drawing.Size(147, 28);
            this.reportBtn.TabIndex = 5;
            this.reportBtn.Text = "Generate report";
            this.reportBtn.UseVisualStyleBackColor = true;
            this.reportBtn.Click += new System.EventHandler(this.reportBtn_Click);
            // 
            // startDateTxt
            // 
            this.startDateTxt.AutoSize = true;
            this.startDateTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDateTxt.Location = new System.Drawing.Point(672, 92);
            this.startDateTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.startDateTxt.Name = "startDateTxt";
            this.startDateTxt.Size = new System.Drawing.Size(82, 20);
            this.startDateTxt.TabIndex = 8;
            this.startDateTxt.Text = "Start date";
            // 
            // EndDateTxt
            // 
            this.EndDateTxt.AutoSize = true;
            this.EndDateTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndDateTxt.Location = new System.Drawing.Point(672, 132);
            this.EndDateTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EndDateTxt.Name = "EndDateTxt";
            this.EndDateTxt.Size = new System.Drawing.Size(75, 20);
            this.EndDateTxt.TabIndex = 9;
            this.EndDateTxt.Text = "End date";
            // 
            // startDateTextBox
            // 
            this.startDateTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDateTextBox.Location = new System.Drawing.Point(807, 89);
            this.startDateTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.startDateTextBox.Name = "startDateTextBox";
            this.startDateTextBox.Size = new System.Drawing.Size(132, 26);
            this.startDateTextBox.TabIndex = 10;
            // 
            // endDateTextBox
            // 
            this.endDateTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDateTextBox.Location = new System.Drawing.Point(807, 128);
            this.endDateTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.endDateTextBox.Name = "endDateTextBox";
            this.endDateTextBox.Size = new System.Drawing.Size(132, 26);
            this.endDateTextBox.TabIndex = 11;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(672, 289);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 12;
            // 
            // getStartDateBnt
            // 
            this.getStartDateBnt.Location = new System.Drawing.Point(961, 89);
            this.getStartDateBnt.Margin = new System.Windows.Forms.Padding(4);
            this.getStartDateBnt.Name = "getStartDateBnt";
            this.getStartDateBnt.Size = new System.Drawing.Size(100, 28);
            this.getStartDateBnt.TabIndex = 13;
            this.getStartDateBnt.Text = "Get date";
            this.getStartDateBnt.UseVisualStyleBackColor = true;
            this.getStartDateBnt.Click += new System.EventHandler(this.getStartDateBnt_Click);
            // 
            // getEndDateBtn
            // 
            this.getEndDateBtn.Location = new System.Drawing.Point(961, 128);
            this.getEndDateBtn.Margin = new System.Windows.Forms.Padding(4);
            this.getEndDateBtn.Name = "getEndDateBtn";
            this.getEndDateBtn.Size = new System.Drawing.Size(100, 28);
            this.getEndDateBtn.TabIndex = 14;
            this.getEndDateBtn.Text = "Get date";
            this.getEndDateBtn.UseVisualStyleBackColor = true;
            this.getEndDateBtn.Click += new System.EventHandler(this.getEndDateBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 606);
            this.Controls.Add(this.getEndDateBtn);
            this.Controls.Add(this.getStartDateBnt);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.endDateTextBox);
            this.Controls.Add(this.startDateTextBox);
            this.Controls.Add(this.EndDateTxt);
            this.Controls.Add(this.startDateTxt);
            this.Controls.Add(this.reportComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reportBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.transferStatusRichTextBox);
            this.Controls.Add(this.dataTransferComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataTransferBtn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dataTransferBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dataTransferComboBox;
        private System.Windows.Forms.RichTextBox transferStatusRichTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox reportComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button reportBtn;
        private System.Windows.Forms.Label startDateTxt;
        private System.Windows.Forms.Label EndDateTxt;
        private System.Windows.Forms.TextBox startDateTextBox;
        private System.Windows.Forms.TextBox endDateTextBox;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button getStartDateBnt;
        private System.Windows.Forms.Button getEndDateBtn;

    }
}