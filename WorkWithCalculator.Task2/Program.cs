using System.Globalization;
using WorkWithCalculator.Common;
using WorkWithCalculator.CustomCalc.Calc;
using WorkWithCalculator.CustomCalc.Interfaces;
using WorkWithCalculator.CustomLogger.Interfaces;
using WorkWithCalculator.CustomLogger.Loggers;

namespace WorkWithCalculator.Task2
{
    internal class Program
    {
        static Ilogger logger { get; set; }
        static void Main(string[] args)
        {
            logger = new ConsoleLogger();

            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };

            int number1 = ConsoleCommon.GetConsoleRead<int>(ConsoleCommon.ValidDigit<int>, "Введите первое число:", logger);
            int number2 = ConsoleCommon.GetConsoleRead<int>(ConsoleCommon.ValidDigit<int>, "Введите второе число:", logger);

            IFunction<int> add = new Addition<int>();
            IFunction<int> sub = new Subtraction<int>();
            var calculation = new Calculation<int, IFunction<int>>(number1, number2,logger);

            string text = "Выберите арифметическое действие \n 1. - Сложение \n 2. - Вычитание\n";

            var result1 = calculation.Result(ConsoleCommon.SelectedFunction<int>(ConsoleCommon.ValidSelectedFunction, text, logger));
        }
    }
}