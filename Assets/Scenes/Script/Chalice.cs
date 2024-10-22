using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chalice : MonoBehaviour
{
    float _angle = 0f;
    public float rotationSpeed = 40f;
    public float frequency = 1f;
    public float magnitude = 1f;

    public Chalice GoldChalice;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _angle += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(_angle, Vector3.up);

        float yOffset = Mathf.Sin(Time.time * frequency) * magnitude;

        transform.position += new Vector3(0, yOffset, 0) * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(GoldChalice.gameObject);
    }
}
