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
        public int MoveSpeed;
        List<Texture2D> IdleAnimations;
        List<Texture2D> KickAnimations;
        List<Texture2D> WalkAnimations;
        List<Texture2D> PunchAnimations;
        List<Texture2D> JumpAnimations;
        List<Texture2D> WalkBAnimations;
        public KeyboardState oldState;
        public GamePadState oldPadState;
        public GamePadState gamePadState;

        public Player(int groundline, int breed, int hoog, List<Texture2D> IdleAnimations, List<Texture2D> WalkAnimations, List<Texture2D> WalkBAnimations, List<Texture2D> JumpAnimations, List<Texture2D> PunchAnimations, List<Texture2D> KickAnimations)
        {
            this.IdleAnimations = IdleAnimations;
            this.WalkAnimations = WalkAnimations;
            this.WalkBAnimations = WalkBAnimations;
            this.JumpAnimations = JumpAnimations;
            this.PunchAnimations = PunchAnimations;
            this.KickAnimations = KickAnimations;

            this.Height = hoog;
            this.Width = breed;
            this.groundline = groundline;
            this.MoveSpeed = Convert.ToInt16(Height / 108);

            this.oldState = Keyboard.GetState(); // dit word alleen in die UpdateInput() gebruikt
            this.oldPadState = GamePad.GetState(PlayerIndex.One);
            

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
            if (Animationloop % 4 == 0)
            { // elke % 6 updaten de animaties, dit is gwn om de snelheid van de animaties aan te passen (als dat nodig is)
                Idleloop++;
                Kickloop++;
                Punchloop++;
                Walkloop++;
            }

            UpdateInput();
            //resets de loops individueel, hangt af van hoeveel plaatjes er in de loop zitten
            if (Idleloop > IdleAnimations.Count()) { Idleloop = 0; }
            if (Walkloop > WalkAnimations.Count()) { Walkloop = 0; }
            this.Walk();
            this.Jump();
            this.Logic();
        }

        public void Walk()
        {
            KeyboardState KEY = Keyboard.GetState();
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);



            if (gamePadState.IsConnected)
            {
                if (gamePadState.ThumbSticks.Left.X > 0.5)
                {
                    this.x += this.MoveSpeed;
                    this.Ra = true;
                }
                else
                {
                    this.Ra = false;
                }
                if (gamePadState.ThumbSticks.Left.X < -0.5)
                {
                    this.x -= this.MoveSpeed;
                    this.La = true;
                }
                else
                {
                    this.La = false;
                }
                if (gamePadState.Buttons.A == ButtonState.Pressed)
                {
                    this.jumpbool = true;
                }
                if (gamePadState.ThumbSticks.Left.Y > 0.5)
                {
                    this.y -= 0;
                    // duck()
                }
            }
            else
            {
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
                    this.x -= this.MoveSpeed;
                }
                if (KEY.IsKeyDown(Keys.Right))
                {
                    this.x += Convert.ToInt16(Height / 98);
                }
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
                spriteBatch.Draw(JumpAnimations[Jumploop], new Rectangle(x, y, Convert.ToInt32(Height / 5.538), Convert.ToInt32(Height / 3.898)), Color.White);

            }
            else
            {
                if (Ra == false && La == false) //als je niet naar links loopt of naar rechts loopt dan... idle loop
                {
                    //IDLE LOOP
                    spriteBatch.Draw(IdleAnimations[Idleloop % IdleAnimations.Count()], new Rectangle(x, y, Convert.ToInt32(Height / 5.538), Convert.ToInt32(Height / 3.898)), Color.White);

                }
                else if (Ra == true)
                {
                    //WALK LOOP
                    spriteBatch.Draw(WalkAnimations[Walkloop % WalkAnimations.Count()], new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White);

                }
                else
                {
                    spriteBatch.Draw(WalkBAnimations[Walkloop % WalkBAnimations.Count()], new Rectangle(x, y, Convert.ToInt32(Height / 4.038), Convert.ToInt32(Height / 3.898)), Color.White);

                }
            }
        }


        private void UpdateInput()
        {
            KeyboardState newState = Keyboard.GetState();
            GamePadState newPadState = GamePad.GetState(PlayerIndex.One);

            if (newPadState.IsConnected)
            {

                
                // als we het nodig hebben om te kijken of een knop wel of niet ingedrukt is.
                // hieronder staat al één voorbeeld. ctrl+K+U voor een heel gedeelte te uncommente

                //if (newPadState.IsButtonDown(Buttons.X))
                //{
                //    if (!oldPadState.IsButtonDown(Buttons.X))
                //    {
                //        //start animatie of iets anders
                //    }
                //}
                //else if (oldPadState.IsButtonDown(Buttons.X))
                //{
                //    //stop animatie of ietsanders
                //}

                //// At the end, we update old state to the state we grabbed at the start of this update.
                //// This allows us to reuse it in the next update.
                //oldPadState = newPadState;
            }
            else
            {
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
}
