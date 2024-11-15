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
        decimal firstValue = 0m;
        decimal resultValue = 0m;
        string operationPerformed = "";
        bool isOperationPerformed = false;
        

        public Form1()
        {
            InitializeComponent();
        }
//------Zahl oder . wird geklickt
        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; //castet das sender-Objekt(Button, der geklickt wurde) zu einem Button
                                            //->wir haben Zugriff auf die Eigenscheaften des Buttons
            if (button.Text == "ce")
            {
                inputTextBox.Text = "";
                firstValue = 0m;
                operationPerformed = "";
                isOperationPerformed = false;
            } 
            else
            {
                if (isOperationPerformed)
                {
                    //wenn Operation ausgewählt wurde
                    inputTextBox.Text = "";
                    isOperationPerformed = false;
                }
                //keine doppelten Dezimalpunkte hinzufügen
                if (button.Text == "." && inputTextBox.Text.Contains("."))
                {
                    return;
                }

                if (inputTextBox.Text == "0")
                {
                    inputTextBox.Text = button.Text;
                }
                else
                {
                    inputTextBox.Text += button.Text;
                }
            }           
        }  
  
//------Rechenoperator wird geklickt
        private void operand_Click(object sender, EventArgs e) 
        {
            Button button = (Button)sender;

            firstValue = decimal.Parse(inputTextBox.Text);
            operationPerformed = button.Text;
            isOperationPerformed |= true;            
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
                default:
                    return;
            }

            inputTextBox.Text = resultValue.ToString();
            firstValue = resultValue;
            operationPerformed = "";
        }


    }
}
