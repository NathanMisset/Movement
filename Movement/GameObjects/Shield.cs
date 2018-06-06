using Microsoft.Xna.Framework;
using System;

namespace Movement {
    class Shield : PhysicsObject{
        //Step 4.2: Declare a variable for the target of the shield
        public Vector2 target;
        private float springConstant;
        private Vector2 springForce;
        public Shield(string assetName, SpaceShip ship, Vector2 velocity, float springConstant)
            : base(assetName, ship.Position + new Vector2(30, 30), velocity, 15f, Vector2.Zero, Vector2.Zero, 1) {
            //Step 4.3: Set the ship parameter as the target of this shield
            target = ship.Position;
            this.springConstant = springConstant;
            
        }

        public override void Update(GameTime gameTime) {
            //Step 4.3: Calculate springing force. F = -x * k => force = -displacement * k
            springForce = (target - this.Position) * springConstant;
            //Step 4.4 Use force as acceleration
            force += springForce;
            acceleration = force;
            base.Update(gameTime);
        }
    }
}
