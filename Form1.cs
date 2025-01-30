using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taschenrechner
{
    public partial class Form1 : Form
    {
        decimal firstValue = 0m;
        decimal resultValue = 0m;
        string operationPerformed = "";
        bool isOperationPerformed = false;


        public Form1()
        {
            InitializeComponent();
            inputTextBox.Text = "0";
        }

        //------Zahl oder . wird geklickt
        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button == null) return;

            //Wenn nach einer Operatoin eine neue Zahl eingegeben wird, fangen wir von vorne an 
            if (isOperationPerformed)
            {
                inputTextBox.Text = "0";
                isOperationPerformed = false;
            }

            if (inputTextBox.Text.Contains("."))
            {
                if (button.Text == ".")
                {
                    return;
                }
                else
                {
                    inputTextBox.Text += button.Text;
                }

                isOperationPerformed = false;

            }

            //Wenn die aktuelle Zahl "0" ist, ersetze sie (außer wenn "." eingegeben wird)
            if (inputTextBox.Text == "0")
            {
                inputTextBox.Text = button.Text;
            }
            else
            {
                inputTextBox.Text += button.Text;
            }

            if (button.Text == "ce")
            {
                inputTextBox.Text = "0";
                isOperationPerformed = false;
                firstValue = 0m;
                resultValue = 0m;
                operationPerformed = "";
            }
        }

        //------Rechenoperator wird geklickt
        private void operand_Click(object sender, EventArgs e)
        {
            Button button = (sender as Button);
            if (button == null) return;

            isOperationPerformed = true;
            firstValue = decimal.Parse(inputTextBox.Text);
            operationPerformed = button.Text;
        }

        //------Gleich-Taste wird geklickt
        private void equals_Click(object sender, EventArgs e)
        {
            decimal secondValue = decimal.Parse(inputTextBox.Text);

            switch (operationPerformed)
            {
                case "+":
                    resultValue = firstValue + secondValue;
                    break;
                case "-":
                    resultValue = firstValue - secondValue;
                    break;
                case "*":
                    resultValue = firstValue * secondValue;
                    break;
                case "/":
                    resultValue = firstValue / secondValue;
                    break;
            }

            inputTextBox.Text = resultValue.ToString();
            isOperationPerformed = true;
        }
    }
}
