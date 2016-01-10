using System;

public class PongGame {

    public Rectangle SceneBounds;
    public MovingObject Ball;
    public MovingObject LeftPaddle;
    public MovingObject RightPaddle;

    public float PaddlesSpeed;
    public float MaxBallVerticalSpeed;

    public void Update(float deltaTime)
    {
        Ball.Move(deltaTime);
        LeftPaddle.Move(deltaTime);
        RightPaddle.Move(deltaTime);

        LeftPaddle.PushInto(SceneBounds);
        RightPaddle.PushInto(SceneBounds);
        Ball.PushInto(SceneBounds);

        pushOutTheBall(LeftPaddle);
        pushOutTheBall(RightPaddle);
    }

    private void pushOutTheBall(MovingObject paddle)
    {
        if (Ball.PushOutOf(paddle))
        {
            float coef = (Ball.GetCenterY() - paddle.Shape.GetCenterY()) / paddle.GetHeight();
            float newVelocity = UnityEngine.Mathf.Clamp(coef, -1F, 1F) * MaxBallVerticalSpeed;
            Ball.VelocityY = coef * MaxBallVerticalSpeed;
        }
    }

    public void RequestLeftPaddleMove(float axisValue)
    {
        LeftPaddle.VelocityY = axisValue * PaddlesSpeed;
    }

}
