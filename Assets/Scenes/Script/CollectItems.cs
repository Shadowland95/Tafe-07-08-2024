using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
//
{
    public MoveDoor door;
    public int collectedItems = 0;

    // Update is called once per frame
    void Update()
    {
        if (collectedItems >= 1)
        {
     //       door.OpenTheDoor();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Name of GO: " + collision.gamebject.name);
        //Debug.Log("Tag of GO: " + collision.gameObject.tag);
        if(collision.gameObject.tag == "Collectable")
        {
            collectedItems++;
            Destroy(collision.gameObject);
        }
    }
}
//

