using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace KatyPerry
{
   public class Firework_element
    {
       public float x, y, DirectionX, DirectionY;
       protected int mlife;
       public int life 
       {
           get 
           {
               return mlife;
           }
           protected set
           {
               mlife = value;
           }
       }
       protected const int max_life_in_ticks = 75;

       public Firework_element(float px,float py,float pdirectionx,float pdirectiony)
        {
           x = px;
           y = py;
           DirectionX = pdirectionx;
           DirectionY = pdirectiony;
           life = max_life_in_ticks;
        }

       public virtual void Draw(Graphics pdraw)
        {
            if (life < 0)
                return;

            int size = (int)10.0f * life/max_life_in_ticks;
            pdraw.FillEllipse(Brushes.White, x - 5, y - 5, 10, 10);
        }

       public virtual void Tick()
        {
            if (life < 0)
                return;

            x += DirectionX;
            y += DirectionY;
            life--;
        }
    }
}
