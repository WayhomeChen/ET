using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
#if UNITY_EDITOR
using UnityEditor;

#endif

/// <summary>
/// Unity游戏对象引用收集器数据
/// </summary>
[Serializable]
public class ReferenceCollectorData
{
	/// <summary> 主键 </summary>
	public string key;
	/// <summary> Unity游戏对象 </summary>
	public Object gameObject;
}

/// <summary>
/// Unity游戏对象引用收集器比较器
/// </summary>
public class ReferenceCollectorDataComparer: IComparer<ReferenceCollectorData>
{
	public int Compare(ReferenceCollectorData x, ReferenceCollectorData y)
	{
		return string.Compare(x.key, y.key, StringComparison.Ordinal);
	}
}

/// <summary>
/// Unity游戏对象引用收集器
/// </summary>
public class ReferenceCollector: MonoBehaviour, ISerializationCallbackReceiver // 一般地，存在Unity无法自动(反)序列化的字段的MonoBehaviour子类才需要继承ISerializationCallbackReceiver接口
{
	public List<ReferenceCollectorData> data = new List<ReferenceCollectorData>();

	private readonly Dictionary<string, Object> dict = new Dictionary<string, Object>();

#if UNITY_EDITOR
	/// <summary>
	/// 添加引用
	/// <para>
	/// <param name="key">key: 主键</param>,
	/// <param name="obj">obj: Unity游戏对象</param>
	/// </para>
	/// </summary>
	public void Add(string key, Object obj)
	{
		SerializedObject serializedObject = new SerializedObject(this);
		SerializedProperty dataProperty = serializedObject.FindProperty("data");
		int i;
		for (i = 0; i < data.Count; i++)
		{
			if (data[i].key == key)
			{
				break;
			}
		}
		if (i != data.Count)
		{
			SerializedProperty element = dataProperty.GetArrayElementAtIndex(i);
			element.FindPropertyRelative("gameObject").objectReferenceValue = obj;
		}
		else
		{
			dataProperty.InsertArrayElementAtIndex(i);
			SerializedProperty element = dataProperty.GetArrayElementAtIndex(i);
			element.FindPropertyRelative("key").stringValue = key;
			element.FindPropertyRelative("gameObject").objectReferenceValue = obj;
		}
		EditorUtility.SetDirty(this);
		serializedObject.ApplyModifiedProperties();
		serializedObject.UpdateIfRequiredOrScript();
	}

	/// <summary>
	/// 移除引用
	/// <para>
	/// <param name="key">key: 主键</param>
	/// </para>
	/// </summary>
	public void Remove(string key)
	{
		SerializedObject serializedObject = new SerializedObject(this);
		SerializedProperty dataProperty = serializedObject.FindProperty("data");
		int i;
		for (i = 0; i < data.Count; i++)
		{
			if (data[i].key == key)
			{
				break;
			}
		}
		if (i != data.Count)
		{
			dataProperty.DeleteArrayElementAtIndex(i);
		}
		EditorUtility.SetDirty(this);
		serializedObject.ApplyModifiedProperties();
		serializedObject.UpdateIfRequiredOrScript();
	}

	public void Clear()
	{
		SerializedObject serializedObject = new SerializedObject(this);
		var dataProperty = serializedObject.FindProperty("data");
		dataProperty.ClearArray();
		EditorUtility.SetDirty(this);
		serializedObject.ApplyModifiedProperties();
		serializedObject.UpdateIfRequiredOrScript();
	}

	public void Sort()
	{
		SerializedObject serializedObject = new SerializedObject(this);
		data.Sort(new ReferenceCollectorDataComparer());
		EditorUtility.SetDirty(this);
		serializedObject.ApplyModifiedProperties();
		serializedObject.UpdateIfRequiredOrScript();
	}
#endif

	public T Get<T>(string key) where T : class
	{
		Object dictGo;
		if (!dict.TryGetValue(key, out dictGo))
		{
			return null;
		}
		return dictGo as T;
	}

	public Object GetObject(string key)
	{
		Object dictGo;
		if (!dict.TryGetValue(key, out dictGo))
		{
			return null;
		}
		return dictGo;
	}

	public void OnBeforeSerialize()
	{
	}

	public void OnAfterDeserialize()
	{
		dict.Clear();
		foreach (ReferenceCollectorData referenceCollectorData in data)
		{
			if (!dict.ContainsKey(referenceCollectorData.key))
			{
				dict.Add(referenceCollectorData.key, referenceCollectorData.gameObject);
			}
		}
	}
}