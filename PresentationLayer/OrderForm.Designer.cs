namespace PresentationLayer
{
    partial class OrderForm
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
            this.btnSaveButton = new System.Windows.Forms.Button();
            this.cbOrderStatus = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSaveButton
            // 
            this.btnSaveButton.Location = new System.Drawing.Point(38, 60);
            this.btnSaveButton.Name = "btnSaveButton";
            this.btnSaveButton.Size = new System.Drawing.Size(94, 29);
            this.btnSaveButton.TabIndex = 3;
            this.btnSaveButton.Text = "Save";
            this.btnSaveButton.UseVisualStyleBackColor = true;
            this.btnSaveButton.Click += new System.EventHandler(this.btnSaveButton_Click);
            // 
            // cbOrderStatus
            // 
            this.cbOrderStatus.FormattingEnabled = true;
            this.cbOrderStatus.Items.AddRange(new object[] {
            "Delivered",
            "InProgress"});
            this.cbOrderStatus.Location = new System.Drawing.Point(12, 12);
            this.cbOrderStatus.Name = "cbOrderStatus";
            this.cbOrderStatus.Size = new System.Drawing.Size(151, 28);
            this.cbOrderStatus.TabIndex = 2;
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(170, 93);
            this.Controls.Add(this.btnSaveButton);
            this.Controls.Add(this.cbOrderStatus);
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveButton;
        private System.Windows.Forms.ComboBox cbOrderStatus;
    }
}