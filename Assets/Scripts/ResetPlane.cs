using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Basketball") && other.gameObject.GetComponent<Rigidbody>().useGravity==true)
        {
            other.gameObject.GetComponent<BallBehavior>().ResetPos();
        }
    }
}
