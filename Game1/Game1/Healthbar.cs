using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Game1
{
    public class Healthbar : IComponent
    {
        private int Height;
        private float x;
        private float xEbar;
        private float xHPbar;
        private int y;
        private int HPbarlength;
        private int Ebarlength;
        public float Health;
        private int Energy;
        private int Width;
        private float Damage;
        private int takehpawayCount;
        private bool takehpaway;
        private SpriteFont font;
        public string Text;
        private string pos;

        public Healthbar(SpriteFont font,int Height, int width, string position)
        {
            this.Height = Height;
            this.Width = width;
            if (position == "left")
            {
                this.x = Convert.ToInt32(Height / 21.6);
            }
            else if (position == "right")
            {
                this.x = Convert.ToInt32(Height / 0.93);
            }
            this.xHPbar = x;
            this.xEbar = x;
            this.y = Convert.ToInt32(Height / 15);
            this.Health = 100;
            this.Energy = 100;
            this.HPbarlength = Convert.ToInt32(Health * (Width / 250));
            this.Ebarlength = Convert.ToInt32(Energy * (Width / 250));
            this.Damage = 0;
            this.takehpaway = false;
            this.takehpawayCount = 0;
            this.font = font;
            this.Text = "player name place";
            this.pos = position;

        }

        public void GetHit(float damage)
        {
            this.Damage = damage/3;
            this.takehpaway = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D HPbar = new Texture2D(spriteBatch.GraphicsDevice, HPbarlength, Height/36);
            Color[] HPdata = new Color[HPbarlength * (Height / 36)];
            for (int i = 0; i < HPdata.Length; ++i) HPdata[i] = Color.YellowGreen;
            HPbar.SetData(HPdata);
            Vector2 HPcoor = new Vector2(this.xHPbar, this.y);

            Texture2D EnergyBar = new Texture2D(spriteBatch.GraphicsDevice, Ebarlength, Height / 72);
            Color[] Edata = new Color[Ebarlength * (Height/72)];
            for (int i = 0; i < Edata.Length; ++i) Edata[i] = Color.LightSkyBlue;
            EnergyBar.SetData(Edata);
            Vector2 Ecoor = new Vector2(this.xEbar, this.y + (Height/27));
            

            spriteBatch.Draw(EnergyBar, Ecoor, Color.White);
            spriteBatch.Draw(HPbar, HPcoor, Color.White);
            spriteBatch.DrawString(font, this.Text, new Vector2(this.x + font.MeasureString(this.Text).X * (Height/540f), this.y - (Height / 36)), Color.White, 0, font.MeasureString(this.Text)/2, Height/360f, SpriteEffects.None, 0.5f);



    }

        public void Update(float dt)
        {
            if (Health < 1) { Health = 1; }
            if (Energy < 1) { Energy = 1; }

            this.HPbarlength = Convert.ToInt32(Health * (Width / 250));
            this.Ebarlength = Convert.ToInt32(Energy * (Width / 250));


            if (this.takehpaway == true)
            {
                takehpawayCount++;
                this.Health -= (this.Damage / 10);

                if (this.pos == "right" && this.Health > 1)
                {
                    this.xHPbar += ((this.Damage / 10) * (Width / 250));
                }


                if (this.takehpawayCount == 10)
                {
                    this.takehpaway = false;
                    this.takehpawayCount = 0;
                }
            }
        }
    }
}
