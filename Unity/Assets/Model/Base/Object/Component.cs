using System;
using MongoDB.Bson.Serialization.Attributes;

namespace ETModel
{
	/// <summary>
	/// ET组件类
	/// </summary>
	[BsonIgnoreExtraElements]
	public abstract class Component : Object, IDisposable, IComponentSerialize
	{
		/// <summary>
		/// 实例ID
		/// 只有Game.EventSystem.Add方法中会设置该值，如果new出来的对象不想加入Game.EventSystem中，则需要自己在构造函数中设置
		/// </summary>
		[BsonIgnore]
		public long InstanceId { get; private set; }

		[BsonIgnore]
		private bool isFromPool;

		[BsonIgnore]
		public bool IsFromPool
		{
			get
			{
				return this.isFromPool;
			}
			set
			{
				this.isFromPool = value;

				if (!this.isFromPool)
				{
					return;
				}

				this.InstanceId = IdGenerater.GenerateId();
				Game.EventSystem.Add(this);
			}
		}

		/// <summary>
		/// 是否已销毁
		/// </summary>
		[BsonIgnore]
		public bool IsDisposed
		{
			get
			{
				return this.InstanceId == 0;
			}
		}

		/// <summary> 父组件 </summary>
		[BsonIgnore]
		public Component Parent { get; set; }

		/// <summary>
		/// 获取父组件并当作指定类型
		/// <para>
		/// <typeparam name="T">T: 指定类型</typeparam>,
		/// <returns>返回: 类型为T的父组件</returns>
		/// </para>
		/// </summary>
		public T GetParent<T>() where T : Component
		{
			return this.Parent as T;
		}

		/// <summary>
		/// 组件所挂的实体
		/// </summary>
		[BsonIgnore]
		public Entity Entity
		{
			get
			{
				return this.Parent as Entity;
			}
		}

		protected Component()
		{
			this.InstanceId = IdGenerater.GenerateId();
		}

		/// <summary>
		/// 销毁组件
		/// </summary>
		public virtual void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}

			// 触发Destroy事件
			Game.EventSystem.Destroy(this);

			Game.EventSystem.Remove(this.InstanceId);

			this.InstanceId = 0;

			if (this.IsFromPool)
			{
				Game.ObjectPool.Recycle(this);
			}
		}

		public virtual void BeginSerialize()
		{
		}

		public virtual void EndDeSerialize()
		{
		}
	}
}