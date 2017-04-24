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
    public class Player : Game1, IPlayer
    {

        public int x;
        public int y;
        public bool jumpbool;
        public int vel;
        public bool Ra;
        public bool La;
        public int Idleloop;
        public int Walkloop;
        public int Kickloop;
        public int Punchloop;
        public int Jumploop;

        public Player()
        {
            this.y = groundline; // de begin Y pos van de speler.... dit moet echt een class in...
            this.x = 100; // the hardcode is real... CLASSES
            this.jumpbool = false; // dit gaat echt te ver... maar het werk :/
            this.vel = 0;
            this.Idleloop = 0; // stil staan animatie
            this.Walkloop = 0;
            this.Kickloop = 0;
            this.Punchloop = 0;
            this.Jumploop = 0;
        }

        public void Update(float dt)
        {
            if (mainloop % 6 == 0)
            { // elke % 6 updaten de animaties, dit is gwn om de snelheid van de animaties aan te passen (als dat nodig is)

                Idleloop++;
                Kickloop++;
                Punchloop++;
                Walkloop++;
            }
            //resets de loops individueel, hangt af van hoeveel plaatjes er in de loop zitten
            if (Idleloop > 9) { Idleloop = 0; }
            if (Walkloop > 10) { Walkloop = 0; }
            this.Walk();
            this.Jump();
            this.Logic();
        }

        public void Walk()
        {
            KeyboardState KEY = Keyboard.GetState();

            if (KEY.IsKeyDown(Keys.Up))
            {
                this.jumpbool = true;
            }
            if (KEY.IsKeyDown(Keys.Down))
            {
                this.y += 0;
            }
            if (KEY.IsKeyDown(Keys.Left))
            {
                this.x -= Convert.ToInt16(Height / 108);
            }
            if (KEY.IsKeyDown(Keys.Right))
            {
                this.x += Convert.ToInt16(Height / 108);
            }

        }
        public void Logic()
        {
            if (this.y >= groundline)
            {
                this.y = groundline;
            }
        }
        public void Jump()
        {
            if (this.jumpbool == true)
            {
                int Gspeed = Convert.ToInt32(-0.2 * this.vel + 4); //deze formule is de richtingscoeficiënt van "f(x) = -0.1x^2+4x" de "+4" aan het einde is de hoogte van de sprong
                this.y -= (Height / 108) * Gspeed; // (height/108) is de zwaartekracht, kijk maar wat er gebeurt bij Height/250
                this.vel++;
                if (this.vel == 0) { Jumploop++; }
                else if (this.vel == 7) { Jumploop++; }
                else if (this.vel == 11) { Jumploop++; }
                else if (this.vel == 16) { Jumploop++; }
                else if (this.vel == 19) { Jumploop++; }
                else if (this.vel == 23) { Jumploop++; }
                else if (this.vel == 26) { Jumploop++; }
                else if (this.vel == 31) { Jumploop++; }
                else if (this.vel == 34) { Jumploop++; }


                if (this.y >= groundline)
                {
                    this.jumpbool = false;
                    this.Jumploop = 0;
                    this.vel = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (jumpbool == true)
            {
                if (Jumploop == 0) { spriteBatch.Draw(JUMP1, new Rectangle(x, y, Convert.ToInt32(Height / 5.538), Convert.ToInt32(Height / 3.898)), Color.White); }
                else if (Jumploop == 1) { spriteBatch.Draw(JUMP2, new Rectangle(x, y, Convert.ToInt32(Height / 5.538), Convert.ToInt32(Height / 3.898)), Color.White); }
                else if (Jumploop == 2) { spriteBatch.Draw(JUMP3, new Rectangle(x, y, Convert.ToInt32(Height / 5.538), Convert.ToInt32(Height / 3.898)), Color.White); }
                else if (Jumploop == 3) { spriteBatch.Draw(JUMP4, new Rectangle(x, y, Convert.ToInt32(Height / 5.538), Convert.ToInt32(Height / 3.898)), Color.White); }
                else if (Jumploop == 4) { spriteBatch.Draw(JUMP5, new Rectangle(x, y, Convert.ToInt32(Height / 5.538), Convert.ToInt32(Height / 3.898)), Color.White); }
                else if (Jumploop == 5) { spriteBatch.Draw(JUMP6, new Rectangle(x, y, Convert.ToInt32(Height / 5.538), Convert.ToInt32(Height / 3.898)), Color.White); }
                else if (Jumploop == 6) { spriteBatch.Draw(JUMP7, new Rectangle(x, y, Convert.ToInt32(Height / 5.538), Convert.ToInt32(Height / 3.898)), Color.White); }
                else if (Jumploop == 7) { spriteBatch.Draw(JUMP8, new Rectangle(x, y, Convert.ToInt32(Height / 5.538), Convert.ToInt32(Height / 3.898)), Color.White); }
                else if (Jumploop == 8) { spriteBatch.Draw(JUMP9, new Rectangle(x, y, Convert.ToInt32(Height / 5.538), Convert.ToInt32(Height / 3.898)), Color.White); }
                else if (Jumploop == 9) { spriteBatch.Draw(JUMP10, new Rectangle(x, y, Convert.ToInt32(Height / 5.538), Convert.ToInt32(Height / 3.898)), Color.White); }
            }
            else
            {
                if (Ra == false && La == false) //als je niet naar links loopt of naar rechts loopt dan... idle loop
                {
                    //IDLE LOOP
                    if (Idleloop == 0) { spriteBatch.Draw(IDLE1, new Rectangle(x, y, Convert.ToInt32(Height / 5.538), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Idleloop == 1) { spriteBatch.Draw(IDLE2, new Rectangle(x, y, Convert.ToInt32(Height / 5.538), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Idleloop == 2) { spriteBatch.Draw(IDLE3, new Rectangle(x, y, Convert.ToInt32(Height / 5.538), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Idleloop == 3) { spriteBatch.Draw(IDLE4, new Rectangle(x, y, Convert.ToInt32(Height / 5.538), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Idleloop == 4) { spriteBatch.Draw(IDLE5, new Rectangle(x, y, Convert.ToInt32(Height / 5.538), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Idleloop == 5) { spriteBatch.Draw(IDLE6, new Rectangle(x, y, Convert.ToInt32(Height / 5.538), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Idleloop == 6) { spriteBatch.Draw(IDLE7, new Rectangle(x, y, Convert.ToInt32(Height / 5.538), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Idleloop == 7) { spriteBatch.Draw(IDLE8, new Rectangle(x, y, Convert.ToInt32(Height / 5.538), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Idleloop == 8) { spriteBatch.Draw(IDLE9, new Rectangle(x, y, Convert.ToInt32(Height / 5.538), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Idleloop == 9) { spriteBatch.Draw(IDLE10, new Rectangle(x, y, Convert.ToInt32(Height / 5.538), Convert.ToInt32(Height / 3.898)), Color.White); }
                }
                else
                {
                    //WALK LOOP
                    if (Walkloop == 0) { spriteBatch.Draw(WALK1, new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Walkloop == 1) { spriteBatch.Draw(WALK2, new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Walkloop == 2) { spriteBatch.Draw(WALK3, new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Walkloop == 3) { spriteBatch.Draw(WALK4, new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Walkloop == 4) { spriteBatch.Draw(WALK5, new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Walkloop == 5) { spriteBatch.Draw(WALK6, new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Walkloop == 6) { spriteBatch.Draw(WALK7, new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Walkloop == 7) { spriteBatch.Draw(WALK8, new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Walkloop == 8) { spriteBatch.Draw(WALK9, new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Walkloop == 9) { spriteBatch.Draw(WALK10, new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Walkloop == 10) { spriteBatch.Draw(WALK11, new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White); }
                }
            }
        }

    }
}
