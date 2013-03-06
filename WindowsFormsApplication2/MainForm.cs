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

			scr.LogMessage += scr_LogMessage;
			scr.ProgressIncrement += scr_ProgressIncrement;
		}

		private void scr_ProgressIncrement(int progressCount) {
			int value = progressBar.Value + progressCount;
			if (value > 100) {
				value = 100;
			}
			progressBar.Value = value;
		}

		private void scr_LogMessage(string message) {
			logFileTextBox.Text += message + "\r\n";
		}

		private void button3_Click(object sender, EventArgs e) {
			progressBar.Value = 0;
			string sourceText = File.ReadAllText(@OUTPUT, Encoding.Default);
			StopWatchOneTime.Start();	
			string text = scr.MainString(sourceText, DecodeType.UnScramble);
			StopWatchOneTime.Stop();
			stopWatchLabel.Text = StopWatchOneTime.Result.ToString();
			MessageBox.Show(text);
			File.WriteAllText(@"outputUnScrambled.txt", text);
			MessageBox.Show(progressBar.Value.ToString());
		}

		private void button1_Click(object sender, EventArgs e) {
			string text = File.ReadAllText(sourceFileTextBox.Text, Encoding.Default);
			StopWatchOneTime.Start();
			string scrambler = scr.ScrambledString(text);
			StopWatchOneTime.Stop();
			stopWatchLabel.Text = StopWatchOneTime.Result.ToString();
			File.WriteAllText(@OUTPUT, scrambler);
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