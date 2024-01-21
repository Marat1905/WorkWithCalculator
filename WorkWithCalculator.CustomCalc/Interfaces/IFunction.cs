using System.Numerics;

namespace WorkWithCalculator.CustomCalc.Interfaces
{
    /// <summary>Интерфейс арифметических функций</summary>
    /// <typeparam name="T">Обобщение</typeparam>
    public interface IFunction<T> where T : INumber<T>
    {
        /// <summary>Метод для вычисления </summary>
        /// <param name="value1">параметр 1</param>
        /// <param name="value2">параметр 2</param>
        /// <returns>Возврат результата</returns>
        T Result(T value1,T value2);
    }
}
