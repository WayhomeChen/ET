using System;
using System.ComponentModel;
using LitJson;

namespace ETModel
{
	/// <summary>
	/// JSON工具类，封装了LitJson.JsonMapper
	/// </summary>
	public static class JsonHelper
	{
		/// <summary>
		/// 对象转JSON字符串
		/// <para>
		/// <param name="obj">obj: 要转的对象</param>,
		/// <returns>返回: JSON字符串</returns>
		/// </para>
		/// </summary>
		public static string ToJson(object obj)
		{
			return JsonMapper.ToJson(obj);
		}

		/// <summary>
		/// JSON字符串转对象，并进行初始化
		/// <para>
		/// <typeparam name="T">T: 目标对象类型</typeparam>,
		/// <param name="str">str: 输入的JSON字符串</param>,
		/// <returns>返回: 转换后的T类型对象</returns>
		/// </para>
		/// </summary>
		public static T FromJson<T>(string str)
		{
			T t = JsonMapper.ToObject<T>(str);
			ISupportInitialize iSupportInitialize = t as ISupportInitialize;
			if (iSupportInitialize == null)
			{
				return t;
			}
			iSupportInitialize.EndInit();
			return t;
		}

		/// <summary>
		/// JSON字符串转对象，并进行初始化
		/// <para>
		/// <param name="type">type: 目标对象类型</param>,
		/// <param name="str">str: 输入的JSON字符串</param>,
		/// <returns>返回: 转换后的type类型对象</returns>
		/// </para>
		/// </summary>
		public static object FromJson(Type type, string str)
		{
			object t = JsonMapper.ToObject(type, str);
			ISupportInitialize iSupportInitialize = t as ISupportInitialize;
			if (iSupportInitialize == null)
			{
				return t;
			}
			iSupportInitialize.EndInit();
			return t;
		}

		/// <summary>
		/// 克隆对象，通过JSON与对象的转换进行克隆
		/// <para>
		/// <typeparam name="T">T: 对象类型</typeparam>,
		/// <param name="t">t: 对象</param>,
		/// <returns>返回: 克隆好的对象</returns>
		/// </para>
		/// </summary>
		public static T Clone<T>(T t)
		{
			return FromJson<T>(ToJson(t));
		}
	}
}