using In_Lec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Lec
{
    class Transform
    {
        public Transform()
        {
        }
        public static void Scale(_3D_Model a, float sx, float sy, float sz)
        {
            for (int i = 0; i < a.L_3D_Pts.Count; i++)
            {
                a.L_3D_Pts[i].X *= sx;
                a.L_3D_Pts[i].Y *= sy;
                a.L_3D_Pts[i].Z *= sz;

            }
        }
        public static void Translate(_3D_Model a, float xr, float yr, float zr)
        {
            for (int i = 0; i < a.L_3D_Pts.Count; i++)
            {
                a.L_3D_Pts[i].X += xr;
                a.L_3D_Pts[i].Y += yr;
                a.L_3D_Pts[i].Z += zr;

            }
        }
        public static void Rotatex(_3D_Model a, double theta)
        {
            //theta = (float)(theta * Math.PI / 180.0);
            for (int i = 0; i < a.L_3D_Pts.Count; i++)
            {
                double y1 = ((a.L_3D_Pts[i].Y) * Math.Cos(theta));
                double z1 = ((a.L_3D_Pts[i].Z) * Math.Sin(theta));

                double z2 = ((a.L_3D_Pts[i].Z) * Math.Cos(theta));
                double y2 = ((a.L_3D_Pts[i].Y) * Math.Sin(theta));
                a.L_3D_Pts[i].Y = (float)(y1 - z1);
                a.L_3D_Pts[i].Z = (float)(y2 + z2);
            }
        }
        public static void Rotatey(_3D_Model a, double theta)
        {
            //theta = (float)(theta * Math.PI / 180.0);
            for (int i = 0; i < a.L_3D_Pts.Count; i++)
            {
                double z1 = ((a.L_3D_Pts[i].Z) * Math.Cos(theta));
                double x1 = ((a.L_3D_Pts[i].X) * Math.Sin(theta));

                double x2 = ((a.L_3D_Pts[i].X) * Math.Cos(theta));
                double z2 = ((a.L_3D_Pts[i].Z) * Math.Sin(theta));
                a.L_3D_Pts[i].Z = (float)(z1 - x1);
                a.L_3D_Pts[i].X = (float)(x2 + z2);
            }
        }
        public static void Rotatez(_3D_Model a, double theta)
        {
            //theta = (float)(theta * Math.PI / 180.0);

            for (int i = 0; i < a.L_3D_Pts.Count; i++)
            {
                double x1 = ((a.L_3D_Pts[i].X) * Math.Cos(theta));
                double y1 = ((a.L_3D_Pts[i].Y) * Math.Sin(theta));

                double y2 = ((a.L_3D_Pts[i].Y) * Math.Cos(theta));
                double x2 = ((a.L_3D_Pts[i].X) * Math.Sin(theta));
                a.L_3D_Pts[i].X = (float)(x1 - y1);
                a.L_3D_Pts[i].Y = (float)(x2 + y2);
            }
        }
        public static void Rotateall(_3D_Model a, _3D_Point p1, _3D_Point p2, int sign)
        {
            double oldx = p1.X;
            double oldy = p1.Y;
            double oldz = p1.Z;
            Translate(a, (float)-(p1.X), (float)-(p1.Y), (float)-(p1.Z));

            double v1 = p1.X - p2.X;
            double v2 = p1.Y - p2.Y;
            double v3 = p1.Z - p2.Z;
            double theta = Math.Atan2(v2, v1);
            //theta = (float)(theta * Math.PI / 180.0);
            double sq = Math.Sqrt((v2 * v2) + (v1 * v1));
            double phi = Math.Atan2(sq, v3);
            //phi = (float)(phi * Math.PI / 180.0);
            Rotatez(a, -theta);
            Rotatey(a, -phi);
            Rotatez(a, (sign * 0.1));
            Rotatey(a, phi);
            Rotatez(a, theta);
            Translate(a, (float)oldx, (float)oldy, (float)oldz);
        }
    }
}
