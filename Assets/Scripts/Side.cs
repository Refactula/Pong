using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum Side
{
    Left,
    Bottom,
    Right,
    Top,
}

public static class SideHelper
{
    public static readonly int Values = Enum.GetNames(typeof(Side)).Length;

    public static readonly Side[] Horizontal = { Side.Left, Side.Right };
    public static readonly Side[] Vertical = { Side.Bottom, Side.Top };

    public static Side Opposite(this Side side)
    {
        switch (side)
        {
            case Side.Left: return Side.Right;
            case Side.Bottom: return Side.Top;
            case Side.Right: return Side.Left;
            case Side.Top: return Side.Bottom;
        }
        throw new ArgumentException();
    }
}
