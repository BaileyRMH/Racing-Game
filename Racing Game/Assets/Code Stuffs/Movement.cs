using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody body;

    public Vector3 explosionPosition;

    public float radius;
    public float explosionForce;
    

    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        explosionPosition = Random.insideUnitSphere;
        body.AddExplosionForce(explosionForce, explosionPosition, radius);
        body.AddForce(new Vector3 (1,1,1) , ForceMode.Acceleration);
    }
}
