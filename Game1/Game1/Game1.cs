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
        public static int Height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height; // scherm hoogte
        public static int Width = Convert.ToInt32(Height * 1.77777776); // 16:9 aspect ratio
        public int groundline;
        Color backColor = Color.CornflowerBlue;
        public SpriteFont font;
        public int mainloop;
        public int graphicloop;
        public Player speler1;
        PlayerInput Player1Movement;
        PlayerInput Player2Movement;


        public Game1()
        {
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

            FlyThing.Add(FM1 = Content.Load<Texture2D>("F100"));
            FlyThing.Add(FM2 = Content.Load<Texture2D>("F101"));
            FlyThing.Add(FM3 = Content.Load<Texture2D>("F102"));
            FlyThing.Add(FM4 = Content.Load<Texture2D>("F103"));
            FlyThing.Add(FM5 = Content.Load<Texture2D>("F104"));
            FlyThing.Add(FM6 = Content.Load<Texture2D>("F105"));
            FlyThing.Add(FM7 = Content.Load<Texture2D>("F106"));
            FlyThing.Add(FM8 = Content.Load<Texture2D>("F107"));
            FlyThing.Add(FM9 = Content.Load<Texture2D>("F108"));
            FlyThing.Add(FM10 = Content.Load<Texture2D>("F109"));
            FlyThing.Add(FM11 = Content.Load<Texture2D>("F110"));
            FlyThing.Add(FM12 = Content.Load<Texture2D>("F111"));
            FlyThing.Add(FM13 = Content.Load<Texture2D>("F112"));
            FlyThing.Add(FM14 = Content.Load<Texture2D>("F113"));
            FlyThing.Add(FM15 = Content.Load<Texture2D>("F114"));
            FlyThing.Add(FM16 = Content.Load<Texture2D>("F115"));
            FlyThing.Add(FM17 = Content.Load<Texture2D>("F116"));
            FlyThing.Add(FM18 = Content.Load<Texture2D>("F117"));
            FlyThing.Add(FM19= Content.Load<Texture2D>("F118"));
            FlyThing.Add(FM20 = Content.Load<Texture2D>("F119"));
            FlyThing.Add(FM21 = Content.Load<Texture2D>("F120"));
            FlyThing.Add(FM22 = Content.Load<Texture2D>("F121"));
            FlyThing.Add(FM23 = Content.Load<Texture2D>("F122"));
            FlyThing.Add(FM24 = Content.Load<Texture2D>("F123"));
            FlyThing.Add(FM25 = Content.Load<Texture2D>("F124"));
            FlyThing.Add(FM26 = Content.Load<Texture2D>("F125"));
            FlyThing.Add(FM27 = Content.Load<Texture2D>("F126"));
            FlyThing.Add(FM28 = Content.Load<Texture2D>("F127"));

            DuckAnimations.Add(DUCK1 = Content.Load<Texture2D>("DUCK1"));
            DuckAnimations.Add(DUCK2 = Content.Load<Texture2D>("DUCK2"));
            DuckAnimations.Add(DUCK3 = Content.Load<Texture2D>("DUCK3"));
            DuckAnimations.Add(DUCK4 = Content.Load<Texture2D>("DUCK4"));
            DuckAnimations.Add(DUCK5 = Content.Load<Texture2D>("DUCK5"));
            DuckAnimations.Add(DUCK6 = Content.Load<Texture2D>("DUCK6"));
            DuckAnimations.Add(DUCK7 = Content.Load<Texture2D>("DUCK7"));
            DuckAnimations.Add(DUCK8 = Content.Load<Texture2D>("DUCK8"));
            DuckAnimations.Add(DUCK9 = Content.Load<Texture2D>("DUCK9"));

            JPunchAnimations.Add(JPUNCH1 = Content.Load<Texture2D>("JPUNCH1"));
            JPunchAnimations.Add(JPUNCH2 = Content.Load<Texture2D>("JPUNCH2"));
            JPunchAnimations.Add(JPUNCH3 = Content.Load<Texture2D>("JPUNCH3"));
            JPunchAnimations.Add(JPUNCH4 = Content.Load<Texture2D>("JPUNCH4"));

            JKickAnimations.Add(JKICK1 = Content.Load<Texture2D>("JKICK1"));
            JKickAnimations.Add(JKICK2 = Content.Load<Texture2D>("JKICK2"));
            JKickAnimations.Add(JKICK3 = Content.Load<Texture2D>("JKICK3"));
            JKickAnimations.Add(JKICK4 = Content.Load<Texture2D>("JKICK4"));
            JKickAnimations.Add(JKICK5 = Content.Load<Texture2D>("JKICK5"));
            JKickAnimations.Add(JKICK6 = Content.Load<Texture2D>("JKICK6"));
            JKickAnimations.Add(JKICK7 = Content.Load<Texture2D>("JKICK7"));

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
