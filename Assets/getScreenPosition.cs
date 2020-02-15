using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getScreenPosition : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject topLeft;
    public GameObject bottomRight;
    public Camera cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 topLeftPixel = cam.WorldToScreenPoint(topLeft.transform.position);
        Vector3 bottomRightPixel = cam.WorldToScreenPoint(bottomRight.transform.position);

        Debug.Log(topLeftPixel.x);
        Debug.Log(bottomRightPixel.x);
    }
}
