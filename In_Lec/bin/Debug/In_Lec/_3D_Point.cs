namespace In_Lec;

internal class _3D_Point
{
	public float X;

	public float Y;

	public float Z;

	public _3D_Point(float xx, float yy, float zz)
	{
		X = xx;
		Y = yy;
		Z = zz;
	}

	public _3D_Point(_3D_Point p)
	{
		X = p.X;
		Y = p.Y;
		Z = p.Z;
	}
}
