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
		private string OUTPUT = "output.txt";
		private Scrambler scr = new Scrambler();
		public MainForm() {
			InitializeComponent();
			sourceFileTextBox.Enabled = false;
			stopWatchLabel.Text = "00:00:00.000000";
		}

		private void button3_Click(object sender, EventArgs e) {
			string sourceText = File.ReadAllText(@OUTPUT, Encoding.Default);
			StopWatchOneTime.Start();	
			string text = scr.MainString(sourceText, DecodeType.UnScramble);
			StopWatchOneTime.Stop();
			stopWatchLabel.Text = StopWatchOneTime.Result.ToString();
			MessageBox.Show(text);
			File.WriteAllText(@"outputUnScrambled.txt", text);
		}

		private void button1_Click(object sender, EventArgs e) {
			string text = File.ReadAllText(sourceFileTextBox.Text, Encoding.Default);
			StopWatchOneTime.Start();
			logFileTextBox.Text = scr.ScrambledString(text);
			StopWatchOneTime.Stop();
			stopWatchLabel.Text = (StopWatchOneTime.Result).ToString();
			File.WriteAllText(@OUTPUT, logFileTextBox.Text);
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