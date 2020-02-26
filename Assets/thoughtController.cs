﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thoughtController : MonoBehaviour
{
    // Start is called before the first frame update
    public float scale;

    private bool fading;
    void Start()
    {
        
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
            transform.localScale = new Vector3(1,1,1);
        }
    }

    public void resetScale()
    {
        transform.localScale = new Vector3(1,1,1);
        fading = false;

    }

    public void startFading() => fading = true;
}
