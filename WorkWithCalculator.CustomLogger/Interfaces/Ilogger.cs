namespace WorkWithCalculator.CustomLogger.Interfaces
{
    /// <summary>Интерфейс логгера </summary>
    public interface Ilogger
    {
        /// <summary>Запись ошибок</summary>
        /// <param name="message">Текст</param>
        void Event(string message);

        /// <summary>Запись ошибок</summary>
        /// <param name="message">Текст</param>
        void Error(string message);
    }
}
