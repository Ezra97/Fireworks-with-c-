using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace KatyPerry
{
   public class missile : Firework_element
    {
       List<Point> Trail;
       public missile(float px,float py,float pdirectionx,float pdirectiony):base(px,py,pdirectionx,pdirectiony)
       {
           Trail = new List<Point>();
       }
       public override void Tick()
       {
           base.Tick();
           DirectionY += 0.01f;
           Trail.Add(new Point((int)x, (int)y));
       }
       public override void Draw(Graphics pdraw)
       {
           if (life <= 0)
               return;
           int TrailLength=25;
           for (int count=0, i = Math.Max(1,Trail.Count-TrailLength); i < Trail.Count; i++,count++)
           {
               var myPen = new Pen(Color.FromArgb((int)(200*count/(float)TrailLength),Color.White),(int)(7*count/(float)TrailLength));
               pdraw.DrawLine(myPen,Trail[i],Trail[i-1]);
           }
       }
    }
}
