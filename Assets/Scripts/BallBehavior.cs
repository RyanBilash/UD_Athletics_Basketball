using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public TouchPhase touchPhase = TouchPhase.Ended;
    private Vector3 defaultPos = new Vector3(0, 1, 0.3f);

    private List<Vector3> tracking = new List<Vector3>();
    private float velocity = 10f;

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
        if(gameObject.transform.position.y < -5f)
        {
            ResetPos();
        }
        
    }

    public void ThrowReady()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    public static IEnumerator Frames(int frameCount)
    {
        //counts down frames to wait
        while (frameCount > 0)
        {
            frameCount--;
            yield return null;
        }
    }

    public IEnumerator IncreaseVelocityWhenThrown()
    {
        yield return Frames(1); //wait 1 frame before collecting speed data
        //Debug.Log(gameObject.GetComponent<Rigidbody>().velocity);
        Vector3 tempVel = gameObject.GetComponent<Rigidbody>().velocity;
        
        tempVel.z = Mathf.Min(0f, 2*tempVel.z) * -1; //make sure the ball is thrown towards the net
        
        tempVel.y = 0.2f * tempVel.y; //increase throw height a bit, because of how the default throw works
        tempVel.x = (tempVel.x / 2)*-1; //try to not have it veer off to the side
        
        gameObject.GetComponent<Rigidbody>().AddForce(tempVel, ForceMode.VelocityChange);
    }

    public void Throw()
    {
        StartCoroutine(IncreaseVelocityWhenThrown());
    }

    public void ResetPos()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.transform.position = defaultPos;
    }
}
