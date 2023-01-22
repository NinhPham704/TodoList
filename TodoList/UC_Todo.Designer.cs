namespace TodoList
{
    partial class UC_Todo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDelete = new System.Windows.Forms.Button();
            this.txbStatus = new System.Windows.Forms.TextBox();
            this.ckbDone = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(365, 4);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 27);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txbStatus
            // 
            this.txbStatus.Location = new System.Drawing.Point(32, 4);
            this.txbStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbStatus.Name = "txbStatus";
            this.txbStatus.Size = new System.Drawing.Size(327, 27);
            this.txbStatus.TabIndex = 4;
            this.txbStatus.Text = "Write Something";
            // 
            // ckbDone
            // 
            this.ckbDone.AutoSize = true;
            this.ckbDone.Location = new System.Drawing.Point(8, 9);
            this.ckbDone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckbDone.Name = "ckbDone";
            this.ckbDone.Size = new System.Drawing.Size(18, 17);
            this.ckbDone.TabIndex = 5;
            this.ckbDone.UseVisualStyleBackColor = true;
            this.ckbDone.CheckedChanged += new System.EventHandler(this.ckbDone_CheckedChanged);
            // 
            // UC_Todo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ckbDone);
            this.Controls.Add(this.txbStatus);
            this.Controls.Add(this.btnDelete);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "UC_Todo";
            this.Size = new System.Drawing.Size(446, 41);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnDelete;
        private TextBox txbStatus;
        private CheckBox ckbDone;
    }
}
