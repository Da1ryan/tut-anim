using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace tut_anim
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D tribbleGreyTexture, tribbleOrangeTexture, tribbleCreamTexture, tribbleBrownTexture;
        Color bgColour;
        SoundEffect tribbleCoo;
        Texture2D tribbleBackground, tribbleBackgroundBrown, tribbleBackgroundCream, tribbleBackgroundGrey, tribbleBackgroundOrange;
        Rectangle bgRect;
        Rectangle greyTribbleRect, brownTribbleRect, orangeTribbleRect, creamTribbleRect;
        Vector2 tribbleGreySpeed, tribbleBrownSpeed, tribbleOrangeSpeed, tribbleCreamSpeed;
        Screen screen;
        enum Screen
        {
            title,
            animation
        }
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
            greyTribbleRect = new Rectangle(200, 100, 100, 100);
            brownTribbleRect = new Rectangle(305, 20, 100, 100);
            orangeTribbleRect = new Rectangle(107, 210, 100, 100);
            creamTribbleRect = new Rectangle(270, 330, 100, 100);
            bgRect = new(0, 0, 800, 600);

            tribbleGreySpeed = new Vector2(-2, 2);
            tribbleBrownSpeed = new Vector2(0, 2);
            tribbleOrangeSpeed = new Vector2(1, 3);
            tribbleCreamSpeed = new Vector2(2, 0);

            screen = Screen.title;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleBackground = Content.Load<Texture2D>("TribbleCrowd");
            tribbleBackgroundBrown = Content.Load<Texture2D>("TribbleCrowdBrown");
            tribbleBackgroundCream = Content.Load<Texture2D>("TribbleCrowdCream");
            tribbleBackgroundGrey = Content.Load<Texture2D>("TribbleCrowdGrey");
            tribbleBackgroundOrange = Content.Load<Texture2D>("TribbleCrowdOrange");
            tribbleCoo = Content.Load<SoundEffect>("tribble_coo");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (screen == Screen.title)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    screen = Screen.animation;
            }
            else if (screen == Screen.animation)
            {
                greyTribbleRect.X += (int)tribbleGreySpeed.X;
                greyTribbleRect.Y += (int)tribbleGreySpeed.Y;
                brownTribbleRect.X += (int)tribbleBrownSpeed.X;
                brownTribbleRect.Y += (int)tribbleBrownSpeed.Y;
                orangeTribbleRect.X += (int)tribbleOrangeSpeed.X;
                orangeTribbleRect.Y += (int)tribbleOrangeSpeed.Y;
                creamTribbleRect.X += (int)tribbleCreamSpeed.X;
                creamTribbleRect.Y += (int)tribbleCreamSpeed.Y;

                if (greyTribbleRect.Right >= _graphics.PreferredBackBufferWidth || greyTribbleRect.Left < 0)
                {
                    tribbleGreySpeed.X *= -1;
                    tribbleBackground = tribbleBackgroundGrey;
                    tribbleCoo.Play();
                }

                if (brownTribbleRect.Right >= _graphics.PreferredBackBufferWidth || brownTribbleRect.Left < 0)
                {
                    tribbleBrownSpeed.X *= 0;
                    tribbleBackground = tribbleBackgroundBrown;
                    tribbleCoo.Play();
                }

                if (orangeTribbleRect.Right >= _graphics.PreferredBackBufferWidth || orangeTribbleRect.Left < 0)
                {
                    tribbleOrangeSpeed.X *= -1;
                    tribbleBackground = tribbleBackgroundOrange;
                    tribbleCoo.Play();
                }

                if (creamTribbleRect.Right >= _graphics.PreferredBackBufferWidth || creamTribbleRect.Left < 0)
                {
                    tribbleCreamSpeed.X *= -1;
                    tribbleBackground = tribbleBackgroundCream;
                    tribbleCoo.Play();
                }


                if (greyTribbleRect.Bottom >= _graphics.PreferredBackBufferHeight || greyTribbleRect.Top < 0)
                {
                    tribbleGreySpeed.Y *= -1;
                    tribbleBackground = tribbleBackgroundGrey;
                    tribbleCoo.Play();
                }

                if (brownTribbleRect.Bottom >= _graphics.PreferredBackBufferHeight || brownTribbleRect.Top < 0)
                {
                    tribbleBrownSpeed.Y *= -1;
                    tribbleBackground = tribbleBackgroundBrown;
                    tribbleCoo.Play();
                }

                if (orangeTribbleRect.Bottom >= _graphics.PreferredBackBufferHeight || orangeTribbleRect.Top < 0)
                {
                    tribbleOrangeSpeed.Y *= -1;
                    tribbleBackground = tribbleBackgroundOrange;
                    tribbleCoo.Play();
                }

                if (creamTribbleRect.Bottom >= _graphics.PreferredBackBufferHeight || creamTribbleRect.Top < 0)
                {
                    tribbleCreamSpeed.Y *= 0;
                    tribbleBackground = tribbleBackgroundCream;
                    tribbleCoo.Play();
                }
            }
            
                

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(bgColour);
            
            _spriteBatch.Begin();
            if (screen == Screen.title)
            {
                _spriteBatch.Draw(tribbleBackground, bgRect, Color.White);

            }
            else if (screen == Screen.animation)
            {
                _spriteBatch.Draw(tribbleBackground, bgRect, Color.White);

                _spriteBatch.Draw(tribbleGreyTexture, greyTribbleRect, Color.White);
                _spriteBatch.Draw(tribbleBrownTexture, brownTribbleRect, Color.White);
                _spriteBatch.Draw(tribbleOrangeTexture, orangeTribbleRect, Color.White);
                _spriteBatch.Draw(tribbleCreamTexture, creamTribbleRect, Color.White);
            }
               
            
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}