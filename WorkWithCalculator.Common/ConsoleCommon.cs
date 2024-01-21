using System.Numerics;
using WorkWithCalculator.CustomCalc.Calc;
using WorkWithCalculator.CustomCalc.Enums;
using WorkWithCalculator.CustomCalc.Interfaces;
using WorkWithCalculator.CustomLogger.Interfaces;

namespace WorkWithCalculator.Common
{
    public static class ConsoleCommon
    {
        /// <summary>Выбор арифметического действия</summary>
        /// <typeparam name="T">Обобщение</typeparam>
        /// <param name="predicate">Метод для валидации</param>
        /// <param name="text">Текст для представления</param>
        /// <param name="message">Текст при ошибке</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
       public static IFunction<T> SelectedFunction<T>(Func<string?, IFormatProvider, bool> predicate, string text, Ilogger _logger=null, string message = "Неизвестная функция") where T : INumber<T>
        {
            T result = default;
            do
            {
                try
                {
                    Console.Write(text);
                    string? input = Console.ReadLine();
                    if (IsValid(input, message, predicate))
                    {
                        if (Enum.TryParse(input, true, out Functions parsedEnumValue))
                        {
                            switch (parsedEnumValue)
                            {
                                case Functions.sub:
                                    _logger?.Event($"Выбрано вычитание");
                                    return new Subtraction<T>();
                                case Functions.add:
                                    _logger?.Event($"Выбрано сложение");
                                    return new Addition<T>();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (_logger == null)
                        Console.WriteLine(ex.Message);
                    else
                        _logger.Error($"Ошибка: {ex.Message}");
                }
            }
            while (result != null);

            throw new NotImplementedException();
        }


        /// <summary>Получение значения с консоли</summary>
        /// <typeparam name="T">Обобщение</typeparam>
        /// <param name="text">Текст для представления</param>
        /// <returns></returns>
        public static T GetConsoleRead<T>(Func<string?, IFormatProvider, bool> predicate, string text = "Введите число:", Ilogger _logger = null, string message = "Введенное значение должно быть числом", IFormatProvider? formatter = default) where T : INumber<T>
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
                        _logger?.Event($"Ввели число: {result}");
                        break;
                    }
                }
                catch (Exception ex)
                {

                    if (_logger == null)
                        Console.WriteLine(ex.Message);
                    else
                        _logger.Error($"Ошибка: {ex.Message}");
                }
            }
            while (result != null);

            return result;
        }

        /// <summary>Метод для валидации числа</summary>
        /// <param name="digit">Текст который надо проверить что оно является числом</param>
        /// <returns></returns>
        public static bool ValidDigit<T>(string? digit, IFormatProvider formatter = default) where T : INumber<T>
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
        public static bool ValidSelectedFunction(string? input, IFormatProvider formatter = default)
        {
            if (Enum.TryParse(input, true, out Functions parsedEnumValue))
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
        private static bool IsValid(string? input, string message, Func<string?, IFormatProvider?, bool> predicate, IFormatProvider? formatter = default)
        {
            return predicate(input, formatter) != true ? throw new ArgumentException(message) : true;
        }
    }
}
