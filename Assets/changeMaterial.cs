using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMaterial : MonoBehaviour
{
    Renderer r;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMaterial(Material m)
    {
        r.sharedMaterial = m;

    }
}
