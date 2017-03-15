//CBAssignment4
//Pong in Monogame

//SimpleString Class

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
    /// defines the simple string class
    /// </summary>
    class SimpleString : DrawableGameComponent
    {
        protected SpriteBatch spriteBatch;
        private string message;
        private string name;
        private Vector2 position;
        protected Color color;
        protected SpriteFont font;
        private Vector2 dimension;
        /// <summary>
        /// gets and sets the text of the message to be displayed
        /// </summary>
        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }
        /// <summary>
        /// gets and sets the position of the message to be displayed
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
        /// <summary>
        /// gets / sets the dimensions of the text
        /// </summary>
        public Vector2 Dimension
        {
            get
            {
                return dimension;
            }

            set
            {
                dimension = value;
            }
        }
        /// <summary>
        /// gets and sets the name of the current player
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        /// <summary>
        /// the simple string contstructor
        /// </summary>
        /// <param name="game">the current game</param>
        /// <param name="spriteBatch">the current spritebatch</param>
        /// <param name="message">the message to be displayed</param>
        /// <param name="name">the name of the player</param>
        /// <param name="position">the position of the tex</param>
        /// <param name="color">the color of the text</param>
        /// <param name="font">the font style</param>
        /// <param name="dimension">the dimensions of the message</param>
        public SimpleString(Game game,SpriteBatch spriteBatch, string message, string name, Vector2 position, Color color, SpriteFont font, Vector2 dimension) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.message = message;
            this.name = name;
            this.position = position;
            this.color = color;
            this.font = font;
            this.dimension = dimension;
        }
        /// <summary>
        /// overided the initialize method
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }
        /// <summary>
        /// updates the string
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        /// <summary>
        /// draws the string 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(font, message, position, color);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
