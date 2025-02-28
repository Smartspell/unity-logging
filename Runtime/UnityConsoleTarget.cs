﻿#nullable enable

#if UNITY_5_3_OR_NEWER
namespace Smartspell.Logging
{
	public sealed class UnityConsoleTarget : ILogTarget
	{
		public void Info(object o) => UnityEngine.Debug.Log(o);

		public void Warning(object o) => UnityEngine.Debug.LogWarning(o);

		public void Error(object o) => UnityEngine.Debug.LogError(o);
	}
}
#endif
