using System.Numerics;

namespace WorkWithCalculator.CustomCalc.Interfaces
{
    public interface IAddition<T> : IFunction<T> where T : INumber<T>
    {
    }
}
