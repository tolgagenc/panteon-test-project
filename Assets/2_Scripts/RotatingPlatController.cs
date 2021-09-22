using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatController : MonoBehaviour
{
    Rigidbody rb;

    Vector3 eulerAngleVel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        eulerAngleVel = new Vector3(0, 0, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVel * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
