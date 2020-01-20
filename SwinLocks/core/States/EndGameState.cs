using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SwinLocks {
    class EndGameState : GameState {
        Entity e;
        Random rand;
        Vector2 winnerPos;
        Vector2 winnerOrigin;
        Vector2 stringPos;
        List<Entity> explodies;

        public EndGameState(Entity e) {
            this.e = e;
            e.detach<ControllableComponent>();
            SpatialComponent s = e.get<SpatialComponent>();
            s.pos = new Vector2(Constants.SCREEN_X / 2, Constants.SCREEN_Y / 2);
            s.rot = 0;
            stringPos = new Vector2(Constants.SCREEN_X / 2 - 370, 3 * Constants.SCREEN_Y / 4);
            winnerPos = new Vector2(Constants.SCREEN_X / 2, Constants.SCREEN_Y / 4);
            winnerOrigin = new Vector2(Resources.winner.Width / 2, Resources.winner.Height / 2);
            rand = new Random();
            explodies = new List<Entity>();
        }
        public override void update() {
            if ( Input.keyPressed(Keys.Space) )
                SwinLocks.state = new MenuState();

            SpatialComponent s;
            for ( int i = explodies.Count - 1; i > -1; i-- ) {
                s = explodies[i].get<SpatialComponent>();
                s.pos += s.vel;
                if ( explodies[i].get<DecayComponent>().ttl-- == -30 )
                    explodies.RemoveAt(i);
            }
            if ( rand.Next(30) == 0 ) {
                Vector2 v = new Vector2(rand.Next(Constants.SCREEN_X), rand.Next(Constants.SCREEN_Y));
                for ( int i = 0; i < 15; i++ )
                    explodies.Add( EntityFactory.particle(v) );
            }
        }
        public override void render(SpriteBatch sb) {
            sb.Draw(Resources.winner, winnerPos, null, Color.White, 0f, winnerOrigin, 1f, SpriteEffects.None, 0f);
            RenderableComponent r = e.get<RenderableComponent>();
            SpatialComponent s = e.get<SpatialComponent>();
            sb.Draw(r.tex, s.pos, r.offset, Color.White, 0f, s.origin, 2f, SpriteEffects.None, 0f);
            foreach ( Entity p in explodies ) {
                r = p.get<RenderableComponent>();
                s = p.get<SpatialComponent>();
                sb.Draw(r.tex, s.pos, r.offset, r.col, 0f, s.origin, 2f, SpriteEffects.None, 0f);
            }
            sb.DrawString(Resources.font, "SPACE TO RETURN, ESC TO END", stringPos, Color.Black);
        }
    }
}
