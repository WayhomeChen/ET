using System;

/// <summary>
/// 整型分式结构
/// </summary>
[Serializable]
public struct VFactor
{
	/// <summary> 分子 </summary>
	public long nom;

	/// <summary> 分母 </summary>
	public long den;

	/// <summary> 0/1 </summary>
	[NonSerialized]
	public static VFactor zero = new VFactor(0L, 1L);

	/// <summary> 1/1 </summary>
	[NonSerialized]
	public static VFactor one = new VFactor(1L, 1L);

	/// <summary> π=3.1416 </summary>
	[NonSerialized]
	public static VFactor pi = new VFactor(31416L, 10000L);

	/// <summary> 2π=6.2832 </summary>
	[NonSerialized]
	public static VFactor twoPi = new VFactor(62832L, 10000L);

	private static long mask_ = 9223372036854775807L;

	private static long upper_ = 16777215L;

	public int roundInt
	{
		get
		{
			return (int)IntMath.Divide(this.nom, this.den);
		}
	}

	/// <summary> 整型结果 </summary>
	public int integer
	{
		get
		{
			return (int)(this.nom / this.den);
		}
	}

	/// <summary> 单精度浮点型结果 </summary>
	public float single
	{
		get
		{
			double num = (double)this.nom / (double)this.den;
			return (float)num;
		}
	}

	/// <summary> 是正数？, true=正, false=负 </summary>
	public bool IsPositive
	{
		get
		{
/*			DebugHelper.Assert(this.den != 0L, "VFactor: denominator is zero !");*/
			if (this.nom == 0L)
			{
				return false;
			}
			bool flag = this.nom > 0L;
			bool flag2 = this.den > 0L;
			return !(flag ^ flag2);
		}
	}

	/// <summary> 是负数？, true=负, false=正 </summary>
	public bool IsNegative
	{
		get
		{
/*			DebugHelper.Assert(this.den != 0L, "VFactor: denominator is zero !");*/
			if (this.nom == 0L)
			{
				return false;
			}
			bool flag = this.nom > 0L;
			bool flag2 = this.den > 0L;
			return flag ^ flag2;
		}
	}

	/// <summary> 是零？, true=零, false=非零 </summary>
	public bool IsZero
	{
		get
		{
			return this.nom == 0L;
		}
	}

	/// <summary> 取倒数 </summary>
	public VFactor Inverse
	{
		get
		{
			return new VFactor(this.den, this.nom);
		}
	}

	/// <summary>
	/// 创建整型分式<br/>
	/// <para>
	/// <param name="n">n: 分子</param>, 
	/// <param name="d">d: 分母</param>
	/// </para>
	/// </summary>
	public VFactor(long n, long d)
	{
		this.nom = n;
		this.den = d;
	}


