using Microsoft.Xna.Framework;
using System;

namespace Movement {
    class PlayingState : GameObjectList{
        protected PhysicsObject ball;
        protected SpaceShip spaceship;
        protected Shield shield;
        public PlayingState() {
            //Step 1.1: Create a PhysicsObject, place it in the middle of the screen and add it to the PlayingState.
            //Use one of the ball sprites  and scale = 30
            ball = new PhysicsObject("GreenBallX", new Vector2(Movement.Screen.X / 2, Movement.Screen.Y / 2), new Vector2(0,0), 30, new Vector2(0, 0), Vector2.Zero, 1);
            this.Add(ball);
            
            //Step 2.1: Create a SpaceShip, place it in the middle of the screen and add it to the PlayingState.
            //Use the spaceship sprite.
            spaceship = new SpaceShip("spr_spaceship", new Vector2(Movement.Screen.X/2,Movement.Screen.Y/2), ball, 600f, 3f);
            this.Add(spaceship);
            //Step 4.1: Create a Shield without starting velocity, place it in the middle of the screen and add it to the PlayingState.
            //Use one of the ball sprites. 
            shield = new Shield("spr_ball_green", spaceship, new Vector2(0,0), 0.2f);
            this.Add(shield);
        }

        public override void HandleInput(InputHelper inputHelper) {
            //Step 1.2: If the left mousebutton is pressed, draw the PhysicsObject of step 1.1 on the position of the mouse.
            if (inputHelper.MouseLeftButtonPressed())
            {
                ball.Position = inputHelper.MousePosition;
            }
            base.HandleInput(inputHelper);
        }
        public override void Update(GameTime gameTime)
        {
            spaceship.LookAt(ball, 90);
            shield.target = spaceship.Position;
            base.Update(gameTime);
        }
    }
}
