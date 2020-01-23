using System;
using System.Linq;
using NUnit.Framework;

namespace Kata_RomanNumeral
{
    class testRomanNumeral
    {
        //Demo Parametrized test using NUnit
        [TestCase("CLV", 155)]
        [TestCase("I", 1)]
        [TestCase("CL", 150)]
        [TestCase("LXX", 70)]
        [TestCase("MCCXXXV", 1235)]
        public void testOneExpectI(string expected, int number)
        {
            Integer one = new Integer(number);
            string romanNumber = one.ToRoman();
            Assert.AreEqual(expected, romanNumber);
        }
    }

    internal class Integer
    {
        private readonly int _i;
        private string[,] ROMAN =
        {
            {"","I", "II", "III", "IV", "V", "VI", "VII", "VIII", "VIII",},
            {"","X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC",},
            {"","C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM",},
            {"","M", "MM", "", "", "", "", "", "", "",}
        };

        public Integer(int i)
        {
            _i = i;
        }

        public string ToRoman()
        {
            string chiffre = _i.ToString();
            int x = 0;
            string number = "";

            foreach (char c in chiffre.Reverse())
            {
                var  cc = (int)Char.GetNumericValue(c);
                number = ROMAN[x, cc] + number;
                x++;
            }

            return number;
        }
    }
}
