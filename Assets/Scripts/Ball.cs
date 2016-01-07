using UnityEngine;
using System.Collections;
using System;

public class Ball
{
    public Rectangle Shape;
    private float velocityX;
    private float velocityY;

    public Ball(Rectangle shape, float velocityX, float velocityY)
    {
        this.Shape = shape;
        this.velocityX = velocityX;
        this.velocityY = velocityY;
    }

    public void Move(float deltaTime)
    {
        Shape.MoveBy(velocityX * deltaTime, velocityY * deltaTime);
    }

    public void BounceFromSceneWalls(Rectangle scene)
    {
        if (Shape.Top > scene.Top)
        {
            onBounceY(scene.Top - Shape.Top);
        }
        else if (Shape.Bottom < scene.Bottom)
        {
            onBounceY(scene.Bottom - Shape.Bottom);
        }

        // TODO: Temporal
        //if (Shape.Left < scene.Left)
        //{
        //    onBounceX(scene.Left - Shape.Left);
        //}

        //else if (Shape.Right > scene.Right)
        //{
        //    onBounceX(scene.Right - Shape.Right);
        //}
    }

    internal void BounceFromPaddle(Rectangle paddle)
    {
        if (Shape.Intersects(paddle))
        {
            if (velocityX < 0)
            {
                onBounceX(paddle.Right - Shape.Left);
            }
            else
            {
                onBounceX(paddle.Left - Shape.Right);
            }
        }
    }

    private void onBounceY(float delta)
    {
        Shape.MoveBy(0, 2 * delta);
        velocityY = -velocityY;
    }

    private void onBounceX(float delta)
    {
        Shape.MoveBy(2 * delta, 0);
        velocityX = -velocityX;
    }
}