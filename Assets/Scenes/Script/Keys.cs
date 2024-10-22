using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    float _angle = 0f;
    public float rotationSpeed = 40f;
    public float frequency = 1f;
    public float magnitude = 1f;

    public MoveDoor door;

    public void UnlockDoor()
    { 
        if (door != null)
        {
            door.unlockDoor = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //rotation
        _angle += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(_angle, Vector3.up);
        //transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        //bob up and down
        float yOffset = Mathf.Sin(Time.time * frequency) * magnitude;

        transform.position += new Vector3(0, yOffset, 0) * Time.deltaTime;
    }
}
