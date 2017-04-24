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
        public SpriteBatch spriteBatch;
        public Texture2D sprite, BG1, BG2, BG3, BG4, BG5, BG6, BG7, BG8;
        public Texture2D IDLE1, IDLE2, IDLE3, IDLE4, IDLE5, IDLE6, IDLE7, IDLE8, IDLE9, IDLE10;
        public Texture2D KICK1, KICK2, KICK3, KICK4, KICK5, KICK6, KICK7, KICK8, KICK9, KICK10, KICK11, KICK12, KICK13, KICK14;
        public Texture2D WALK1, WALK2, WALK3, WALK4, WALK5, WALK6, WALK7, WALK8, WALK9, WALK10, WALK11;
        public Texture2D PUNCH1, PUNCH2, PUNCH3, PUNCH4, PUNCH5, PUNCH6, PUNCH7, PUNCH8, PUNCH9;
        public Texture2D JUMP1, JUMP2, JUMP3, JUMP4, JUMP5, JUMP6, JUMP7, JUMP8, JUMP9, JUMP10;
        public bool Ra;
        public bool La;
        public static int Height = 720; // GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height; // scherm hoogte
        public static int Width = 1280; // Convert.ToInt32(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height * 1.77777776); // 16:9 aspect ratio
        public int groundline;
        Color backColor = Color.CornflowerBlue;
        public SpriteFont font;
        public int mainloop;
        public int graphicloop;
        public Player speler1;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = Width;
            graphics.PreferredBackBufferHeight = Height;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges(); // hiermee kan je midden in de game je resolutie veranderen, waar die nu staat doet het eigenlijk niks. je moet het na een verandering zetten/roepen.
            this.groundline = Height - (Height / 3); // definitie van de grond
            this.graphicloop = 0; // voor de background animatie
            this.mainloop = 0; // mainloop wordt elke gamtick met +1 omhoog gedaan
            this.Ra = false; // Right active, is alleen true als je rechter pijltjestoets indrukt, als je loslaat dan wordt die weer false. code ervan in: UpdateInput()
            this.La = false; // zelfde maar dan links
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
            //Player speler1 = new Player();
            
            
        }
        Gamestate gamestate;
        Background background;
        IPlayer player1;
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
            
            background = new Background(BG1, BG2, BG3, BG4, BG5, BG6, BG7, BG8, Width, Height);
            player1 = new Player(groundline, Width, Height, IDLE1, IDLE2, IDLE3, IDLE4, IDLE5, IDLE6, IDLE7, IDLE8, IDLE9, IDLE10, KICK1, KICK2, KICK3, KICK4, KICK5, KICK6, KICK7, KICK8, KICK9, KICK10, KICK11, KICK12, KICK13, KICK14, WALK1, WALK2, WALK3, WALK4, WALK5, WALK6, WALK7, WALK8, WALK9, WALK10, WALK11, PUNCH1, PUNCH2, PUNCH3, PUNCH4, PUNCH5, PUNCH6, PUNCH7, PUNCH8, PUNCH9, JUMP1, JUMP2, JUMP3, JUMP4, JUMP5, JUMP6, JUMP7, JUMP8, JUMP9, JUMP10);

            gamestate = new Gamestate(background,player1);

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
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            //dit kijkt naar welke knop er is inegrukt en welke niet 
            
            gamestate.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
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
            gamestate.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        
    }
}
