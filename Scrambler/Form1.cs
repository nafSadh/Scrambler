using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Scrambler {
	public partial class Form1 : Form {
		bool inputAnyText = false;
		public Form1() {
			InitializeComponent();
			openFileTextBox.Enabled = false;
			scrambleBtn.Click += scrambleBtn_Click;
		}

		private void scrambleBtn_Click(object sender, EventArgs e) {
			scramble(File.ReadAllText(@openFileTextBox.Text));
		}

		private void scramble(string text) {
			Scrambler.AllUp = allUpperCase.Checked;
			Scrambler.TrimSpace = trimSpace.Checked;
			Scrambler.InsertSpace = insertSpace.Checked;
			scrmbledText.Text = Scrambler.scrableTheText(text);
		}

		private void AllUpperCase_CheckedChanged(object sender, EventArgs e) {
			AllLowerCase.Enabled = !(allUpperCase.Checked);
		}

		private void AllLowerCase_CheckedChanged(object sender, EventArgs e) {
			allUpperCase.Enabled = !(AllLowerCase.Checked);
		}

		private void button1_Click(object sender, EventArgs e) {
			OpenFileDialog open = new OpenFileDialog();
			open.ShowDialog();
			openFileTextBox.Text = open.FileName;
			
		}
	}
}