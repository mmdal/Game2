using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpliteAnimation charSprite;
        Texture2D attackAni;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            charSprite = new SpliteAnimation(Content, "1.png", 100f, 3, 1, 3, true);
            attackAni = Content.Load<Texture2D>("2.png");
            // TODO: use this.Content to load your game content here
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

            int OffsetX = 0;
            int OffsetY = 0;

            if ( Keyboard.GetState().IsKeyDown( Keys.Right ) )
            {
                OffsetX = 1;
            }
            else if ( Keyboard.GetState().IsKeyDown(Keys.Left) )
            {
                OffsetX = -1;
            }
            if ( Keyboard .GetState().IsKeyDown( Keys.Up ) )
            {
                OffsetY = -1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                OffsetY = 1;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                charSprite.Animation = attackAni;
            }
            else charSprite.SetBase();

            charSprite.Position = new Vector2(charSprite.Position.X + OffsetX, charSprite.Position.Y + OffsetY);


            // TODO: Add your update logic here
            charSprite.PlayAnitmation(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            charSprite.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
