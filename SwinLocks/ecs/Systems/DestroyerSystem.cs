﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class DestroyerSystem : System {
        public override void Execute() {
            List<Entity> entsToDestroy = new List<Entity>();
            List<CollisionEvent> events = GameContext.I.collRegister
                .query<DestructorComponent, DestructibleComponent>().toList();

            foreach (CollisionEvent e in events) {
                if ( e.e1.has<DestructibleComponent>() && !entsToDestroy.Contains(e.e1) )
                    entsToDestroy.Add(e.e1);

                if ( e.e2.has<DestructibleComponent>() && !entsToDestroy.Contains(e.e2) )
                    entsToDestroy.Add(e.e2);
            }

            List<Entity> ents = GameContext.I.entities.Where( e => e.has<HealthComponent>() ).ToList();
            foreach (Entity e in ents) {
                HealthComponent h = e.get<HealthComponent>();
                if ( h.health <= 0 && !entsToDestroy.Contains(e) )
                    entsToDestroy.Add(e);
            }

            foreach (Entity e in entsToDestroy) {
                GameContext.I.entities.Remove(e);
            }
        }
    }
}
