namespace Scrambler
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
            this.scrmbledText = new System.Windows.Forms.TextBox();
            this.scrambleBtn = new System.Windows.Forms.Button();
            this.insertSpace = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TrimSpace = new System.Windows.Forms.CheckBox();
            this.AllLowerCase = new System.Windows.Forms.CheckBox();
            this.AllUpperCase = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.inputText = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // scrmbledText
            // 
            this.scrmbledText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scrmbledText.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.scrmbledText.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scrmbledText.Location = new System.Drawing.Point(167, 228);
            this.scrmbledText.Multiline = true;
            this.scrmbledText.Name = "scrmbledText";
            this.scrmbledText.ReadOnly = true;
            this.scrmbledText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.scrmbledText.Size = new System.Drawing.Size(582, 235);
            this.scrmbledText.TabIndex = 2;
            // 
            // scrambleBtn
            // 
            this.scrambleBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.scrambleBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.scrambleBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.scrambleBtn.Font = new System.Drawing.Font("Corbel", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scrambleBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.scrambleBtn.Location = new System.Drawing.Point(1, 228);
            this.scrambleBtn.Name = "scrambleBtn";
            this.scrambleBtn.Size = new System.Drawing.Size(160, 235);
            this.scrambleBtn.TabIndex = 3;
            this.scrambleBtn.Text = "Scramble Them";
            this.scrambleBtn.UseVisualStyleBackColor = false;
            this.scrambleBtn.Click += new System.EventHandler(this.scrambleBtn_Click);
            // 
            // insertSpace
            // 
            this.insertSpace.AutoSize = true;
            this.insertSpace.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertSpace.Location = new System.Drawing.Point(6, 32);
            this.insertSpace.Name = "insertSpace";
            this.insertSpace.Size = new System.Drawing.Size(94, 19);
            this.insertSpace.TabIndex = 4;
            this.insertSpace.Text = "Insert Spaces";
            this.insertSpace.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TrimSpace);
            this.groupBox1.Controls.Add(this.AllLowerCase);
            this.groupBox1.Controls.Add(this.AllUpperCase);
            this.groupBox1.Controls.Add(this.insertSpace);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1, -6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 228);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // TrimSpace
            // 
            this.TrimSpace.AutoSize = true;
            this.TrimSpace.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrimSpace.Location = new System.Drawing.Point(7, 114);
            this.TrimSpace.Name = "TrimSpace";
            this.TrimSpace.Size = new System.Drawing.Size(85, 19);
            this.TrimSpace.TabIndex = 7;
            this.TrimSpace.Text = "Trim Space";
            this.TrimSpace.UseVisualStyleBackColor = true;
            // 
            // AllLowerCase
            // 
            this.AllLowerCase.AutoSize = true;
            this.AllLowerCase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllLowerCase.Location = new System.Drawing.Point(6, 86);
            this.AllLowerCase.Name = "AllLowerCase";
            this.AllLowerCase.Size = new System.Drawing.Size(103, 19);
            this.AllLowerCase.TabIndex = 6;
            this.AllLowerCase.Text = "All Lower Case";
            this.AllLowerCase.UseVisualStyleBackColor = true;
            this.AllLowerCase.CheckedChanged += new System.EventHandler(this.AllLowerCase_CheckedChanged);
            // 
            // AllUpperCase
            // 
            this.AllUpperCase.AutoSize = true;
            this.AllUpperCase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllUpperCase.Location = new System.Drawing.Point(6, 59);
            this.AllUpperCase.Name = "AllUpperCase";
            this.AllUpperCase.Size = new System.Drawing.Size(103, 19);
            this.AllUpperCase.TabIndex = 5;
            this.AllUpperCase.Text = "All Upper Case";
            this.AllUpperCase.UseVisualStyleBackColor = true;
            this.AllUpperCase.CheckedChanged += new System.EventHandler(this.AllUpperCase_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.inputText);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(167, -6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(582, 228);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Text";
            // 
            // inputText
            // 
            this.inputText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputText.Location = new System.Drawing.Point(6, 37);
            this.inputText.Multiline = true;
            this.inputText.Name = "inputText";
            this.inputText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.inputText.Size = new System.Drawing.Size(576, 185);
            this.inputText.TabIndex = 0;
            this.inputText.Text = "Insert Text Here...";
            this.inputText.Click += new System.EventHandler(this.inputText_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(748, 464);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.scrambleBtn);
            this.Controls.Add(this.scrmbledText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Sadhontoon Scrambler";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox scrmbledText;
        private System.Windows.Forms.Button scrambleBtn;
        private System.Windows.Forms.CheckBox insertSpace;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox TrimSpace;
        private System.Windows.Forms.CheckBox AllLowerCase;
        private System.Windows.Forms.CheckBox AllUpperCase;
        private System.Windows.Forms.TextBox inputText;
    }
}

