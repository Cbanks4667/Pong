//CBAssignment4
//Pong in Monogame

//NameForm Class

//Revision History
//Created: Chris Banks Nov.6th 2016
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
    class NameForm : DrawableGameComponent
    {
        private SimpleString player1;
        private SimpleString player2;
        private CollisionManager cm;
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 stage;
        private Rectangle txtName; 
        private Rectangle btnName;
        private SpriteFont font;
        private string name = "";
        private char letter;
        private bool getLetter = true;
        Texture2D pixel; 
        Color[] colorData ={Color.White};
        private int setName =1;
        private int counter;

        public int SetName
        {
            get
            {
                return setName;
            }

            set
            {
                setName = value;
            }
        }

        public NameForm(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 position, Vector2 stage, SpriteFont font,SimpleString player1, SimpleString player2, Texture2D pixel, CollisionManager cm) : base(game)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.stage = stage;
            this.font = font;
            this.pixel = pixel;
            this.cm = cm;
        }
        public override void Initialize()
        {
            
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
           
            KeyboardState ks = Keyboard.GetState();
            MouseState ms = Mouse.GetState();
            
            var keys = ks.GetPressedKeys();
            List<char> letters = new List<char>();
            var keyValue = Keys.Add;

            txtName = new Rectangle((int)stage.X / 2 - 30, (int)stage.Y / 2 - 52, 105, 21);
            btnName = new Rectangle(txtName.X - 10, txtName.Y + 40, 75, 21);
            if (setName < 3)
            {
                if (letters.Count == 0 && getLetter == true && counter > 10)
                {
                    if (keys.Any() && !ks.IsKeyDown(Keys.Back) && !ks.IsKeyDown(Keys.Enter))
                    {
                        getLetter = false;
                        if (keys.Length > 0)
                        {
                            keyValue = keys[0];

                            try
                            {
                                letter = Char.Parse(keyValue.ToString());
                                letters.Add(letter);
                                name += letters[0].ToString().ToLower();
                                counter = 0;
                                //letters.Clear();
                            }
                            catch (Exception)
                            {

                                //throw;
                            }

                        }

                    }
                    else if (keys.Any() && ks.IsKeyDown(Keys.Back))
                    {
                        int namelength = name.Length;
                        if (namelength > 0)
                        {
                            name = name.Substring(0, namelength - 1);
                            counter = 0;
                        }

                    }
                    else if (btnName.Contains(ms.X,ms.Y) && ms.LeftButton == ButtonState.Pressed)
                    {
                        cm.StartOfGame = "true";
                        if (name.Length > 0)
                        {
                            if (setName == 1)
                            {
                                player1.Name = name;
                                name = "";
                                setName++;
                                counter = 0;
                            }
                            else
                            {
                                player2.Name = name;
                                setName++;
                                counter = 0;
                            }
                        }

                    }
                }
              

                if (ks.IsKeyUp(keyValue))
                {
                    letters.Clear();
                    getLetter = true;
                    counter++;
                } 
            }
            else if (setName > 2)
            {
                if (ks.IsKeyDown(Keys.Enter))
                {
                    setName++;
                }
                this.Visible = false;
                cm.NameFormIsVisible = false;
                
            }
           




            
            pixel.SetData<Color>(colorData);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex,position,Color.White);
            spriteBatch.Draw(pixel, txtName, Color.White);
            //spriteBatch.Draw(pixel, btnName, Color.Purple);
            spriteBatch.DrawString(font, name.ToLower(), new Vector2(stage.X / 2 - 30, stage.Y / 2 - 52), Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
   
}

// Make a 1x1 texture named pixel.  
