using System;

namespace ETModel
{
	/// <summary>
	/// 销毁系统接口
	/// </summary>
	public interface IDestroySystem
	{
		/// <summary>
		/// <returns>返回: 被销毁的组件的类型</returns>
		/// </summary>
		Type Type();

		/// <summary>
		/// 销毁调用入口
		/// <para>
		/// <param name="o">o: 被销毁的组件实例</param>
		/// </para>
		/// </summary>
		void Run(object o);
	}

	/// <summary>
	/// 销毁系统类
	/// <para>
	/// <typeparam name="T">T: 被销毁的组件的类型</typeparam>
	/// </para>
	/// </summary>
	public abstract class DestroySystem<T> : IDestroySystem
	{
		public void Run(object o)
		{
			this.Destroy((T)o);
		}

		/// <summary>
		/// <returns>返回: 被销毁的组件的类型</returns>
		/// </summary>
		public Type Type()
		{
			return typeof(T);
		}

		/// <summary>
		/// 销毁调用入口
		/// <para>
		/// <param name="self">self: 被销毁的组件实例</param>
		/// </para>
		/// </summary>
		public abstract void Destroy(T self);
	}
}
