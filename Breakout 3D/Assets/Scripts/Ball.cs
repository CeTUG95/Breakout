using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float ballInitvelocity = 6000f;
    private Rigidbody rb;
    private bool ballinPlay;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ballinPlay == false){
            transform.parent = null;
            ballinPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitvelocity, ballInitvelocity, 0));
        }

    }
}
