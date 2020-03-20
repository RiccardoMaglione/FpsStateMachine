using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float velocity = 6f;
    public float rotationVelocity = 30f;
    public Vector3 gravity = Vector3.down * 9.81f;
    CharacterController cController;
    public Camera Eyes;
    bool isShifting=false;

    void Awake()
    {
        cController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float forward = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 currentVelocity = this.transform.forward * forward * velocity;

        if (Input.GetKey(KeyCode.W))
        {
            cController.Move((currentVelocity + gravity) * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.W))
        {
            cController.Move((currentVelocity*2 + gravity) * Time.deltaTime);
        }

        this.transform.Rotate(Vector3.up * rotationVelocity * horizontal * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.LeftShift) && isShifting == false)
        {
            Eyes.transform.position = new Vector3(Eyes.transform.position.x, Eyes.transform.position.y - 1, Eyes.transform.position.z);
            isShifting = true;
        }
        if (Input.GetKeyDown(KeyCode.RightShift) && isShifting == true)
        {
            Eyes.transform.position = new Vector3(Eyes.transform.position.x, Eyes.transform.position.y + 1, Eyes.transform.position.z); ;
            isShifting = false;
        }
    }
}
