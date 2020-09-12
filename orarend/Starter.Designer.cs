namespace orarend
{
    partial class Starter
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
            this.Sub_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Sub_length = new System.Windows.Forms.NumericUpDown();
            this.StartofList = new System.Windows.Forms.Label();
            this.List = new System.Windows.Forms.ListBox();
            this.Add = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_length)).BeginInit();
            this.SuspendLayout();
            // 
            // Sub_name
            // 
            this.Sub_name.Location = new System.Drawing.Point(82, 26);
            this.Sub_name.Name = "Sub_name";
            this.Sub_name.Size = new System.Drawing.Size(100, 20);
            this.Sub_name.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tárgy neve:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tárgy hossza(órában):";
            // 
            // Sub_length
            // 
            this.Sub_length.Location = new System.Drawing.Point(138, 59);
            this.Sub_length.Name = "Sub_length";
            this.Sub_length.Size = new System.Drawing.Size(120, 20);
            this.Sub_length.TabIndex = 3;
            this.Sub_length.ValueChanged += new System.EventHandler(this.Sub_length_ValueChanged);
            // 
            // StartofList
            // 
            this.StartofList.AutoSize = true;
            this.StartofList.Location = new System.Drawing.Point(15, 91);
            this.StartofList.Name = "StartofList";
            this.StartofList.Size = new System.Drawing.Size(111, 13);
            this.StartofList.TabIndex = 4;
            this.StartofList.Text = "Lehetőségek(órában):";
            // 
            // List
            // 
            this.List.FormattingEnabled = true;
            this.List.HorizontalScrollbar = true;
            this.List.Location = new System.Drawing.Point(346, 26);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(600, 407);
            this.List.TabIndex = 5;
            this.List.KeyUp += new System.Windows.Forms.KeyEventHandler(this.List_KeyUp);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(265, 410);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 6;
            this.Add.Text = "Hozzáad";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(595, 441);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 7;
            this.Start.Text = "Órarendek";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Starter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(958, 476);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.List);
            this.Controls.Add(this.StartofList);
            this.Controls.Add(this.Sub_length);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Sub_name);
            this.Name = "Starter";
            this.Text = "Starter";
            ((System.ComponentModel.ISupportInitialize)(this.Sub_length)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Sub_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Sub_length;
        private System.Windows.Forms.Label StartofList;
        private System.Windows.Forms.ListBox List;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Start;
    }
}

