using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VisitorController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject curator;
    public GameObject thought;
    public bool arrived;

    public GameObject thoughtPlane;

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
        agent.SetDestination(nextLocation);

        if (arrived == true)
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
        GameObject o = curator.GetComponent<Curator>().getArtwork();
        Debug.Log(o);
        return o.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Artwork"))
        {
            arrived = true;
            currentLocation = other.gameObject.transform.position;
            thought.GetComponent<thoughtController>().resetScale();
            Material m = other.gameObject.GetComponent<Renderer>().material;
            thoughtPlane.GetComponent<changeMaterial>().ChangeMaterial(m);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Artwork"))
        {
            Debug.Log(other.gameObject.ToString());
            thought.GetComponent<thoughtController>().startFading();
        }
    }
}
