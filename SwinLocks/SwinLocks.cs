using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

namespace SwinLocks
{
    public class SwinLocks : Game
    {
        private GraphicsDeviceManager graphics;
        public static SpriteBatch sb;
        public static GameState state;

        public SwinLocks()
        {
            graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize() {
            new GameContext();

            graphics.PreferredBackBufferWidth = Constants.SCREEN_X;
            graphics.PreferredBackBufferHeight = Constants.SCREEN_Y;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            sb = new SpriteBatch(GraphicsDevice);

            Resources.player = Content.Load<Texture2D>("player");
            Resources.pillar = Content.Load<Texture2D>("pillar");
            Resources.fireball = Content.Load<Texture2D>("fireball");
            Resources.lightning = Content.Load<Texture2D>("lightning");
            Resources.particle = Content.Load<Texture2D>("particle");
            Resources.abilitySlot = Content.Load<Texture2D>("ability_slot");
            Resources.healthbar = Content.Load<Texture2D>("health_bar");
            Resources.splash = Content.Load<Texture2D>("splash");
            Resources.winner = Content.Load<Texture2D>("winner");

            Resources.font = Content.Load<SpriteFont>("font");

            Resources.shootFireball = Content.Load<SoundEffect>("fireball_shoot");
            Resources.explode = Content.Load<SoundEffect>("explosion");
            Resources.shootGravity = Content.Load<SoundEffect>("gravity_shoot");
            Resources.blink = Content.Load<SoundEffect>("blink");
            Resources.menu = Content.Load<Song>("menu");
            Resources.gameplay = Content.Load<Song>("gameplay");

            state = new MenuState();
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
