namespace WindowsFormsApplication1
{
    partial class ExceltoSql
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dbIpAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDBName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.MaskedTextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSqlSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Excel file path";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(117, 8);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server IP";
            // 
            // dbIpAddress
            // 
            this.dbIpAddress.Location = new System.Drawing.Point(117, 37);
            this.dbIpAddress.Name = "dbIpAddress";
            this.dbIpAddress.Size = new System.Drawing.Size(146, 20);
            this.dbIpAddress.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // lblUID
            // 
            this.lblUID.Location = new System.Drawing.Point(117, 92);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(146, 20);
            this.lblUID.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "User ID";
            // 
            // lblDBName
            // 
            this.lblDBName.Location = new System.Drawing.Point(117, 63);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(146, 20);
            this.lblDBName.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Database Name";
            // 
            // lblPwd
            // 
            this.lblPwd.Location = new System.Drawing.Point(117, 118);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(146, 20);
            this.lblPwd.TabIndex = 4;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(188, 162);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Convert";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSqlSave
            // 
            this.btnSqlSave.Location = new System.Drawing.Point(107, 162);
            this.btnSqlSave.Name = "btnSqlSave";
            this.btnSqlSave.Size = new System.Drawing.Size(75, 23);
            this.btnSqlSave.TabIndex = 6;
            this.btnSqlSave.Text = "Save as sql file";
            this.btnSqlSave.UseVisualStyleBackColor = true;
            this.btnSqlSave.Click += new System.EventHandler(this.btnSqlSave_Click);
            // 
            // ExceltoSql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 187);
            this.Controls.Add(this.btnSqlSave);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.lblDBName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblUID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dbIpAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label1);
            this.Name = "ExceltoSql";
            this.Text = "ExceltoSql";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dbIpAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lblUID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox lblDBName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox lblPwd;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSqlSave;
    }
}

