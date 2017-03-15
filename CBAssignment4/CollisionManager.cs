//CBAssignment4
//Pong in Monogame

//Collision Manager Class

//Revision History
//Created: Chris Banks Nov.5th 2016
//


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
namespace CBAssignment4
{
    /// <summary>
    /// defines the collisionmanager class
    /// </summary>
    class CollisionManager : GameComponent
    {
        private Bat bat1;
        private Bat bat2;
        private List<Ball> ball;
        private int scoreLeft = 0;
        private int scoreRight = 0;
        private SoundEffect ding;
        private SoundEffect clap;
        private SoundEffect click;
        private ScoreBoard sb;
        private Vector2 stage;
        SimpleString player1;
        SimpleString player2;
        private bool createBall;
        private string startOfGame = "true";
        private bool nameFormIsVisible = true;
        /// <summary>
        /// gets and sets the score for player 1
        /// </summary>
        public int ScoreLeft
        {
            get
            {
                return scoreLeft;
            }

            set
            {
                scoreLeft = value;
            }
        }
        /// <summary>
        /// gets and sets the score for player 2
        /// </summary>
        public int ScoreRight
        {
            get
            {
                return scoreRight;
            }

            set
            {
                scoreRight = value;
            }
        }
        /// <summary>
        /// determines if a new ball should be created
        /// </summary>
        public bool CreateBall
        {
            get
            {
                return createBall;
            }

            set
            {
                createBall = value;
            }
        }
        /// <summary>
        /// gets and sets the start of the game
        /// </summary>
        public string StartOfGame
        {
            get
            {
                return startOfGame;
            }

            set
            {
                startOfGame = value;
            }
        }

        public string StartOfGame1
        {
            get
            {
                return startOfGame;
            }

            set
            {
                startOfGame = value;
            }
        }

        public bool NameFormIsVisible
        {
            get
            {
                return nameFormIsVisible;
            }

            set
            {
                nameFormIsVisible = value;
            }
        }

        /// <summary>
        /// The Constructor for the collision manager
        /// </summary>
        /// <param name="game">the current game</param>
        /// <param name="bat1">player 1's bat</param>
        /// <param name="bat2">plater 2's bat</param>
        /// <param name="ball">the ball in play</param>
        /// <param name="player1">player 1's text</param>
        /// <param name="player2">player 2's text</param>
        /// <param name="ding">ding sound effect</param>
        /// <param name="clap">clap sound effect</param>
        /// <param name="click">click sound effect</param>
        /// <param name="sb">the scoreboard</param>
        /// <param name="stage">the playable area </param>
        public CollisionManager(Game game, Bat bat1, Bat bat2, Ball ball,SimpleString player1,SimpleString player2,SoundEffect ding, SoundEffect clap, SoundEffect click, ScoreBoard sb, Vector2 stage) : base(game)
        {
            this.bat1 = bat1;
            this.bat2 = bat2;
            this.ball = new List<Ball>();
            this.ball.Add(ball);
            this.ding = ding;
            this.clap = clap;
            this.click = click;
            this.player1 = player1;
            this.player2 = player2;
            this.sb = sb;
            this.stage = stage;
        }
        /// <summary>
        /// overides the initialize method
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }
        /// <summary>
        /// updates and does collision logic
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (player2.Name == "computer")
            {
                if (ball[0].Speed.Y > 0)
                {
                    bat2.Position = new Vector2(bat2.Position.X, bat2.Position.Y + bat2.Speed);
                }
                else
                {
                    bat2.Position = new Vector2(bat2.Position.X, bat2.Position.Y - bat2.Speed);
                }
            }
            if (player1.Name == "computer")
            {
                if (ball[0].Speed.Y > 0)
                {
                    bat1.Position = new Vector2(bat1.Position.X, bat1.Position.Y + bat1.Speed);
                }
                else
                {
                    bat1.Position = new Vector2(bat1.Position.X, bat1.Position.Y - bat1.Speed);
                }
            }
            

            KeyboardState ks = Keyboard.GetState();
            if (StartOfGame == "true")
            {
                ball[0].Enabled = false;
               StartOfGame = "false";
            }
            else if(StartOfGame == "false")
            {
                if (ks.IsKeyDown(Keys.Enter) && nameFormIsVisible ==false)
                {
                   
                        StartOfGame = "";
                    ball[0].Enabled = true;
                }
            }
            //else if (StartOfGame =="")
            //{
               
            //    if (ks.IsKeyDown(Keys.Enter) && nameFormIsVisible == false)
            //    {
                    
            //      //  StartOfGame = "";

            //    }
            //}
            Rectangle leftBatRect = bat1.getBounds();
            Rectangle rightBatRect = bat2.getBounds();
            Rectangle ballRect = ball[0].getBounds();
            Rectangle scoreBoardRect = sb.getBounds();
            if (ball[0].Position.X + ball[0].getBounds().Width > stage.X)
            {
                if (CreateBall == false)
                {
                    ScoreLeft++;
                    ding.Play();
                    if (scoreLeft ==2 )
                    {
                        createBall = false;
                        clap.Play();
                    }
                }
                ball[0].Position = new Vector2(stage.X / 2 - ball[0].getBounds().Width / 2, (stage.Y - scoreBoardRect.Height) / 2 - ball[0].getBounds().Height / 2);
               // ball[0].Speed = new Vector2
                ball[0].Enabled = false;         
                //this.Dispose();
                CreateBall = true;
            }
            if (ball[0].Position.X < 0)
            {
                if (CreateBall == false)
                {
                    ScoreRight++;
                    ding.Play();
                    if (ScoreRight ==2)
                    {
                        createBall = false;
                        clap.Play();
                    }
                }
                ball[0].Position = new Vector2(stage.X / 2 - ball[0].getBounds().Width / 2, (stage.Y - scoreBoardRect.Height) / 2 - ball[0].getBounds().Height / 2);
                ball[0].Enabled = false;
                CreateBall = true;
            }
            if (ballRect.Intersects(leftBatRect))
            { 
                ball[0].Speed = new Vector2(Math.Abs(ball[0].Speed.X), ball[0].Speed.Y);
                click.Play();
            }
            if (ballRect.Intersects(rightBatRect))
            {
                ball[0].Speed = new Vector2(-Math.Abs(ball[0].Speed.X), ball[0].Speed.Y);
                click.Play();
            }

            base.Update(gameTime);
        }
        /// <summary>
        /// adds new ball to list
        /// </summary>
        /// <param name="ball"></param>
        public void addBall(Ball ball)
        {
            this.ball.Insert(0, ball);
        }
        /// <summary>
        /// makes all balls but current ball invisible
        /// </summary>
        public void clearBalls()
        {
            for (int i = 1; i < ball.Count; i++)
            {
                ball[i].Visible = false;
            }
        }
    }
}
