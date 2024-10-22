using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class MoveOnClick : MonoBehaviour
{
    NavMeshAgent Agent;

    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f)) 
            {
                Agent.destination = hit.point;
            }
        }
    }
}
