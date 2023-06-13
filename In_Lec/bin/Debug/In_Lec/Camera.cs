using System.Drawing;

namespace In_Lec;

internal class Camera
{
	public _3D_Point cop;

	public _3D_Point lookAt;

	public _3D_Point up;

	public float focal = 3f;

	public _3D_Point basisa;

	public _3D_Point lookDir;

	public _3D_Point basisc;

	public int ceneterX;

	public int ceneterY;

	public int cxScreen;

	public int cyScreen;

	public Camera()
	{
		cop = new _3D_Point(0f, 0f, -350f);
		lookAt = new _3D_Point(0f, 0f, 50f);
		up = new _3D_Point(0f, 1f, 0f);
	}

	public void BuildNewSystem()
	{
		lookDir = new _3D_Point(0f, 0f, 0f);
		basisa = new _3D_Point(0f, 0f, 0f);
		basisc = new _3D_Point(0f, 0f, 0f);
		lookDir.X = lookAt.X - cop.X;
		lookDir.Y = lookAt.Y - cop.Y;
		lookDir.Z = lookAt.Z - cop.Z;
		Matrix.Normalise(lookDir);
		basisa = Matrix.CrossProduct(up, lookDir);
		Matrix.Normalise(basisa);
		basisc = Matrix.CrossProduct(lookDir, basisa);
		Matrix.Normalise(basisc);
	}

	public void TransformToOrigin_And_Rotate(_3D_Point a, _3D_Point e)
	{
		_3D_Point w = new _3D_Point(a.X, a.Y, a.Z);
		w.X -= cop.X;
		w.Y -= cop.Y;
		w.Z -= cop.Z;
		e.X = w.X * basisa.X + w.Y * basisa.Y + w.Z * basisa.Z;
		e.Y = w.X * basisc.X + w.Y * basisc.Y + w.Z * basisc.Z;
		e.Z = w.X * lookDir.X + w.Y * lookDir.Y + w.Z * lookDir.Z;
	}

	public PointF TransformToOrigin_And_Rotate_And_Project(_3D_Point w1)
	{
		_3D_Point e1 = new _3D_Point(0f, 0f, 0f);
		TransformToOrigin_And_Rotate(w1, e1);
		_3D_Point n1 = new _3D_Point(0f, 0f, 0f);
		n1.X = focal * e1.X / e1.Z;
		n1.Y = focal * e1.Y / e1.Z;
		n1.X = (int)((float)ceneterX + (float)cxScreen * n1.X / 2f);
		n1.Y = (int)((float)ceneterY - (float)cyScreen * n1.Y / 2f);
		return new PointF(n1.X, n1.Y);
	}
}
