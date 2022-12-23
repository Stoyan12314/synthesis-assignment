namespace PresentationLayer
{
    partial class subCategoryForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SubCat_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subCat_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbSubCat = new System.Windows.Forms.TextBox();
            this.btnSubCat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubCat_id,
            this.subCat_name});
            this.dataGridView1.Location = new System.Drawing.Point(113, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(303, 188);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // SubCat_id
            // 
            this.SubCat_id.HeaderText = "SubCat id";
            this.SubCat_id.MinimumWidth = 6;
            this.SubCat_id.Name = "SubCat_id";
            this.SubCat_id.Width = 125;
            // 
            // subCat_name
            // 
            this.subCat_name.HeaderText = "SubCat name";
            this.subCat_name.MinimumWidth = 6;
            this.subCat_name.Name = "subCat_name";
            this.subCat_name.Width = 125;
            // 
            // tbSubCat
            // 
            this.tbSubCat.Location = new System.Drawing.Point(113, 319);
            this.tbSubCat.Name = "tbSubCat";
            this.tbSubCat.Size = new System.Drawing.Size(125, 27);
            this.tbSubCat.TabIndex = 1;
            this.tbSubCat.TextChanged += new System.EventHandler(this.tbSubCat_TextChanged);
            // 
            // btnSubCat
            // 
            this.btnSubCat.Location = new System.Drawing.Point(112, 362);
            this.btnSubCat.Name = "btnSubCat";
            this.btnSubCat.Size = new System.Drawing.Size(126, 29);
            this.btnSubCat.TabIndex = 2;
            this.btnSubCat.Text = "Create sub cat";
            this.btnSubCat.UseVisualStyleBackColor = true;
            this.btnSubCat.Click += new System.EventHandler(this.btnSubCat_Click);
            // 
            // subCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 450);
            this.Controls.Add(this.btnSubCat);
            this.Controls.Add(this.tbSubCat);
            this.Controls.Add(this.dataGridView1);
            this.Name = "subCategoryForm";
            this.Text = "subCategoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubCat_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn subCat_name;
        private System.Windows.Forms.TextBox tbSubCat;
        private System.Windows.Forms.Button btnSubCat;
    }
}