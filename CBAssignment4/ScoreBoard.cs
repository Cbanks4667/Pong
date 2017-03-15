//CBAssignment4
//Pong in Monogame

//Scoreboard Class

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

namespace CBAssignment4
{
/// <summary>
/// defines the scoreboard class
/// </summary>
    class ScoreBoard : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 stage;
        /// <summary>
        /// the scoreboard constructor
        /// </summary>
        /// <param name="game">the current game</param>
        /// <param name="spriteBatch">the current spritebatch</param>
        /// <param name="tex">the texture file for the scoreboard</param>
        /// <param name="position">the position of the string</param>
        /// <param name="stage">the size of the window</param>
        public ScoreBoard(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 position, Vector2 stage) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.stage = stage;
        }
        /// <summary>
        /// overides the intialize method
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }
        /// <summary>
        /// updates the scoreboard
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        /// <summary>
        /// draws the scoreboard
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            this.spriteBatch.Begin();
            this.spriteBatch.Draw(tex, position, Color.White);
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
        /// <summary>
        /// gets the boundary of the scorebord
        /// </summary>
        /// <returns></returns>
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }
    }
}
