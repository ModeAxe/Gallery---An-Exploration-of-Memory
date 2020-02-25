using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VisitorController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject curator;
    public bool arrived;

    private GameObject currentLocation;
    private GameObject nextLocation;

    public NavMeshAgent agent;

    void Start()
    {
        arrived = false;
        currentLocation = curator.GetComponent<Curator>().getArtwork();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(currentLocation.transform.position);

        if(arrived == true)
        {

            do
            {
                nextLocation = curator.GetComponent<Curator>().getArtwork();
                Debug.Log("Thinking....");
                Debug.Log(nextLocation);
            } while (nextLocation.ToString() == currentLocation.ToString());

            agent.SetDestination(nextLocation.transform.position);
            Debug.Log("New Desitination");
            arrived = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Artwork"))
        {
            arrived = true;
            currentLocation = other.gameObject;
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Artwork"))
            Debug.Log(other.gameObject.ToString());
    }
}
