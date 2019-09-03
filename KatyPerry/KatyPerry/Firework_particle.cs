using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatyPerry
{
    public class Firework_particle : Firework_element
    {
        private Random rnd;
        Color mycolor;
        public Firework_particle(float px,float py,float pdirectionx,float pdirectiony):base(px,py,pdirectionx,pdirectiony)
        {
            rnd = new Random((int)(px + py + DirectionX + DirectionX) + DateTime.Now.Millisecond);
            mycolor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
        }
        public override void Tick()
        {
            base.Tick();
            DirectionY += 0.08f;
        }
        public override void Draw(Graphics pdraw)
        {
            if (life <= 0)
                return;

            int size = (int)(10.0f * life / max_life_in_ticks);

            pdraw.FillEllipse(new SolidBrush(mycolor), x - size / 2, y - size, size, size);
        }
    }
}
