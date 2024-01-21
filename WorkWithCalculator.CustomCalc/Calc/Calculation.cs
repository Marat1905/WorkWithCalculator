using System.Numerics;
using WorkWithCalculator.CustomCalc.Interfaces;
using WorkWithCalculator.CustomLogger.Interfaces;

namespace WorkWithCalculator.CustomCalc.Calc
{
    public class Calculation<T,M> : ICalculation<T, M> where M : IFunction<T> where T : INumber<T>
    {
        private readonly Ilogger? _logger;
        #region Конструктор

        public Calculation( T value1,T value2,Ilogger? logger=null) 
        {
            Value1 = value1;
            Value2 = value2;
            _logger = logger;
        }
        #endregion
        public T Value1 { get; }

        public T Value2 { get; }


        public T Result(M result)
        {
            T res = result.Result(Value1, Value2); ;
            _logger?.Event($"Ответ: {res}");
            return res;
        }






        //T IAddition<T>.Result() => Value1 + Value2;

        //T ISubtraction<T>.Result() => Value1 - Value2;
    }
}
