//CBAssignment4
//Pong in Monogame

//Ball Class

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
/// the defines the ball class
/// </summary>
    class Ball : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 speed;
        private Vector2 stage;
        private SoundEffect click;
        /// <summary>
        /// gets and sets the speed of the ball
        /// </summary>
        public Vector2 Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }
        /// <summary>
        /// gets and sets the position of the ball;
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public Vector2 Speed1
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }

        /// <summary>
        /// the constructor for the ball
        /// </summary>
        /// <param name="game">the current game</param>
        /// <param name="spriteBatch">the current spritebatch</param>
        /// <param name="tex">texture file of ball</param>
        /// <param name="position">position of the ball</param>
        /// <param name="speed">speed of the ball</param>
        /// <param name="stage">boundary of the games playable area</param>
        /// <param name="click">sound effect for collisions</param>
        public Ball(Game game,SpriteBatch spriteBatch, Texture2D tex, Vector2 position, Vector2 speed, Vector2 stage,SoundEffect click) : base(game)
        {
           
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.speed = speed;
            this.stage = stage;
            this.click = click;
        }
        /// <summary>
        /// overides the intialize method
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }
        /// <summary>
        /// updates the ball
        /// </summary>
        /// <param name="gameTime">current timespan of game</param>
        public override void Update(GameTime gameTime)
        {
            position += speed;
           
            //top wall
            if (position.Y < 0)
            {
                speed.Y = Math.Abs(speed.Y);
                click.Play();
            }

            //bottom wall
            if (position.Y + tex.Height >= stage.Y)
            {
                click.Play();
                speed.Y = -Math.Abs(speed.Y);
            }

            //bottom wall with collision manager
            //if (position.Y > stage.Y)
            //{
            //    this.position = Vector2.Zero;
            //    this.Enabled = false;
            //    this.Visible = false;
            //}


            //right wall
            if (position.X + tex.Width > stage.X)
            {

                // speed.X = -Math.Abs(speed.X);
                // this.position = new Vector2(stage.X / 2 - tex.Width / 2, stage.Y / 2 - tex.Height / 2);
                // this.speed = new Vector2(0, 0);
                // this.Enabled = false;
                // this.Visible = false;


            }

            //LEFT WALL 
            if (position.X < 0)
            {
                //speed.X = Math.Abs(speed.X);
                //this.position = new Vector2(stage.X / 2 - tex.Width / 2, stage.Y / 2 - tex.Height / 2);
                //this.speed = new Vector2(0, 0);
                //  this.Enabled = false;
                // this.Visible = false;
            }
            
            base.Update(gameTime);
        }
        /// <summary>
        /// draws the ball
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        /// <summary>
        /// gets the boundary of the ball
        /// </summary>
        /// <returns>ball's boundary</returns>
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }
    }
}
