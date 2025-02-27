using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButton : MonoBehaviour
{
    public AudioClip buttonSound;


    private AudioSource audioSource;
    private CounterScript counterScript;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = buttonSound;

       
    }


}
