using UnityEngine;
using System.Collections;

public enum ElevatorPlatformState
{
    MovingDown,
    MovingUp,
    StoppedAtTop,
    StoppedAtBottom
}
public class ElevatorPlatform : MonoBehaviour {

    public float topPosition;
    public float waitTime;

    private float bottomPosition;
    private ElevatorPlatformState state;
    private float currentWaitTime;

	// Use this for initialization
	void Start () {
        bottomPosition = getCurrentHeight();
        state = ElevatorPlatformState.StoppedAtBottom;
	}
	
	// Update is called once per frame
	void Update () {
        switch (state)
        {
            case ElevatorPlatformState.StoppedAtBottom:
                if (currentWaitTime < waitTime)
                {
                    currentWaitTime += 1.0F;
                }
                else
                {
                    currentWaitTime = 0.0F;
                    state = ElevatorPlatformState.MovingUp;
                }
                break;

            case ElevatorPlatformState.StoppedAtTop:
                if (currentWaitTime < waitTime)
                {
                    currentWaitTime += 1.0F;
                }
                else
                {
                    currentWaitTime = 0.0F;
                    state = ElevatorPlatformState.MovingDown;
                }
                break;

            case ElevatorPlatformState.MovingDown:
                if (getCurrentHeight() > bottomPosition)
                {
                    transform.Translate(Vector3.back * 2.0F * Time.deltaTime);
                }
                else
                {
                    state = ElevatorPlatformState.StoppedAtBottom;
                }
                break;

            case ElevatorPlatformState.MovingUp:
                if (bottomPosition + getCurrentHeight() < bottomPosition + topPosition)
                {
                    transform.Translate(Vector3.forward * 2.0F * Time.deltaTime);
                }
                else
                {
                    state = ElevatorPlatformState.StoppedAtTop;
                }
                break;
        }
	}

    float getCurrentHeight()
    {
        return transform.position.y;
    }
}
