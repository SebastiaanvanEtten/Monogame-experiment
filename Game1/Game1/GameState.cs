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
        Player player1, player2;
        FloatingMan floot;

        public Gamestate(Background bg, Player player1, Player player2, FloatingMan fll)
        {
            this.background = bg;
            this.player1 = player1;
            this.player2 = player2;
            this.floot = fll;
        }

        public void Update(float dt)
        {
            if (player1.x > player2.x)
            {
                player1.flipped = true;
                player2.flipped = false;
            }
            else
            {
                player1.flipped = false;
                player2.flipped = true;
            }

            if (player1.x == player2.x)
            {
                player1.healthbar.GetHit(20);
                player2.healthbar.GetHit(20);
            }

            this.player1.Update(dt);
            this.player2.Update(dt);
            this.background.Update(dt);
            this.floot.Update(dt);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            this.background.Draw(spriteBatch);
            this.player1.Draw(spriteBatch);
            this.player2.Draw(spriteBatch);
            this.floot.Draw(spriteBatch);
        }
    }
}