using UnityEngine;
using System.Collections;
using System;

public class BallView : GameViewComponent {

    public float InitialVelocityX;
    public float InitialVelocityY;

    private RectangleView rectangleView;

    public override void Awake()
    {
        base.Awake();
        rectangleView = GetComponent<RectangleView>();
    }

    public Ball CreateBall()
    {
        return new Ball(rectangleView.CreateRectangle(), InitialVelocityX, InitialVelocityY);
    }

}
