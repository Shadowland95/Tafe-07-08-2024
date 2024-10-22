using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    public enum DoorStates
    {
        Opened,
        Closed,
        Opening,
        Closing,
        Locked,
    }


    public Vector3 openingDirection = new Vector3(0f, -3f, 0f);
    public float speed = 5f;
    public bool unlockDoor = false;
    public bool doorCycle; 

    public float waitTime = 5f;
    private float _startOfWait = 0f;

    public DoorStates state = DoorStates.Closed;

    private Vector3 _closedPosition = Vector3.zero;
    private Vector3 _openPosition = Vector3.zero;


    void Start()
    {
        _closedPosition = transform.position;
        _openPosition = transform.position + openingDirection;
    }

    // Update is called once per frame
    void Update()
    {

        switch(state)
        {
            case DoorStates.Opened:
                //21
                if (doorCycle)
                {
                    if (waitTime < Time.time - _startOfWait) //20 -10 = 11
                    {
                        state = DoorStates.Closing;
                    }
                }
                break;
            case DoorStates.Closed:
                if (waitTime < Time.time - _startOfWait)
                {
                    state = DoorStates.Opening;
                }
                break;
            case DoorStates.Opening:
                transform.position = Vector3.MoveTowards(transform.position, _openPosition, speed * Time.deltaTime);

                if (Vector3.Distance(transform.position, _openPosition) < 0.01f)
                {
                    state = DoorStates.Opened;
                    _startOfWait = Time.time; // 10
                }
                break;
            case DoorStates.Closing:
                transform.position = Vector3.MoveTowards(transform.position, _closedPosition, speed * Time.deltaTime);
                //The door is open
                if (Vector3.Distance(transform.position, _closedPosition) < 0.01f)
                //if(transform.position == _openPosition) 
                //This can cause a bug maybe.
                {
                    state = DoorStates.Closed;
                    _startOfWait = Time.time;
                }
                break;
            case DoorStates.Locked:
                if(unlockDoor) // ! (not) // == true
                {
                    state = DoorStates.Opening;
                }
                break;
            default:
                break;
        }
    }
}
