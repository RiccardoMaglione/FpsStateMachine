using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus : MonoBehaviour
{
    private float baseFOV;
    void Start()
    {
        baseFOV = Camera.main.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Camera.main.fieldOfView = 10;
        }
        else
        {
            Camera.main.fieldOfView = baseFOV;
        }
    }
}
