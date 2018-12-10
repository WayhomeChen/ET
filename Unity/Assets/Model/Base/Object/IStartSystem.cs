using System;

namespace ETModel
{
	/// <summary>
	/// 启动系统接口
	/// </summary>
	public interface IStartSystem
	{
		/// <summary>
		/// <returns>返回: 被启动的组件的类型</returns>
		/// </summary>
		Type Type();

		/// <summary>
		/// 启动调用入口
		/// <para>
		/// <param name="o">o: 被启动的组件实例</param>
		/// </para>
		/// </summary>
		void Run(object o);
	}

	/// <summary>
	/// 启动系统类
	/// <para>
	/// <typeparam name="T">T: 被启动的组件类型</typeparam>
	/// </para>
	/// </summary>
	public abstract class StartSystem<T> : IStartSystem
	{
		public void Run(object o)
		{
			this.Start((T)o);
		}

		/// <summary>
		/// <returns>返回: 被启动的组件的类型</returns>
		/// </summary>
		public Type Type()
		{
			return typeof(T);
		}

		/// <summary>
		/// 启动调用入口
		/// <para>
		/// <param name="self">self: 被启动的组件实例</param>
		/// </para>
		/// </summary>
		public abstract void Start(T self);
	}
}
