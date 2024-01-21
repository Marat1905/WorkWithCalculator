using System.Data.SqlTypes;
using System.Numerics;
using WorkWithCalculator.CustomCalc.Interfaces;

namespace WorkWithCalculator.CustomCalc.Calc
{
    /// <summary><inheritdoc cref="IFunction{T}"/> </summary>
    /// <typeparam name="T"><inheritdoc cref="IFunction{T}"/></typeparam>
    public class Addition<T> : IAddition<T> where T : INumber<T>
    {
        public T Result(T value1, T value2)=>value1+value2;
    }
}
