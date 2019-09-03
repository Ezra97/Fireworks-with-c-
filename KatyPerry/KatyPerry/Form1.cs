using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KatyPerry
{
    public partial class Form1 : Form
    {
        List<Firework_element> particleSystem;

        public Form1()
        {
            InitializeComponent();
            particleSystem = new List<Firework_element>();
        }

        private void Draw_Scene(object sender, EventArgs e)
        {
            var drawer = this.CreateGraphics();
            //clear the screen with blackness
            int MissileNumber = 0;
            drawer.Clear(Color.Black);
            //go over every particle in system
            //no matter if missile or explosion

            for (int i = 0; i < particleSystem.Count; i++)
            {
                particleSystem[i].Tick();
                particleSystem[i].Draw(drawer);
                //if missile
                if (particleSystem[i] is missile)
                {
                    //and missile ended its life
                    if (particleSystem[i].life == 0)
                    {
                        //create explosion
                        Random rnd = new Random();
                        for (int j = 0; j < 30; j++)
                        {
                            particleSystem.Add(new Firework_particle(particleSystem[i].x, particleSystem[i].y, rnd.Next(-200, 300) / 100.0f, rnd.Next(-200, 300) / 100.0f));
                        }
                    }
                    else 
                    {
                        MissileNumber++;
                    }
                }
            }
            //if theres less than 3 missiles, add more missiles
            Random r = new Random();
            for (; MissileNumber < 3; MissileNumber++)
            {
                particleSystem.Add(new missile(Width/2,Height,r.Next(-200,300)/100.0f,r.Next(-600,-500)/100.0f));
            }

            //remove dead particles
            for (int i = 0; i < particleSystem.Count; i++)
            {
                if (particleSystem[i].life <= 0)
                {
                    particleSystem.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
