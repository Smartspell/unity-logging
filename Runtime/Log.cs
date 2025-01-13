#nullable enable

namespace Smartspell.Logging
{
	public sealed class Log : ILogFilter
	{
		private readonly ILogTarget target;
		private readonly ILogFilter filter;

		public Log(ILogTarget target, ILogFilter filter)
        {
         	this.target = target;
         	this.filter = filter;
        }

		public bool InfoEnabled()
		{
#if (RELEASE && !UNITY_EDITOR) || DISABLE_INFO_LOG
			return false;
#else
			return filter.InfoEnabled();
#endif
		}

		public bool WarningEnabled()
		{
#if DISABLE_WARNING_LOG
			return false;
#else
			return filter.WarningEnabled();
#endif
		}

		public bool ErrorEnabled()
		{
#if DISABLE_ERROR_LOG
			return false;
#else
			return filter.ErrorEnabled();
#endif
		}

#if (RELEASE && !UNITY_EDITOR) || DISABLE_INFO_LOG
		[System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
		public void Info(object o)
		{
			if(InfoEnabled())
				target.Info(o);
		}

#if DISABLE_WARNING_LOG
		[System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
		public void Warning(object o)
		{
			if(WarningEnabled())
				target.Warning(o);
		}

#if DISABLE_ERROR_LOG
		[System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
		public void Error(object o)
		{
			if(ErrorEnabled())
				target.Error(o);
		}

        public static Log FromMask(LogMask mask) => new(Factory.DefaultTarget(), LogFilter.Create(mask));
        public static Log Empty() => FromMask(LogMask.Empty);
        public static Log All() => FromMask(LogMask.All);
        public static Log WarningLevel() => FromMask(LogMask.Warning | LogMask.Error);
        public static Log ErrorLevel() => FromMask(LogMask.Error);
	}
}
