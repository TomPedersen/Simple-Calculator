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
        private bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            //To remove the default 0 in the textbox when any number is entered and to clear field between each entry, e.g. 2 + 2 + 3 doesn't become 223.
            if ((textBoxResults.Text == "0") || isOperationPerformed)
            {
                textBoxResults.Clear();    
            }

            //To prevent multiple consecutive decimals from being entered
            if (button.Text == ".")
            {
                if (!textBoxResults.Text.Contains("."))
                    textBoxResults.Text = textBoxResults.Text + button.Text;
            }
            else
            {
                textBoxResults.Text = textBoxResults.Text + button.Text;
            }

            
            isOperationPerformed = false;
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            equationValue = Double.Parse(textBoxResults.Text);
            labelCurrentOperation.Text = equationValue + " " + operation;
            isOperationPerformed = true;

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
