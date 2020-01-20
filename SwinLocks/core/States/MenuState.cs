using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SwinLocks
{
    class MenuState : GameState
    {
        Vector2 splashPos;
        Vector2 splashOrigin;
        List<Vector2> playerPos;
        List<Rectangle> playerSource;
        Vector2 stringPos;
        Vector2 playerOrigin;
        int clock;
        int clockCycle;
        public MenuState() {
            splashPos = new Vector2(Constants.SCREEN_X / 2, Constants.SCREEN_Y / 4);
            stringPos = new Vector2(Constants.SCREEN_X / 2 - 150, 3 * Constants.SCREEN_Y / 4);
            splashOrigin = new Vector2(Resources.splash.Width / 2, Resources.splash.Height / 2);
            playerPos = new List<Vector2>();
            for ( int i = 0; i < 4; i++ )
                playerPos.Add(new Vector2( (i + 1) * Constants.SCREEN_X / 5, Constants.SCREEN_Y / 2));
            playerSource = new List<Rectangle>() {
                new Rectangle(0, 0, Constants.PLAYER_PILLAR, Constants.PLAYER_PILLAR),
                new Rectangle(0, 100, Constants.PLAYER_PILLAR, Constants.PLAYER_PILLAR),
                new Rectangle(0, 200, Constants.PLAYER_PILLAR, Constants.PLAYER_PILLAR),
                new Rectangle(0, 300, Constants.PLAYER_PILLAR, Constants.PLAYER_PILLAR)
            };
            playerOrigin = new Vector2( Constants.PLAYER_PILLAR / 2, Constants.PLAYER_PILLAR / 2);

            clock = 0;
            clockCycle = 10;

            MediaPlayer.Play(Resources.menu);
        }
        public override void update() {
            if ( Input.keyPressed(Keys.Space) )
                SwinLocks.state = new GameplayState(SwinLocks.sb);

            if ( clock++ == clockCycle ) {
                for ( int i = 0; i < 4; i++ )
                    playerSource[i] = new Rectangle((playerSource[i].X + 100) % 800,
                        playerSource[i].Y, playerSource[i].Width, playerSource[i].Height);
                clock = 0;
            }
        }

        public override void render(SpriteBatch sb) {
            sb.Draw(Resources.splash, splashPos, null, Color.White, 0f, splashOrigin, 3f, SpriteEffects.None, 0f);
            for ( int i = 0; i < 4; i++ )
                sb.Draw(Resources.player, playerPos[i], playerSource[i], Color.White, 0f, playerOrigin, 2f, SpriteEffects.None, 0f);
            sb.DrawString(Resources.font, "SPACE TO START", stringPos, Color.Black);
        }
    }
}
