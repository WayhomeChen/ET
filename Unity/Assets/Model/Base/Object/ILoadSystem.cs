using System;

namespace ETModel
{
	/// <summary>
	/// 加载系统接口
	/// </summary>
	public interface ILoadSystem
	{
		/// <summary>
		/// <returns>返回: 被加载的组件的类型</returns>
		/// </summary>
		Type Type();

		/// <summary>
		/// 加载调用入口
		/// <para>
		/// <param name="o">o: 被加载的组件实例</param>
		/// </para>
		/// </summary>
		void Run(object o);
	}

	/// <summary>
	/// 加载系统类
	/// <para>
	/// <typeparam name="T">T: 被加载的组件的类型</typeparam>
	/// </para>
	/// </summary>
	public abstract class LoadSystem<T> : ILoadSystem
	{
		public void Run(object o)
		{
			this.Load((T)o);
		}

		/// <summary>
		/// <returns>返回: 被加载的组件的类型</returns>
		/// </summary>
		public Type Type()
		{
			return typeof(T);
		}

		/// <summary>
		/// 加载调用入口
		/// <para>
		/// <param name="self">self: 被加载的组件实例</param>
		/// </para>
		/// </summary>
		public abstract void Load(T self);
	}
}
