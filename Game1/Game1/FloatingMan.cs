using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class FloatingMan : IComponent
    {
        public int x;
        public int y;
        public int vel;
        public int speed;
        public int Height;
        public int Width;
        public int animloop;
        public int Period;
        
        List<Texture2D> Animation;

        public FloatingMan(int hoog,int breed, List<Texture2D> anim)
        {
            this.animloop = 0;
            this.Animation = anim;
            this.Height = hoog;
            this.Width = breed;
            this.x = 200;
            this.y = 400;
            this.vel = 0;
            this.speed = 0;
            this.Period = 20;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Animation[animloop], new Rectangle(x, y, Convert.ToInt32(100), Convert.ToInt32(100)), Color.White);
        }

        public void Update(float dt)
        {
            this.vel++;
            int Gspeed = Convert.ToInt32(Math.Cos(((2 * Math.PI) / this.Period) * (this.vel)));
            this.y += Gspeed; //Convert.ToInt32(Math.PI/(Gspeed*180));

            Console.WriteLine(Gspeed);
            Console.WriteLine(y);
        }
    }
}
