using System.Globalization;
using System.Numerics;
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

            int number1=GetConsoleRead<int>(ValidDigit<int>, "Введите первое число:");
            int number2 = GetConsoleRead<int>(ValidDigit<int>, "Введите второе число:");

            IFunction<int> add = new Addition<int>();
            IFunction<int> sub = new Subtraction<int>();
            var calculation=new Calculation<int,IFunction<int>>(number1, number2);

            string text = "Выберите арифметическое действие \n 1. - Сложение \n 2. - Вычитание\n";

            var result1 = calculation.Result(SelectedFunction<int>(ValidSelectedFunction, text));
            Console.WriteLine($"Ответ: {result1}");
        }

        /// <summary>Выбор арифметического действия</summary>
        /// <typeparam name="T">Обобщение</typeparam>
        /// <param name="predicate">Метод для валидации</param>
        /// <param name="text">Текст для представления</param>
        /// <param name="message">Текст при ошибке</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        static IFunction<T> SelectedFunction<T>(Func<string?, IFormatProvider, bool> predicate,string text, string message = "Неизвестная функция") where T: INumber<T>
        {
            T result = default;
            do
            {
                try
                {
                    Console.Write(text);
                    string? input = Console.ReadLine();
                    if(IsValid(input,message, predicate))
                    {
                        if (Enum.TryParse(input, true, out Functions parsedEnumValue))
                        {
                            switch (parsedEnumValue)
                            {
                                case Functions.sub:
                                    return new Subtraction<T>();
                                case Functions.add:
                                    return new Addition<T>();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (result != null);

            throw new NotImplementedException();
        }


        /// <summary>Получение значения с консоли</summary>
        /// <typeparam name="T">Обобщение</typeparam>
        /// <param name="text">Текст для представления</param>
        /// <returns></returns>
        static T GetConsoleRead<T>(Func<string?, IFormatProvider, bool> predicate, string text= "Введите число:",string message= "Введенное значение должно быть числом", IFormatProvider? formatter = default) where T: INumber<T>
        {
            T? result = default;
            do
            {
                try
                {
                    Console.Write(text);
                    string? input = Console.ReadLine();
                    if (IsValid(input, message, predicate))
                    {
                        result = T.Parse(input, formatter);
                        break;
                    }                     
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (result!=null);

            return result;
        }

        /// <summary>Метод для валидации числа</summary>
        /// <param name="digit">Текст который надо проверить что оно является числом</param>
        /// <returns></returns>
        private static bool ValidDigit<T>(string? digit, IFormatProvider formatter=default) where T : INumber<T>
        {
            if (T.TryParse(digit, formatter, out T? result))
            {
                return true;
            }
            return false;
        }

        /// <summary>Метод для валидации числа</summary>
        /// <param name="digit">Текст который надо проверить что оно является числом</param>
        /// <returns></returns>
        private static bool ValidSelectedFunction(string? input, IFormatProvider formatter = default) 
        {
            if (Enum.TryParse(input,true, out Functions parsedEnumValue))
            {
                if (Enum.IsDefined(typeof(Functions), parsedEnumValue)) 
                {
                    return true;
                } 
            }
            return false;
        }

        /// <summary>Метод валидации</summary>
        /// <param name="input">Входящий текст</param>
        /// <param name="message">Сообщение при ошибке</param>
        /// <param name="predicate">Делегат для проверки валидации</param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        private static bool IsValid(string? input, string message, Func<string?, IFormatProvider?,bool> predicate, IFormatProvider? formatter = default)
        {
            return predicate(input, formatter) != true ? throw new ArgumentException(message) : true;
        }
    }
}