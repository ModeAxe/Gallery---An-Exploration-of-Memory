using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VisitorController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject curator;
    public bool arrived;

    public NavMeshAgent agent;

    void Start()
    {
        arrived = false;
        agent.SetDestination(curator.GetComponent<Curator>().getArtwork());
    }

    // Update is called once per frame
    void Update()
    {
        if(arrived == true)
        {
            agent.SetDestination(curator.GetComponent<Curator>().getArtwork());
            Debug.Log("New Desitination");
            arrived = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Artwork"))
        {
            arrived = true;
            Debug.Log("I'm here");
        }
    }
}
