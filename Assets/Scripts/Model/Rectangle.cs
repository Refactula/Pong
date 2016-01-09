using System;

public class Rectangle
{
    public float Left;
    public float Bottom;
    public float Right;
    public float Top;

    public static Rectangle CreateFromCenter(float centerX, float centerY, float width, float height)
    {
        float halfWidth = width / 2F;
        float halfHeight = height / 2F;
        return new Rectangle(centerX - halfWidth, centerY - halfHeight, centerX + halfWidth, centerY + halfHeight);
    }

    public float GetCenterX()
    {
        return (Left + Right) / 2F;
    }

    public float GetCenterY()
    {
        return (Bottom + Top) / 2F;
    }

    public Rectangle(float left, float bottom, float right, float top)
    {
        this.Left = left;
        this.Bottom = bottom;
        this.Right = right;
        this.Top = top;
    }

    public void MoveBy(float dx, float dy)
    {
        Left += dx;
        Bottom += dy;
        Right += dx;
        Top += dy;
    }

    public bool Intersects(Rectangle other)
    {
        return Math.Min(Right, other.Right) > Math.Max(Left, other.Left) && 
               Math.Min(Top, other.Top) > Math.Max(Bottom, other.Bottom);
    }
}