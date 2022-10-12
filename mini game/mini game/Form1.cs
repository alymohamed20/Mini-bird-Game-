using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mini_game
{
    public class bird
    {
        public int X, Y, ihit = -1, W, H;
        public Bitmap img;

    }
    public class wood
    {
        public int X, Y, ihit = -1, W, H;
        public Bitmap img;

    }
    public partial class Form1 : Form
    {
        List<bird> Lb = new List<bird>();
        List<wood> Lw = new List<wood>();
        List<wood> Lw2 = new List<wood>();
        Bitmap off;
        Timer tt = new Timer();
        Bitmap b;
        int YS = 0;
        int XS = 0;
        int cttick = 0;
        int fu = 0;
        int ct = 0;
        int ay = 0;
        int ax = 300;
        int ay2 = 0;
        int ax2 = 300;
        int fhit = 1;
        int ctre = 0;
        int fw = 0;
        int j = 0;
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            Paint += Form1_Paint;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            tt.Tick += Tt_Tick;
            tt.Start();

        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            
                XS += 5;
            YS += 5;
                Lb[0].X ++;
            if(isreach()==1)
            {
                ctre++;
            }
            movewood();
            movewood2();
            
          
            if (fu==0)
            {
                Lb[0].Y+=cttick;
                ct--;
            }
            if(Lb[0].X>=this.Width*3)
            {
                fw = 1;

            }
            if(fw==1)
            {
                tt.Stop();
                MessageBox.Show("you win");
            }
            if(ishit()==fhit)
            {
                tt.Stop();
                MessageBox.Show("game over");
                MessageBox.Show("your score is : " + ctre);

            }
            

            cttick++;
            DrawDubb(this.CreateGraphics());
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up)
            {
                fu = 0;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Up)
            {
                Lb[0].Y-=ct;
                fu = 1;
                cttick = 15;
                ct+=2;
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }
        void createbackground()
        {

            b = new Bitmap("0.bmp");
            b.MakeTransparent(b.GetPixel(0, 0));


        }
        void createbird()
        {
            bird pnn = new bird();
            pnn.X = 40;
            pnn.Y = 100;
            pnn.img = new Bitmap("1.bmp");
            pnn.img.MakeTransparent(pnn.img.GetPixel(1, 1));
            pnn.W = 60;
            pnn.H = 60;
            Lb.Add(pnn);

        }
        List<int> check = new List<int>();
        void createwood()
        {
            for (int i = 0; i < 50; i++)
            {
                wood pnn = new wood();
                pnn.X = ax;
           
                Random RR3 = new Random();
                ay = RR3.Next(200, this.Height - 60);
                pnn.Y = ay;
                for (int j = 150; j < check.Count; j++)
                {
                 

 

                    if (ay == check[j])
                    {
                        ay = RR3.Next(150, this.Height - 60);
                        j = 150;
                    }

                }
                pnn.img = new Bitmap("7.bmp");
                pnn.img.MakeTransparent(pnn.img.GetPixel(1, 1));
                pnn.W = 60;
                pnn.H = ay + this.Height-70;
                Lw.Add(pnn);
                ax += 200;
            }
        }
        List<int> check2 = new List<int>();
        void createwood2()
        {
            for (int i = 0; i < 50; i++)
            {
                wood pnn = new wood();
                pnn.X = ax2;
                Random RR2 = new Random();
                pnn.Y = ay2;
                pnn.img = new Bitmap("8.bmp");
                pnn.img.MakeTransparent(pnn.img.GetPixel(1, 1));
                pnn.W = 60;
                pnn.H = RR2.Next(50, Lw[i].Y-40);
                for (int j = 100; j < check2.Count; j++)
                {




                    if (ay2 == check2[j])
                    {
                        ay2 = RR2.Next(100, Lw[i].Y-40);
                        j = 100;
                    }

                }
                Lw2.Add(pnn);
                ax2 += 200;
            }
        }
        int ishit()
        {
           
            for (int i = 0; i < Lw2.Count; i++)
            {
                if (Lb[0].X+Lb[0].W-25 >= Lw2[i].X && Lb[0].X+10  <= Lw2[i].X + Lw2[i].W-10
                      && Lb[0].Y >= Lw2[i].Y && Lb[0].Y+20 <= Lw2[i].Y + Lw2[i].H)
                {

                    return 1;

                }

            }
            for (int i = 0; i < Lw.Count; i++)
            {
                if (Lb[0].X + Lb[0].W - 25 >= Lw[i].X && Lb[0].X + 10 <= Lw[i].X + Lw[i].W - 10
                       && Lb[0].Y + Lb[0].H-20 >= Lw[i].Y )
                {

                    return 1;

                }

            }
            return 0;
        }
        int isreach()
        {
            for (j = 0; j < Lw2.Count; j++)
            {
                if (Lb[0].X >= Lw2[j].X && Lb[0].X + Lb[0].W - 5 <= Lw2[j].X + Lw2[j].W
                      && Lb[0].Y > Lw2[j].Y + Lw2[j].H && Lb[0].Y + Lb[0].H < Lw[j].Y)
                {

                    return 1;


                }

            }

            return 0;
        }
        void movewood()
        {
            for(int i=0;i<Lw.Count;i++)
            {
                Lw[i].X-=4;

            }
        }
        void movewood2()
        {
            for (int i = 0; i < Lw2.Count; i++)
            {
                Lw2[i].X -= 4;

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
            createbackground();
            createbird();
            createwood();
            createwood2();
      

        }
        void DrawScene(Graphics g)
        {
            g.Clear(Color.Green);
            g.DrawImage(b, new Rectangle(0, 0, this.Width*3 , this.Height), new Rectangle(XS, YS, b.Width, b.Height), GraphicsUnit.Pixel);
     
            for (int i = 0; i < Lw.Count; i++)
            {
                g.DrawImage(Lw[i].img, Lw[i].X, Lw[i].Y, Lw[i].W, Lw[i].H);
            }
            for (int i = 0; i < Lw2.Count; i++)
            {
                g.DrawImage(Lw2[i].img, Lw2[i].X, Lw2[i].Y, Lw2[i].W, Lw2[i].H);
            }
            g.DrawImage(Lb[0].img, Lb[0].X, Lb[0].Y, Lb[0].W, Lb[0].H);
            String S = "" + ctre;
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            g.DrawString(S, drawFont, Brushes.Red, 10, 10);
        }

        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }





    }
}
