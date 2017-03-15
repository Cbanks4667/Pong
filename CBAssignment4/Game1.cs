//CBAssignment4
//Pong in Monogame

//Game1 Class

//Revision History
//Created: Chris Banks Nov.5th 2016
//

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;

namespace CBAssignment4
{
    /// <summary>
    /// defines the game class
    /// </summary>
    public class Game1 : Game
    {
       GraphicsDeviceManager graphics;
       SpriteBatch spriteBatch;
       private Bat bat1;
       private Bat bat2;
       private Ball ball;
       private SimpleString player1;
       private SimpleString player2;
       private CollisionManager cm;
       private ScoreBoard sb;
       private SpriteFont font;
       private float speed = 5;
       SoundEffect clickSound;
       private const int MAX_SCORE = 2;
       private NameForm nameForm;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            //graphics.IsFullScreen = true;
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
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //-------Load-----Textures------------
            Texture2D ballTex = Content.Load<Texture2D>("images/Ball");
            Texture2D batLeftTex = Content.Load<Texture2D>("images/BatLeft");
            Texture2D batRightTex = Content.Load<Texture2D>("images/BatRight");
            Texture2D scoreTex = Content.Load<Texture2D>("images/Scorebar");
            Texture2D NameFormTex = Content.Load<Texture2D>("images/Enter-Name");
            Texture2D pixel = new Texture2D(GraphicsDevice, 1, 1);
            //--------Load-----Sounds--------------
            SoundEffect dingSound = Content.Load<SoundEffect>("sounds/ding");
            clickSound = Content.Load<SoundEffect>("sounds/click");
            SoundEffect clapSound = Content.Load<SoundEffect>("sounds/applause1");
            //----------Load-------Fonts-------------
            font = Content.Load<SpriteFont>("fonts/MyFont");

            //---------Set------Positions--------------------
            
           Vector2 stage = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            Vector2 ScorePos = new Vector2(0, stage.Y - scoreTex.Height);
            Vector2 BatLeftPos = new Vector2(0, ((stage.Y - scoreTex.Height) / 2) -(batLeftTex.Height/2));
           Vector2 BatRightPos = new Vector2(stage.X - batRightTex.Width, ((stage.Y - scoreTex.Height) / 2) - (batRightTex.Height/2));
           Vector2 BallPos = new Vector2((stage.X / 2 -(ballTex.Width/2)), ((stage.Y - scoreTex.Height) / 2) - (ballTex.Height/2));
           Vector2 NameFormPos = new Vector2((stage.X/2-(NameFormTex.Width/2)),((stage.Y-scoreTex.Height)/2)- (NameFormTex.Height/2));

