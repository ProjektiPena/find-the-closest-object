using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSwordHit : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    private AudioSource audiosource;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    private void hit()
    {
        AudioClip clip = GetRandomClip();
        audiosource.PlayOneShot(clip);

    }

    private AudioClip GetRandomClip()
    {

        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }
}