	/// <summary>
	/// 判断完全相等, 即非空、同类型、等值。
	/// <para>
	/// <param name="obj">obj: 比较对象</param>
	/// </para>
	/// <returns>返回: true=完全相等, false=不完全等</returns>
	/// </summary>
	public override bool Equals(object obj)
	{
		return obj != null && base.GetType() == obj.GetType() && this == (VFactor)obj;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	/// <summary>
	/// float型结果字符串
	/// </summary>
	/// <returns></returns>
	public override string ToString()
	{
		return this.single.ToString();
	}

	/// <summary>
	/// 不懂？？？
	/// </summary>
	public void strip()
	{
		while ((this.nom & VFactor.mask_) > VFactor.upper_ && (this.den & VFactor.mask_) > VFactor.upper_)
		{
			this.nom >>= 1;
			this.den >>= 1;
		}
	}

	/// <summary> 数学上的小于 </summary>
	public static bool operator <(VFactor a, VFactor b)
	{
		long num = a.nom * b.den;
		long num2 = b.nom * a.den;
		bool flag = b.den > 0L ^ a.den > 0L;
		return (!flag) ? (num < num2) : (num > num2);
	}

	/// <summary> 数学上的大于 </summary>
	public static bool operator >(VFactor a, VFactor b)
	{
		long num = a.nom * b.den;
		long num2 = b.nom * a.den;
		bool flag = b.den > 0L ^ a.den > 0L;
		return (!flag) ? (num > num2) : (num < num2);
	}

	/// <summary> 数学上的小于等于 </summary>
	public static bool operator <=(VFactor a, VFactor b)
	{
		long num = a.nom * b.den;
		long num2 = b.nom * a.den;
		bool flag = b.den > 0L ^ a.den > 0L;
		return (!flag) ? (num <= num2) : (num >= num2);
	}

	/// <summary> 数学上的大于等于 </summary>
	public static bool operator >=(VFactor a, VFactor b)
	{
		long num = a.nom * b.den;
		long num2 = b.nom * a.den;
		bool flag = b.den > 0L ^ a.den > 0L;
		return (!flag) ? (num >= num2) : (num <= num2);
	}

	/// <summary> 数学上的等于（BUG: 0/0==任何数） </summary>
	public static bool operator ==(VFactor a, VFactor b)
	{
		return a.nom * b.den == b.nom * a.den;
	}

	/// <summary> 数学上的不等于（BUG: 0/0==任何数） </summary>
	public static bool operator !=(VFactor a, VFactor b)
	{
		return a.nom * b.den != b.nom * a.den;
	}

	/// <summary> 数学上的小于 </summary>
	public static bool operator <(VFactor a, long b)
	{
		long num = a.nom;
		long num2 = b * a.den;
		return (a.den <= 0L) ? (num > num2) : (num < num2);
	}

	/// <summary> 数学上的大于 </summary>
	public static bool operator >(VFactor a, long b)
	{
		long num = a.nom;
		long num2 = b * a.den;
		return (a.den <= 0L) ? (num < num2) : (num > num2);
	}

	/// <summary> 数学上的小于等于 </summary>
	public static bool operator <=(VFactor a, long b)
	{
		long num = a.nom;
		long num2 = b * a.den;
		return (a.den <= 0L) ? (num >= num2) : (num <= num2);
	}

	/// <summary> 数学上的大于等于 </summary>
	public static bool operator >=(VFactor a, long b)
	{
		long num = a.nom;
		long num2 = b * a.den;
		return (a.den <= 0L) ? (num <= num2) : (num >= num2);
	}

	/// <summary> 数学上的等于（BUG: 0/0==任何数） </summary>
	public static bool operator ==(VFactor a, long b)
	{
		return a.nom == b * a.den;
	}

	/// <summary> 数学上的不等于（BUG: 0/0==任何数） </summary>
	public static bool operator !=(VFactor a, long b)
	{
		return a.nom != b * a.den;
	}

	/// <summary> 数学上的加 </summary>
	public static VFactor operator +(VFactor a, VFactor b)
	{
		return new VFactor
		{
			nom = a.nom * b.den + b.nom * a.den,
			den = a.den * b.den
		};
	}

	/// <summary> 数学上的加 </summary>
	public static VFactor operator +(VFactor a, long b)
	{
		a.nom += b * a.den;
		return a;
	}

	/// <summary> 数学上的减 </summary>
	public static VFactor operator -(VFactor a, VFactor b)
	{
		return new VFactor
		{
			nom = a.nom * b.den - b.nom * a.den,
			den = a.den * b.den
		};
	}

	/// <summary> 数学上的减 </summary>
	public static VFactor operator -(VFactor a, long b)
	{
		a.nom -= b * a.den;
		return a;
	}

	/// <summary> 数学上的乘 </summary>
	public static VFactor operator *(VFactor a, long b)
	{
		a.nom *= b;
		return a;
	}

	/// <summary> 数学上的除 </summary>
	public static VFactor operator /(VFactor a, long b)
	{
		a.den *= b;
		return a;
	}

	public static VInt3 operator *(VInt3 v, VFactor f)
	{
		return IntMath.Divide(v, f.nom, f.den);
	}

	public static VInt2 operator *(VInt2 v, VFactor f)
	{
		return IntMath.Divide(v, f.nom, f.den);
	}

	public static VInt3 operator /(VInt3 v, VFactor f)
	{
		return IntMath.Divide(v, f.den, f.nom);
	}

	public static VInt2 operator /(VInt2 v, VFactor f)
	{
		return IntMath.Divide(v, f.den, f.nom);
	}

	public static int operator *(int i, VFactor f)
	{
		return (int)IntMath.Divide((long)i * f.nom, f.den);
	}

	/// <summary> 取相反数 </summary>
	public static VFactor operator -(VFactor a)
	{
		a.nom = -a.nom;
		return a;
	}
}

