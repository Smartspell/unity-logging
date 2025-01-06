#nullable enable

namespace Smartspell.Logging
{
    public sealed class LogFilter : ILogFilter
    {
        private readonly LogMask mask;

        public static LogFilter Create(LogMask mask) => new(mask);
        public static LogFilter ErrorLevel() => new(LogMask.Error);
        public static LogFilter WarningLevel() => new(LogMask.Warning | LogMask.Error);
        public static LogFilter All() => new(LogMask.All);

        private LogFilter(LogMask mask)
        {
            this.mask = mask;
        }

        public bool InfoEnabled() => mask.Contains(LogMask.Info);
        public bool WarningEnabled() => mask.Contains(LogMask.Warning);
        public bool ErrorEnabled() => mask.Contains(LogMask.Error);
    }
}