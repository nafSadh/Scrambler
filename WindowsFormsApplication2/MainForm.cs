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

		private delegate string ScramblerStringDelegate(string text);
		private ScramblerStringDelegate std;
		private const bool LOG = true;
		private const bool NOLOG = false;

		public MainForm() {
			InitializeComponent();
			sourceFileTextBox.Enabled = false;
			stopWatchLabel.Text = "00:00:00.000000";
			scr.LogMessage += scr_LogMessage;
			scr.ProgressIncrement += scr_ProgressIncrement;
		}

		private void scr_LogMessage(string message) {
			putMessageLabel(logFileTextBox, message + "\r\n", LOG);
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
		}

		private void button1_Click(object sender, EventArgs e) {
			progressBar.Value = 0;
			string text = File.ReadAllText(sourceFileTextBox.Text, Encoding.Default);
			std = new ScramblerStringDelegate(scr.ScrambledString);
			StopWatchOneTime.Start();
			std.BeginInvoke(text, scramblerCallBack, this);
		}

		private void scramblerCallBack(IAsyncResult ia) {
			string resultText = std.EndInvoke(ia);
			StopWatchOneTime.Stop();
			putMessageLabel(stopWatchLabel, StopWatchOneTime.Result.ToString(), NOLOG);
			File.WriteAllText(@OUTPUT, resultText);
		}

		private void putMessageLabel(Control control, string message, bool log) {
			if (control.InvokeRequired) {
				AddTextDelegate controlDelegate = null;
				if (log) {
					controlDelegate = new AddTextDelegate(AddLogTextCallBack);
				} else {
					controlDelegate = new AddTextDelegate(AddTextCallBack);
				}
				control.Invoke(controlDelegate, message, control);
			} else {
				if (log) {
					control.Text += message;
				} else {
					control.Text = message;
				}
			}
		}
		private delegate void AddTextDelegate(string text, Control textBox);
		private void AddTextCallBack(string text, Control textBox) {
			textBox.Text = text;
		}
		private void AddLogTextCallBack(string text, Control textBox) {
			textBox.Text += text;
		}

		private void scr_ProgressIncrement(int progressCount) {
			int value = progressBar.Value + progressCount;
			if (value > 100) {
				value = 100;
			}
			putProgress(progressBar, value);
		}
		private void putProgress(ProgressBar control, int count) {
			if (control.InvokeRequired) {
				AddProgressDelegate controlDelegate = new AddProgressDelegate(AddProgressCallBack);
				control.Invoke(controlDelegate, control, count);
			} else {
				progressBar.Value = count;
			}
		}
		private delegate void AddProgressDelegate(ProgressBar progress, int count);
		private void AddProgressCallBack(ProgressBar progress, int count) {
			progress.Value = count;
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