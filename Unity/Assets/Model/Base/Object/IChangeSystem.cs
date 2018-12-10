using System;

namespace ETModel
{
	/// <summary>
	/// 变更系统接口
	/// </summary>
	public interface IChangeSystem
	{
		/// <summary>
		/// <returns>返回: 被变更的组件的类型</returns>
		/// </summary>
		Type Type();

		/// <summary>
		/// 变更调用入口
		/// <para>
		/// <param name="o">o: 被变更的组件实例</param>
		/// </para>
		/// </summary>
		void Run(object o);
	}

	/// <summary>
	/// 变更系统类
	/// <para>
	/// <typeparam name="T">T: 被变更的组件的类型</typeparam>
	/// </para>
	/// </summary>
	public abstract class ChangeSystem<T> : IChangeSystem
	{
		public void Run(object o)
		{
			this.Change((T)o);
		}

		/// <summary>
		/// <returns>返回: 被变更的组件的类型</returns>
		/// </summary>
		public Type Type()
		{
			return typeof(T);
		}

		/// <summary>
		/// 变更调用入口
		/// <para>
		/// <param name="self">self: 被变更的组件实例</param>
		/// </para>
		/// </summary>
		public abstract void Change(T self);
	}
}
