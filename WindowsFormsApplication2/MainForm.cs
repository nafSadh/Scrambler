using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScramblerWindowsForm {
	public partial class MainForm : Form {
		Scrambler.Scrambler newScr = new Scrambler.Scrambler();
		public MainForm() {
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e) {
			MessageBox.Show(newScr.MainString(binaryTextBox.Text, Scrambler.DecodeType.Binary));
		}

		private void button3_Click(object sender, EventArgs e) {
			MessageBox.Show(newScr.MainString(textBox3.Text, Scrambler.DecodeType.UnScramble));
		}

		private void button1_Click(object sender, EventArgs e) {
			binaryTextBox.Text = newScr.BinaryString(sourceTextBox.Text);
			textBox3.Text = newScr.ScrambledString(binaryTextBox.Text);
		}

		private void button4_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void button5_Click(object sender, EventArgs e) {
			OpenFileDialog open = new OpenFileDialog();
			open.ShowDialog();
			sourceTextBox.Text = open.FileName;
		}
	}
}
