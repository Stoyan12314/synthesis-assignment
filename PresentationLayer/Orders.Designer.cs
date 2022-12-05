namespace PresentationLayer
{
    partial class Orders
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
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.order_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delivery_option = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delivery_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.order_id,
            this.order_date,
            this.delivery_option,
            this.delivery_date,
            this.order_status});
            this.dataGridViewOrders.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.RowHeadersWidth = 51;
            this.dataGridViewOrders.RowTemplate.Height = 29;
            this.dataGridViewOrders.Size = new System.Drawing.Size(679, 514);
            this.dataGridViewOrders.TabIndex = 0;
            this.dataGridViewOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // order_id
            // 
            this.order_id.HeaderText = "Order id";
            this.order_id.MinimumWidth = 6;
            this.order_id.Name = "order_id";
            this.order_id.Width = 125;
            // 
            // order_date
            // 
            this.order_date.HeaderText = "order date";
            this.order_date.MinimumWidth = 6;
            this.order_date.Name = "order_date";
            this.order_date.Width = 125;
            // 
            // delivery_option
            // 
            this.delivery_option.HeaderText = "delivery option";
            this.delivery_option.MinimumWidth = 6;
            this.delivery_option.Name = "delivery_option";
            this.delivery_option.Width = 125;
            // 
            // delivery_date
            // 
            this.delivery_date.HeaderText = "delivery date";
            this.delivery_date.MinimumWidth = 6;
            this.delivery_date.Name = "delivery_date";
            this.delivery_date.Width = 125;
            // 
            // order_status
            // 
            this.order_status.HeaderText = "order status";
            this.order_status.MinimumWidth = 6;
            this.order_status.Name = "order_status";
            this.order_status.Width = 125;
            // 
            // Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 534);
            this.Controls.Add(this.dataGridViewOrders);
            this.Name = "Orders";
            this.Text = "Orders";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn delivery_option;
        private System.Windows.Forms.DataGridViewTextBoxColumn delivery_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_status;
    }
}