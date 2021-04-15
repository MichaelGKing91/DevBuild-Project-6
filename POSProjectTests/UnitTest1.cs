using System;
using Xunit;
using POSProject;

namespace POSProjectTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(2, 2.50, 5)]
        [InlineData(4, 2.50, 10)]
        [InlineData(2, 3.50, 7)]
        [InlineData(6, 5.00, 30)]
        [InlineData(3, 1.50, 4.50)]
        public void CalcSubtotalTests(int quantity, double price, double expected)
        {
            double result = Calcs.CalcSubtotal(quantity, price);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, 2.59, 4.59)]
        [InlineData(4.30, 2.50, 6.80)]
        [InlineData(2, 3.50, 5.50)]
        [InlineData(6, 5.00, 11)]
        [InlineData(3, 1.50, 4.50)]
        public void CalcGrandTotalTests(double totalTax, double subTotal, double expected)
        {
            double result = Calcs.CalcGrandTotal(totalTax, subTotal);
            Assert.Equal(expected, result);

        }

        [Theory]
        [InlineData(20.00, 1.4)]
        [InlineData(23.00, 1.61)]
        [InlineData(54.45, 3.8115)]
        [InlineData(12.12, 0.8484)]
        [InlineData(231.10, 16.177)]
        public void CalcTotalTaxTests(double subTotal, double expected)
        {
            //return subTotal * rate;
            double result = Calcs.CalcTotalTax(subTotal);
            expected = Math.Round(expected, 4);
            result = Math.Round(result, 4);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, 2)]
        [InlineData(4.59, 4.59)]
        [InlineData(7.64, 7.64)]
        [InlineData(19.45, 19.45)]
        [InlineData(1.50, 1.50)]
        public void GetAmountTenderedTests(double amountTendered, double expected)
        {
            double result = Calcs.GetAmountTendered(amountTendered);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(20.00, 2.59, 17.41)]
        [InlineData(5.00, 2.50, 2.50)]
        [InlineData(15, 13.75, 1.25)]
        [InlineData(50, 5.01, 44.99)]
        [InlineData(25, 22.41, 2.59)]
        public void CalcChangeTests(double amountTendered, double grandTotal, double expected)
        {
            double result = Calcs.CalcChange(amountTendered, grandTotal);
            Assert.Equal(expected, result);
        }
    }
}
