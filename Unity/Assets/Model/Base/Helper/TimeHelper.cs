using System;

namespace ETModel
{
	/// <summary>
	/// 时间工具类
	/// </summary>
	public static class TimeHelper
	{
		/// <summary> UTC时间的起点 </summary>
		private static readonly long epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;

		/// <summary>
		/// 获取客户端时间
		/// <para>
		/// <returns>返回: 客户端时间（单位：毫秒）</returns>
		/// </para>
		/// </summary>
		public static long ClientNow()
		{
			return (DateTime.UtcNow.Ticks - epoch) / 10000;
		}

		/// <summary>
		/// 获取客户端时间
		/// <para>
		/// <returns>返回: 客户端时间（单位：秒）</returns>
		/// </para>
		/// </summary>
		public static long ClientNowSeconds()
		{
			return (DateTime.UtcNow.Ticks - epoch) / 10000000;
		}

		/// <summary>
		/// 获取当前时间
		/// <para>
		/// <returns>返回: 登录前是客户端时间,登录后是同步过的服务器时间</returns>
		/// </para>
		/// </summary>
		public static long Now()
		{
			return ClientNow();
		}
	}
}