using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScramblerNS;
using System.IO;

namespace ScramblerWindowsForm {
	public partial class MainForm : Form {
		Scrambler scr = new Scrambler();
		public MainForm() {
			InitializeComponent();
			sourceFileTextBox.Enabled = false;
			stopWatchLabel.Text = "00:00:00.000000";
		}

		private void button2_Click(object sender, EventArgs e) {
			MessageBox.Show(scr.MainString(binaryTextBox.Text, DecodeType.Binary));
		}

		private void button3_Click(object sender, EventArgs e) {
			MessageBox.Show(scr.MainString(logFileTextBox.Text, DecodeType.UnScramble));
		}

		private void button1_Click(object sender, EventArgs e) {
			string text = File.ReadAllText(sourceFileTextBox.Text, Encoding.Default);
			DateTime begin = DateTime.Now;
			binaryTextBox.Text = scr.BinaryString(text);
			logFileTextBox.Text = scr.ScrambledString(binaryTextBox.Text);
			DateTimeConverter c = new DateTimeConverter();
			DateTime end = DateTime.Now;
			stopWatchLabel.Text = (end - begin).ToString();
			File.WriteAllText(@"output.txt", logFileTextBox.Text);
		}

		private void button4_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void button5_Click(object sender, EventArgs e) {
			OpenFileDialog open = new OpenFileDialog();
			open.ShowDialog();
			sourceFileTextBox.Text = open.FileName;
		}
	}
}