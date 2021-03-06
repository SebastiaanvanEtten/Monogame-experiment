﻿using System;
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
    public class Player : IPlayer
    {

        public int x;
        public int y;
        public bool jumpbool;
        public bool IsPunching;
        public bool IsKicking;
        public bool IsDucking;
        public int KickStart;
        public int PunchStart;
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
        public int JPunchloop;
        public int JKickloop;
        public int Jumploop;
        public int Animationloop;
        public int Duckloop;
        public int MoveSpeed;
        private int FrameWidth;
        private int FrameHeight;
        List<Texture2D> IdleAnimations;
        List<Texture2D> KickAnimations;
        List<Texture2D> WalkAnimations;
        List<Texture2D> PunchAnimations;
        List<Texture2D> JumpAnimations;
        List<Texture2D> WalkBAnimations;
        List<Texture2D> DuckAnimations;
        List<Texture2D> JKickAnimations;
        List<Texture2D> JPunchAnimations;
        private Song KickSound;
        public KeyboardState oldState;
        public GamePadState oldPadState;
        public GamePadState gamePadState;
        PlayerInput Movement;
        public Healthbar healthbar;
        Texture2D Frame;
        public bool flipped;

        public Player(int startpos, Healthbar bar, List<Texture2D> JKickAnimations, List<Texture2D> JPunchAnimations, Song KickSound, PlayerInput Input, int groundline, int breed, int hoog, List<Texture2D> IdleAnimations, List<Texture2D> WalkAnimations, List<Texture2D> WalkBAnimations, List<Texture2D> JumpAnimations, List<Texture2D> PunchAnimations, List<Texture2D> KickAnimations, List<Texture2D> DuckAnimations)
        {
            this.IdleAnimations = IdleAnimations;
            this.WalkAnimations = WalkAnimations;
            this.WalkBAnimations = WalkBAnimations;
            this.JumpAnimations = JumpAnimations;
            this.PunchAnimations = PunchAnimations;
            this.KickAnimations = KickAnimations;
            this.DuckAnimations = DuckAnimations;
            this.JKickAnimations = JKickAnimations;
            this.JPunchAnimations = JPunchAnimations;
            this.healthbar = bar;

            this.Movement = Input;
            this.Frame = IdleAnimations[0];
            this.KickSound = KickSound;

            this.Height = hoog;
            this.Width = breed;
            this.groundline = groundline;
            this.MoveSpeed = Convert.ToInt16(Height / 108);

            this.oldState = Keyboard.GetState(); // dit word alleen in die UpdateInput() gebruikt
            this.oldPadState = GamePad.GetState(PlayerIndex.One);


            this.y = groundline; // de begin Y pos van de speler.... dit moet echt een class in...
            this.x = startpos; // the hardcode is real... CLASSES
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
            healthbar.Update(dt);
            

            Animationloop++;
            if (Animationloop % 3 == 0)
            {
                Kickloop++;
                Punchloop++;

                if (jumpbool == true && IsKicking == true && JKickloop < 4)
                {
                    JKickloop++;
                }
                if (jumpbool == true && IsPunching == true && JPunchloop < JPunchAnimations.Count()+1)
                {
                    JPunchloop++;
                }
            }
            if (Animationloop % 4 == 0)
            {
                Idleloop++;
                Walkloop++;
                if (this.IsDucking == true)
                {
                    Duckloop++;
                }

            }

            UpdateInput();
            //resets de loops individueel, hangt af van hoeveel plaatjes er in de loop zitten
            if (Idleloop == IdleAnimations.Count()) { Idleloop = 0; }
            if (Walkloop == WalkAnimations.Count()) { Walkloop = 0; }
            if (Duckloop == DuckAnimations.Count())
            {
                if (this.IsDucking == true)
                {
                    this.Duckloop = 4;
                }
                else
                {
                    this.Duckloop = 0;
                }
            }

            this.Walk();
            this.Jump();
            this.Logic();
            this.Kick();
            this.Punch();

            this.frameupdater();
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            //test box
            int wit = Convert.ToInt32(Height / 12);
            int heit = Convert.ToInt32(Height / 4.32);

            Texture2D HPbar = new Texture2D(spriteBatch.GraphicsDevice, wit, heit);
            Color[] HPdata = new Color[wit * heit];
            for (int i = 0; i < HPdata.Length; ++i) HPdata[i] = Color.Blue;
            HPbar.SetData(HPdata);
            Vector2 HPcoor = new Vector2(this.x, this.y);
            spriteBatch.Draw(HPbar, HPcoor, Color.White);


            healthbar.Draw(spriteBatch);
            SpriteEffects s = SpriteEffects.FlipHorizontally;
            if (this.flipped == true) 
            {
                //TODO: flip die kkr image
                spriteBatch.Draw(this.Frame, new Rectangle(x-FrameWidth/4, y, this.FrameWidth, this.FrameHeight), Color.White);
            }
            else
            {
                spriteBatch.Draw(this.Frame, new Rectangle(x-FrameWidth/4, y, this.FrameWidth, this.FrameHeight), Color.White);
            }

            

        }


        public void Walk()
        {
            KeyboardState KEY = Keyboard.GetState();
            GamePadState gamePadState = GamePad.GetState(Movement.index);
            
            if (gamePadState.IsConnected)
            {
                if (gamePadState.ThumbSticks.Left.X > 0.5 && this.IsDucking == false)
                {
                    this.x += this.MoveSpeed;
                    this.Ra = true;
                }
                else
                {
                    this.Ra = false;
                }
                if (gamePadState.ThumbSticks.Left.X < -0.5 && this.IsDucking == false)
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
                if ((gamePadState.Buttons.B == ButtonState.Pressed) && (Kickloop - KickStart > KickAnimations.Count))
                {
                    Kickloop = 0;
                    JKickloop = 0;
                    KickStart = Kickloop;
                    this.IsKicking = true;
                }
                if ((gamePadState.Buttons.X == ButtonState.Pressed) && (Punchloop - PunchStart > PunchAnimations.Count))
                {
                    Punchloop = 0;
                    JPunchloop = 0;
                    PunchStart = Punchloop;
                    this.IsPunching = true;
                }
                if (gamePadState.ThumbSticks.Left.Y < -0.5)
                {
                    this.IsDucking = true;
                }
                else
                {
                    this.IsDucking = false;
                    this.Duckloop = 0;
                }
            }
            else
            {
                if (KEY.IsKeyDown(Movement.Jump))
                {
                    this.jumpbool = true;
                }
                if (KEY.IsKeyDown(Movement.Duck))
                {
                    this.y -= 0;
                }
                if (KEY.IsKeyDown(Movement.WalkLeft) && this.IsDucking == false)
                {
                    this.x -= this.MoveSpeed;
                }
                if (KEY.IsKeyDown(Movement.WalkRight) && this.IsDucking == false)
                {
                    this.x += this.MoveSpeed;
                }
                if (KEY.IsKeyDown(Movement.Kick) && (Kickloop - KickStart > KickAnimations.Count) && this.IsPunching == false)
                {
                    Kickloop = 0;
                    JKickloop = 0;
                    KickStart = Kickloop;
                    this.IsKicking = true;
                }

                if (KEY.IsKeyDown(Movement.Punch) && (Punchloop - PunchStart > PunchAnimations.Count) && this.IsKicking == false)
                {
                    Punchloop = 0;
                    JPunchloop = 0;
                    PunchStart = Punchloop;
                    this.IsPunching = true;
                }
            }

        }

        public void Logic()
        {
            if (IsPunching == true || IsKicking == true)
            {
                if (this.y >= groundline)
                {
                    this.MoveSpeed = 0;
                }
                
            }
            else
            {
                this.MoveSpeed = Convert.ToInt16(Height / 108);
            }


            if (this.y >= groundline)
            {
                this.y = groundline;
            }
            if (this.x < Convert.ToInt32(Height/25)) { this.x = Convert.ToInt32(Height / 25); }
            if (this.x > (Width - Convert.ToInt32(Height / 12.6))) { this.x = Width - (Convert.ToInt32(Height / 12.6)); }
        }

        public void Jump()
        {
            if (this.jumpbool == true)
            {
                this.MoveSpeed = Convert.ToInt16(Height / 98);
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
                    this.MoveSpeed = Convert.ToInt16(Height / 108);
                    this.jumpbool = false;
                    this.Jumploop = 0;
                    this.vel = 0;
                    this.Kickloop = this.KickAnimations.Count();
                    this.Punchloop = this.JPunchAnimations.Count();
                }
            }
        }

        public void Kick()
        {
            if (this.IsKicking)
            {
                if (Kickloop == 5)
                {
                    //hit tegenstander
                }
                if (flipped == true)
                {
                    this.x -= Convert.ToInt32(Height / 540);
                }
                else
                {
                    this.x += Convert.ToInt32(Height / 540);
                }
               
                if (this.Kickloop == KickAnimations.Count())
                {
                    IsKicking = false;

                }
            }
        }

        public void Punch()
        {
            if (this.IsPunching)
            {

                if (this.Punchloop == PunchAnimations.Count())
                {
                    IsPunching = false;
                }
            }
        }

        private void frameupdater()
        {
            if (IsKicking)
            {
                if (Kickloop == 1)
                {
                    //MediaPlayer.Play(KickSound);
                }
                //Kick LOOP
                if (jumpbool == true)
                {
                    this.Frame = JKickAnimations[JKickloop % JKickAnimations.Count()];
                    this.FrameWidth = Convert.ToInt32(Height / 3.538);
                    this.FrameHeight = Convert.ToInt32(Height / 3.398);
                }
                else
                {
                    this.Frame = KickAnimations[Kickloop % KickAnimations.Count()];
                    this.FrameWidth = Convert.ToInt32(Height / 2.938);
                    this.FrameHeight = Convert.ToInt32(Height / 3.898);
                }
            }
            else if (IsPunching)
            {
                if ( Punchloop == 1)
                {
                    //play sound
                }
                if (jumpbool == true)
                {
                    this.Frame = JPunchAnimations[JPunchloop % JPunchAnimations.Count()];
                    this.FrameWidth = Convert.ToInt32(Height / 4.038);
                    this.FrameHeight = Convert.ToInt32(Height / 3.898);
                }
                else
                {
                    this.Frame = PunchAnimations[Punchloop % PunchAnimations.Count()];
                    this.FrameWidth = Convert.ToInt32(Height / 4.038);
                    this.FrameHeight = Convert.ToInt32(Height / 3.898);
                }
               
            }
            else
            {
                if (jumpbool == true)
                {
                    this.Frame = JumpAnimations[Jumploop];
                    this.FrameWidth = Convert.ToInt32(Height / 5.138);
                    this.FrameHeight = Convert.ToInt32(Height / 3.498);
                }
                else if (this.IsDucking)
                {
                    //DUCK LOOP
                    this.Frame = DuckAnimations[Duckloop];
                    this.FrameWidth = Convert.ToInt32(Height / 4.838);
                    this.FrameHeight = Convert.ToInt32(Height / 3.898);
                }
                else
                {
                    if (La == true) //als je niet naar links loopt of naar rechts loopt dan... idle loop
                    {
                        this.Frame = WalkBAnimations[Walkloop % WalkBAnimations.Count()];
                        this.FrameWidth = Convert.ToInt32(Height / 4.038);
                        this.FrameHeight = Convert.ToInt32(Height / 3.898);
                    }
                    else if (Ra == true)
                    {
                        //WALK LOOP
                        this.Frame = WalkAnimations[Walkloop % WalkAnimations.Count()];
                        this.FrameWidth = Convert.ToInt32(Height / 4.038);
                        this.FrameHeight = Convert.ToInt32(Height / 3.898);
                    }
                    else
                    {   //IDLE LOOP
                        this.Frame = IdleAnimations[Idleloop % IdleAnimations.Count()];
                        this.FrameWidth = Convert.ToInt32(Height / 5.538);
                        this.FrameHeight = Convert.ToInt32(Height / 3.898);
                    }
                }
            }
        }

        private void UpdateInput()
        {
            KeyboardState newState = Keyboard.GetState();
            GamePadState newPadState = GamePad.GetState(Movement.index);

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
                if (newState.IsKeyDown(Movement.Jump))
                {
                    if (!oldState.IsKeyDown(Movement.Jump))
                    {
                        //stop animatie
                    }
                }
                else if (oldState.IsKeyDown(Movement.Jump))
                {
                    //start animatie;
                }


                if (newState.IsKeyDown(Movement.Kick))
                {
                    if (!oldState.IsKeyDown(Movement.Kick))
                    {
                        //stop
                    }
                }
                else if (oldState.IsKeyDown(Movement.Kick))
                {
                    //start
                }

                if (newState.IsKeyDown(Movement.WalkLeft))
                {
                    if (!oldState.IsKeyDown(Movement.WalkLeft))
                    {
                        if (flipped == true)
                        {
                            this.Ra = true;
                        }
                        else
                        {
                            this.La = true;
                        }
                        
                    }
                }
                else if (oldState.IsKeyDown(Movement.WalkLeft))
                {
                    if (flipped == true)
                    {
                        this.La = false;
                        this.Ra = false;
                    }
                    else
                    {
                        this.La = false;
                        this.Ra = false;
                    }
                }

                if (newState.IsKeyDown(Movement.WalkRight))
                {
                    if (!oldState.IsKeyDown(Movement.WalkRight))
                    {
                        if (flipped == true)
                        {
                            this.La = true;
                        }
                        else
                        {
                            this.Ra = true;
                        }
                    }
                }
                else if (oldState.IsKeyDown(Movement.WalkRight))
                {
                    if (flipped == true)
                    {
                        this.La = false;
                        this.Ra = false;
                    }
                    else
                    {
                        this.La = false;
                        this.Ra = false;
                    }
                }

                if (newState.IsKeyDown(Movement.Duck))
                {
                    if (!oldState.IsKeyDown(Movement.Duck))
                    {
                        this.IsDucking = true;
                        
                    }
                }
                else if (oldState.IsKeyDown(Movement.Duck))
                {
                    this.IsDucking = false;
                    this.Duckloop = 0;
                }

                // Update saved state.
                oldState = newState;
            }
        

        }

    }
}
