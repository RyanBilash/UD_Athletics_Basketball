using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoopDetector : MonoBehaviour
{
    public GameObject ball;
    public GameObject score;
    public TMP_Text scoreText;
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
        if (other.gameObject == ball && ball.GetComponent<Rigidbody>().useGravity == true)
        {
            ball.GetComponent<BallBehavior>().ResetPos();
            //score.GetComponent<>()
            int temp = int.Parse(scoreText.text) + 1;
            scoreText.SetText( (""+temp));

        }
    }
}
