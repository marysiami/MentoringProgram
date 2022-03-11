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
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.FDirEx = new System.Windows.Forms.CheckBox();
            this.FDirStop = new System.Windows.Forms.CheckBox();
            this.FFilesEx = new System.Windows.Forms.CheckBox();
            this.FFileStop = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 37);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(396, 22);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 225);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Search Pattern";
            this.label2.Visible = false;
            // 
            // addFiltersLabel
            // 
            this.addFiltersLabel.AutoSize = true;
            this.addFiltersLabel.Location = new System.Drawing.Point(36, 144);
            this.addFiltersLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addFiltersLabel.Name = "addFiltersLabel";
            this.addFiltersLabel.Size = new System.Drawing.Size(93, 20);
            this.addFiltersLabel.TabIndex = 3;
            this.addFiltersLabel.Text = "Add Filters";
            this.addFiltersLabel.UseVisualStyleBackColor = true;
            this.addFiltersLabel.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(148, 221);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(151, 22);
            this.textBox2.TabIndex = 4;
            this.textBox2.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(147, 343);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(151, 22);
            this.textBox3.TabIndex = 6;
            this.textBox3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 347);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Search Pattern";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 185);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Directories";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 313);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 25);
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
            this.buttonStart.Location = new System.Drawing.Point(195, 729);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(156, 47);
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
            this.startLabel.Location = new System.Drawing.Point(692, 153);
            this.startLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(92, 24);
            this.startLabel.TabIndex = 14;
            this.startLabel.Text = "StartLabel";
            this.startLabel.Visible = false;
            // 
            // stopLabel
            // 
            this.stopLabel.AutoSize = true;
            this.stopLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.stopLabel.Location = new System.Drawing.Point(692, 672);
            this.stopLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stopLabel.Name = "stopLabel";
            this.stopLabel.Size = new System.Drawing.Size(94, 24);
            this.stopLabel.TabIndex = 15;
            this.stopLabel.Text = "StopLabel";
            this.stopLabel.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(351, 41);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 16);
            this.label9.TabIndex = 16;
            // 
            // noPathLabel
            // 
            this.noPathLabel.AutoSize = true;
            this.noPathLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.noPathLabel.Location = new System.Drawing.Point(76, 74);
            this.noPathLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.noPathLabel.Name = "noPathLabel";
            this.noPathLabel.Size = new System.Drawing.Size(85, 16);
            this.noPathLabel.TabIndex = 17;
            this.noPathLabel.Text = "Enter a value";
            this.noPathLabel.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(949, 118);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 25);
            this.label7.TabIndex = 19;
            this.label7.Text = "EVENT LOGS";
            // 
            // resultTree
            // 
            this.resultTree.Location = new System.Drawing.Point(696, 193);
            this.resultTree.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.resultTree.Name = "resultTree";
            this.resultTree.Size = new System.Drawing.Size(747, 443);
            this.resultTree.TabIndex = 23;
            this.resultTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView_NodeMouseDoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1127, 37);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(171, 16);
            this.label8.TabIndex = 24;
            this.label8.Text = "Double click - remove node";
            // 
            // FDirEx
            // 
            this.FDirEx.AutoSize = true;
            this.FDirEx.Location = new System.Drawing.Point(394, 253);
            this.FDirEx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FDirEx.Name = "FDirEx";
            this.FDirEx.Size = new System.Drawing.Size(61, 20);
            this.FDirEx.TabIndex = 34;
            this.FDirEx.Text = "DirEx";
            this.FDirEx.UseVisualStyleBackColor = true;
            this.FDirEx.Visible = false;
            // 
            // FDirStop
            // 
            this.FDirStop.AutoSize = true;
            this.FDirStop.Location = new System.Drawing.Point(394, 220);
            this.FDirStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FDirStop.Name = "FDirStop";
            this.FDirStop.Size = new System.Drawing.Size(74, 20);
            this.FDirStop.TabIndex = 33;
            this.FDirStop.Text = "DirStop";
            this.FDirStop.UseVisualStyleBackColor = true;
            this.FDirStop.Visible = false;
            // 
            // FFilesEx
            // 
            this.FFilesEx.AutoSize = true;
            this.FFilesEx.Location = new System.Drawing.Point(394, 347);
            this.FFilesEx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FFilesEx.Name = "FFilesEx";
            this.FFilesEx.Size = new System.Drawing.Size(73, 20);
            this.FFilesEx.TabIndex = 36;
            this.FFilesEx.Text = "FilesEx";
            this.FFilesEx.UseVisualStyleBackColor = true;
            this.FFilesEx.Visible = false;
            // 
            // FFileStop
            // 
            this.FFileStop.AutoSize = true;
            this.FFileStop.Location = new System.Drawing.Point(394, 313);
            this.FFileStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FFileStop.Name = "FFileStop";
            this.FFileStop.Size = new System.Drawing.Size(86, 20);
            this.FFileStop.TabIndex = 35;
            this.FFileStop.Text = "FilesStop";
            this.FFileStop.UseVisualStyleBackColor = true;
            this.FFileStop.Visible = false;
            // 
            // FileSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1555, 801);
            this.Controls.Add(this.FFilesEx);
            this.Controls.Add(this.FFileStop);
            this.Controls.Add(this.FDirEx);
            this.Controls.Add(this.FDirStop);
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
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.addFiltersLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.CheckBox FDirEx;
        private System.Windows.Forms.CheckBox FDirStop;
        private System.Windows.Forms.CheckBox FFilesEx;
        private System.Windows.Forms.CheckBox FFileStop;
    }
}