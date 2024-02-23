using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip box;
    AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        int rnd = Random.Range(0, 21);
        Debug.Log(rnd);
        if ( rnd == 0)
        {
            Invoke("Play", 2);
        }
    }
    void Play()
    {
        audioSource.PlayOneShot(box);
    }
}
