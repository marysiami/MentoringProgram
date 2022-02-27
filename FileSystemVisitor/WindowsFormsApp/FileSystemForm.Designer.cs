namespace WindowsFormsApp
{
    partial class FileSystemForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addFiltersLabel = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.startLabel = new System.Windows.Forms.Label();
            this.stopLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.noPathLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.resultTree = new System.Windows.Forms.TreeView();
            this.label8 = new System.Windows.Forms.Label();
            this.DirStop = new System.Windows.Forms.CheckBox();
            this.DirEx = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.FilesEx = new System.Windows.Forms.CheckBox();
            this.FileStop = new System.Windows.Forms.CheckBox();
            this.FDirEx = new System.Windows.Forms.CheckBox();
            this.FDirStop = new System.Windows.Forms.CheckBox();
            this.FFilesEx = new System.Windows.Forms.CheckBox();
            this.FFileStop = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(298, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 424);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Search Pattern";
            this.label2.Visible = false;
            // 
            // addFiltersLabel
            // 
            this.addFiltersLabel.AutoSize = true;
            this.addFiltersLabel.Location = new System.Drawing.Point(22, 358);
            this.addFiltersLabel.Name = "addFiltersLabel";
            this.addFiltersLabel.Size = new System.Drawing.Size(75, 17);
            this.addFiltersLabel.TabIndex = 3;
            this.addFiltersLabel.Text = "Add Filters";
            this.addFiltersLabel.UseVisualStyleBackColor = true;
            this.addFiltersLabel.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(106, 421);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(114, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 451);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Search Option";
            this.label3.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(105, 520);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(114, 20);
            this.textBox3.TabIndex = 6;
            this.textBox3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 523);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Search Pattern";
            this.label4.Visible = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(106, 451);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(114, 17);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "Top Directory Only";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 392);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Directories";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 496);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Files";
            this.label6.Visible = false;
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Chartreuse;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonStart.Location = new System.Drawing.Point(146, 592);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(117, 38);
            this.buttonStart.TabIndex = 12;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.startLabel.Location = new System.Drawing.Point(519, 124);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(74, 18);
            this.startLabel.TabIndex = 14;
            this.startLabel.Text = "StartLabel";
            this.startLabel.Visible = false;
            // 
            // stopLabel
            // 
            this.stopLabel.AutoSize = true;
            this.stopLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.stopLabel.Location = new System.Drawing.Point(519, 546);
            this.stopLabel.Name = "stopLabel";
            this.stopLabel.Size = new System.Drawing.Size(74, 18);
            this.stopLabel.TabIndex = 15;
            this.stopLabel.Text = "StopLabel";
            this.stopLabel.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(263, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 16;
            // 
            // noPathLabel
            // 
            this.noPathLabel.AutoSize = true;
            this.noPathLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.noPathLabel.Location = new System.Drawing.Point(57, 60);
            this.noPathLabel.Name = "noPathLabel";
            this.noPathLabel.Size = new System.Drawing.Size(70, 13);
            this.noPathLabel.TabIndex = 17;
            this.noPathLabel.Text = "Enter a value";
            this.noPathLabel.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(712, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "EVENT LOGS";
            // 
            // resultTree
            // 
            this.resultTree.Location = new System.Drawing.Point(522, 157);
            this.resultTree.Name = "resultTree";
            this.resultTree.Size = new System.Drawing.Size(561, 361);
            this.resultTree.TabIndex = 23;
            this.resultTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView_NodeMouseDoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(845, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Double click - remove node";
            // 
            // DirStop
            // 
            this.DirStop.AutoSize = true;
            this.DirStop.Location = new System.Drawing.Point(30, 125);
            this.DirStop.Name = "DirStop";
            this.DirStop.Size = new System.Drawing.Size(61, 17);
            this.DirStop.TabIndex = 25;
            this.DirStop.Text = "DirStop";
            this.DirStop.UseVisualStyleBackColor = true;
            // 
            // DirEx
            // 
            this.DirEx.AutoSize = true;
            this.DirEx.Location = new System.Drawing.Point(30, 152);
            this.DirEx.Name = "DirEx";
            this.DirEx.Size = new System.Drawing.Size(51, 17);
            this.DirEx.TabIndex = 26;
            this.DirEx.Text = "DirEx";
            this.DirEx.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(27, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 18);
            this.label10.TabIndex = 29;
            this.label10.Text = "Directories";
            this.label10.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(24, 198);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 20);
            this.label11.TabIndex = 30;
            this.label11.Text = "Files";
            this.label11.Visible = false;
            // 
            // FilesEx
            // 
            this.FilesEx.AutoSize = true;
            this.FilesEx.Location = new System.Drawing.Point(30, 258);
            this.FilesEx.Name = "FilesEx";
            this.FilesEx.Size = new System.Drawing.Size(59, 17);
            this.FilesEx.TabIndex = 32;
            this.FilesEx.Text = "FilesEx";
            this.FilesEx.UseVisualStyleBackColor = true;
            // 
            // FileStop
            // 
            this.FileStop.AutoSize = true;
            this.FileStop.Location = new System.Drawing.Point(30, 231);
            this.FileStop.Name = "FileStop";
            this.FileStop.Size = new System.Drawing.Size(64, 17);
            this.FileStop.TabIndex = 31;
            this.FileStop.Text = "FileStop";
            this.FileStop.UseVisualStyleBackColor = true;
            // 
            // FDirEx
            // 
            this.FDirEx.AutoSize = true;
            this.FDirEx.Location = new System.Drawing.Point(290, 447);
            this.FDirEx.Name = "FDirEx";
            this.FDirEx.Size = new System.Drawing.Size(51, 17);
            this.FDirEx.TabIndex = 34;
            this.FDirEx.Text = "DirEx";
            this.FDirEx.UseVisualStyleBackColor = true;
            this.FDirEx.Visible = false;
            // 
            // FDirStop
            // 
            this.FDirStop.AutoSize = true;
            this.FDirStop.Location = new System.Drawing.Point(290, 420);
            this.FDirStop.Name = "FDirStop";
            this.FDirStop.Size = new System.Drawing.Size(61, 17);
            this.FDirStop.TabIndex = 33;
            this.FDirStop.Text = "DirStop";
            this.FDirStop.UseVisualStyleBackColor = true;
            this.FDirStop.Visible = false;
            // 
            // FFilesEx
            // 
            this.FFilesEx.AutoSize = true;
            this.FFilesEx.Location = new System.Drawing.Point(290, 523);
            this.FFilesEx.Name = "FFilesEx";
            this.FFilesEx.Size = new System.Drawing.Size(59, 17);
            this.FFilesEx.TabIndex = 36;
            this.FFilesEx.Text = "FilesEx";
            this.FFilesEx.UseVisualStyleBackColor = true;
            this.FFilesEx.Visible = false;
            // 
            // FFileStop
            // 
            this.FFileStop.AutoSize = true;
            this.FFileStop.Location = new System.Drawing.Point(290, 496);
            this.FFileStop.Name = "FFileStop";
            this.FFileStop.Size = new System.Drawing.Size(69, 17);
            this.FFileStop.TabIndex = 35;
            this.FFileStop.Text = "FilesStop";
            this.FFileStop.UseVisualStyleBackColor = true;
            this.FFileStop.Visible = false;
            // 
            // FileSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 651);
            this.Controls.Add(this.FFilesEx);
            this.Controls.Add(this.FFileStop);
            this.Controls.Add(this.FDirEx);
            this.Controls.Add(this.FDirStop);
            this.Controls.Add(this.FilesEx);
            this.Controls.Add(this.FileStop);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.DirEx);
            this.Controls.Add(this.DirStop);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.resultTree);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.noPathLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.stopLabel);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.addFiltersLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "FileSystemForm";
            this.Text = "FileSystemForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox addFiltersLabel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label stopLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label noPathLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TreeView resultTree;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox DirStop;
        private System.Windows.Forms.CheckBox DirEx;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox FilesEx;
        private System.Windows.Forms.CheckBox FileStop;
        private System.Windows.Forms.CheckBox FDirEx;
        private System.Windows.Forms.CheckBox FDirStop;
        private System.Windows.Forms.CheckBox FFilesEx;
        private System.Windows.Forms.CheckBox FFileStop;
    }
}