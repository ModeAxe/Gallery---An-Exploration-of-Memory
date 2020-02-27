using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thoughtController : MonoBehaviour
{
    // Start is called before the first frame update
    public float scale;
    public Vector3 sphereSize;

    private bool fading;
    void Start()
    {
        this.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(fading)
        {
            if(transform.localScale.x > 0)
                transform.localScale -= new Vector3(scale * Time.deltaTime, scale * Time.deltaTime, scale * Time.deltaTime);
        }
        else
        {
            fading = false;
            transform.localScale = sphereSize;
        }
    }

    public void resetScale()
    {
        transform.localScale = sphereSize;
        this.GetComponent<Renderer>().enabled = true;
        fading = false;

    }

    public void startFading() => fading = true;
}
