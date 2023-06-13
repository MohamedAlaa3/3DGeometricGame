using System;
using System.Collections.Generic;

namespace In_Lec;

internal class Transformation
{
	public static void Scale(List<_3D_Point> L_Pts, float sx, float sy, float sz)
	{
		for (int i = 0; i < L_Pts.Count; i++)
		{
			L_Pts[i].X *= sx;
			L_Pts[i].Y *= sy;
			L_Pts[i].Z *= sz;
		}
	}

	public static void RotatX(List<_3D_Point> L_Pts, float theta)
	{
		float th = (float)(Math.PI * (double)theta / 180.0);
		for (int i = 0; i < L_Pts.Count; i++)
		{
			_3D_Point p2 = L_Pts[i];
			float x_ = p2.X;
			float y_ = (float)((double)p2.Y * Math.Cos(th) - (double)p2.Z * Math.Sin(th));
			float z_ = (float)((double)p2.Y * Math.Sin(th) + (double)p2.Z * Math.Cos(th));
			p2.X = x_;
			p2.Y = y_;
			p2.Z = z_;
		}
	}

	public static void RotatY(List<_3D_Point> L_Pts, float theta)
	{
		float th = (float)(Math.PI * (double)theta / 180.0);
		for (int i = 0; i < L_Pts.Count; i++)
		{
			_3D_Point p2 = L_Pts[i];
			float x_ = (float)((double)p2.Z * Math.Sin(th) + (double)p2.X * Math.Cos(th));
			float y_ = p2.Y;
			float z_ = (float)((double)p2.Z * Math.Cos(th) - (double)p2.X * Math.Sin(th));
			p2.X = x_;
			p2.Y = y_;
			p2.Z = z_;
		}
	}

	public static void RotatZ(List<_3D_Point> L_Pts, float theta)
	{
		float th = (float)(Math.PI * (double)theta / 180.0);
		for (int i = 0; i < L_Pts.Count; i++)
		{
			_3D_Point p2 = L_Pts[i];
			float x_ = (float)((double)p2.X * Math.Cos(th) - (double)p2.Y * Math.Sin(th));
			float y_ = (float)((double)p2.X * Math.Sin(th) + (double)p2.Y * Math.Cos(th));
			float z_ = p2.Z;
			p2.X = x_;
			p2.Y = y_;
			p2.Z = z_;
		}
	}

	public static void TranslateX(List<_3D_Point> L_Pts, float tx)
	{
		for (int i = 0; i < L_Pts.Count; i++)
		{
			_3D_Point p2 = L_Pts[i];
			p2.X += tx;
		}
	}

	public static void TranslateY(List<_3D_Point> L_Pts, float ty)
	{
		for (int i = 0; i < L_Pts.Count; i++)
		{
			_3D_Point p2 = L_Pts[i];
			p2.Y += ty;
		}
	}

	public static void TranslateZ(List<_3D_Point> L_Pts, float tz)
	{
		for (int i = 0; i < L_Pts.Count; i++)
		{
			_3D_Point p2 = L_Pts[i];
			p2.Z += tz;
		}
	}

	public static void Translate(List<_3D_Point> L_Pts, float xr, float yr, float zr)
	{
		for (int i = 0; i < L_Pts.Count; i++)
		{
			L_Pts[i].X += xr;
			L_Pts[i].Y += yr;
			L_Pts[i].X += zr;
		}
	}

	public static void RotateArbitrary(List<_3D_Point> L_Pts, _3D_Point v1, _3D_Point v2, float ang)
	{
		TranslateX(L_Pts, v1.X * -1f);
		TranslateY(L_Pts, v1.Y * -1f);
		TranslateZ(L_Pts, v1.Z * -1f);
		float dx = v2.X - v1.X;
		float dy = v2.Y - v1.Y;
		float dz = v2.Z - v1.Z;
		float theta = (float)Math.Atan2(dy, dx);
		float phi = (float)Math.Atan2(Math.Sqrt(dx * dx + dy * dy), dz);
		theta = (float)((double)(theta * 180f) / Math.PI);
		phi = (float)((double)(phi * 180f) / Math.PI);
		RotatZ(L_Pts, theta * -1f);
		RotatY(L_Pts, phi * -1f);
		RotatZ(L_Pts, ang);
		RotatY(L_Pts, phi * 1f);
		RotatZ(L_Pts, theta * 1f);
		TranslateZ(L_Pts, v1.Z * 1f);
		TranslateY(L_Pts, v1.Y * 1f);
		TranslateX(L_Pts, v1.X * 1f);
	}

	public static void RotateArbitrary2(List<_3D_Point> L_Pts, _3D_Point v1, _3D_Point v2, float ang)
	{
		TranslateX(L_Pts, v1.X * -1f);
		TranslateY(L_Pts, v1.Y * -1f);
		TranslateZ(L_Pts, v1.Z * -1f);
		float dx = v2.X - v1.X;
		float dy = v2.Y - v1.Y;
		float dz = v2.Z - v1.Z;
		float theta = (float)Math.Atan2(dy, dx);
		float phi = (float)Math.Atan2(Math.Sqrt(dx * dx + dy * dy), dz);
		theta = (float)((double)(theta * 180f) / Math.PI);
		phi = (float)((double)(phi * 180f) / Math.PI);
		RotatZ(L_Pts, theta * -1f);
		RotatY(L_Pts, phi * -1f);
		RotatZ(L_Pts, ang);
		RotatY(L_Pts, phi * 1f);
		RotatZ(L_Pts, theta * 1f);
		TranslateZ(L_Pts, v1.Z * 1f);
		TranslateY(L_Pts, v1.Y * 1f);
		TranslateX(L_Pts, v1.X * 1f);
	}
}
