using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoop : MonoBehaviour
{
    private AudioSource audioSource;
    private float cooldown;

    public List<AudioClip> clipList;
    private AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            if(cooldown < 0f)
            {
                clip = clipList[Random.Range(0, clipList.Count)];
                audioSource.clip = clip;
                audioSource.Play();
                cooldown = Random.Range(5f, 30f);
            }
            else
            {
                cooldown -=Time.deltaTime;
            }
        }
    }
}
