using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public Transform player;
    public float lookSensitivity = 350f;

    public float updownLookRotation = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //look on x
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity * Time.deltaTime;
        player.Rotate(Vector3.up * mouseX);

        //look on y
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity * Time.deltaTime;
        updownLookRotation -= mouseY;
        updownLookRotation = Mathf.Clamp(updownLookRotation, -32f, 80f);//Restriction of angles
        transform.localRotation = Quaternion.Euler(updownLookRotation, 0f, 0f);
    }
}
