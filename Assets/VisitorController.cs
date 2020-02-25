using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VisitorController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject curator;
    public bool arrived;

    private Vector3 currentLocation;
    private Vector3 nextLocation;

    public NavMeshAgent agent;

    void Start()
    {
        arrived = false;
        nextLocation = getNextLocation();
    }

    // Update is called once per frame
    void Update()
    {

        if(arrived == true)
        {
            if (nextLocation != currentLocation)
            {
                agent.SetDestination(nextLocation);
                Debug.Log("New Desitination");
                arrived = false;
            }
            else
            {
                nextLocation = getNextLocation();
            }
        }
    }

    private Vector3 getNextLocation()
    {
        return curator.GetComponent<Curator>().getArtwork().transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Artwork"))
        {
            arrived = true;
            currentLocation = other.gameObject.transform.position;
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Artwork"))
            Debug.Log(other.gameObject.ToString());
    }
}
