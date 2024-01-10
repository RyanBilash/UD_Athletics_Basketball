using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public TouchPhase touchPhase = TouchPhase.Ended;
    private Vector3 defaultPos = new Vector3(0, 1, 0.3f);

    private bool touchedFirstCollider = false;

    public GameObject topRimCollider;
    public GameObject bottomRimCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == touchPhase)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward,1.0f);
            foreach(RaycastHit hit in hits)
            {
                if(hit.collider != null)
                {
                    if(hit.transform.gameObject == topRimCollider)
                    {
                        touchedFirstCollider = !touchedFirstCollider;
                    }else if(hit.transform.gameObject == bottomRimCollider)
                    {
                        //increase points and reset again
                    }
                }
            }
        }
    }

    public void ThrowReady()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void ResetPos()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.transform.position = defaultPos;
    }
}
