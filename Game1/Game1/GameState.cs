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
        Background background;
        IPlayer player;

        public Gamestate(Background bg, IPlayer player)
        {
            this.background = bg;
            this.player = player;
        }

        public void Update(float dt)
        {
            this.player.Update(dt);
            this.background.Update(dt);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            this.background.Draw(spriteBatch);
            this.player.Draw(spriteBatch);
        }
    }
}