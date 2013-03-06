namespace ScramblerWindowsForm
{
    partial class MainForm
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
			this.sourceFileTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.logFileTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.stopWatchLabel = new System.Windows.Forms.Label();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// sourceFileTextBox
			// 
			this.sourceFileTextBox.Location = new System.Drawing.Point(10, 29);
			this.sourceFileTextBox.Name = "sourceFileTextBox";
			this.sourceFileTextBox.Size = new System.Drawing.Size(320, 20);
			this.sourceFileTextBox.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Enter Text";
			// 
			// logFileTextBox
			// 
			this.logFileTextBox.Location = new System.Drawing.Point(12, 115);
			this.logFileTextBox.Multiline = true;
			this.logFileTextBox.Name = "logFileTextBox";
			this.logFileTextBox.Size = new System.Drawing.Size(570, 232);
			this.logFileTextBox.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 99);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Scrambled String";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 55);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 21);
			this.button1.TabIndex = 6;
			this.button1.Text = "Scramble";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(470, 89);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(113, 23);
			this.button3.TabIndex = 8;
			this.button3.Text = "Scramble to Text";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(495, 353);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(88, 23);
			this.button4.TabIndex = 9;
			this.button4.Text = "Exit";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(336, 29);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(91, 21);
			this.button5.TabIndex = 10;
			this.button5.Text = "Browse";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// stopWatchLabel
			// 
			this.stopWatchLabel.AutoSize = true;
			this.stopWatchLabel.Location = new System.Drawing.Point(109, 63);
			this.stopWatchLabel.Name = "stopWatchLabel";
			this.stopWatchLabel.Size = new System.Drawing.Size(56, 13);
			this.stopWatchLabel.TabIndex = 11;
			this.stopWatchLabel.Text = "Enter Text";
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(208, 58);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(374, 18);
			this.progressBar.TabIndex = 12;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(590, 385);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.stopWatchLabel);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.logFileTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.sourceFileTextBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sourceFileTextBox;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox logFileTextBox;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Label stopWatchLabel;
		private System.Windows.Forms.ProgressBar progressBar;
    }
}

