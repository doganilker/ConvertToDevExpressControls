namespace ConvertToDevExpressControls
{
    partial class FrmMainForm
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
            this.txtDesignerFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblDesignerFilePath = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDesignerFilePath
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtDesignerFilePath, 2);
            this.txtDesignerFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDesignerFilePath.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDesignerFilePath.Location = new System.Drawing.Point(3, 34);
            this.txtDesignerFilePath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDesignerFilePath.Multiline = true;
            this.txtDesignerFilePath.Name = "txtDesignerFilePath";
            this.txtDesignerFilePath.Size = new System.Drawing.Size(573, 22);
            this.txtDesignerFilePath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(582, 34);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(39, 22);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Controls.Add(this.btnConvert, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtLog, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtDesignerFilePath, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnBrowse, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDesignerFilePath, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 381);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnConvert
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnConvert, 2);
            this.btnConvert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConvert.Location = new System.Drawing.Point(532, 64);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(89, 22);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // txtLog
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtLog, 3);
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtLog.Location = new System.Drawing.Point(3, 93);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(618, 285);
            this.txtLog.TabIndex = 4;
            // 
            // lblDesignerFilePath
            // 
            this.lblDesignerFilePath.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblDesignerFilePath, 3);
            this.lblDesignerFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDesignerFilePath.Location = new System.Drawing.Point(3, 0);
            this.lblDesignerFilePath.Name = "lblDesignerFilePath";
            this.lblDesignerFilePath.Size = new System.Drawing.Size(618, 30);
            this.lblDesignerFilePath.TabIndex = 0;
            this.lblDesignerFilePath.Text = "C# designer file:";
            this.lblDesignerFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 381);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Convert to DevExpress Controls";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDesignerFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblDesignerFilePath;
    }
}

