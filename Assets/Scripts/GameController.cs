using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public GameObject BallObject;
    public GameObject SceneObject;
    public GameObject PaddleLeftObject;
    public GameObject PaddleRightObject;

    private PongGame pongGame = new PongGame();

    private BallView ballView;
    private RectangleView sceneView;
    private RectangleView paddleLeftView;
    private RectangleView paddleRightView;

    public void Awake()
    {
        Application.runInBackground = true;
        
        ballView = BallObject.GetComponent<BallView>();
        sceneView = SceneObject.GetComponent<RectangleView>();
        paddleLeftView = PaddleLeftObject.GetComponent<RectangleView>();
        paddleRightView = PaddleRightObject.GetComponent<RectangleView>();
    }

    public void Start()
    {
        pongGame.Ball = ballView.CreateBall();
        pongGame.Scene = sceneView.CreateRectangle();
        pongGame.PlayerLeft = new Player(paddleLeftView.CreateRectangle());
        pongGame.PlayerRight = new Player(paddleRightView.CreateRectangle());
    }

    void Update()
    {
        pongGame.Update(Time.deltaTime);
        ballView.Update(pongGame.Ball.Shape);
        paddleLeftView.Update(pongGame.PlayerLeft.Paddle);
        paddleRightView.Update(pongGame.PlayerRight.Paddle);
    }

}
