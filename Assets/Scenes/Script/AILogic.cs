using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))] //Nice to have

public class AILogic : MonoBehaviour
{
    //Reference to other things
    public Keys key;// Only need to set if you want ai to auto move to key (look at update)
    public MoveDoor door;// Only need to set if you want ai to auto move to key (look at update)

    public Transform player;
    GameObject test;

    //Self reference
    public RandomWalk randomWalk;
    private NavMeshAgent _agent;
    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (door != null && key != null)
        {
            if (door.state == MoveDoor.DoorStates.Locked)
            {
                _agent.destination = key.transform.position;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (key != null && key.gameObject == other.gameObject)
        {
            key.UnlockDoor();
            Destroy(key.gameObject);
        }
        else if (key == null)
        {
            Keys foundKey = other.GetComponent<Keys>();
            if (foundKey != null)
            {
                foundKey.UnlockDoor();
                Destroy(foundKey.gameObject);
            }
        }
        
    }

}
