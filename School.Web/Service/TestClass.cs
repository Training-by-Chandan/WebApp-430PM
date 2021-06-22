using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Web.Service
{
    public class TestClass
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public double CalculateTax(double amount)
        {
            var tax= amount * 13/100;
            return amount + tax;
        }
    }
}