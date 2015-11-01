using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private Double equationValue = 0;
        private string operation = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            //To remove the default 0 in the textbox when any number is entered
            if (textBoxResults.Text == "0")
            {
                textBoxResults.Clear();    
            }

            Button button = (Button) sender;
            textBoxResults.Text = textBoxResults.Text +button.Text;
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            equationValue = Double.Parse(textBoxResults.Text);
        }

        private void buttonClearEntry_Click(object sender, EventArgs e)
        {
            //Simply clears screen for cases of typos or other errors without interruption to work in progress
            textBoxResults.Text = "0";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            //clears screen and deletes results. Ends any equations in progress
            textBoxResults.Text = "0";
            equationValue = 0;
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    textBoxResults.Text = (equationValue + Double.Parse(textBoxResults.Text)).ToString();
                    break;
                case "-":
                    textBoxResults.Text = (equationValue - Double.Parse(textBoxResults.Text)).ToString();
                    break;
                case "*":
                    textBoxResults.Text = (equationValue * Double.Parse(textBoxResults.Text)).ToString();
                    break;
                case "/":
                    textBoxResults.Text = (equationValue / Double.Parse(textBoxResults.Text)).ToString();
                    break;
            }
        }
    }
}
