using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject SceneBoundsObject;
    public GameObject BallObject;
    public GameObject LeftPaddleObject;
    public GameObject RightPaddleObject;

    public float PaddlesSpeed;
    public float MaxBallVerticalSpeed;

    private PongGame pongGame = new PongGame();

    void Start()
    {
        pongGame.SceneBounds = createRectangle(SceneBoundsObject);
        pongGame.Ball = createMovingObject(BallObject, true);
        pongGame.LeftPaddle = createMovingObject(LeftPaddleObject, false);
        pongGame.RightPaddle = createMovingObject(RightPaddleObject, false);
        pongGame.PaddlesSpeed = PaddlesSpeed;
        pongGame.MaxBallVerticalSpeed = MaxBallVerticalSpeed;
    }

    private MovingObject createMovingObject(GameObject gameObject, bool bounces)
    {
        Rectangle shape = createRectangle(gameObject);
        var initialVelocity = gameObject.GetComponent<InitialVelocity>();
        MovingObject result;
        if (initialVelocity != null)
            result = new MovingObject(pongGame, shape, initialVelocity.VelocityX, initialVelocity.VelocityY);
        else
            result = new MovingObject(pongGame, shape, 0, 0);
        result.Bounces = bounces;
        return result;
    }

    private Rectangle createRectangle(GameObject gameObject)
    {
        var rectangleMesh = gameObject.GetComponent<RectangleMesh>();
        var x = gameObject.transform.position.x;
        var y = gameObject.transform.position.y;
        var width = rectangleMesh.Width;
        var height = rectangleMesh.Height;
        return Rectangle.CreateFromCenter(x, y, width, height);
    }

    void Update()
    {
        pongGame.RequestLeftPaddleMove(Input.GetAxis("Vertical"));
        pongGame.Update(Time.deltaTime);
        updateViewComponents();
    }

    private void updateViewComponents()
    {
        updatePosition(BallObject, pongGame.Ball);
        updatePosition(LeftPaddleObject, pongGame.LeftPaddle);
        updatePosition(RightPaddleObject, pongGame.RightPaddle);
    }

    private void updatePosition(GameObject viewObject, MovingObject modelObject)
    {
        float x = modelObject.GetCenterX();
        float y = modelObject.GetCenterY();
        float z = viewObject.transform.position.z;
        var newPosition = new Vector3(x, y, z);
        viewObject.transform.position = newPosition;
    }

}
