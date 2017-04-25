using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

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
        public Texture2D WALKB1, WALKB2, WALKB3, WALKB4, WALKB5, WALKB6, WALKB7, WALKB8, WALKB9, WALKB10, WALKB11;

        List<Texture2D> IdleAnimations = new List<Texture2D>();
        List<Texture2D> KickAnimations = new List<Texture2D>();
        List<Texture2D> WalkAnimations = new List<Texture2D>();
        List<Texture2D> PunchAnimations = new List<Texture2D>();
        List<Texture2D> JumpAnimations = new List<Texture2D>();
        List<Texture2D> WalkBAnimations = new List<Texture2D>();

        public bool Ra;
        public bool La;
        public static int Height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height; // scherm hoogte
        public static int Width = Convert.ToInt32(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height * 1.77777776); // 16:9 aspect ratio
        public int groundline;
        Color backColor = Color.CornflowerBlue;
        public SpriteFont font;
        public int mainloop;
        public int graphicloop;
        public Player speler1;
        PlayerInput Player1Movement;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = Width;
            graphics.PreferredBackBufferHeight = Height;
            graphics.IsFullScreen = true;
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
        FloatingMan floot;
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("File");

            // laad de sprite
            KickAnimations.Add(KICK1 = Content.Load<Texture2D>("KICK1"));
            KickAnimations.Add(KICK2 = Content.Load<Texture2D>("KICK2"));
            KickAnimations.Add(KICK3 = Content.Load<Texture2D>("KICK3"));
            KickAnimations.Add(KICK4 = Content.Load<Texture2D>("KICK4"));
            KickAnimations.Add(KICK5 = Content.Load<Texture2D>("KICK5"));
            KickAnimations.Add(KICK6 = Content.Load<Texture2D>("KICK6"));
            KickAnimations.Add(KICK7 = Content.Load<Texture2D>("KICK7"));
            KickAnimations.Add(KICK8 = Content.Load<Texture2D>("KICK8"));
            KickAnimations.Add(KICK9 = Content.Load<Texture2D>("KICK9"));
            KickAnimations.Add(KICK10 = Content.Load<Texture2D>("KICK10"));
            KickAnimations.Add(KICK11 = Content.Load<Texture2D>("KICK11"));
            KickAnimations.Add(KICK12 = Content.Load<Texture2D>("KICK12"));
            KickAnimations.Add(KICK13 = Content.Load<Texture2D>("KICK13"));
            KickAnimations.Add(KICK14 = Content.Load<Texture2D>("KICK14"));

            JumpAnimations.Add(JUMP1 = Content.Load<Texture2D>("JUMP1"));
            JumpAnimations.Add(JUMP2 = Content.Load<Texture2D>("JUMP2"));
            JumpAnimations.Add(JUMP3 = Content.Load<Texture2D>("JUMP3"));
            JumpAnimations.Add(JUMP4 = Content.Load<Texture2D>("JUMP4"));
            JumpAnimations.Add(JUMP5 = Content.Load<Texture2D>("JUMP5"));
            JumpAnimations.Add(JUMP6 = Content.Load<Texture2D>("JUMP6"));
            JumpAnimations.Add(JUMP7 = Content.Load<Texture2D>("JUMP7"));
            JumpAnimations.Add(JUMP8 = Content.Load<Texture2D>("JUMP8"));
            JumpAnimations.Add(JUMP9 = Content.Load<Texture2D>("JUMP9"));
            JumpAnimations.Add(JUMP10 = Content.Load<Texture2D>("JUMP10"));

            WalkAnimations.Add(WALK1 = Content.Load<Texture2D>("WALK1"));
            WalkAnimations.Add(WALK2 = Content.Load<Texture2D>("WALK2"));
            WalkAnimations.Add(WALK3 = Content.Load<Texture2D>("WALK3"));
            WalkAnimations.Add(WALK4 = Content.Load<Texture2D>("WALK4"));
            WalkAnimations.Add(WALK5 = Content.Load<Texture2D>("WALK5"));
            WalkAnimations.Add(WALK6 = Content.Load<Texture2D>("WALK6"));
            WalkAnimations.Add(WALK7 = Content.Load<Texture2D>("WALK7"));
            WalkAnimations.Add(WALK8 = Content.Load<Texture2D>("WALK8"));
            WalkAnimations.Add(WALK9 = Content.Load<Texture2D>("WALK9"));
            WalkAnimations.Add(WALK10 = Content.Load<Texture2D>("WALK10"));
            WalkAnimations.Add(WALK11 = Content.Load<Texture2D>("WALK11"));

            WalkBAnimations.Add(WALKB1 = Content.Load<Texture2D>("WALKB1"));
            WalkBAnimations.Add(WALKB2 = Content.Load<Texture2D>("WALKB2"));
            WalkBAnimations.Add(WALKB3 = Content.Load<Texture2D>("WALKB3"));
            WalkBAnimations.Add(WALKB4 = Content.Load<Texture2D>("WALKB4"));
            WalkBAnimations.Add(WALKB5 = Content.Load<Texture2D>("WALKB5"));
            WalkBAnimations.Add(WALKB6 = Content.Load<Texture2D>("WALKB6"));
            WalkBAnimations.Add(WALKB7 = Content.Load<Texture2D>("WALKB7"));
            WalkBAnimations.Add(WALKB8 = Content.Load<Texture2D>("WALKB8"));
            WalkBAnimations.Add(WALKB9 = Content.Load<Texture2D>("WALKB9"));
            WalkBAnimations.Add(WALKB10 = Content.Load<Texture2D>("WALKB10"));
            WalkBAnimations.Add(WALKB11 = Content.Load<Texture2D>("WALKB11"));

            PunchAnimations.Add(PUNCH1 = Content.Load<Texture2D>("PUNCH1"));
            PunchAnimations.Add(PUNCH2 = Content.Load<Texture2D>("PUNCH2"));
            PunchAnimations.Add(PUNCH3 = Content.Load<Texture2D>("PUNCH3"));
            PunchAnimations.Add(PUNCH4 = Content.Load<Texture2D>("PUNCH4"));
            PunchAnimations.Add(PUNCH5 = Content.Load<Texture2D>("PUNCH5"));
            PunchAnimations.Add(PUNCH6 = Content.Load<Texture2D>("PUNCH6"));
            PunchAnimations.Add(PUNCH7 = Content.Load<Texture2D>("PUNCH7"));
            PunchAnimations.Add(PUNCH8 = Content.Load<Texture2D>("PUNCH8"));
            PunchAnimations.Add(PUNCH9 = Content.Load<Texture2D>("PUNCH9"));

            IdleAnimations.Add(IDLE1 = Content.Load<Texture2D>("IDLE1"));
            IdleAnimations.Add(IDLE2 = Content.Load<Texture2D>("IDLE2"));
            IdleAnimations.Add(IDLE3 = Content.Load<Texture2D>("IDLE3"));
            IdleAnimations.Add(IDLE4 = Content.Load<Texture2D>("IDLE4"));
            IdleAnimations.Add(IDLE5 = Content.Load<Texture2D>("IDLE5"));
            IdleAnimations.Add(IDLE6 = Content.Load<Texture2D>("IDLE6"));
            IdleAnimations.Add(IDLE7 = Content.Load<Texture2D>("IDLE7"));
            IdleAnimations.Add(IDLE8 = Content.Load<Texture2D>("IDLE8"));
            IdleAnimations.Add(IDLE9 = Content.Load<Texture2D>("IDLE9"));
            IdleAnimations.Add(IDLE10 = Content.Load<Texture2D>("IDLE10"));

            BG1 = Content.Load<Texture2D>("BG1");
            BG2 = Content.Load<Texture2D>("BG2");
            BG3 = Content.Load<Texture2D>("BG3");
            BG4 = Content.Load<Texture2D>("BG4");
            BG5 = Content.Load<Texture2D>("BG5");
            BG6 = Content.Load<Texture2D>("BG6");
            BG7 = Content.Load<Texture2D>("BG7");
            BG8 = Content.Load<Texture2D>("BG8");
            
            background = new Background(BG1, BG2, BG3, BG4, BG5, BG6, BG7, BG8, Width, Height);
            Player1Movement = new PlayerInput(Keys.Right, Keys.Left, Keys.Down, Keys.Up, Keys.X, Keys.B);
            player1 = new Player(Player1Movement, groundline, Width, Height, IdleAnimations, WalkAnimations, WalkBAnimations, JumpAnimations, PunchAnimations, KickAnimations);
            floot = new FloatingMan(Height,Width, IdleAnimations);
            gamestate = new Gamestate(background,player1,floot);

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
