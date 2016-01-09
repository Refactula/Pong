using System;

public class PongGame {

    public Rectangle SceneBounds;
    public MovingObject Ball;
    public MovingObject LeftPaddle;
    public MovingObject RightPaddle;

    public void Update(float deltaTime)
    {
        Ball.Move(deltaTime);
        LeftPaddle.Move(deltaTime);
        RightPaddle.Move(deltaTime);

        LeftPaddle.PushInto(SceneBounds);
        RightPaddle.PushInto(SceneBounds);        
        Ball.PushInto(SceneBounds);

        Ball.PushOutOf(LeftPaddle);
        Ball.PushOutOf(RightPaddle);
    }
    
}
