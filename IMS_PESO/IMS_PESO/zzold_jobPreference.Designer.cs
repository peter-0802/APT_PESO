namespace IMS_PESO
{
    partial class zzold_jobPreference
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
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label46 = new System.Windows.Forms.Label();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.preferedOccupation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radioButton26 = new System.Windows.Forms.RadioButton();
            this.radioButton25 = new System.Windows.Forms.RadioButton();
            this.label45 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.textBox30);
            this.groupBox12.Controls.Add(this.button2);
            this.groupBox12.Controls.Add(this.label46);
            this.groupBox12.Controls.Add(this.textBox29);
            this.groupBox12.Controls.Add(this.dataGridView1);
            this.groupBox12.Controls.Add(this.radioButton26);
            this.groupBox12.Controls.Add(this.radioButton25);
            this.groupBox12.Controls.Add(this.label45);
            this.groupBox12.Controls.Add(this.label43);
            this.groupBox12.Controls.Add(this.label39);
            this.groupBox12.Controls.Add(this.textBox24);
            this.groupBox12.Controls.Add(this.textBox28);
            this.groupBox12.Controls.Add(this.label33);
            this.groupBox12.Controls.Add(this.label44);
            this.groupBox12.Controls.Add(this.label37);
            this.groupBox12.Controls.Add(this.textBox21);
            this.groupBox12.Location = new System.Drawing.Point(12, 41);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(1011, 332);
            this.groupBox12.TabIndex = 58;
            this.groupBox12.TabStop = false;
            // 
            // textBox30
            // 
            this.textBox30.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox30.Location = new System.Drawing.Point(801, 259);
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new System.Drawing.Size(164, 24);
            this.textBox30.TabIndex = 78;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(855, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 25);
            this.button2.TabIndex = 82;
            this.button2.Text = "Add to pending list";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(694, 261);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(94, 20);
            this.label46.TabIndex = 79;
            this.label46.Text = "Expiry Date:";
            // 
            // textBox29
            // 
            this.textBox29.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox29.Location = new System.Drawing.Point(487, 257);
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new System.Drawing.Size(164, 24);
            this.textBox29.TabIndex = 76;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.preferedOccupation,
            this.location});
            this.dataGridView1.Location = new System.Drawing.Point(10, 112);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(995, 136);
            this.dataGridView1.TabIndex = 81;
            // 
            // preferedOccupation
            // 
            this.preferedOccupation.HeaderText = "Prefered Occupation";
            this.preferedOccupation.Name = "preferedOccupation";
            this.preferedOccupation.ReadOnly = true;
            // 
            // location
            // 
            this.location.HeaderText = "Prefered Location";
            this.location.Name = "location";
            this.location.ReadOnly = true;
            // 
            // radioButton26
            // 
            this.radioButton26.AutoSize = true;
            this.radioButton26.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.radioButton26.Location = new System.Drawing.Point(725, 39);
            this.radioButton26.Name = "radioButton26";
            this.radioButton26.Size = new System.Drawing.Size(213, 22);
            this.radioButton26.TabIndex = 76;
            this.radioButton26.TabStop = true;
            this.radioButton26.Text = "Overseas, specific countries";
            this.radioButton26.UseVisualStyleBackColor = true;
            // 
            // radioButton25
            // 
            this.radioButton25.AutoSize = true;
            this.radioButton25.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.radioButton25.Location = new System.Drawing.Point(481, 39);
            this.radioButton25.Name = "radioButton25";
            this.radioButton25.Size = new System.Drawing.Size(238, 22);
            this.radioButton25.TabIndex = 75;
            this.radioButton25.TabStop = true;
            this.radioButton25.Text = "Local, specific cities/municipality";
            this.radioButton25.UseVisualStyleBackColor = true;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(353, 261);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(100, 20);
            this.label45.TabIndex = 77;
            this.label45.Text = "Passport No.";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(477, 16);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(182, 20);
            this.label43.TabIndex = 72;
            this.label43.Text = "PREFERED LOCATION";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(6, 73);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(22, 20);
            this.label39.TabIndex = 61;
            this.label39.Text = "1.";
            // 
            // textBox24
            // 
            this.textBox24.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox24.Location = new System.Drawing.Point(28, 71);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(330, 24);
            this.textBox24.TabIndex = 60;
            // 
            // textBox28
            // 
            this.textBox28.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox28.Location = new System.Drawing.Point(140, 259);
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new System.Drawing.Size(164, 24);
            this.textBox28.TabIndex = 75;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(477, 73);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(22, 20);
            this.label33.TabIndex = 55;
            this.label33.Text = "1.";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(6, 261);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(128, 20);
            this.label44.TabIndex = 75;
            this.label44.Text = "Expected Salary:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(6, 16);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(206, 20);
            this.label37.TabIndex = 54;
            this.label37.Text = "PREFERED OCCUPATION";
            // 
            // textBox21
            // 
            this.textBox21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox21.Location = new System.Drawing.Point(499, 71);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(350, 24);
            this.textBox21.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 80;
            this.label1.Text = "~code~";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 82;
            this.label2.Text = "Code:";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DodgerBlue;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(801, 388);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(222, 47);
            this.button3.TabIndex = 83;
            this.button3.Text = "Create Contact";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // jobPreference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "jobPreference";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PESO IMS   ||   II - Job Preference";
            this.Load += new System.EventHandler(this.jobPreference_Load);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.RadioButton radioButton26;
        private System.Windows.Forms.RadioButton radioButton25;
        private System.Windows.Forms.TextBox textBox30;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox textBox29;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox textBox28;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox textBox21;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn preferedOccupation;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
    }
}