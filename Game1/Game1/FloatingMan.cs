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
        public int MoveSpeed;
        public int Height;
        public int Width;
        private int animloop;
        private int Period;
        private int amplitude;
        private int mainloop;
        private bool active;
        private bool halfway;
        private bool leaving;
        private int stoptimer;
        SpriteFont font;


        List<Texture2D> Animation;

        public FloatingMan(int hoog,int breed, List<Texture2D> anim, SpriteFont font)
        {
            this.animloop = 0;
            this.Animation = anim;
            this.Height = hoog;
            this.Width = breed;
            this.x = -(Height/3);
            this.y = 0;
            this.vel = 0;
            this.MoveSpeed = Convert.ToInt32(Height/108);
            this.Period = 150;
            this.amplitude = 5;
            this.mainloop = 0;
            this.active = true;
            
        }

        public void activate()
        {
            this.active = true;
            this.MoveSpeed = 10;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.active == true)
            {
                spriteBatch.Draw(Animation[animloop], new Rectangle(x, y, Convert.ToInt32(Height / 3), Convert.ToInt32(Height / 3)), Color.White);
            }
            else
            {
                // draw dan niks
            }
            
        }

        public void Update(float dt)
        {

            if (this.active == true)
            {
                if (this.x > (Width / 2) - ((Height / 5)) && this.leaving == false)
                {
                    this.halfway = true;
                }

                if (halfway == true)
                {
                    this.x -= this.MoveSpeed;
                    this.stoptimer++;
                    if (stoptimer > 180)
                    {
                        this.halfway = false;
                        this.leaving = true;
                    }

                }
                this.x += this.MoveSpeed;
                
                if (this.x > Width)
                {
                    this.halfway = false;
                    this.active = false;
                    this.leaving = false;
                    this.x = -(Height / 3);
                }


                this.mainloop++;
                if (mainloop % 6 == 0)
                {
                    animloop++;
                }

                if (animloop == Animation.Count()) { animloop = 0; }

                this.vel++;
                int Gspeed = Convert.ToInt32(this.amplitude * Math.Sin(((2 * Math.PI) / this.Period) * (this.vel)));
                this.y += GravityToScreenSize(Gspeed);
            }
            else
            {
                // doe niks
            }
            
            
            
        }
        int GravityToScreenSize(int Gravity)
        {
            if (Gravity == 0)
            {
                return 0;
            }
            else
            {
                return (Height / (1080 / Gravity));
            }
            
        }
    }
}
