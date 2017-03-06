using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQtestinclassdemo
{
    class Tax
    {
        public string purchasePrice;
        public string taxAmount;
        public string totalAmount;
        public string sentValue;
        public Tax()
        {
            purchasePrice = string.Empty;
            taxAmount = string.Empty;
            totalAmount = string.Empty;
        }

        public void Calculate(string price, string salesTax) {
            double numericPrice = 0.0;
            double numericTax = 0.0;
            double numericTotal = 0.0;
            double NumericTotalTax = 0.0;

            bool success = false;

            success = double.TryParse(price, out numericPrice);
            if (success)
            {
                success = double.TryParse(salesTax, out numericTax);
                if (success)
                {
                    NumericTotalTax = numericPrice * numericTax;
                    numericTotal = NumericTotalTax + numericPrice;
                    //set amount in currency format
                    sentValue = numericPrice.ToString();
                    purchasePrice = numericPrice.ToString("c");
                    taxAmount = NumericTotalTax.ToString("c");
                    totalAmount = numericTotal.ToString("c");
                }
            }

       }

    }
    
}
