using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlane : MonoBehaviour
{

    public GameObject ball;
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
        if (other.gameObject==ball && ball.GetComponent<Rigidbody>().useGravity == true)
        {
            ball.GetComponent<BallBehavior>().ResetPos();
          
        }
    }
}
