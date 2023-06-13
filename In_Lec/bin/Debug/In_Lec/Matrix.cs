using System;

namespace In_Lec;

internal class Matrix
{
	public static void Normalise(_3D_Point v)
	{
		float length = (float)Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
		v.X /= length;
		v.Y /= length;
		v.Z /= length;
	}

	public static _3D_Point CrossProduct(_3D_Point p1, _3D_Point p2)
	{
		_3D_Point p3 = new _3D_Point(0f, 0f, 0f);
		p3.X = p1.Y * p2.Z - p1.Z * p2.Y;
		p3.Y = p1.Z * p2.X - p1.X * p2.Z;
		p3.Z = p1.X * p2.Y - p1.Y * p2.X;
		return p3;
	}
}
