using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMaterial : MonoBehaviour
{
    Renderer r;
    public float speed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
        
    }
    private void Update()
    {
        transform.Rotate(Vector3.up * -speed * Time.deltaTime);  
    }
    public void ChangeMaterial(Texture t)
    {
        r.material.mainTexture = t;

    }
}
