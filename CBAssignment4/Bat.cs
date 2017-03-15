//CBAssignment4
//Pong in Monogame

//Bat Class
 
//Revision History
//Created: Chris Banks Nov.5th 2016
//

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBAssignment4

{/// <summary>
/// defines the bat class
/// </summary>
    class Bat : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private float speed;
        private Vector2 stage;
        private string player;
        /// <summary>
        /// Gets and Sets the position of the bat
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
        //gets the texture of the bat
        public Texture2D Tex
        {
            get
            {
                return tex;
            }


        }

        public float Speed
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
        /// contstructor for Bat class
        /// </summary>
        /// <param name="game">current game</param>
        /// <param name="spriteBatch">current spritebatch</param>
        /// <param name="tex">texture of bat</param>
        /// <param name="position">position of bat</param>
        /// <param name="speed">bat speed</param>
        /// <param name="stage">bounds of game</param>
        /// <param name="player">references current player of bat</param>
        public Bat(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 position,
            float speed, Vector2 stage, string player) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.speed = speed;
            this.stage = stage;
            this.player = player;
        }
        /// <summary>
        /// overides the initialize method
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }
        /// <summary>
        /// updates the bat position
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();

            if (player == "Left")
            {
                if (ks.IsKeyDown(Keys.A))
                {
                    position.Y -= speed;
                }
                if (ks.IsKeyDown(Keys.Z))
                {
                    position.Y += speed;
                }
                if (position.X + tex.Width > stage.X)
                {
                    position.X = stage.X - tex.Width;
                }
                if (position.Y + tex.Height > stage.Y)
                {
                    position.Y = stage.Y - tex.Height;
                }
                if (position.Y < 0)
                {
                    position.Y = 0;
                }
                if (position.X < 0)
                {
                    position.X = 0;
                }
            }
            else if (player == "Right")
            {
                if (ks.IsKeyDown(Keys.Up))
                {
                    position.Y -= speed;
                }
                if (ks.IsKeyDown(Keys.Down))
                {
                    position.Y += speed;
                }
                if (ks.IsKeyDown(Keys.Right))
                {
                    position.X += speed;
                }
                if (ks.IsKeyDown(Keys.Left))
                {
                    position.X -= speed;
                }
                if (position.X + tex.Width > stage.X)
                {
                    position.X = stage.X - tex.Width;
                }
                if (position.Y + tex.Height > stage.Y)
                {
                    position.Y = stage.Y - tex.Height;
                }
                if (position.Y < 0)
                {
                    position.Y = 0;
                }
                if (position.X < stage.X / 2 + tex.Width / 2)
                {
                    position.X = stage.X / 2 + tex.Width / 2;
                }
            }


            base.Update(gameTime);
        }
        /// <summary>
        /// draws the bat
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
        /// gets the dimensions and position of bat
        /// </summary>
        /// <returns>returns the bat position in game</returns>
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }
    }
}
