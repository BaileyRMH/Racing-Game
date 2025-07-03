using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DaylightCycle : MonoBehaviour
{

    //public GameObject Light;

    //[Header("How Many Degrees /s")]
    //public float iteration;
    //public bool canRotate;

    //[Header("How Long Is One Day/Night Cycle?")]
    //public float howManyHours;
    //public float howManyMinutes;
    //public float howManySeconds;

    //[Header("Total Time")]
    //public float cycleTime;

    //void Start()
    //{
    //    cycleTime = (howManyHours * 60 * 60) + (howManyMinutes * 60) + howManySeconds;
    //    iteration = cycleTime / 360;
    //}

    //void Update()
    //{
    //    Debug.Log(canRotate);
    //    if (canRotate)
    //    {
    //        Light.transform.Rotate(Vector3.right, iteration);
    //        canRotate = false;
    //    }
    //    Invoke("ResetState", 1f);
    //}


    //void ResetState()
    //{
    //    canRotate = true;
    //    Debug.Log("Resetted your states fr");
    //}


    public float rotation;
    public float rotationAmount = 1f; // Amount to rotate in degrees

    void Update()
    {
        // Rotate the object around its local X axis
        rotation = this.transform.rotation.x;
        transform.Rotate(Vector3.right * rotationAmount * Time.deltaTime);
        if (rotation == 1)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

}
