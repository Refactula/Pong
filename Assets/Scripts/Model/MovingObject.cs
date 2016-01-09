using System;

public class MovingObject
{
    public Rectangle Shape;
    public float VelocityX;
    public float VelocityY;
    public bool Bounces;

    public MovingObject(Rectangle shape, float velocityX, float velocityY)
    {
        this.Shape = shape;
        this.VelocityX = velocityX;
        this.VelocityY = velocityY;
    }

    public float GetCenterX()
    {
        return Shape.GetCenterX();
    }

    public float GetCenterY()
    {
        return Shape.GetCenterY();
    }

    public void Move(float deltaTime)
    {
        Shape.MoveBy(VelocityX * deltaTime, VelocityY * deltaTime);
    }

    public void PushOutOf(MovingObject other)
    {
        PushOutOf(other.Shape);
    }

    public void PushOutOf(Rectangle rectangle)
    {
        if (!Shape.Intersects(rectangle))
        {
            return;
        }
        float horizontalCorrection = VelocityX < 0 ? rectangle.Right - Shape.Left : rectangle.Left - Shape.Right;
        float verticalCorrection = VelocityY < 0 ? rectangle.Top - Shape.Bottom : rectangle.Bottom - Shape.Top;
        if (Math.Abs(horizontalCorrection) < Math.Abs(verticalCorrection))
            OnHorizontalCollision(horizontalCorrection);
        else
            OnVerticalCollision(verticalCorrection);
    }

    public void PushInto(Rectangle rectangle)
    {
        if (Shape.Top > rectangle.Top)
            OnVerticalCollision(rectangle.Top - Shape.Top);
        else if (Shape.Bottom < rectangle.Bottom)
            OnVerticalCollision(rectangle.Bottom - Shape.Bottom);

        if (Shape.Left < rectangle.Left)
            OnHorizontalCollision(rectangle.Left - Shape.Left);
        else if (Shape.Right > rectangle.Right)
            OnHorizontalCollision(rectangle.Right - Shape.Right);
    }

    private void OnHorizontalCollision(float correction)
    {
        if (Bounces)
        {
            Shape.MoveBy(correction * 2f, 0);
            VelocityX = -VelocityX;
        }
        else
        {
            Shape.MoveBy(correction, 0);
        }
    }

    private void OnVerticalCollision(float correction)
    {
        if (Bounces)
        {
            Shape.MoveBy(0, correction * 2f);
            VelocityY = -VelocityY;
        }
        else
        {
            Shape.MoveBy(0, correction);
        }
    }
}
