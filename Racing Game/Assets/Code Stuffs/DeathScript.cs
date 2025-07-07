using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameObject startObject;
    public Transform startPoint;


    void Start()
    {
        startPoint = startObject.transform;
    }

    void Update()
    {
        if (this.gameObject.transform.position.y < -15)
        {
            this.gameObject.transform.position = startPoint.position;
        }
    }
}
