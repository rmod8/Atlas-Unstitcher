namespace AtlasUnstitcher
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolstrip = new System.Windows.Forms.ToolStrip();
            this.toolstripButtonFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolstripMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelExampleExportName = new System.Windows.Forms.Label();
            this.comboSuffix = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textbExportedName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelAspectRatio = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NumericY = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NumericX = new System.Windows.Forms.NumericUpDown();
            this.buttonExport = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox = new AtlasUnstitcher.PictureBoxWithInterpolationMode();
            this.comboBackType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolstrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericX)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolstrip
            // 
            this.toolstrip.BackColor = System.Drawing.SystemColors.Control;
            this.toolstrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripButtonFile});
            this.toolstrip.Location = new System.Drawing.Point(0, 0);
            this.toolstrip.Name = "toolstrip";
            this.toolstrip.Size = new System.Drawing.Size(459, 25);
            this.toolstrip.TabIndex = 0;
            this.toolstrip.Text = "toolStrip1";
            // 
            // toolstripButtonFile
            // 
            this.toolstripButtonFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolstripButtonFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripMenuOpen});
            this.toolstripButtonFile.Image = ((System.Drawing.Image)(resources.GetObject("toolstripButtonFile.Image")));
            this.toolstripButtonFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstripButtonFile.Name = "toolstripButtonFile";
            this.toolstripButtonFile.Size = new System.Drawing.Size(38, 22);
            this.toolstripButtonFile.Text = "File";
            // 
            // toolstripMenuOpen
            // 
            this.toolstripMenuOpen.Name = "toolstripMenuOpen";
            this.toolstripMenuOpen.Size = new System.Drawing.Size(180, 22);
            this.toolstripMenuOpen.Text = "Open";
            this.toolstripMenuOpen.Click += new System.EventHandler(this.toolstripMenuOpen_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelExampleExportName);
            this.groupBox1.Controls.Add(this.comboSuffix);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textbExportedName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.labelAspectRatio);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.NumericY);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NumericX);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 176);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export Options:";
            // 
            // labelExampleExportName
            // 
            this.labelExampleExportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExampleExportName.Location = new System.Drawing.Point(6, 138);
            this.labelExampleExportName.Name = "labelExampleExportName";
            this.labelExampleExportName.Size = new System.Drawing.Size(152, 23);
            this.labelExampleExportName.TabIndex = 13;
            this.labelExampleExportName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboSuffix
            // 
            this.comboSuffix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSuffix.Enabled = false;
            this.comboSuffix.FormattingEnabled = true;
            this.comboSuffix.Items.AddRange(new object[] {
            "Total Incremental",
            "[XY] Axis Incremental",
            "[YX] Axis Incremental",
            "Minecraft \'terrain.png\'"});
            this.comboSuffix.Location = new System.Drawing.Point(6, 92);
            this.comboSuffix.Name = "comboSuffix";
            this.comboSuffix.Size = new System.Drawing.Size(139, 21);
            this.comboSuffix.TabIndex = 12;
            this.comboSuffix.SelectedIndexChanged += new System.EventHandler(this.comboSuffix_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Suffix:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Exported Name:";
            // 
            // textbExportedName
            // 
            this.textbExportedName.Enabled = false;
            this.textbExportedName.Location = new System.Drawing.Point(6, 42);
            this.textbExportedName.Name = "textbExportedName";
            this.textbExportedName.Size = new System.Drawing.Size(142, 20);
            this.textbExportedName.TabIndex = 9;
            this.textbExportedName.TextChanged += new System.EventHandler(this.textbExportedName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Filename Example:";
            // 
            // labelAspectRatio
            // 
            this.labelAspectRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAspectRatio.Location = new System.Drawing.Point(164, 138);
            this.labelAspectRatio.Name = "labelAspectRatio";
            this.labelAspectRatio.Size = new System.Drawing.Size(87, 23);
            this.labelAspectRatio.TabIndex = 6;
            this.labelAspectRatio.Text = "1 : 1";
            this.labelAspectRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Aspect Ratio:";
            // 
            // NumericY
            // 
            this.NumericY.Enabled = false;
            this.NumericY.Location = new System.Drawing.Point(167, 93);
            this.NumericY.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.NumericY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericY.Name = "NumericY";
            this.NumericY.Size = new System.Drawing.Size(94, 20);
            this.NumericY.TabIndex = 4;
            this.NumericY.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.NumericY.ValueChanged += new System.EventHandler(this.Numeric_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sectors per Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sectors per X:";
            // 
            // NumericX
            // 
            this.NumericX.Enabled = false;
            this.NumericX.Location = new System.Drawing.Point(167, 43);
            this.NumericX.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.NumericX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericX.Name = "NumericX";
            this.NumericX.Size = new System.Drawing.Size(94, 20);
            this.NumericX.TabIndex = 1;
            this.NumericX.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.NumericX.ValueChanged += new System.EventHandler(this.Numeric_ValueChanged);
            // 
            // buttonExport
            // 
            this.buttonExport.Enabled = false;
            this.buttonExport.Location = new System.Drawing.Point(12, 206);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 0;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox);
            this.groupBox2.Location = new System.Drawing.Point(285, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(162, 176);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sector Preview:";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Magenta;
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.pictureBox.Location = new System.Drawing.Point(6, 19);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(150, 150);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // comboBackType
            // 
            this.comboBackType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBackType.FormattingEnabled = true;
            this.comboBackType.Items.AddRange(new object[] {
            "White",
            "Magenta",
            "Monotone Checkerboard",
            "Black & Magenta Checkerboard"});
            this.comboBackType.Location = new System.Drawing.Point(242, 206);
            this.comboBackType.Name = "comboBackType";
            this.comboBackType.Size = new System.Drawing.Size(205, 21);
            this.comboBackType.TabIndex = 7;
            this.comboBackType.SelectedIndexChanged += new System.EventHandler(this.comboBackType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Background Type:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 233);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBackType);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolstrip);
            this.Controls.Add(this.buttonExport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atlas Unstitcher";
            this.toolstrip.ResumeLayout(false);
            this.toolstrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericX)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolstrip;
        private System.Windows.Forms.ToolStripDropDownButton toolstripButtonFile;
        private System.Windows.Forms.ToolStripMenuItem toolstripMenuOpen;
        private PictureBoxWithInterpolationMode pictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown NumericY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumericX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelAspectRatio;
        private System.Windows.Forms.ComboBox comboBackType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textbExportedName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboSuffix;
        private System.Windows.Forms.Label labelExampleExportName;
    }
}

