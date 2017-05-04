using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
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
        public Texture2D FM1, FM2, FM3, FM4, FM5, FM6, FM7, FM8, FM9, FM10, FM11, FM12, FM13, FM14, FM15, FM16, FM17, FM18, FM19, FM20, FM21, FM22, FM23, FM24, FM25, FM26, FM27, FM28;
        public Texture2D DUCK1, DUCK2, DUCK3, DUCK4, DUCK5, DUCK6, DUCK7, DUCK8, DUCK9;
        public Texture2D JKICK1, JKICK2, JKICK3, JKICK4, JKICK5, JKICK6, JKICK7;
        public Texture2D JPUNCH1, JPUNCH2, JPUNCH3, JPUNCH4;

        public Song KickSound;

        List<Texture2D> IdleAnimations = new List<Texture2D>();
        List<Texture2D> KickAnimations = new List<Texture2D>();
        List<Texture2D> WalkAnimations = new List<Texture2D>();
        List<Texture2D> PunchAnimations = new List<Texture2D>();
        List<Texture2D> JumpAnimations = new List<Texture2D>();
        List<Texture2D> WalkBAnimations = new List<Texture2D>();
        List<Texture2D> DuckAnimations = new List<Texture2D>();
        List<Texture2D> JKickAnimations = new List<Texture2D>();
        List<Texture2D> JPunchAnimations = new List<Texture2D>();
        List<Texture2D> FlyThing = new List<Texture2D>();

        public bool Ra;
        public bool La;
        public static int Height = 480;// GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height; // scherm hoogte
        public static int Width = Convert.ToInt32(Height * 1.77777776); // 16:9 aspect ratio
        public int groundline;
        Color backColor = Color.CornflowerBlue;
        public SpriteFont font;
        public int mainloop;
        public int graphicloop;
        public Player speler1;
        public double cooldown;
        PlayerInput Player1Movement;
        PlayerInput Player2Movement;


        public Game1()
        {
            TargetElapsedTime = new TimeSpan(30);
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = Width;
            graphics.PreferredBackBufferHeight = Height;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges(); // hiermee kan je midden in de game je resolutie veranderen, waar die nu staat doet het eigenlijk niks. je moet het na een verandering zetten/roepen.
            this.groundline = Height - Convert.ToInt32(Height / 2.5); // definitie van de grond
            this.graphicloop = 0; // voor de background animatie
            this.mainloop = 0; // mainloop wordt elke gamtick met +1 omhoog gedaan
            this.Ra = false; // Right active, is alleen true als je rechter pijltjestoets indrukt, als je loslaat dan wordt die weer false. code ervan in: UpdateInput()
            this.La = false; // zelfde maar dan links
            this.cooldown = 0.016f;
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
        Healthbar barplayer1, barplayer2;
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("File");

            // laad de sprite
            KickSound = Content.Load<Song>("Whoosh");

            for (int i = 0; i < 28; ++i) { FlyThing.Add(Content.Load<Texture2D>(("F" + Convert.ToString(100 + i)))); }
            for (int i = 0; i < 8; ++i) { DuckAnimations.Add(Content.Load<Texture2D>(("DUCK" + Convert.ToString(i+1)))); }
            for (int i = 0; i < 4; ++i) { JPunchAnimations.Add(Content.Load<Texture2D>(("Jpunch" + Convert.ToString(i + 1)))); }
            for (int i = 0; i < 7; ++i) { JKickAnimations.Add(Content.Load<Texture2D>(("JKICK" + Convert.ToString(i + 1)))); }
            for (int i = 0; i < 13; ++i) { KickAnimations.Add(Content.Load<Texture2D>(("KICK" + Convert.ToString(i + 1)))); }
            for (int i = 0; i < 10; ++i) { JumpAnimations.Add(Content.Load<Texture2D>(("JUMP" + Convert.ToString(i + 1)))); }
            for (int i = 0; i < 11; ++i) { WalkAnimations.Add(Content.Load<Texture2D>(("WALK" + Convert.ToString(i + 1)))); }
            for (int i = 0; i < 11; ++i) { WalkBAnimations.Add(Content.Load<Texture2D>(("WALKB" + Convert.ToString(i + 1)))); }
            for (int i = 0; i < 9; ++i) { PunchAnimations.Add(Content.Load<Texture2D>(("PUNCH" + Convert.ToString(i + 1)))); }
            for (int i = 0; i < 10; ++i) { IdleAnimations.Add(Content.Load<Texture2D>(("IDLE" + Convert.ToString(i + 1)))); }

            BG1 = Content.Load<Texture2D>("BG1");
            BG2 = Content.Load<Texture2D>("BG2");
            BG3 = Content.Load<Texture2D>("BG3");
            BG4 = Content.Load<Texture2D>("BG4");
            BG5 = Content.Load<Texture2D>("BG5");
            BG6 = Content.Load<Texture2D>("BG6");
            BG7 = Content.Load<Texture2D>("BG7");
            BG8 = Content.Load<Texture2D>("BG8");


            barplayer1 = new Healthbar(font, Height, Width);
            background = new Background(BG1, BG2, BG3, BG4, BG5, BG6, BG7, BG8, Width, Height);
            Player1Movement = new PlayerInput(Keys.Right, Keys.Left, Keys.Down, Keys.Up, Keys.O, Keys.P, PlayerIndex.One);
            Player2Movement = new PlayerInput(Keys.D, Keys.A, Keys.S, Keys.W, Keys.C, Keys.V, PlayerIndex.Two);
            player1 = new Player(barplayer1, JKickAnimations, JPunchAnimations, KickSound, Player1Movement, groundline, Width, Height, IdleAnimations, WalkAnimations, WalkBAnimations, JumpAnimations, PunchAnimations, KickAnimations, DuckAnimations);
            floot = new FloatingMan(Height,Width,FlyThing,font);
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
            this.cooldown -= gameTime.ElapsedGameTime.TotalSeconds;

            if (this.cooldown <= 0)
            {
                gamestate.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
                this.cooldown = 0.016f;
            }
                
            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.cooldown -= gameTime.ElapsedGameTime.TotalSeconds;

            if (this.cooldown <= 0)
            {
                GraphicsDevice.Clear(backColor);
                spriteBatch.Begin();
                gamestate.Draw(spriteBatch);
                spriteBatch.End();

                this.cooldown = 0.016f;
            }
            

            base.Draw(gameTime);
        }
        
    }
}
