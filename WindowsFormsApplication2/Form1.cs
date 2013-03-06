using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2 {
	public partial class Form1 : Form {
		Scrambler.Scrambler NewScr = new Scrambler.Scrambler();

		public Form1() {
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e) {
			MessageBox.Show(NewScr.MainString(textBox2.Text, 0));
		}

		private void button3_Click(object sender, EventArgs e) {
			MessageBox.Show(NewScr.MainString(textBox3.Text, 1));
		}

		private void button1_Click(object sender, EventArgs e) {
			textBox2.Text = NewScr.BinaryString(textBox1.Text);
			textBox3.Text = NewScr.ScrambledString(textBox1.Text);
		}

		private void button4_Click(object sender, EventArgs e) {
			// Exit the program
			if (Application.MessageLoop) {
				// Use this since we are a WinForms app
				Application.Exit();
			} else {
				// Use this since we are a console app
				Environment.Exit(1);
			}
		}
	}
}
