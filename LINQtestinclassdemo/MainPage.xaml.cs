using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LINQtestinclassdemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //tax class instance
        Tax tax;
        //set tagText default 13 for the  HST which is selected on start
        string tagText = "0.13";
        string inputValue = string.Empty;
        public MainPage()
        {
            this.InitializeComponent();
            //initialize an object of Tax class 
            tax = new Tax();
        }

      

        private void TaxRaterb_Click(object sender, RoutedEventArgs e)
        {
            //Radiobutton Click Handler for ALL 3 RadioButtons

            if (((RadioButton)sender).IsChecked == true)
            {
                //get the radiobutton tag to tagText and call the function
                RadioButton rb = (RadioButton)sender;
                 this.tagText = rb.Tag.ToString();
                Debug.WriteLine(tax.sentValue);
                DoCalculation(tax.sentValue, tagText);
 
            }
        }
        
        private void textBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            string tempinput = Input.Text;
            DoCalculation(tempinput,tagText);
        }


        private void inputGotfocus(object sender, RoutedEventArgs e)
        {
            //when The input TB got focus 
          Input.Text = string.Empty;
        }

        private void DoCalculation(string inputvalue,string percentage) {
           
            tax.Calculate(inputvalue, percentage);

            TaxAmount.Text = tax.taxAmount;
            TotalAmount.Text = tax.totalAmount;
        }


        private void inputLostFocus(object sender, RoutedEventArgs e)
        {
            Input.Text = tax.purchasePrice;
            
        }
    }
}
