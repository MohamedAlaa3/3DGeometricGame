using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace In_Lec;

public class Form1 : Form
{
	private Bitmap off;

	private _3D_Model Cube = new _3D_Model();

	private _3D_Model pnn;

	private _3D_Model Cube2 = new _3D_Model();

	private List<_3D_Model> map = new List<_3D_Model>();

	private Camera cam = new Camera();

	private List<p> points = new List<p>();

	private List<p> points2 = new List<p>();

	private int CTup = 0;

	private IContainer components = null;

	public Form1()
	{
		base.WindowState = FormWindowState.Maximized;
		base.Paint += Form1_Paint;
		base.Load += Form1_Load;
		base.KeyDown += Form1_KeyDown;
	}

	private void Form1_KeyDown(object sender, KeyEventArgs e)
	{
		switch (e.KeyCode)
		{
		case Keys.X:
			Transformation.RotatX(Cube.L_3D_Pts, 1f);
			break;
		case Keys.Y:
			Transformation.RotatY(Cube.L_3D_Pts, 1f);
			break;
		case Keys.Z:
			Transformation.RotatZ(Cube.L_3D_Pts, 1f);
			break;
		case Keys.Right:
			cam.cop.X += 10f;
			break;
		case Keys.Left:
			cam.cop.X -= 10f;
			break;
		case Keys.F:
			cam.cop.Y += 10f;
			break;
		case Keys.G:
			cam.cop.Y -= 10f;
			break;
		case Keys.Up:
			cam.cop.Z += 10f;
			break;
		case Keys.Down:
			cam.cop.Z -= 10f;
			break;
		case Keys.Space:
		{
			CTup++;
			PointF pi_2D = cam.TransformToOrigin_And_Rotate_And_Project(Cube2.L_3D_Pts[0]);
			Text = CTup.ToString();
			if (CTup < 16)
			{
				rot(4, 5, -1);
				move();
			}
			else if (CTup < 32)
			{
				rot(0, 1, -1);
				move();
			}
			else if (CTup < 48)
			{
				rot(3, 2, -1);
			}
			else if (CTup < 64)
			{
				rot(7, 6, -1);
			}
			else
			{
				CTup = 0;
			}
			cam.cop.Y += 3f;
			move();
			break;
		}
		case Keys.P:
			rot(0, 1, -1);
			break;
		case Keys.Q:
			rot(1, 2, 1);
			break;
		case Keys.W:
			rot(2, 3, 1);
			break;
		case Keys.E:
			rot(3, 4, 1);
			break;
		case Keys.R:
			rot(4, 5, -1);
			break;
		case Keys.T:
			move();
			break;
		}
		DrawDubble(CreateGraphics());
	}

	private void rot(int i, int j, int x)
	{
		Transform.Rotateall(Cube2, Cube2.L_3D_Pts[i], Cube2.L_3D_Pts[j], x);
	}

	private void move()
	{
	}

	private void CreateCube(_3D_Model M, float XS, float YS, float ZS, Color vvv)
	{
		float[] vert = new float[24]
		{
			-100f, 100f, -100f, 100f, 100f, -100f, 100f, -100f, -100f, -100f,
			-100f, -100f, -100f, 100f, 100f, 100f, 100f, 100f, 100f, -100f,
			100f, -100f, -100f, 100f
		};
		for (int k = 0; k < vert.Count(); k++)
		{
		}
		int l = 0;
		for (int j = 0; j < 8; j++)
		{
			_3D_Point pnn = new _3D_Point(vert[l] + XS, vert[l + 1] + YS, vert[l + 2] + ZS);
			l += 3;
			M.AddPoint(pnn);
		}
		int[] Edges = new int[24]
		{
			0, 1, 1, 2, 2, 3, 3, 0, 4, 5,
			5, 6, 6, 7, 7, 4, 0, 4, 3, 7,
			2, 6, 1, 5
		};
		l = 0;
		Color[] cl = new Color[4]
		{
			Color.Red,
			Color.Green,
			Color.Yellow,
			Color.Blue
		};
		for (int i = 0; i < 12; i++)
		{
			M.AddEdge(Edges[l], Edges[l + 1], cl[i % 4]);
			l += 2;
		}
	}

