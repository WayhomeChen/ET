using System;

namespace ETModel
{
	/// <summary>
	/// 延迟更新系统接口
	/// </summary>
	public interface ILateUpdateSystem
	{
		/// <summary>
		/// <returns>返回: 被延迟更新的组件的类型</returns>
		/// </summary>
		Type Type();

		/// <summary>
		/// 延迟更新调用入口
		/// <para>
		/// <param name="o">o: 被延迟更新的组件实例</param>
		/// </para>
		/// </summary>
		void Run(object o);
	}

	/// <summary>
	/// 延迟更新系统类
	/// <para>
	/// <typeparam name="T">T: 被延迟更新的组件的类型</typeparam>
	/// </para>
	/// </summary>
	public abstract class LateUpdateSystem<T> : ILateUpdateSystem
	{
		public void Run(object o)
		{
			this.LateUpdate((T)o);
		}

		/// <summary>
		/// <returns>返回: 被延迟更新的组件的类型</returns>
		/// </summary>
		public Type Type()
		{
			return typeof(T);
		}

		/// <summary>
		/// 延迟更新调用入口
		/// <para>
		/// <param name="self">self: 被延迟更新的组件实例</param>
		/// </para>
		/// </summary>
		public abstract void LateUpdate(T self);
	}
}
