namespace PresentationLayer
{
    partial class ItemForm
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
            this.pcBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lbPrice = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.lbCategory = new System.Windows.Forms.Label();
            this.lbSubCategory = new System.Windows.Forms.Label();
            this.tbSubCategory = new System.Windows.Forms.TextBox();
            this.lbItemName = new System.Windows.Forms.Label();
            this.tbItemName = new System.Windows.Forms.TextBox();
            this.lbUnit = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.lbItem = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbCat = new System.Windows.Forms.ComboBox();
            this.lbAmount = new System.Windows.Forms.Label();
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.btnSaveItem = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pcBox
            // 
            this.pcBox.Location = new System.Drawing.Point(32, 43);
            this.pcBox.Name = "pcBox";
            this.pcBox.Size = new System.Drawing.Size(265, 224);
            this.pcBox.TabIndex = 0;
            this.pcBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelectImage);
            this.groupBox1.Controls.Add(this.pcBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 329);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item Image";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Location = new System.Drawing.Point(87, 283);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(159, 29);
            this.btnSelectImage.TabIndex = 1;
            this.btnSelectImage.Text = "Select image";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(6, 297);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(592, 289);
            this.tbDescription.TabIndex = 14;
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(126, 167);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(41, 20);
            this.lbPrice.TabIndex = 22;
            this.lbPrice.Text = "Price";
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(390, 164);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(125, 27);
            this.tbPrice.TabIndex = 21;
            // 
            // lbCategory
            // 
            this.lbCategory.AutoSize = true;
            this.lbCategory.Location = new System.Drawing.Point(126, 127);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(69, 20);
            this.lbCategory.TabIndex = 20;
            this.lbCategory.Text = "Category";
            // 
            // lbSubCategory
            // 
            this.lbSubCategory.AutoSize = true;
            this.lbSubCategory.Location = new System.Drawing.Point(126, 87);
            this.lbSubCategory.Name = "lbSubCategory";
            this.lbSubCategory.Size = new System.Drawing.Size(98, 20);
            this.lbSubCategory.TabIndex = 18;
            this.lbSubCategory.Text = "Sub-category";
            // 
            // tbSubCategory
            // 
            this.tbSubCategory.Location = new System.Drawing.Point(390, 84);
            this.tbSubCategory.Name = "tbSubCategory";
            this.tbSubCategory.Size = new System.Drawing.Size(125, 27);
            this.tbSubCategory.TabIndex = 17;
            // 
            // lbItemName
            // 
            this.lbItemName.AutoSize = true;
            this.lbItemName.Location = new System.Drawing.Point(126, 47);
            this.lbItemName.Name = "lbItemName";
            this.lbItemName.Size = new System.Drawing.Size(49, 20);
            this.lbItemName.TabIndex = 16;
            this.lbItemName.Text = "Name";
            // 
            // tbItemName
            // 
            this.tbItemName.Location = new System.Drawing.Point(390, 44);
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.Size = new System.Drawing.Size(125, 27);
            this.tbItemName.TabIndex = 15;
            // 
            // lbUnit
            // 
            this.lbUnit.AutoSize = true;
            this.lbUnit.Location = new System.Drawing.Point(126, 213);
            this.lbUnit.Name = "lbUnit";
            this.lbUnit.Size = new System.Drawing.Size(36, 20);
            this.lbUnit.TabIndex = 23;
            this.lbUnit.Text = "Unit";
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(390, 247);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(125, 27);
            this.tbAmount.TabIndex = 24;
            // 
            // lbItem
            // 
            this.lbItem.AutoSize = true;
            this.lbItem.Location = new System.Drawing.Point(6, 274);
            this.lbItem.Name = "lbItem";
            this.lbItem.Size = new System.Drawing.Size(117, 20);
            this.lbItem.TabIndex = 25;
            this.lbItem.Text = "Item description";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbCat);
            this.groupBox2.Controls.Add(this.lbAmount);
            this.groupBox2.Controls.Add(this.cbUnit);
            this.groupBox2.Controls.Add(this.tbDescription);
            this.groupBox2.Controls.Add(this.lbItem);
            this.groupBox2.Controls.Add(this.tbAmount);
            this.groupBox2.Controls.Add(this.tbItemName);
            this.groupBox2.Controls.Add(this.lbUnit);
            this.groupBox2.Controls.Add(this.lbItemName);
            this.groupBox2.Controls.Add(this.lbPrice);
            this.groupBox2.Controls.Add(this.tbSubCategory);
            this.groupBox2.Controls.Add(this.tbPrice);
            this.groupBox2.Controls.Add(this.lbSubCategory);
            this.groupBox2.Controls.Add(this.lbCategory);
            this.groupBox2.Location = new System.Drawing.Point(385, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(604, 592);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Item description";
            // 
            // cbCat
            // 
            this.cbCat.FormattingEnabled = true;
            this.cbCat.Items.AddRange(new object[] {
            "Fruit and Vegetables",
            "Meat",
            "Drinks",
            "Bread",
            "Household goods "});
            this.cbCat.Location = new System.Drawing.Point(390, 124);
            this.cbCat.Name = "cbCat";
            this.cbCat.Size = new System.Drawing.Size(125, 28);
            this.cbCat.TabIndex = 28;
            // 
            // lbAmount
            // 
            this.lbAmount.AutoSize = true;
            this.lbAmount.Location = new System.Drawing.Point(126, 254);
            this.lbAmount.Name = "lbAmount";
            this.lbAmount.Size = new System.Drawing.Size(62, 20);
            this.lbAmount.TabIndex = 27;
            this.lbAmount.Text = "Amount";
            this.lbAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbUnit
            // 
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Items.AddRange(new object[] {
            "piece",
            "kilo",
            "box",
            "grams",
            "pack"});
            this.cbUnit.Location = new System.Drawing.Point(390, 205);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(123, 28);
            this.cbUnit.TabIndex = 26;
            // 
            // btnSaveItem
            // 
            this.btnSaveItem.Location = new System.Drawing.Point(391, 629);
            this.btnSaveItem.Name = "btnSaveItem";
            this.btnSaveItem.Size = new System.Drawing.Size(189, 40);
            this.btnSaveItem.TabIndex = 27;
            this.btnSaveItem.Text = "Save item";
            this.btnSaveItem.UseVisualStyleBackColor = true;
            this.btnSaveItem.Click += new System.EventHandler(this.btnSaveItem_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(595, 629);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(188, 40);
            this.btnRemoveItem.TabIndex = 28;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // ItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 693);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.btnSaveItem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ItemForm";
            this.Text = "Item";
            ((System.ComponentModel.ISupportInitialize)(this.pcBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pcBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label lbCategory;
        private System.Windows.Forms.TextBox cbCategory;
        private System.Windows.Forms.Label lbSubCategory;
        private System.Windows.Forms.TextBox tbSubCategory;
        private System.Windows.Forms.Label lbItemName;
        private System.Windows.Forms.TextBox tbItemName;
        private System.Windows.Forms.Label lbUnit;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label lbItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaveItem;
        private System.Windows.Forms.Label lbAmount;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.ComboBox cbCat;
        private System.Windows.Forms.Button btnRemoveItem;
    }
}