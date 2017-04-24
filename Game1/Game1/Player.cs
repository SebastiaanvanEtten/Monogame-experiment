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
    public class Player : IPlayer
    {

        public int x;
        public int y;
        public bool jumpbool;
        public int vel;
        public bool Ra;
        public bool La;
        public int Height;
        public int Width;
        public int groundline;
        public int Idleloop;
        public int Walkloop;
        public int Kickloop;
        public int Punchloop;
        public int Jumploop;
        public int Animationloop;
        public Texture2D IDLE1, IDLE2, IDLE3, IDLE4, IDLE5, IDLE6, IDLE7, IDLE8, IDLE9, IDLE10;
        public Texture2D KICK1, KICK2, KICK3, KICK4, KICK5, KICK6, KICK7, KICK8, KICK9, KICK10, KICK11, KICK12, KICK13, KICK14;
        public Texture2D WALK1, WALK2, WALK3, WALK4, WALK5, WALK6, WALK7, WALK8, WALK9, WALK10, WALK11;
        public Texture2D PUNCH1, PUNCH2, PUNCH3, PUNCH4, PUNCH5, PUNCH6, PUNCH7, PUNCH8, PUNCH9;
        public Texture2D JUMP1, JUMP2, JUMP3, JUMP4, JUMP5, JUMP6, JUMP7, JUMP8, JUMP9, JUMP10;
        public Texture2D WALKB1, WALKB2, WALKB3, WALKB4, WALKB5, WALKB6, WALKB7, WALKB8, WALKB9, WALKB10, WALKB11;
        public KeyboardState oldState;

        public Player(int groundline, int breed, int hoog, Texture2D IDLE1, Texture2D IDLE2, Texture2D IDLE3, Texture2D IDLE4, Texture2D IDLE5, Texture2D IDLE6, Texture2D IDLE7, Texture2D IDLE8, Texture2D IDLE9, Texture2D IDLE10, Texture2D KICK1, Texture2D KICK2, Texture2D KICK3, Texture2D KICK4, Texture2D KICK5, Texture2D KICK6, Texture2D KICK7, Texture2D KICK8, Texture2D KICK9, Texture2D KICK10, Texture2D KICK11, Texture2D KICK12, Texture2D KICK13, Texture2D KICK14, Texture2D WALK1, Texture2D WALK2, Texture2D WALK3, Texture2D WALK4, Texture2D WALK5, Texture2D WALK6, Texture2D WALK7, Texture2D WALK8, Texture2D WALK9, Texture2D WALK10, Texture2D WALK11, Texture2D PUNCH1, Texture2D PUNCH2, Texture2D PUNCH3, Texture2D PUNCH4, Texture2D PUNCH5, Texture2D PUNCH6, Texture2D PUNCH7, Texture2D PUNCH8, Texture2D PUNCH9, Texture2D JUMP1, Texture2D JUMP2, Texture2D JUMP3, Texture2D JUMP4, Texture2D JUMP5, Texture2D JUMP6, Texture2D JUMP7, Texture2D JUMP8, Texture2D JUMP9, Texture2D JUMP10, Texture2D WALKB1, Texture2D WALKB2, Texture2D WALKB3, Texture2D WALKB4, Texture2D WALKB5, Texture2D WALKB6, Texture2D WALKB7, Texture2D WALKB8, Texture2D WALKB9, Texture2D WALKB10, Texture2D WALKB11)
        {
            this.IDLE1 = IDLE1;
            this.IDLE2 = IDLE2;
            this.IDLE3 = IDLE3;
            this.IDLE4 = IDLE4;
            this.IDLE5 = IDLE5;
            this.IDLE6 = IDLE6;
            this.IDLE7 = IDLE7;
            this.IDLE8 = IDLE8;
            this.IDLE9 = IDLE9;
            this.IDLE10 = IDLE10;

            this.KICK1 = KICK1;
            this.KICK2 = KICK2;
            this.KICK3 = KICK3;
            this.KICK4 = KICK4;
            this.KICK5 = KICK5;
            this.KICK6 = KICK6;
            this.KICK7 = KICK7;
            this.KICK8 = KICK8;
            this.KICK9 = KICK9;
            this.KICK10 = KICK10;
            this.KICK11 = KICK11;
            this.KICK12 = KICK12;
            this.KICK13 = KICK13;
            this.KICK14 = KICK14;

            this.WALK1 = WALK1;
            this.WALK2 = WALK2;
            this.WALK3 = WALK3;
            this.WALK4 = WALK4;
            this.WALK5 = WALK5;
            this.WALK6 = WALK6;
            this.WALK7 = WALK7;
            this.WALK8 = WALK8;
            this.WALK9 = WALK9;
            this.WALK10 = WALK10;
            this.WALK11 = WALK11;

            this.WALKB1 = WALKB1;
            this.WALKB2 = WALKB2;
            this.WALKB3 = WALKB3;
            this.WALKB4 = WALKB4;
            this.WALKB5 = WALKB5;
            this.WALKB6 = WALKB6;
            this.WALKB7 = WALKB7;
            this.WALKB8 = WALKB8;
            this.WALKB9 = WALKB9;
            this.WALKB10 = WALKB10;
            this.WALKB11 = WALKB11;

            this.PUNCH1 = PUNCH1;
            this.PUNCH2 = PUNCH2;
            this.PUNCH3 = PUNCH3;
            this.PUNCH4 = PUNCH4;
            this.PUNCH5 = PUNCH5;
            this.PUNCH6 = PUNCH6;
            this.PUNCH7 = PUNCH7;
            this.PUNCH8 = PUNCH8;
            this.PUNCH9 = PUNCH9;

            this.JUMP1 = JUMP1;
            this.JUMP2 = JUMP2;
            this.JUMP3 = JUMP3;
            this.JUMP4 = JUMP4;
            this.JUMP5 = JUMP5;
            this.JUMP6 = JUMP6;
            this.JUMP7 = JUMP7;
            this.JUMP8 = JUMP8;
            this.JUMP9 = JUMP9;
            this.JUMP10 = JUMP10;

            this.Height = hoog;
            this.Width = breed;
            this.groundline = groundline;

            this.oldState = Keyboard.GetState(); // dit word alleen in die UpdateInput() gebruikt

            this.y = groundline; // de begin Y pos van de speler.... dit moet echt een class in...
            this.x = 100; // the hardcode is real... CLASSES
            this.jumpbool = false; // dit gaat echt te ver... maar het werk :/
            this.vel = 0;
            this.Idleloop = 0; // stil staan animatie
            this.Walkloop = 0;
            this.Kickloop = 0;
            this.Punchloop = 0;
            this.Jumploop = 0;
            this.Animationloop = 0;
        }

        public void Update(float dt)
        {
            Animationloop++;
            if (Animationloop % 6 == 0)
            { // elke % 6 updaten de animaties, dit is gwn om de snelheid van de animaties aan te passen (als dat nodig is)
                Idleloop++;
                Kickloop++;
                Punchloop++;
                Walkloop++;
            }

            UpdateInput();
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
                else if (Ra == true)
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
                else
                {
                    if (Walkloop == 0) { spriteBatch.Draw(WALKB1, new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Walkloop == 1) { spriteBatch.Draw(WALKB2, new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Walkloop == 2) { spriteBatch.Draw(WALKB3, new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Walkloop == 3) { spriteBatch.Draw(WALKB4, new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Walkloop == 4) { spriteBatch.Draw(WALKB5, new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Walkloop == 5) { spriteBatch.Draw(WALKB6, new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Walkloop == 6) { spriteBatch.Draw(WALKB7, new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Walkloop == 7) { spriteBatch.Draw(WALKB8, new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Walkloop == 8) { spriteBatch.Draw(WALKB9, new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Walkloop == 9) { spriteBatch.Draw(WALKB10, new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White); }
                    else if (Walkloop == 10) { spriteBatch.Draw(WALKB11, new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White); }
                }
            }
        }


        private void UpdateInput()
        {
            KeyboardState newState = Keyboard.GetState();

            if (newState.IsKeyDown(Keys.Up))
            {
                if (!oldState.IsKeyDown(Keys.Up))
                {
                    //stop animatie
                }
            }
            else if (oldState.IsKeyDown(Keys.Up))
            {
                //start animatie;
            }

            if (newState.IsKeyDown(Keys.Left))
            {
                if (!oldState.IsKeyDown(Keys.Left))
                {
                    this.La = true;
                }
            }
            else if (oldState.IsKeyDown(Keys.Left))
            {
                this.La = false;
            }

            if (newState.IsKeyDown(Keys.Right))
            {
                if (!oldState.IsKeyDown(Keys.Right))
                {
                    this.Ra = true;
                }
            }
            else if (oldState.IsKeyDown(Keys.Right))
            {
                this.Ra = false;
            }

            if (newState.IsKeyDown(Keys.Down))
            {
                if (!oldState.IsKeyDown(Keys.Down))
                {
                    // stop animatie;
                }
            }
            else if (oldState.IsKeyDown(Keys.Down))
            {
                //start animatie;
            }

            // Update saved state.
            oldState = newState;
        }

    }
}
