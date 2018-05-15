﻿using Microsoft.Xna.Framework;
using System;

namespace Movement {
    class SpaceShip : PhysicsObject{
        //Step 2.2: Declare a variable for the target position of the ship 
        Vector2 target;
        //Step 2.3: Declare a variable for keeping track of the rotation of the ship

        public SpaceShip(string assetName, Vector2 position)
            : base(assetName, position, Vector2.Zero, 50f, Vector2.Zero) {
            layer = 2;
            //Step 2.4: Initialize this object's fields

        }

        //Step 2.5: Set the target position of the ship to the mouse position when the left button is pressed.
        //Tip: override HandleInput
        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.MouseLeftButtonPressed())
            {
                target = inputHelper.MousePosition;
            }
            base.HandleInput(inputHelper);
        }
        public override void Update(GameTime gameTime) {
            //Step 2.6: Move the ship to the position of the target.
            velocity = target - position;
            base.Update(gameTime);
        }
    }
}
