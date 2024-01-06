using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movingSpeed = 3f;
    [SerializeField] float rotateSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * movingSpeed * Time.deltaTime);
            Debug.Log("Pressed Space");
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // Debug.Log("Rotating Left");
            Rotation(Vector3.forward);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            // Debug.Log("Rotating Right");
            Rotation(Vector3.back);
        }
    }

    void Rotation(Vector3 vectorSet)
    {
        rb.freezeRotation = true; // freezing rotation for better control
        transform.Rotate(vectorSet * rotateSpeed * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation to turn on physic system
    }
}
