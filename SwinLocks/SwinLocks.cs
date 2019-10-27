using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SwinLocks
{
    public class SwinLocks : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch sb;
        GameState state;

        public SwinLocks()
        {
            graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            new GameContext();

            graphics.PreferredBackBufferWidth = Constants.SCREEN_X;
            graphics.PreferredBackBufferHeight = Constants.SCREEN_Y;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            sb = new SpriteBatch(GraphicsDevice);

            //Resources.player = Content.Load<Texture2D>("circle");
            Resources.player = Content.Load<Texture2D>("player");
            Resources.pillar = Content.Load<Texture2D>("pillar");
            Resources.fireball = Content.Load<Texture2D>("fireball");
            Resources.lightning = Content.Load<Texture2D>("lightning");
            Resources.particle = Content.Load<Texture2D>("particle");
            Resources.meteor = Content.Load<Texture2D>("meteor");

            Resources.font = Content.Load<SpriteFont>("font");

            state = new GameplayState(sb);
        }

        protected override void UnloadContent() {}

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

            Input.update();
            state.update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            sb.Begin();
            state.render(sb);
            sb.End();

            base.Draw(gameTime);
        }
    }
}
