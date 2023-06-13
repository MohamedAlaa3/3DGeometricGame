using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace In_Lec
{
    class p
    {
        public int X, Y;
        public p(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    public partial class Form1 : Form
    {
        Bitmap off;

        _3D_Model Cube = new _3D_Model(), pnn;
        _3D_Model Cube2 = new _3D_Model();
        List<_3D_Model> map = new List<_3D_Model>();
        Timer timer = new Timer();



        Camera cam = new Camera();
        List<p> points = new List<p>();
        List<p> points2 = new List<p>();
        int CTup = 0, CTleft = 0, CTright = 0;
        int ct = 0;
        bool up=true,R,L,gameover;
        int up1 = 0, up2 = 0;
        int mycube = -1;

        List<int>   holes= new List<int>();
        


        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.Load += new EventHandler(Form1_Load);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            timer.Start();
            timer.Tick += Timer_Tick;
            timer.Interval = 40;







        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ct++;
            if (holes.Contains(mycube))
            {
                Transformation.TranslateZ(Cube2.L_3D_Pts, 1);
                gameover = true;
            }
            else
            {
                if (up)
                {

                    moveUP();
                    CTup++;

                }

                if (CTup == 9)
                {
                    CTup = 0;
                    mycube += 8;
                    if (!R&&!L)
                    {
                        up = true;
                    }
                    else
                    {
                        up= false;
                        //MessageBox.Show("s");

                    }
                    if (!L&&!R)
                    {
                        up = true;
                    }
                    else
                    {
                        up = false;
                    }


                }

                //if (R&&!up)
                //{
                //    if ((mycube + 1) % 8 != 0)
                //    {

                //        moveRight();
                //        CTright++;
                //    }
                //    else
                //    {
                //        R = false;
                //        up= true;
                //    }

                //}

                //if (CTright == 9)
                //{
                //    CTright = 0;
                //    mycube++;
                //    R = false;
                //    up = true;
                //}

                if (L&&!up)
                {
                    if (mycube % 8 != 0)
                    {

                        moveLeft();
                        CTleft++;
                    }
                    else
                    {
                        L = false;
                        up = true;
                    }

                }

                if (CTleft == 9)
                {
                    CTleft = 0;
                    mycube--;
                    L = false;
                    up= true;
                }
                if (R && !up)
                {
                    if ((mycube + 1) % 8 != 0)
                    {

                        moveRight();
                        CTright++;
                    }
                    else
                    {
                        R= false;
                        up = true;
                    }

                }

                if (CTright == 9)
                {
                    CTright = 0;
                    mycube++;
                    R = false;
                    up = true;
                }
            }
            





            DrawDubble(this.CreateGraphics());

        }


        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.X:
                    Transformation.RotatX(Cube.L_3D_Pts, 1);
                    break;
                case Keys.Y:
                    Transformation.RotatY(Cube.L_3D_Pts, 1);
                    break;
                case Keys.Z:
                    Transformation.RotatZ(Cube.L_3D_Pts, 1);
                    break;

                case Keys.Right:
                    cam.cop.X += 10;
                    break;
                case Keys.Left:
                    cam.cop.X -= 10;
                    break;

                case Keys.F:
                    cam.cop.Y += 10;
                    break;
                case Keys.G:
                    cam.cop.Y -= 10;
                    break;

                case Keys.Up:
                    cam.cop.Z += 10;
                    break;
                case Keys.Down:
                    cam.cop.Z -= 10;
                    break;

                case Keys.Space:


                    break;
                case Keys.W:
                    if(!R&&!L&&mycube+8<map.Count())
                        up = true;



                    break;


                case Keys.A:
                    if (!R)
                        L = true;


                    break;

                case Keys.D:
                    if (!L)
                    {
                        R = true;
                        //MessageBox.Show("s");
                    }

                    break;






                case Keys.P:
                    rot(0, 1, -1);

                    break;

                case Keys.Q:
                    rot(1, 2, 1);

                    break;

                case Keys.E:
                    rot(3, 4, 1);

                    break;

                case Keys.R:
                    rot(4, 5, -1);

                    break;


                case Keys.T:
                    rot2(10,1);

                    break;
            }

        }

        private void moveUP()
        {
            if (mycube + 8 < map.Count )
            {

                if (CTup < 9)
                {
                    rot2(10,0);

                }
                
                cam.cop.Y += 5;



            }
            else
            {
                gameover=true;  
            }
        }
        private void moveRight()
        {
            if ((mycube + 1)%8!=0)
            {


                if (CTright < 9)
                {
                    rot2(10,1);

                }
            }
        }
        private void moveLeft()
        {
            if (mycube - 1 < map.Count)
            {

                if (CTleft < 9)
                {
                    rot2(-10, 2);

                }
            }
        }


        private void rot(int i, int j, int x)
        {
            _3D_Point point1 = new _3D_Point(
                (Cube2.L_3D_Pts[0].X + Cube2.L_3D_Pts[7].X) / 2,
                (Cube2.L_3D_Pts[0].Y + Cube2.L_3D_Pts[7].Y) / 2,
                ((Cube2.L_3D_Pts[0].Z + Cube2.L_3D_Pts[7].Z) / 2));
            _3D_Point point2 = new _3D_Point(
               (Cube2.L_3D_Pts[1].X + Cube2.L_3D_Pts[6].X) / 2,
               (Cube2.L_3D_Pts[1].Y + Cube2.L_3D_Pts[6].Y) / 2,
               ((Cube2.L_3D_Pts[1].Z + Cube2.L_3D_Pts[6].Z) / 2));
            //point1.X = Cube2.L_3D_Pts[i].X;
            //point1.Y = Cube2.L_3D_Pts[i].Y;
            //point1.Z = Cube2.L_3D_Pts[i].Z;
            //point2.X = Cube2.L_3D_Pts[j].X;
            //point2.Y = Cube2.L_3D_Pts[j].Y;
            //point2.Z = Cube2.L_3D_Pts[j].Z;
            point1 = Cube2.L_3D_Pts[i];





            Transformation.RotateArbitrary(Cube2.L_3D_Pts, new _3D_Point(Cube2.L_3D_Pts[i]), new _3D_Point(Cube2.L_3D_Pts[j]), 1);







        }
        private void rot2(int x,int f)
        {
            if (!gameover)
            {
                if (f == 0)
                {
                    Transformation.RotateArbitrary(Cube2.L_3D_Pts, new _3D_Point(map[mycube].L_3D_Pts[4]), new _3D_Point(map[mycube].L_3D_Pts[5]), x);

                }
                if (f == 1)
                {
                    Transformation.RotateArbitrary(Cube2.L_3D_Pts, new _3D_Point(map[mycube].L_3D_Pts[5]), new _3D_Point(map[mycube].L_3D_Pts[6]), x);

                }
                if (f == 2)
                {
                    Transformation.RotateArbitrary(Cube2.L_3D_Pts, new _3D_Point(map[mycube].L_3D_Pts[4]), new _3D_Point(map[mycube].L_3D_Pts[7]), x);

                }
            }
        }


        private void move()
        {
            //for (int i = 0; i < points.Count; i++)
            //{
            //    points[i].Y+=5;
            //}
            //for (int i = 0; i < points2.Count; i++)
            //{
            //    points2[i].Y+=5;
            //}
            //for (int i = 0; i < Cube.L_3D_Pts.Count(); i++)
            //{
            //    Cube.L_3D_Pts[i].Y += 1f;
            //}
        }

        void CreateCube(_3D_Model M, float XS, float YS, float ZS, Color vvv)
        {
            float[] vert =
                            {
                                    -100,100,-100,
                                    100,100,-100,
                                    100,-100,-100,
                                    -100,-100,-100,
                                    -100,100,100,
                                    100,100,100,
                                    100,-100,100,
                                    -100,-100,100,

                            };
            for (int i = 0; i < vert.Count(); i++)
            {
                //if (vert[i]==-100)
                //    vert[i] = 0;
            }

            _3D_Point pnn;
            int j = 0;
            for (int i = 0; i < 8; i++)
            {
                pnn = new _3D_Point(vert[j] + XS, vert[j + 1] + YS, vert[j + 2] + ZS);
                j += 3;
                M.AddPoint(pnn);
            }


            int[] Edges = {
                                0,1,
                                1,2,
                                2,3,
                                3,0,
                                4,5,
                                5,6,
                                6,7,
                                7,4,
                                0,4,
                                3,7,
                                2,6,
                                1,5
                          };
            j = 0;
            Color[] cl = { Color.Red, Color.Green, Color.Yellow, Color.Blue };
            for (int i = 0; i < 12; i++)
            {
                M.AddEdge(Edges[j], Edges[j + 1], vvv);

                j += 2;
            }
        }
        void CreateCube2(_3D_Model M, float XS, float YS, float ZS, Color vvv)
        {
            float[] vert =
                            {
                                    -100,100,-100,
                                    100,100,-100,
                                    100,-100,-100,
                                    -100,-100,-100,
                                    -100,100,100,
                                    100,100,100,
                                    100,-100,100,
                                    -100,-100,100,

                            };
            for (int i = 0; i < vert.Count(); i++)
            {
                //if (vert[i]==-100)
                //    vert[i] = 0;
            }

            _3D_Point pnn;
            int j = 0;
            for (int i = 0; i < 8; i++)
            {
                pnn = new _3D_Point(vert[j] + XS, vert[j + 1] + YS, vert[j + 2] + ZS);
                j += 3;
                M.AddPoint(pnn);
            }


            int[] Edges = {
                                0,1,
                                1,2,
                                2,3,
                                3,0,
                                4,5,
                                5,6,
                                6,7,
                                7,4,
                                0,4,
                                3,7,
                                2,6,
                                1,5
                          };
            j = 8;
            for (int i = 8; i < 12; i++)
            {
                M.AddEdge(Edges[j], Edges[j + 1], vvv);

                j += 2;
            }
        }


        void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);


            int cx = 400;
            int cy = 400;
            cam.ceneterX = (this.ClientSize.Width / 2);
            cam.ceneterY = (this.ClientSize.Height / 2);

            cam.cxScreen = cx;
            cam.cyScreen = cy;
            cam.BuildNewSystem();



            Cube.cam = cam;
            CreateCube(Cube, 0, 0, 0, Color.Red);
            Transformation.Scale(Cube.L_3D_Pts, .25f, .25f, .25f);
            Transformation.Translate(Cube.L_3D_Pts, -7, -35, 0);









            int x = -750, y = -500;

            for (int i = 0; i < 20; i++)
            {
                x = -750;
                for (int j = 0; j < 8; j++)
                {

                    pnn = new _3D_Model();
                    pnn.cam = cam;
                    CreateCube2(pnn, x, y, 0, Color.White);
                    //Transformation.Translate(pnn.L_3D_Pts, x, y, 0);

                    Transformation.Scale(pnn.L_3D_Pts, .25f, .25f, .25f);
                    Random random = new Random();
                    if (i == 0 && j == random.Next(0, 8))
                    {
                        mycube = map.Count();
                        Cube = new _3D_Model();
                        Cube2.cam = cam;
                        CreateCube(Cube2, x, y, 0, Color.Blue);
                        Transformation.Scale(Cube2.L_3D_Pts, .25f, .25f, .25f);
                        //Transformation.RotateArbitrary(Cube2.L_3D_Pts, Cube2.L_3D_Pts[0], Cube2.L_3D_Pts[0], 0);


                    }
                    x += 200;



                    map.Add(pnn);


                }
                y += 200;

            }
            Random random2 = new Random();
            for (int i = 0; i < 10; i++)
            {
                holes.Add(random2.Next(24, map.Count - 1));

            }














            //MessageBox.Show("X" + x + " Y" + y);

            for (int i = 0; i < 50; i++)
            {
                points.Add(new p(x, y));
                y -= 100;
            }


            x = this.ClientSize.Width / 4;
            y = this.ClientSize.Height - 100;
            for (int i = 0; i < 9; i++)
            {
                points2.Add(new p(x, y));
                x += 100;
            }



        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubble(e.Graphics);
        }

        void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);
            //for (int i = 0; i < points.Count; i++)
            //{
            //    g.DrawLine(Pens.White, points[i].X, points[i].Y, points[i].X+800, points[i].Y) ;
            //}
            //for (int i = 0; i < points2.Count; i++)
            //{
            //    g.DrawLine(Pens.White, points2[i].X, points2[i].Y, points2[i].X , -1000);
            //}

            //Cube.DrawYourSelf(g);
            for (int mz = 0; mz < map.Count(); mz++)
            {
                map[mz].DrawYourSelf(g, mz);


            }
            Cube2.DrawYourSelf(g, 0);
            for (int i = 0; i < holes.Count(); i++)
            {
                _3D_Point pi = map[holes[i]].L_3D_Pts[4];

                PointF pi_2D = cam.TransformToOrigin_And_Rotate_And_Project(pi);
                //g.DrawEllipse(Pens.Red, pi_2D.X, pi_2D.Y, 75, 75);
                g.FillEllipse(Brushes.Red, pi_2D.X, pi_2D.Y, 75, 75);
            }


        }

        void DrawDubble(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
    }
}
