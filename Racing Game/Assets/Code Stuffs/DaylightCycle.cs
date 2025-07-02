using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DaylightCycle : MonoBehaviour
{

    public GameObject Light;

    [Header("Speed Of Rotation")]
    public float rotationSpeed;

    [Header("How Long Is One Day/Night Cycle?")]
    public float howManyHours;
    public float howManyMinutes;
    public float howManySeconds;

    [Header("Total Time")]
    public float cycleTime;

    // Start is called before the first frame update
    void Start()
    {
        cycleTime = (howManyHours * 60 * 60) + (howManyMinutes * 60) + howManySeconds;
        rotationSpeed = 360 / cycleTime;
    }

    // Update is called once per frame
    void Update()
    {
        Light.transform.Rotate(Vector3.right, rotationSpeed);
    }




}
