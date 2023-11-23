namespace Challenge.Common.Exceptions.Helpers
{
    public interface ILog
    {
        void Information(string message);
        void Warning(string message);
        void Debug(string message);
        void Debug(string message, Exception e);
        void Error(string message);
        void Error(string message, Exception e);
    }
}
