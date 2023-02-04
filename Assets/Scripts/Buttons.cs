using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] AudioSource myaudio;


    public void PlayAudio()
    {
        myaudio.pitch = Random.Range(0.8f, 1.2f);
        myaudio.Play();
    }

    private void OnMouseExit()
    {
        Debug.Log("aa");
        PlayAudio();
    }
    
}
