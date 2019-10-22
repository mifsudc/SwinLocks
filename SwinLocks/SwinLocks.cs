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

            graphics.PreferredBackBufferWidth = 1920;//3840;//1920;
            graphics.PreferredBackBufferHeight = 1080;//2160;//1080;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            sb = new SpriteBatch(GraphicsDevice);

            Resources.player = Content.Load<Texture2D>("circle");
            Resources.pillar = Content.Load<Texture2D>("pillar");
            Resources.fireball = Content.Load<Texture2D>("fireball");
            Resources.lightning = Content.Load<Texture2D>("lightning");

            state = new GameplayState(sb);
        }

        protected override void UnloadContent()
        {
        }

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
