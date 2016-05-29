namespace PortGui02
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
        	this.components = new System.ComponentModel.Container();
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        	this.checkBox1 = new System.Windows.Forms.CheckBox();
        	this.Tray = new System.Windows.Forms.NotifyIcon(this.components);
        	this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
        	this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        	this.button1 = new System.Windows.Forms.Button();
        	this.SuspendLayout();
        	// 
        	// checkBox1
        	// 
        	this.checkBox1.AutoSize = true;
        	this.checkBox1.Location = new System.Drawing.Point(1067, 49);
        	this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        	this.checkBox1.Name = "checkBox1";
        	this.checkBox1.Size = new System.Drawing.Size(455, 21);
        	this.checkBox1.TabIndex = 0;
        	this.checkBox1.Text = "если стоит галка, то бдут удаляться программы из этого списка";
        	this.checkBox1.UseVisualStyleBackColor = true;
        	// 
        	// Tray
        	// 
        	this.Tray.Icon = ((System.Drawing.Icon)(resources.GetObject("Tray.Icon")));
        	this.Tray.Text = "notifyIcon1";
        	this.Tray.Visible = true;
        	this.Tray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tray_MouseClick);
        	// 
        	// tableLayoutPanel1
        	// 
        	this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tableLayoutPanel1.AutoScroll = true;
        	this.tableLayoutPanel1.AutoSize = true;
        	this.tableLayoutPanel1.ColumnCount = 8;
        	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
        	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
        	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
        	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
        	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
        	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
        	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
        	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 281F));
        	this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        	this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        	this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        	this.tableLayoutPanel1.RowCount = 10;
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.tableLayoutPanel1.Size = new System.Drawing.Size(940, 292);
        	this.tableLayoutPanel1.TabIndex = 0;
        	// 
        	// button1
        	// 
        	this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.button1.Location = new System.Drawing.Point(1068, 15);
        	this.button1.Margin = new System.Windows.Forms.Padding(4);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(111, 28);
        	this.button1.TabIndex = 1;
        	this.button1.Text = "button1";
        	this.button1.UseVisualStyleBackColor = true;
        	// 
        	// Form1
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(475, 303);
        	this.Controls.Add(this.button1);
        	this.Controls.Add(this.checkBox1);
        	this.Controls.Add(this.tableLayoutPanel1);
        	this.Cursor = System.Windows.Forms.Cursors.Cross;
        	this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        	this.Name = "Form1";
        	this.Text = "Form1";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NotifyIcon Tray;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;


    }
}

