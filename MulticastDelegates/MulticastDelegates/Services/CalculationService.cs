﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MulticastDelegates.Services
{
    internal class CalculationService
    {
        public static void ShowMax(double x, double y)
        {
            double max = (x > y) ? x : y;
            Console.WriteLine(max);
        }

        public static void showSum(double x, double y)
        {
            double sum = x + y;
            Console.WriteLine(sum);
        }
    }
}
