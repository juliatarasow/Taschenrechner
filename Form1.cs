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
            Button button = sender as Button;

            if (button == null) return;

            if (button.Text == "ce")
            {
                inputTextBox.Text = "0";
                firstValue = 0m;
                resultValue = 0m;
                operationPerformed = "";
                isOperationPerformed = false;
            }

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

            if (inputTextBox.Text == "0" && button.Text != ".")
            {
                inputTextBox.Text = button.Text;
            }
            else
            {
                inputTextBox.Text += button.Text;
            }
        }

//------Rechenoperator wird geklickt
        private void operand_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button == null) return;

            decimal secondValue;

            // es wird versucht die Eingabe in eine Zahl umzuwandeln und Fehler wird mit Fehlermeldung abgefangen
            try
            {
                secondValue = decimal.Parse(inputTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Ungültige Eingabe", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            operationPerformed = button.Text;
            isOperationPerformed = true;
        }

//------Gleich-Taste wird geklickt
        private void equals_Click(object sender, EventArgs e)
        {
            decimal secondValue;

            try
            {
                secondValue = decimal.Parse(inputTextBox.Text);
            }
            catch 
            {
                MessageBox.Show("Ungültige Eingabe", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
               
           

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
                    if (secondValue == 0)
                    {
                        MessageBox.Show("Division durch 0 ist nicht erlaubt!", "Fehler");
                        return;
                    }
                    resultValue = firstValue / secondValue;
                    break;
                default:
                    return;
            }

            inputTextBox.Text = resultValue.ToString();
            firstValue = resultValue;
            operationPerformed = "";
            isOperationPerformed = false;
        }
    }
}
