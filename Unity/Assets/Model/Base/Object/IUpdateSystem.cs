using System;

namespace ETModel
{
	/// <summary>
	/// 更新系统接口
	/// </summary>
	public interface IUpdateSystem
	{
		/// <summary>
		/// <returns>返回: 被更新的组件的类型</returns>
		/// </summary>
		Type Type();

		/// <summary>
		/// 更新调用入口
		/// <para>
		/// <param name="o">o: 被更新的组件实例</param>
		/// </para>
		/// </summary>
		void Run(object o);
	}

	/// <summary>
	/// 更新系统类
	/// <para>
	/// <typeparam name="T">T: 被更新的组件的类型</typeparam>
	/// </para>
	/// </summary>
	public abstract class UpdateSystem<T> : IUpdateSystem
	{
		public void Run(object o)
		{
			this.Update((T)o);
		}

		/// <summary>
		/// <returns>返回: 被更新的组件的类型</returns>
		/// </summary>
		public Type Type()
		{
			return typeof(T);
		}

		/// <summary>
		/// 更新调用入口
		/// <para>
		/// <param name="self">self: 被更新的组件实例</param>
		/// </para>
		/// </summary>
		public abstract void Update(T self);
	}
}
