﻿using System;
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
        public static int Height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height; // scherm hoogte
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
            this.IsFixedTimeStep = false;
            //graphics.SynchronizeWithVerticalRetrace = false;


            TargetElapsedTime = new TimeSpan(30);
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsFixedTimeStep = false;
            this.graphics.SynchronizeWithVerticalRetrace = false;
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
        Player player1, player2;
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
            JPunchAnimations.Add(Content.Load<Texture2D>(("Jpunch4")));
            JPunchAnimations.Add(Content.Load<Texture2D>(("Jpunch4")));
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


            barplayer1 = new Healthbar(font, Height, Width, "left");
            barplayer2 = new Healthbar(font, Height, Width, "right");


            background = new Background(BG1, BG2, BG3, BG4, BG5, BG6, BG7, BG8, Width, Height);
            Player2Movement = new PlayerInput(Keys.Right, Keys.Left, Keys.Down, Keys.Up, Keys.O, Keys.P, PlayerIndex.One);
            Player1Movement = new PlayerInput(Keys.D, Keys.A, Keys.S, Keys.W, Keys.C, Keys.V, PlayerIndex.Two);
            player1 = new Player(100,barplayer1, JKickAnimations, JPunchAnimations, KickSound, Player1Movement, groundline, Width, Height, IdleAnimations, WalkAnimations, WalkBAnimations, JumpAnimations, PunchAnimations, KickAnimations, DuckAnimations);
            player2 = new Player(Width-100,barplayer2, JKickAnimations, JPunchAnimations, KickSound, Player2Movement, groundline, Width, Height, IdleAnimations, WalkAnimations, WalkBAnimations, JumpAnimations, PunchAnimations, KickAnimations, DuckAnimations);
            floot = new FloatingMan(Height,Width,FlyThing,font);
            gamestate = new Gamestate(background,player1,player2,floot);

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
            //this.cooldown -= gameTime.ElapsedGameTime.TotalSeconds;

            //if (this.cooldown <= 0)
            //{
            //    GraphicsDevice.Clear(backColor);
            //    spriteBatch.Begin();
            //    gamestate.Draw(spriteBatch);
            //    spriteBatch.End();

            //    this.cooldown = 0.016f;
            //}

            GraphicsDevice.Clear(backColor);
            spriteBatch.Begin();
            gamestate.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
        
    }
}
