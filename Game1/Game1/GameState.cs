using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class Gamestate : IComponent
    {
        Texture2D background;
        public Gamestate(Texture2D background)
        {
            this.background = background;
        }

        public void Update(float dt)
        {
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
        }
    }
}