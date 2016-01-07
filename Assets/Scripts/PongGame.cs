using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class PongGame {

    public Rectangle Scene;
    public Ball Ball;
    public Player PlayerLeft;
    public Player PlayerRight;

    private float leftPaddleVelocity = 2F;

    public void Update(float deltaTime)
    {
        Ball.Move(deltaTime);

        PlayerLeft.Paddle.MoveBy(0, leftPaddleVelocity * deltaTime);
        if (PlayerLeft.Paddle.Top > Scene.Top)
        {
            float delta = Scene.Top - PlayerLeft.Paddle.Top;
            PlayerLeft.Paddle.MoveBy(0, 2 * delta);
            leftPaddleVelocity = -leftPaddleVelocity;
        }
        else if (PlayerLeft.Paddle.Bottom < Scene.Bottom)
        {
            float delta = Scene.Bottom - PlayerLeft.Paddle.Bottom;
            PlayerLeft.Paddle.MoveBy(0, 2 * delta);
            leftPaddleVelocity = -leftPaddleVelocity;
        }

        PlayerRight.Paddle.SetCenter(PlayerRight.Paddle.GetCenterX(), Ball.Shape.GetCenterY());
        if (PlayerRight.Paddle.Top > Scene.Top)
        {
            PlayerRight.Paddle.MoveBy(0, Scene.Top - PlayerRight.Paddle.Top);
        }
        else if (PlayerRight.Paddle.Bottom < Scene.Bottom)
        {
            PlayerRight.Paddle.MoveBy(0, Scene.Bottom - PlayerRight.Paddle.Bottom);
        }

        Ball.BounceFromSceneWalls(Scene);        
        Ball.BounceFromPaddle(PlayerLeft.Paddle);
        Ball.BounceFromPaddle(PlayerRight.Paddle);

        // Detect ball leaving the scene.
        if (Ball.Shape.Left < Scene.Left)
        {
            // Opposite player scores
            PlayerRight.OnScored();
            resetGameState();
        }
        else if (Ball.Shape.Right > Scene.Right)
        {
            // Opposite player scores.
            PlayerLeft.OnScored();
            resetGameState();
        }
    }
    
    private void resetGameState()
    {
        SceneManager.LoadScene("GameScene");
    }
}
