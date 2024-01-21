using System.Globalization;
using System.Numerics;
using WorkWithCalculator.Common;
using WorkWithCalculator.CustomCalc.Calc;
using WorkWithCalculator.CustomCalc.Enums;
using WorkWithCalculator.CustomCalc.Interfaces;

namespace WorkWithCalculator.Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };

            int number1= ConsoleCommon.GetConsoleRead<int>(ConsoleCommon.ValidDigit<int>, "Введите первое число:");
            int number2 = ConsoleCommon.GetConsoleRead<int>(ConsoleCommon.ValidDigit<int>, "Введите второе число:");

            IFunction<int> add = new Addition<int>();
            IFunction<int> sub = new Subtraction<int>();
            var calculation=new Calculation<int,IFunction<int>>(number1, number2);

            string text = "Выберите арифметическое действие \n 1. - Сложение \n 2. - Вычитание\n";

            var result1 = calculation.Result(ConsoleCommon.SelectedFunction<int>(ConsoleCommon.ValidSelectedFunction, text));
            Console.WriteLine($"Ответ: {result1}");
        }
    }
}