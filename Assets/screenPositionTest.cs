using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenPositionTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public Camera cam;
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPosition = cam.WorldToScreenPoint(target.transform.position);
        Debug.Log(screenPosition);
    }
}
