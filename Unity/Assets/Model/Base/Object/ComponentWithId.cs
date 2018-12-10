using System;
using MongoDB.Bson.Serialization.Attributes;

namespace ETModel
{
	/// <summary>
	/// 具有数据记录ID的ET组件类
	/// </summary>
	[BsonIgnoreExtraElements]
	public abstract class ComponentWithId : Component
	{
		[BsonIgnoreIfDefault]
		[BsonDefaultValue(0L)]
		[BsonElement]
		[BsonId]
		public long Id { get; set; }

		/// <summary>
		/// 创建数据记录ID为默认值（0）的ET组件
		/// </summary>
		protected ComponentWithId()
		{
		}

		/// <summary>
		/// 创建数据记录ID为指定ID的ET组件
		/// <para>
		/// <param name="id">id: 数据记录ID</param>
		/// </para>
		/// </summary>
		protected ComponentWithId(long id)
		{
			this.Id = id;
		}

		/// <summary>
		/// 销毁组件（个人觉得可以删除不需要重载）
		/// </summary>
		public override void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}

			base.Dispose();
		}
	}
}