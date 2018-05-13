using Microsoft.Xna.Framework;
using System;

namespace Movement {
    class PhysicsObject : RotatingSpriteGameObject{
        private readonly float radius;
        protected Vector2 acceleration;

        public PhysicsObject(string assetName, Vector2 position, Vector2 velocity, float radius, Vector2 acceleration)
            : base(assetName) {
            PerPixelCollisionDetection = false;
            Position = position;
            Velocity = velocity;
            Origin = Center;
            this.radius = radius;
            scale = radius * 2 / Width;
            Acceleration = acceleration;
        }

        public override void Update(GameTime gameTime) {
            if (position.X < radius) {
                position.X = radius;
                velocity.X *= -1f;
            }
            if (position.X > GameEnvironment.Screen.X - radius) {
                position.X = GameEnvironment.Screen.X - radius;
                velocity.X *= -1f;
            }
            if (position.Y < radius) {
                position.Y = radius;
                velocity.Y *= -1f;
            }
            if (position.Y > GameEnvironment.Screen.Y - radius) {
                position.Y = GameEnvironment.Screen.Y - radius;
                velocity.Y *= -1f;
            }

            Velocity += Acceleration;
            base.Update(gameTime);
        }

        public virtual Vector2 Acceleration {
            get { return acceleration; }
            set { acceleration = value; }
        }
    }
}
