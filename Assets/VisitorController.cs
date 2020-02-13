using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VisitorController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject curator;

    public NavMeshAgent agent;

    void Start()
    {
        agent.SetDestination(curator.GetComponent<Curator>().getArtwork());
    }

    // Update is called once per frame
    void Update()
    {
        //agent.SetDestination(curator.GetComponent<Curator>().getArtwork());
    }
}
