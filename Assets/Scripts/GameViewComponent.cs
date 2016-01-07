using UnityEngine;
using System.Collections;

public class GameViewComponent : MonoBehaviour {

    protected GameController gameController;

    public virtual void Awake()
    {
        gameController = GetComponentInParent<GameController>();
    }

    public void Update(Rectangle rectangle)
    {
        GetComponent<RectangleView>().Update(rectangle);
    }

}
