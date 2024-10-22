using UnityEngine;

public class SlideingDoors : MonoBehaviour
{
    public Vector3 deltaPosition = new Vector3(0f, -2f, 0f);
    public float speed = 5f;
    public float waitTime = 3f;

    private Vector3 _closedPostion;
    private Vector3 _openPosition;

    // Start is called before the first frame update
    void Start()
    {
        _closedPostion = transform.position;
        _openPosition = transform.position + deltaPosition;
    }

    public void OpenTheDoor()
    {
        transform.position = Vector3.MoveTowards(transform.position, _openPosition, speed * Time.deltaTime);
    }

//Uncomment /* if you want the door to open automatically 

    // Update is called once per frame
    void Update()
    {
        if (Time.time > waitTime)
        {
            OpenTheDoor();
        }
    }
}
