using System;

namespace ETModel
{
	/// <summary>
	/// 唤醒系统接口
	/// </summary>
	public interface IAwakeSystem
	{
		/// <summary>
		/// <returns>返回: 被唤醒对象的类型</returns>
		/// </summary>
		Type Type();
	}

	/// <summary>
	/// 唤醒接口（无传参）
	/// </summary>
	public interface IAwake
	{
		/// <summary>
		/// 被唤醒后的回调
		/// <para>
		/// <param name="o">o: 被唤醒的对象</param>
		/// </para>
		/// </summary>
		void Run(object o);
	}

	/// <summary>
	/// 唤醒接口（传1参）
	/// <para>
	/// <typeparam name="A">A: 参数1的类型</typeparam>
	/// </para>
	/// </summary>
	public interface IAwake<A>
	{
		/// <summary>
		/// 被唤醒后的回调
		/// <para>
		/// <param name="o">o: 被唤醒的对象</param>,
		/// <param name="a">a: 参数1</param>
		/// </para>
		/// </summary>
		void Run(object o, A a);
	}

	/// <summary>
	/// 唤醒接口（传2参）
	/// <para>
	/// <typeparam name="A">A: 参数1的类型</typeparam>,
	/// <typeparam name="B">B: 参数2的类型</typeparam>
	/// </para>
	/// </summary>
	public interface IAwake<A, B>
	{
		/// <summary>
		/// 被唤醒后的回调
		/// <para>
		/// <param name="o">o: 被唤醒的对象</param>,
		/// <param name="a">a: 参数1</param>,
		/// <param name="b">b: 参数2</param>
		/// </para>
		/// </summary>
		void Run(object o, A a, B b);
	}

	/// <summary>
	/// 唤醒接口（传3参）
	/// <para>
	/// <typeparam name="A">A: 参数1的类型</typeparam>,
	/// <typeparam name="B">B: 参数2的类型</typeparam>,
	/// <typeparam name="C">C: 参数3的类型</typeparam>
	/// </para>
	/// </summary>
	public interface IAwake<A, B, C>
	{
		/// <summary>
		/// 被唤醒后的回调
		/// <para>
		/// <param name="o">o: 被唤醒的对象</param>,
		/// <param name="a">a: 参数1</param>,
		/// <param name="b">b: 参数2</param>,
		/// <param name="c">c: 参数3</param>
		/// </para>
		/// </summary>
		void Run(object o, A a, B b, C c);
	}

	/// <summary>
	/// 唤醒系统类（无传参）
	/// <para>
	/// <typeparam name="T">T: 被唤醒对象的类型</typeparam>
	/// </para>
	/// </summary>
	public abstract class AwakeSystem<T> : IAwakeSystem, IAwake
	{
		/// <summary>
		/// <returns>返回: 被唤醒对象的类型</returns>
		/// </summary>
		public Type Type()
		{
			return typeof(T);
		}

		public void Run(object o)
		{
			this.Awake((T)o);
		}

		/// <summary>
		/// 对象被唤醒后的回调
		/// <para>
		/// <param name="self">self: 被唤醒的对象</param>
		/// </para>
		/// </summary>
		public abstract void Awake(T self);
	}

	/// <summary>
	/// 唤醒系统类（传1参）
	/// <para>
	/// <typeparam name="T">T: 被唤醒对象的类型</typeparam>,
	/// <typeparam name="A">A: 参数1的类型</typeparam>
	/// </para>
	/// </summary>
	public abstract class AwakeSystem<T, A> : IAwakeSystem, IAwake<A>
	{
		/// <summary>
		/// <returns>返回: 被唤醒对象的类型</returns>
		/// </summary>
		public Type Type()
		{
			return typeof(T);
		}

		public void Run(object o, A a)
		{
			this.Awake((T)o, a);
		}

		/// <summary>
		/// 对象被唤醒后的回调
		/// <para>
		/// <param name="self">self: 被唤醒的对象</param>,
		/// <param name="a">a: 参数1</param>
		/// </para>
		/// </summary>
		public abstract void Awake(T self, A a);
	}

	/// <summary>
	/// 唤醒系统类（传2参）
	/// <para>
	/// <typeparam name="T">T: 被唤醒对象的类型</typeparam>,
	/// <typeparam name="A">A: 参数1的类型</typeparam>,
	/// <typeparam name="B">B: 参数2的类型</typeparam>
	/// </para>
	/// </summary>
	public abstract class AwakeSystem<T, A, B> : IAwakeSystem, IAwake<A, B>
	{
		/// <summary>
		/// <returns>返回: 被唤醒对象的类型</returns>
		/// </summary>
		public Type Type()
		{
			return typeof(T);
		}

		public void Run(object o, A a, B b)
		{
			this.Awake((T)o, a, b);
		}

		/// <summary>
		/// 对象被唤醒后的回调
		/// <para>
		/// <param name="self">self: 被唤醒的对象</param>,
		/// <param name="a">a: 参数1</param>,
		/// <param name="b">b: 参数2</param>
		/// </para>
		/// </summary>
		public abstract void Awake(T self, A a, B b);
	}

	/// <summary>
	/// 唤醒系统类（传3参）
	/// <para>
	/// <typeparam name="T">T: 被唤醒对象的类型</typeparam>,
	/// <typeparam name="A">A: 参数1的类型</typeparam>,
	/// <typeparam name="B">B: 参数2的类型</typeparam>,
	/// <typeparam name="C">C: 参数3的类型</typeparam>
	/// </para>
	/// </summary>
	public abstract class AwakeSystem<T, A, B, C> : IAwakeSystem, IAwake<A, B, C>
	{
		/// <summary>
		/// <returns>返回: 被唤醒对象的类型</returns>
		/// </summary>
		public Type Type()
		{
			return typeof(T);
		}

		public void Run(object o, A a, B b, C c)
		{
			this.Awake((T)o, a, b, c);
		}

		/// <summary>
		/// 对象被唤醒后的回调
		/// <para>
		/// <param name="self">self: 被唤醒的对象</param>,
		/// <param name="a">a: 参数1</param>,
		/// <param name="b">b: 参数2</param>,
		/// <param name="c">c: 参数3</param>
		/// </para>
		/// </summary>
		public abstract void Awake(T self, A a, B b, C c);
	}
}
