using System;
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
    public int maxWaitTime;

    public GameObject thoughtPlane;

    private Vector3 currentLocation;
    private Vector3 nextLocation;

    public NavMeshAgent agent;

    void Start()
    {
        arrived = false;
        nextLocation = getNextLocation();
        agent.speed = UnityEngine.Random.Range(4, 15);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(nextLocation);

        if (arrived == true)
        {
            StartCoroutine(chillBro());
            if (nextLocation != currentLocation)
            {
                
                agent.SetDestination(nextLocation);
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
        return o.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Artwork"))
        {
            arrived = true;
            currentLocation = other.gameObject.transform.position;
            thought.GetComponent<thoughtController>().resetScale();
            Texture t = other.gameObject.GetComponent<Renderer>().material.mainTexture;
            thoughtPlane.GetComponent<changeMaterial>().ChangeMaterial(t);

        }
    }

    [Obsolete]
    IEnumerator chillBro()
    {
        int t = UnityEngine.Random.Range(0, maxWaitTime);
        Debug.Log(t);
        agent.Stop();
        yield return new WaitForSeconds(t);
        agent.speed = UnityEngine.Random.Range(4, 15);
        agent.Resume();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Artwork"))
        {
            thought.GetComponent<thoughtController>().startFading();
        }
    }
}
