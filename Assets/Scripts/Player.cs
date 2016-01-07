using UnityEngine;
using System.Collections;
using System;

public class Player
{
    public Rectangle Paddle;
    private int scores;

    public Player(Rectangle paddle)
    {
        this.Paddle = paddle;
    }

    public void OnScored()
    {
        scores++;
    }
}