namespace ETModel
{
	/// <summary>
	/// ID产生器
	/// </summary>
	public static class IdGenerater
	{
		public static long AppId { private get; set; }

		private static ushort value;

		/// <summary>
		/// 产生ID
		/// <para>
		/// <returns>返回: 产生的ID，字节格式：{7~6: AppId, 7~4: 当前时间（秒，可能会进位到AppId）, 3~0: 递增编号}</returns>
		/// </para>
		/// </summary>
		public static long GenerateId()
		{
			long time = TimeHelper.ClientNowSeconds();

			return (AppId << 48) + (time << 16) + ++value;
		}

		/// <summary>
		/// 从指定ID获取应用ID，应用ID——指定ID的高位两个字节
		/// <para>
		/// <param name="id">id: 指定ID</param>
		/// <returns>返回: 应用ID</returns>
		/// </para>
		/// </summary>
		public static int GetAppIdFromId(long id)
		{
			return (int)(id >> 48);
		}
	}
}