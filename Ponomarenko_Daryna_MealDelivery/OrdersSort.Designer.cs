
namespace Ponomarenko_Daryna_MealDelivery
{
    partial class OrdersSort
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
            this.btnLoadOrders = new System.Windows.Forms.Button();
            this.btnSortAndLoad = new System.Windows.Forms.Button();
            this.lbSort = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnLoadOrders
            // 
            this.btnLoadOrders.Location = new System.Drawing.Point(56, 31);
            this.btnLoadOrders.Name = "btnLoadOrders";
            this.btnLoadOrders.Size = new System.Drawing.Size(156, 53);
            this.btnLoadOrders.TabIndex = 0;
            this.btnLoadOrders.Text = "Load";
            this.btnLoadOrders.UseVisualStyleBackColor = true;
            this.btnLoadOrders.Click += new System.EventHandler(this.BtnLoadOrders_Click);
            // 
            // btnSortAndLoad
            // 
            this.btnSortAndLoad.Location = new System.Drawing.Point(56, 124);
            this.btnSortAndLoad.Name = "btnSortAndLoad";
            this.btnSortAndLoad.Size = new System.Drawing.Size(156, 53);
            this.btnSortAndLoad.TabIndex = 1;
            this.btnSortAndLoad.Text = "Sort and load";
            this.btnSortAndLoad.UseVisualStyleBackColor = true;
            this.btnSortAndLoad.Click += new System.EventHandler(this.BtnSortAndLoad_Click);
            // 
            // lbSort
            // 
            this.lbSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSort.FormattingEnabled = true;
            this.lbSort.ItemHeight = 18;
            this.lbSort.Location = new System.Drawing.Point(259, 31);
            this.lbSort.Name = "lbSort";
            this.lbSort.Size = new System.Drawing.Size(245, 238);
            this.lbSort.TabIndex = 2;
            // 
            // OrdersSort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 350);
            this.Controls.Add(this.lbSort);
            this.Controls.Add(this.btnSortAndLoad);
            this.Controls.Add(this.btnLoadOrders);
            this.Name = "OrdersSort";
            this.Text = "OrdersSort";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadOrders;
        private System.Windows.Forms.Button btnSortAndLoad;
        private System.Windows.Forms.ListBox lbSort;
    }
}