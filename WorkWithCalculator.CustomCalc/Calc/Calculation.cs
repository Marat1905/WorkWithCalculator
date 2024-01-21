using System.Numerics;
using WorkWithCalculator.CustomCalc.Interfaces;

namespace WorkWithCalculator.CustomCalc.Calc
{
    public class Calculation<T,M> : ICalculation<T, M> where M : IFunction<T> where T : INumber<T>
    {
        #region Конструктор

        public Calculation( T value1,T value2) 
        {
            Value1 = value1;
            Value2 = value2;
        }
        #endregion
        public T Value1 { get; }

        public T Value2 { get; }


        public T Result(M result)
        {
            return result.Result(Value1, Value2);
        }






        //T IAddition<T>.Result() => Value1 + Value2;

        //T ISubtraction<T>.Result() => Value1 - Value2;
    }
}
