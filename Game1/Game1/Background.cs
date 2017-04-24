using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class Background : IComponent
    {
        Texture2D BackGround1, BackGround2, BackGround3, BackGround4, BackGround5, BackGround6, BackGround7, BackGround8;
        int gameloop;
        int graphicloop;
        int Height;
        int Width;

        public Background(Texture2D a, Texture2D b, Texture2D c, Texture2D d, Texture2D e, Texture2D f, Texture2D g, Texture2D h, int breed, int hoog)
        {
            this.BackGround1 = a;
            this.BackGround2 = b;
            this.BackGround3 = c;
            this.BackGround4 = d;
            this.BackGround5 = e;
            this.BackGround6 = f;
            this.BackGround7 = g;
            this.BackGround8 = h;
            this.gameloop = 0;
            this.graphicloop = 0;
            this.Height = hoog;
            this.Width = breed;
        }

        public void Update(float dt)
        {
            this.gameloop++;
            if (this.gameloop % 6 == 0)
            {
                this.graphicloop++;
            }
            if (graphicloop > 7) { this.graphicloop = 0; }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (graphicloop == 0) { spriteBatch.Draw(BackGround1, new Rectangle(0, 0, Width, Height), Color.White); }
            else if (graphicloop == 1) { spriteBatch.Draw(BackGround2, new Rectangle(0, 0, Width, Height), Color.White); }
            else if (graphicloop == 2) { spriteBatch.Draw(BackGround3, new Rectangle(0, 0, Width, Height), Color.White); }
            else if (graphicloop == 3) { spriteBatch.Draw(BackGround4, new Rectangle(0, 0, Width, Height), Color.White); }
            else if (graphicloop == 4) { spriteBatch.Draw(BackGround5, new Rectangle(0, 0, Width, Height), Color.White); }
            else if (graphicloop == 5) { spriteBatch.Draw(BackGround6, new Rectangle(0, 0, Width, Height), Color.White); }
            else if (graphicloop == 6) { spriteBatch.Draw(BackGround7, new Rectangle(0, 0, Width, Height), Color.White); }
            else if (graphicloop == 7) { spriteBatch.Draw(BackGround8, new Rectangle(0, 0, Width, Height), Color.White); }
        }
    }
}
