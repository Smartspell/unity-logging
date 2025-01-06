namespace Smartspell.Logging
{
    public interface ILogFilter
    {
        bool InfoEnabled();

        bool WarningEnabled();

        bool ErrorEnabled();
    }
}
