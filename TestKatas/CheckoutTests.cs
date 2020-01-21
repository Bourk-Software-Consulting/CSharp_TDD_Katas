using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;
using NUnit.Framework;

namespace nCheckoutTests
{
    public class CheckoutTests
    {
        [TestCase(50,"A")]
        [TestCase(100, "AA")]
        [TestCase(80, "BA")]
        public void testACosts50(int expected, string skus)
        {
            Basket basket = new Basket();
            foreach (var sku in skus)
            {
                basket.add(sku);
            }
            int total = basket.checkout();
            Assert.AreEqual(expected,total);
        }
    }

    class Basket
    {
        private List<char> skus = new List<char>();
        public int checkout()
        {
            int total = 0;
            foreach (var sku in skus)
            {
                if (sku == 'A')
                    total += 50;
                if (sku == 'B')
                    total += 30;
                if (sku == 'C')
                    total += 20;
            }

            return total;
        }

        public void add(char c)
        {
            skus.Add(c);
        }
    }
    
}
