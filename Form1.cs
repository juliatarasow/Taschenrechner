using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taschenrechner
{
    public partial class Form1 : Form
    {
        TextBox _inputTextBox;
        string inputNumber = " ";
        decimal outputNumber = 0m;
        string calc = " ";

        public Form1()
        {
            InitializeComponent();

            inputNumber = inputTextBox.Text;
            if (decimal.TryParse(inputNumber, out outputNumber))
            {
                outputNumber = decimal.Parse(inputNumber);
            }
            else
            {
                MessageBox.Show("Bitte eine gültige Zahl eingeben.", "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void equals_Click(object sender, EventArgs e)
        {
           switch (calc)
            {
                case "/":
                    inputTextBox.Text = (decimal.Parse(inputTextBox.Text) / decimal.Parse(inputTextBox.Text)).ToString();
                    break;
                case "*":

                    break;
                case "-":

                    break;
                case "+":

                    break;
                default:
                    break;
            }

            
        }

        private void seven_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "7";
        }

        private void eight_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "8";
        }

        private void nine_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "9";
        }

        private void four_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "4";
        }

        private void five_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "5";
        }

        private void six_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "6";
        }

        private void one_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "1";
        }

        private void two_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "2";
        }

        private void three_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "3";
        }

        private void zero_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "0";  
        }

        private void dott_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += ".";
        }
                
        private void devide_Click(object sender, EventArgs e)
        {
            calc = "/";
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            calc = "*";
        }

        private void minus_Click(object sender, EventArgs e)
        {
            calc = "-";
        }

        private void plus_Click(object sender, EventArgs e)
        {
            calc = "+";
        }

        private void clear_Click(object sender, EventArgs e)
        {
            inputTextBox.Clear();
        }
    }
}
