using System;

namespace ETModel
{
	/// <summary>
	/// 日志类，封装了UnityEngine的Debug类
	/// </summary>
	public static class Log
	{
		/// <summary>
		/// 在U3D的控制台中输出info信息，同Info和Debug
		/// <para>
		/// <param name="msg">msg: 信息</param>
		/// </para>
		/// </summary>
		public static void Trace(string msg)
		{
			UnityEngine.Debug.Log(msg);
		}

		/// <summary>
		/// 在U3D的控制台中输出warning信息
		/// <para>
		/// <param name="msg">msg: 信息</param>
		/// </para>
		/// </summary>
		public static void Warning(string msg)
		{
			UnityEngine.Debug.LogWarning(msg);
		}

		/// <summary>
		/// 在U3D的控制台中输出info信息，同Trace和Debug
		/// <para>
		/// <param name="msg">msg: 信息</param>
		/// </para>
		/// </summary>
		public static void Info(string msg)
		{
			UnityEngine.Debug.Log(msg);
		}

		/// <summary>
		/// 在U3D的控制台中输出异常的信息（error）
		/// <para>
		/// <param name="e">e: 异常</param>
		/// </para>
		/// </summary>
		public static void Error(Exception e)
		{
			UnityEngine.Debug.LogError(e.ToString());
		}

		/// <summary>
		/// 在U3D的控制台中输出error信息
		/// <para>
		/// <param name="msg">msg: 信息</param>
		/// </para>
		/// </summary>
		public static void Error(string msg)
		{
			UnityEngine.Debug.LogError(msg);
		}

		/// <summary>
		/// 在U3D的控制台中输出info信息，同Trace和Info
		/// <para>
		/// <param name="msg">msg: 信息</param>
		/// </para>
		/// </summary>
		public static void Debug(string msg)
		{
			UnityEngine.Debug.Log(msg);
		}

		/// <summary>
		/// 在U3D的控制台中输出info对象的转储信息
		/// <para>
		/// <param name="msg">msg: 要输出的对象</param>
		/// </para>
		/// </summary>
		public static void Msg(object msg)
		{
			Debug(Dumper.DumpAsString(msg));
		}
	}
}