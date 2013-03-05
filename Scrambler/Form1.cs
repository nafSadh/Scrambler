using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scrambler {
	public partial class Form1 : Form {
		bool inputAnyText = false;
		public Form1() {
			InitializeComponent();
			inputText.Focus();
		}

		private void scrambleBtn_Click(object sender, EventArgs e) {
			Scrambler.AllUp = allUpperCase.Checked;
			Scrambler.TrimSpace = trimSpace.Checked;
			Scrambler.InsertSpace = insertSpace.Checked;
			scrmbledText.Text = Scrambler.scrableTheText(inputText.Text);
		}

		private void AllUpperCase_CheckedChanged(object sender, EventArgs e) {
			AllLowerCase.Enabled = !(allUpperCase.Checked);
		}

		private void AllLowerCase_CheckedChanged(object sender, EventArgs e) {
			allUpperCase.Enabled = !(AllLowerCase.Checked);
		}

		private void inputText_Click(object sender, EventArgs e) {
			if (inputAnyText == false) {
				inputText.Text = "";
				inputAnyText = true;
			}
		}
	}
}