using UnityEngine;
using System.Collections;
using System;

public class Rectangle
{
    private float[] values = new float[SideHelper.Values];

    public float Left { get { return Get(Side.Left); } set { Set(Side.Left, value); } }
    public float Bottom { get { return Get(Side.Bottom); } set { Set(Side.Bottom, value); } }
    public float Right { get { return Get(Side.Right); } set { Set(Side.Right, value); } }
    public float Top { get { return Get(Side.Top); } set { Set(Side.Top, value); } }

    public float Get(Side side)
    {
        return values[(int)side];
    }

    public void Set(Side side, float value)
    {
        values[(int)side] = value;
    }

    public Rectangle(float x, float y, float width, float height)
    {
        Left = x - width / 2F;
        Right = x + width / 2F;

        Bottom = y - height / 2F;
        Top = y + height / 2F;
    }

    public void MoveBy(float dx, float dy)
    {
        Left += dx;
        Right += dx;

        Bottom += dy;
        Top += dy;
    }

    public bool Intersects(Rectangle rectangle)
    {
        return Math.Max(Left, rectangle.Left) < Math.Min(Right, rectangle.Right) &&
            Math.Max(Bottom, rectangle.Bottom) < Math.Min(Top, rectangle.Top);
    }

    public float GetCenterX()
    {
        return (Left + Right) / 2F;
    }

    public float GetCenterY()
    {
        return (Bottom + Top) / 2F;
    }

    internal void SetCenter(float x, float y)
    {
        MoveBy(x - GetCenterX(), y - GetCenterY());
    }
}
