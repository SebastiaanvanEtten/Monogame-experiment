using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Texture2D sprite, BG1, BG2, BG3, BG4, BG5, BG6, BG7, BG8;
        public Texture2D IDLE1, IDLE2, IDLE3, IDLE4, IDLE5, IDLE6, IDLE7, IDLE8, IDLE9, IDLE10;
        public Texture2D KICK1, KICK2, KICK3, KICK4, KICK5, KICK6, KICK7, KICK8, KICK9, KICK10, KICK11, KICK12, KICK13, KICK14;
        public Texture2D WALK1, WALK2, WALK3, WALK4, WALK5, WALK6, WALK7, WALK8, WALK9, WALK10, WALK11;
        public Texture2D PUNCH1, PUNCH2, PUNCH3, PUNCH4, PUNCH5, PUNCH6, PUNCH7, PUNCH8, PUNCH9;
        public Texture2D JUMP1, JUMP2, JUMP3, JUMP4, JUMP5, JUMP6, JUMP7, JUMP8, JUMP9, JUMP10;

        public int Height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height; // scherm hoogte
        public int Width = Convert.ToInt32(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height * 1.77777776); // 16:9 aspect ratio
        int groundline;
        public int x;
        public int y;
        bool jumpbool;
        int vel;
        KeyboardState oldState;
        Color backColor = Color.CornflowerBlue;
        public SpriteFont font;
        bool Ra;
        bool La;
        int mainloop;
        int graphicloop;
        int Idleloop;
        int Walkloop;
        int Kickloop;
        int Punchloop;
        int Jumploop;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = Width;
            graphics.PreferredBackBufferHeight = Height;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges(); // hiermee kan je midden in de game je resolutie veranderen, waar die nu staat doet het eigenlijk niks. je moet het na een verandering zetten/roepen.
            this.groundline = Height - (Height / 3); // definitie van de grond
            this.y = groundline; // de begin Y pos van de speler.... dit moet echt een class in...
            this.x = 100; // the hardcode is real... CLASSES
            this.jumpbool = false; // dit gaat echt te ver... maar het werk :/
            this.vel = 0;
            this.Ra = false; // Right active, is alleen true als je rechter pijltjestoets indrukt, als je loslaat dan wordt die weer false. code ervan in: UpdateInput()
            this.La = false; // zelfde maar dan links
            this.graphicloop = 0; // voor de background animatie
            this.mainloop = 0; // mainloop wordt elke gamtick met +1 omhoog gedaan
            this.Idleloop = 0; // stil staan animatie
            this.Walkloop = 0; 
            this.Kickloop = 0;
            this.Punchloop = 0;
            this.Jumploop = 0;
            

        }
        

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
        
            base.Initialize();
            oldState = Keyboard.GetState(); // dit word alleen in die UpdateInput() gebruikt
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("File");

            // laad de sprite
            KICK1 = Content.Load<Texture2D>("KICK1");
            KICK2 = Content.Load<Texture2D>("KICK2");
            KICK3 = Content.Load<Texture2D>("KICK3");
            KICK4 = Content.Load<Texture2D>("KICK4");
            KICK5 = Content.Load<Texture2D>("KICK5");
            KICK6 = Content.Load<Texture2D>("KICK6");
            KICK7 = Content.Load<Texture2D>("KICK7");
            KICK8 = Content.Load<Texture2D>("KICK8");
            KICK9 = Content.Load<Texture2D>("KICK9");
            KICK10 = Content.Load<Texture2D>("KICK10");
            KICK11 = Content.Load<Texture2D>("KICK11");
            KICK12 = Content.Load<Texture2D>("KICK12");
            KICK13 = Content.Load<Texture2D>("KICK13");
            KICK14 = Content.Load<Texture2D>("KICK14");

            JUMP1 = Content.Load<Texture2D>("JUMP1");
            JUMP2 = Content.Load<Texture2D>("JUMP2");
            JUMP3 = Content.Load<Texture2D>("JUMP3");
            JUMP4 = Content.Load<Texture2D>("JUMP4");
            JUMP5 = Content.Load<Texture2D>("JUMP5");
            JUMP6 = Content.Load<Texture2D>("JUMP6");
            JUMP7 = Content.Load<Texture2D>("JUMP7");
            JUMP8 = Content.Load<Texture2D>("JUMP8");
            JUMP9 = Content.Load<Texture2D>("JUMP9");
            JUMP10 = Content.Load<Texture2D>("JUMP10");

            WALK1 = Content.Load<Texture2D>("WALK1");
            WALK2 = Content.Load<Texture2D>("WALK2");
            WALK3 = Content.Load<Texture2D>("WALK3");
            WALK4 = Content.Load<Texture2D>("WALK4");
            WALK5 = Content.Load<Texture2D>("WALK5");
            WALK6 = Content.Load<Texture2D>("WALK6");
            WALK7 = Content.Load<Texture2D>("WALK7");
            WALK8 = Content.Load<Texture2D>("WALK8");
            WALK9 = Content.Load<Texture2D>("WALK9");
            WALK10 = Content.Load<Texture2D>("WALK10");
            WALK11 = Content.Load<Texture2D>("WALK11");

            PUNCH1 = Content.Load<Texture2D>("PUNCH1");
            PUNCH2 = Content.Load<Texture2D>("PUNCH2");
            PUNCH3 = Content.Load<Texture2D>("PUNCH3");
            PUNCH4 = Content.Load<Texture2D>("PUNCH4");
            PUNCH5 = Content.Load<Texture2D>("PUNCH5");
            PUNCH6 = Content.Load<Texture2D>("PUNCH6");
            PUNCH7 = Content.Load<Texture2D>("PUNCH7");
            PUNCH8 = Content.Load<Texture2D>("PUNCH8");
            PUNCH9 = Content.Load<Texture2D>("PUNCH9");

            IDLE1 = Content.Load<Texture2D>("IDLE1");
            IDLE2 = Content.Load<Texture2D>("IDLE2");
            IDLE3 = Content.Load<Texture2D>("IDLE3");
            IDLE4 = Content.Load<Texture2D>("IDLE4");
            IDLE5 = Content.Load<Texture2D>("IDLE5");
            IDLE6 = Content.Load<Texture2D>("IDLE6");
            IDLE7 = Content.Load<Texture2D>("IDLE7");
            IDLE8 = Content.Load<Texture2D>("IDLE8");
            IDLE9 = Content.Load<Texture2D>("IDLE9");
            IDLE10 = Content.Load<Texture2D>("IDLE10");

            BG1 = Content.Load<Texture2D>("BG1");
            BG2 = Content.Load<Texture2D>("BG2");
            BG3 = Content.Load<Texture2D>("BG3");
            BG4 = Content.Load<Texture2D>("BG4");
            BG5 = Content.Load<Texture2D>("BG5");
            BG6 = Content.Load<Texture2D>("BG6");
            BG7 = Content.Load<Texture2D>("BG7");
            BG8 = Content.Load<Texture2D>("BG8");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            KeyboardState KEY = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here ::: DOING
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

            // dit is de logic waarmee je niet door de grond zakt.
            if (this.y >= groundline)
            {
                this.y = groundline;
            }

            //dit kijkt naar welke knop er is inegrukt en welke niet 
            UpdateInput();


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
            mainloop++;
            if (mainloop % 6 == 0)
            { // elke % 6 updaten de animaties, dit is gwn om de snelheid van de animaties aan te passen (als dat nodig is)
                graphicloop++;
                Idleloop++;
                Kickloop++;
                Punchloop++;
                Walkloop++;
            }
            //resets de loops individueel, hangt af van hoeveel plaatjes er in de loop zitten
            if (Idleloop > 9) { Idleloop = 0; }
            if (graphicloop > 7) { graphicloop = 0; }
            if (Walkloop > 10) { Walkloop = 0; }

            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backColor);

            spriteBatch.Begin();
            if (graphicloop == 0) { spriteBatch.Draw(BG1, new Rectangle(0, 0, Width, Height), Color.White); }
            else if (graphicloop == 1) { spriteBatch.Draw(BG2, new Rectangle(0, 0, Width, Height), Color.White); }
            else if (graphicloop == 2) { spriteBatch.Draw(BG3, new Rectangle(0, 0, Width, Height), Color.White); }
            else if (graphicloop == 3) { spriteBatch.Draw(BG4, new Rectangle(0, 0, Width, Height), Color.White); }
            else if (graphicloop == 4) { spriteBatch.Draw(BG5, new Rectangle(0, 0, Width, Height), Color.White); }
            else if (graphicloop == 5) { spriteBatch.Draw(BG6, new Rectangle(0, 0, Width, Height), Color.White); }
            else if (graphicloop == 6) { spriteBatch.Draw(BG7, new Rectangle(0, 0, Width, Height), Color.White); }
            else if (graphicloop == 7) { spriteBatch.Draw(BG8, new Rectangle(0, 0, Width, Height), Color.White); }

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
            
            

            spriteBatch.End();

            base.Draw(gameTime);
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
