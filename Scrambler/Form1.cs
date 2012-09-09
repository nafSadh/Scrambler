using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scrambler
{
    public partial class Form1 : Form
    {
        bool inputAnyText = false;
        public Form1()
        {
            InitializeComponent();
            inputText.Focus();
        }

        private void scrambleBtn_Click(object sender, EventArgs e)
        {
            scrmbledText.Text =
                ns7.sadhontoon.Scrambler.scrableTheText(
                inputText.Text,
                AllUpperCase.Checked,
                AllLowerCase.Checked,
                TrimSpace.Checked,
                insertSpace.Checked);
        }

        private void AllUpperCase_CheckedChanged(object sender, EventArgs e)
        {
            AllLowerCase.Enabled = !AllUpperCase.Checked;
        }

        private void AllLowerCase_CheckedChanged(object sender, EventArgs e)
        {
            AllUpperCase.Enabled = !AllLowerCase.Checked;
        }

        private void inputText_Click(object sender, EventArgs e)
        {
            if (!inputAnyText)
            {
                inputText.Text = "";
                inputAnyText = true;
            }
        }
    }
}
