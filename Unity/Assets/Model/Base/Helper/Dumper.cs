using System;
using System.Collections;
using System.Reflection;
using System.Text;
using Google.Protobuf;
using UnityEngine;

namespace ETModel
{
    /// <summary>
	/// 转储类
	/// </summary>
	public static class Dumper
    {
        /// <summary>  </summary>
		private static readonly StringBuilder _text = new StringBuilder("", 1024);

        /// <summary>
		/// _text末尾填充连续空格
		/// <para>
		/// <param name="num">num: 要扩充的空格数</param>
		/// </para>
		/// </summary>
		private static void AppendIndent(int num)
        {
            _text.Append(' ', num);
        }

        /// <summary>
		/// 递归式转储（对象序列化为字符串）
		/// <para>
		/// <param name="obj">obj: 要转储的对象</param>
		/// </para>
		/// </summary>
		private static void DoDump(object obj)
        {
			// 若对象为空，转储格式：『null,』
            if (obj == null)
            {
                _text.Append("null");
                _text.Append(",");
                return;
            }

			// 转储对象类型
            Type t = obj.GetType();

			// repeat field 重复域
			// 若对象实现了IList，转储格式：『[<obj[0]的转储结果/><obj[1]的转储结果/><obj[2]的转储结果/>...]』
			if (obj is IList)
            {
                /*
                _text.Append(t.FullName);
                _text.Append(",");
                AppendIndent(1);
                */

                _text.Append("[");
                IList list = obj as IList;
                foreach (object v in list)
                {
                    DoDump(v);
                }

                _text.Append("]");
            }
			// 若对象是值类型，转储格式：『<obj的值/>, 』
            else if (t.IsValueType)
            {
                _text.Append(obj);
                _text.Append(",");
                AppendIndent(1);
            }
			// 若对象是字符串，转储格式：『"<obj取字符串/>", 』
            else if (obj is string)
            {
                _text.Append("\"");
                _text.Append(obj);
                _text.Append("\"");
                _text.Append(",");
                AppendIndent(1);
            }
			// 若对象是ProtoBuf.ByteStringe，转储格式：『"<obj取字符串/>", 』
			else if (obj is ByteString)
            {
                _text.Append("\"");
                _text.Append(((ByteString) obj).bytes.Utf8ToStr());
                _text.Append("\"");
                _text.Append(",");
                AppendIndent(1);
            }
			// 若对象是数组，转储格式：『[0:<obj[0]的转储结果/>1:<obj[1]的转储结果/>2:<obj[2]的转储结果/>...]』
			else if (t.IsArray)
            {
                Array a = (Array) obj;
                _text.Append("[");
                for (int i = 0; i < a.Length; i++)
                {
                    _text.Append(i);
                    _text.Append(":");
                    DoDump(a.GetValue(i));
                }

                _text.Append("]");
            }
			// 若对象是类，转储格式：『<<obj的类名/>{<obj的public域0名/>:<obj的public域0的转储结果/><obj的public域1名/>:<obj的public域1的转储结果/>...}>』
			else if (t.IsClass)
            {
                _text.Append($"<{t.Name}>");
                _text.Append("{");
                var fields = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                if (fields.Length > 0)
                {
                    foreach (PropertyInfo info in fields)
                    {
                        _text.Append(info.Name);
                        _text.Append(":");
                        object value = info.GetGetMethod().Invoke(obj, null);
                        DoDump(value);
                    }
                }

                _text.Append("}");
            }
			// 若对象的类型不支持转储，转储格式：『<obj取字符串/>, 』
            else
            {
                Debug.LogWarning("unsupport type: " + t.FullName);
                _text.Append(obj);
                _text.Append(",");
                AppendIndent(1);
            }
        }

        /// <summary>
		/// 获取对象的转储结果字符串
		/// <para>
		/// <param name="obj">obj: 要转储的对象</param>
		/// <param name="hint">hint: 转储结果的前缀</param>
		/// <returns>返回: 转储结果字符串</returns>
		/// </para>
		/// </summary>
		public static string DumpAsString(object obj, string hint = "")
        {
            _text.Clear();
            _text.Append(hint);
            DoDump(obj);
            return _text.ToString();
        }
    }
}