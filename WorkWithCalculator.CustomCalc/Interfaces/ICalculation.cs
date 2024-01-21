using System.Numerics;

namespace WorkWithCalculator.CustomCalc.Interfaces
{
    public interface ICalculation<T, M>: IResult<T, M> where M : IFunction<T> where T : INumber<T>
    {
        public T Value1 { get; }

        public T Value2 { get; }

    }
}
