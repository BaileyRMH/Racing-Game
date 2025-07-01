using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform target; // Assign the target object in the Inspector
    public float rotationSpeed = 2f; // Adjust for desired smoothness

    private Quaternion targetRotation;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target not assigned!");
            enabled = false; // Disable the script if no target is set
        }
        targetRotation = transform.rotation; // Initialize with current rotation
    }


    void Update()
    {
        if (target != null)
        {
            // Calculate the direction to the target
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            // Create a rotation that looks towards the target
            Quaternion desiredRotation = Quaternion.LookRotation(direction);

            // Smoothly interpolate towards the desired rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }


    }
}