	private void CreateCube2(_3D_Model M, float XS, float YS, float ZS, Color vvv)
	{
		float[] vert = new float[24]
		{
			-100f, 100f, -100f, 100f, 100f, -100f, 100f, -100f, -100f, -100f,
			-100f, -100f, -100f, 100f, 100f, 100f, 100f, 100f, 100f, -100f,
			100f, -100f, -100f, 100f
		};
		for (int k = 0; k < vert.Count(); k++)
		{
		}
		int l = 0;
		for (int j = 0; j < 8; j++)
		{
			_3D_Point pnn = new _3D_Point(vert[l] + XS, vert[l + 1] + YS, vert[l + 2] + ZS);
			l += 3;
			M.AddPoint(pnn);
		}
		int[] Edges = new int[24]
		{
			0, 1, 1, 2, 2, 3, 3, 0, 4, 5,
			5, 6, 6, 7, 7, 4, 0, 4, 3, 7,
			2, 6, 1, 5
		};
		l = 8;
		for (int i = 8; i < 12; i++)
		{
			M.AddEdge(Edges[l], Edges[l + 1], vvv);
			l += 2;
		}
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		off = new Bitmap(base.ClientSize.Width, base.ClientSize.Height);
		int cx = 400;
		int cy = 400;
		cam.ceneterX = base.ClientSize.Width / 2;
		cam.ceneterY = base.ClientSize.Height / 2;
		cam.cxScreen = cx;
		cam.cyScreen = cy;
		cam.BuildNewSystem();
		Cube.cam = cam;
		CreateCube(Cube, 0f, 0f, 0f, Color.Red);
		Transformation.Scale(Cube.L_3D_Pts, 0.25f, 0.25f, 0.25f);
		Transformation.Translate(Cube.L_3D_Pts, -7f, -35f, 0f);
		int x = -750;
		int y = 8000;
		for (int k = 0; k < 8; k++)
		{
			y = -500;
			for (int l = 0; l < 20; l++)
			{
				pnn = new _3D_Model();
				pnn.cam = cam;
				CreateCube2(pnn, x, y, 0f, Color.White);
				Transformation.Scale(pnn.L_3D_Pts, 0.25f, 0.25f, 0.25f);
				if (k == 3 && l == 0)
				{
					Cube = new _3D_Model();
					Cube2.cam = cam;
					CreateCube(Cube2, x, y, 0f, Color.Red);
					Transformation.Scale(Cube2.L_3D_Pts, 0.25f, 0.25f, 0.25f);
				}
				map.Add(pnn);
				y += 200;
			}
			x += 200;
		}
		for (int j = 0; j < 50; j++)
		{
			points.Add(new p(x, y));
			y -= 100;
		}
		x = base.ClientSize.Width / 4;
		y = base.ClientSize.Height - 100;
		for (int i = 0; i < 9; i++)
		{
			points2.Add(new p(x, y));
			x += 100;
		}
	}

	private void Form1_Paint(object sender, PaintEventArgs e)
	{
		DrawDubble(e.Graphics);
	}

	private void DrawScene(Graphics g)
	{
		g.Clear(Color.Black);
		for (int mz = 0; mz < map.Count(); mz++)
		{
			map[mz].DrawYourSelf(g, 1);
		}
		Cube2.DrawYourSelf(g, 0);
	}

	private void DrawDubble(Graphics g)
	{
		Graphics g2 = Graphics.FromImage(off);
		DrawScene(g2);
		g.DrawImage(off, 0, 0);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		base.SuspendLayout();
		base.AutoScaleDimensions = new System.Drawing.SizeF(12f, 25f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(274, 229);
		base.Name = "Form1";
		this.Text = "Form1";
		base.Load += new System.EventHandler(Form1_Load);
		base.ResumeLayout(false);
	}
}
