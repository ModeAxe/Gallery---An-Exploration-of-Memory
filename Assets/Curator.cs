using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curator : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] artworks;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getArtwork()
    {
        return artworks[Random.Range(0,artworks.Length)];
    }
}