           string message = "Player 1: {0}  Score:{1}";
            Vector2 stringLeftDimension = font.MeasureString(message);
            Vector2 StringLeftPos = new Vector2(0, ScorePos.Y - stringLeftDimension.Y);
            Vector2 stringRightDimension = font.MeasureString(message);
            Vector2 StringRightPos = new Vector2(stage.X - stringRightDimension.X, ScorePos.Y - stringRightDimension.Y);
            //-------Create-------Ball----------------------
            Random r = new Random();
            float Xaxis = (float)(r.Next(3, 9));
            int direction = r.Next(0, 2);
            if (direction == 1)
            {
                Xaxis = -Xaxis;
            }
            float Yaxis = (float)(r.Next(3, 9));
            direction = r.Next(0, 2);
            if (direction == 1)
            {
                Yaxis = -Yaxis;
            }
            Vector2 speedBall = new Vector2(Xaxis, Yaxis);
            ball = new Ball(this, spriteBatch, ballTex, BallPos, speedBall, new Vector2(stage.X,stage.Y - scoreTex.Height),clickSound);
            this.Components.Add(ball);
            //-------Create-------BatLeft-------------------
            bat1 = new Bat(this, spriteBatch, batLeftTex, BatLeftPos, speed, new Vector2(stage.X,stage.Y - scoreTex.Height), "Left");
            this.Components.Add(bat1);
            //-------Create-------BatRight------------------
            bat2 = new Bat(this, spriteBatch, batRightTex, BatRightPos, speed, new Vector2(stage.X, stage.Y - scoreTex.Height), "Right");
            this.Components.Add(bat2);
            //-------Create-------ScoreBoard--------------------
            sb = new ScoreBoard(this, spriteBatch, scoreTex, ScorePos, stage);
            this.Components.Add(sb);
            //-------Create-------SimpleString Player1--------------------
            player1 = new SimpleString(this, spriteBatch, message, "", StringLeftPos, Color.Black, font, stringLeftDimension);
            this.Components.Add(player1);
            //-------Create-------SimpleString Player2--------------------
            player2 = new SimpleString(this, spriteBatch, message, "", StringLeftPos, Color.Black, font, stringRightDimension);
            this.Components.Add(player2);
            //-------Create-------CollisionManager----------
            cm = new CollisionManager(this, bat1, bat2, ball, player1,player2, dingSound, clapSound, clickSound, sb, stage);
            this.Components.Add(cm);
            //-------Create-------NameForm------------------
            nameForm = new NameForm(this, spriteBatch, NameFormTex, NameFormPos, stage, font, player1, player2,pixel, cm);
            this.Components.Add(nameForm);
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
            Texture2D scoreTex = Content.Load<Texture2D>("images/Scorebar");
            Vector2 stage = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            KeyboardState ks = Keyboard.GetState();
            Texture2D ballTex = Content.Load<Texture2D>("images/Ball");
            Vector2 BallPos = new Vector2((stage.X / 2 - (ballTex.Width / 2)), ((stage.Y - scoreTex.Height) / 2) - (ballTex.Height / 2));
            player1.Message = string.Format("  Player 1: {0} \n  Score:{1}  ", player1.Name, cm.ScoreLeft);
            player2.Message = string.Format("  Player 2: {0} \n  Score:{1}  ", player2.Name, cm.ScoreRight);
            player1.Dimension = font.MeasureString(player1.Message);
            player2.Dimension = font.MeasureString(player2.Message);
            player1.Position = new Vector2(0, stage.Y - scoreTex.Height );
            player2.Position = new Vector2(stage.X - player2.Dimension.X, stage.Y - scoreTex.Height);

            if (cm.ScoreLeft < MAX_SCORE && cm.ScoreRight < MAX_SCORE)
            {
                if (ks.IsKeyDown(Keys.Enter) && (cm.CreateBall == true) && cm.NameFormIsVisible == false)
                {
                    cm.CreateBall = false;
                    Random r = new Random();
                    float Xaxis = (float)(r.Next(3, 9));
                    int direction = r.Next(0, 2);
                    if (direction == 1)
                    {
                        Xaxis = -Xaxis;
                    }
                    float Yaxis = (float)(r.Next(3, 9));
                    direction = r.Next(0, 2);
                    if (direction == 1)
                    {
                        Yaxis = -Yaxis;
                    }
                    Vector2 speedBall = new Vector2(Xaxis, Yaxis);
                    ball = new Ball(this, spriteBatch, ballTex, BallPos, speedBall, new Vector2(stage.X, stage.Y - scoreTex.Height),clickSound);
                    this.Components.Add(ball);
                    cm.addBall(ball);
                    cm.clearBalls();
                }
            }
            else
            {
                if (cm.ScoreLeft == MAX_SCORE)
                {
                    player1.Message = string.Format("Player 1: {0} is the Winner", player1.Name);
                    player1.Dimension = font.MeasureString(player1.Message);
                    player1.Position = new Vector2(0, stage.Y - scoreTex.Height + player1.Dimension.Y);
                    player2.Message = "";

                }
                else if (cm.ScoreRight == MAX_SCORE)
                {
                    player2.Message = string.Format("Player 2: {0} is the Winner", player2.Name);
                    player2.Dimension = font.MeasureString(player2.Message);
                    player2.Position = new Vector2(0, stage.Y - scoreTex.Height + player2.Dimension.Y);
                    player1.Message = "";
                }
                if (ks.IsKeyDown(Keys.Space))
                {
                    cm.ScoreLeft = 0;
                    cm.ScoreRight = 0;
                    bat1.Position = new Vector2(0, (((stage.Y - scoreTex.Height )/ 2) - bat1.Tex.Height/2));
                    bat2.Position = new Vector2(stage.X - bat2.Tex.Width, (((stage.Y - scoreTex.Height) / 2) - bat2.Tex.Height/2));
                }
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        { 
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
       
    }
}
