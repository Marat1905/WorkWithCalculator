using System.Numerics;

namespace WorkWithCalculator.CustomCalc.Interfaces
{
    public interface IResult<out T,in M> where M: IFunction<T> where T: INumber<T>
    {
        /// <summary>Функция двух чисел</summary>
        /// <returns>Возвращение результата</returns>
        T Result(M result);
    }
}
