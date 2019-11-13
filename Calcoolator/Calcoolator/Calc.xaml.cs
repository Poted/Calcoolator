using System;
using System.Data;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calcoolator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Calc : ContentPage
	{
        string inputValue;
        Label label = new Label();

        public Calc()
        {
            InitializeComponent();
        }

        private void Button1Clicked(object sender, EventArgs e)
        {

            if (btn1.IsFocused)
                inputValue = "1";

            else if (btn2.IsFocused)
                inputValue = "2";

            else if (btn3.IsFocused)
                inputValue = "3";

            else if (btn4.IsFocused)
                inputValue = "4";

            else if (btn5.IsFocused)
                inputValue = "5";

            else if (btn6.IsFocused)
                inputValue = "6";

            else if (btn7.IsFocused)
                inputValue = "7";

            else if (btn8.IsFocused)
                inputValue = "8";

            else if (btn9.IsFocused)
                inputValue = "9";

            else if (btn0.IsFocused)
                inputValue = "0";

            SaveInput(inputValue);
        }


        private void SaveInput(string inputValue)
        {
            label = lbl;

            if (btnPlus.IsFocused & !lbl.Text.EndsWith("+") & !lbl.Text.EndsWith("-") & !lbl.Text.EndsWith("*") & !lbl.Text.EndsWith("/"))
                lbl.Text = lbl.Text + "+";

            else if (btnMinus.IsFocused & !lbl.Text.EndsWith("+") & !lbl.Text.EndsWith("-") & !lbl.Text.EndsWith("*") & !lbl.Text.EndsWith("/"))
                lbl.Text = lbl.Text + "-";

            else if (btnDivide.IsFocused & !lbl.Text.EndsWith("+") & !lbl.Text.EndsWith("-") & !lbl.Text.EndsWith("*") & !lbl.Text.EndsWith("/"))
                lbl.Text = lbl.Text + "/";

            else if (btnMultiply.IsFocused & !lbl.Text.EndsWith("+") & !lbl.Text.EndsWith("-") & !lbl.Text.EndsWith("*") & !lbl.Text.EndsWith("/"))
                lbl.Text = lbl.Text + "*";


            else if (btnEqual.IsFocused)
            {
                if (btnPlus.IsFocused | btnMinus.IsFocused | btnDivide.IsFocused | btnMultiply.IsFocused)
                    lbl.Text = Calculate(lbl.Text.Remove(lbl.Text.Length - 1));

                else
                    lbl.Text = Calculate(lbl.Text).ToString();
            }

            else
            {
                if(btnPlus.IsFocused | btnMinus.IsFocused | btnDivide.IsFocused | btnMultiply.IsFocused)
                {

                }

                else if (lbl.Text != "0")
                    lbl.Text = lbl.Text + inputValue.ToString();
                else lbl.Text = inputValue.ToString();

                if (btnClear.IsFocused)
                {
                    lbl.Text = "0";
                }
            }
            
        }

        private string Calculate(string inputValue)
        {
            inputValue = lbl.Text;
            string result = new DataTable().Compute(inputValue, null).ToString();
            return result;
        }

        private void Button_Cancel_Clicked(object sender, EventArgs e)
        {
            if (btnCancel.IsFocused && lbl.Text.Length != 0 & lbl.Text != "0")
                lbl.Text = lbl.Text.Remove(lbl.Text.Length - 1);
            else if (lbl.Text?.Length == 0 | lbl.Text == "0")
            {
                lbl.Text = "0";
            }
        }
	}
}