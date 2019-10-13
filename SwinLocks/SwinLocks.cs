using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SwinLocks.utils;
using SwinLocks.core;
using SwinLocks.ecs;

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
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            state = new GameplayState();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            sb = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

            Input.Update();
            if ( Input.KeyPressed(Keys.Up) )
                System.Console.WriteLine("Up Pressed");
            // TODO: Add your update logic here
            state.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            state.Render(sb);
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
