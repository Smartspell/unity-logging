﻿#nullable enable

namespace Smartspell.Logging
{
    public interface ILogTarget
    {
        void Info(object o);

        void Warning(object o);

        void Error(object o);
    }
}
